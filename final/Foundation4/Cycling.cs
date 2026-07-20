public class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int lengthMinutes, double speed) : base(date, lengthMinutes)
    {
        _speed = speed;
    }

    public override double GetSpeed() => _speed;
    public override double GetDistance() => (_speed * GetLength()) / 60;
    public override double GetPace() => 60 / _speed;
}