using System;
using Xunit;

namespace Examples
{
    public class Examples
    {
        public interface IFive
        {
            int Five() => 5;
        }
        /*
	    .class interface nested public auto ansi abstract IFive
	    {
	    	// Methods
	    	.method public hidebysig newslot virtual 
	    		instance int32 Five () cil managed 
	    	{
	    		// Method begins at RVA 0x2112
	    		// Code size 2 (0x2)
	    		.maxstack 8
    
	    		IL_0000: ldc.i4.5
	    		IL_0001: ret
	    	} // end of method IFive::Five
    
	    } // end of class IFive
        */
        
        public interface IAdd
        {
            int Add(int a, int b);
        }
        
        public class A
        {
            public int Six = 6;
        }
        /*
	    .class nested public auto ansi beforefieldinit A
	    	extends [System.Runtime]System.Object
	    {
	    	// Fields
	    	.field public int32 Six
    
	    	// Methods
	    	.method public hidebysig specialname rtspecialname 
	    		instance void .ctor () cil managed 
	    	{
	    		// Method begins at RVA 0x2115
	    		// Code size 14 (0xe)
	    		.maxstack 8
    
	    		IL_0000: ldarg.00
	    		IL_0001: ldc.i4.6
	    		IL_0002: stfld int32 Examples.Examples/A::Six
	    		IL_0007: ldarg.00
	    		IL_0008: call instance void [System.Runtime]System.Object::.ctor()
	    		IL_000d: ret
	    	} // end of method A::.ctor
    
	    } // end of class A
        */
        
        public class B : IFive {}
        /*
	    .class nested public auto ansi beforefieldinit B
	    	extends [System.Runtime]System.Object
	    	implements Examples.Examples/IFive
	    {
	    	// Methods
	    	.method public hidebysig specialname rtspecialname 
	    		instance void .ctor () cil managed 
	    	{
	    		// Method begins at RVA 0x2124
	    		// Code size 7 (0x7)
	    		.maxstack 8
    
	    		IL_0000: ldarg.00
	    		IL_0001: call instance void [System.Runtime]System.Object::.ctor()
	    		IL_0006: ret
	    	} // end of method B::.ctor
    
	    } // end of class B
        */
        
        public class Classic : IAdd
        {
            public int Add(int a, int b) => a + b;
        }
        
        public class PlusOne : A, IFive, IAdd
        {
            public int Five() => 6;
            
            public int Six = 7;
            
            public int Add(int a, int b) => a + b + 1;
        }
        
        [Theory]
        [InlineData(2, 2)]
        [InlineData(1, 5)]
        [InlineData(5, 1)]
        [InlineData(0, 9876)]
        [InlineData(9876, 0)]
        [InlineData(-123, 6336)]
        [InlineData(6336, -123)]
        public void ClassicAddMustAddNumbers(int x, int y)
        {
            var adder = new Classic();
            Assert.Equal(x + y, adder.Add(x, y));
        }
        
        [Fact]
        public void AddFiveAndSixMustEqual11()
        {
            var adder = new Classic();
            var a = new A();
            IFive b = new B(); // must be of the type of the interface to use default interface method
            Assert.Equal(11, adder.Add(b.Five(), a.Six));
        }
        
        [Fact]
        public void PlusOneAdditionMustAdd1()
        {
            var plus1 = new PlusOne();
            Assert.Equal(1 + 2 + 1, plus1.Add(1, 2));
            Assert.Equal(5 + 1, plus1.Five());
            Assert.Equal(6 + 1, plus1.Six);
            Assert.Equal(5 + 1 + 6 + 1 + 1, plus1.Add(plus1.Five(), plus1.Six));
        }
    }
}
