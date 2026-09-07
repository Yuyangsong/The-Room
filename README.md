# UIUC CS417 MP1a — The Room

Unity XR room prototype for the **4-credit section**. The target scope is all Core Requirements, all Side Quests, and the highest Content Stories tier. This repository currently preserves the Part 1 / Part 2 tutorial baseline; it is not a finished rubric submission.

## Environment and opening the project

- Unity **6000.5.6f1** (Unity 6)
- Universal Render Pipeline **17.5.0**
- OpenXR Plugin **1.17.1**
- XR Interaction Toolkit **3.5.1**
- Input System **1.20.0**
- Main scene: `Assets/Scenes/SampleScene.unity` (enabled in build settings)

Install Git LFS before cloning. After cloning, run `git lfs install` and `git lfs pull`, then open the repository folder through Unity Hub using the version above. Let Unity import assets and resolve the packages. Open the main scene. Keyboard controls support desktop checks; controller input and head tracking require an appropriate OpenXR runtime and headset.

## Current baseline

Part 1 is completed according to the project author: a 15 × 15 × 15 room, XR Origin, Point Light, Planet and child Moon, World Space instruction Canvas, materials, and a custom skybox. Part 2 is substantially implemented: Quit, Rainbow Light, Orbiting Moon, Orbiting Comet, and BreakOut / Camera Teleport. Part 3 is optional decoration.

Repository inspection confirms the scene content, scripts, and input bindings. This checkpoint has not been independently tested in Unity Play Mode, a player build, or a headset by the repository review. Implementation status below does not certify grading completion.

### Controls

Custom asset: `Assets/input/RoomInputActions.inputactions`, action map: **Gameplay**.

| Action | Keyboard | XR controller | Behavior |
| --- | --- | --- | --- |
| Quit | Q | Right primaryButton | Stop Play Mode in the Editor; quit the built application |
| ChangeLight | L | Right secondaryButton | Cycle the configured light colors |
| BreakOut | T | Left primaryButton | Toggle between the initial position and the external platform at (0, 0, -20) |

`Quit.cs`, `LightSwitch.cs`, and `BreakOut.cs` use `InputActionReference` and `performed` callbacks. They do not separately poll the keyboard. The custom gameplay asset coexists with the project's XRI input assets.

### Room orientation

Use the instructor's wall numbers consistently, relative to the player's initial orientation; avoid front/back wall names.

| Wall | Initial player-relative direction | Scene plane |
| --- | --- | --- |
| Wall 1 | Facing the player | z = +7.5 |
| Wall 2 | Right | x = +7.5 |
| Wall 3 | Behind the player | z = -7.5 |
| Wall 4 | Left | x = -7.5 |

The instruction Canvas is on **Wall 1**. XR Origin starts approximately at **(0, 0, -7)**. Planet is at **(0, 7.5, 0)**. Floor and ceiling are at y = 0 and y = 15.

## Rubric implementation tracker

Requirements are transcribed from the supplied rubric screenshots; the subway assignments are the author's design plan. “Baseline” means code / scene content is present, with runtime validation still required.

### Core Requirements

| Story | Points | Current evidence / planned implementation |
| --- | --- | --- |
| Particle Bursts | 2 | TODO: Ticket/Card Dispenser spawning must trigger a particle burst at the spawned object's location |
| Spatial Sound | 2 | TODO: the same spawn input must trigger spatialized sound at the spawned object's location |
| Object Space | 1 | Baseline: Planet with child Moon |
| World Space | 1 | Baseline: World Space Canvas on Wall 1; future Digital Information Display |
| Materials | 1 | Baseline: materials applied to room / scene objects |
| Highlight Outline | 2 | TODO: apply an outline vertex shader material to the Control Panel; verify URP compatibility |
| XR Tracked Camera | 2 | Baseline: XR Origin; verify actual head tracking and record the final demonstration from headset POV |
| Euler Steady | 2 | Baseline: `OrbitMoon.cs` uses Update and Time.deltaTime |
| Kinematic Double Integrators | 2 | Baseline: `OrbitComet.cs` accumulates acceleration into velocity and velocity into position with Time.deltaTime |
| XR Controller Inputs | 1 | Baseline: Gameplay actions bind XR controller buttons; headset validation pending |
| Quit Key | 1 | Baseline: `Quit.cs` handles the Quit action |
| Object Spawning | 1 | TODO: controller action instantiates a 3D prefab through the Ticket/Card Dispenser |
| Camera Teleport | 3 | Baseline: `BreakOut.cs` toggles the rig position; verify the tracked camera follows correctly |

### Side Quests

| Story | Points | Current evidence / planned implementation |
| --- | --- | --- |
| Object Shooter | 2 | TODO: dedicated spawned object with an internal velocity initialized from controller direction, integrated every Update |
| Arbitrary Orbiter | 2 | Baseline: Comet acceleration uses position relative to the assigned Planet transform rather than the world origin |
| Perfect Orbits | 2 | TODO: spawned orbiting object; remove the radial velocity component, then set tangential speed to sqrt(gravity / distance) |
| Skybox Material | 1 | Baseline: scene references a custom skybox material |
| Rainbow Lighting | 1 | Baseline: Point Light + `LightSwitch.cs`; future Ceiling Light assignment |

Perfect Orbits depends on Arbitrary Orbiter and Object Shooter. Its dedicated spawning path must preserve these dependencies without forcing all features onto the Ticket/Card Dispenser's spawned object. Validate stable motion over time and handle a controller direction parallel to the attractor direction.

## Subway cart prototype plan

MP1a will evolve into a single subway cart prototype for **MP1b: Subway Escape**, which is planned to contain multiple cars. Prefer downloaded assets and Unity primitives; custom Blender modeling is not planned. This is future work, not content already present in the baseline.

Target **16 different object types**:

| # | Object Content | Planned rubric responsibility where assigned |
| --- | --- | --- |
| 1 | End/Connection Door | — |
| 2 | Digital Information Display | World Space UI |
| 3 | Emergency Intercom | — |
| 4 | Security Camera | — |
| 5 | Subway Window | — |
| 6 | Sliding Subway Door | — |
| 7 | Bench Seat | — |
| 8 | Vertical Handrail Pole | — |
| 9 | Route Map | — |
| 10 | Control Panel | Highlight Outline |
| 11 | Fire Extinguisher | — |
| 12 | Ticket/Card Dispenser | Object Spawning + co-located Particle Burst + Spatial Sound |
| 13 | Ceiling Light | Rainbow Lighting |
| 14 | Hanging Strap | — |
| 15 | Exit/Warning Sign | — |
| 16 | Hologram/Anomaly Projector | — |

Keep Planet + Moon for Object Space / Euler Steady and Comet for Kinematic Double Integrator / Arbitrary Orbiter. Design Object Shooter / Perfect Orbits separately. Preserve BreakOut for Camera Teleport and the custom skybox for Skybox Material.

### Content Stories acceptance targets

Each category awards 1 / 2 / 3 points at 4 / 8 / 16 entries. The conservative implementation target is:

- **16 different Objects**, rather than counting repeated copies of the same prop.
- **16 distinguishable Particle Feedback emitters**, triggered by user inputs. Distinguish visual behavior, shape, color, timing, and/or purpose; merely duplicating an identical emitter is not the target.
- **16 distinguishable Spatial Audio generators**, distributed around the room and triggered by user inputs. Use distinguishable sounds / behaviors and verify audible spatial placement.

The rubric screenshots specify N assets / emitters / audio generators; the stronger distinctness target is the author's conservative design decision. The 16 object names above do not imply that 16 particle or audio implementations exist. Create an inventory for each feedback type with its trigger, location, effect / clip, and verification result as implementation proceeds.

## Remaining work and verification

1. Preserve and test this tutorial checkpoint: Q/L/T, both teleport directions, light colors, Moon motion, and Comet attraction.
2. Verify the corresponding controller buttons, head tracking, and teleport behavior in a headset; record the eventual demonstration from headset POV.
3. Add spawning with simultaneous, co-located particle and spatial audio feedback; add the Control Panel outline shader.
4. Implement Object Shooter and Perfect Orbits, retaining the prerequisite behaviors.
5. Build the subway cart and complete the 16 / 16 / 16 content inventories.
6. Update the World Space instructions for all final actions and validate the player build.

Known baseline follow-ups: input callbacks currently subscribe in Start without lifecycle cleanup; light cycling assumes a nonempty color list; comet acceleration assumes a valid attractor and nonzero distance. The current Comet velocity is manually configured and does not constitute a Perfect Orbits implementation.

## Repository hygiene and asset credits

Track `Assets/` (including `.meta` files), `Packages/`, and `ProjectSettings/`. `.gitignore` excludes Unity-generated Library, Temp, Logs, obj, UserSettings, builds, and IDE caches. `.vsconfig` records the shared Unity development workload, not the `.vs` cache.

`.gitattributes` already routes common image, audio, video, model, and archive formats through Git LFS. Unity scenes, prefabs, materials, and metadata retain the existing Unity YAML merge attributes. Git LFS must be available when adding assets and cloning the project; LFS pointer text alone is not a usable Unity asset. No history migration is part of this checkpoint.

Imported content includes Unity package samples, TextMesh Pro resources, and the existing skybox / tile images. Preserve bundled license notices. The original source / license attribution for the skybox and tile images still needs to be recorded by the author; do not invent credits. For future downloads, record asset name, creator, source URL, license, and modifications.
