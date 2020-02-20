# goose

The goose library exposes many aspects of the goose.

Some properties are vectors, which have `x` and `y` fields that can be read/written separately, or they can be assigned from a tuple or a table. See [Vector2](../Types/vector2.md).

#### Example

```lua
hook.Add("preRig", "stuff", function()
   print("goose position", goose.position.x, goose.position.y)
   print("BodyCenter", goose.rig.bodyCenter.x, goose.rig.bodyCenter.y)
   -- all these are equivalent
   goose.position = {120, 240}
   
   goose.position = {x=120, y=240}
   
   goose.position.x = 120
   goose.position.y = 240
end)
```

## position

```lua
Vector2 goose.position
```

The current position.

#### Example

```lua
-- print position
print("goose position", goose.position.x, goose.position.y)
-- all these are equivalent
goose.position = {120, 240}

goose.position = {x=120, y=240}

goose.position.x = 120
goose.position.y = 240
```

## velocity

```lua
Vector2 goose.velocity
```

The current velocity.

## direction

```lua
number goose.direction
```

The current direction the goose is facing, in degrees.

## targetDirection

```lua
Vector2 goose.targetDirection
```

The target direction of the goose, described as a unit vector. 

## extendingNeck

```lua
boolean goose.extendingNeck
```

Override whether the goose is extending its neck - resets every frame.

## target

```lua
Vector2 goose.target
```

The target position. Set this point, and the goose will automatically locomote to it.

#### Example

```lua
goose.target = {x=300, x=300}
```

## currentSpeed

```lua
number goose.currentSpeed
```

## currentAcceleration

```lua
number goose.currentAcceleration
```

Determines the current rate of acceleration. 

## stepInterval

```lua
number goose.stepInterval
```

Determines the interval in seconds at which the goose's feets will step.

## canDecelerateImmediately

```lua
boolean goose.canDecelerateImmediately
```

Determines whether the goose can decelerate immediately upon reaching its target location, or whether it will float around it.

## time

```lua
number goose.time
```

The current time in seconds, since the goose was born (read-only).

## trackMudEndTime

```lua
number goose.trackMudEndTime
```

The time at which the goose should stop tracking mud.

## AddFootMark

```lua
void goose.AddFootMark(number x, number y)
```

Adds a foot mark.

## ClearFootMarks

```lua
void goose.ClearFootMarks()
```

Clears all foot marks.

## rig

```
Rig goose.rig
```

The current location of all the goose's body parts, for rendering. The `rig` field itself is read-only, but its contents can be changed. See [Rig](../Types/rig.md).

#### Example

```lua
goose.rig.bodyCenter.x = 100
goose.rig.feets.lFootPos = {120,120}
```

## tasks

```lua
table goose.tasks
```

The list of task IDs (read-only).

#### Example

```lua
print("Tasks:", table.ToString(goose.tasks, "Tasks", false))
```

## task

```lua
string goose.task
```

The ID of the currently running task.

## SetTask

```lua
void goose.SetTask( string id, boolean honk = true)
```

Set the goose's current task by its ID.

## ChooseRandomTask

```lua
void goose.ChooseRandomTask()
```

Set the goose's task to a random task.

## Roam

```lua
void goose.Roam()
```

Set the current task to the default task.

## Honk

```lua
void goose.Honk()
```

Play a honk sound.

## SetSpeed

```lua
void goose.SetSpeed( Speed speed )
```

Set the speed tier of the goose. See [Speed](../Types/enums.md#speed-tiers).

## SetTargetOffscreen

```lua
ScreenDirection goose.SetTargetOffscreen( boolean canExitTop = false )
```

Set the goose's target position to the closest offscreen position, weighted to the center of whatever screen edge it's on.


#### Returns

* the chosen direction. See [Screen Direction](../Types/enums.md#screen-direction).

## IsGooseAtTarget

```lua
boolean goose.IsGooseAtTarget( number distance )
```

Check if goose is at target.

## distanceToTarget

```lua
number goose.distanceToTarget
```

Check goose distance to target.

