using System.Collections.Generic;
using System.IO;

public class ActivityLogger
{
    private string _path;

    public ActivityLogger(string path)
    {
        _path = path;
// Create the log file if it does not already exist.
        if (!File.Exists(_path))
        {
            File.Create(_path).Dispose();
        }
    }
// Append one completed session to the log file.
    public void Append(ActivityLogEntry entry)
    {
        using (StreamWriter writer = new StreamWriter(_path, true))
        {
            writer.WriteLine(entry.ToString());
        }
    }
// Read all valid entries from the log file.
    public List<ActivityLogEntry> ReadAll()
    {
        List<ActivityLogEntry> entries = new List<ActivityLogEntry>();

        foreach (string line in File.ReadAllLines(_path))
        {
            if (ActivityLogEntry.TryParse(line, out ActivityLogEntry entry))
            {
                entries.Add(entry);
            }
        }

        return entries;
    }
// Build menu statistics from the saved log entries.
    public ActivityStats GetStats()
    {
        ActivityStats stats = new ActivityStats();
        List<ActivityLogEntry> entries = ReadAll();

        foreach (ActivityLogEntry entry in entries)
        {
            stats.AddSession(entry.ActivityName, entry.DurationSeconds);
        }

        return stats;
    }
}