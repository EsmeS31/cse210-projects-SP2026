using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(
        string title,
        string description,
        int points,
        int targetCount,
        int bonusPoints)
        : base(title, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public ChecklistGoal(
        string title,
        string description,
        int points,
        int targetCount,
        int bonusPoints,
        int currentCount,
        bool completed)
        : base(title, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = currentCount;
        _completed = completed;
    }

    public override int RecordEvent()
    {
        if (_completed)
        {
            return 0;
        }

        _currentCount++;

        if (_currentCount >= _targetCount)
        {
            _completed = true;
            return _points + _bonusPoints;
        }

        return _points;
    }

    public override string GetDisplayString()
    {
        string status = _completed ? "[X]" : "[ ]";

        return $"{status} {_title} ({_description}) -- Completed {_currentCount}/{_targetCount} times";
    }

    public override string GetSaveString()
    {
        return $"ChecklistGoal|{_title}|{_description}|{_points}|{_targetCount}|{_bonusPoints}|{_currentCount}|{_completed}";
    }
}