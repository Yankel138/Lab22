using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab22
{
    class Program
    {
        static int[] array;
        static int n;
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива случайных целых чисел: ");
            n = Convert.ToInt32(Console.ReadLine());

            Task task1 = new Task(() => ArrayRandom(n));
            Task task2 = task1.ContinueWith(Sum);
            Task task3 = task1.ContinueWith(Maximum);

            task1.Start();
            task2.Wait();
            task3.Wait();
          
            Console.ReadKey();
        }

        static void ArrayRandom(int n) 
        {
            array = new int[n];
            Random random = new Random();
            Console.WriteLine("Элементы массива:");
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(-100, 100);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static void Sum (Task task)
        {
            int sum = 0;
            foreach (int i in array)
            {
                sum += i;
            }
            Console.WriteLine($"Сумма элементов массива: {sum}");
        }

        static void Maximum(Task task)
        {
            int max = array[0];
            for (int i = 1; i < n; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            Console.WriteLine($"Максимальный элемент массива: {max}");
        }
    }
}
