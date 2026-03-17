using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private GoalFileHandler _fileHandler;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _fileHandler = new GoalFileHandler();
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public List<Goal> GetGoals()
    {
        return _goals;
    }

    public int GetScore()
    {
        return _score;
    }

    public int GetLevel()
    {
        return (_score / 1000) + 1;
    }

    public int GetPointsToNextLevel()
    {
        int nextLevelScore = GetLevel() * 1000;
        return nextLevelScore - _score;
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
        Console.WriteLine($"Level: {GetLevel()}");
        Console.WriteLine($"{GetPointsToNextLevel()} points until Level {GetLevel() + 1}");
    }

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

    public void SaveGoals(string filename)
    {
        _fileHandler.Save(filename, _score, _goals);
    }

    public void LoadGoals(string filename)
    {
        SaveData saveData = _fileHandler.Load(filename);
        _score = saveData.Score;
        _goals = _fileHandler.ConvertToGoals(saveData.Goals);
    }
}