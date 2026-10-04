# Match Gameplay Scene Setup

## Hierarchy
- 3D Scene
  - FieldPlane (Plane, scaled to field size)
  - GoalArea_Home (Cube, trigger)
  - GoalArea_Away (Cube, trigger)
  - Player_Home (Sphere with Rigidbody)
  - Player_Away (Sphere with Rigidbody)
  - Ball (Sphere with Rigidbody and SphereCollider)
- Canvas (World Space)
  - HUD
    - HomeScoreText (Text)
    - AwayScoreText (Text)
    - TimerText (Text)
    - PauseButton (Button)

## Scripts to Attach
- MatchManager.cs on empty GameObject
- PlayerController.cs on Player_Home and Player_Away
- BallController.cs on Ball
- GoalDetector.cs on GoalArea_Home and GoalArea_Away
- UIMatchHUD.cs on HUD Canvas

## Physics Setup
1. Use Rigidbody for players and ball
2. Use BoxCollider as triggers for goal areas
3. Use SphereCollider for ball
4. Set drag values to simulate friction
