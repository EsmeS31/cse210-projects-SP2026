using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("03 Nov 2022", 30, 4.8));
        activities.Add(new Cycling("03 Nov 2022", 45, 24.0));
        activities.Add(new Swimming("03 Nov 2022", 20, 40));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}