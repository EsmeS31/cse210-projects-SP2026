using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _questionList;
    
    // Unique list references to track item tracking for uniquely served questions
    private List<string> _unusedPrompts;
    private List<string> _unusedQuestions;

    public ReflectionActivity() : base("Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        PromptList = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questionList = new List<string>
        {
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
    }

    protected override void RunActivity()
    {
        string prompt = GetRandomItemFromList(PromptList, ref _unusedPrompts);
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        Countdown(5);
        Console.Clear();

        DateTime endTime = DateTime.Now.AddSeconds(Seconds);
        while (DateTime.Now < endTime)
        {
            string question = GetRandomItemFromList(_questionList, ref _unusedQuestions);
            Console.Write($"\n> {question} ");
            DisplaySpinner(10);
            Console.WriteLine();
        }
    }
}