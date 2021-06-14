using System;
using System.Runtime.InteropServices;
using Xunit;

namespace Examples
{
    public class Examples
    {
        // taken from http://www.albahari.com/nutshell/E9-CH24.aspx

        [DllImport ("libc")]
        static extern int clock_gettime (int clk_id, ref Timespec tp);
        
        [StructLayout (LayoutKind.Sequential)]
        struct Timespec
        {
          public long tv_sec;   /* seconds */
          public long tv_nsec;  /* nanoseconds */
        }
        
        [Fact]
        public void NativeClockTimeExample()
        {
            Timespec timespec = new Timespec();
            int success = clock_gettime(0, ref timespec);
            Assert.Equal(0, success);  // check that call worked
            
            Console.WriteLine($"seconds={timespec.tv_sec}, nanoseconds={timespec.tv_nsec}");
            DateTime epoch = new DateTime (1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            Console.WriteLine($"datetime={epoch.AddSeconds(timespec.tv_sec).ToLocalTime()}");
        }
        
        [DllImport ("libc")]
        static extern uint getuid();
        
        [Fact]
        public void NativeGetUidExample()
        {
            uint uid = getuid();
            Assert.NotEqual<uint>(0, uid); // true except for system
            Console.WriteLine($"uid={uid}");    
        }
    }
}
