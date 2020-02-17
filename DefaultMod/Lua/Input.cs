using System.Runtime.InteropServices;
using System.Windows.Forms;
using MoonSharp.Interpreter;

namespace GooseLua.Lua
{
    [MoonSharpUserData]
    class Input
    {
        private Script script;

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        [MoonSharpHidden]
        public Input(Script script)
        {
            this.script = script;
        }

        public bool IsKeyDown(int key) => GetAsyncKeyState((Keys)key) != 0;

        public string GetKeyName(int key) => ((Keys)key).ToString();
    }
}
