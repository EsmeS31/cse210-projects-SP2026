using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _unusedPrompts;

    public ListingActivity() : base("Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        PromptList = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt peace or inspiration this month?",
            "Who are some of your personal heroes?"
        };
    }

    protected override void RunActivity()
    {
        string prompt = GetRandomItemFromList(PromptList, ref _unusedPrompts);
        Console.WriteLine("List as many items as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        Countdown(5);
        Console.WriteLine();

        List<string> itemsGathered = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(Seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                itemsGathered.Add(input);
            }
        }

        Console.WriteLine($"You listed {itemsGathered.Count} items!");
    }
}