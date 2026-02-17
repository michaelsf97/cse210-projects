using System;
using System.Collections.Generic;


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
            Console.Write("Select a choice from the menu: ");
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

                    case "2":
                        Console.WriteLine("Your Goals:");
                        for (int i = 0; i < goals.Count; i++)
                        {
                            string status = "[ ]";
                            if (goals[i] is ChecklistGoal cg)
                            {
                                status = cg.IsComplete == "True" ? "[X]" : "[ ]";
                                Console.WriteLine($"{i + 1}. {status} {cg.Name} (Completed {cg.CurrentCount}/{cg.TargetCount} times)");
                            }
                            else
                            {
                                status = goals[i].IsComplete == "True" ? "[X]" : "[ ]";
                                Console.WriteLine($"{i + 1}. {status} {goals[i].Name}");
                            }
                        }
                        break;
                    case "3":
                        // Save goals and score to file
                        Console.Write("Enter filename to save: ");
                        string saveFile = Console.ReadLine();
                        using (var writer = new System.IO.StreamWriter(saveFile))
                        {
                            writer.WriteLine(totalPoints);
                            foreach (var goal in goals)
                            {
                                if (goal is ChecklistGoal cg)
                                {
                                    writer.WriteLine($"Checklist|{cg.Name}|{cg.Points}|{cg.IsComplete}|{cg.TargetCount}|{cg.CurrentCount}|{cg.ValuePerCompletion}|{cg.BonusValue}");
                                }
                                else if (goal is SimpleGoal)
                                {
                                    writer.WriteLine($"Simple|{goal.Name}|{goal.Points}|{goal.IsComplete}");
                                }
                                else if (goal is EternalGoal)
                                {
                                    writer.WriteLine($"Eternal|{goal.Name}|{goal.Points}|{goal.IsComplete}");
                                }
                            }
                        }
                        Console.WriteLine("Goals and score saved.");
                        break;
                    case "4":
                        // Load goals and score from file
                        Console.Write("Enter filename to load: ");
                        string loadFile = Console.ReadLine();
                        if (!System.IO.File.Exists(loadFile))
                        {
                            Console.WriteLine("File not found.");
                            break;
                        }
                        goals.Clear();
                        string[] lines = System.IO.File.ReadAllLines(loadFile);
                        if (lines.Length > 0)
                            int.TryParse(lines[0], out totalPoints);
                        for (int i = 1; i < lines.Length; i++)
                        {
                            var parts = lines[i].Split('|');
                            if (parts[0] == "Simple")
                            {
                                var g = new SimpleGoal(parts[1], parts[2]);
                                g.IsComplete = parts[3];
                                goals.Add(g);
                            }
                            else if (parts[0] == "Eternal")
                            {
                                var g = new EternalGoal(parts[1], parts[2]);
                                g.IsComplete = parts[3];
                                goals.Add(g);
                            }
                            else if (parts[0] == "Checklist")
                            {
                                var g = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[6]), int.Parse(parts[7]));
                                g.IsComplete = parts[3];
                                g.TargetCount = int.Parse(parts[4]);
                                g.CurrentCount = int.Parse(parts[5]);
                                goals.Add(g);
                            }
                        }
                        Console.WriteLine("Goals and score loaded.");
                        break;

                case "5":
                    // Record Event
                    Console.WriteLine("Which goal did you accomplish?");
                    for (int i = 0; i < goals.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {goals[i].Name}");
                    }
                    int goalIndex = int.Parse(Console.ReadLine()) - 1;
                    if (goalIndex >= 0 && goalIndex < goals.Count)
                    {
                        int earned = 0;
                        var chosen = goals[goalIndex];
                        if (chosen is ChecklistGoal checklistGoal)
                        {
                            checklistGoal.Record();
                            earned = checklistGoal.ValuePerCompletion;
                            if (checklistGoal.IsComplete == "True")
                            {
                                earned += checklistGoal.BonusValue;
                                Console.WriteLine("Bonus ! You completed the checklist goal.");
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