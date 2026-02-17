using System;
using System.IO.File.ReadAllLines();

public class Goal
{
    public string Name { get; set; }
    public string Points { get; set; }
    public string IsComplete { get; set; }

    public virtual void Complete()
    {
        IsComplete = "True";
    }
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string points)
    {
        Name = name;
        Points = points;
        IsComplete = "False";
    }

    public override void Complete()
    {
        base.Complete();
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, string points)
    {
        Name = name;
        Points = points;
        IsComplete = "False";
    }

    public override void Complete()
    {
        base.Complete();
    }
}

public class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; }
    public int ValuePerCompletion { get; set; }
    public int BonusValue { get; set; }

    public ChecklistGoal(string name, string points, int valuePerCompletion, int bonusValue)
    {
        Name = name;
        TargetCount = targetCount;
        ValuePerCompletion = valuePerCompletion;
        BonusValue = bonusValue;
        CurrentCount = 0;
        IsComplete = false;
    }

    public void Record()
    {
        if (!IsComplete)
        {
            CurrentCount++;
            if (CurrentCount >= TargetCount)
            {
                IsComplete = true;
            }
        }
    }
}


class Program

{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create A New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
        }
        Console.WriteLine("Select a choice from the menu: ");
        string input = Console.ReadLine();

        switch (input)
        {
    }

    List<Goal> goals  = new List<Goal>();
    int totalPoints = 0;

    goals.Add(new SimpleGoal("Run a marathon", "1000"));
    goals.Add(new EternalGoal("Read The Book Of Mormon", "100"));


    goals[0].Complete();
    if (goals[0].IsComplete == "True");
}