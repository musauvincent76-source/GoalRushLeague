# Team Scene (Unity Implementation)

## Scene Hierarchy
```
TeamScene
├── Canvas
│   ├── Header (Panel)
│   │   ├── TeamNameText (Text)
│   │   ├── CoinsText (Text)
│   │   └── GemsText (Text)
│   ├── StatsPanel (Panel)
│   │   ├── WinsText (Text)
│   │   ├── LossesText (Text)
│   │   └── DrawsText (Text)
│   ├── FormationPanel (Panel)
│   │   ├── FormationLabel (Text)
│   │   └── FormationDropdown (Dropdown)
│   ├── SquadPanel (Panel)
│   │   └── ScrollView
│   │       └── SquadContent (Panel)
│   │           └── PlayerCard (Prefab - Duplicate)
│   └── BottomMenu (Panel)
│       ├── PlayMatchButton (Button)
│       ├── MarketButton (Button)
│       ├── LeagueButton (Button)
│       └── SettingsButton (Button)
└── EventSystem
```

## PlayerCard Prefab Structure
```
PlayerCard
├── Image (Player Avatar)
├── NameText (Text)
├── PositionText (Text)
├── RatingText (Text)
├── RatingSlider (Slider)
└── Button (Clickable)
```

## Scripts to Attach
- Attach `TeamSceneController.cs` to Canvas
- Attach `PlayerCardUI.cs` to PlayerCard prefab
- Attach `TeamManager.cs` to empty GameObject
- Attach `EconomyManager.cs` to empty GameObject
- Attach `SaveManager.cs` to empty GameObject

## Setup Steps
1. Create Canvas with ScreenSpace overlay
2. Create Header panel with team info
3. Create stats display
4. Create Formation dropdown with options: 4-3-3, 4-2-4, 3-5-2, 5-3-2
5. Create ScrollView for squad roster
6. Create PlayerCard prefab template
7. Create bottom menu with navigation buttons
8. Wire buttons to scene transitions
9. Set up FormationDropdown listener

## Prefab Fields
- playerCardPrefab: Assign PlayerCard prefab
- squadContainer: Assign ScrollView Content transform

## Dynamic Elements
- Squad roster displays all players in current team
- Coins and gems update in real-time
- Formation selection updates team.formation property
- Play Match button loads MatchScene
```
