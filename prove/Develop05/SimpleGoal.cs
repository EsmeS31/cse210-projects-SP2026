using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string title, string description, int points)
        : base(title, description, points)
    {
    }

    public override int RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            return _points;
        }

        return 0;
    }

    public override string GetDisplayString()
    {
        string status = _completed ? "[X]" : "[ ]";
        return $"{status} {_title} ({_description})";
    }

    public override string GetSaveString()
    {
        return $"SimpleGoal|{_title}|{_description}|{_points}|{_completed}";
    }
}