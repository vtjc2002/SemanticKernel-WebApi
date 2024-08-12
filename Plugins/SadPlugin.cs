using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace SKBotApi.Plugins
{
    internal class SadPlugin
    {
        /// <summary>
        /// Tells an excuse.
        /// </summary>
        /// <returns></returns>
        [KernelFunction("Sad")]
        [Description("Tells a short sad story.")]
        public async Task<string> GetSadStoryAync()
        {
            return "I lost a dart game to a blind man.";
        }


    }
}
