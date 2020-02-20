# draw

The draw library's purpose is to simplify the usage of the [surface](surface.md) library.

These functions should only be called from `preRender` and `postRender` [hooks](hook.md).

## GetFontHeight

```lua
number SimpleText( string font )
```

Returns the height of the specified font in pixels.

## MeasureText

```lua
table MeasureText( string text, string font )
```

Returns the size of the text in pixels.

#### Arguments

1. `text`: The text to be drawn.
2. `font`: The font.

#### Returns

* Table with width and height

```lua
size = draw.MeasureText("Some Text")
w, h = size[1], size[2]
```

#### Example



## SimpleText

```lua
void SimpleText( string text, string font, number x, number y )
```

Draws text on the screen.

### Arguments

1. `text`: The text to be drawn.
2. `font`: The font.
3. `x`: The X coordinate.
4. `y`: The Y coordinate.
