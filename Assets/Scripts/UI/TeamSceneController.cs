using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class TeamSceneController : MonoBehaviour
{
    public Text teamNameText;
    public Text coinsText;
    public Text gemsText;
    public Text winsText;
    public Text lossesText;
    public Dropdown formationDropdown;
    public Button playMatchButton;
    public Button marketButton;
    public Button leagueButton;
    public Button settingsButton;
    public Transform squadContainer;
    public GameObject playerCardPrefab;

    private TeamManager teamManager;
    private EconomyManager economyManager;
    private SaveManager saveManager;

    private void Start()
    {
        teamManager = FindObjectOfType<TeamManager>();
        economyManager = FindObjectOfType<EconomyManager>();
        saveManager = FindObjectOfType<SaveManager>();

        if (teamManager.currentTeam == null)
        {
            teamManager.CreateTeam("GoalRush FC");
        }

        playMatchButton.onClick.AddListener(OnPlayMatchClicked);
        marketButton.onClick.AddListener(OnMarketClicked);
        leagueButton.onClick.AddListener(OnLeagueClicked);
        settingsButton.onClick.AddListener(OnSettingsClicked);
        formationDropdown.onValueChanged.AddListener(OnFormationChanged);

        DisplayTeamInfo();
        DisplaySquad();
    }

    private void Update()
    {
        UpdateDisplay();
    }

    private void DisplayTeamInfo()
    {
        teamNameText.text = teamManager.currentTeam.teamName;
        coinsText.text = economyManager.coins.ToString();
        gemsText.text = economyManager.gems.ToString();
        winsText.text = "Wins: " + teamManager.currentTeam.wins;
        lossesText.text = "Losses: " + teamManager.currentTeam.losses;
    }

    private void DisplaySquad()
    {
        foreach (Transform child in squadContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (PlayerData player in teamManager.currentTeam.squad)
        {
            GameObject card = Instantiate(playerCardPrefab, squadContainer);
            PlayerCardUI cardUI = card.GetComponent<PlayerCardUI>();
            cardUI.SetPlayerData(player);
        }
    }

    private void UpdateDisplay()
    {
        coinsText.text = economyManager.coins.ToString();
        gemsText.text = economyManager.gems.ToString();
    }

    private void OnFormationChanged(int index)
    {
        string[] formations = { "4-3-3", "4-2-4", "3-5-2", "5-3-2" };
        teamManager.currentTeam.formation = formations[index];
        Debug.Log("Formation changed to: " + formations[index]);
    }

    private void OnPlayMatchClicked()
    {
        Debug.Log("Loading match scene...");
        SceneManager.LoadScene("MatchScene");
    }

    private void OnMarketClicked()
    {
        Debug.Log("Opening market...");
    }

    private void OnLeagueClicked()
    {
        Debug.Log("Loading league scene...");
        SceneManager.LoadScene("LeagueScene");
    }

    private void OnSettingsClicked()
    {
        Debug.Log("Opening settings...");
    }
}
