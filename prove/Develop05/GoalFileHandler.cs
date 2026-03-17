using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class GoalFileHandler
{
    public void Save(string filename, int score, List<Goal> goals)
    {
        SaveData saveData = new SaveData();
        saveData.Score = score;

        foreach (Goal goal in goals)
        {
            saveData.Goals.Add(goal.ToGoalData());
        }

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(saveData, options);
        File.WriteAllText(filename, json);
    }

    public SaveData Load(string filename)
    {
        if (!File.Exists(filename))
        {
            return new SaveData();
        }

        string json = File.ReadAllText(filename);
        SaveData? saveData = JsonSerializer.Deserialize<SaveData>(json);

        return saveData ?? new SaveData();
    }

    public List<Goal> ConvertToGoals(List<GoalData> goalDataList)
    {
        List<Goal> goals = new List<Goal>();

        foreach (GoalData data in goalDataList)
        {
            goals.Add(CreateGoalFromData(data));
        }

        return goals;
    }

    private Goal CreateGoalFromData(GoalData data)
    {
        switch (data.Type)
        {
            case "SimpleGoal":
                return new SimpleGoal(data.Name, data.Description, data.Points, data.IsComplete);

            case "EternalGoal":
                return new EternalGoal(data.Name, data.Description, data.Points);

            case "ChecklistGoal":
                return new ChecklistGoal(
                    data.Name,
                    data.Description,
                    data.Points,
                    data.TargetAmount,
                    data.Bonus,
                    data.AmountCompleted);

            default:
                throw new Exception($"Unknown goal type: {data.Type}");
        }
    }
}