using UnityEngine;
using UnityEngine.UI;

public class UIMatchHUD : MonoBehaviour
{
    public Text homeScoreText;
    public Text awayScoreText;
    public Text timerText;
    public MatchManager matchManager;

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (matchManager == null) return;

        homeScoreText.text = matchManager.homeScore.ToString();
        awayScoreText.text = matchManager.awayScore.ToString();

        int minutes = (int)(matchManager.matchTimer / 60);
        int seconds = (int)(matchManager.matchTimer % 60);
        timerText.text = minutes + ":" + seconds.ToString("00");
    }
}
