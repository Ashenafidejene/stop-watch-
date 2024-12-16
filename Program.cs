using System;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();

    
        stopwatch.OnStarted += EventHandlers.HandleOnStarted;
        stopwatch.OnStopped += EventHandlers.HandleOnStopped;
        stopwatch.OnReset += EventHandlers.HandleOnReset;

        bool isRunning = true;
        stopwatch.UpdateConsole();

        while (isRunning)
        {
            Console.SetCursorPosition(0, 9);
            Console.Write("Enter Command: ");
            string input = Console.ReadLine()?.ToUpper();

            switch (input)
            {
                case "S":
                    new System.Threading.Thread(stopwatch.Start).Start();
                    break;

                case "T":
                    stopwatch.Stop();
                    break;

                case "R":
                    stopwatch.Reset();
                    break;

                case "Q":
                    isRunning = false;
                    stopwatch.Stop(); // Stop any running threads
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine("Invalid Command. Use S, T, R, or Q.");
                    break;
            }
        }
    }
}