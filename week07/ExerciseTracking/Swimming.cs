public class Swimming : Exercise
{
    protected int _numLaps;

    public Swimming(string date, int minutes, int laps) : base(date, minutes)
    {
        _numLaps = laps;
        _exerciseName = "Swimming";
    }

    public override double CalculateDistance()
    {
        return ((_numLaps * 50) / 1000) * 0.62;
    }

    public override double CalculateSpeed()
    {
        return (CalculateDistance() / _minutes) * 60;
    }

    public override double CalculatePace()
    {
        return _minutes / CalculateDistance();
    }
}