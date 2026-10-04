using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LeagueSceneController : MonoBehaviour
{
    public Transform leaderboardContainer;
    public GameObject leaderboardEntryPrefab;
    public Button backButton;
    public Text playerRankText;
    public Text playerTeamNameText;
    public Text playerPointsText;

    private LeaderboardManager leaderboardManager;
    private TeamManager teamManager;

    private void Start()
    {
        leaderboardManager = FindObjectOfType<LeaderboardManager>();
        teamManager = FindObjectOfType<TeamManager>();

        backButton.onClick.AddListener(OnBackClicked);

        DisplayLeaderboard();
        DisplayPlayerRank();
    }

    private void DisplayLeaderboard()
    {
        foreach (Transform child in leaderboardContainer)
        {
            Destroy(child.gameObject);
        }

        List<LeaderboardEntry> entries = leaderboardManager.GetLeaderboard();

        foreach (LeaderboardEntry entry in entries)
        {
            GameObject entryObject = Instantiate(leaderboardEntryPrefab, leaderboardContainer);
            LeaderboardEntryUI entryUI = entryObject.GetComponent<LeaderboardEntryUI>();
            entryUI.SetData(entry);
        }
    }

    private void DisplayPlayerRank()
    {
        leaderboardManager.UpdateLeaderboard(
            teamManager.currentTeam.teamId,
            teamManager.currentTeam.teamName,
            teamManager.currentTeam.wins,
            teamManager.currentTeam.losses
        );

        List<LeaderboardEntry> entries = leaderboardManager.GetLeaderboard();
        LeaderboardEntry playerEntry = entries.Find(e => e.teamId == teamManager.currentTeam.teamId);

        if (playerEntry != null)
        {
            playerRankText.text = "Rank: " + playerEntry.rank;
            playerTeamNameText.text = playerEntry.teamName;
            playerPointsText.text = "Points: " + playerEntry.points;
        }
    }

    private void OnBackClicked()
    {
        SceneManager.LoadScene("TeamScene");
    }
}
