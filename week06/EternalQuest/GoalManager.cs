using System.Drawing;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public class GoalManager
{
    protected int _score;
    protected List<Goal> _goals = new List<Goal>();

    public GoalManager()
    {

    }

    public void Start()
    {
        string userResponse = "";

        while (userResponse != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            userResponse = Console.ReadLine();

            if (userResponse == "1")
            {
                CreateGoal();
            }
            else if (userResponse == "2")
            {
                ListGoalDetails();
            }
            else if (userResponse == "3")
            {
                SaveGoals();
            }
            else if (userResponse == "4")
            {
                LoadGoals();
            }
            else if (userResponse == "5")
            {
                RecordEvent();
            }
            else if (userResponse == "6")
            {
                Console.WriteLine("Come back soon!");
            }
            else
            {
                Console.WriteLine("Invalid Option. Please choose 1-6.");
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine();
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine();

        if (_score < 100)
        {
            Console.WriteLine($"You're a Goal Novice. Way to go!");
            Console.WriteLine($"You're {100 - _score} away from leveling up to a Goal Apprentice.");
        }
        else if (_score < 200)
        {
            Console.WriteLine($"You're a Goal Apprentice and progressing nicely!");
            Console.WriteLine($"You're {200 - _score} away from leveling up to a Goal Adventurer. Keep going!");
        }
        else if (_score < 400)
        {
            Console.WriteLine($"You're a Goal Adventurer. You're moving nicely through your development journey, I see!");
            Console.WriteLine($"You're {400 - _score} away from leveling up to Goal Champion. Will you keep the trend alive??");
        }
        else if (_score < 800)
        {
            Console.WriteLine($"You're a Goal Champion. You...are..a...champion!");
            Console.WriteLine($"You're {800 - _score} away from leveling up to Goal Hero. Incredible progress!!");
        }
        else if (_score < 1600)
        {
            Console.WriteLine($"You're a Goal Hero. Yep, you're my hero!");
            Console.WriteLine($"You're {1600 - _score} away from leveling up to Goal Legend. Do you have what it takes??");
        }
        else if (_score < 3200)
        {
            Console.WriteLine($"Whoa!!!! You're not messing around. You've become a Goal Legend. Let that sink in for a second...you're legendary!");
            Console.WriteLine($"Here's the deal...you're {3200 - _score} away from being all that you can be and achieving the greatest honor ever...");
            Console.Write("Goal MYTHIC!!! Only a select few reach this status.");
        }
        else if (_score >= 3200)
        {
            Console.Write("You ");
            Thread.Sleep(1000);
            Console.Write("are ");
            Thread.Sleep(1000);
            Console.WriteLine("MYTHICAL!!! You rock!!");
        }
    }

    public void ListGoalNames()
    {
        int num = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{num}. {goal.GetName()}.");
            num++;
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");

        if (_goals != null)
        {
            int num = 1;
            foreach (Goal goal in _goals)
            {
                Console.WriteLine($"{num}. {goal.GetDetailsString()}");
                num++;
            }
        }
        else
        {
            Console.WriteLine("  You have no goals yet! Create a goal by selecting 1");  
        }
    }

    public void CreateGoal()
    {
        string goalResponse = "";
        string goalName = "";
        string goalDescription = "";
        int goalPoints = 0;
        int goalTarget = 0;
        int goalBonus = 0;
        bool goalComplete = false;
        int goalAmount = 0;
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        goalResponse = Console.ReadLine();
        Console.Write("What is the name of your goal? ");
        goalName = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        goalDescription = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        goalPoints = int.Parse(Console.ReadLine());

        if (goalResponse == "1")
        {
            Goal goal = new SimpleGoal(goalName, goalDescription, goalPoints, goalComplete);
            _goals.Add(goal);
        }
        else if (goalResponse == "2")
        {
            Goal goal = new EternalGoal(goalName, goalDescription, goalPoints);
            _goals.Add(goal);

        }
        else if (goalResponse == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            goalTarget = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            goalBonus = int.Parse(Console.ReadLine());
            Goal goal = new ChecklistGoal(goalName, goalDescription, goalPoints, goalBonus, goalTarget, goalAmount);
            _goals.Add(goal);
        }
        else
        {
            Console.WriteLine("Invalid entry, please enter 1-3");
        }

    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int response = int.Parse(Console.ReadLine());
        int goalIndex = response - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal selectedGoal = _goals[goalIndex];
            int pointsEarned = selectedGoal.RecordEvent();
            _score += pointsEarned;

            Console.WriteLine();
            Console.WriteLine($"Great work! You've earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points earned.");
        }
        else
        {
            Console.WriteLine($"Please enter a valid goal number.");
        }

    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goal saved.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);

        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(": ");
            string goalType = parts[0];
            string data = parts[1];

            string[] fields = data.Split(", ");

            if (goalType == "Simple Goal")
            {
                string name = fields[0];
                string description = fields[1];
                int points = int.Parse(fields[2]);
                bool complete = bool.Parse(fields[3]);

                Goal goal = new SimpleGoal(name, description, points, complete);
                _goals.Add(goal);
            }
            else if (goalType == "Eternal Goal")
            {
                string name = fields[0];
                string description = fields[1];
                int points = int.Parse(fields[2]);
                Goal goal = new EternalGoal(name, description, points);
                _goals.Add(goal);
            }
            else
            {
                string name = fields[0];
                string description = fields[1];
                int points = int.Parse(fields[2]);
                int bonus = int.Parse(fields[3]);
                int target = int.Parse(fields[4]);
                int amount = int.Parse(fields[5]);
                Goal goal = new ChecklistGoal(name, description, points, bonus, target, amount);
                _goals.Add(goal);
            }
        }

        Console.WriteLine("File Loaded!");
    }

}
