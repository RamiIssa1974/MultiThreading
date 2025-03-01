using System;
using System.Threading;
using System.Threading.Tasks;

public class TaskContinuationsDemo
{
    public static void Run()
    {
        Console.WriteLine("Starting Task Continuations Demo...");

        // Task ראשון - הורדת נתונים (מדומה)
        Task<string> downloadTask = Task.Run(() =>
        {
            Console.WriteLine("Downloading data...");
            Thread.Sleep(2000); // לדמות זמן הורדה
            return "Data from the internet";
        });

        // ContinueWith - עיבוד הנתונים לאחר שההורדה הסתיימה
        Task processTask = downloadTask.ContinueWith((previousTask) =>
        {
            Console.WriteLine($"Processing data: {previousTask.Result}");
            Thread.Sleep(1000); // לדמות עיבוד
            Console.WriteLine("Data processed.");
        });

        // מחכים לכל המשימות לסיים
        processTask.Wait();

        Console.WriteLine("Task Continuations Demo Completed.");
    }
}
