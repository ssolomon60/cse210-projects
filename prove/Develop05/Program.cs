using System;
using System.Threading;
using System.Collections.Generic;

public abstract class Activity
{
    string _name;
    string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessages()
    {
        Console.WriteLine($"Starting {_name}");
        Console.WriteLine(_description);
        Console.Write("Enter Duration (seconds): ");
        _duration = int.Parse(Console.ReadLine());
    }

    public void DisplayEnding()
    {
        Console.WriteLine("Well Done!");
        ShowSpinner(3);
        Console.WriteLine($"You completed {_name} for {_duration} seconds.");
    }

    protected void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string> { "|", "/", "-", "\\", "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(animationStrings[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i = (i + 1) % animationStrings.Count;
        }
    }

    public abstract void Run();
}

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding you to breathe in and out slowly.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessages();
        for (int i = 0; i < _duration / 6; i++)
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(3);
            Console.WriteLine("Breathe out...");
            ShowSpinner(3);
        }
        DisplayEnding();
    }
}

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>
    {
        "Where and when have you felt the Holy Spirit this week?",
        "What things have you done that made you proud this week?",
        "What was your favorite point about this week?"
    };

    public ListingActivity() : base("Listing Activity", "This activity helps you reflect on the good things in your life by having you list as many things as possible.")
    {
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }

    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        Console.WriteLine("Start Listing Items: ");
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }

        return items;
    }

    public override void Run()
    {
        DisplayStartingMessages();
        Console.WriteLine(GetRandomPrompt());
        ShowSpinner(3);
        List<string> items = GetListFromUser();
        _count = items.Count;
        Console.WriteLine($"You listed {_count} items.");
        DisplayEnding();
    }
}

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Do you have any regrets and how will you overcome them in the future?",
        "Reflect on the future, how can you obtain that future version of yourself?",
        "Is Cereal a soup?"
    };

    private List<string> _questions = new List<string>
    {
        "Why did you think the way you did?",
        "What did you learn about yourself? About others?",
        "How are you feeling now?"
    };

    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times when you have shown strength and resilience.")
    {
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();
        return _questions[random.Next(_questions.Count)];
    }

    private void DisplayQuestions()
    {
        for (int i = 0; i < _duration / 6; i++)
        {
            Console.WriteLine(GetRandomQuestion());
            ShowSpinner(3);
        }
    }

    public override void Run()
    {
        DisplayStartingMessages();
        Console.WriteLine(GetRandomPrompt());
        ShowSpinner(3);
        DisplayQuestions();
        DisplayEnding();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose an Activity");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Quit");
            string choice = Console.ReadLine();

            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ListingActivity(),
                "3" => new ReflectingActivity(),
                "4" => null,
                _ => null
            };

            if (activity == null) break;

            activity.Run();
        }
    }
}
