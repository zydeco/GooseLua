using System;
using CoreFoundation;
using GooseLua.Lua;
using GooseShared;
using MoonSharp.Interpreter;

namespace GooseLua
{
    class _G
    {
        public static Script LuaState;
        public static GooseEntity goose;
        public static CoreGraphics.CGContext graphics;
        public static string path;
        public static Hook hook;

        public static void HandleScriptException(Exception ex)
        {
            Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
        }

        public static void RunOnMainQueue(Action action)
        {
            DispatchQueue.MainQueue.DispatchAsync(action);
        }
    }
}
