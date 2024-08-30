using Xunit;
 
namespace HelloWorldApp.Tests
{
    public class UnitTest
    {
        [Fact]
        public void TestHelloWorldOutput()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main(new string[] { });
                
                string result = sw.ToString().Trim();
                Assert.Equal("Hello, World!!", result);
            }
        }
    }
}