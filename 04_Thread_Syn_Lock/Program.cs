
class LockCounter
{
    int number = 0;
    int eventNumbre = 0;
    public int Number { get => number; }
    public int EvenNumber { get => eventNumbre; }

    public void UpdateFields()
    {
        for (int i = 0; i < 1_000_000; i++)
        {
            /*Interlocked.Increment(ref number);
            if(number % 2 == 0)
            {
                Interlocked.Increment(ref eventNumbre);
            }*/

            lock(this)
            {
                ++number;
                if (number % 2 == 0)
                    ++eventNumbre;
            }

            /*Monitor.Enter(this);
            try
            {
                ++number;
                if (number % 2 == 0)
                    ++eventNumbre;
            }
            finally
            {
                Monitor.Exit(this);
            }  --> оператор (lock)    */
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        LockCounter c = new LockCounter();
        Thread[] threads = new Thread[5];
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(c.UpdateFields);
            threads[i].Start();
        }
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i].Join();
        }
        Console.WriteLine($"NUmber :: {c.Number} \t Event number :: {c.EvenNumber}"); // 5_000_000 , 2_500_000
    }
}