using System;
using System.Threading;

public delegate void StopwatchEventHandler(string message);

public class Stopwatch
{
    private TimeSpan timeElapsed = TimeSpan.Zero;
    private bool isRunning = false;

    public event StopwatchEventHandler OnStarted;
    public event StopwatchEventHandler OnStopped;
    public event StopwatchEventHandler OnReset;

    public void Start()
    {
        if (isRunning) return;

        isRunning = true;
        OnStarted?.Invoke("Stopwatch Started!");
        
        while (isRunning)
        {
            Tick();
            Thread.Sleep(1000); // Simulate 1-second ticking
            UpdateConsole();
        }
    }

    public void Stop()
    {
        if (!isRunning) return;

        isRunning = false;
        OnStopped?.Invoke("Stopwatch Stopped!");
        UpdateConsole();
    }

    public void Reset()
    {
        if (isRunning) return;

        timeElapsed = TimeSpan.Zero;
        OnReset?.Invoke("Stopwatch Reset!");
        UpdateConsole();
    }

    private void Tick()
    {
        timeElapsed = timeElapsed.Add(TimeSpan.FromSeconds(1));
    }

    public void UpdateConsole()
    {
        Console.Clear();
        Console.WriteLine("===== Stopwatch =====");
        Console.WriteLine($"Elapsed Time: {timeElapsed}");
        Console.WriteLine("=====================");
        Console.WriteLine("Commands:");
        Console.WriteLine("S - Start");
        Console.WriteLine("T - Stop");
        Console.WriteLine("R - Reset");
        Console.WriteLine("Q - Quit");
    }
}