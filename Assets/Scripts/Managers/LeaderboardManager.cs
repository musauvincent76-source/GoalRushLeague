using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LeaderboardEntry
{
    public string teamId;
    public string teamName;
    public int points;
    public int wins;
    public int losses;
    public int rank;
}

public class LeaderboardManager : MonoBehaviour
{
    private List<LeaderboardEntry> leaderboard = new List<LeaderboardEntry>();

    public void UpdateLeaderboard(string teamId, string teamName, int winsCount, int lossesCount)
    {
        LeaderboardEntry entry = leaderboard.Find(e => e.teamId == teamId);

        if (entry == null)
        {
            entry = new LeaderboardEntry
            {
                teamId = teamId,
                teamName = teamName,
                wins = winsCount,
                losses = lossesCount,
                points = winsCount * 3
            };
            leaderboard.Add(entry);
        }
        else
        {
            entry.wins = winsCount;
            entry.losses = lossesCount;
            entry.points = winsCount * 3;
        }

        SortLeaderboard();
    }

    private void SortLeaderboard()
    {
        leaderboard.Sort((a, b) => b.points.CompareTo(a.points));

        for (int i = 0; i < leaderboard.Count; i++)
        {
            leaderboard[i].rank = i + 1;
        }
    }

    public List<LeaderboardEntry> GetLeaderboard()
    {
        return leaderboard;
    }
}
