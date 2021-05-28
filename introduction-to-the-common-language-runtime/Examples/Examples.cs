using System;
using Xunit;

namespace Examples
{
    public class Examples
    {
        [Fact]
        public void EmitExample()
        {
            Assert.Equal("ldsfld", System.Reflection.Emit.OpCodes.Ldsfld.ToString());
            var test = System.Reflection.Emit.MethodBuilder.GetCurrentMethod();
            foreach(var prop in test.GetType().GetProperties(System.Reflection.BindingFlags.Instance))
            {
                Console.WriteLine($"{prop}={prop.GetValue(prop).ToString()}");
            }
        }
    }
}
