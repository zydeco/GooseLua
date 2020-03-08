using System.Collections.Generic;
using System.Linq;
using System.Media;
using MoonSharp.Interpreter;
using CoreGraphics;
using Graphics = CoreGraphics.CGContext;
using AppKit;
using CoreText;
using System.Drawing;
using Foundation;

namespace GooseLua.Lua
{
    [MoonSharpUserData]
    class Surface
    {
        private Script script;
        private Graphics graphics { get => _G.graphics; }
        private CGColor drawColor = new CGColor(1.0f, 1.0f, 1.0f);
        private Dictionary<string, Font> fonts = new Dictionary<string, Font>();
        private Closure isColor = null;
        private CGPoint textPos = CGPoint.Empty;
        private CGColor textColor = new CGColor(1.0f, 1.0f, 1.0f);
        private Font textFont = null;
        private Dictionary<string, SoundPlayer> sounds = new Dictionary<string, SoundPlayer>();

        internal class Font
        {
            public CTFont font;
            public NSFont nsFont;
            public FontStyle style;
        }

        [MoonSharpHidden]
        public Surface(Script script)
        {
            this.script = script;
            InitFonts();
        }

        [MoonSharpHidden]
        public Font GetFont(string name) => fonts.ContainsKey(name) ? fonts[name] : fonts["Default"];

        private void InitFonts() {
            CreateFont("DermaDefault", "Tahoma", 13f);
            CreateFont("DermaDefaultBold", "Tahoma", 13f, FontStyle.Bold);
            CreateFont("DermaLarge", "Tahoma", 32f);
            CreateFont("DebugFixed", "Courier New", 14f);
            CreateFont("DebugFixedSmall", "Courier New", 14f);
            CreateFont("Default", "Verdana", 12f);
            CreateFont("Marlett", "Marlett", 14f);
            CreateFont("Trebuchet18", "Trebuchet MS", 18f);
            CreateFont("Trebuchet24", "Trebuchet MS", 24f);
            CreateFont("HudHintTextLarge", "Verdana", 14f);
            CreateFont("HudHintTextSmall", "Verdana", 11f);
            CreateFont("CenterPrintText", "Trebuchet MS", 18f);
            CreateFont("HudSelectionText", "Verdana", 8f);
            CreateFont("CloseCaption_Normal", "Tahoma", 26f);
            CreateFont("CloseCaption_Italic", "Tahoma", 26f, FontStyle.Italic);
            CreateFont("CloseCaption_Bold", "Tahoma", 26f, FontStyle.Bold);
            CreateFont("CloseCaption_BoldItalic", "Tahoma", 26f, FontStyle.Bold | FontStyle.Italic);
            CreateFont("TargetID", "Trebuchet MS", 24f, FontStyle.Bold);
            CreateFont("TargetIDSmall", "Trebuchet MS", 18f, FontStyle.Bold);
            CreateFont("BudgetLabel", "Courier New", 14f);
            CreateFont("HudNumbers", "Trebuchet MS", 32f);
            SetFont("Default");
        }

        private CGColor GetColor(DynValue rOrColor, int g, int b, int a) {
            if (isColor == null) {
                isColor = (Closure)script.Globals["IsColor"];
            }

            int r;

            if (isColor.Call(rOrColor).CastToBool()) {
                Table color = rOrColor.Table;
                r = (int)color.Get("r").Number;
                g = (int)color.Get("g").Number;
                b = (int)color.Get("b").Number;
                a = (int)color.Get("a").Number;
            } else {
                r = (int)(rOrColor.CastToNumber() ?? 255.0);
            }

            return new CGColor(r / 255f, g / 255f, b / 255f, a / 255f);
        }

        public static CGColor GetColor(Table color, CGColor defaultColor = null) {
            if (color == null) {
                return defaultColor;
            }
            int r = (int)color.Get("r").Number;
            int g = (int)color.Get("g").Number;
            int b = (int)color.Get("b").Number;
            int a = (int)color.Get("a").Number;

            return new CGColor(r / 255f, g / 255f, b / 255f, a / 255f);
        }

        public static Table GetColorTable(Script script, CGColor cgcolor) {
            NSColor color = NSColor.FromCGColor(cgcolor);
            color = color.UsingColorSpace(NSColorSpace.DeviceRGBColorSpace);
            int red = (int)(color.RedComponent * 255f);
            int green = (int)(color.GreenComponent * 255f);
            int blue = (int)(color.BlueComponent * 255f);
            int alpha = (int)(color.AlphaComponent * 255f);
            return script.DoString($"return Color({red},{green},{blue},{alpha})").Table;
        }

        private Table GetColorTable(CGColor color) => GetColorTable(script, color);

        private void CheckGraphics() {
            if (graphics == default(Graphics)) throw new ScriptRuntimeException("Graphics not initialized or invalid hook.");
        }

        public void CreateFont(string name, Table attributes) {
            FontStyle style = FontStyle.Regular;
            double size = attributes.Get("size")?.CastToNumber() ?? 13.0;
            double weight = attributes.Get("weight")?.CastToNumber() ?? 400;
            if (attributes.Get("underline").CastToBool()) {
                style |= FontStyle.Underline;
            }
            if (attributes.Get("italic").CastToBool()) {
                style |= FontStyle.Italic;
            }
            if (attributes.Get("bold").CastToBool() || weight >= 600 ) {
                style |= FontStyle.Bold;
            }
            if (attributes.Get("strikeout").CastToBool()) {
                style |= FontStyle.Strikeout;
            }

            CreateFont(name, attributes.Get("font").CastToString(), (float)size, style);
        }

        private void CreateFont(string fontKey, string fontName, float size, FontStyle style = FontStyle.Regular) {
            var font = new CTFont(fontName, size);
            if (fonts.ContainsKey(fontKey)) {
                fonts.Remove(fontKey);
            }
            CTFontSymbolicTraits traits = CTFontSymbolicTraits.None;
            if (style.HasFlag(FontStyle.Bold)) {
                traits |= CTFontSymbolicTraits.Bold;
            }
            if (style.HasFlag(FontStyle.Italic)) {
                traits |= CTFontSymbolicTraits.Italic;
            }
            if (traits != CTFontSymbolicTraits.None) {
                font = font.WithSymbolicTraits(size, traits, CTFontSymbolicTraits.Bold | CTFontSymbolicTraits.Italic);
            }
            fonts.Add(fontKey, new Font() {
                font = font,
                nsFont = NSFont.FromCTFont(font),
                style = style
            });
        }

        public void DrawCircle(int originX, int originY, int radius, DynValue rOrColor, int g = 255, int b = 255, int a = 255) {
            CheckGraphics();

            graphics.SetStrokeColor(GetColor(rOrColor, g, b, a));
            graphics.SetLineWidth(1f);
            graphics.StrokeEllipseInRect(new CGRect(originX - radius, originY - radius, 2 * radius, 2 * radius));
        }

        public void DrawLine(int sx, int sy, int fx, int fy) {
            CheckGraphics();

            graphics.SetStrokeColor(drawColor);
            graphics.SetLineWidth(1f);
            graphics.BeginPath();
            graphics.MoveTo(sx, sy);
            graphics.AddLineToPoint(fx, fy);
            graphics.StrokePath();
        }

        public void DrawOutlinedRect(int x, int y, int w, int h) {
            CheckGraphics();

            graphics.SetStrokeColor(drawColor);
            graphics.SetLineWidth(1f);
            graphics.StrokeRect(new CGRect(x, y, w, h));
        }

        public void DrawPoly(Table vertices) {
            CheckGraphics();
            var points = vertices.Pairs.Select(v =>
                new CGPoint((float)v.Value.Table.Get("x").Number, (float)v.Value.Table.Get("y").Number)
            ).ToArray<CGPoint>();

            graphics.SetFillColor(drawColor);
            graphics.BeginPath();
            graphics.AddLines(points);
            graphics.FillPath();
        }

        public void DrawRect(int x, int y, int w, int h) {
            CheckGraphics();
            graphics.SetFillColor(drawColor);
            graphics.FillRect(new CGRect(x, y, w, h));
        }

        public void DrawText(string text) {
            CheckGraphics();
            GetStringToDraw(text).DrawAtPoint(textPos);
        }

        internal NSAttributedString GetStringToDraw(string text, NSFont font = null, CGColor color = null, NSTextAlignment alignment = NSTextAlignment.Left, CGColor strokeColor = null, double outlineWidth = 0f) {
            var attributes = new NSStringAttributes();
            attributes.Font = font ?? textFont.nsFont;
            attributes.ForegroundColor = NSColor.FromCGColor(color ?? textColor);
            if (textFont.style.HasFlag(FontStyle.Underline)) {
                attributes.UnderlineStyle = (int)NSUnderlineStyle.Single;
            }
            if (textFont.style.HasFlag(FontStyle.Strikeout)) {
                attributes.StrikethroughStyle = 1;
            }
            attributes.ParagraphStyle = new NSMutableParagraphStyle() {
                Alignment = alignment
            };
            if (outlineWidth != 0f) {
                attributes.StrokeWidth = (float)(outlineWidth * -1 * (100 / font.PointSize));
                if (strokeColor != null) {
                    attributes.StrokeColor = NSColor.FromCGColor(strokeColor);
                }
            }
            
            return new NSAttributedString(text, attributes);
        }

        public Table GetDrawColor() {
            return GetColorTable(drawColor);
        }

        public Table GetTextColor() {
            return GetColorTable(textColor);
        }

        public DynValue GetTextSize(string text) {
            if (graphics == default(Graphics) || textFont == null) {
                return DynValue.Nil;
            }
            var size = GetStringToDraw(text).Size;
            return DynValue.NewTuple(DynValue.NewNumber(size.Width), DynValue.NewNumber(size.Height));
        }

        public void PlaySound(string soundfile) {
            if (!sounds.TryGetValue(soundfile, out SoundPlayer player)) {
                player = new SoundPlayer(soundfile);
                sounds.Add(soundfile, player);
            }
            player.Play();
        }

        public void SetDrawColor(DynValue rOrColor, int g = 255, int b = 255, int a = 255) {
            drawColor = GetColor(rOrColor, g, b, a);
        }
        
        public void SetFont(string fontName) {
            textFont = GetFont(fontName);
        }

        public void SetTextColor(DynValue rOrColor, int g = 255, int b = 255, int a = 255) {
            textColor = GetColor(rOrColor, g, b, a);
        }

        public void SetTextPos(int x, int y) {
            textPos = new CGPoint(x, y);
        }
    }
}
