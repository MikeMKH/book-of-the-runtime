using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"0th={Fib(0)}");
            Console.WriteLine($"1th={Fib(1)}");
            Console.WriteLine($"2th={Fib(2)}");
            Console.WriteLine($"3th={Fib(3)}");
            Console.WriteLine($"4th={Fib(4)}");
            Console.WriteLine($"5th={Fib(5)}");
            Console.WriteLine($"...");
            Console.WriteLine($"20th={Fib(20)}");
        }

        static int Fib(int n)
        {
            if (n == 0) return 0;

            var previous = 0;
            var current  = 1;
            for(int i = 0; i < n; i++)
            {
                var old = current;
                current += previous;
                previous = old;
            }
            return current;
        }
    }
}
