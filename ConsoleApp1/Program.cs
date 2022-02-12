using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static volatile int num = 0;

        // Initialized set to ensure that the producer goes first.
        static EventWaitHandle consumed1 = new AutoResetEvent(true);
        static EventWaitHandle consumed2 = new AutoResetEvent(false);
        static EventWaitHandle consumed3 = new AutoResetEvent(false);

        // Initialized not set to ensure consumer waits until first producer run.
        static EventWaitHandle produced = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            new Thread(Consumer3).Start();
            new Thread(Consumer2).Start();
            new Thread(Consumer1).Start();
            new Thread(Producer).Start();

            Console.ReadKey();
        }

        static void Producer()
        {
            while (num < 20)
            {
                consumed1.WaitOne();
                //num++;
                Console.WriteLine("Produced   " + num);
                //Thread.Sleep(100);
                produced.Set();
            }
        }

        static void Consumer1()
        {
            while (num < 20)
            {
                produced.WaitOne();
                //consumed1.WaitOne();

                Console.WriteLine("Consumed 1 " + num);
                //Thread.Sleep(200);
                //num--;

                //consumed2.Set();
                consumed2.Set();
            }
        }
        
        static void Consumer2()
        {
            while (num < 20)
            {
                //produced.WaitOne();
                consumed2.WaitOne();
                //consumed3.WaitOne();
                //num++;
                Console.WriteLine("Consumed 2 " + num);
                //Thread.Sleep(200);
                //num--;
                //consumed3.Set();
                consumed3.Set();
            }
        }

        static void Consumer3()
        {
            while (num < 20 + 1)
            {
                //produced.WaitOne();
                consumed3.WaitOne();
                Console.WriteLine("Consumed 3 " + num);
                num++;
                //Thread.Sleep(200);
                //num--;
                consumed1.Set();
            }
        }
    }
}
