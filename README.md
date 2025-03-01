# MultiThreading
1. **Understanding Threads** – What they are and why they are useful.
2. **Creating and Managing Threads in C#**.
3. **Thread Synchronization** – Handling shared resources safely.
4. **Task Parallel Library (TPL)** – Modern way to handle multithreading.
5. **Async/Await** – Writing efficient asynchronous code.

**Thread Synchronization**
When working with multiple threads, you might face issues with:

-**Race Conditions** – When two or more threads access shared data at the same time.
-**Data Inconsistency** – When threads modify shared data simultaneously.

-**lock** keyword: To ensure that only one thread accesses a piece of code at a time.
-**Monitor** class: An advanced way to handle locking and waiting.

**Task Parallel Library (TPL)**
The Task Parallel Library (TPL) is a modern way to manage concurrency and parallelism in C#. It is:

-**Easier to use** than manually creating and managing threads.
-**More efficient** because it automatically manages thread pooling.
-**More flexible**, supporting asynchronous programming with async and await.

**await Task.WhenAll()**
**Task.WhenAny()**
**AggregateException**
**Parallel.ForEachAsync()**
**Cancellation Tokens**
**Thread Safety and Data Integrity**
-**Locking Mechanisms**:*lock,Monitor,Mutex,Semaphore*
-**Thread-safe Collections:** *ConcurrentDictionary, ConcurrentQueue, ConcurrentBag*
-**Immutable Data**

