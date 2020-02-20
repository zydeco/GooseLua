# input

The input library allows you to gather information about the client's input devices (mouse & keyboard), such as the cursor position and whether a key is pressed or not.

## GetCursorPos

```lua
number, number input.GetCursorPos()
```

Returns the cursor's position on the screen

#### Returns

1. The cursor's position on the X axis
2. The cursor's position on the Y axis

## GetKeyName

```lua
string input.GetKeyName( number key )
```

Get the "friendly" name of a key. see [enums/keys](../Types/enums.md#keys).

#### Arguments

1. `key`: the key. 


## IsKeyDown

```lua
boolean input.IsKeyDown( number key )
```

Gets whether a key is down.

#### Arguments

1. `key`: the key. see [enums/keys](../Types/enums.md#keys)

#### Example

```lua
hook.Add("preRender", function()
    if input.IsKeyDown(KEY_INSERT) then
        draw.SimpleText("INSERT is being held.", "Segoe UI Light", 5, 5)
    else
        draw.SimpleText("INSERT is NOT being held.", "Segoe UI Light", 5, 5)
    end
end)
```

## IsMouseDown

```lua
boolean input.IsMouseDown( number button )
```

Gets whether a mouse button is down.

#### Arguments

1. `button`: the mouse button. see [enums/mouse](../Types/enums.md#mouse)


## SetCursorPos

```lua
void input.SetCursorPos( number mouseX, number mouseY )
```

Sets the cursor's position on the screen, relative to the topleft corner.

#### Arguments

1. `mouseX`: X coordinate for mouse position
2. `mouseY`: Y coordinate for mouse position

