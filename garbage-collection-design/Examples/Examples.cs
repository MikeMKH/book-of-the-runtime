using System;
using System.Collections.Generic;
using Xunit;

namespace Examples
{
    public class Examples
    {
        [Fact]
        public void GarbageCollectorSettings()
        {
            Console.WriteLine($"highest generation={GC.MaxGeneration}");
            Console.WriteLine($"total memory={GC.GetTotalMemory(false)}");
        }
        
        [Fact]
        public void GetGenerationExample()
        {
            Console.WriteLine("start method");
            Console.WriteLine($"\thighest generation={GC.MaxGeneration}");
            Console.WriteLine($"\ttotal memory={GC.GetTotalMemory(false)}");
            
            var obj = new { x=1, y=2, z=3 };
            Assert.Equal(0, GC.GetGeneration(obj)); // safe bet
            
            Console.WriteLine("after new object");
            Console.WriteLine($"\thighest generation={GC.MaxGeneration}");
            Console.WriteLine($"\ttotal memory={GC.GetTotalMemory(false)}");
            
            List<int> list = new ();
            for(int i = 0; i < Int16.MaxValue; i++) list.Add(i);
            Assert.Equal(0, GC.GetGeneration(list));
            
            Console.WriteLine("after new List");
            Console.WriteLine($"\thighest generation={GC.MaxGeneration}");
            Console.WriteLine($"\ttotal memory={GC.GetTotalMemory(false)}");
            
            List<List<int>> listOfLists = new ();
            for(int i = 0; i < Int16.MaxValue; i++) listOfLists.Add(list);
            
            Console.WriteLine("after new List of List");
            Console.WriteLine($"\thighest generation={GC.MaxGeneration}");
            Console.WriteLine($"\ttotal memory={GC.GetTotalMemory(false)}");
            
            Dictionary<string, List<List<int>>> dict = new ();
            for(int i = 0; i < Int16.MaxValue; i++) dict.Add(new string('z', i), listOfLists);
            
            Console.WriteLine("after new Dictionary of List of List");
            Console.WriteLine($"\thighest generation={GC.MaxGeneration}");
            Console.WriteLine($"\ttotal memory={GC.GetTotalMemory(false)}");
            
            Console.WriteLine($"obj gen={GC.GetGeneration(obj)}");
            Console.WriteLine($"List gen={GC.GetGeneration(list)}");
            Console.WriteLine($"List of List gen={GC.GetGeneration(listOfLists)}");
            Console.WriteLine($"Dictionary of List of List gen={GC.GetGeneration(dict)}");
        }
    }
}
