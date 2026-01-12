using System;

public class PromptGenerator
{
    private string[] _prompts;
    private Random _random;

    public PromptGenerator(string[] prompts)
    {
        _prompts = prompts;
        _random = new Random();
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Length);
        return _prompts[index];
    }
}
