# GoalRush League Backend

This backend powers:
- user authentication
- team creation and economy
- match results
- leaderboard updates
- reward distribution

## Quick Start

1. Install dependencies:
   npm install
2. Create a `.env` file based on `.env.example`
3. Start the API:
   npm start

## API Endpoints

- POST /api/auth/register
- POST /api/auth/login
- POST /api/team/create
- POST /api/match/end
- GET /api/leaderboard?limit=10

## Stack
- Node.js
- Express
- PostgreSQL
