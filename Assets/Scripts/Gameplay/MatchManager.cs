using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public int homeScore;
    public int awayScore;
    public float matchTimer;
    public bool isMatchActive;

    public void StartMatch()
    {
        homeScore = 0;
        awayScore = 0;
        matchTimer = 90f;
        isMatchActive = true;
        Debug.Log("Match started.");
    }

    private void Update()
    {
        if (!isMatchActive) return;

        matchTimer -= Time.deltaTime;

        if (matchTimer <= 0)
        {
            EndMatch();
        }
    }

    public void ScoreGoal(bool homeTeam)
    {
        if (homeTeam)
            homeScore++;
        else
            awayScore++;
    }

    public void EndMatch()
    {
        isMatchActive = false;
        Debug.Log("Match ended: " + homeScore + " - " + awayScore);
    }
}
