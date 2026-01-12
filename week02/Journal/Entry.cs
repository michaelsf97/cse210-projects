using System;

public class Entry
{
    public DateTime Date { get; set; }
    public string[] Answers { get; set; }

    public Entry(DateTime date, string[] answers)
    {
        Date = date;
        Answers = answers;
    }

    public void Display(string[] questions)
    {
        Console.WriteLine($"Date: {Date}");
        for (int i = 0; i < questions.Length; i++)
        {
            Console.WriteLine($"Q: {questions[i]}");
            Console.WriteLine($"A: {Answers[i]}");
        }
        Console.WriteLine();
    }
}
