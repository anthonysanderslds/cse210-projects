public class Cycling : Exercise
{
    protected double _speed;

    public Cycling(string date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
        _exerciseName = "Cycling";
    }

    public override double CalculateSpeed()
    {
        return _speed;
    }

    public override double CalculateDistance()
    {
        return (_speed * _minutes) / 60;
    }

    public override double CalculatePace()
    {
        return 60 / _speed;
    }
}