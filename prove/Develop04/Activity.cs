using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public abstract class Activity
{
    private int _seconds;
    private string _promptStr;
    private List<string> _promptList;
    private string _startMessage;
    private string _endMessage;
    private string _description;

    public int Seconds 
    { 
        get => _seconds; 
        set => _seconds = value; 
    }
    public string Description 
    { 
        get => _description; 
        set => _description = value; 
    }
    public string StartMessage 
    { 
        get => _startMessage; 
        set => _startMessage = value; 
    }
    public string EndMessage 
    { 
        get => _endMessage; 
        set => _endMessage = value; 
    }
    public List<string> PromptList 
    { 
        get => _promptList; 
        set => _promptList = value; 
    }

    public Activity(string name, string description)
    {
        _startMessage = $"Welcome to the {name}.\n";
        _description = description;
        _endMessage = "\nWell done!!";
        _promptList = new List<string>();
    }

    public void Display()
    {
        GetStartMessage();
        Console.Clear();
        Console.WriteLine("Get ready...");
        DisplaySpinner(5);
        Console.WriteLine();

        RunActivity(); 

        GetEndMessage(this.GetType().Name);
    }

    protected abstract void RunActivity();

    public void GetStartMessage()
    {
        Console.Clear();
        Console.WriteLine(_startMessage);
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        
        if (int.TryParse(Console.ReadLine(), out int duration))
        {
            _seconds = duration;
        }
        else
        {
            _seconds = 30;
        }
    }

    public void GetEndMessage(string activityName)
    {
        Console.WriteLine(_endMessage);
        DisplaySpinner(3);
        string friendlyName = System.Text.RegularExpressions.Regex.Replace(activityName, "([A-Z])", " $1").Trim();
        Console.WriteLine($"You have completed another {_seconds} seconds of the {friendlyName}.");
        DisplaySpinner(4);
    }

    public void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void DisplaySpinner(int seconds)
    {
        List<string> spinnerChars = new List<string> { "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = spinnerChars[i];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
            if (i >= spinnerChars.Count)
            {
                i = 0;
            }
        }
    }

    protected string GetRandomItemFromList(List<string> sourceList, ref List<string> trackingList)
    {
        if (trackingList == null || trackingList.Count == 0)
        {
            trackingList = new List<string>(sourceList);
            // Quick linear shuffle
            Random rng = new Random();
            int n = trackingList.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = trackingList[k];
                trackingList[k] = trackingList[n];
                trackingList[n] = value;
            }
        }

        string selection = trackingList[0];
        trackingList.RemoveAt(0);
        return selection;
    }
}