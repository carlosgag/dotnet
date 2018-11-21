using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Main
{
    public class Program
    {

        static void Main(string[] args)
        {
            Program p = new Program();
            //p.threads();
            SharingVars s = new SharingVars();
            s.doWork();
            Console.ReadLine();
        }

        public Task<string> GetHtmlAsync()
        {
            HttpClient client = new HttpClient();
            return client.GetStringAsync("http://www.dotnetfoundation.org");
        }

        public async Task<string> GetFirstCharactersCountAsync(int count)
        {
            string result = "";
            HttpClient client = new HttpClient();
            string page = await client.GetStringAsync("http://www.dotnetfoundation.org");
            if (count > page.Length)
            {
                result = page;
            }
            else
            {
                result = page.Substring(0, count);
            }
            Console.WriteLine(result);
            Console.ReadLine();
            return result;
        }

        public void threads()
        {
            ThreadStart job = new ThreadStart(ThreadJob);
            Thread thread = new Thread(job);
            thread.Start();
            for (int i = 0; i<5;i++)
            {
                Console.WriteLine("Main Thread: {0}", i);
                Thread.Sleep(1000);
            }
        }

        public void ThreadJob()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Other Thread: {0}", i);
                Thread.Sleep(500);
            }
        }
    }
}
