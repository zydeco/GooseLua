# config

The config library allows mods to read and save configuration values.

Configuration values are stored by section, you should use your mod's name as a section, so it won't clash with other mods.

Configuration is stored under `Assets/Lua Mods/config.ini`.

```ini
[myTestMod]
value=value
something=another value
[anotherMod]
value=something else
etc=...
```

## Register

```lua
config.Register( string section, table values )
```

Registers a set of default config values. Should be called at the top of your script.

#### Arguments

1. `section`: the section name
2. `values`: the values to register

#### Example

```lua
config.Register("myTestMod", {
   value = "value",
   something = "another value"
})
```

## Get

```lua
string config.Get( string section, string key, string defaultValue = nil)
```

Returns a value from the configuration, or a default value if it doesn't exist.

#### Arguments

1. `section`: the section name
2. `key`: the configuration key to look for
3. `defaultValue`: the value to return if the key is not found (optional, defaults to `nil`)

#### Returns

The value of the requested configuration key, if it can't be found, the parameter `defaultValue`, or `nil` if there is no `defaultValue` parameter.

#### Example

```lua
name = config.Get("myTestMod", "name", "Honk XL Goosetaf")
```

## Set

```lua
config.Set( string section, string key, string value)
```

Writes a value to the configuration.

#### Arguments

1. `section`: the section name
2. `key`: the key to set
3. `value`: the value to set

#### Returns

The value of the requested configuration key, if it can't be found, the parameter `defaultValue`, or `nil` if there is no `defaultValue` parameter.

#### Example

```lua
config.Set("myTestMod", "name", "Honk XL Goosetaf")
```
