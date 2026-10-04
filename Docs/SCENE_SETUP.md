# GoalRush League - Scene Setup Guide

## Overview
This guide covers Unity scene setup for the game.

## Scenes to Create
1. MainMenu
2. TeamScene
3. MatchScene
4. LeagueScene
5. StoreScene (future)

## Scene Flow
```text
MainMenu -> TeamScene -> MatchScene -> LeagueScene
```

## MainMenu Scene
- Splash logo
- Login/Register form
- Club creation form
- Attach: UIMainMenu.cs, AuthenticationService.cs

## TeamScene
- Team information display
- Squad roster
- Formation selector
- Navigation buttons
- Attach: UITeamManager.cs, TeamManager.cs, EconomyManager.cs

## MatchScene
- Field, ball, players
- HUD for score and timer
- Goal triggers
- Attach: MatchManager.cs, PlayerController.cs, BallController.cs, GoalDetector.cs, UIMatchHUD.cs

## LeagueScene
- Top leaderboard
- User rank and points
- Team entry cards
- Attach: LeaderboardManager.cs

## Prefabs to Create
- PlayerCard.prefab
- LeaderboardEntry.prefab
- PlayerAvatar.prefab
