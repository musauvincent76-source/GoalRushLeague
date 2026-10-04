using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchSceneController : MonoBehaviour
{
    public Text homeTeamText;
    public Text awayTeamText;
    public Text homeScoreText;
    public Text awayScoreText;
    public Text timerText;
    public Button pauseButton;
    public Button quitButton;
    public Canvas matchHUD;

    private MatchManager matchManager;
    private TeamManager teamManager;
    private RewardManager rewardManager;
    private EconomyManager economyManager;
    private bool isPaused = false;

    private void Start()
    {
        matchManager = FindObjectOfType<MatchManager>();
        teamManager = FindObjectOfType<TeamManager>();
        rewardManager = FindObjectOfType<RewardManager>();
        economyManager = FindObjectOfType<EconomyManager>();

        pauseButton.onClick.AddListener(OnPauseClicked);
        quitButton.onClick.AddListener(OnQuitClicked);

        homeTeamText.text = teamManager.currentTeam.teamName;
        awayTeamText.text = "Away Team";

        matchManager.StartMatch();
    }

    private void Update()
    {
        if (matchManager.isMatchActive)
        {
            UpdateMatchDisplay();
        }
        else
        {
            OnMatchEnded();
        }
    }

    private void UpdateMatchDisplay()
    {
        homeScoreText.text = matchManager.homeScore.ToString();
        awayScoreText.text = matchManager.awayScore.ToString();

        int minutes = (int)(matchManager.matchTimer / 60);
        int seconds = (int)(matchManager.matchTimer % 60);
        timerText.text = minutes + ":" + seconds.ToString("00");
    }

    private void OnMatchEnded()
    {
        bool isWin = matchManager.homeScore > matchManager.awayScore;
        rewardManager.GrantRewards(isWin, economyManager);

        if (isWin)
        {
            teamManager.currentTeam.wins++;
        }
        else
        {
            teamManager.currentTeam.losses++;
        }

        ShowMatchResult(isWin);
        Invoke(nameof(ReturnToTeamScene), 3f);
    }

    private void ShowMatchResult(bool isWin)
    {
        string result = isWin ? "VICTORY!" : "DEFEAT";
        Debug.Log("Match Result: " + result + " " + matchManager.homeScore + " - " + matchManager.awayScore);
    }

    private void OnPauseClicked()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        pauseButton.GetComponentInChildren<Text>().text = isPaused ? "Resume" : "Pause";
    }

    private void OnQuitClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TeamScene");
    }

    private void ReturnToTeamScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TeamScene");
    }
}
