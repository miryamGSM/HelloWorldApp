using Xunit;
 
namespace HelloWorldApp.Tests
{
    public class UnitTest
    {
        [Fact]
        public void TestHelloWorldOutput()
        {
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                Program.Main(new string[] { });
                
                var result = sw.ToString().Trim();
                Assert.Equal("Hello, World!", result);
            }
        }
    }
}