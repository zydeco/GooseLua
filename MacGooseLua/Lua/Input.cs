using System.Drawing;
using System.Runtime.InteropServices;
using AppKit;
using CoreGraphics;
using MoonSharp.Interpreter;

namespace GooseLua.Lua
{
    [MoonSharpUserData]
    class Input
    {
        private Script script;

        [MoonSharpHidden]
        public Input(Script script)
        {
            this.script = script;
        }

        public bool IsKeyDown(int key) => false;

        public string GetKeyName(int key) => "unknown";

        public DynValue GetCursorPos() {
            var pos = NSEvent.CurrentMouseLocation;
            var screenHeight = NSScreen.MainScreen.Frame.Height;
            return DynValue.NewTuple(DynValue.NewNumber(pos.X), DynValue.NewNumber(screenHeight - pos.Y));
        }

        public void SetCursorPos(int x, int y) => CGDisplay.MoveCursor(CGDisplay.MainDisplayID, new CGPoint(x, y));
        
        public bool IsMouseDown(int button) {
            var buttons = NSEvent.CurrentPressedMouseButtons;
            switch ((Mouse)button)
            {
                case Mouse.MOUSE_LEFT:
                    return (buttons & 1) != 0;
                case Mouse.MOUSE_RIGHT:
                    return (buttons & 2) != 0;
                case Mouse.MOUSE_MIDDLE:
                    return (buttons & 4) != 0;
                case Mouse.MOUSE_4:
                    return (buttons & 8) != 0;
                case Mouse.MOUSE_5:
                    return (buttons & 16) != 0;
                default:
                    throw new ScriptRuntimeException("Unsupported mouse button " + button);
            }
        }
    }
}
