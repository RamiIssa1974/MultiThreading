using System;
using System.Threading.Tasks;

public class AsyncExceptionHandlingDemo
{
    public static async Task Run()
    {
        Console.WriteLine("Starting Async Exception Handling Demo...");

        // Single Task Exception Handling
        try
        {
            await FailingTaskAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught exception from FailingTaskAsync: {ex.Message}");
        }

        Console.WriteLine("Moving on to multiple tasks...");

        // Multiple Tasks Exception Handling with WhenAll
        Task[] tasks = new Task[]
        {
            FailingTaskAsync(),
            SucceedingTaskAsync(),
            AnotherFailingTaskAsync()
        };

        try
        {
            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Caught exception from Task.WhenAll!");

            // Check if there are multiple exceptions
            if (ex is AggregateException aggEx)
            {
                foreach (var inner in aggEx.InnerExceptions)
                {
                    Console.WriteLine($"Inner Exception: {inner.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        Console.WriteLine("Async Exception Handling Demo Completed.");
    }

    // This method throws an exception
    private static async Task FailingTaskAsync()
    {
        await Task.Delay(1000); // Simulate some work
        throw new InvalidOperationException("Something went wrong in FailingTaskAsync!");
    }

    // This method succeeds without exceptions
    private static async Task SucceedingTaskAsync()
    {
        await Task.Delay(500); // Simulate some work
        Console.WriteLine("SucceedingTaskAsync completed successfully.");
    }

    // This method throws a different exception
    private static async Task AnotherFailingTaskAsync()
    {
        await Task.Delay(800); // Simulate some work
        throw new ArgumentNullException("A required parameter was null in AnotherFailingTaskAsync!");
    }
}
