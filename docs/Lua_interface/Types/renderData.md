# RenderData

Allows changing the colors used to render the goose.
See [goose.renderData](../Libraries/goose.md#renderdata).

#### Example

```lua
-- change goose colors
hook.Add("preRender", "ChangeGooseColors", function()
    -- must be done in a hook because the goose isn't available until after mods are initialised
    goose.renderData.gooseWhite = Color(128, 128, 128)
    goose.renderData.gooseOrange = Color(255, 0, 0)
    goose.renderData.gooseOutline = Color(255, 255, 255)
    goose.renderData.gooseShadow = Color(255, 0, 0)
    hook.Remove("preRender", "ChangeGooseColors")
end )
```

## Render Colors

```lua
Color goose.renderData.gooseWhite
Color goose.renderData.gooseOrange
Color goose.renderData.gooseOutline
```

* `gooseWhite`: used to render the goose's body.
* `gooseOrange`: used to render the goose's feet and beak.
* `gooseOutline`: used to render the goose's outline.

## Shadow

```lua
Color goose.renderData.gooseShadow
boolean goose.renderData.gooseShadowFill
```

* `gooseShadow`: used to render the goose's shadow
* `gooseShadowFill`: if `true`, the shadow will be fully drawn, if `false` it will use the default 25% fill pattern

