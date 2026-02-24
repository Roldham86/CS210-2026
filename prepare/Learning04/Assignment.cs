public class Assignment
{
    private string _studentName;
    private string _topic;

// Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

// Returns summary
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

// Getter for derived classes
    public string GetStudentName()
    {
        return _studentName;
    }
}