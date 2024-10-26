using System;
using System.Collections.Generic;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public virtual string GetDetails() => $"{_name}: {_description} - {_points} points";
}

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"{_name} completed!");
    }

    public override bool IsComplete() => _isComplete;
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) 
        : base(name, description, points) { }

    public override void RecordEvent() => Console.WriteLine($"Event recorded for {_name}. Keep going!");
    public override bool IsComplete() => false;
}

public class ChecklistGoal : Goal
{
    private int _progress;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) 
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (++_progress >= _target)
            Console.WriteLine($"{_name} complete! Bonus: {_bonus} points!");
        else
            Console.WriteLine($"{_name}: {_progress}/{_target}");
    }

    public override bool IsComplete() => _progress >= _target;
}

public class GoalManager
{
    private List<Goal> _goals = new();
    private int _score;

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\n1. Create Goal\n2. List Goals\n3. Record Event\n4. Score\n5. Exit");
            switch (Console.ReadLine())
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": Console.WriteLine($"Score: {_score}"); break;
                case "5": return;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("Goal Type: 1. Simple 2. Eternal 3. Checklist");
        Goal goal = Console.ReadLine() switch
        {
            "1" => new SimpleGoal(Prompt("Name"), Prompt("Description"), IntPrompt("Points")),
            "2" => new EternalGoal(Prompt("Name"), Prompt("Description"), IntPrompt("Points")),
            "3" => new ChecklistGoal(Prompt("Name"), Prompt("Description"), IntPrompt("Points"), IntPrompt("Target"), IntPrompt("Bonus")),
            _ => null
        };

        if (goal != null) _goals.Add(goal);
    }

    private void ListGoals() => _goals.ForEach(g => Console.WriteLine(g.GetDetails()));
    
    private void RecordEvent()
    {
        for (int i = 0; i < _goals.Count; i++) 
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");

        if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= _goals.Count)
        {
            var goal = _goals[idx - 1];
            goal.RecordEvent();
            if (goal.IsComplete()) _score += goal is ChecklistGoal ? 50 : 10;
        }
    }

    private string Prompt(string message)
    {
        Console.Write($"{message}: ");
        return Console.ReadLine();
    }

    private int IntPrompt(string message)
    {
        Console.Write($"{message}: ");
        return int.TryParse(Console.ReadLine(), out int value) ? value : 0;
    }
}

class Program
{
    static void Main() => new GoalManager().Start();
}