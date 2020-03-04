# Enums

## Keys
| Name | Key | Notes |
| ---- | --- | ----- |
| `KEY_0` | 0 |  |
| `KEY_1` | 1 |  |
| `KEY_2` | 2 |  |
| `KEY_3` | 3 |  |
| `KEY_4` | 4 |  |
| `KEY_5` | 5 |  |
| `KEY_6` | 6 |  |
| `KEY_7` | 7 |  |
| `KEY_8` | 8 |  |
| `KEY_9` | 9 |  |
| `KEY_PAD_0` | Numpad 0 |  |
| `KEY_PAD_1` | Numpad 1 |  |
| `KEY_PAD_2` | Numpad 2 |  |
| `KEY_PAD_3` | Numpad 3 |  |
| `KEY_PAD_4` | Numpad 4 |  |
| `KEY_PAD_5` | Numpad 5 |  |
| `KEY_PAD_6` | Numpad 6 |  |
| `KEY_PAD_7` | Numpad 7 |  |
| `KEY_PAD_8` | Numpad 8 |  |
| `KEY_PAD_9` | Numpad 9 |  |
| `KEY_F1` | F1 |  |
| `KEY_F2` | F2 |  |
| `KEY_F3` | F3 |  |
| `KEY_F4` | F4 |  |
| `KEY_F5` | F5 |  |
| `KEY_F6` | F6 |  |
| `KEY_F7` | F7 |  |
| `KEY_F8` | F8 |  |
| `KEY_F9` | F9 |  |
| `KEY_F10` | F10 |  |
| `KEY_F11` | F11 |  |
| `KEY_F12` | F12 |  |
| `KEY_F13` | F13 |  |
| `KEY_F14` | F14 |  |
| `KEY_F15` | F15 |  |
| `KEY_F16` | F16 |  |
| `KEY_F17` | F17 |  |
| `KEY_F18` | F18 |  |
| `KEY_F19` | F19 |  |
| `KEY_F20` | F20 |  |
| `KEY_F21` | F21 |  |
| `KEY_F22` | F22 |  |
| `KEY_F23` | F23 |  |
| `KEY_F24` | F24 |  |
| `KEY_A` | A |  |
| `KEY_B` | B |  |
| `KEY_C` | C |  |
| `KEY_D` | D |  |
| `KEY_E` | E |  |
| `KEY_F` | F |  |
| `KEY_G` | G |  |
| `KEY_H` | H |  |
| `KEY_I` | I |  |
| `KEY_J` | J |  |
| `KEY_K` | K |  |
| `KEY_L` | L |  |
| `KEY_M` | M |  |
| `KEY_N` | N |  |
| `KEY_O` | O |  |
| `KEY_P` | P |  |
| `KEY_Q` | Q |  |
| `KEY_R` | R |  |
| `KEY_S` | S |  |
| `KEY_T` | T |  |
| `KEY_U` | U |  |
| `KEY_V` | V |  |
| `KEY_W` | W |  |
| `KEY_X` | X |  |
| `KEY_Y` | Y |  |
| `KEY_Z` | Z |  |
| `KEY_UP` | Up Arrow |  |
| `KEY_DOWN` | Down Arrow |  |
| `KEY_LEFT` | Left Arrow |  |
| `KEY_RIGHT` | Right Arrow |  |
| `KEY_PAGEUP` | Page Up |  |
| `KEY_PAGEDOWN` | Page Down |  |
| `KEY_LCONTROL` | Left Control |  |
| `KEY_RCONTROL` | Right Control |  |
| `KEY_LALT` | Alt | Should've been left alt but we can't check for that |
| `KEY_RALT` | Alt | Should've been right alt but we can't check for that |
| `KEY_ALT` | Alt |  |
| `KEY_LWIN` | Left Windows Key |  |
| `KEY_RWIN` | Right Windows Key |  |
| `KEY_LSHIFT` | Left Shift |  |
| `KEY_RSHIFT` | Right Shift |  |
| `KEY_INSERT` | Insert |  |
| `KEY_DELETE` | Delete |  |
| `KEY_BACKSPACE` | Back |  |
| `KEY_COMMA` | Comma |  |
| `KEY_ESCAPE` | Escape |  |
| `KEY_ENTER` | Enter |  |
| `KEY_SPACE` | Space |  |
| `KEY_APP` | Application Key |  |
| `KEY_TAB` | Tab |  |
| `KEY_HOME` | Home |  |
| `KEY_END` | End |  |
| `KEY_NUMLOCK` | NumLock |  |
| `KEY_CAPSLOCK` | CapsLock |  |
| `KEY_SCROLLOCK` | Scroll |  |

## Mouse
| Name | Value | Notes |
| ---- | --- | ----- |
| `MOUSE_FIRST` | 107 | First mouse button |
| `MOUSE_LEFT` | 107 | Left mouse button |
| `MOUSE_RIGHT` | 108 | Right mouse button |
| `MOUSE_MIDDLE` | 109 | Middle mouse button, aka the wheel press |
| `MOUSE_4` | 110 | Mouse 4 button ( Sometimes, mouse wheel tilt left ) |
| `MOUSE_5` | 111 | Mouse 5 button ( Sometimes, mouse wheel tilt right ) |
| `MOUSE_WHEEL_UP` | 112 | Mouse wheel scroll up |
| `MOUSE_WHEEL_DOWN` | 113 | Mouse wheel scroll down |
| `MOUSE_LAST` | 113 | Last mouse button |

## Speed Tiers

Speeds you can set with [`goose.SetSpeed()`](../Libraries/goose.md#SetSpeed).

| Name | Value | Notes |
| ---- | --- | ----- |
| `Speed.Walk` | 0 | Walking speed, equivalent to 80 |
| `Speed.Run` | 1 | Running speed, equivalent to 200 |
| `Speed.Charge` | 2 | Charging speed, equivalent to 400 |

## Screen Direction

Screen direction returned by [`goose.SetTargetOffscreen()`](../Libraries/goose.md#SetTargetOffscreen).


| Name | Value | Notes |
| ---- | --- | ----- |
| `ScreenDirection.Left` | 0 |  |
| `ScreenDirection.Top` | 1 |  |
| `ScreenDirection.Right` | 2 |  |

## Text Alignment

Used for drawing text.

| Name | Value | Notes |
| ---- | ----- | ----- |
| `TEXT_ALIGN_LEFT` | 0 | Align the text on the left     |
| `TEXT_ALIGN_CENTER` | 1 | Align the text in center     |
| `TEXT_ALIGN_RIGHT` | 2 | Align the text on the right   |
| `TEXT_ALIGN_TOP` | 3 | Align the text on the top       |
| `TEXT_ALIGN_BOTTOM` | 4 | Align the text on the bottom |
