# hook

Hooks are functions that are called on different events.

#### Events

The available events to hook are:

* `preTick`: Fires before the goose 'tick' function.
* `postTick`: Fires after the goose 'tick' function.
* `preRig`: Fires before the goose 'updateRig' function
* `postRig`: Fires after the goose's 'updateRig' function.
* `preRender`: Fires during rendering, before the goose draws itself.
* `postRender`: Fires during rendering, after the goose draws itself.

## Add

```lua
void hook.Add( string hook, string name, function callback )
```

Adds a hook to be executed. When the event fires, the given function is called.

#### Arguments

1. `hook`: event to hook. see [events](hook.md#events).
2. `name`: name of the hook. must be unique among mods.
3. `callback`: function to be called when the event fires.

#### Example

Adding a hook that prints the goose position on every frame:

```lua
hook.Add("postRig", "printGoosePos", function()
   print("goose position", goose.position.x, goose.position.y)
end)
```

## Remove

```lua
void hook.Remove( string hook, string name )
```

1. `hook`: event to hook. see [events](hook.md#events).
2. `name`: name of the hook. must be previously added with [hook.Add](hook.md#add).

#### Example

Removing the hook we added previously:

```lua
hook.Remove("postRig", "printGoosePos")
```

## SetSpeed
Gets The Goose's current task

Usage: ```goose.getTask()```

Example:
```lua
hook.Add("postTick", "leave my mouse alone", function()
    local task = goose.getTask()
    if task == "NabMouse" then
        goose.setTask("Wander")
    end
end)
```
