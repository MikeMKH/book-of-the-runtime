using System;
using System.Diagnostics;

namespace App
{
    class Program
    {
        static void ThrowExceptionOnEvens(int[] values)
        {
            foreach(var value in values)
            {
                try
                {
                    if (value % 2 == 0) throw new Exception();
                }
                catch (Exception e)
                {
                    var trace = new StackTrace(true);
                    foreach(var frame in trace.GetFrames())
                    {
                        Console.WriteLine($"{frame.GetFileLineNumber()}: {frame.GetMethod()}");
                    }
                    throw e;
                }
            }
        }
        
        static void Main(string[] args)
        {
            var values = new [] {1, 2, 3};
            try
            {
                ThrowExceptionOnEvens(values);
            }
            catch (Exception)
            {
                var trace = new StackTrace(true);
                foreach(var frame in trace.GetFrames())
                {
                    Console.WriteLine($"Native={frame.GetNativeOffset()}, IL={frame.GetILOffset()}");
                }
            }
        }
    }
}
