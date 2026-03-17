// Made by W00F
// A checklist goal must be completed a certain number of times.
// Each completion awards points, and the final completion awards a bonus.
public class ChecklistGoal : Goal
{
// Tracks current progress toward completion.
    private int _amountCompleted;
// The number of times the goal must be completed.
    private int _targetAmount;
// Extra bonus points awarded when the goal is fully completed.
    private int _bonus;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int targetAmount,
        int bonus,
        int amountCompleted = 0)
        : base(name, description, points)
    {
        _targetAmount = targetAmount;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }
// Records progress on the checklist goal and awards regular points, bith final bounus
    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }
        _amountCompleted++;
        if (_amountCompleted == _targetAmount)
        {
            return _points + _bonus;
        }

        return _points;
    }
// Returns whether the checklist goal has reached its target count.
    public override bool IsComplete()
    {
        return _amountCompleted >= _targetAmount;
    }
// Returns a formatted display string including progress count.
    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description}) -- Completed {_amountCompleted}/{_targetAmount}";
    }
// Converts this goal into savable GoalData.
    public override GoalData ToGoalData()
    {
        return new GoalData
        {
            Type = "ChecklistGoal",
            Name = _name,
            Description = _description,
            Points = _points,
            AmountCompleted = _amountCompleted,
            TargetAmount = _targetAmount,
            Bonus = _bonus
        };
    }
}
