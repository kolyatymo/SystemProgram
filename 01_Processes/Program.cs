using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        /*Process current = Process.GetCurrentProcess(); // повертає поточний процес
        current.PriorityClass = ProcessPriorityClass.High;

        Console.WriteLine("----------- Current proccess info ---------");

        Console.WriteLine($" PriorityClass {current.PriorityClass}");
        Console.WriteLine($" ProccessName {current.ProcessName}");
        Console.WriteLine($" ID {current.Id}");
        Console.WriteLine($" MachineName {current.MachineName}");
        Console.WriteLine($" PrivateMemory {current.PriorityClass}");

        Console.ReadKey();*/

        /*Process[] processes = Process.GetProcesses();

        foreach (var p in processes)
        {
            try
            {
                Console.WriteLine($"{p.ProcessName}\t{p.Id}\t{p.PriorityClass}\t{p.StartTime}");
            }
            catch( Exception ex ) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error with {p.ProcessName} ({ex.Message})");
                Console.ResetColor();
            }
        }*/


        //Process.Start("mspaint.exe");

        //Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "stackoverflow.com github.com google.com");

        ProcessStartInfo Info = new ProcessStartInfo()
        {
            FileName = "notepad",
            Arguments = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\777.txt",
            WindowStyle = ProcessWindowStyle.Normal
        };

        Process pr = Process.Start(Info);
        Console.WriteLine("Press key to do operation .....");
        //Console.ReadKey();

        //pr.Close();
        //pr.Refresh();
        //pr.CloseMainWindow(); // alt + f4

        Thread.Sleep(2000); // затримка в мс


        pr.Kill();
        Console.WriteLine("Opeartion done .....");

        Console.ReadKey();
    }
}