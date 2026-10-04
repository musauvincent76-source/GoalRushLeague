using Fusion;
using UnityEngine;

public class MatchmakingManager : MonoBehaviour
{
    private NetworkRunner runner;
    private bool isSearching = false;

    public void StartMatchmaking()
    {
        if (isSearching)
        {
            Debug.Log("Already searching for match.");
            return;
        }

        isSearching = true;
        Debug.Log("Starting matchmaking...");

        runner = FindObjectOfType<NetworkRunner>();

        var startGameArgs = new StartGameArgs
        {
            GameMode = GameMode.Shared,
            SessionName = "match_" + System.Guid.NewGuid().ToString().Substring(0, 8),
            Scene = 1
        };

        runner.StartGame(startGameArgs);
        Debug.Log("Entered match session.");
        isSearching = false;
    }
}
