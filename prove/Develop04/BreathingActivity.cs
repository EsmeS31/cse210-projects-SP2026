using System;

public class BreathingActivity : Activity
{
    private int _inhaleInt = 4;
    private int _exhaleInt = 6;

    public BreathingActivity() : base("Breathing Activity", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void RunActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(Seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in... ");
            DynamicPulseCountdown(_inhaleInt, true);
            Console.WriteLine();

            Console.Write("Now breathe out... ");
            DynamicPulseCountdown(_exhaleInt, false);
            Console.WriteLine();
        }
    }

    private void DynamicPulseCountdown(int seconds, bool expanding)
    {
        for (int i = 1; i <= seconds; i++)
        {
            if (expanding)
                Console.Write(new string('>', i));
            else
                Console.Write(new string('<', seconds - i + 1));

            System.Threading.Thread.Sleep(1000);
            
            Console.Write(new string('\b', 25));
            Console.Write(new string(' ', 25));
            Console.Write(new string('\b', 25));
        }
    }
}