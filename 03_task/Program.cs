using _03_task;

internal class Program
{
    private static void Main(string[] args)
    {
        FibonacciCounter counter = new FibonacciCounter();

        counter.Go();

        Console.ReadLine();

    }
}