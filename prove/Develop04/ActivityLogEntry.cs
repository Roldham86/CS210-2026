using System;

public class ActivityLogEntry
{
// Read-only properties for a single completed activity session.
    public DateTime Timestamp { get; }
    public string ActivityName { get; }
    public int DurationSeconds { get; }
    public int? ItemCount { get; }

    public ActivityLogEntry(DateTime timestamp, string activityName, int durationSeconds, int? itemCount)
    {
        Timestamp = timestamp;
        ActivityName = activityName;
        DurationSeconds = durationSeconds;
        ItemCount = itemCount;
    }
// Convert entry to a single line for the log file.
    public override string ToString()
    {
        string itemText = ItemCount.HasValue ? ItemCount.Value.ToString() : "";
        return $"{Timestamp:O}|{ActivityName}|{DurationSeconds}|{itemText}";
    }
// Rebuild an ActivityLogEntry from a line in the log file.
    public static bool TryParse(string line, out ActivityLogEntry entry)
    {
        entry = null;

        string[] parts = line.Split('|');
        if (parts.Length != 4)
        {
            return false;
        }

        bool validTimestamp = DateTime.TryParse(parts[0], out DateTime timestamp);
        bool validDuration = int.TryParse(parts[2], out int duration);

        int? itemCount = null;
        if (!string.IsNullOrWhiteSpace(parts[3]))
        {
            if (int.TryParse(parts[3], out int parsedCount))
            {
                itemCount = parsedCount;
            }
            else
            {
                return false;
            }
        }

        if (!validTimestamp || !validDuration)
        {
            return false;
        }

        entry = new ActivityLogEntry(timestamp, parts[1], duration, itemCount);
        return true;
    }
}