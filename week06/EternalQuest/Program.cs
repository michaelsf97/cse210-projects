using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime;
using System.Xml.Serialization;

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
        List<Goal> goals = new List<Goal>();
        int totalPoints = 0;

        goals.Add(new SimpleGoal("Run a marathon", "1000"));
        goals.Add(new EternalGoal("Read The Book Of Mormon", "100"));

        bool running = true;
        while (running)
        {
            Console.WriteLine($"Your Current Score: {totalPoints}");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create A New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.WriteLine("Select a choice from the menu: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("The types of Goals are:");
                    Console.WriteLine("1. Simple Goal");
                    Console.WriteLine("2. Eternal Goal");
                    Console.WriteLine("3. Checklist Goal");
                    string goalType = Console.ReadLine();

                    Console.WriteLine("What is the name of your goal? ");
                    string name = Console.ReadLine();

                    Console.WriteLine("What is a short description of it? ");
                    string description = Console.ReadLine();

                    Console.WriteLine("What is the amount of points associated with this goal? ");
                    int points = int.Parse(Console.ReadLine());

                    if (goalType == "1")
                    {
                        goals.Add(new SimpleGoal(name, points.ToString()));
                    }
                    else if (goalType == "2")
                    {
                        goals.Add(new EternalGoal(name, points.ToString()));
                    }
                    else if (goalType == "3")
                    {
                        Console.WriteLine("How many times does this goal need to be achieved for a total bonus completion? ");
                        int targetCount = int.Parse(Console.ReadLine());

                        Console.WriteLine("Points per achievement? ");
                        int pointsPerAchievement = int.Parse(Console.ReadLine());

                        Console.WriteLine("Bonus points on achievement? ");
                        int totalBonus = int.Parse(Console.ReadLine());

                        ChecklistGoal checklistGoal = new ChecklistGoal(name, points.ToString(), pointsPerAchievement, totalBonus);
                        checklistGoal.TargetCount = targetCount;
                        goals.Add(checklistGoal);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Goal Type. Re-Attempt Goal");
                    }
                    break;

                case "5":
                    Console.WriteLine("The goals are:");
                    for (int i = 0; i < goals.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {goals[i].Name}");
                    }
                    int selected = int.Parse(Console.ReadLine());
                    Goal chosen = goals[selected - 1];
                    int earned = 0;
                    if (chosen is ChecklistGoal checklistGoal)
                    {
                        int before = checklistGoal.CurrentCount;
                        checklistGoal.Record();
                        if (checklistGoal.CurrentCount > before)
                        {
                            earned = checklistGoal.ValuePerCompletion;
                            if (checklistGoal.CurrentCount == checklistGoal.TargetCount)
                            {
                                earned += checklistGoal.BonusValue;
                                Console.WriteLine("Bonus ! You completed the checklist goal.");
                            }
                        }
                    }
                    else if (chosen is SimpleGoal simpleGoal)
                    {
                        if (simpleGoal.IsComplete == "False")
                        {
                            simpleGoal.Complete();
                            earned = int.Parse(simpleGoal.Points);
                        }
                        else
                        {
                            Console.WriteLine("This goal is already complete.");
                        }
                    }
                    else if (chosen is EternalGoal eternalGoal)
                    {
                        earned = int.Parse(eternalGoal.Points);
                        Console.WriteLine("Eternal goal recorded. You can do this as many times as you want!");
                    }
                    totalPoints += earned;
                    if (earned > 0)
                    {
                        Console.WriteLine($"Congratulations!! You earned {earned} points! Total: {totalPoints}");
                    }
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Quit");
                    break;
            }
        }
    }
}