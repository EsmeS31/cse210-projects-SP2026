/*
    Creativity:
    Added a leveling system.

    Every 1000 points earned increases the user's level.
    The current level is displayed with the score.
*/

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();

            int level = score / 1000 + 1;

            Console.WriteLine($"Score: {score}");
            Console.WriteLine($"Level: {level}");
            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("\nSelect a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    ListGoals();
                    break;

                case "3":
                    SaveGoals();
                    break;

                case "4":
                    LoadGoals();
                    break;

                case "5":
                    RecordEvent();
                    break;

                case "6":
                    running = false;
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.Clear();

        Console.WriteLine("Goal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Choose goal type: ");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("Target count: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            goals.Add(
                new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus));
        }
    }

    static void ListGoals()
    {
        Console.Clear();

        Console.WriteLine("Goals:\n");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDisplayString()}");
        }

        Console.WriteLine("\nPress Enter...");
        Console.ReadLine();
    }

    static void RecordEvent()
    {
        Console.Clear();

        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Select Goal:\n");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetTitle()}");
        }

        Console.Write("\nChoice: ");

        int index = int.Parse(Console.ReadLine()) - 1;

        int earnedPoints = goals[index].RecordEvent();

        score += earnedPoints;

        Console.WriteLine($"\nYou earned {earnedPoints} points!");
        Console.WriteLine($"Total Score: {score}");

        Console.ReadLine();
    }

    static void SaveGoals()
    {
        Console.Write("Filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(score);

            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.GetSaveString());
            }
        }

        Console.WriteLine("Saved.");
        Console.ReadLine();
    }

    static void LoadGoals()
    {
        Console.Write("Filename: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            Console.ReadLine();
            return;
        }

        goals.Clear();

        string[] lines = File.ReadAllLines(filename);

        score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            if (parts[0] == "SimpleGoal")
            {
                SimpleGoal goal =
                    new SimpleGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]));

                if (bool.Parse(parts[4]))
                {
                    goal.RecordEvent();
                }

                goals.Add(goal);
            }
            else if (parts[0] == "EternalGoal")
            {
                goals.Add(
                    new EternalGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3])));
            }
            else if (parts[0] == "ChecklistGoal")
            {
                goals.Add(
                    new ChecklistGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        int.Parse(parts[5]),
                        int.Parse(parts[6]),
                        bool.Parse(parts[7])));
            }
        }

        Console.WriteLine("Loaded.");
        Console.ReadLine();
    }
}