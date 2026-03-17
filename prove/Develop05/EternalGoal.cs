public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_name} ({_description})";
    }

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