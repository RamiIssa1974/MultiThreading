using System;
using System.Threading;
using System.Threading.Tasks;

public class ThreadSafetyDemo
{
    private static int sharedCounter = 0; // Shared resource
    private static readonly object lockObject = new object(); // Lock object

    public static async Task Run()
    {
        Console.WriteLine("Starting Thread Safety Demo...");

        // Create multiple tasks to increment the shared counter
        Task[] tasks = new Task[10];
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                for (int j = 0; j < 1000; j++)
                {
                    // Uncomment one of the following to see the difference:

                    // Race Condition (Uncomment this to see inconsistent results)
                    // sharedCounter++;

                    // Using Lock to Ensure Thread Safety
                    lock (lockObject)
                    {
                        sharedCounter++;
                    }
                }
            });
        }

        await Task.WhenAll(tasks);

        Console.WriteLine($"Final Counter Value: {sharedCounter}");
        Console.WriteLine("Thread Safety Demo Completed.");
    }
}
