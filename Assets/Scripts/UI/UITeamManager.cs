using UnityEngine;
using UnityEngine.UI;

public class UITeamManager : MonoBehaviour
{
    public Text teamNameText;
    public Text coinsText;
    public Text gemsText;
    public Button playMatchButton;
    public Button marketButton;
    public Button leagueButton;
    public TeamManager teamManager;
    public EconomyManager economyManager;

    private void Start()
    {
        teamManager = FindObjectOfType<TeamManager>();
        economyManager = FindObjectOfType<EconomyManager>();

        playMatchButton.onClick.AddListener(OnPlayMatchClicked);
        marketButton.onClick.AddListener(OnMarketClicked);
        leagueButton.onClick.AddListener(OnLeagueClicked);
    }

    private void Update()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (teamManager == null || economyManager == null) return;

        teamNameText.text = teamManager.currentTeam.teamName;
        coinsText.text = "Coins: " + economyManager.coins;
        gemsText.text = "Gems: " + economyManager.gems;
    }

    private void OnPlayMatchClicked()
    {
        Debug.Log("Play Match button clicked.");
    }

    private void OnMarketClicked()
    {
        Debug.Log("Market button clicked.");
    }

    private void OnLeagueClicked()
    {
        Debug.Log("League button clicked.");
    }
}
