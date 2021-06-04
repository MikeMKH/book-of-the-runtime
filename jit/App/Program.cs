using System;

/*
 I was unable to get the actual assembler code by following https://github.com/dotnet/coreclr/blob/master/Documentation/botr/ryujit-overview.md
*/
namespace App
{
    class Program
    {
        /*
	    .method public hidebysig specialname rtspecialname 
	    	instance void .ctor () cil managed 
	    {
	    	// Method begins at RVA 0x20ce
	    	// Code size 7 (0x7)
	    	.maxstack 8
    
	    	IL_0000: ldarg.00
	    	IL_0001: call instance void [System.Runtime]System.Object::.ctor()
	    	IL_0006: ret
	    } // end of method Program::.ctor
        */
        
        static void Main(string[] args)
        {
            X();
            var y = Y();
            Z(y);
        }
        /*
        private static void Main (string[] args)
	    {
	    	X ();
	    	Z (Y ());
	    }
        */
        /*
	    .method private hidebysig static 
	    	void Main (
	    		string[] args
	    	) cil managed 
	    {
	    	// Method begins at RVA 0x2048
	    	// Code size 16 (0x10)
	    	.maxstack 8
	    	.entrypoint
    
	    	IL_0000: call void App.Program::X()
	    	IL_0005: call int32 App.Program::Y()
	    	IL_000a: call void App.Program::Z(int32)
	    	IL_000f: ret
	    } // end of method Program::Main
        */
        
        static void X()
        {
            const int unneeded_beforeloop = 7;
            for(int i = 0; i < 3; i++)
            {
                const int unneeded_inloop = 8;
                string bang = "!";
                Console.WriteLine($"{i}{bang}");
            }
            const int unneeded_afterloop = 7;
        }
        /*
	    private static void X ()
	    {
	    	for (int i = 0; i < 3; i++) {
	    		string arg = "!";
	    		Console.WriteLine ($"{i}{arg}");
	    	}
	    }
        */
        /*
	    .method private hidebysig static 
	    	void X () cil managed 
	    {
	    	// Method begins at RVA 0x205c
	    	// Code size 41 (0x29)
	    	.maxstack 3
	    	.locals init (
	    		[0] int32,
	    		[1] string
	    	)
    
	    	IL_0000: ldc.i4.0
	    	IL_0001: stloc.00
	    	IL_0002: br.s IL_0024
	    	// loop start (head: IL_0024)
	    		IL_0004: ldstr "!"
	    		IL_0009: stloc.11
	    		IL_000a: ldstr "{0}{1}"
	    		IL_000f: ldloc.00
	    		IL_0010: box [System.Runtime]System.Int32
	    		IL_0015: ldloc.11
	    		IL_0016: call string [System.Runtime]System.String::Format(string, object, object)
	    		IL_001b: call void [System.Console]System.Console::WriteLine(string)
	    		IL_0020: ldloc.00
	    		IL_0021: ldc.i4.1
	    		IL_0022: add
	    		IL_0023: stloc.00
    
	    		IL_0024: ldloc.00
	    		IL_0025: ldc.i4.3
	    		IL_0026: blt.s IL_0004
	    	// end loop
    
	    	IL_0028: ret
	    } // end of method Program::X
        */
        
        static int Y()
        {
            int result = 0;
            for(int i = 0; i < 100; i++)
            {
                const int unneeded_zero = 0;
                result += i;
                result += unneeded_zero;
            }
            return result;
        }
        /*
	    private static int Y ()
	    {
	    	int num = 0;
	    	for (int i = 0; i < 100; i++) {
	    		num += i;
	    		num = num;
	    	}
	    	return num;
	    }
        */
        /*
	    .method private hidebysig static 
	    	int32 Y () cil managed 
	    {
	    	// Method begins at RVA 0x2094
	    	// Code size 23 (0x17)
	    	.maxstack 2
	    	.locals init (
	    		[0] int32,
	    		[1] int32
	    	)
    
	    	IL_0000: ldc.i4.0
	    	IL_0001: stloc.00
	    	IL_0002: ldc.i4.0
	    	IL_0003: stloc.11
	    	IL_0004: br.s IL_0010
	    	// loop start (head: IL_0010)
	    		IL_0006: ldloc.00
	    		IL_0007: ldloc.11
	    		IL_0008: add
	    		IL_0009: stloc.00
	    		IL_000a: ldloc.00
	    		IL_000b: stloc.00
	    		IL_000c: ldloc.11
	    		IL_000d: ldc.i4.1
	    		IL_000e: add
	    		IL_000f: stloc.11
    
	    		IL_0010: ldloc.11
	    		IL_0011: ldc.i4.s 100
	    		IL_0013: blt.s IL_0006
	    	// end loop
    
	    	IL_0015: ldloc.00
	    	IL_0016: ret
	    } // end of method Program::Y
        */
        
        static void Z(int value) => Console.WriteLine($"sum(0..100)={value}");
        /*
	    private static void Z (int value)
	    {
	    	Console.WriteLine ($"sum(0..100)={value}");
	    }
        */
        /*
	    .method private hidebysig static 
	    	void Z (
	    		int32 'value'
	    	) cil managed 
	    {
	    	// Method begins at RVA 0x20b7
	    	// Code size 22 (0x16)
	    	.maxstack 8
    
	    	IL_0000: ldstr "sum(0..100)={0}"
	    	IL_0005: ldarg.00
	    	IL_0006: box [System.Runtime]System.Int32
	    	IL_000b: call string [System.Runtime]System.String::Format(string, object)
	    	IL_0010: call void [System.Console]System.Console::WriteLine(string)
	    	IL_0015: ret
	    } // end of method Program::Z
        */
    }
}
