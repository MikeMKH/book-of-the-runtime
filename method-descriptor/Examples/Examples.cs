using System;
using System.Linq;
using Xunit;

namespace Examples
{
    public class Examples
    {
        [Fact]
        public void StringMethods()
        {
            var methods = 
              from m in typeof(string).GetMethods()
              group m by m.MethodHandle.Value.ToString().Substring(0,5) into g
              select new { UpperBits = g.Key, Methods = g.ToList()};
              
            foreach(var m in methods)
            {
                Console.WriteLine($"[{m.UpperBits}]");
                foreach(var method in m.Methods)
                {
                    Console.WriteLine($"\t{method.ToString()}");
                }
            }
        }
    }
}
