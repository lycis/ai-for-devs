using DotNetEnv;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OpenAI;
using OpenAI.Chat;
using System.ClientModel;
using System.ComponentModel;

// Run from AIAgentTraining/ so the project .env file is loaded.
Env.Load();

// the weather tool
[Description("Get the weather for a given location.")]
static string GetWeather([Description("The location to get the weather for.")] string location)
    => $"The weather in {location} is cloudy with a high of 15°C.";

// the weather tool
[Description("Books a hotel reservation for a given location")]
static string BookHotel([Description("The location where you want to book a hotel.")] string location)
    => $"Hotel booked for 200$ a night.";


// we access mistral through its OpenAI compatible endpoints
var apiKey = Environment.GetEnvironmentVariable("MISTRAL_API_KEY")
    ?? throw new InvalidOperationException("Environment variable 'MISTRAL_API_KEY' is not defined.");
var opts = new OpenAIClientOptions();
opts.Endpoint = new Uri("https://api.mistral.ai/v1/");
var openAiClient = new OpenAIClient(new ApiKeyCredential(apiKey), opts);

IChatClient chatClient = openAiClient.GetChatClient("mistral-small-2603").AsIChatClient();

AIAgent agent = chatClient.AsAIAgent(
      instructions:
                """
                You are a helpful travel assistant.

                Use tools when they can provide information relevant
                to the question.

                Otherwise answer from your general knowledge.
                Never fabricate tool results.
                """,
        tools:  [AIFunctionFactory.Create(GetWeather), AIFunctionFactory.Create(BookHotel)]
    );

var session = await agent.CreateSessionAsync();

Console.WriteLine(await agent.RunAsync("What is the capital of Austria? This is where I am.", session));
Console.ReadLine();
Console.WriteLine(await agent.RunAsync("How is the weather there?", session));
Console.ReadLine();
Console.WriteLine(await agent.RunAsync("That sounds good. Book a hotel for me.", session));


/** Open AI Harness Solution */
/*
var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")
    ?? throw new InvalidOperationException("Environment variable 'OPENAI_API_KEY' is not defined.");
var openAiClient = new OpenAIClient(new ApiKeyCredential(apiKey));

IChatClient chatClient = openAiClient.GetChatClient("gpt-5-mini").AsIChatClient();

AIAgent agent = chatClient.AsHarnessAgent(
    new HarnessAgentOptions
    {
        DisableWebSearch = true,
        ChatOptions = new ChatOptions
        { 
            Instructions =
                """
                You are a helpful travel assistant.

                Use tools when they can provide information relevant
                to the question.

                Otherwise answer from your general knowledge.
                Never fabricate tool results.
                """,
            Tools = [AIFunctionFactory.Create(GetWeather)]
        }
    });

var session = await agent.CreateSessionAsync();

await foreach (var update in agent.RunStreamingAsync("""
        I am spending this evening in Vienna.

        Create an evening plan for me. Do not ask for preferences. Assume a 
        travelling couple with two kids.

        Check the weather first.
        Based on the weather:
        - recommend what we should wear,
        - decide whether an outdoor activity makes sense,
        - suggest an appropriate type of activity,
        - give me a concise final plan.

        Work through everything necessary to complete the task.
    """, session))
{
    Console.Write(update);
}

Console.WriteLine();

while (true)
{
    Console.Write("> ");
    string? input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input) || input.Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    // Stream this turn's output as the harness plans and works through the request.
    await foreach (var update in agent.RunStreamingAsync(input, session))
    {
        Console.Write(update);
    }

    Console.WriteLine();
}
*/