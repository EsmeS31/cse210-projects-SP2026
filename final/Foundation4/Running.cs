public class Running : Activity
{
    private double _distance;

    public Running(string date, int lengthMinutes, double distance) : base(date, lengthMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / GetLength()) * 60;
    public override double GetPace() => GetLength() / _distance;
}