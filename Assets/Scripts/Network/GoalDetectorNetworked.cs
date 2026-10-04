using UnityEngine;

public class GoalDetectorNetworked : MonoBehaviour
{
    public bool isHomeTeamGoal;
    private MatchState matchState;
    private bool hasScored = false;

    private void Start()
    {
        matchState = FindObjectOfType<MatchState>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && !hasScored && matchState != null && matchState.MatchStarted)
        {
            hasScored = true;
            matchState.RPC_ScoreGoal(isHomeTeamGoal);

            BallControllerNetworked ballController = other.GetComponent<BallControllerNetworked>();
            if (ballController != null)
            {
                ballController.RPC_ResetPosition(Vector3.zero);
            }

            Invoke(nameof(ResetGoalScorer), 2f);
        }
    }

    private void ResetGoalScorer()
    {
        hasScored = false;
    }
}
