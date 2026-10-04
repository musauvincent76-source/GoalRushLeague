using UnityEngine;
using UnityEngine.UI;

public class LeaderboardEntryUI : MonoBehaviour
{
    public Text rankText;
    public Text teamNameText;
    public Text pointsText;
    public Text winsText;

    public void SetData(LeaderboardEntry entry)
    {
        rankText.text = "#" + entry.rank;
        teamNameText.text = entry.teamName;
        pointsText.text = entry.points.ToString() + " pts";
        winsText.text = "Wins: " + entry.wins;
    }
}
