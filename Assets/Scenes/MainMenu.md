# Main Menu Scene Setup

## Hierarchy
- Canvas
  - Panel (Background)
  - Logo (Image)
  - LoginPanel
    - UsernameInput (InputField)
    - PasswordInput (InputField)
    - LoginButton (Button)
    - RegisterButton (Button)
  - CreateClubPanel
    - TeamNameInput (InputField)
    - CreateTeamButton (Button)

## Scripts to Attach
- UIMainMenu.cs on Canvas
- AuthenticationService.cs on empty GameObject

## UI Setup
1. Create Canvas with RawImage background
2. Add Logo image at top center
3. Create Login/Register panel with Input Fields and Buttons
4. Create Team Creation panel
5. Wire buttons to script methods
