using System;
using AppKit;
using CoreGraphics;
using CoreText;
using MoonSharp.Interpreter;
using Graphics = CoreGraphics.CGContext;

namespace GooseLua.Lua
{
    [MoonSharpUserData]
    class Draw
    {
        private Script script;
        private Surface surface;
        private Graphics graphics { get => _G.graphics; }
        private CGColor whiteColor = new CGColor(1f, 1f, 1f, 1f);

        [MoonSharpHidden]
        public Draw(Script script, Surface surface)
        {
            this.script = script;
            this.surface = surface;
        }

        private void CheckGraphics() {
            if (graphics == default(Graphics)) throw new ScriptRuntimeException("Graphics not initialized or invalid hook.");
        }

        private NSTextAlignment GetTextAlignment(int xAlign) {
            switch (xAlign)
            {
                case (int)TextAlign.TEXT_ALIGN_RIGHT:
                    return NSTextAlignment.Right;
                case (int)TextAlign.TEXT_ALIGN_CENTER:
                    return NSTextAlignment.Center;
                case (int)TextAlign.TEXT_ALIGN_LEFT:
                default:
                    return NSTextAlignment.Left;
            }
        }

        public void DrawText(string text, string font = "DermaDefault", int x = 0, int y = 0, Table color = null, int xAlign = (int)TextAlign.TEXT_ALIGN_LEFT) => SimpleText(text, font, x, y, color, xAlign);

        public float GetFontHeight(string font) {
            CheckGraphics();
            return (float)surface.GetFont(font).font.Size;
        }

        public void RoundedBox(int cornerRadius, int x, int y, int width, int height, Table color) => RoundedBoxEx(cornerRadius, x, y, width, height, color, true, true, true, true);

        public void RoundedBoxEx(int cornerRadius, int x, int y, int width, int height, Table color, bool roundTopLeft = false, bool roundTopRight = false, bool roundBottomLeft = false, bool roundBottomRight = false) {
            CheckGraphics();
            nfloat[] angles = { (nfloat)Math.PI, (nfloat)(Math.PI + Math.PI / 2), 0, (nfloat)Math.PI / 2 };

            graphics.BeginPath();
            if (roundTopLeft) {
                graphics.AddArc(x + cornerRadius, y + cornerRadius, cornerRadius, angles[0], angles[1], false);
            } else {
                graphics.MoveTo(x, y);
            }

            if (roundTopRight) {
                graphics.AddArc(x + width - cornerRadius, y + cornerRadius, cornerRadius, angles[1], angles[2], false);
            } else {
                graphics.AddLineToPoint(x + width, y);
            }

            if (roundBottomRight) {
                graphics.AddArc(x + width - cornerRadius, y + height - cornerRadius, cornerRadius, angles[2], angles[3], false);
            } else {
                graphics.AddLineToPoint(x + width, y + height);
            }

            if (roundBottomLeft) {
                graphics.AddArc(x + cornerRadius, y + height - cornerRadius, cornerRadius, angles[3], angles[0], false);
            } else {
                graphics.AddLineToPoint(x, y + height);
            }

            graphics.ClosePath();
            graphics.SetFillColor(Surface.GetColor(color));
            graphics.FillPath();
        }

        public DynValue SimpleText(string text, string font = "DermaDefault", int x = 0, int y = 0, Table color = null, int xAlign = (int)TextAlign.TEXT_ALIGN_LEFT, int yAlign = (int)TextAlign.TEXT_ALIGN_TOP) {
            CheckGraphics();
            var pos = new CGPoint(x, y);
            var textFont = surface.GetFont(font);
            var textColor = Surface.GetColor(color, whiteColor);
            NSGraphicsContext.CurrentContext = NSGraphicsContext.FromCGContext(graphics, true);
            var drawableText = surface.GetStringToDraw(text, textFont.nsFont, textColor, GetTextAlignment(xAlign));
            drawableText.DrawString(pos);
            var size = drawableText.Size;
            return DynValue.NewTuple(DynValue.NewNumber(size.Width), DynValue.NewNumber(size.Height));
        }

        public DynValue SimpleTextOutlined(string text, string font = "DermaDefault", int x = 0, int y = 0, Table color = null, int xAlign = (int)TextAlign.TEXT_ALIGN_LEFT, int yAlign = (int)TextAlign.TEXT_ALIGN_TOP, double outlineWidth = 1, Table outlineColor = null) {
            CheckGraphics();
            var pos = new CGPoint(x, y);
            var textFont = surface.GetFont(font);
            var alignment = GetTextAlignment(xAlign);
            var fillColor = Surface.GetColor(color, whiteColor);
            NSGraphicsContext.CurrentContext = NSGraphicsContext.FromCGContext(graphics, true);
            var drawableText = surface.GetStringToDraw(text, textFont.nsFont, fillColor, alignment, Surface.GetColor(outlineColor, whiteColor), outlineWidth);
            drawableText.DrawString(pos);
            var size = drawableText.Size;
            return DynValue.NewTuple(DynValue.NewNumber(size.Width), DynValue.NewNumber(size.Height));
        }

        public DynValue Text(Table tab) {
            return SimpleText(
                tab.Get("text").String,
                tab.Get("font")?.String ?? "DermaDefault",
                (int)(tab.Get("pos")?.Table.Get(1).Number ?? 0),
                (int)(tab.Get("pos")?.Table.Get(2).Number ?? 0),
                tab.Get("color")?.Table,
                (int)(tab.Get("xalign")?.Number ?? (int)TextAlign.TEXT_ALIGN_LEFT),
                (int)(tab.Get("yalign")?.Number ?? (int)TextAlign.TEXT_ALIGN_TOP)
                );
        }

        public DynValue TextShadow(Table tab, double distance, int alpha = 200) {
            return SimpleText(
                tab.Get("text").String,
                tab.Get("font")?.String ?? "DermaDefault",
                (int)(tab.Get("pos")?.Table.Get(1).Number ?? 0),
                (int)(tab.Get("pos")?.Table.Get(2).Number ?? 0),
                script.DoString($"Color(0,0,0,{alpha})").Table,
                (int)(tab.Get("xalign")?.Number ?? (int)TextAlign.TEXT_ALIGN_LEFT),
                (int)(tab.Get("yalign")?.Number ?? (int)TextAlign.TEXT_ALIGN_TOP)
                );
        }

        public DynValue WordBox(int borderSize, int x, int y, string text, string font, Table boxColor, Table textColor) {
            var pos = new CGPoint(x + borderSize, y + borderSize);
            var textFont = surface.GetFont(font);
            var drawableText = surface.GetStringToDraw(text, textFont.nsFont, Surface.GetColor(textColor));
            var size = drawableText.Size;

            RoundedBox(borderSize, x, y, (int)size.Width + borderSize * 2, (int)size.Height + borderSize * 2, boxColor);
            NSGraphicsContext.CurrentContext = NSGraphicsContext.FromCGContext(graphics, true);
            drawableText.DrawString(pos);

            return DynValue.NewTuple(DynValue.NewNumber(size.Width + borderSize * 2), DynValue.NewNumber(size.Height + borderSize * 2));
        }

        #region non-facepunch API
        public DynValue MeasureText(string text, string font = "DermaDefault") {
            CheckGraphics();

            var textFont = surface.GetFont(font);
            var drawableText = surface.GetStringToDraw(text, textFont.nsFont);
            var size = drawableText.Size;
            return DynValue.NewTable(new Table(script, DynValue.NewNumber(size.Width), DynValue.NewNumber(size.Height)));
        }
        #endregion
    }
}
