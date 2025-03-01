using System;
using System.Threading;
using System.Threading.Tasks;

public class MonitorDemo
{
    private static int balance = 1000; // Shared resource
    private static readonly object lockObject = new object(); // Lock object

    public static async Task Run()
    {
        Console.WriteLine("Starting Monitor Demo...");

        // Create multiple tasks to simulate multiple withdrawals
        Task[] tasks = new Task[5];
        for (int i = 0; i < tasks.Length; i++)
        {
            int amount = (i + 1) * 200; // Withdrawal amount
            tasks[i] = Task.Run(() => Withdraw(amount));
        }

        // Simulate deposits to satisfy the withdrawals
        await Task.Delay(2000);
        Task.Run(() => Deposit(500));

        await Task.WhenAll(tasks);

        Console.WriteLine($"Final Balance: {balance}");
        Console.WriteLine("Monitor Demo Completed.");
    }

    // Withdraw money from the account
    private static void Withdraw(int amount)
    {
        // Try to acquire the lock
        Monitor.Enter(lockObject);
        try
        {
            Console.WriteLine($"Attempting to withdraw {amount} on Thread {Thread.CurrentThread.ManagedThreadId}");

            // Wait until there are sufficient funds
            while (balance < amount)
            {
                Console.WriteLine($"Insufficient funds for {amount}. Waiting...");
                Monitor.Wait(lockObject); // Wait for a signal
            }

            // Proceed with the withdrawal
            balance -= amount;
            Console.WriteLine($"Withdrawal of {amount} successful. New Balance: {balance}");
        }
        finally
        {
            Monitor.Exit(lockObject); // Always release the lock
        }
    }

    // Deposit money into the account
    private static void Deposit(int amount)
    {
        // Acquire the lock
        Monitor.Enter(lockObject);
        try
        {
            Console.WriteLine($"Depositing {amount} on Thread {Thread.CurrentThread.ManagedThreadId}");
            balance += amount;
            Console.WriteLine($"Deposit of {amount} successful. New Balance: {balance}");

            // Signal waiting threads that funds are available
            Monitor.PulseAll(lockObject); // Notify all waiting threads
        }
        finally
        {
            Monitor.Exit(lockObject); // Always release the lock
        }
    }
}
