using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Examples
{
    public class Examples
    {
        void PrintLine(string s) => Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] {s}");
        
        [Fact]
        public void CurrentThreadInformation()
        {
            PrintLine($"{System.Reflection.MethodBase.GetCurrentMethod()}");
            PrintLine($"\tProcessorId={Thread.GetCurrentProcessorId()}");
            PrintLine($"\tManagedThreadId={Thread.CurrentThread.ManagedThreadId}");
            PrintLine($"\tThreadState={Thread.CurrentThread.ThreadState}");
        }
        
        [Fact]
        public void CreateThreadExample()
        {
            PrintLine($"{System.Reflection.MethodBase.GetCurrentMethod()}");
            
            var complete = Task.FromResult("done");
            Assert.Equal(TaskStatus.RanToCompletion, complete.Status);
            PrintLine("\tTask.FromResult");
            PrintLine($"\t\tId={complete.Id}");
            PrintLine($"\t\tStatus={complete.Status}");
            
            var waiting = Task.FromResult("waiting").ContinueWith(s => PrintLine($"\tResult={s.Result}"));
            PrintLine("\tTask.FromResult.ContinueWith");
            PrintLine($"\t\tId={waiting.Id}");
            PrintLine($"\t\tStatus={waiting.Status}");
            
            var method = Task.Run(PrintThreadInfo);
            PrintLine("\tTask.Run");
            PrintLine($"\t\tId={method.Id}");
            PrintLine($"\t\tStatus={method.Status}");
            
            void PrintThreadInfo()
            {
                PrintLine($"\t\tProcessorId={Thread.GetCurrentProcessorId()}");
                PrintLine($"\t\tManagedThreadId={Thread.CurrentThread.ManagedThreadId}");
                PrintLine($"\t\tThreadState={Thread.CurrentThread.ThreadState}");
            }
        }
    }
}
