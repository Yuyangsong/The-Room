# The Room

CS417 MP1a Unity project (4-credit section).

## About

The Room is a subway cart environment built inside a 15 × 15 × 15 room. Seats, multiple doors, handrails, ceiling lights, and information displays establish the cart layout, while a control panel and sci-fi cargo crate sit at the rear. The scene combines objects built from Unity primitives with imported assets and provides a starting point for the planned MP1b Subway Escape project.

Players can interact with objects for particle and spatial sound feedback, select the cargo crate to spawn a crystal, and launch bottles from the left controller. The control panel switches between THROW and ORBIT modes. Above the cart, a planet, moon, and comet demonstrate orbital motion and a custom outline shader. Players can also change the lighting and teleport to an outside platform to view the skybox.

## Controls

| Meta Quest controller input | Action |
| --- | --- |
| Point at an interactive object + Grip | Interact |
| Left Y | Spawn a bottle in the current mode |
| Left X | Switch between inside and outside viewpoints |
| Right B | Change the light color |
| Right A | Quit |

Select the control panel to switch between THROW and ORBIT modes.

## Project

- Main scene: `Assets/Scenes/SampleScene.unity`
- Rendering: Universal Render Pipeline (URP)
- XR: OpenXR and XR Interaction Toolkit 3.5.1
- Target platform: Meta Quest (Android APK)

For desktop simulation, enable the scene's XR Interaction Simulator. Disable it before building or testing with a real headset.

## Contributor

Yuyangsong Xie

## Unity Version

Unity 6000.5.6f1
