using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using Azure.Identity;

public partial class OpenAISamples
{
    public static async Task Chat() 
    {
        IChatClient client =
            new AzureOpenAIClient(
                new Uri(Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT")),
                new DefaultAzureCredential())
                .AsChatClient(modelId: "gpt-4o-mini");

        var response = await client.CompleteAsync("What is AI?");

        Console.WriteLine(response.Message);
    }    
}