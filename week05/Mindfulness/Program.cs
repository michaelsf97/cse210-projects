using System;
using System.Timers;
using System.Xml.Serialization;


public abstract class Activity
{
    private string name;
    private string description;
    private int duration;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public void PromptDuration()
    {
        Console.WriteLine("How long, in seconds, would you like for your session? ");
        duration = int.Parse(Console.ReadLine());
    }

    public int GetDuration() => duration;
    public virtual void Start()
    {
        Console.WriteLine($"Starting {name} activity...");
        Console.WriteLine(description);
        PromptDuration();
        Console.WriteLine("Get ready to begin");
        Thread.Sleep(3000);

    }


    public virtual void End()
    {
        Console.WriteLine($"Well Done!!, you have completed the {name} activity.");
    }
}

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Start()
    {
        base.Start();
        int interval = 5;
        int elapsed = 0;
        int duration = GetDuration();
        while (elapsed < duration)
        {
            Console.WriteLine("Breathe in...");
            for (int i = interval; i > 0 && elapsed < duration; i--, elapsed++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
            if (elapsed >= duration) break;
            Console.WriteLine("Breathe out...");
            for (int i = interval; i > 0 && elapsed < duration; i--, elapsed++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }
        End();
    }
}

public class ReflectingActivity : Activity
{
    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void Start()
    {
        base.Start();
        Random random = new Random();
        string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
        };
        int promptIndex = random.Next(prompts.Length);
        Console.WriteLine(prompts[promptIndex]);

        string[] questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        int elapsed = 0;
        int pauseSeconds = 5;
        int duration = GetDuration();
        while (elapsed < duration)
        {
            int questionIndex = random.Next(questions.Length);
            Console.WriteLine(questions[questionIndex]);
            for (int s = 0; s < pauseSeconds && elapsed < duration; s++, elapsed++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
        End();
    }
}

public class ListingActivity : Activity
{
    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many as you can in a certain area.")
    {
    }

    public override void Start()
    {
        base.Start();
        Random random = new Random();
        string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        int promptIndex = random.Next(prompts.Length);
        Console.WriteLine(prompts[promptIndex]);
        Console.WriteLine("You will have a few seconds to think about your prompt...");
        Thread.Sleep(3000);
        Console.WriteLine("Start listing items. Press Enter after each item.");
        int duration = GetDuration();
        int elapsed = 0;
        int itemCount = 0;
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            if (Console.KeyAvailable)
            {
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                    itemCount++;
            }
        }
        Console.WriteLine($"You listed {itemCount} items!");
        End();
    }
}

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Lesson", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

        public override void Start()
        {
            base.Start();

            End();
        }
};

public abstract class ReflectingActivity : Activity
{
    public ReflectingActivity() : base("Reflecting Lesson", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

        public override void Start()
        {
            base.Start();
            End();   
        }
}

public abstract class ListingActivity : Activity
{
    public ListingActivity() : base("Listing Lesson", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }
        public override void Start()
        {
            base.Start();
            End();
        }
}

    private class NewBaseType
    {
        static void StartListingActivity()
        {
            Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many as you can in a certain area.");
            Random random = new Random();
            string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When you have felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
        };
            int index = random.Next(prompts.Length);
            Console.WriteLine(prompts[index]);

            int elapsed = 0;
            int pauseSeconds = 5;

            while (elapsed < duration)
            {
                int questionIndex = random.Next(questions.Length);
                Console.WriteLine(questions[questionIndex]);

                for (int s = 0; s < pauseSeconds && elapsed < duration; s++, elapsed++)
                {
                    Console.WriteLine(".");
                    Thread.Sleep(1000);
                }

                Console.WriteLine();
            }

            Console.WriteLine("Well Done!!, you have completed the reflecting activity.");

        }
    }

    class Program : NewBaseType
    {
    static void Main(string[] args)
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Start breathing activity");
        Console.WriteLine("2. Start reflecting activity");
        Console.WriteLine("3. Start listing activity");
        Console.WriteLine("4. Quit");
        Console.WriteLine("Select a choice from the menu: ");

        string input = Console.ReadLine();
        switch (input)
        {
        case "1":
            Activity activity = new BreathingActivity();
            activity.Start();
            break;
        case "2":
            Activity activity = new ReflectingActivity();
            activity.Start();
            break;
        
        case "3":
            static void Main(string[] args)
            {
                bool running = true;
                while (running)
                {
                    Console.WriteLine("Menu Options:");
                    Console.WriteLine("1. Start breathing activity");
                    Console.WriteLine("2. Start reflecting activity");
                    Console.WriteLine("3. Start listing activity");
                    Console.WriteLine("4. Quit");
                    Console.Write("Select a choice from the menu: ");

                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            Activity breathing = new BreathingActivity();
                            breathing.Start();
                            break;
                        case "2":
                            Activity reflecting = new ReflectingActivity();
                            reflecting.Start();
                            break;
                        case "3":
                            Activity listing = new ListingActivity();
                            listing.Start();
                            break;
                        case "4":
                            running = false;
                            Console.WriteLine("Exit");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.\n");
                            break;
                    }
                    Console.WriteLine();
                }
            }
        }
    }
    }