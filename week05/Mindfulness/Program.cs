using System;
using System.Xml.Serialization;

class Program
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
                StartBreathingActivity();
                break;
        case "2":
                StartReflectingActivity();
                break;
        
        case "3":
                StartListingActivity();
                break;
            
        case "4":
        running = false;
                Console.WriteLine("Exit");
                break;

        }
        Console.WriteLine();
    }

    static void StartBreathingActivity()
    {
        Console.WriteLine("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");

        Console.WriteLine("How long, in seconds, wpuld you like for your session?");
    }

    static void StartReflectingActivity()
    {
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        Random random = new Random();
        string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
        };
        int index = random.Next(prompts.Length);
        Console.WriteLine(prompts[index]);

        string[] questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not a successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",

            
        };
        int index = random.Next(questions.Length);
        Console.WriteLine(questions[index]);
    }

    static void StartListingActivity()

    {
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many as you can in a certain area.");
        Random random = new Random();
        string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths og yours?",
            "Who are people that you have helped this week?",
            "When you have felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
        }
    }

            

        }
    }
}