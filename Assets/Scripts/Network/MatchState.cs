using Fusion;
using UnityEngine;

public class MatchState : NetworkBehaviour
{
    [Networked]
    public int HomeScore { get; set; }

    [Networked]
    public int AwayScore { get; set; }

    [Networked]
    public float MatchTimer { get; set; }

    [Networked]
    public bool MatchStarted { get; set; }

    [Networked]
    public bool MatchFinished { get; set; }

    [Networked]
    public int HomeTeamId { get; set; }

    [Networked]
    public int AwayTeamId { get; set; }

    private float matchDuration = 90f;

    public override void FixedUpdateNetwork()
    {
        if (!MatchStarted || MatchFinished)
            return;

        MatchTimer -= Runner.DeltaTime;

        if (MatchTimer <= 0)
        {
            FinishMatch();
        }
    }

    public void StartMatch(int homeTeamId, int awayTeamId)
    {
        if (HasInputAuthority)
        {
            HomeTeamId = homeTeamId;
            AwayTeamId = awayTeamId;
            MatchTimer = matchDuration;
            MatchStarted = true;
            MatchFinished = false;
            Debug.Log("Match started: Team " + homeTeamId + " vs Team " + awayTeamId);
        }
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    public void RPC_ScoreGoal(bool isHomeTeam)
    {
        if (isHomeTeam)
        {
            HomeScore++;
            Debug.Log("GOAL! Home team scored. Score: " + HomeScore + " - " + AwayScore);
        }
        else
        {
            AwayScore++;
            Debug.Log("GOAL! Away team scored. Score: " + HomeScore + " - " + AwayScore);
        }
    }

    private void FinishMatch()
    {
        MatchFinished = true;
        MatchStarted = false;
        Debug.Log("Match finished. Final score: " + HomeScore + " - " + AwayScore);
    }

    public int GetWinnerTeamId()
    {
        if (HomeScore > AwayScore)
            return HomeTeamId;
        else if (AwayScore > HomeScore)
            return AwayTeamId;
        else
            return 0;
    }
}
