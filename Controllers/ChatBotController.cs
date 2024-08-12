using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SKBotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatBotController : ControllerBase
    {

        private readonly IChatCompletionService _chatCompletionService;
        private readonly Kernel _kernel;

        public ChatBotController(Kernel kernel,IChatCompletionService chatCompletionService)
        {
            _chatCompletionService = chatCompletionService;
            _kernel = kernel;
        }

        // POST api/<ChatBotController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] string input)
        {

            // Enable auto function calling 
            OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
            {
                ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
            };

            // Call Azure Open AI to get the chat result
            ChatMessageContent chatResult = await _chatCompletionService.GetChatMessageContentAsync(input, openAIPromptExecutionSettings, _kernel);

            return Ok(chatResult.ToString());
        }


    }
}
