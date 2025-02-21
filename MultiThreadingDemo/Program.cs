// See https://aka.ms/new-console-template for more information
Console.WriteLine("Main Thread Started");
Thread thread = new Thread(PrintNumbers);
thread.Start();

for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"Main Thread: {i}");
    Thread.Sleep(500);
}

Console.WriteLine("Main Thread Ended");
//Console.ReadLine();
void PrintNumbers()
{
    for (int i = 1; i <= 5; i++)
    {
        Console.WriteLine($"Worker Thread: {i}");
        Thread.Sleep(1000); // Simulate some work
    }
}
