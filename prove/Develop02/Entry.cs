class Entry
{
    //attributes
    public string _date;
    public string _response;
    public string _prompt;

    //Behaviors
    public void Display()
    {
        Console.WriteLine($"{_date} -- {_prompt} \n {_response}");
    }

}