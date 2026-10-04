# Team Management Scene Setup

## Hierarchy
- Canvas
  - Header
    - TeamNameText (Text)
    - CoinsText (Text)
    - GemsText (Text)
  - SquadPanel
    - ScrollView
      - PlayerCard (Prefab)
  - FormationPanel
    - FormationDropdown (Dropdown)
  - BottomMenu
    - PlayMatchButton (Button)
    - MarketButton (Button)
    - LeagueButton (Button)

## Scripts to Attach
- UITeamManager.cs on Canvas
- TeamManager.cs on empty GameObject
- EconomyManager.cs on empty GameObject

## UI Setup
1. Display current team info
2. Show squad roster with player cards
3. Formation selector dropdown
4. Navigation buttons at bottom
