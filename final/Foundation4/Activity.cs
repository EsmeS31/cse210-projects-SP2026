public class Activity
{
    private string _date;
    private int _lengthMinutes;

    public Activity(string date, int lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    public string GetDate() => _date;
    public int GetLength() => _lengthMinutes;

    public virtual double GetDistance() => 0;
    public virtual double GetSpeed() => 0;
    public virtual double GetPace() => 0;

    public string GetSummary()
    {
        return $"{_date} {this.GetType().Name} ({_lengthMinutes} min): " +
               $"Distance {GetDistance():0.0} km, " +
               $"Speed: {GetSpeed():0.0} kph, " +
               $"Pace: {GetPace():0.00} min per km";
    }
}