using System;
using System.Threading;

public class MutexDemo
{
    // Unique name for the Mutex (system-wide)
    private static readonly string MutexName = "Global\\MyUniqueMutexName";
    private static Mutex mutex;

    public static void Run()
    {
        Console.WriteLine("Starting Mutex Demo...");

        // Try to create the Mutex with a unique name
        bool isNewInstance;
        mutex = new Mutex(true, MutexName, out isNewInstance);

        if (isNewInstance)
        {
            Console.WriteLine("No other instance is running. This instance owns the Mutex.");
            Console.WriteLine("Press Enter to release the Mutex and exit.");
            Console.ReadLine();

            // Release the Mutex
            mutex.ReleaseMutex();
        }
        else
        {
            Console.WriteLine("Another instance is already running. Exiting...");
        }

        Console.WriteLine("Mutex Demo Completed.");
    }
}
