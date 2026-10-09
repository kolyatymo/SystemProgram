internal class Program
{
    static Random rnd = new Random();
    private static void Main(string[] args)
    {
        /*Task task1 = new Task(() => Console.WriteLine($"Task 1 is execute in Thread : {Thread.CurrentThread.ManagedThreadId}"));

        task1.Start();

        // start automatically
        Task task2 = Task.Factory.StartNew(() => Console.WriteLine($"Task 2 is execute in Thread : {Thread.CurrentThread.ManagedThreadId}"));

        // start automatically
        Task task3 = Task.Run(() => Console.WriteLine($"Task 3 is execute in Thread : {Thread.CurrentThread.ManagedThreadId}"));

        Console.ReadLine();
        Task task = new Task(Display);
        task.Start();
        task.Wait(); // waiting .... freeze заморозить доки таска не завершить роботу
        Console.WriteLine("Method main completion");*/
        #region task array

        /*Task[] tasks1 = new Task[3]
        {
            new Task(() => Console.WriteLine("First task")),
            new Task(() => Console.WriteLine("Second task")),
            new Task(() => Console.WriteLine("Third task"))
        };

        foreach (var t in tasks1)
        {
            t.Start();
        }
        Task.WaitAll(tasks1); // or tasks[0], tasks[1], task[2];
        Console.WriteLine("All task have done!");

        Task[] tasks2 = new Task[3];

        int j = 0;
        for (int i = 0; i < tasks2.Length; i++)
        {
            tasks2[i] = Task.Run(() =>
            {
                Thread.Sleep(rnd.Next(5000));
                Console.WriteLine($"Task {++j}");
            });
        }

        Task.WaitAny(tasks2); // waiting any one task was completed
        Console.WriteLine("Some Task has done!");

        Console.ReadLine();*/

        #endregion

        #region Continuous_Task

        /*Task task1 = new Task(() =>
        {
            Console.WriteLine($"Task Id (creating array) :: {Task.CurrentId}");
            Thread.Sleep(2000);
        });

        Task task2 = task1.ContinueWith(Display2);//.ContinueWith(Display3); // Task 1 виконується перша далі task 2
        //Task task2 = Task.Run(Display);
        task1.Start();

        task2.Wait();

        Console.WriteLine("Main is working");
        Console.ReadLine();*/



        #endregion

        #region Task Result

        // Factorial 
        /*Task<int> task1 = new Task<int>(() => Factorial(5));

        var task2 = task1.ContinueWith(Summ);

        task1.Start();
        task1.Wait(); 
        
        // task1.wait(); freeze
        Console.WriteLine($"Factorial number 5      :: {task1.Result}");
        Console.WriteLine($"Summ Factorial number 5 :: {task2.Result}");

        Task<Book> task3 = new Task<Book>(() =>
        {
            return new Book() { Title = "It", Author = "King"};
        });
        task3.Start();

        Book res = task3.Result;
        Console.WriteLine("New Book :: " + res);
        Console.WriteLine("Main end");*/



        #endregion

        #region Inner Task

        var outer = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("Outer task starting ....");

            var inner = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Inner task starting ...");
                Thread.Sleep(2000);
                Console.WriteLine("Inner task finished ... ");
            },TaskCreationOptions.AttachedToParent);
            //inner.Wait();
            Console.WriteLine("Outer task was finished.");
        });

        outer.Wait();
        Console.WriteLine("Main finished");

        #endregion

    }

    static void Display()
    {
        Console.WriteLine("Start work method Display");
        // ..............
        Console.WriteLine("End work method Display");
    }

    static void Display2(Task prevTask)
    {
        Console.WriteLine($"Task Id :: {Task.CurrentId}");
        Console.WriteLine($"Previous Task Id :: {prevTask.Id}");
        Thread.Sleep(3000);
    }
    static void Display3(Task prevTask)
    {
        Console.WriteLine($"Task Id :: {Task.CurrentId}");
        Console.WriteLine($"Previous Task Id :: {prevTask.Id}");
    }
    static int Factorial(int x)
    {
        int result = 1;

        for (int i = 1; i <= x; i++)
        {
            result *= i;
            //Thread.Sleep(1000);
        }
        return result;
    }

    static int Summ(Task<int> prevTask)
    {
        int summ = prevTask.Result * 2;
        Console.WriteLine(summ);
        return summ;
    }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public override string ToString()
    {
        return $"{Title} by {Author}";
    }
}