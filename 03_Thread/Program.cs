using System.Threading;

internal class Program
{
    #region Thread_without params
    /*static void Method()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine($"\t\t\t {i} - Hello in thread");
            Thread.Sleep(50);
        }
    }
    private static void Main(string[] args)
    {
        //ThreadStart threadStart = new ThreadStart(Method); // створення делегату -- 1
        //ThreadStart threadStart = Method; -- 2
        // передати ctor -- 3
        ParameterizedThreadStart 
        
        Thread thread = new Thread(Method); // потік повязаний з методом
        thread.Start(); // псевдо паралельний код

        //Method();

        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(i + " - Hello in many");
            Thread.Sleep(50); // затримка на 50 мл
        }
    }*/
    #endregion

    #region Thread_with_params
    static void ThreadFunk(object a)
    {
        string ID = (string)a;
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(ID + " " + i);
            Thread.Sleep(100);
        }
    }

    static void ThreadFunkNumber(object a)
    {

        for (int i = ((Tuple<int, int>)a).Item1; i < ((Tuple<int, int>)a).Item2; i++)
        {
            Console.WriteLine(i);
            Thread.Sleep(100);
        }
    }
    private static void Main(string[] args)
    {
        ParameterizedThreadStart threadStart = new ParameterizedThreadStart(ThreadFunk);
        //Thread thread = new Thread(threadStart);
        Thread thread1 = new Thread(ThreadFunk);
        thread1.Start("One");

        Thread thread2 = new Thread(ThreadFunk);
        thread2.Priority = ThreadPriority.Highest;
        thread2.Start("\t\tTwo");

        Thread thread3 = new Thread(ThreadFunkNumber);
        thread3.Start(new Tuple<int, int>(1, 2));

        Console.ReadKey();
        Console.WriteLine("End");

    }
    #endregion

    #region Thread_in_background
    /*static void Method()
    {
        Thread thisThread = Thread.CurrentThread;
        Console.WriteLine( "ID of backgroung thread : " + thisThread.GetHashCode());
        for (int i = 0; i < 50; i++)
        {
            Console.WriteLine("\t\t\t Hello in Thread " + i);
            Thread.Sleep(100);
        }
    }
    private static void Main(string[] args)
    {
        Thread thread = new Thread(Method);
        thread.IsBackground = true; // фоновий потік - залежить від батківського потоку
        thread.Start();

        Console.WriteLine("ID of primary thread " + Thread.CurrentThread.GetHashCode());
        Console.ReadKey();
        Console.WriteLine("Main end");

        //thread.Suspend(); // призупинення виконання потоку (застарілий)
        //thread.Resume(); // відновлення
        //thread.Abort(); // примусово зупинити }*/
    #endregion

    #region

    /*static void Method()
    {
        Console.WriteLine("Thread is working .....");
        Thread.Sleep(3000);
        Console.WriteLine("Thread wad ended .....");
    }
    private static void Main(string[] args)
    {
        Thread thread = new Thread(Method);
        Console.WriteLine("Thread is going to start ....");
        thread.Start();
        Thread.Sleep(200);
        thread.Join(); // wait - затримка потоку
        Console.WriteLine("Waiting for thread ending ....");

        Console.WriteLine("Program was ended.");

        
        }*/
        #endregion
    }
