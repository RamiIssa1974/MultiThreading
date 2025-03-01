using MultiThreadingDemo;

Console.WriteLine("Choose an example to run:");
Console.WriteLine("1 - Basic Threading Example");
Console.WriteLine("2 - Thread Synchronization Example");
Console.WriteLine("3 - Task Parallel Library Example");
Console.WriteLine("4 - Task Continuations Example");
Console.WriteLine("5 - Async/Await Example");
Console.WriteLine("6 - Task.WhenAll Example");
Console.WriteLine("7 - File Processing with Task.WhenAll");
Console.WriteLine("8 - Async Exception Handling Example");
Console.WriteLine("9 - Parallel.ForEachAsync Image Processing Example");
Console.WriteLine("10 - Cancellation Tokens Example");
Console.WriteLine("11 - Thread Safety Example with Lock");
Console.WriteLine("12 - Monitor Example with Conditional Wait");
Console.WriteLine("13 - Mutex Example for Single Instance Check");
Console.WriteLine("14 - Semaphore Example with Limited Access");
Console.WriteLine("15 - Concurrent Collections Example with ConcurrentDictionary");

Console.Write("Enter your choice: ");
string choice = Console.ReadLine();

switch (choice)
{
    case "1":
        Console.WriteLine("Running Basic Threading Example...");
        BasicThreadingExample.Run();
        break;

    case "2":
        Console.WriteLine("Running Thread Synchronization Example...");
        ThreadSynchronizationDemo.Run();
        break;
    case "3":
        Console.WriteLine("Running Task Parallel Library Example...");
        TaskParallelLibraryDemo.Run();
        break;
    case "4":
        Console.WriteLine("Running Task Continuations Example...");
        TaskContinuationsDemo.Run();
        break;
    case "5":
        Console.WriteLine("Running Async/Await Example...");
        await AsyncAwaitDemo.Run();
        break;
    case "6":
        Console.WriteLine("Running Task.WhenAll Example...");
        await TaskWhenAllDemo.Run();
        break;
    case "7":
        Console.WriteLine("Running File Processing with Task.WhenAll...");
        await FileProcessingWhenAllDemo.Run();
        break;
    case "8":
        Console.WriteLine("Running Async Exception Handling Example...");
        await AsyncExceptionHandlingDemo.Run();
        break;
    case "9":
        Console.WriteLine("Running Parallel.ForEachAsync Image Processing Example...");
        await ParallelForEachAsyncDemo.Run();
        break;
    case "10":
        Console.WriteLine("Running Cancellation Tokens Example...");
        await CancellationTokensDemo.Run();
        break;
    case "11":
        Console.WriteLine("Running Thread Safety Example with Lock...");
        await ThreadSafetyDemo.Run();
        break;
    case "12":
        Console.WriteLine("Running Monitor Example with Conditional Wait...");
        await MonitorDemo.Run();
        break;
    case "13":
        Console.WriteLine("Running Mutex Example for Single Instance Check...");
        MutexDemo.Run();
        break;
    case "14":
        Console.WriteLine("Running Semaphore Example with Limited Access...");
        await SemaphoreDemo.Run();
        break;        
    case "15":
        Console.WriteLine("Running Concurrent Collections Example with ConcurrentDictionary...");
        await ConcurrentCollectionsDemo.Run();
        break;

    default:
        Console.WriteLine("Invalid choice. Exiting...");
        break;
}

Console.ReadLine();