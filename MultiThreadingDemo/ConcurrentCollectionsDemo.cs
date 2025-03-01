using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

public class ConcurrentCollectionsDemo
{
    // ConcurrentDictionary to store word counts
    private static ConcurrentDictionary<string, int> wordCounts = new ConcurrentDictionary<string, int>();

    public static async Task Run()
    {
        Console.WriteLine("Starting Concurrent Collections Demo...");

        // Simulated web pages
        string[] webPages = new string[]
        {
            "Hello world world concurrency",
            "Concurrency in C# is powerful",
            "ConcurrentDictionary is thread-safe",
            "Hello from another world of threads",
            "Hello world of concurrent programming"
        };

        // Process each web page in parallel
        Task[] tasks = new Task[webPages.Length];
        for (int i = 0; i < webPages.Length; i++)
        {
            string content = webPages[i];
            tasks[i] = Task.Run(() => CountWords(content));
        }

        await Task.WhenAll(tasks);

        // Display word counts
        Console.WriteLine("Word Counts:");
        foreach (var kvp in wordCounts)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }

        Console.WriteLine("Concurrent Collections Demo Completed.");
    }

    // Count words in the given content and update the dictionary
    private static void CountWords(string content)
    {
        Console.WriteLine($"Processing: {content} on Thread {System.Threading.Thread.CurrentThread.ManagedThreadId}");

        string[] words = content.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            // Convert word to lower case for case-insensitive counting
            string lowerWord = word.ToLower();

            // Increment the word count in a thread-safe manner
            wordCounts.AddOrUpdate(
                lowerWord,      // Key
                1,              // Value if the key doesn't exist
                (key, oldValue) => oldValue + 1 // Increment if the key exists
            );
        }
    }
}
