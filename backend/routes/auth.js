const express = require('express');
const bcrypt = require('bcryptjs');
const { v4: uuidv4 } = require('uuid');
const { pool } = require('../server');

const router = express.Router();

router.post('/register', async (req, res) => {
  try {
    const { username, email, password } = req.body;

    if (!username || !email || !password) {
      return res.status(400).json({ message: 'Missing required fields' });
    }

    const existingUser = await pool.query(
      'SELECT id FROM users WHERE email = $1 OR username = $2',
      [email, username]
    );

    if (existingUser.rows.length > 0) {
      return res.status(409).json({ message: 'User already exists' });
    }

    const passwordHash = await bcrypt.hash(password, 10);
    const userId = uuidv4();
    const teamId = uuidv4();

    await pool.query(
      'INSERT INTO users(id, username, email, password_hash) VALUES($1, $2, $3, $4)',
      [userId, username, email, passwordHash]
    );

    await pool.query(
      'INSERT INTO teams(id, user_id, team_name, coins, gems) VALUES($1, $2, $3, $4, $5)',
      [teamId, userId, `${username}'s Team`, 500, 50]
    );

    return res.status(201).json({
      userId,
      teamId,
      username,
      message: 'User registered successfully'
    });
  } catch (error) {
    console.error(error);
    return res.status(500).json({ message: 'Registration failed' });
  }
});

router.post('/login', async (req, res) => {
  try {
    const { email, password } = req.body;

    if (!email || !password) {
      return res.status(400).json({ message: 'Missing email or password' });
    }

    const result = await pool.query('SELECT * FROM users WHERE email = $1', [email]);

    if (result.rows.length === 0) {
      return res.status(401).json({ message: 'Invalid credentials' });
    }

    const user = result.rows[0];
    const passwordMatches = await bcrypt.compare(password, user.password_hash);

    if (!passwordMatches) {
      return res.status(401).json({ message: 'Invalid credentials' });
    }

    return res.status(200).json({
      userId: user.id,
      username: user.username,
      email: user.email,
      message: 'Login successful'
    });
  } catch (error) {
    console.error(error);
    return res.status(500).json({ message: 'Login failed' });
  }
});

module.exports = router;
