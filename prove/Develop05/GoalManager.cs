using System;
using System.Collections.Generic;
// Made by W00F
// Manages the user's goals, total score, level system, and save/load actions.
public class GoalManager
{
// Stores all goals using the base Goal type.
    private List<Goal> _goals;
// Stores the player's total score.
    private int _score;
// Handles JSON save/load operations.
    private GoalFileHandler _fileHandler;
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _fileHandler = new GoalFileHandler();
    }
// Adds a new goal to the list.
    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }
// Returns the full list of goals.
    public List<Goal> GetGoals()
    {
        return _goals;
    }
// Returns the player's current score.
    public int GetScore()
    {
        return _score;
    }
// Calculates the player's current level. Every 1000 points increases the level by 1.
    public int GetLevel()
    {
        return (_score / 1000) + 1;
    }
// Returns how many points are needed to reach the next level.
    public int GetPointsToNextLevel()
    {
        int nextLevelScore = GetLevel() * 1000;
        return nextLevelScore - _score;
    }
// Displays the user's score and level information.
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
        Console.WriteLine($"Level: {GetLevel()}");
        Console.WriteLine($"{GetPointsToNextLevel()} points until Level {GetLevel() + 1}");
    }
// Displays all goals with numbering and current completion status.
    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals have been created yet.");
            return;
        }
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }
// Records an event for the selected goal and updates the total score.
    // -1 if the selected index is invalid
    //  0 if no points were earned
    // >0 for points earned
    public int RecordEvent(int goalIndex)
    {
        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            return -1;
        }

        int pointsEarned = _goals[goalIndex].RecordEvent();
        _score += pointsEarned;
        return pointsEarned;
    }
// Saves all goals and score to a file.
    public void SaveGoals(string filename)
    {
        _fileHandler.Save(filename, _score, _goals);
    }
// Loads all goals and score from a file.
    public void LoadGoals(string filename)
    {
        SaveData saveData = _fileHandler.Load(filename);
        _score = saveData.Score;
        _goals = _fileHandler.ConvertToGoals(saveData.Goals);
    }
}