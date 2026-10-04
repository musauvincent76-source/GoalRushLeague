# Main Menu Scene (Unity Implementation)

## Scene Hierarchy
```
MainMenuScene
├── Canvas
│   ├── Background (Image)
│   ├── Logo (Image)
│   ├── LoginPanel (Panel)
│   │   ├── EmailInput (InputField)
│   │   ├── PasswordInput (InputField)
│   │   ├── LoginButton (Button)
│   │   └── LoginText (Text)
│   ├── RegisterPanel (Panel)
│   │   ├── UsernameInput (InputField)
│   │   ├── EmailInput (InputField)
│   │   ├── PasswordInput (InputField)
│   │   ├── RegisterButton (Button)
│   │   └── RegisterText (Text)
│   ├── GuestButton (Button)
│   └── MessageText (Text)
└── EventSystem
```

## Scripts to Attach
- Attach `MainMenuController.cs` to Canvas
- Attach `AuthenticationService.cs` to empty GameObject

## Setup Steps
1. Create Canvas with ScreenSpace overlay
2. Add background image
3. Add GoalRush League logo at top
4. Create LoginPanel with inputs and button
5. Create RegisterPanel with inputs and button
6. Add GuestButton
7. Wire all buttons to MainMenuController methods
8. Set up InputField listeners

## Colors & Style
- Primary: Dark Blue (#1a1a2e)
- Accent: Gold (#ffd700)
- Text: White
- Button Hover: Light Blue (#16213e)

## Navigation
- Login → TeamScene
- Register → Show confirmation → TeamScene
- Guest → TeamScene (no account)
```
