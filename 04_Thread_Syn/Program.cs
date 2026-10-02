
class Counter
{
    public static int count = 0;
}
internal class Program
{
    private static void Main(string[] args)
    {
        Thread[] threads = new Thread[5];
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(() =>
            {
                for (int j = 0; j < 1_000_000; j++)
                {
                    Interlocked.Increment(ref Counter.count); // перевірка щоб потоки встигали зберігати результат
                }
            });
            threads[i].Start();
        }

        for (int i = 0; i < threads.Length; i++)
        {
            threads[i].Join(); // коли потоки завершуть роботу тоді мейн завершить (main is waiting)
        }

        Console.WriteLine($"Counter = {Counter.count}");
    }
}