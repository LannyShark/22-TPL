using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(-100, 100);
            }
            foreach (int a in array)
            {
                Console.Write($"{a} ");
            }
            Console.WriteLine();
            Action<object> action1 = new Action<object>(Sum);
            Task task1 = new Task(action1, array);
            task1.Start();
            Action<Task, object> action2 = new Action<Task, object>(Max);
            Task task2 = task1.ContinueWith(action2, array);
            Console.ReadKey();
        }
        static void Sum(object arr)
        {
            int[] array = (int[])arr;
            int sum = 0;
            foreach (int a in array)
            {
                sum += a;
            }
            Console.WriteLine(sum);
        }
        static void Max(Task task, object arr)
        {
            int[] array = (int[])arr;
            int max = array[0];
            foreach (int a in array)
            {
                if (a > max) max = a;
            }
            Console.WriteLine(max);
        }
    }
}
