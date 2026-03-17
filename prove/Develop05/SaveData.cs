using System.Collections.Generic;
// Made By W00F
// Wrapper class for the full save file.
// Stores total score and the list of saved goals.
public class SaveData
{
    public int Score { get; set; }
    public List<GoalData> Goals { get; set; } = new List<GoalData>();
}