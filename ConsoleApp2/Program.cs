using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 12. Дана последовательность натуральных чисел {a0…an–1}. Создать
многопоточное приложение для поиска суммы ∑ai, где ai – четные числа 
*/
namespace ConsoleApp2
{
    class Program
    {
        static int sum = 0; // cумма чисел
        static int n = 8; // количество элементов последовательности
        static int a = 0; // хранит значение а[n]
        static int b = 3; // a+b=a[n+1] т.е. на какое число увеличивается или уменьшается последовательность

        static Barrier barrier = new Barrier(2, (b) =>
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.Append(" ");
            }

        });

        static void Main(string[] args)
        {
            // создаем новый поток
            Thread myThread = new Thread(new ThreadStart(Count));
            myThread.Start(); // запускаем поток

            for (int i = 0; i < n; i++)
            {
                a += b;
                if (a % 2 == 0)
                {
                    Console.WriteLine("Главный поток:");
                    Console.WriteLine(sum + a);
                    // Thread.Sleep(200);
                    barrier.SignalAndWait();
                }
            }
            Console.ReadLine();
        }

        public static void Count()
        {
            for (int i = 0; i < n; i++)
            {
                a += b;
                if (a % 2 == 0)
                {
                    Console.WriteLine("Второй поток:");
                    Console.WriteLine(sum + a);
                    // Thread.Sleep(200);
                    barrier.SignalAndWait();
                }
            }
        }
    }
}
