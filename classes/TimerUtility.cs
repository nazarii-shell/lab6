using System;
using System.Diagnostics;

public static class TimerUtility
{
    public static double TimeSortExecution<T>(Action<T> action, T data)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        action(data);

        stopwatch.Stop();
        return (double)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000;
    }  
    public static double TimeSortExecution(Action<int[], int> action, int[] data, int toFind)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        action(data, toFind);

        stopwatch.Stop();
        return (double)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000;
    }  
}

