# Match Scene (Unity Implementation)

## Scene Hierarchy
```
MatchScene
├── 3D Scene
│   ├── Camera (Main)
│   ├── Lighting
│   │   ├── Directional Light
│   │   └── Ambient Light
│   ├── Field (Plane)
│   │   └── Material (Green grass)
│   ├── Player_Home (Sphere)
│   │   ├── Rigidbody (Mass: 1, Drag: 0.5)
│   │   ├── CapsuleCollider
│   │   └── PlayerController.cs
│   ├── Player_Away (Sphere)
│   │   ├── Rigidbody (Mass: 1, Drag: 0.5)
│   │   ├── CapsuleCollider
│   │   └── PlayerController.cs
│   ├── Ball (Sphere)
│   │   ├── Rigidbody (Mass: 0.5, Drag: 0.3)
│   │   ├── SphereCollider (radius: 0.25)
│   │   ├── BallController.cs
│   │   └── Material (White)
│   ├── GoalArea_Home (Cube - Trigger)
│   │   ├── BoxCollider (Is Trigger)
│   │   ├── GoalDetector.cs (isHomeTeamGoal: true)
│   │   └── Material (Transparent Red)
│   └── GoalArea_Away (Cube - Trigger)
│       ├── BoxCollider (Is Trigger)
│       ├── GoalDetector.cs (isHomeTeamGoal: false)
│       └── Material (Transparent Blue)
├── Canvas (World Space)
│   └── HUD (Panel)
│       ├── HomeTeamText (Text)
│       ├── AwayTeamText (Text)
│       ├── HomeScoreText (Text)
│       ├── AwayScoreText (Text)
│       ├── TimerText (Text)
│       ├── PauseButton (Button)
│       └── QuitButton (Button)
└── EventSystem
```

## Scripts to Attach
- Attach `MatchSceneController.cs` to Canvas
- Attach `MatchManager.cs` to empty GameObject
- Attach `PlayerControllerNetworked.cs` to Player_Home and Player_Away
- Attach `BallController.cs` to Ball
- Attach `GoalDetector.cs` to GoalArea_Home and GoalArea_Away
- Attach `UIMatchHUD.cs` to HUD

## Physics Setup
- Player Rigidbody: Body Type Dynamic, Mass 1, Drag 0.5
- Ball Rigidbody: Body Type Dynamic, Mass 0.5, Drag 0.3
- Goal Colliders: BoxCollider with Is Trigger enabled
- Field: Plane with flat collider

## Camera Setup
- Position: (0, 15, -10)
- Rotation: (45, 0, 0)
- Orthographic: false
- FOV: 60

## Setup Steps
1. Create 3D scene with plane as field
2. Add directional light (sun) and ambient light
3. Create player spheres at (-5, 1, 0) and (5, 1, 0)
4. Create ball sphere at (0, 1, 0)
5. Create goal trigger zones at (0, 1, -10) and (0, 1, 10)
6. Create Canvas (World Space) above field
7. Add HUD with score and timer display
8. Set up camera to show full field
9. Attach all scripts
10. Test player movement and ball physics
```
