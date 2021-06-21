using System;
using Xunit;

namespace Examples
{
    public class Examples
    {
        [Fact]
        public void HRExceptionExample()
        {
            var error = unchecked((int) 0x81234567);
            var exception = Record.Exception(Foo);
            Assert.IsType<Exception>(exception);
            Assert.Equal(error, exception.HResult);
            
            void Foo() { throw new Exception{ HResult = error }; }
        }
        
        [Fact]
        public void RethrowExceptionExample()
        {
            Assert.Equal(2, DivideBy(2)(4));
            Assert.Equal(2, Apply(DivideBy(2), 4));
            
            var causeDivideByZero = DivideBy(0);
            
            var exception = Record.Exception(() => causeDivideByZero(4));
            Assert.IsType<DivideByZeroException>(exception);
            
            var rethrow = Record.Exception(() => Apply(causeDivideByZero, 8));
            Assert.IsType<DivideByZeroException>(rethrow);
            
            Func<int, int> DivideBy(int n) => x => x / n;
            int Apply(Func<int, int> f, int x)
            {
                try
                {
                    return f(x);
                }
                catch(Exception e)
                {
                    throw;
                }
            }
        }
    }
}
