using System;
using System.Threading.Tasks;

public class TaskWhenAllDemo
{
    public static async Task Run()
    {
        Console.WriteLine("Starting Task.WhenAll Demo...");

        // Create multiple tasks for downloading data in parallel
        Task<string> downloadTask1 = DownloadDataAsync("Source 1", 2000);
        Task<string> downloadTask2 = DownloadDataAsync("Source 2", 3000);
        Task<string> downloadTask3 = DownloadDataAsync("Source 3", 1000);

        // Run all tasks in parallel and wait for all of them to complete
        string[] results = await Task.WhenAll(downloadTask1, downloadTask2, downloadTask3);

        // Process the results after all tasks are completed
        Console.WriteLine("All downloads completed. Processing data...");
        foreach (var result in results)
        {
            Console.WriteLine($"Processed: {result}");
        }

        Console.WriteLine("Task.WhenAll Demo Completed.");
    }

    // Asynchronous method to simulate data download
    private static async Task<string> DownloadDataAsync(string source, int delay)
    {
        Console.WriteLine($"Starting download from {source}...");
        await Task.Delay(delay); // Simulate network delay
        Console.WriteLine($"Download completed from {source}.");
        return $"Data from {source}";
    }
}
