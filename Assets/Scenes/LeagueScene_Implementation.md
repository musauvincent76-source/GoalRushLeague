# League Scene (Unity Implementation)

## Scene Hierarchy
```
LeagueScene
├── Canvas
│   ├── Header (Panel)
│   │   └── TitleText (Text)
│   ├── PlayerRankPanel (Panel)
│   │   ├── RankText (Text)
│   │   ├── TeamNameText (Text)
│   │   └── PointsText (Text)
│   ├── LeaderboardPanel (Panel)
│   │   └── ScrollView
│   │       └── LeaderboardContent (Panel)
│   │           └── LeaderboardEntry (Prefab - Duplicate)
│   └── BackButton (Button)
└── EventSystem
```

## LeaderboardEntry Prefab Structure
```
LeaderboardEntry
├── RankText (Text)
├── TeamNameText (Text)
├── PointsText (Text)
└── WinsText (Text)
```

## Scripts to Attach
- Attach `LeagueSceneController.cs` to Canvas
- Attach `LeaderboardEntryUI.cs` to LeaderboardEntry prefab
- Attach `LeaderboardManager.cs` to empty GameObject

## Setup Steps
1. Create Canvas with ScreenSpace overlay
2. Create Header with "Leaderboard" title
3. Create player rank display panel (top section)
4. Create ScrollView for leaderboard entries
5. Create LeaderboardEntry prefab template
6. Create Back button to return to TeamScene
7. Wire button to LeagueSceneController
8. Assign prefab reference in controller

## Prefab Fields
- leaderboardEntryPrefab: Assign LeaderboardEntry prefab
- leaderboardContainer: Assign ScrollView Content transform

## Data Display
- Rank position (#1, #2, etc.)
- Team name
- Points (calculated from wins * 3)
- Number of wins
- Current player rank highlighted
```
