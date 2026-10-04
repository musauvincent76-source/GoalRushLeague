using System;
using System.Collections.Generic;

[Serializable]
public class TeamData
{
    public string teamId;
    public string teamName;
    public int coins;
    public int gems;
    public int wins;
    public int losses;
    public int draws;
    public string formation;
    public List<PlayerData> squad = new List<PlayerData>();
}
