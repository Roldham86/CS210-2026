// Made by W00F
// This class is a simple data container used for JSON saving/loading.
// It stores enough information to rebuild any goal type.
public class GoalData
{
    public string Type { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public int Points { get; set; }
    public bool IsComplete { get; set; }
    public int AmountCompleted { get; set; }
    public int TargetAmount { get; set; }
    public int Bonus { get; set; }
}