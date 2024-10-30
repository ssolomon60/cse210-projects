using System;
using System.Collections.Generic;

abstract class Activity
{
    private readonly DateTime _date;
    private readonly int _minutes;
    protected Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }
    protected int Minutes => _minutes;
    public abstract double GetDistance();
    public double GetSpeed() => (GetDistance() / _minutes) * 60;
    public double GetPace() => _minutes / GetDistance();
    public string GetSummary() => $"{_date: dd MM yyy} {GetType().Name} ({_minutes} min): Distance {GetDistance(): 0.0} km, Speed {GetSpeed(): 0.0} kph. Pace {GetPace(): 0.0} min per km";
}
class Running : Activity
{
    private readonly double _distance;
    public Running(DateTime date, int minutes, double distance) : base(date, minutes) => _distance = distance;
    public override double GetDistance() => _distance;
}
class Cycling : Activity
{
    private readonly double _speed;
    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes) => _speed = speed;
    public override double GetDistance() => (_speed * Minutes) / 60;
}
class Swimming : Activity
{
    private readonly int _laps;
    private const double LapDistance = 50 / 1000.0;
    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes) => _laps = laps;
    public override double GetDistance() => _laps * LapDistance;
}
class Program
{
    static void Main()
    {
        var activities = new List<Activity>();
        bool addingActivities = true;

        while (addingActivities)
        {
            Console.WriteLine("Enter the type of activity (running, cycling, swimming): ");
            string activityType = Console.ReadLine()?.ToLower();

            Console.WriteLine("Enter the date of activity (YYYY-MM-DD): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the duration of the activity in minutes: ");
            int minutes = int.Parse(Console.ReadLine());

            switch (activityType)
            {
                case "running":
                    Console.WriteLine("Enter the distance covered in kilometers: ");
                    double runningDistance = double.Parse(Console.ReadLine());
                    activities.Add(new Running(date, minutes, runningDistance));
                    break;

                case "cycling":
                    Console.WriteLine("Enter the average speed in kph: ");
                    double cyclingSpeed = double.Parse(Console.ReadLine());
                    activities.Add(new Cycling(date, minutes, cyclingSpeed));
                    break;

                case "swimming":
                    Console.WriteLine("Enter the number of laps completed: ");
                    int swimmingLaps = int.Parse(Console.ReadLine());
                    activities.Add(new Swimming(date, minutes, swimmingLaps));
                    break;

                default:
                    Console.WriteLine("Invalid activity type.");
                    continue;
            }

            Console.WriteLine("Would you like to add another activity? (yes/no): ");
            addingActivities = Console.ReadLine()?.ToLower() == "yes";
        }

        Console.WriteLine("\nActivity Summary:");
        activities.ForEach(activity => Console.WriteLine(activity.GetSummary()));
    }
}