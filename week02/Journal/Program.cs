using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Welcome To The Journal Program.");
        Console.WriteLine("Please select one of the following choices: ");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.WriteLine("What would you like to do? ");

        string[] questions =
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        Journal journal = new Journal(questions);
        bool running = true;
        while (running)
        {
            Console.WriteLine("Please select one of the following choices: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("What would you like to do? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var answers = new string[questions.Length];
                    for (int i = 0; i < questions.Length; i++)
                    {
                        Console.WriteLine(questions[i]);
                        answers[i] = Console.ReadLine();
                    }
                    Entry entry = new Entry(DateTime.Now, answers);
                    journal.AddEntry(entry);
                    break;
                case "2":
                    journal.Display();
                    break;
                case "3":
                    Console.WriteLine("Load");
                    Console.WriteLine("Enter filename to load:");
                    string filename = Console.ReadLine();
                    journal.load(filename);
                    break;
                case "4":
                    Console.WriteLine("Save");
                    Console.WriteLine("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.Save(saveFilename);
                    break;
                case "5":
                    Console.WriteLine("Quit");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please put a valid option.");
                    break;
            }
            Console.WriteLine();
        }

    }
}


