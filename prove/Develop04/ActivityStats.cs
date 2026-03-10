using System.Collections.Generic;

public class ActivityStats
{
// Public totals shown on the menu.
    public int TotalSessions { get; private set; }
    public int TotalSeconds { get; private set; }
// Tracks how many times each activity was completed.
    private Dictionary<string, int> _sessionsByActivity;

    public ActivityStats()
    {
        _sessionsByActivity = new Dictionary<string, int>();
    }
// Add one session to the totals.
    public void AddSession(string activityName, int durationSeconds)
    {
        TotalSessions++;
        TotalSeconds += durationSeconds;

        if (!_sessionsByActivity.ContainsKey(activityName))
        {
            _sessionsByActivity[activityName] = 0;
        }

        _sessionsByActivity[activityName]++;
    }
// Return the count for a specific activity type.
    public int GetCount(string activityName)
    {
        if (_sessionsByActivity.ContainsKey(activityName))
        {
            return _sessionsByActivity[activityName];
        }

        return 0;
    }
}