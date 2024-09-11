using System;
using Xunit;

using HelloWorldApp;
 
namespace HelloWorldApp.Tests
{
    public class UnitTest
    {
        [Fact]
        public void TestHelloWorldOutput()
        {
			// comment
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                Program.Main(new string[] { });
                
                var result = sw.ToString().Trim();
                Assert.Equal("Hello, World!", result);
            }
			// sub-branch comment
        }
    }
}