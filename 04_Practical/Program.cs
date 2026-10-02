using System.Xml.Linq;

internal class Program
{
    class WriteFileThread
    {
        int words = 0;
        int rows = 0;
        int punctuation = 0;

        public int Words { get => words; }
        public int Rows { get => rows; }
        public int Punctuation { get => punctuation; }

        public WriteFileThread() { }

        public void WriteThread(string File_name)
        {
            lock (this)
            {
                var lines = File.ReadAllLines(File_name);

                rows += lines.Length;

                char[] punct = { ',', '.', '?', ':', ';', '!' };

                foreach (var line in lines)
                {
                    string[] newlinew = line.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);

                    words += newlinew.Length;

                    foreach (var item in line)
                    {
                        foreach (var item1 in punct)
                        {
                            if (item == item1)
                            {
                                punctuation++;
                            }
                        }
                    }
                }
            }
        }

        public void UpdateFile(string File_name)
        {
            lock(this)
            {
                WriteThread(File_name);
            }
        }
    }
    private static void Main(string[] args)
    {

        string[] strings = new string[] { "Text1.txt", "Text2.txt", "Text3.txt" };


        WriteFileThread w = new WriteFileThread();
        Thread[] threads = new Thread[3];
        for (int i = 0; i < threads.Length; i++)
        {
            int index = i;
            threads[i] = new Thread(() => w.UpdateFile(strings[index]));
            threads[i].Start();
        }

        for (int i = 0; i < threads.Length; i++)
        {
            threads[i].Join();
        }
        Console.WriteLine("---------Save all Items -----------");
        for (int i = 0; i < strings.Length; i++)
        {
            Console.WriteLine($"Files Name --> {strings[i]}");
        }
        Console.WriteLine($"Rows --> {w.Rows}, \tWords --> {w.Words}, \tPunct --> {w.Punctuation}");
        Console.WriteLine();
        
    }
}