const express = require('express');
const { v4: uuidv4 } = require('uuid');
const { pool } = require('../server');

const router = express.Router();

router.post('/end', async (req, res) => {
  try {
    const { matchId, homeTeamId, awayTeamId, homeScore, awayScore } = req.body;

    if (!homeTeamId || !awayTeamId) {
      return res.status(400).json({ message: 'Missing team identifiers' });
    }

    const winnerTeamId = homeScore > awayScore ? homeTeamId : awayScore > homeScore ? awayTeamId : null;
    const matchUUID = matchId || uuidv4();

    await pool.query(
      `INSERT INTO matches(id, home_team_id, away_team_id, home_score, away_score, status, winner_team_id)
       VALUES($1, $2, $3, $4, $5, 'finished', $6)`,
      [matchUUID, homeTeamId, awayTeamId, homeScore, awayScore, winnerTeamId]
    );

    let coinReward = 150;
    let gemReward = 2;

    if (winnerTeamId === homeTeamId) {
      coinReward = 300;
      gemReward = 10;
    }

    return res.status(200).json({
      matchId: matchUUID,
      winnerTeamId,
      coinReward,
      gemReward,
      message: 'Match result saved successfully'
    });
  } catch (error) {
    console.error(error);
    return res.status(500).json({ message: 'Failed to save match' });
  }
});

module.exports = router;
