using AIAgentTraining;
using AIAgentTraining.Approval;
using AIAgentTraining.Models;
using AIAgentTraining.TravelApi;
using DotNetEnv;

Env.Load();
Console.WriteLine($"CWD: {Directory.GetCurrentDirectory()}");
Console.WriteLine(
    $"MISTRAL_API_KEY loaded: {!string.IsNullOrWhiteSpace(
        Environment.GetEnvironmentVariable("MISTRAL_API_KEY"))}");

var travelApi = new TravelService();
var approvalService = new ApprovalService();
var agent = AgentFactory.Create(travelApi, approvalService);
var session = await agent.CreateSessionAsync();

// TODO adapt scenario if required
// TODO Exercise 3: Set scenario to TravelAapiScenario.DelayedBookingConfirmation
// TODO Exercise 4: Set scenario to TravelAapiScenario.FailedHotelBooking
travelApi.SetScenario(TravelApiScenario.HappyPath);

Console.WriteLine("---------- Travel Agent ----------");
while(true)
{
    Console.Write("> ");

    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input)) continue;
    if (input.Equals("exit", StringComparison.OrdinalIgnoreCase)) break;

    Console.WriteLine("[Agent]");
    await foreach (var update in agent.RunStreamingAsync(input, session))
    {
        Console.Write(update);
    }
    Console.WriteLine();
    Console.WriteLine("[/Agent]");

    if(approvalService.PendingApproval is not null)
    {
        await humanApproval(approvalService, agent, session, travelApi);
    }
    Console.WriteLine();
}

static async Task humanApproval(ApprovalService approvalService, Microsoft.Agents.AI.AIAgent agent, Microsoft.Agents.AI.AgentSession session, TravelService? travelApi)
{
    var approval = approvalService.PendingApproval;

    Console.WriteLine();
    Console.WriteLine("[APPROVAL]");
    Console.WriteLine(approval.Description);
    Console.WriteLine("Approve? [y/N]");

    var answer = Console.ReadLine();
    if (answer?.Equals("y", StringComparison.OrdinalIgnoreCase) == true || answer?.Equals("yes", StringComparison.OrdinalIgnoreCase) == true)
    {
        var result = await approval.Action();
       result = waitForBookingToFinish(travelApi, result);

        Console.WriteLine($"[RUNTIME] Booking {result.BookingId}: {result.Status}");

        await foreach (var update in agent.RunStreamingAsync(
            $"""
                    The user approved the requested booking.

                    The booking operation returned:
                        Booking ID: {result.BookingId}
                           Status: {result.Status}

                    Continue based on this authoritative result.
                """, session))
        {
            Console.Write(update);
        }
    }
    else
    {
        await foreach (var update in agent.RunStreamingAsync(
            """
                    The user rejected the proposed booking.
                    Continue without performing that booking.
                """,
            session))
        {
            Console.Write(update);
        }
    }

    approvalService.ClearPendingApproval();
}

static BookingResult waitForBookingToFinish(TravelService travelApi, BookingResult result)
{
    // TODO Exercise 3: Waiting for External Systems
    // Implement the code here to wait here for booking to be done
    return result;
}