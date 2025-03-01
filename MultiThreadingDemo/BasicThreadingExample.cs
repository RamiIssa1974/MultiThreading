using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingDemo
{
    public class BasicThreadingExample
    {
        public static void Run()
        {
            Console.WriteLine("Main Thread Started");

            // Create a new thread
            Thread thread = new Thread(PrintNumbers);
            thread.Start();

            // Continue execution on the main thread
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Main Thread: {i}");
                Thread.Sleep(500);
            }

            thread.Join(); // Wait for the other thread to finish

            Console.WriteLine("Main Thread Ended");
        }

        // Method to run on the new thread
        private static void PrintNumbers()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Worker Thread: {i}");
                Thread.Sleep(1000); // Simulate some work
            }
        }
    }
}
