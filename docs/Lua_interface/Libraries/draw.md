# draw

The draw library's purpose is to simplify the usage of the [surface](surface.md) library.

These functions should only be called from `preRender` and `postRender` [hooks](hook.md).

## DrawText

```lua
draw.DrawText( string text, string font = "DermaDefault", number x = 0, number y = 0, table color = Color( 255, 255, 255, 255 ), number xAlign = TEXT_ALIGN_LEFT )
```

It draws text.

#### Arguments

1. `text`: the text to draw.
2. `font`: the font, created with [surface.CreateFont](surface.md#createFont) or one of the [Default Fonts](surface.md#default-fonts).
3. `x`: the X coordinate.
4. `y`: the Y coordinate.
5. `color`: color for the text, created with [Color](../functions.md#color).
6. `xAlign`: horizontal alignment of the text, see [enums/Text Alignment](../Types/enums.md#text-alignment).


## GetFontHeight

```lua
number draw.GetFontHeight( string font )
```

Returns the height of the specified font in points.

#### Arguments

1. `font`: the font, created with [surface.CreateFont](surface.md#createFont) or one of the [Default Fonts](surface.md#default-fonts).

## RoundedBox

```lua
draw.RoundedBox( number cornerRadius, number x, number y, number width, number height, table color )
```

Draws a rectangle with rounded corners, filled with a color.

#### Arguments

1. `cornerRadius`: radius of the rounded corners.
2. `x`: the X coordinate of the top left of the rectangle.
3. `y`: the Y coordinate of the top left of the rectangle.
4. `width`: the width of the rectangle.
5. `height`: the height of the rectangle.
6. `color`: color to fill the shape with, created with [Color](../functions.md#color).

## RoundedBoxEx

```lua
draw.RoundedBoxEx( number cornerRadius, number x, number y, number width, number height, table color, boolean roundTopLeft = false, boolean roundTopRight = false, boolean roundBottomLeft = false, boolean roundBottomRight = false )
```

Like [RoundedBox](#roundedbox), but allows you to specify which of the corners should be rounded.

#### Arguments

1. `cornerRadius`: radius of the rounded corners.
2. `x`: the X coordinate of the top left of the rectangle.
3. `y`: the Y coordinate of the top left of the rectangle.
4. `width`: the width of the rectangle.
5. `height`: the height of the rectangle.
6. `color`: color to fill the shape with, created with [Color](../functions.md#color).
7. `roundTopLeft`: whether the top left corner should be rounded.
8. `roundTopRight`: whether the top right corner should be rounded.
9. `roundBottomLeft`: whether the bottom left corner should be rounded.
10. `roundBottomRight`: whether the bottom right corner should be rounded.

## SimpleText

```lua
number, number draw.SimpleText( string text, string font = "DermaDefault", number x = 0, number y = 0, table color = Color( 255, 255, 255, 255 ), number xAlign = TEXT_ALIGN_LEFT, number yAlign = TEXT_ALIGN_TOP )
```

Draws text on the screen.

#### Arguments

1. `text`: The text to be drawn.
2. `font`: the font, created with [surface.CreateFont](surface.md#createFont) or one of the [Default Fonts](surface.md#default-fonts).
3. `x`: The X coordinate.
4. `y`: The Y coordinate.
5. `color`: color for the text, created with [Color](../functions.md#color).
6. `xAlign`: horizontal alignment of the text, see [enums/Text Alignment](../Types/enums.md#text-alignment).
7. `yAlign`: vertical alignment of the text, see [enums/Text Alignment](../Types/enums.md#text-alignment).

#### Returns

1. The width of the text. Same value as if you were calling [surface.GetTextSize](surface.md#gettextsize).
2. The height of the text. Same value as if you were calling  [surface.GetTextSize](surface.md#gettextsize).

## SimpleTextOutlined

```lua
number, number draw.SimpleTextOutlined( string text, string font = "DermaDefault", number x = 0, number y = 0, table color = Color( 255, 255, 255, 255 ), number xAlign = TEXT_ALIGN_LEFT, number yAlign = TEXT_ALIGN_TOP, number outlinewidth, table outlinecolor = Color( 255, 255, 255, 255 ) )
```

Draws text on the screen.

#### Arguments

1. `text`: the text to be drawn.
2. `font`: the font, created with [surface.CreateFont](surface.md#createFont) or one of the [Default Fonts](surface.md#default-fonts).
3. `x`: the X coordinate.
4. `y`: the Y coordinate.
5. `color`: color for the text, created with [Color](../functions.md#color).
6. `xAlign`: horizontal alignment of the text, see [enums/Text Alignment](../Types/enums.md#text-alignment).
7. `yAlign`: vertical alignment of the text, see [enums/Text Alignment](../Types/enums.md#text-alignment).
8. `outlinewidth`: width of the outline.
9. `outlinecolor`: color of the ouline (see [Color](../functions.md#color)).

#### Returns

1. The width of the text. Same value as if you were calling [surface.GetTextSize](surface.md#gettextsize).
2. The height of the text. Same value as if you were calling  [surface.GetTextSize](surface.md#gettextsize).

## Text

```lua
number, number draw.Text( table textdata )
```

Works like [draw.SimpleText](#simpletext) but uses a table structure instead.

#### Arguments

1. `textdata`: the text properties

#### Returns

1. The width of the text. Same value as if you were calling [surface.GetTextSize](surface.md#gettextsize).
2. The height of the text. Same value as if you were calling  [surface.GetTextSize](surface.md#gettextsize).

#### Example

```lua
hook.Add( "postRender", "drawTextExample", function()
    draw.Text( {
        text = "test",
        font = "DebugFixed",
        pos = { 50, 50 },
        color = Color(255, 120, 0),
        xalign = TEXT_ALIGN_LEFT,
        yalign = TEXT_ALIGN_TOP
    } )
end )
```

## TextShadow

```lua
number, number draw.TextShadow( table textdata, number distance, number alpha = 200 )
```

Works like [draw.Text](#test), but draws the text as a shadow.

#### Arguments

1. `textdata`: the text properties
2. `distance`: how far away the shadow appear
3. `alpha`: the opacity of the shadow from 0 (invisible) to 255 (fully black)

#### Returns

1. The width of the text. Same value as if you were calling [surface.GetTextSize](surface.md#gettextsize).
2. The height of the text. Same value as if you were calling  [surface.GetTextSize](surface.md#gettextsize).

## WordBox

```lua
number, number draw.WordBox( number bordersize, number x, number y, string text, string font, table boxcolor, table textcolor )
```

Draws a rounded box with text in it.

#### Arguments 

1. `bordersize`: size of the border.
2. `x`: the X coordinate.
3. `y`: the Y coordinate.
4. `text`: the text to be drawn.
5. `font`: the font, created with [surface.CreateFont](surface.md#createFont) or one of the [Default Fonts](surface.md#default-fonts).

6. `boxcolor`: color for the box, created with [Color](../functions.md#color).
7. `text`: color for the text, created with [Color](../functions.md#color).

#### Returns

1. The width of the word box.
2. The height of the word box.
