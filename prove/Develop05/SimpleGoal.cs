// Made by W00F
// simple goals can only be completed one time.
public class SimpleGoal : Goal
{
// Tracks whether this goal has been completed.
    private bool _isComplete;
    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }
// If the goal is not complete, mark it complete and award points.
// If it is already complete, award no points.
    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _isComplete = true;
        return _points;
    }
// Returns whether this simple goal has been completed.
    public override bool IsComplete()
    {
        return _isComplete;
    }
// Returns a formatted display string for the goal list.
    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description})";
    }
// Converts this goal into savable GoalData.
    public override GoalData ToGoalData()
    {
        return new GoalData
        {
            Type = "SimpleGoal",
            Name = _name,
            Description = _description,
            Points = _points,
            IsComplete = _isComplete
        };
    }
}