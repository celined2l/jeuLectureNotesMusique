
# Unity Note Reading - Rhythm Game Starter Kit (v3)

This version includes an **Editor menu** to auto-build a working example scene inside your project, so you don't need pre-shipped .meta files.

## How to install
1. Copy the folders `Scripts`, `Sprites`, `Editor`, `Docs` into your Unity project's `Assets/`.
2. In Unity, go to **Tools → Note Game → Build Example Scene**.
3. Open `Assets/Scenes/ExampleScene.unity` and press **Play**.

## Controls
- Notes: **A S D F G H J** → **C D E F G A B**
- Change clef: **1** = Treble (Sol), **2** = Bass (Fa), **3** = Alto (Ut3)
- Tempo: use the **BPM slider** or **↑ / ↓** keys.

## Customization
- `Conductor`: `bpm`, `unitsPerBeat`
- `NoteSpawner`: `beatsBetweenNotes`, `notes` list
- `HitZone`: `hitWindowHalfWidth`, perfect window via `InputManager.perfectWindowFraction`
- `ClefManager`: `baseY`, `stepY`

## Why the scene didn't work earlier?
Unity creates `.meta` files on import that contain GUIDs. A scene shipped outside your project can't reliably reference those GUIDs. The Editor builder script recreates the scene **inside your project** and wires up all references programmatically.
