const express = require('express');
const dotenv = require('dotenv');
const { Pool } = require('pg');

dotenv.config();

const app = express();
const pool = new Pool({
  host: process.env.DB_HOST,
  port: process.env.DB_PORT,
  database: process.env.DB_NAME,
  user: process.env.DB_USER,
  password: process.env.DB_PASSWORD,
});

app.use(express.json());

app.get('/', (req, res) => {
  res.json({ message: 'GoalRush League backend is running.' });
});

app.use('/api/auth', require('./routes/auth'));
app.use('/api/match', require('./routes/matches'));
app.use('/api', require('./routes/leaderboard'));

const port = process.env.PORT || 5000;
app.listen(port, () => {
  console.log(`GoalRush League backend running on port ${port}`);
});

module.exports = { app, pool };
