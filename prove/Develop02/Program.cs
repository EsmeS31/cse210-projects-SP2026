using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop02 World!");
        Entry entry = new Entry(); 
        DateTime theCurrentTime = DateTime.Now;
        entry._date = theCurrentTime.ToShortDateString();
        entry._prompt = "<insert cool prompt here>";
        entry._response = "<insert whatever the user typed here>";
        entry.Display();
    }
}