using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public int coinRewardWin = 300;
    public int coinRewardLose = 100;
    public int gemRewardWin = 10;
    public int gemRewardLose = 2;

    public void GrantRewards(bool isWin, EconomyManager economyManager)
    {
        if (isWin)
        {
            economyManager.AddCoins(coinRewardWin);
            economyManager.AddGems(gemRewardWin);
            Debug.Log("Victory! Earned " + coinRewardWin + " coins and " + gemRewardWin + " gems.");
        }
        else
        {
            economyManager.AddCoins(coinRewardLose);
            economyManager.AddGems(gemRewardLose);
            Debug.Log("Defeat. Earned " + coinRewardLose + " coins and " + gemRewardLose + " gems.");
        }
    }
}
