using System;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace Examples
{
    public class Examples
    {
        [Fact]
        public void StackTraceExample()
        {
            var t = new StackTrace();
            Assert.Equal(
                "StackTraceExample"
                ,t.GetFrames().First().GetMethod().Name);
        }
        
        public void Method1() => Method2();
        public void Method2() => Method3();
        public void Method3() => throw new ExecutionEngineException();
        
        [Fact]
        public void StackTraceExceptionExample()
        {
            var sut = new Examples();
            try
            {
                sut.Method1();
            }
            catch (ExecutionEngineException)
            {
                var trace = new StackTrace(true);
                foreach(var frame in trace.GetFrames())
                {
                    Console.WriteLine($"{frame.GetHashCode()}: {frame.GetMethod().Name}");
                }
            }
        }
    }
}
