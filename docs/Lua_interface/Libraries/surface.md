# surface

The surface library allows you to draw things on the screen.

These functions should only be called from `preRender` and `postRender` [hooks](hook.md), except for [CreateFont](#createfont).

#### Example

```lua
hook.Add("postRender", "a rectangle", function()
   surface.SetDrawColor(0,255,0)
   surface.DrawRect(100, 100, 100, 100)
   surface.SetDrawColor(200,100,0)
   surface.DrawLine(100, 100, 200, 200)
end)
```

## CreateFont

```lua
surface.CreateFont( string fontName, table fontData )
```

Creates a new font. Due to the static nature of fonts, do NOT create the font more than once. You should only be creating them once, it is recommended to create them at the top of your script. Do not use this function within a render hook!

Be sure to check the List of [Default Fonts](#default-fonts) first! Those fonts can be used without using this function.

#### Arguments

1. `fontName`: the name for the new font. you will use this in drawing functions to refer to this font.
2. `fontData`: the font properties. see the example below

#### Example

```lua
surface.CreateFont( "TheDefaultSettings", {
	font = "Arial", --  Use the font-name which is shown to you by your operating system Font Viewer, not the file name
	size = 13,
	bold = false,
	underline = false,
	italic = false,
	strikeout = false
})

hook.Add( "postRender", "HelloThere", function()
	draw.SimpleText( "Hello there!", "TheDefaultSettings", ScrW() * 0.5, ScrH() * 0.25, color_white, TEXT_ALIGN_CENTER )
end )
```

## DrawCircle

```lua
surface.DrawCircle( number originX, number originY, number radius, number r, number g, number b, number a = 255 )
```

Draws a circle outline with a given color.

#### Arguments

1. `originX`: the center X integer coordinate.
2. `originY`: the center Y integer coordinate.
3. `radius`: the radius of the circle.
4. `r`: the red value of the color to draw the circle with, or a [Color](../functions.md#color).
5. `g`: the green value of the color to draw the circle with, unused if a [Color](../functions.md#color) was given.
6. `b`: the blue value of the color to draw the circle with, unused if a [Color](../functions.md#color) was given.
7. `a`: the alpha value of the color to draw the circle with, unused if a [Color](../functions.md#color) was given.

#### Example

Draws an orange circle at position 500, 500 with a varying/animated radius of 50 to 150.

```lua
hook.Add( "preRender", "DrawCircleExample", function()
    surface.DrawCircle( 500, 500, 100 + math.sin( CurTime() ) * 50, Color( 255, 120, 0 ) )
end )
```

## DrawLine

```lua
surface.DrawLine( number startX, number startY, number endX, number endY )
```

Draws a line from one point to another, using the color set by [surface.SetDrawColor](#setdrawcolor).

#### Arguments

1. `startX`: The start X coordinate of the line.
2. `startY`: The start Y coordinate of the line.
3. `endX`: The end X coordinate of the line.
4. `endY`: The end Y coordinate of the line.

#### Example

```lua
hook.Add("preRender", "Draw Line", function()
    surface.SetDrawColor(255, 255, 255)
    surface.DrawLine(5, 5, 10, 10)
end)
```

## DrawOutlinedRect

```lua
surface.DrawOutlinedRect( number x, number y, number width, number height )
```

Draws a hollow box with a border width of 1px, using the color set by [surface.SetDrawColor](#setdrawcolor).

#### Arguments

1. `x`: The X coordinate of the rectangle.
2. `y`: The Y coordinate of the rectangle.
3. `width`: The width of the rectangle.
4. `height`: The height of the rectangle.

## DrawPoly

```lua
surface.DrawPoly( table vertices )
```

Draws a filled polygon made up of vertices, using the color set by [surface.SetDrawColor](#setdrawcolor).

#### Example

```lua
local triangle = {
	{ x = 100, y = 200 },
	{ x = 150, y = 100 },
	{ x = 200, y = 200 }
}

hook.Add("postRender", "PolygonTest", function()
    surface.SetDrawColor( 255, 0, 0, 255 )
    draw.NoTexture()
    surface.DrawPoly( triangle )
end )
```

## DrawRect

```lua
surface.DrawRect( number x, number y, number width, number height )
```

Draws a solid rectangle on the screen, using the color set by [surface.SetDrawColor](#setdrawcolor).

#### Arguments

1. `x`: The X coordinate of the rectangle.
2. `y`: The Y coordinate of the rectangle.
3. `width`: The width of the rectangle.
4. `height`: The height of the rectangle.

#### Example

```lua
hook.Add("preRender", "Draw Box", function()
    surface.SetDrawColor(255, 255, 255)
    surface.DrawRect(5, 5, 100, 100)
end)
```

## DrawText

```lua
surface.DrawText( string text )
```

Draw the specified text on the screen, using the previously set position, font and color.

## GetDrawColor

```lua
surface.GetDrawColor()
```

Returns the current draw color.

## GetTextColor

```lua
surface.GetTextColor()
```

Returns the current text color.

## GetTextSize

```lua
number, number surface.GetTextSize( string text )
```

Returns the size of the given text, using the font set by [surface.SetFont](#setfont)

#### Returns

1. The width of the text, in pixels.
2. The height of the text, in pixels.

## PlaySound

```lua
surface.PlaySound( string soundfile )
```

Plays a sound file. See [GetModDirectory](../functions.md#getmoddirectory).

#### Arguments

1. `soundfile`: path to the sound file

## SetDrawColor

```lua
surface.SetDrawColor( number r, number g, number b, number a = 255 )
```

Set the color of any future shapes to be drawn.

#### Arguments

1. `r`: the red value of the color (0 to 255), or a [Color](../functions.md#color).
2. `g`: the green value of the color (0 to 255), unused if a [Color](../functions.md#color) was iven.
3. `b`: the blue value of the color (0 to 255), unused if a [Color](../functions.md#color) was given.
4. `a`: the alpha value of the color (0 to 255), unused if a [Color](../functions.md#color) was given.

## SetFont

```lua
surface.SetFont( string fontName )
```

Set the current font to be used for text operations later.

The fonts must first be created with [surface.CreateFont](#createfont) or be one of the [Default Fonts](#default-fonts).

#### Example

```lua
hook.Add( "postRender", "TextInABox", function()
    surface.SetDrawColor( 0, 0, 0, 128 ) -- Set color for background
    surface.DrawRect( 100, 100, 128, 20 ) -- Draw background
    
    surface.SetTextColor( 255, 255, 255 ) -- Set text color
    surface.SetTextPos( 136, 104 ) -- Set text position, top left corner
    surface.SetFont( "Default" ) -- Set the font
    surface.DrawText( "Hello World" ) -- Draw the text
end )
```

## SetTextColor

```lua
surface.SetTextColor( number r, number g, number b, number a = 255 )
```

Set the color of any future text to be drawn, can be set by either using r, g, b, a as separate values or by a Color. Using a color structure is not recommended to be created procedurally.

#### Arguments

1. `r`: the red value of the color (0 to 255), or a [Color](../functions.md#color).
2. `g`: the green value of the color (0 to 255), unused if a [Color](../functions.md#color) was iven.
3. `b`: the blue value of the color (0 to 255), unused if a [Color](../functions.md#color) was given.
4. `a`: the alpha value of the color (0 to 255), unused if a [Color](../functions.md#color) was given.

## SetTextPos

```lua
surface.SetTextPos( number x, number y )
```

Set the top-left position to draw any future text at.

#### Arguments

1. `x`: the X coordinate.
2. `y`: the Y coordinate.


## Default Fonts

These are the default fonts you can use for text drawing operations without having to use [CreateFont](#createfont).

| Name | Description |
| ---- | ----------- |
| `DermaDefault` | Tahoma 13 |
| `DermaDefaultBold` | Tahoma 13, Bold |
| `DermaLarge` | Tahoma 32 |
| `DebugFixed` | Courier New 14 |
| `DebugFixedSmall` | Courier New 14 |
| `Default` | Verdana 12 |
| `Marlett` | Marlett 14 |
| `Trebuchet18` | Trebuchet MS 18 |
| `Trebuchet24` | Trebuchet MS 24 |
| `HudHintTextLarge` | Verdana 14 |
| `HudHintTextSmall` | Verdana 11 |
| `CenterPrintText` | Trebuchet MS 18 |
| `HudSelectionText` | Verdana 8 |
| `CloseCaption_Normal` | Tahoma 26 |
| `CloseCaption_Italic` | Tahoma 26, Italic |
| `CloseCaption_Bold` | Tahoma 26, Bold |
| `CloseCaption_BoldItalic` | Tahoma 26, Bold Italic |
| `TargetID` | Trebuchet MS 24, Bold |
| `TargetIDSmall` | Trebuchet MS 18, Bold |
| `BudgetLabel` | Courier New 14 |
| `HudNumbers` | Trebuchet MS 32 |
