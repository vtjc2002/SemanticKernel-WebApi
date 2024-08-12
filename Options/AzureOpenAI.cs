using System.ComponentModel.DataAnnotations;

namespace SKBotApi.Options
{
    /// <summary>
    /// Azure OpenAI settings.
    /// </summary>
    public sealed class AzureOpenAI
    {
        /// <summary>
        /// Azure Open AI chat deployment name
        /// </summary>
        [Required]
        public string ChatDeploymentName { get; set; } = string.Empty;

        /// <summary>
        /// Azure Open AI endpoint.
        /// </summary>
        [Required]
        public string Endpoint { get; set; } = string.Empty;

        /// <summary>
        /// Azure Open AI API key.
        /// </summary>
        [Required]
        public string ApiKey { get; set; } = string.Empty;

    }

}
