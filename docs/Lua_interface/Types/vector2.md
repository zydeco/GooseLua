# Vector2

This represents and coordinate with x and y positions.

#### Example

```lua
print("goose position", goose.position.x, goose.position.y)
print("BodyCenter", goose.rig.bodyCenter.x, goose.rig.bodyCenter.y)
-- all these are equivalent
goose.position = {120, 240}

goose.position = {x=120, y=240}

goose.position.x = 120
goose.position.y = 240
```
