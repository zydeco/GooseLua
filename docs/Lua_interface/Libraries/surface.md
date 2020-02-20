# surface

The surface library allows you to draw things on the screen.

These functions should only be called from `preRender` and `postRender` [hooks](hook.md).

#### Example

```lua
hook.Add("postRender", "a rectangle", function()
   surface.SetDrawColor(0,255,0)
   surface.DrawRect(100, 100, 100, 100)
   surface.SetDrawColor(200,100,0)
   surface.DrawLine(100, 100, 200, 200)
end)
```

## DrawLine

```lua
void surface.DrawLine( number startX, number startY, number endX, number endY )
```

Draws a line from one point to another, using the color set by [surface.SetDrawColor](#setDrawColor).

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

## DrawRect

```lua
void surface.DrawRect( number x, number y, number width, number height )
```

Draws a solid rectangle on the screen, using the color set by [surface.SetDrawColor](#setDrawColor).

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

## SetDrawColor

```lua
void surface.SetDrawColor( number r, number g, number b, number a = 255 )
```

Set the color of any future shapes to be drawn.

#### Arguments

1. `r`: The red value of color (0 to 255).
2. `g`: The green value of color (0 to 255).
3. `b`: The blue value of color (0 to 255).
4. `a`: The alpha value of color (0 to 255). Defaults to 255 (fully opaque).
