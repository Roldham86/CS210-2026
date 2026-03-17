public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _targetAmount;
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

    public override bool IsComplete()
    {
        return _amountCompleted >= _targetAmount;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description}) -- Completed {_amountCompleted}/{_targetAmount}";
    }

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
