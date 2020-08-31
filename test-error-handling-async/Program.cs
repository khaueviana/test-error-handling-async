using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace test_error_handling_async
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            int count = 1;
            var tasks = new List<Task>();

            for (int i = 0; i < 20; i++)
            {
                tasks.Add(RunTask(count));

                count++;
            }

            try
            {
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        private static async Task<Task> RunTask(int count)
        {
            if (count == 5 || count == 15)
            {
                Console.WriteLine($"Before - Exception Count {count}");

                throw new Exception($"Exception Count {count}");
            }

            Console.WriteLine($"Delay Count: {count}");

            await Task.Delay(TimeSpan.FromSeconds(1));

            return Task.CompletedTask;
        }

//        public static class Program
//        {
//            private static async Task Main(string[] args)
//            {
//            //var x = ReturnTask();
//​
//            // await ReturnTask();
//​
//            ReturnTask().GetAwaiter().GetResult();
//​
//            Console.WriteLine("Teste");
//            }
//​
//        private static async Task ReturnTask()
//            {
//                await Task.Delay(5000);
//​
//            throw new Exception("error");
//​
//            // await Error();
//        }
//​
//        private static Task Error()
//            {
//                throw new Exception("ERRO!");
//            }
//        }
    }
}