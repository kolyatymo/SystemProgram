internal class Program
{
    private static readonly object lockObj = new();
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter First Numb --> ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Second Numb --> ");
        int b = int.Parse(Console.ReadLine());

        string FileName = @"rest.txt";
        if(File.Exists(FileName))
        {
            File.Delete(FileName);
        }

        using var stream = File.AppendText(FileName);
        var res = Parallel.For(a, b+1, i => Multiplication(i,stream));

        Console.WriteLine(res);
    }

    static void Multiplication(int i, StreamWriter stream)
    {
        //for (int i = a; i <= b; i++)
        //{
            for (int j = 1; j <= 10; j++)
            {
                /*lock(lockObj)
                {
                    File.AppendAllText(filename, $"{i} * {j} = {i * j} \n");
                }*/
                
                stream.WriteLine($"{i} * {j} = {i * j}");

                Console.WriteLine($"{i} * {j} = {i * j}"); 
            }
            Console.WriteLine("............");
        //}
        //return a;
    }
}

