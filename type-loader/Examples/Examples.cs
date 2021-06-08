using System;
using Xunit;

namespace Examples
{
    public class Examples
    {
        public class A1<S, T, U> {}
        public class A2<T> where T: class {}
        public class A3<T> where T: struct {}
        public class A4<T> where T: new() {}
        public class A5<T> where T: EventArgs {}
        public class A6<T> where T: ICloneable, IComparable {}
        public class A7<S, T, U>
          where S: struct
          where T: ICloneable, IComparable
          where U: class {}
          
        public class A8 {}
        
        [Fact]
        public void TokenExample()
        {
            var a1 = typeof(A1<short, int, long>);
            Assert.Contains("`3", a1.ToString());
            Assert.Equal(
                "Examples.Examples+A1`3[System.Int16,System.Int32,System.Int64]",
                a1.ToString());
            
            var a2 = typeof(A2<string>);
            Assert.Equal("Examples.Examples+A2`1[System.String]", a2.ToString());
            
            var a3 = typeof(A3<DateTime>);
            Assert.Equal("Examples.Examples+A3`1[System.DateTime]", a3.ToString());
            
            var a4 = typeof(A4<DateTime>);
            Assert.Equal("Examples.Examples+A4`1[System.DateTime]", a4.ToString());
            
            var a5 = typeof(A5<EventArgs>);
            Assert.Equal("Examples.Examples+A5`1[System.EventArgs]", a5.ToString());
            
            var a6 = typeof(A6<string>);
            Assert.Equal("Examples.Examples+A6`1[System.String]", a6.ToString());
            
            var a7 = typeof(A7<short, string, Tuple<int>>);
            Assert.Contains("`3", a7.ToString());
            Assert.Equal(
                "Examples.Examples+A7`3[System.Int16,System.String,System.Tuple`1[System.Int32]]",
                a7.ToString());
            
            var a8 = typeof(A8);
            Assert.Equal("Examples.Examples+A8", a8.ToString());
        }
        
        public class X<T>: Z<Y<T>> {}
        public class Y<T>: Z<X<T>> {}
        public class Z<T> {}
        
        [Fact]
        public void LoadLevelsExample()
        {
            var x = typeof(X<>);
            Assert.Equal("Examples.Examples+X`1[T]", x.ToString());
            
            var y = typeof(Y<>);
            Assert.Equal("Examples.Examples+Y`1[T]", y.ToString());
            
            var z = typeof(Z<>);
            Assert.Equal("Examples.Examples+Z`1[T]", z.ToString());
        }
    }
}
