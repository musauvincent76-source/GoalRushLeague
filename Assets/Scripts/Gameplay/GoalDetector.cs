using UnityEngine;

public class GoalDetector : MonoBehaviour
{
    public bool isHomeTeamGoal;
    private MatchManager matchManager;

    private void Start()
    {
        matchManager = FindObjectOfType<MatchManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (matchManager != null)
            {
                matchManager.ScoreGoal(isHomeTeamGoal);
                Debug.Log("GOAL! " + (isHomeTeamGoal ? "Home" : "Away") + " team scored!");
            }
        }
    }
}
