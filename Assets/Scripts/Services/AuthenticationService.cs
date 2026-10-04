using UnityEngine;

public class AuthenticationService : MonoBehaviour
{
    public bool isAuthenticated;
    public string currentUserId;

    public static AuthenticationService Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Register(string username, string email, string password)
    {
        Debug.Log("Registering user: " + username);
    }

    public void Login(string email, string password)
    {
        Debug.Log("Logging in user: " + email);
        isAuthenticated = true;
        currentUserId = "user_" + System.Guid.NewGuid().ToString();
    }

    public void Logout()
    {
        Debug.Log("Logging out.");
        isAuthenticated = false;
        currentUserId = "";
    }
}
