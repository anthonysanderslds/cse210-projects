using System;

class Program
{
    static void Main(string[] args)
    {
        List<Exercise> _exercises = new List<Exercise>();

        Exercise run = new Running("16 Feb 2026", 45, 10.5);
        _exercises.Add(run);

        Exercise cycle = new Cycling("16 Feb 2026", 20, 25.2);
        _exercises.Add(cycle);

        Exercise swim = new Swimming("16 Feb 2026", 30, 60);
        _exercises.Add(swim);

        foreach (Exercise exercise in _exercises)
        {
            Console.WriteLine($"{exercise.GetSummary()}");
            Console.WriteLine();
        }
    }
}