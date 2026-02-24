using System;

class CyclingActivity : Activity
{
    private double _speedMph;

    public CyclingActivity(DateTime date, int minutes, double speedMph)
        : base(date, minutes)
    {
        _speedMph = speedMph;
    }

    public override double GetDistance()
    {
        return (_speedMph * GetMinutes()) / 60;
    }

    public override double GetSpeed()
    {
        return _speedMph;
    }

    public override double GetPace()
    {
        return 60 / _speedMph;
    }
}