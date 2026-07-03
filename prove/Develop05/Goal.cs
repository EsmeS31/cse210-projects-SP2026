using System;

public abstract class Goal
{
    protected string _title;
    protected string _description;
    protected int _points;
    protected bool _completed;

    public Goal()
    {
    }

    public Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
        _completed = false;
    }

    public string GetTitle()
    {
        return _title;
    }

    public bool IsCompleted()
    {
        return _completed;
    }

    public abstract int RecordEvent();

    public abstract string GetDisplayString();

    public abstract string GetSaveString();
}