CREATE TABLE IF NOT EXISTS users (
    id UUID PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    password_hash TEXT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS teams (
    id UUID PRIMARY KEY,
    user_id UUID REFERENCES users(id),
    team_name VARCHAR(100) NOT NULL,
    coins INT DEFAULT 500,
    gems INT DEFAULT 50,
    wins INT DEFAULT 0,
    losses INT DEFAULT 0,
    draws INT DEFAULT 0,
    formation VARCHAR(20) DEFAULT '4-3-3',
    rank_position INT DEFAULT 0
);

CREATE TABLE IF NOT EXISTS players (
    id UUID PRIMARY KEY,
    team_id UUID REFERENCES teams(id),
    name VARCHAR(100) NOT NULL,
    position VARCHAR(20) NOT NULL,
    overall_rating INT NOT NULL,
    pace INT NOT NULL,
    shooting INT NOT NULL,
    passing INT NOT NULL,
    defending INT NOT NULL,
    stamina INT NOT NULL,
    cost INT NOT NULL,
    level INT DEFAULT 1
);

CREATE TABLE IF NOT EXISTS matches (
    id UUID PRIMARY KEY,
    home_team_id UUID REFERENCES teams(id),
    away_team_id UUID REFERENCES teams(id),
    home_score INT DEFAULT 0,
    away_score INT DEFAULT 0,
    status VARCHAR(20) DEFAULT 'finished',
    winner_team_id UUID REFERENCES teams(id),
    played_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS rewards (
    id UUID PRIMARY KEY,
    user_id UUID REFERENCES users(id),
    coins INT DEFAULT 0,
    gems INT DEFAULT 0,
    source VARCHAR(50),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS leaderboard (
    id UUID PRIMARY KEY,
    team_id UUID REFERENCES teams(id),
    points INT DEFAULT 0,
    position INT DEFAULT 0
);
