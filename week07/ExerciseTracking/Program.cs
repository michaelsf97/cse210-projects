using System;
class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new RunningActivity(new DateTime(2026, 2, 21), 30, 3.0),
            new CyclingActivity(new DateTime(2026, 2, 21), 45, 15.0),
            new SwimmingActivity(new DateTime(2026, 2, 21), 40, 40)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

