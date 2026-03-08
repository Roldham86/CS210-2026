using System.Collections.Generic;

public class ActivityStats
{
    public int TotalSessions { get; private set; }
    public int TotalSeconds { get; private set; }
    private Dictionary<string, int> _sessionsByActivity;

    public ActivityStats()
    {
        _sessionsByActivity = new Dictionary<string, int>();
    }

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

    public int GetCount(string activityName)
    {
        if (_sessionsByActivity.ContainsKey(activityName))
        {
            return _sessionsByActivity[activityName];
        }

        return 0;
    }
}