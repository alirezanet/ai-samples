﻿using Microsoft.SemanticKernel;
var openAIChatCompletionModelName = "gpt-4-turbo"; // this could be other models like "gpt-4-turbo".
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKernel();

# pragma warning disable CS0618
// This should work for any other service you can decided to use E.g Mistral.
var kernel = builder.Services.AddOpenAIChatCompletion(openAIChatCompletionModelName, Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var app = builder.Build();

app.MapGet("/WeatherForecast", async (Kernel kerel) =>
{
    int temp = Random.Shared.Next(-20, 55);
    return new WeatherForecast
    (
        DateOnly.FromDateTime(DateTime.Now),
        temp,
        await kerel.InvokePromptAsync<string>($"Short description of weather at {temp}0c?") // This description will be generated by the AI model for the given temperature.
    );
});
app.Run();

internal record WeatherForecast(DateOnly Date, int TempratureC, string Summary)
{
    public int TempratureF => 32 + (int)(TempratureC / 0.5556);
}
