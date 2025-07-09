using MicrosoftNights.McpServerDemo.Tools;

namespace MicrosoftNights.McpServerDemo.Tests
{
    public class Tests
    {
        [Test]
        public async Task Test1()
        {
            var jokes = await JokeTool.GetAllJokes();
            Assert.Pass();
        }
    }
}
