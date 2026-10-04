# League & Leaderboard Scene Setup

## Hierarchy
- Canvas
  - Title (Text)
  - LeaderboardPanel
    - ScrollView
      - LeaderboardEntry (Prefab)
        - RankText (Text)
        - TeamNameText (Text)
        - PointsText (Text)
  - BackButton (Button)

## Scripts to Attach
- LeaderboardManager.cs on empty GameObject
- Create LeaderboardUI.cs for display

## UI Setup
1. Show top teams
2. Display rank, team name, points, wins, losses
3. Highlight current player's team
4. Add back button to return to menu
