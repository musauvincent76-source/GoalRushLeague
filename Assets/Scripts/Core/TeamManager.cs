using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public TeamData currentTeam;

    public void CreateTeam(string name)
    {
        currentTeam = new TeamData
        {
            teamId = System.Guid.NewGuid().ToString(),
            teamName = name,
            coins = 500,
            gems = 50,
            wins = 0,
            losses = 0,
            draws = 0,
            formation = "4-3-3"
        };

        Debug.Log("Team created: " + currentTeam.teamName);
    }

    public void AddPlayer(PlayerData player)
    {
        currentTeam.squad.Add(player);
    }

    public List<PlayerData> GetSquad()
    {
        return currentTeam.squad;
    }
}
