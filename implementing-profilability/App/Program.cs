using System;
using System.Collections.Generic;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 12; i++) PrintFib(i);
            Console.WriteLine("...");
            PrintFib(20);
            for(int i = 21; i < 28; i++) PrintFib(i);
        }
        
        static void PrintFib(int n) => Console.WriteLine($"{n}={GCFib(n)}");
        
        static Dictionary<int, int> cache = new Dictionary<int, int>();
        static int GCFib(int n)
        {
            if (cache.ContainsKey(n-2) && cache.ContainsKey(n-1))
            {
                Console.Write("[cache]");
                var result = cache[n-2] + cache[n-1];
                cache.Add(n, result);
                return result;   
            }
            
            var previous = 0;
            var current = 1;
            for(var i = 0; i < n; i++)
            {
                var temp = current;
                current += previous;
                previous = temp;
                System.GC.Collect(2);  // to see what it looks like in the debugger
            }
            cache.Add(n, previous);
            return previous;
        }
    }
}
