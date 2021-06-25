using System;
using System.Linq;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Program();
            
            float x = 1.23f, y = 4.567f;
            var z = app.IdentitySpy(FloatAdder(x, y));
            /*
		    IL_0014: call float32 App.Program::FloatAdder(float32, float32)
		    IL_0019: callvirt instance !!0 App.Program::IdentitySpy<float32>(!!0)
            IL_001e: stloc.22
            */
            Console.WriteLine($"{x} + {y}={z}");
            /*
		    IL_001f: ldstr "{0} + {1}={2}"
		    IL_0024: ldloc.00
		    IL_0025: box [System.Runtime]System.Single
		    IL_002a: ldloc.11
		    IL_002b: box [System.Runtime]System.Single
		    IL_0030: ldloc.22
		    IL_0031: box [System.Runtime]System.Single
		    IL_0036: call string [System.Runtime]System.String::Format(string, object, object, object)
		    IL_003b: call void [System.Console]System.Console::WriteLine(string)
            */
            
            var sum = app.Summer(1, 2, 3, 4, 5, 6, 7, 8, 9);
            /*
		    IL_0040: ldc.i4.1
		    IL_0041: ldc.i4.8
		    IL_0042: newarr [System.Runtime]System.Int32
		    IL_0047: dup
		    IL_0048: ldtoken field valuetype '<PrivateImplementationDetails>'/'__StaticArrayInitTypeSize=32' '<PrivateImplementationDetails>'::B06E51B2494D439F5E151692CA393EFC3C52CDFDDCC377BE789356250B9860A6
		    IL_004d: call void [System.Runtime]System.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(class [System.Runtime]System.Array, valuetype [System.Runtime]System.RuntimeFieldHandle)
		    IL_0052: callvirt instance int32 App.Program::Summer(int32, int32[])
		    IL_0057: stloc.33
            */
            Console.WriteLine($"+ 1..9 = {sum}");
            /*
		    IL_0058: ldstr "+ 1..9 = {0}"
		    IL_005d: ldloc.33
		    IL_005e: box [System.Runtime]System.Int32
		    IL_0063: call string [System.Runtime]System.String::Format(string, object)
		    IL_0068: call void [System.Console]System.Console::WriteLine(string)
            */
						
						app.TryCatchTest();
						app.TryCatchFinallyTest();
						/*
		    IL_0071: ldloc.00
		    IL_0072: callvirt instance void App.Program::TryCatchTest()
		    IL_0077: ldloc.00
		    IL_0078: callvirt instance void App.Program::TryCatchFinallyTest()
		    IL_007d: ret
						*/
        }
        
        static float FloatAdder(float x, float y) => x + y;
        /*
	    .method private hidebysig static 
	    	float32 FloatAdder (
	    		float32 x,
	    		float32 y
	    	) cil managed 
	    {
	    	// Method begins at RVA 0x20ca
	    	// Code size 4 (0x4)
	    	.maxstack 8
    
	    	IL_0000: ldarg.00
	    	IL_0001: ldarg.11
	    	IL_0002: add
	    	IL_0003: ret
	    } // end of method Program::FloatAdder
        */
        
        T IdentitySpy<T>(T x)
        {
            Console.WriteLine($"[peek] {x}");
            return x;
        }
        /*
	    .method private hidebysig 
	    	instance !!T IdentitySpy<T> (
	    		!!T x
	    	) cil managed 
	    {
	    	// Method begins at RVA 0x20cf
	    	// Code size 23 (0x17)
	    	.maxstack 8
    
	    	IL_0000: ldstr "[peek] {0}"
	    	IL_0005: ldarg.11
	    	IL_0006: box !!T
	    	IL_000b: call string [System.Runtime]System.String::Format(string, object)
	    	IL_0010: call void [System.Console]System.Console::WriteLine(string)
	    	IL_0015: ldarg.11
	    	IL_0016: ret
	    } // end of method Program::IdentitySpy
        */
        
        int Summer(int y, params int[] xs) => xs.Aggregate(y, (m, x) => m + x);
        /*
	    .method private hidebysig 
	    	instance int32 Summer (
	    		int32 y,
	    		int32[] xs
	    	) cil managed 
	    {
	    	.param [2]
	    		.custom instance void [System.Runtime]System.ParamArrayAttribute::.ctor() = (
	    			01 00 00 00
	    		)
	    	// Method begins at RVA 0x20e7
	    	// Code size 39 (0x27)
	    	.maxstack 8
    
	    	IL_0000: ldarg.22
	    	IL_0001: ldarg.11
	    	IL_0002: ldsfld class [System.Runtime]System.Func`3<int32, int32, int32> App.Program/'<>c'::'<>9__3_0'
	    	IL_0007: dup
	    	IL_0008: brtrue.s IL_0021
    
	    	IL_000a: pop
	    	IL_000b: ldsfld class App.Program/'<>c' App.Program/'<>c'::'<>9'
	    	IL_0010: ldftn instance int32 App.Program/'<>c'::'<Summer>b__3_0'(int32, int32)
	    	IL_0016: newobj instance void class [System.Runtime]System.Func`3<int32, int32, int32>::.ctor(object, native int)
	    	IL_001b: dup
	    	IL_001c: stsfld class [System.Runtime]System.Func`3<int32, int32, int32> App.Program/'<>c'::'<>9__3_0'
    
	    	IL_0021: call !!1 [System.Linq]System.Linq.Enumerable::Aggregate<int32, int32>(class [System.Runtime]System.Collections.Generic.IEnumerable`1<!!0>, !!1, class [System.Runtime]System.Func`3<!!1, !!0, !!1>)
	    	IL_0026: ret
	    } // end of method Program::Summer
          */
				  public void TryCatchTest() {
            try {
                try {
                    throw new ArgumentException(
											System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
                }
                catch (ArgumentException e){
                    Console.WriteLine("ArgumentException was caught");
                    throw new ArgumentException(
											System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
                }
            }
            catch (ArgumentException e) {
                Console.WriteLine("ArgumentException was caught");
            }
          }
					/*
	    .method public hidebysig 
	    	instance void TryCatchTest () cil managed 
	    {
	    	// Method begins at RVA 0x211c
	    	// Code size 73 (0x49)
	    	.maxstack 1
	    	.locals init (
	    		[0] int32
	    	)
    
	    	.try
	    	{
	    		.try
	    		{
	    			IL_0000: call class [System.Threading.Thread]System.Threading.Thread [System.Threading.Thread]System.Threading.Thread::get_CurrentThread()
	    			IL_0005: callvirt instance int32 [System.Threading.Thread]System.Threading.Thread::get_ManagedThreadId()
	    			IL_000a: stloc.00
	    			IL_000b: ldloca.s 0
	    			IL_000d: call instance string [System.Runtime]System.Int32::ToString()
	    			IL_0012: newobj instance void [System.Runtime]System.ArgumentException::.ctor(string)
	    			IL_0017: throw
	    		} // end .try
	    		catch [System.Runtime]System.ArgumentException
	    		{
	    			IL_0018: pop
	    			IL_0019: ldstr "ArgumentException was caught"
	    			IL_001e: call void [System.Console]System.Console::WriteLine(string)
	    			IL_0023: call class [System.Threading.Thread]System.Threading.Thread [System.Threading.Thread]System.Threading.Thread::get_CurrentThread()
	    			IL_0028: callvirt instance int32 [System.Threading.Thread]System.Threading.Thread::get_ManagedThreadId()
	    			IL_002d: stloc.00
	    			IL_002e: ldloca.s 0
	    			IL_0030: call instance string [System.Runtime]System.Int32::ToString()
	    			IL_0035: newobj instance void [System.Runtime]System.ArgumentException::.ctor(string)
	    			IL_003a: throw
	    		} // end handler
	    	} // end .try
	    	catch [System.Runtime]System.ArgumentException
	    	{
	    		IL_003b: pop
	    		IL_003c: ldstr "ArgumentException was caught"
	    		IL_0041: call void [System.Console]System.Console::WriteLine(string)
	    		IL_0046: leave.s IL_0048
	    	} // end handler
    
	    	IL_0048: ret
	    } // end of method Program::TryCatchTest
					*/
					public void TryCatchFinallyTest()
					{
						var zero = 0;
						try
						{
							var x = 5 / zero;
							try
							{
								var y = 6 / zero;
								try
								{
									var z = 7 / zero;
								}
								catch
								{
									Console.WriteLine("Inner Catch");
								}
							}
							finally
							{
								Console.WriteLine("Inner Finally");
							}
						}
						catch
						{
							Console.WriteLine("Outter Catch");
						}
					}
					/*
	    .method public hidebysig 
	    	instance void TryCatchFinallyTest () cil managed 
	    {
	    	// Method begins at RVA 0x2194
	    	// Code size 58 (0x3a)
	    	.maxstack 2
	    	.locals init (
	    		[0] int32
	    	)
    
	    	IL_0000: ldc.i4.0
	    	IL_0001: stloc.00
	    	.try
	    	{
	    		IL_0002: ldc.i4.5
	    		IL_0003: ldloc.00
	    		IL_0004: div
	    		IL_0005: pop
	    		.try
	    		{
	    			IL_0006: ldc.i4.6
	    			IL_0007: ldloc.00
	    			IL_0008: div
	    			IL_0009: pop
	    			.try
	    			{
	    				IL_000a: ldc.i4.7
	    				IL_000b: ldloc.00
	    				IL_000c: div
	    				IL_000d: pop
	    				IL_000e: leave.s IL_001d
	    			} // end .try
	    			catch [System.Runtime]System.Object
	    			{
	    				IL_0010: pop
	    				IL_0011: ldstr "Inner Catch"
	    				IL_0016: call void [System.Console]System.Console::WriteLine(string)
	    				IL_001b: leave.s IL_001d
	    			} // end handler
    
	    			IL_001d: leave.s IL_002a
	    		} // end .try
	    		finally
	    		{
	    			IL_001f: ldstr "Inner Finally"
	    			IL_0024: call void [System.Console]System.Console::WriteLine(string)
	    			IL_0029: endfinally
	    		} // end handler
    
	    		IL_002a: leave.s IL_0039
	    	} // end .try
	    	catch [System.Runtime]System.Object
	    	{
	    		IL_002c: pop
	    		IL_002d: ldstr "Outter Catch"
	    		IL_0032: call void [System.Console]System.Console::WriteLine(string)
	    		IL_0037: leave.s IL_0039
	    	} // end handler
    
	    	IL_0039: ret
	    } // end of method Program::TryCatchFinallyTest
					*/
    }
}
