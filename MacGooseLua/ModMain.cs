using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using AppKit;
using CoreGraphics;
using Foundation;
using GooseShared;
using MoonSharp.Interpreter;

namespace GooseLua
{
    [Register("MacGooseLuaMod")]
    public class MacGooseLua : NSObject, IMod, INSTextFieldDelegate
    {
        private Lua.Config config = null;
        private NSBundle bundle = null;

        void IMod.Init()
        {
            var modPath = API.Helper.getModDirectory(this);
            var path = Path.GetFullPath(Path.Combine(modPath, "..", "..", "Lua Mods"));
            bundle = new NSBundle(modPath);

            var script = new Script(CoreModules.Preset_SoftSandbox);
            script.Options.DebugPrint = HandlePrint;
            _G.path = path;
            _G.LuaState = script;

            script.Globals["ScrW"] = new CallbackFunction((ScriptExecutionContext context, CallbackArguments arguments) => {
                return DynValue.NewNumber(NSScreen.MainScreen.Frame.Width);
            });

            script.Globals["ScrH"] = new CallbackFunction((ScriptExecutionContext context, CallbackArguments arguments) => {
                return DynValue.NewNumber(NSScreen.MainScreen.Frame.Height);
            });

            UserData.RegisterAssembly();
            Lua.Enums.Register(_G.LuaState);

            var surface = new Lua.Surface(script);
            var hook = new Lua.Hook();
            _G.hook = hook;
            script.Globals["draw"] = new Lua.Draw(script, surface);
            script.Globals["surface"] = surface;
            script.Globals["hook"] = hook;
            script.Globals["input"] = new Lua.Input(script);
            script.Globals["Msg"] = script.Globals["print"];
            script.Globals["MsgC"] = new CallbackFunction((ScriptExecutionContext context, CallbackArguments arguments) => {
                List<dynamic> args = new List<dynamic>();
                Closure isColor = (Closure)context.CurrentGlobalEnv["IsColor"];
                for (int i = 0; i < arguments.Count; i++)
                {
                    DynValue arg = arguments.RawGet(i, true);
                    if (arg == DynValue.Nil) continue;
                    if (arg.Type == DataType.String)
                    {
                        args.Add(arg.String);
                    }
                    else if (isColor.Call(arg).CastToBool())
                    {
                        Table color = arg.Table;
                        int r = (int)color.Get("r").Number;
                        int g = (int)color.Get("g").Number;
                        int b = (int)color.Get("b").Number;
                        int a = (int)color.Get("a").Number;
                        args.Add(Color.FromArgb(a, r, g, b));
                    }
                    else
                    {
                        throw ScriptRuntimeException.BadArgument(i, "MsgC", "expected color or string");
                    }

                }
                MsgC(args.ToArray());
                return DynValue.Nil;
            });
            config = new Lua.Config(Path.Combine(path, "config.ini"));
            script.Globals["config"] = config;

            script.Globals["AddConsoleCommand"] = new CallbackFunction((ScriptExecutionContext context, CallbackArguments arguments) => {
                return DynValue.Nil;
            });

            script.Globals["Derma_StringRequest"] = new CallbackFunction((ScriptExecutionContext context, CallbackArguments arguments) => {
                return DynValue.Nil;
            });

            script.Globals["Derma_Message"] = new CallbackFunction((ScriptExecutionContext context, CallbackArguments arguments) => {
                return DynValue.Nil;
            });

            script.Globals["HTTP"] = new CallbackFunction((ScriptExecutionContext context, CallbackArguments arguments) => {
                if (arguments.Count == 1 && arguments[0].Type == DataType.Table)
                {
                    return DynValue.NewBoolean(Lua.Http.Request(arguments[0].Table));
                }
                return DynValue.False;
            });

            Include(script, "http");
            Include(script, "math");
            Include(script, "string");
            Include(script, "table");
            Include(script, "bit");
            Include(script, "color");
            Include(script, "concommand");
            Include(script, "defaultcmds");

            //KeyEnums.Load();

            GooseProxy.Register();
            script.Globals["goose"] = new GooseProxy(script);
            script.Globals["GetModDirectory"] = new CallbackFunction((ScriptExecutionContext context, CallbackArguments arguments) => {
                return DynValue.NewString(_G.path);
            });
            script.Globals["CurTime"] = new CallbackFunction((ScriptExecutionContext context, CallbackArguments arguments) => {
                return DynValue.NewNumber(SamEngine.Time.time);
            });

            script.Globals["RegisterTask"] = CallbackFunction.FromMethodInfo(script, typeof(Task).GetMethod("Register"));

            InjectionPoints.PreTickEvent += preTick;
            InjectionPoints.PostTickEvent += postTick;
            InjectionPoints.PreRenderEvent += preRender;
            InjectionPoints.PostRenderEvent += postRender;
            InjectionPoints.PreUpdateRigEvent += preRig;
            InjectionPoints.PostUpdateRigEvent += postRig;

            LoadLuaMods(script, path);
        }

        private void LoadLuaMods(Script script, string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string[] files = Directory.GetFiles(path, "*.lua");
            foreach (string scriptPath in files)
            {
                string scriptName = Path.GetFileNameWithoutExtension(scriptPath);
                try
                {
                    script.DoFile(scriptPath, script.Globals, scriptName);
                }
                catch (Exception ex)
                {
                    _G.HandleScriptException(ex);
                }
            }
        }

        private void Include(Script script, string name)
        {
            var code = GetResource($"Includes/{name}.lua");
            script.DoString(code, script.Globals, name);
        }

        public string GetResource(string path)
        {
            var resourceName = "__xammac_content_" + path.Replace("/", "_f");
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                return new StreamReader(stream).ReadToEnd();
            }
        }

        public void preTick(GooseEntity g)
        {
            _G.goose = g;
            _G.hook.CallHooks("preTick");
        }

        public void postTick(GooseEntity g)
        {
            _G.goose = g;
            _G.hook.CallHooks("postTick");
        }

        public void preRender(GooseEntity g, CGContext ctx)
        {
            _G.goose = g;
            _G.graphics = ctx;
            _G.hook.CallHooks("preRender");
        }

        public void postRender(GooseEntity g, CGContext ctx)
        {
            _G.goose = g;
            _G.graphics = ctx;
            _G.hook.CallHooks("postRender");
        }

        public void preRig(GooseEntity g)
        {
            _G.goose = g;
            _G.hook.CallHooks("preRig");
        }

        public void postRig(GooseEntity g)
        {
            _G.goose = g;
            _G.hook.CallHooks("postRig");
        }

        [Export("openModsFolder:")]
        public void OpenModsFolder(NSObject sender)
        {
            NSWorkspace.SharedWorkspace.OpenFile(_G.path);
        }

        [Export("editConfigFile:")]
        public void EditConfigFile(NSObject sender)
        {
            NSWorkspace.SharedWorkspace.OpenFile(config.configFilePath, "TextEdit.app", true);
        }

        private void LoadNibResource(string nibName)
        {
            NSNib nib = null;
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"__xammac_content_{nibName}.nib"))
            {
                var buf = new byte[stream.Length];
                stream.Read(buf, 0, buf.Length);
                nib = new NSNib(NSData.FromArray(buf), bundle);
            }

            nib.InstantiateNibWithOwner(this, out NSArray nibObjects);
        }

        #region Console
        [Export("consoleWindow")]
        public NSWindow consoleWindow{ get; set; } = null;
        [Export("consoleTextView")]
        public NSTextView consoleTextView { get; set; } = null;
        [Export("consoleInputField")]
        public NSTextField consoleInputField { get; set; } = null;

        [Export("openConsole:")]
        public void OpenConsole(NSObject sender)
        {
            if (consoleWindow == null) {
                LoadNibResource("Console");
                consoleTextView.TextStorage.SetString(new NSAttributedString(bufferedOutput,
                    font: consoleTextView.Font,
                    foregroundColor: consoleTextView.TextColor));
            }
            consoleWindow.MakeKeyAndOrderFront(sender);
            consoleWindow.MakeFirstResponder(consoleInputField);
            consoleTextView.ScrollRangeToVisible(new NSRange(bufferedOutput.Length, 0));
        }

        [Export("runConsoleCommand:")]
        public void RunConsoleCommand(NSObject sender)
        {
            if (sender is NSTextField field)
            {
                var commandString = field.StringValue;
                field.StringValue = "";
                RunConsoleCommand(commandString);

            }
            else if (sender is NSString stringArg)
            {
                RunConsoleCommand((string)stringArg);
            }
        }

        public void RunConsoleCommand(string command)
        {
            AddConsoleText(command + "\n");
        }

        public void AddConsoleText(string text)
        {
            AddConsoleText(new NSAttributedString(text,
                font: consoleTextView.Font,
                foregroundColor: consoleTextView.TextColor));
        }

        public void AddConsoleText(NSAttributedString text)
        {
            consoleTextView.TextStorage.Append(text);
            // remove excess
            while (consoleTextView.String.Length > consoleMaxSize)
            {
                var firstLineLength = consoleTextView.String.IndexOf("\n");
                if (firstLineLength == -1)
                {
                    consoleTextView.TextStorage.SetString(text);
                } else
                {
                    consoleTextView.TextStorage.DeleteRange(new NSRange(0, firstLineLength));
                }
            }
            consoleTextView.ScrollRangeToVisible(new NSRange(consoleTextView.String.Length, 0));
        }

        private string bufferedOutput = "";
        private int consoleMaxSize = 1024 * 1024;

        private void HandlePrint(string text)
        {
            if (consoleTextView != null)
            {
                AddConsoleText(text + "\n");
            } else
            {
                bufferedOutput += text + "\n";
                // remove excess
                while (bufferedOutput.Length > consoleMaxSize)
                {
                    var firstLineLength = bufferedOutput.IndexOf("\n");
                    if (firstLineLength == -1)
                    {
                        bufferedOutput = text;
                    } else
                    {
                        bufferedOutput = bufferedOutput.Substring(firstLineLength);
                    }
                    
                }
            }
        }

        public void MsgC(params dynamic[] args)
        {
            Color currentColor = Color.White;
            foreach (dynamic arg in args)
            {
                if (arg is Color colorArg)
                {
                    currentColor = colorArg;
                }
                else if (arg is string stringArg)
                {
                    AddConsoleText(new NSAttributedString(stringArg,
                        font: consoleTextView.Font,
                        foregroundColor: NSColor.FromRgba(currentColor.R, currentColor.G, currentColor.B, currentColor.A)));
                }
            }
        }
 
        #endregion

        #region Editor
        [Export("editorWindow")]
        public NSWindow editorWindow { get; set; } = null;
        [Export("editorTextView")]
        public NSTextView editorTextView { get; set; } = null;

        [Export("openEditor:")]
        public void OpenEditor(NSObject sender)
        {
            if (editorWindow == null)
            {
                LoadNibResource("Editor");
            }
            editorWindow.MakeKeyAndOrderFront(sender);
        }

        [Export("runScript:")]
        public void RunScript(NSObject sender)
        {
            var code = editorTextView.String;
            try
            {
                _G.LuaState.DoString(code, _G.LuaState.Globals, "editor");
            }
            catch (InterpreterException ex)
            {
                OpenConsole(sender);
                MsgC(Color.Red, string.Format("[ERROR] {0}: {1}\n{2}\n", ex.Source, ex.DecoratedMessage, ex.StackTrace));
            }
        }
        #endregion
    }
}
