public abstract class Exercise
{
    protected string _dateString;
    protected int _minutes;

    protected string _exerciseName;


    public Exercise(string date, int minutes)
    {
        _dateString = date;
        _minutes = minutes;
    }

    public abstract double CalculateDistance();
    public abstract double CalculateSpeed();
    public abstract double CalculatePace();

    public string GetSummary()
    {
        return $"{_dateString} {_exerciseName} ({_minutes} min)- Distance {CalculateDistance():F1} miles, Speed {CalculateSpeed():F1} mph, Pace {CalculatePace():F1} min per mile";
    }
}