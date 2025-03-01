using System;
using System.Threading;
using System.Threading.Tasks;

public class CancellationTokensDemo
{
    public static async Task Run()
    {
        Console.WriteLine("Starting Cancellation Tokens Demo...");

        // Create a CancellationTokenSource
        CancellationTokenSource cts = new CancellationTokenSource();

        // Start a long-running task and pass the cancellation token
        Task longRunningTask = LongRunningOperationAsync(cts.Token);

        Console.WriteLine("Press 'C' to cancel the operation...");

        // Listen for user input to cancel the operation
        while (!longRunningTask.IsCompleted)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.C)
                {
                    Console.WriteLine("Cancelling operation...");
                    cts.Cancel(); // Trigger cancellation
                    break;
                }
            }
            await Task.Delay(100); // Check every 100 ms
        }

        try
        {
            await longRunningTask;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operation was cancelled.");
        }
        finally
        {
            cts.Dispose();
        }

        Console.WriteLine("Cancellation Tokens Demo Completed.");
    }

    // Long-running operation with support for cancellation
    private static async Task LongRunningOperationAsync(CancellationToken token)
    {
        Console.WriteLine("Starting long-running operation...");

        for (int i = 1; i <= 10; i++)
        {
            // Check for cancellation request
            token.ThrowIfCancellationRequested();

            Console.WriteLine($"Processing step {i}...");
            await Task.Delay(1000); // Simulate long processing

            // Check for cancellation in a different way (optional)
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Cancellation requested. Stopping...");
                break;
            }
        }

        Console.WriteLine("Long-running operation completed.");
    }
}
