using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    public int coins;
    public int gems;

    public void AddCoins(int amount)
    {
        coins += amount;
    }

    public void AddGems(int amount)
    {
        gems += amount;
    }

    public bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            return true;
        }

        return false;
    }
}
