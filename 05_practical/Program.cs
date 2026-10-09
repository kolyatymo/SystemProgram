using System.Threading.Tasks;


class MyArrayClass
{
    public int Max { get; set; }
    public int Min { get; set; }
    public int AVG { get; set; }
    public int Summ { get; set; }
    static int[] MyArray()
    {
        Random rnd = new Random();

        int size = rnd.Next(20, 100);

        int[] array = new int[size];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rnd.Next(2, 100);
            Console.WriteLine(i);
        }
        return array;
    }

    public void Maxx(int[] arr)
    {
        Max = arr[0];

        for (int i = 0; i < arr.Length; i++)
        {
            if (Max < arr[i])
                Max = arr[i];
        }
    }
    public void Minn(int[] arr)
    {
        Min = arr[0];

        for (int i = 0; i < arr.Length; i++)
        {
            if (Min > arr[i])
                Min = arr[i];
        }
    }
    
    public void SUmm(int[] arr)
    {
        Summ = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            Summ += arr[i];
        }
    }
    

    internal class Program
    {
        static void TimeNow()
        {
            Console.WriteLine(DateTime.Now);
        }

        static void PrimeNumb()
        {
            for (int i = 2; i < 1000; i++)
            {
                bool IsGood = true;

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        IsGood = false;
                        break;
                    }
                }
                if (IsGood)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void PrimeNumb(int First, int Last)
        {
            for (int i = First; i < Last; i++)
            {
                bool IsGood = true;

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        IsGood = false;
                        break;
                    }
                }
                if (IsGood)
                {
                    Console.WriteLine(i);
                }
            }
        }


        private static void Main(string[] args)
        {
            #region task 1

            /*Task task1 = new Task(TimeNow);
            task1.Start();

            Task task2 = Task.Run(TimeNow);

            Task task3 = Task.Factory.StartNew(TimeNow);

            Console.ReadLine();
            Console.WriteLine("main end");*/

            #endregion

            #region task 2

            /*Task task = Task.Run(PrimeNumb);
            task.Wait();

            Console.ReadLine();
            Console.WriteLine("Main end");*/

            #endregion

            #region task 3

            /*Console.WriteLine($"Enter First Number --> ");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine($"Enter Second Number --> ");
            int b = int.Parse(Console.ReadLine());

            Task task = Task.Run(() => PrimeNumb(a,b));
            task.Wait();

            Console.ReadLine();
            Console.WriteLine("Main end");*/


            #endregion

            #region task 4

            MyArrayClass arr = new MyArrayClass();

            Task[] tasks = new Task[4]
            {
            new Task(() => Console.WriteLine($"Max     --> {arr.Max}")),
            new Task(() => Console.WriteLine($"Min     --> {arr.Min}")),
            new Task(() => Console.WriteLine($"Sum     --> {arr.Summ}")),
            new Task(() => Console.WriteLine($"Average --> {arr.Summ / 2}"))
            };

            foreach (var t in tasks)
            {
                t.Start();
            }

            Task.WaitAll(tasks);

            Console.ReadLine();
            Console.WriteLine("Main end");
            #endregion
        }
    }
}