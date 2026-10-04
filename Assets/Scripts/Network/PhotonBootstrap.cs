using Fusion;
using UnityEngine;
using System.Threading.Tasks;

public class PhotonBootstrap : MonoBehaviour
{
    public NetworkRunner runnerPrefab;
    private NetworkRunner runner;

    public static PhotonBootstrap Instance;

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

    private async void Start()
    {
        await InitializePhoton();
    }

    private async Task InitializePhoton()
    {
        GameObject runnerObject = new GameObject("NetworkRunner");
        runner = runnerObject.AddComponent<NetworkRunner>();

        var startGameArgs = new StartGameArgs();
        startGameArgs.GameMode = GameMode.Shared;
        startGameArgs.SessionName = "GoalRushLeague_Match";
        startGameArgs.SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>();

        await runner.StartGame(startGameArgs);
        Debug.Log("Photon Fusion initialized successfully.");
    }

    public NetworkRunner GetRunner()
    {
        return runner;
    }
}
