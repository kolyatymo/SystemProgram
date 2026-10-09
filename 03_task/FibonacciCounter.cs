using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _03_task
{
    internal class FibonacciCounter
    {
        public int N1 { get; set; }
        public int N2 { get; set; }
        public int EvenCount { get; set; }

        private void Fibonacci()
        {
            N1 = 0;
            N2 = 1;
            for (int i = 0; i < 10; i++)
            {
                lock(this)
                {
                    int n = N1 + N2;
                    N1 = N2;
                    N2 = n;
                }
                
                Thread.Sleep(1000);
            }
        }

        private void CountEven()
        {
            for (int i = 0; i < 10; i++)
            {
                lock (this)
                {
                    if (N1 % 2 == 0)
                    {
                        EvenCount++;
                    }
                    else if (N2 % 2 == 0)
                    {
                        EvenCount++;
                    }
                }
                Thread.Sleep(1000);
            }
        }

        public void print()
        {
            Console.WriteLine($"{"iteration",-10} {"n1",-5} {"n2",-5} {"evenCount"}");

            for (int i = 0; i < 10; i++)
            {
                lock (this)
                {
                    Console.WriteLine($"{i + 1,-10} {N1,-5} {N2,-5} {EvenCount}");
                }

                Thread.Sleep(1000);
            }
        }

        public void Go()
        {
            Thread[] threads = new Thread[3];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[0] = new Thread(Fibonacci);
                threads[1] = new Thread(CountEven);
                threads[2] = new Thread(print);
            }
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
            }
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }






            /*Thread thread1 = new Thread(Fibonacci);
            Thread thread2 = new Thread(CountEven);
            Thread thread3 = new Thread(print);

            thread1.Start();
            thread2.Start();
            thread3.Start();*/

            /*thread1.Join();
            thread2.Join();
            thread3.Join();*/
        }

        /*private void Fibonacci()
        {
            N1 = 0;
            N2 = 1;
            Console.WriteLine($"{"iteration", -5} {"n1", -5} {"n2", -5} {"evenCount"}");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i + 1, -9} {N1, -5} {N2, -5} {EvenCount}");
                int n = N1 + N2;
                N1 = N2;
                N2 = n;
                if(N1 % 2 == 0)
                {
                    EvenCount++;
                }
                else if(N2 % 2 == 0)
                {
                    EvenCount++;
                }
                Thread.Sleep(50);
            }
        }*/

    }

}
