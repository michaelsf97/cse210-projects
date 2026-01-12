using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private string[] _questions;

    public Journal(string[] questions)
    {
        _questions = questions;
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display yet. ");
        }
        else
        {
            foreach (var entry in _entries)
            {
                entry.Display(_questions);
            }
        }
    }

    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry.Date);
                foreach (var answer in entry.Answers)
                {
                    writer.WriteLine(answer);
                }
            }
        }
        Console.WriteLine($"Entries saved to {filename}!");
    }

    public void load (string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _entries.Clear();
            for (int i = 0; i < lines.Length; i += _questions.Length + 1)
            {
                DateTime date = DateTime.Parse(lines[i]);
                string[] loadedAnswers = new string[_questions.Length];
                for (int j = 0; j < _questions.Length; j++)
                {
                    loadedAnswers[j] = lines[i + j + 1];
                }
                _entries.Add(new Entry(date, loadedAnswers));
            }
            Console.WriteLine("Entries loaded!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
