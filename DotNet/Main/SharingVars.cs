using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Main
{
    public class SharingVars
    {
        private string _threadOutput = "";
        private bool _stopThreads = false;

        private void DisplayThread1()
        {
            while (_stopThreads == false)
            {
                Console.WriteLine("Display Thread 1");
                _threadOutput = "Hello Thread 1";
                Thread.Sleep(1000);
                Console.WriteLine("Thread 1 output --> {0}", _threadOutput);
            }
        }

        private void DisplayThread2()
        {
            while (_stopThreads == false)
            {
                Console.WriteLine("Display Thread 2");
                _threadOutput = "Hello Thread 2";
                Thread.Sleep(1000);
                Console.WriteLine("Thread 2 output --> {0}", _threadOutput);
            }
        }

        public void doWork()
        {
            Thread thread1 = new Thread(new ThreadStart(DisplayThread1));
            Thread thread2 = new Thread(new ThreadStart(DisplayThread2));

            thread1.Start();
            thread2.Start();
        }
    }
}
