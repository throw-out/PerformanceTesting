using System;

public class Timer
{
    public static DateTime ZERO = new DateTime(1970, 1, 1, 0, 0, 0);

    private double _start;
    public Timer()
    {
        this._start = (DateTime.Now - ZERO).TotalMilliseconds;
    }
    public double End()
    {
        return (DateTime.Now - ZERO).TotalMilliseconds - this._start;
    }
}