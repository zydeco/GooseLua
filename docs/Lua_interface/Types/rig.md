# Rig

The current location of all the goose's body parts, for rendering.
See [goose.rig](../Libraries/goose.md#rig).

#### Example

```lua
goose.rig.bodyCenter.x = 100
goose.rig.feets.lFootPos = {120,120}
```

## feets

#### Variables

```lua
Vector2 goose.rig.feets.lFootPos
Vector2 goose.rig.feets.rFootPos
number goose.rig.feets.lFootMoveTimeStart
number goose.rig.feets.rFootMoveTimeStart
Vector2 goose.rig.feets.lFootMoveOrigin
Vector2 goose.rig.feets.rFootMoveOrigin
Vector2 goose.rig.feets.lFootMoveDir
Vector2 goose.rig.feets.rFootMoveDir
number goose.rig.feets.feetDistanceApart
```

#### Constants

```lua
number goose.rig.wantStepAtDistance
number goose.rig.overshootFraction
```

## Under Body

```lua
Vector2 goose.rig.underBodyCenter
```

#### Constants

```lua
number goose.rig.underBodyRadius
number goose.rig.underBodyLength
number goose.rig.underBodyElevation
```

## Body

#### Variables

```lua
Vector2 goose.rig.bodyCenter
```

#### Constants

```lua
number goose.rig.bodyRadius
number goose.rig.bodyLength
number goose.rig.bodyElevation
```

## Necc

#### Variables

```lua
number goose.rig.neckLerpPercent
Vector2 goose.rig.neckCenter
Vector2 goose.rig.neckBase
Vector2 goose.rig.neckHeadPoint
```

#### Constants

```lua
number goose.rig.neccRadius
number goose.rig.neccHeight1 -- first position
number goose.rig.neccExtendForward1
number goose.rig.neccHeight2 -- second position
number goose.rig.neccExtendForward2
```

## Head

#### Variables

```lua
Vector2 goose.rig.head1EndPoint
Vector2 goose.rig.head2EndPoint
```

#### Constants

```lua
number goose.rig.headRadius1
number goose.rig.headLength1
number goose.rig.headRadius2
number goose.rig.headLength2
```

## Eyes

#### Constants

```lua
number goose.rig.eyeRadius
number goose.rig.eyeElevation
number goose.rig.IPD
number goose.rig.eyeRadius
```
