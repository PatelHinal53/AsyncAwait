using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            high();
            simple();

            MyTask myTask = new MyTask();
            myTask.high().Wait();

            Console.ReadKey();

        }

        private static async void high()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(5000);
                    Console.WriteLine("\n Method do high");

                    Task.Delay(1000).Wait();
                }

            });
        }

        private static void simple()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(5000);
                Console.WriteLine("\n Method do simple");

                Task.Delay(1000).Wait();
            }
        }

        class MyTask
        {
            public async Task high()
            {
                int a = await doSomethingAsync(5);
                return;
            }
            private async Task<int> doSomethingAsync(int v)
            {
                return await Task.Run(() =>
                {

                    Thread.Sleep(1000);
                    Console.WriteLine("\n doSomethingAsync");
                    Console.Write("\n " + (v * 2));
                    return v * 2;

                });
            }
        }
    }
}
