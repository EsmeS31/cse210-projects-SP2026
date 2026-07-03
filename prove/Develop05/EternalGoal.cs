using System;

public class EternalGoal : Goal
{
    public EternalGoal(string title, string description, int points)
        : base(title, description, points)
    {
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override string GetDisplayString()
    {
        return $"[∞] {_title} ({_description})";
    }

    public override string GetSaveString()
    {
        return $"EternalGoal|{_title}|{_description}|{_points}";
    }
}