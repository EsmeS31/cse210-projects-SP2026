class Entry
{
    //attributes
    public string _date;
    public string _response;
    public string _prompt;

    //Behaviors
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine(_response);
        Console.WriteLine();
    }

}
