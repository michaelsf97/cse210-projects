using System;
using System.Collections.Generic;

namespace cse210projects
{
    abstract class Activity
    {
        private DateTime _date;
        private int _minutes;

    protected Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime GetDate() => _date;
    public int GetMinutes() => _minutes;


    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();


    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min) - " +
               $"Distance: {GetDistance():F1} Miles, Speed: {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F2} min per mile";
    }
    }
}