using AIAgentTraining.Approval;
using AIAgentTraining.TravelApi;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OpenAI;
using System.ClientModel;

namespace AIAgentTraining
{
    public class AgentFactory
    {
        static IChatClient CreateChatClient()
        {
            var apiKey = Environment.GetEnvironmentVariable("MISTRAL_API_KEY") ?? throw new InvalidOperationException("Environment variable 'MISTRAL_API_KEY' is not defined."); ;
            var opts = new OpenAIClientOptions();
            opts.Endpoint = new Uri("https://api.mistral.ai/v1/");
            var openAiClient = new OpenAIClient(new ApiKeyCredential(apiKey), opts);

            IChatClient chatClient = openAiClient.GetChatClient("mistral-small-2603").AsIChatClient();
            return chatClient;
        }

        

        public static AIAgent Create(TravelService travelService, ApprovalService approvalService)
        {
            // Access to the Mistral API is created here.
            var client = CreateChatClient();

            // Agent Tools
            var searchDestinations = AIFunctionFactory.Create(
                travelService.SearchDestinations,
                name: "search_destinations",
                description:
                    """
                    Search for travel destinations by minimum expected temperature
                    and maximum weekend budget.

                    Interpret subjective terms such as 'warm' or 'hot' into a
                    reasonable minimum temperature before calling this tool.
                    """
            );

            // TODO Exercise 1: Build a readonly Agent
            // * Implement the agent tools to search for flights and hotels
            // Try a prompt such as:
            //     I want a warm weekend destination from Vienna with a total budget of €1,000. Find me a reasonable option.

            // TODO Exercise 2: Add booking tool calls (BookFlight and BookHotel)
            // Keep in mind: booking is different becasue it has consequences

            // Creating the agent
            return client.AsAIAgent(
                instructions:
                """
                You are a travel planning assistant.

                Help the user find suitable travel options.

                Use tools when they provide authoritative information.
                Do not invent travel availability or prices.
                """,
                tools: [
                    searchDestinations
                    ]);

        }
    }
}
