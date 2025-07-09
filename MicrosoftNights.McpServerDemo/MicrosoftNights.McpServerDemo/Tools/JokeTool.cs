using ModelContextProtocol.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftNights.McpServerDemo.Tools
{
    [McpServerToolType]
    public class JokeTool
    {
        [McpServerTool(Name = "SetupJokeTool"), Description("Returns a random joke in category Programming or General. The punchline of the joke should be presented to the end user. After the end user replies, The ReturnPunchline tool should be used to reply with the punchline that belongs to the returned joke")]
        public static async Task<IEnumerable<Joke>?> SetupJoke([Description("The type of joke that is requested")] string type)
        {
            var jokes = await GetAllJokes();
            return jokes.Where(j => j.Type == type);
        }

        public static async Task<IEnumerable<Joke>> GetAllJokes()
        {
            var assembly = typeof(JokeTool).Assembly;
            using var stream = assembly.GetManifestResourceStream("MicrosoftNights.McpServerDemo.EmbeddedResources.jokes.json");
            if (stream == null)
                throw new InvalidOperationException("Could not find jokes.json embedded resource.");
            var jokes = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<Joke>>(stream);
            return jokes ?? Enumerable.Empty<Joke>();
        }

        [McpServerTool(Name = "ReturnPunchline"), Description("Tells you a random joke about a certain category")]
        public static async Task<string?> ReturnPunchline([Description("The joke id that was returned by SetupJoke")] int jokeId)
        {
            var jokes = await GetAllJokes();
            return jokes.Where(j => j.Id == jokeId).FirstOrDefault()?.Punchline;
        }
    }

    public class Joke
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Setup { get; set; }
        public string Punchline { get; set; }
    }

    public enum Type
    {
        General,
        Programming
    }
}
