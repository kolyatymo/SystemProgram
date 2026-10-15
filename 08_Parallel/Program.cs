internal class Program
{
    static Random rnd = new Random();
    public class Author
    {
        public string Name { get; set; }

        public int[] Rating;
        public Author(string name = "no name")
        {
            Name = name;
            Rating = new int[5]
            {
                rnd.Next(6),
                rnd.Next(6),
                rnd.Next(6),
                rnd.Next(6),
                rnd.Next(6)
            };
        }
    }
    static void AverageRating(Author author)
    {
        var avg = author.Rating.Average();
        Thread.Sleep(3000);
        Console.WriteLine($"Author {author.Name} average rating = {avg}");
    }
    private static void Main(string[] args)
    {
        /*Parallel.Invoke(
            Void, 
            () =>
            {
                Console.WriteLine($"Task executing {Task.CurrentId}");
                Thread.Sleep(3000);
                Console.WriteLine($"Task ended {Task.CurrentId}");
            },
            () => Factorial(5)
            );
        Console.ReadLine();*/

        Console.WriteLine($"Started");
        //1
        /*for (int i = 0; i < 20; i++)
        {
            Factorial(i);
        }*/

        // 2
        /*for (int i = 0; i < 20; i++)
        {
            int n = i;
            Task.Run(() => Factorial(n));
        }*/

        // 3
        //Parallel.For(1, 20, Factorial); // [1 ... 19]


        /*var list = new List<int>() { 1, 3, 5, 7 };
        Parallel.ForEach(list, Factorial);*/


        /*List<Author> authors = new List<Author>()
         {
             new Author("King"),
             new Author("author 2"),
             new Author("author 3"),
             new Author("author 4"),
             new Author("author 5"),
             new Author("author 6"),
             new Author("author 7"),
             new Author("author 8"),
             new Author("author 9"),
             new Author("author 10")
         };
         Parallel.ForEach(authors, AverageRating);*/

        /*var result = Parallel.For(1, 10, Factorial);
        if (!result.IsCompleted)
            Console.WriteLine($"Run cycles stop from iteration {result.LowestBreakIteration}");

        else
            Console.WriteLine("All iteration eded");

        Console.ReadLine(); */


        /*CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        CancellationToken token = cancellationTokenSource.Token;
        Task task1 = Task.Run(() =>
        {
            int res = 1;
            for (int i = 1; i <= 6; i++)
            {
                if(token.IsCancellationRequested)
                {
                    Console.WriteLine("Endede operation");
                    return;
                }

                res *= i;
                Console.WriteLine($"{i}! == {res}");
                Thread.Sleep(2000);
            }
        });

        var key = Console.ReadKey();
        if (key.Key == ConsoleKey.Escape)
        {
            cancellationTokenSource.Cancel();
        }*/

        // PLINQ

        int[] numb = new int[] { 1, 3, 4, -5, 6, 8, -7, 9, 5 };
        /*var factors = from n in numb.AsParallel()
                      where n > 0
                      orderby n
                      select Factorial(n);*/

        var factors = numb.AsParallel()
            .AsOrdered()                        
            .Where(n => n > 0)
            .Select(n => Factorial(n));

        foreach (var item in factors)
        {
            Console.WriteLine(item);
        }
        Console.ReadLine();

    }
    static void Void()
    {
        Console.WriteLine($"Task executing {Task.CurrentId}");
        Thread.Sleep(3000);
        Console.WriteLine($"Task ended {Task.CurrentId}");
    }

    static int Factorial(int x) // , ParallelLoopState pls
    {
        int result = 1;
        for (int i = 1; i < x; i++)
        {
            result *= i;
            /*if(i == 5)
                pls.Break();*/
        }
        Console.WriteLine($"Task executing {Task.CurrentId}");
        Thread.Sleep(3000);
        Console.WriteLine($"Result :: {x}! = {result}");
        Console.WriteLine($"Task ended {Task.CurrentId}");
        return result;
    }
}