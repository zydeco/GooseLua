using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;

namespace GooseLua.Lua {
    [MoonSharpUserData]
    class Hook {
        [MoonSharpHidden]
        private Dictionary<string, Dictionary<string, Closure>> hooks = new Dictionary<string, Dictionary<string, Closure>>();
        private List<Tuple<string, string, Closure>> deferredUpdates = new List<Tuple<string, string, Closure>>();
        private bool callingHooks = false;

        public Hook() {
            hooks["preRig"] = new Dictionary<string, Closure>();
            hooks["postRig"] = new Dictionary<string, Closure>();
            hooks["preTick"] = new Dictionary<string, Closure>();
            hooks["postTick"] = new Dictionary<string, Closure>();
            hooks["preRender"] = new Dictionary<string, Closure>();
            hooks["postRender"] = new Dictionary<string, Closure>();
        }

        public void Add(string hook, string name, Closure action) {
            if (callingHooks) {
                // defer update
                deferredUpdates.Add(Tuple.Create(hook, name, action));
                return;
            }
            if (hooks[hook].ContainsKey(name)) {
                hooks[hook][name] = action;
            } else {
                hooks[hook].Add(name, action);
            }
        }

        public void Remove(string hook, string name) {
            if (callingHooks) {
                // defer update
                deferredUpdates.Add(Tuple.Create(hook, name, default(Closure)));
                return;
            }
            hooks[hook].Remove(name);
        }

        [MoonSharpHidden]
        public void CallHooks(string hook) {
            callingHooks = true;
            foreach (Closure func in hooks[hook].Values) {
                try {
                    func.Call();
                } catch (Exception ex) {
                    _G.HandleScriptException(ex);
                }
            }
            callingHooks = false;
            RunDeferredUpdates();
        }

        private void RunDeferredUpdates() {
            foreach(var update in deferredUpdates) {
                if (update.Item3 == default(Closure)) {
                    Remove(update.Item1, update.Item2);
                } else {
                    Add(update.Item1, update.Item2, update.Item3);
                }
            }
            deferredUpdates.Clear();
        }
    }
}
