# Functions

These are some functions.

## `Msg`

```lua
void Msg( vararg args )
```

Equivalent of `print`. Shows a string in the console.

#### Example

```lua
Msg("Honk, world")
Msg("I'm at", goose.position.x, goose.position.y)
```

## `MsgC`

```lua
void MsgC( vararg args )
```

Just like `Msg`, except it can also print colored text.

#### Example

```lua
MsgC("hello from MsgC ",
   Color(255, 0, 0), "red, ", 
   Color(0, 255, 0), "green, ",
   Color(0, 0, 255), "and blue\r\n")
```

## RegisterTask

```lua
void RegisterTask(string id, string name, string description, bool canBePickedRandomly, function runTask)
```
Registers a new task to be run by the goose.

When the task is running, the `runTask` callback is called on every frame, with a table as its argument. This table can be used to track things related to the task.

#### Arguments

1. `id`: id of the task, used to select the task with [goose.SetTask](Libraries/goose.md#setTask).
2. `name`: Human-readable name of the task
3. `description`: The person who programmed this forgot to give this task a description!
4. `canBePickedRandomly`: `true` if the goose can pick the task randomly, `false` otherwise.
5. `runTask`: Called on every frame when the task is running.

#### Example

```
RegisterTask("testTask", "Lua Task", "testing", true, function(data)
   if table.IsEmpty(data) then
     -- task just started, set values
     print("I'm running the task")
     t.startTime = goose.time
  else
     -- should actually do something here
  end
end)
```
## ScrH

```lua
number ScrH()
```

#### Example

```lua
print("Screen size", ScrW(), ScrH())
```

## ScrW

```lua
number ScrW()
```

Returns the screen width.

#### Example

```lua
print("Screen size", ScrW(), ScrH())
```

