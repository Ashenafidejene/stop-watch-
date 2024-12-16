using System;

public static class EventHandlers
{
    public static void HandleOnStarted(string message)
    {
        Console.SetCursorPosition(0, 7);
        Console.WriteLine(message);
    }

    public static void HandleOnStopped(string message)
    {
        Console.SetCursorPosition(0, 7);
        Console.WriteLine(message);
    }

    public static void HandleOnReset(string message)
    {
        Console.SetCursorPosition(0, 7);
        Console.WriteLine(message);
    }
}