using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public InputField usernameInput;
    public InputField emailInput;
    public InputField passwordInput;
    public Button loginButton;
    public Button registerButton;
    public Button guestButton;
    public Text messageText;

    private AuthenticationService authService;

    private void Start()
    {
        authService = FindObjectOfType<AuthenticationService>();
        
        loginButton.onClick.AddListener(OnLoginClicked);
        registerButton.onClick.AddListener(OnRegisterClicked);
        guestButton.onClick.AddListener(OnGuestClicked);
    }

    private void OnLoginClicked()
    {
        string email = emailInput.text;
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            ShowMessage("Please fill in all fields.");
            return;
        }

        authService.Login(email, password);
        ShowMessage("Login successful!");
        
        Invoke(nameof(LoadTeamScene), 1f);
    }

    private void OnRegisterClicked()
    {
        string username = usernameInput.text;
        string email = emailInput.text;
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            ShowMessage("Please fill in all fields.");
            return;
        }

        authService.Register(username, email, password);
        ShowMessage("Registration successful! Please log in.");
    }

    private void OnGuestClicked()
    {
        ShowMessage("Loading as guest...");
        Invoke(nameof(LoadTeamScene), 1f);
    }

    private void ShowMessage(string message)
    {
        messageText.text = message;
        Invoke(nameof(ClearMessage), 3f);
    }

    private void ClearMessage()
    {
        messageText.text = "";
    }

    private void LoadTeamScene()
    {
        SceneManager.LoadScene("TeamScene");
    }
}
