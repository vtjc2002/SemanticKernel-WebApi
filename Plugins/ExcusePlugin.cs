using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace SKBotApi.Plugins
{
    internal class ExcusePlugin
    {
        /// <summary>
        /// Tells an excuse.
        /// </summary>
        /// <returns></returns>
        [KernelFunction("Excuse")]
        [Description("Tells an excuse on why I am late for work.")]
        public async Task<string> GetExecuseAync()
        {
            return "I'm sorry, I can't do that.";
        }


    }
}
