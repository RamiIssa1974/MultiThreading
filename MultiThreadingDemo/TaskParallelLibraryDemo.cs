using System;
using System.Threading;
using System.Threading.Tasks;

public class TaskParallelLibraryDemo
{
    public static void Run()
    {
        Console.WriteLine("Starting Task Parallel Library Demo...");

        // Array of numbers to process
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Using Tasks to process numbers in parallel
        Task[] tasks = new Task[numbers.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            int num = numbers[i];
            tasks[i] = Task.Run(() => ProcessNumber(num));
        }

        // Wait for all tasks to complete
        Task.WaitAll(tasks);

        Console.WriteLine("All tasks completed.");
    }

    // Method to process a number
    private static void ProcessNumber(int num)
    {
        Console.WriteLine($"Processing number: {num} on Thread {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(1000); // Simulate processing time
        Console.WriteLine($"Finished processing number: {num}");
    }
}
