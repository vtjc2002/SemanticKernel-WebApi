
using Microsoft.SemanticKernel;
using SKBotApi.Options;
using SKBotApi.Plugins;

namespace SKBotApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient();

            // Bind Azure Open AI settings
            builder.Services.AddOptions<AzureOpenAI>()
               .Bind(builder.Configuration.GetSection(nameof(AzureOpenAI)))
               .ValidateDataAnnotations()
               .ValidateOnStart();

            // Load the Azure Open AI settings
            AzureOpenAI azureOpenAIOptions = builder.Configuration.GetSection(nameof(AzureOpenAI)).Get<AzureOpenAI>() ?? throw new InvalidOperationException("AzureOpenAI configuration section is missing or invalid.");

            // Add SK Plugins
            builder.Services.AddSingleton<KernelPlugin>(sp => KernelPluginFactory.CreateFromType<JokePlugin>(serviceProvider: sp));
            builder.Services.AddSingleton<KernelPlugin>(sp => KernelPluginFactory.CreateFromType<ExcusePlugin>(serviceProvider: sp));
            builder.Services.AddSingleton<KernelPlugin>(sp => KernelPluginFactory.CreateFromType<SadPlugin>(serviceProvider: sp));

            // Add SK Kernel
            builder.Services.AddKernel().AddAzureOpenAIChatCompletion(
                deploymentName: azureOpenAIOptions.ChatDeploymentName,
                endpoint: azureOpenAIOptions.Endpoint,
                apiKey: azureOpenAIOptions.ApiKey
                );


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
