using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace SKBotApi.Plugins
{
    internal class JokePlugin
    {
        /// <summary>
        /// Tells a joke.
        /// </summary>
        /// <returns></returns>
        [KernelFunction("Joke")]
        [Description("Tells a joke.")]
        public async Task<string> GetJokeAync()
        {
            return "Why did the chicken cross the road? To get to the other side! Sorry, I am not good a telling joke.";
        }
    }
}
