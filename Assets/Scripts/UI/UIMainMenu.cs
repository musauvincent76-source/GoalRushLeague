using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    public InputField teamNameInput;
    public Button createTeamButton;

    private TeamManager teamManager;

    private void Start()
    {
        teamManager = FindObjectOfType<TeamManager>();
        createTeamButton.onClick.AddListener(CreateClub);
    }

    private void CreateClub()
    {
        string teamName = teamNameInput.text;

        if (string.IsNullOrEmpty(teamName))
            teamName = "GoalRush FC";

        teamManager.CreateTeam(teamName);
    }
}
