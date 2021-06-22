using System;

namespace App
{
    interface I
    {
        void iMethod();
        void defaultMethod() => Console.WriteLine("\tI.defaultMethod");
    }
    
    class B
    {
        static int sField;
        int field;
        
        public void method() => Console.WriteLine("\tB.method");
        public virtual void vMethod(B b) => Console.WriteLine("\tB.vMethod");
        public static void sMethod() => Console.WriteLine("\tB.sMethod");
    }
    
    class C : B, I
    {
        int i;
        
        public virtual void iMethod() => Console.WriteLine("\tC.iMethod");
        public override void vMethod(B b) => Console.WriteLine("\tC.vMethod");
        public static void sMethod() => Console.WriteLine("\tC.sMethod");
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            I i = new C();
            B b = new B();
            B bc = new C();
            C c = new C();
            
            Console.WriteLine("I i = new C();");
            i.defaultMethod();
            i.iMethod();
            
            Console.WriteLine("B b = new B();");
            b.method();
            b.vMethod(b);
            B.sMethod();
            
            Console.WriteLine("B bc = new C();");
            bc.method();
            bc.vMethod(bc);
            B.sMethod();
            
            Console.WriteLine("C c = new C();");
            c.iMethod();
            c.method();
            c.vMethod(c);
            C.sMethod();
        }
        /*
        internal class Program
        {
        	private static void Main (string[] args)
        	{
        		C c = new C ();
        		B b = new B ();
        		B b2 = new C ();
        		C c2 = new C ();
        		Console.WriteLine ("I i = new C();");
        		((I)c).defaultMethod ();
        		((I)c).iMethod ();
        		Console.WriteLine ("B b = new B();");
        		b.method ();
        		b.vMethod (b);
        		B.sMethod ();
        		Console.WriteLine ("B bc = new C();");
        		b2.method ();
        		b2.vMethod (b2);
        		B.sMethod ();
        		Console.WriteLine ("C c = new C();");
        		c2.iMethod ();
        		c2.method ();
        		c2.vMethod (c2);
        		C.sMethod ();
        	}
        }
        */
        
        /*
        .class private auto ansi beforefieldinit App.Program
        	extends [System.Runtime]System.Object
        {
        	// Methods
        	.method private hidebysig static 
        		void Main (
        			string[] args
        		) cil managed 
        	{
        		// Method begins at RVA 0x20b4
        		// Code size 135 (0x87)
        		.maxstack 2
        		.entrypoint
        		.locals init (
        			[0] class App.B,
        			[1] class App.B,
        			[2] class App.C
        		)
        
        		IL_0000: newobj instance void App.C::.ctor()
        		IL_0005: newobj instance void App.B::.ctor()
        		IL_000a: stloc.00
        		IL_000b: newobj instance void App.C::.ctor()
        		IL_0010: stloc.11
        		IL_0011: newobj instance void App.C::.ctor()
        		IL_0016: stloc.22
        		IL_0017: ldstr "I i = new C();"
        		IL_001c: call void [System.Console]System.Console::WriteLine(string)
        		IL_0021: dup
        		IL_0022: callvirt instance void App.I::defaultMethod()
        		IL_0027: callvirt instance void App.I::iMethod()
        		IL_002c: ldstr "B b = new B();"
        		IL_0031: call void [System.Console]System.Console::WriteLine(string)
        		IL_0036: ldloc.00
        		IL_0037: callvirt instance void App.B::'method'()
        		IL_003c: ldloc.00
        		IL_003d: ldloc.00
        		IL_003e: callvirt instance void App.B::vMethod(class App.B)
        		IL_0043: call void App.B::sMethod()
        		IL_0048: ldstr "B bc = new C();"
        		IL_004d: call void [System.Console]System.Console::WriteLine(string)
        		IL_0052: ldloc.11
        		IL_0053: callvirt instance void App.B::'method'()
        		IL_0058: ldloc.11
        		IL_0059: ldloc.11
        		IL_005a: callvirt instance void App.B::vMethod(class App.B)
        		IL_005f: call void App.B::sMethod()
        		IL_0064: ldstr "C c = new C();"
        		IL_0069: call void [System.Console]System.Console::WriteLine(string)
        		IL_006e: ldloc.22
        		IL_006f: callvirt instance void App.C::iMethod()
        		IL_0074: ldloc.22
        		IL_0075: callvirt instance void App.B::'method'()
        		IL_007a: ldloc.22
        		IL_007b: ldloc.22
        		IL_007c: callvirt instance void App.B::vMethod(class App.B)
        		IL_0081: call void App.C::sMethod()
        		IL_0086: ret
        	} // end of method Program::Main
        
        	.method public hidebysig specialname rtspecialname 
        		instance void .ctor () cil managed 
        	{
        		// Method begins at RVA 0x2147
        		// Code size 7 (0x7)
        		.maxstack 8
        
        		IL_0000: ldarg.00
        		IL_0001: call instance void [System.Runtime]System.Object::.ctor()
        		IL_0006: ret
        	} // end of method Program::.ctor
        
        } // end of class App.Program
        */
    }
}
