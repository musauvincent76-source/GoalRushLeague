using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void SaveTeam(TeamData team)
    {
        string json = JsonUtility.ToJson(team);
        PlayerPrefs.SetString("GoalRushTeam", json);
    }

    public TeamData LoadTeam()
    {
        if (PlayerPrefs.HasKey("GoalRushTeam"))
        {
            string json = PlayerPrefs.GetString("GoalRushTeam");
            return JsonUtility.FromJson<TeamData>(json);
        }

        return new TeamData();
    }
}
