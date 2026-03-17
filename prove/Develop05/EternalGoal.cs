// Made by W00F
// An eternal goal is never completed and gives points every time it is recorded.
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }
// Always awards points when recorded.
    public override int RecordEvent()
    {
        return _points;
    }
// Eternal goals never become complete.
    public override bool IsComplete()
    {
        return false;
    }
// Returns a formatted display string for the goal list.
    public override string GetDetailsString()
    {
        return $"[ ] {_name} ({_description})";
    }
// Converts this goal into savable GoalData.
    public override GoalData ToGoalData()
    {
        return new GoalData
        {
            Type = "EternalGoal",
            Name = _name,
            Description = _description,
            Points = _points
        };
    }
}