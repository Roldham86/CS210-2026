public abstract class Goal
{
// Protected fields shared by all derived goal classes.
    protected string _name;
    protected string _description;
    protected int _points;
// Base constructor used by all goal types.
    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }
// // Accessor for the goal name.
//     public string GetName()
//     {
//         return _name;
//     }
// // Accessor for the goal description.
//     public string GetDescription()
//     {
//         return _description;
//     }
// // Accessor for the point value of the goal.
//     public int GetPoints()
//     {
//         return _points;
//     }
// Records an event for the goal and returns the number of points earned.
    public abstract int RecordEvent();
// Returns whether or not this goal is complete.
    public abstract bool IsComplete();
// Returns the formatted display string for this goal.
    public abstract string GetDetailsString();
// Converts the goal into a GoalData object for saving to JSON.
    public abstract GoalData ToGoalData();
}