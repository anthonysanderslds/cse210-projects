//Added gamification to the program which created the ability for the user to 'level up' based on number of points
//It will send the user messages stating how many points away from the next level they are and some fun encouraging messages.

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}