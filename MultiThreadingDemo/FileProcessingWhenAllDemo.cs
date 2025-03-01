using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class FileProcessingWhenAllDemo
{
    public static async Task Run()
    {
        Console.WriteLine("Starting File Processing with Task.WhenAll...");

        // Get all text files from the Data folder
        string dataDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string[] files = Directory.GetFiles(dataDirectory, "*.txt");

        // Create a Task for each file to count words in parallel
        Task<int>[] wordCountTasks = files.Select(file => CountWordsAsync(file)).ToArray();

        // Run all tasks in parallel and wait for all of them to complete
        int[] wordCounts = await Task.WhenAll(wordCountTasks);

        // Sum up all the word counts
        int totalWordCount = wordCounts.Sum();

        Console.WriteLine("All files processed.");
        Console.WriteLine($"Total Word Count: {totalWordCount}");
    }

    // Asynchronous method to count words in a file
    private static async Task<int> CountWordsAsync(string filePath)
    {
        Console.WriteLine($"Processing file: {Path.GetFileName(filePath)} on Thread {System.Threading.Thread.CurrentThread.ManagedThreadId}");
        string text = await File.ReadAllTextAsync(filePath);

        // Simulate heavy computation (e.g., text analysis)
        await Task.Delay(1000);

        int wordCount = text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
        Console.WriteLine($"File: {Path.GetFileName(filePath)}, Word Count: {wordCount}");

        return wordCount;
    }
}
