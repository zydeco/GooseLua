using System;
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
    public class MacGooseLua : NSObject, IMod
    {        
        void IMod.Init()
        {
            var path = Path.GetFullPath(Path.Combine(API.Helper.getModDirectory(this), "..", "..", "Lua Mods"));
            var script = new Script(CoreModules.Preset_SoftSandbox);
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
            script.Globals["config"] = new Lua.Config(Path.Combine(path, "config.ini"));

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

        [Export("doSomething:")]
        public void DoSomething(NSObject sender)
        {
            Console.WriteLine("Doing something from preferences!");
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
    }
}
