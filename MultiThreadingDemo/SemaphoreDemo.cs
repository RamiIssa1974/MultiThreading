using System;
using System.Threading;
using System.Threading.Tasks;

public class SemaphoreDemo
{
    // SemaphoreSlim with a limit of 3 concurrent threads
    private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(3);

    public static async Task Run()
    {
        Console.WriteLine("Starting Semaphore Demo...");

        // Create multiple tasks to simulate concurrent requests
        Task[] tasks = new Task[10];
        for (int i = 0; i < tasks.Length; i++)
        {
            int requestId = i + 1;
            tasks[i] = Task.Run(() => AccessResource(requestId));
        }

        await Task.WhenAll(tasks);

        Console.WriteLine("Semaphore Demo Completed.");
    }

    // Method to simulate accessing a limited resource
    private static async Task AccessResource(int requestId)
    {
        Console.WriteLine($"Request {requestId} is waiting to access the resource...");

        // Wait to enter the semaphore (acquire a slot)
        await semaphore.WaitAsync();

        try
        {
            Console.WriteLine($"Request {requestId} has entered the resource.");
            await Task.Delay(2000); // Simulate work with the resource
            Console.WriteLine($"Request {requestId} has finished and is leaving the resource.");
        }
        finally
        {
            // Release the semaphore (free a slot)
            semaphore.Release();
        }
    }
}
