using System;
using System.Linq;

namespace _01_ConsoleApplication
{
    class Program
    {

        static void Main(string[] args)
        {


            Console.Write("Press enter for see SUM value 1 to n = 100");
            Console.Out.Flush();
            Console.ReadLine();

            Console.WriteLine(Sum(100));

            int i = 1;
            int e = 100;

            Console.Write("Press enter for ascending FOR LOOP order");
            Console.Out.Flush();
            Console.ReadLine();
        

            for (; i <= e; i++)
            {
                Console.WriteLine(i);
            }

            Console.Write("Press enter for descending FOR LOOP order");
            Console.Out.Flush();
            Console.ReadLine();
        

            i = 100;
            e = 1;
            for (; i >= e; i--)
            {
                Console.WriteLine(i);
            }

            Console.Write("Press enter for ascending WHILE LOOP order");
            Console.Out.Flush();
            Console.ReadLine();

            i = 1;
            e = 100;
            while (i <= e)
            {
                Console.WriteLine(i);
                i++;
            }

            Console.Write("Press enter for descending WHILE LOOP order");
            Console.Out.Flush();
            Console.ReadLine();

            i = 100;
            e = 1;
            while (i >= e)
            {
                Console.WriteLine(i);
                i--;
            }

            Console.Write("Press enter for ascending LINQ order");
            Console.Out.Flush();
            Console.ReadLine();

            i = 1;
            e = 100;

            var numbers = Enumerable.Range(i, e).ToList();
            numbers.ForEach(Console.WriteLine);

            Console.Write("Press enter for descending LINQ order");
            Console.Out.Flush();
            Console.ReadLine();

            numbers.OrderByDescending(i => i).ToList().ForEach(Console.WriteLine);

        }

        public static int Sum(int n)
        {
            var sum = 1;

            for (var i = 1; i <= n; i++)
            {
                sum += i;
            }

            return sum;

        }
       
    }
}
