using System;
using System.Threading.Tasks;

public class AsyncAwaitDemo
{
    public static async Task Run()
    {
        Console.WriteLine("Starting Async/Await Demo...");

        // Call the asynchronous method
        string data = await DownloadDataAsync();

        // Continue processing after data is downloaded
        Console.WriteLine($"Data received: {data}");
        Console.WriteLine("Processing data...");
        await Task.Delay(1000); // Simulate data processing
        Console.WriteLine("Data processed.");

        Console.WriteLine("Async/Await Demo Completed.");
    }

    // Asynchronous method to simulate data download
    private static async Task<string> DownloadDataAsync()
    {
        Console.WriteLine("Starting data download...");
        await Task.Delay(2000); // Simulate network delay
        Console.WriteLine("Data download completed.");
        return "Sample data from async method";
    }
}
