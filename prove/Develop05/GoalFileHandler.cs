using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
// Made by W00F
// Handles saving and loading goal data from a JSON file.
public class GoalFileHandler
{
// Saves the player's score and all goals to a JSON file.
    public void Save(string filename, int score, List<Goal> goals)
    {
        SaveData saveData = new SaveData();
        saveData.Score = score;
    // Convert each Goal object into GoalData for serialization.
        foreach (Goal goal in goals)
        {
            saveData.Goals.Add(goal.ToGoalData());
        }
    // Write the JSON with indentation to make it easier to read.
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        string json = JsonSerializer.Serialize(saveData, options);
        File.WriteAllText(filename, json);
    }
// Loads save data from a JSON file.
// If the file does not exist, return a blank save.
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
// Converts a list of GoalData objects back into actual Goal objects.
    public List<Goal> ConvertToGoals(List<GoalData> goalDataList)
    {
        List<Goal> goals = new List<Goal>();

        foreach (GoalData data in goalDataList)
        {
            goals.Add(CreateGoalFromData(data));
        }
        return goals;
    }
// Creates the correct derived goal object based on the saved Type field.
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