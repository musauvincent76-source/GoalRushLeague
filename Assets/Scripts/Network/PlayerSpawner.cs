using Fusion;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour, INetworkRunnerCallbacks
{
    public GameObject playerPrefab;
    public Vector3 homeSpawnPosition = new Vector3(-5f, 1f, 0f);
    public Vector3 awaySpawnPosition = new Vector3(5f, 1f, 0f);

    private NetworkRunner runner;

    private void Start()
    {
        runner = FindObjectOfType<NetworkRunner>();
        if (runner != null)
        {
            runner.AddCallbacks(this);
        }
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        SpawnPlayerForTeam(runner);
    }

    private void SpawnPlayerForTeam(NetworkRunner runner)
    {
        if (runner.IsPlayer)
        {
            Vector3 spawnPos = runner.LocalPlayer == PlayerRef.First ? homeSpawnPosition : awaySpawnPosition;
            runner.Spawn(playerPrefab, spawnPos, Quaternion.identity);
            Debug.Log("Player spawned at " + spawnPos);
        }
    }

    public void OnInput(NetworkRunner runner, NetworkInput input) { }
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason) { }
    public void OnConnectedToServer(NetworkRunner runner) { }
    public void OnDisconnectedFromServer(NetworkRunner runner) { }
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbacks.ConnectRequest request, byte[] token) { }
    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) { }
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) { }
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList) { }
    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }
    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken) { }
    public void OnSceneLoadStart(NetworkRunner runner) { }
}
