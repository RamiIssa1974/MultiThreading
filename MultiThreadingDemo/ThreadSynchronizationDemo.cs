using System;
using System.Threading;

public class ThreadSynchronizationDemo
{
    public static void Run()
    {
        BankAccount account = new BankAccount(1000);

        // Create multiple threads that access the same account
        Thread t1 = new Thread(() => PerformTransactions("Thread 1", account));
        Thread t2 = new Thread(() => PerformTransactions("Thread 2", account));

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine($"Final Balance: {account.Balance}");
    }

    // Method to simulate transactions
    private static void PerformTransactions(string threadName, BankAccount account)
    {
        for (int i = 0; i < 5; i++)
        {
            account.Deposit(100, threadName);
            account.Withdraw(50, threadName);
        }
    }
}

// BankAccount Class
public class BankAccount
{
    private readonly object _lock = new object();
    public int Balance { get; private set; }

    public BankAccount(int initialBalance)
    {
        Balance = initialBalance;
    }

    public void Deposit(int amount, string threadName)
    {
        lock (_lock)
        {
            Console.WriteLine($"{threadName} - Depositing: {amount}");
            Balance += amount;
            Console.WriteLine($"{threadName} - Balance After Deposit: {Balance}");
        }
    }

    public void Withdraw(int amount, string threadName)
    {
        lock (_lock)
        {
            if (Balance >= amount)
            {
                Console.WriteLine($"{threadName} - Withdrawing: {amount}");
                Balance -= amount;
                Console.WriteLine($"{threadName} - Balance After Withdrawal: {Balance}");
            }
            else
            {
                Console.WriteLine($"{threadName} - Withdrawal Failed: Insufficient Funds");
            }
        }
    }
}
