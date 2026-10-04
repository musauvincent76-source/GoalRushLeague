# Photon Fusion Setup Guide for GoalRush League

## Overview
Photon Fusion is used for real-time multiplayer football gameplay.

## Installation Steps
1. Create Photon account
2. Import Fusion package into Unity
3. Add Photon App ID
4. Configure settings

## Core Network Scripts
- PhotonBootstrap.cs
- MatchState.cs
- NetworkInputData.cs
- PlayerControllerNetworked.cs
- BallControllerNetworked.cs
- GoalDetectorNetworked.cs
- MatchmakingManager.cs
- PlayerSpawner.cs

## Match Lifecycle
1. Player joins a room
2. Player prefab spawns
3. Match starts
4. Input synced
5. Goal triggers RPC
6. Result sent to backend
