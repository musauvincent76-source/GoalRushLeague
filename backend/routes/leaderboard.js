const express = require('express');
const { pool } = require('../server');

const router = express.Router();

router.get('/leaderboard', async (req, res) => {
  try {
    const limit = Number(req.query.limit) || 10;

    const result = await pool.query(
      `SELECT t.team_name, l.points, l.position
       FROM leaderboard l
       JOIN teams t ON t.id = l.team_id
       ORDER BY l.points DESC
       LIMIT $1`,
      [limit]
    );

    return res.status(200).json({ leaderboard: result.rows });
  } catch (error) {
    console.error(error);
    return res.status(500).json({ message: 'Failed to fetch leaderboard' });
  }
});

module.exports = router;
