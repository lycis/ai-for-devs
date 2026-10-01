# 2-Hour Hands-On Training: Building Reliable AI Agents in C#

**Audience:** Experienced C#/.NET developers with limited or mixed LLM experience  
**Format:** Pair programming or small groups, code-heavy, minimal slides  
**Core scenario:** A travel-booking agent working against a fake API  
**Primary stack:** Microsoft Agent Framework / `AIAgent`, `Microsoft.Extensions.AI`, Mistral via OpenAI-compatible endpoint  
**Main thesis:**

> An agent should own flexible judgment and decision-making. Deterministic software should own execution guarantees, state transitions, persistence, retries, scheduling, idempotency, and other behavior where correctness is defined.

A useful decision rule throughout the session is:

> **If there is a correct deterministic answer, prefer deterministic software. Use the agent where interpretation, ambiguity, or judgment is required.**

---

# Learning Objectives

By the end of the session, participants should be able to:

1. Explain the basic anatomy of an agent:
   - model
   - instructions
   - tools
   - context/state
   - execution loop

2. Expose normal C# functions as AI tools.

3. Design tool descriptions and parameters as an interface for the model.

4. Understand how an agent can select and combine multiple tools to pursue a goal.

5. Distinguish:
   - read operations
   - consequential/write operations

6. Enforce human approval outside the model.

7. Recognize when an agent should stop reasoning and let deterministic infrastructure take over.

8. Handle asynchronous external processes without making the model poll or wait.

9. Resume an agent when new external state becomes available.

10. Reason about:
    - partial failure
    - retries
    - idempotency
    - compensation
    - stale data

11. Allocate responsibility between:
    - Agent
    - Application/runtime
    - Human

12. Understand that the agent is a component inside a conventional software system, not the system itself.

---

# 0:00–0:10 — Cold Open: What Is an Agent?

## Live Demo

Start with the tiny travel assistant:

```csharp
var opts = new OpenAIClientOptions
{
    Endpoint = new Uri("https://api.mistral.ai/v1/")
};

var openAiClient = new OpenAIClient(
    new ApiKeyCredential(apiKey),
    opts);

AIAgent agent = openAiClient
    .GetChatClient("mistral-small-2603")
    .AsAIAgent(
        instructions:
        """
        You are a helpful travel assistant.

        Use tools when they can provide relevant information.
        Otherwise answer from your general knowledge.
        Never fabricate tool results.
        """,
        tools:
        [
            AIFunctionFactory.Create(GetWeather)
        ]);

var session = await agent.CreateSessionAsync();

Console.WriteLine(
    await agent.RunAsync(
        "What is the capital of Austria? This is where I am.",
        session));

Console.WriteLine(
    await agent.RunAsync(
        "How is the weather there?",
        session));
```

The tool:

```csharp
static string GetWeather(string city)
{
    Console.WriteLine($"[TOOL] Checking weather for {city}");

    return city.ToLowerInvariant() switch
    {
        "vienna" => "22 °C, sunny",
        "graz" => "19 °C, cloudy",
        _ => "Weather data unavailable"
    };
}
```

## Mental Model

Introduce:

```text
Agent =
Model
+ Instructions
+ Tools
+ Context
+ Execution Loop
```

Then immediately add the architectural correction:

> The model does not own your application state. Your system decides what context and capabilities it receives.

And introduce the three actors:

```text
Agent      → interpretation and flexible judgment
Runtime    → guarantees and deterministic execution
Human      → consequential or subjective decisions
```

## Discussion Prompt

> Who remembers that “there” means Vienna? The model, the agent framework, or our application?

---

# 0:10–0:30 — Build a Read-Only Travel Agent

## Goal

Turn a simple assistant into an agent that can research travel options by composing several tools.

## Provided

The starter project already contains:

```csharp
ITravelApi
```

with working methods:

```csharp
SearchDestinations(...)
SearchFlights(...)
SearchHotels(...)
```

The agent is already wired with:

```csharp
SearchDestinations
```

## Participant Task

Add:

```csharp
SearchFlights
SearchHotels
```

using:

```csharp
AIFunctionFactory.Create(...)
```

Then test with:

> I want a warm weekend destination next month from Vienna. My total budget is €1,000. Find me a reasonable option.

## What They Should Observe

The model may decide to:

```text
SearchDestinations
      ↓
SearchFlights
      ↓
SearchHotels
      ↓
compare options
      ↓
recommend
```

But it may also choose an unexpected order.

That is useful.

## Teaching Point

Tool definitions are effectively an API for the model.

The important interface is not only:

```csharp
Task<IEnumerable<Flight>> SearchFlights(...)
```

but:

```text
tool name
description
parameter names
parameter descriptions
return semantics
```

## Discussion Prompt

> If the model calls `SearchFlights` before it knows the destination, is that a model failure, an instruction problem, or a tool-design problem?

Then:

> How could you make the behavior more reliable without hardcoding the entire flow?

---

# 0:30–0:50 — Consequential Actions and Human Approval

## Introduce Write Operations

Add:

```csharp
BookFlight(...)
BookHotel(...)
```

Now ask:

> Should these be ordinary tools just like `SearchHotels`?

Use this to distinguish:

```text
Read capability
SearchHotels()

Consequential capability
BookHotel()
```

## Core Rule

Do not rely on:

```text
"Always ask before booking."
```

as the safety mechanism.

A prompt instruction is behavioral guidance.

It is not enforcement.

## Preferred Architecture

The model may decide:

```text
I want to call BookHotel(...)
```

But the runtime classifies that tool as requiring approval:

```text
Agent requests BookHotel(...)
        ↓
Runtime sees consequential capability
        ↓
Human approval
        ↓
Runtime executes
```

## Participant Task

Students add the booking capabilities behind a provided approval boundary.

They should only have to implement the decision wiring, not a large orchestration framework.

For example, starter code might expose:

```csharp
Task<T> ExecuteWithApproval<T>(
    string description,
    Func<Task<T>> action);
```

The student connects:

```text
BookHotel
BookFlight
```

to that boundary.

## Console Experience

```text
Agent proposes:
Book flight FL-42 to Palma for €219.

Approve? [y/n]
> y

[RUNTIME] Booking approved.
[API] Booking flight FL-42...
```

## Discussion Prompt

> The prompt says “ask before booking.” The model ignores that instruction and calls `BookHotel` anyway. What happens?

Desired answer:

> Nothing consequential unless the runtime approves and executes it.

That is the guardrail.

---

# 0:50–1:20 — The Async Wall

This is the central block of the workshop.

## Introduce the Problem

Change the fake API behavior:

```csharp
BookHotel(...)
```

returns:

```text
BookingId: H-1234
Status: Pending
```

The external booking system completes later.

Students also have:

```csharp
GetBookingStatus(string bookingId)
```

## Step 1 — Let the Naive Agent Try

Give the agent access to:

```csharp
GetBookingStatus
```

and ask the participants:

> Make the booking agent finish the hotel booking.

Do not explain the desired architecture yet.

Let them observe behavior such as:

```text
GetBookingStatus(H-1234)
→ Pending

GetBookingStatus(H-1234)
→ Pending

GetBookingStatus(H-1234)
→ Pending
```

or perhaps:

> “The booking should be confirmed shortly.”

Freeze the exercise.

Ask:

> What useful reasoning is the model doing while it waits?

Usually:

```text
none
```

Then:

> Why are we paying for an LLM to behave like `Thread.Sleep()`?

That is the reveal.

---

## Step 2 — Move Waiting Into the Runtime

Introduce the architecture:

```text
Agent
  ↓
BookHotel
  ↓
Pending + booking ID
  ↓
Application stores pending work
  ↓
Application waits / polls
  ↓
External state becomes terminal
  ↓
Agent resumes with new facts
```

## Provided Skeleton

Do not make participants build the whole infrastructure.

Provide:

```csharp
private async Task<BookingResult> WaitForBookingAsync(
    string bookingId,
    CancellationToken cancellationToken)
{
    while (!cancellationToken.IsCancellationRequested)
    {
        // TODO: retrieve booking status

        // TODO:
        // return when Confirmed or Failed

        await Task.Delay(
            TimeSpan.FromSeconds(1),
            cancellationToken);
    }

    throw new OperationCanceledException();
}
```

## Participant Task

They complete only the deterministic core:

```csharp
var status = await api.GetBookingStatus(bookingId);

if (status is Confirmed or Failed)
{
    return status;
}
```

Then resume the agent with a structured fact:

```csharp
await agent.RunAsync(
    """
    External booking update:

    Hotel booking H-1234 is now Confirmed.

    Continue the travel-planning task using this new fact.
    """,
    session);
```

For failure:

```csharp
await agent.RunAsync(
    """
    External booking update:

    Hotel booking H-1234 has Failed.

    The flight is already confirmed.

    Decide what should happen next.
    """,
    session);
```

## Key Teaching Point

> **Waiting is not reasoning.**

The agent can decide that something must happen later.

The runtime owns:

```text
when
how often
how long
what counts as terminal
what happens after a crash
```

## Discussion Prompt

> The agent says “I’ll check again in five minutes.” What is technically wrong with that sentence?

Potential answers:

- the model cannot schedule itself
- the process may terminate
- no durable state exists
- retries are not guaranteed
- many waiting agents would waste resources
- the model is not the clock
- the model should not own operational guarantees

---

# 1:20–1:35 — Partial Failure and Compensation

## Scenario

The fake API now returns:

```text
Flight: Confirmed
Hotel: Failed
```

This is intentionally not a clean transaction.

## Participant Task

Resume the agent with the facts:

```text
Flight FL-42 is confirmed.

Hotel booking H-789 failed.

Available actions:
- search for another hotel
- cancel the flight
- continue without accommodation
- ask the traveller
```

Ask the agent to recommend a next step.

## Important Boundary

Separate:

### Business judgment

```text
Should we search for another hotel?
Should we cancel the trip?
Is the alternative still acceptable?
```

Potentially agent/human territory.

### Deterministic compensation

```text
If policy requires rollback,
call CancelFlight exactly once.
```

Runtime territory.

## Human Boundary

If cancellation costs money or has material consequences:

```text
Agent proposes
      ↓
Human approves
      ↓
Runtime executes
```

## Discussion Prompt

> The flight is confirmed and the hotel failed. Which parts of the recovery have one objectively correct answer, and which require judgment?

That question is more useful than simply asking “agent or app?”

---

# 1:35–1:45 — Two Short Production Engineering Challenges

No coding required.

## Challenge 1 — Duplicate Requests

Ask:

> The user presses Enter twice and your application sends `BookHotel` twice. Should the agent remember that it already booked?

Answer:

No.

Introduce:

```csharp
BookHotel(
    string hotelId,
    string idempotencyKey);
```

Explain that idempotency belongs at the deterministic execution boundary.

## Challenge 2 — Stale Price

Search returned:

```text
Hotel: €85/night
```

Booking returns:

```text
Actual price: €110/night
```

Ask:

> Which value is authoritative?

The booking system.

Then:

> Should the agent automatically accept the increase?

That depends on policy and user constraints.

This creates a nice split:

```text
Runtime:
recognizes authoritative price

Agent:
interprets whether it still fits user's goal

Human/runtime policy:
decides whether approval is required
```

---

# 1:45–1:52 — HarnessAgent: What Changes?

Use this as a short contrast, not another exercise.

Show:

```csharp
AIAgent agent = chatClient.AsHarnessAgent(
    new HarnessAgentOptions
    {
        DisableWebSearch = true,

        ChatOptions = new ChatOptions
        {
            Instructions = "...",
            Tools = [...]
        }
    });
```

Explain:

```text
AIAgent
+ tools
+ session

HarnessAgent
+ planning
+ todo tracking
+ context management
+ longer-task infrastructure
```

But emphasize:

> Harness infrastructure does not replace your business workflow.

It does not magically make these disappear:

```text
persistence
scheduling
idempotency
transactions
approval policy
durable external-state handling
```

Use the current Mistral quirks as a quick provider-independence lesson:

- named agents caused Mistral 422 issues in multi-turn chat
- Harness hosted web search had to be disabled because it emits OpenAI-specific options

Takeaway:

> Abstraction reduces coupling. It does not erase provider behavior.

---

# 1:52–2:00 — Architecture Synthesis and Debrief

Put up the final architecture:

```text
                        USER
                         │
                         ▼
                    ┌─────────┐
                    │ AIAgent │
                    │         │
                    │ intent  │
                    │ compare │
                    │ decide  │
                    └────┬────┘
                         │
                    tool requests
                         │
                         ▼
               ┌──────────────────┐
               │ Application      │
               │ Runtime          │
               │                  │
               │ approvals        │
               │ persistence      │
               │ retries          │
               │ scheduling       │
               │ idempotency      │
               │ policy           │
               └────────┬─────────┘
                        │
              ┌─────────┴──────────┐
              ▼                    ▼
       Travel Booking API      Durable State
              │
              │
              ▼
       External Processes
              │
              │ event / poll
              ▼
      Runtime resumes agent
```

Human approval sits at the execution boundary:

```text
Agent requests consequential action
              ↓
Runtime policy
              ↓
Human approval
              ↓
Runtime executes
```

---

# Responsibility Allocation

| Capability | Owner | Why |
|---|---|---|
| Interpret user intent | Agent | Ambiguous/contextual |
| Compare destinations | Agent | Judgment |
| Choose next useful tool | Agent | Context-dependent |
| Explain recommendation | Agent | Flexible language |
| HTTP communication | Runtime | Deterministic |
| Authentication | Runtime | Security |
| Persistence | Runtime | System of record |
| Retry policy | Runtime | Reliability |
| Timeouts | Runtime | Reliability |
| Scheduling | Runtime | Clock-dependent |
| Polling | Runtime | Deterministic |
| Idempotency | Runtime | Must be enforced |
| Transaction boundaries | Runtime | Correctness |
| Technical rollback | Runtime | Defined behavior |
| Choose among recovery alternatives | Agent | Judgment |
| Approve spending | Human/policy | Consequential |
| Accept major price increase | Human/policy | Consequential |
| Subjective preference | Human | No objectively correct answer |

---

# Starter Solution

Participants should receive a solution that already runs.

## `Program.cs`

Contains:

- CLI/bootstrap
- Mistral configuration
- API-key loading
- session lifecycle
- basic logging
- scenario selection

Students do not spend time on setup.

---

## `TravelApi.cs`

Complete fake API implementation:

```csharp
SearchDestinations(...)
SearchFlights(...)
SearchHotels(...)
BookFlight(...)
BookHotel(...)
GetBookingStatus(...)
CancelBooking(...)
```

Includes deterministic scenario behavior.

Students do not modify this file.

---

## `Dtos.cs`

Provide all records/enums:

```csharp
Destination
Flight
Hotel
BookingRequest
BookingResult
BookingStatus
```

---

## `AgentSetup.cs`

Initially contains:

```csharp
SearchDestinations
```

as a configured tool.

Participants add:

```text
SearchFlights
SearchHotels
BookFlight
BookHotel
```

throughout the exercise.

---

## `ApprovalService.cs`

Provide the approval infrastructure:

```csharp
public interface IApprovalService
{
    Task<bool> RequestApprovalAsync(
        string description,
        CancellationToken cancellationToken);
}
```

with a simple console implementation.

Participants connect consequential tools to it rather than writing the whole mechanism.

---

## `BookingMonitor.cs`

Provide the skeleton:

```csharp
public async Task<BookingResult> WaitForBookingAsync(...)
{
    // TODO
}
```

Participants fill in the terminal-state logic.

---

## `PendingWorkStore.cs`

Provide a working in-memory store.

Do not make students write dictionary plumbing.

Conceptually:

```text
booking ID
user intent
session reference
created time
current status
```

---

# Fake API Dataset

Keep it deliberately tiny and inspectable.

## Destinations

For example:

```text
Palma
Lisbon
Barcelona
Athens
```

Include:

```text
temperature
typical weekend cost
tags
```

---

## Flights

Approximately 2 per destination.

Include trade-offs:

```text
cheap but inconvenient
expensive but direct
one slightly over budget
```

---

## Hotels

Approximately 2 per destination.

Include:

```text
price
location
rating
availability
cancellation conditions
```

The point is not data volume.

The point is giving the agent meaningful alternatives.

---

# Fake API Scenarios

## Scenario A — Happy Path

Everything succeeds.

---

## Scenario B — Pending Booking

```text
BookHotel
→ Pending

GetBookingStatus #1
→ Pending

GetBookingStatus #2
→ Pending

GetBookingStatus #3
→ Confirmed
```

Primary async exercise.

---

## Scenario C — Partial Failure

```text
Flight
→ Confirmed

Hotel
→ Failed
```

Primary recovery exercise.

---

## Scenario D — Price Changed

```text
Search price
→ €85/night

Booking price
→ €110/night
```

Discussion only.

---

## Scenario E — Duplicate Request

Booking API supports:

```text
IdempotencyKey
```

Discussion only or stretch task.

---

## Scenario F — Availability Changed

Flight succeeds.

Selected hotel is no longer available.

Stretch task for fast groups.

---

# Observability

Build logging into the starter solution.

Use clear prefixes:

```text
[USER]
[AGENT]
[TOOL]
[RUNTIME]
[HUMAN]
[API]
```

Example:

```text
[USER] Find me somewhere warm.

[AGENT] Calling SearchDestinations(...)

[TOOL] SearchDestinations(...)

[API] Returned Palma, Lisbon, Athens

[AGENT] Calling SearchFlights(...)

...

[AGENT] Requesting BookHotel(H42)

[RUNTIME] Action requires approval.

[HUMAN] Approved.

[API] H42 → Pending

[RUNTIME] Monitoring H42...

[API] H42 → Confirmed

[RUNTIME] Resuming agent.

[AGENT] Hotel confirmed. Finalizing plan.
```

This makes architectural boundaries visible instead of allowing everything to blur into “the AI did it.”

---

# What Participants Implement

Keep the coding focused on agent-design decisions.

They implement:

- wiring additional read tools
- tool descriptions
- agent instructions
- connecting consequential actions to approval
- completing a small deterministic poller
- agent resumption after external state change
- recovery reasoning after partial failure

They should **not** spend significant time implementing:

- HTTP servers
- DTOs
- fake data
- persistence infrastructure
- CLI plumbing
- authentication
- logging
- generic retry frameworks

---

# Stretch Tasks

For faster groups:

### Stretch 1 — Idempotency

Add an idempotency key to booking operations.

### Stretch 2 — Hotel Becomes Unavailable

Flight confirmed, hotel disappears.

Ask the agent to recover.

### Stretch 3 — Unit Test the Poller

No model involved.

Test:

```text
Pending
Pending
Confirmed
```

### Stretch 4 — Swap Provider

Replace Mistral with another `IChatClient` backend.

Discuss what actually changes.

---

# Key Discussion Questions

Use these throughout the session.

### Tools

> Is the model using the tool incorrectly, or have we given it a bad interface?

### Approval

> Can a prompt instruction ever be a hard security boundary?

### Async

> What useful reasoning is happening while the booking is Pending?

### Persistence

> What happens if the process crashes while ten bookings are Pending?

### Idempotency

> Should the agent remember not to book twice, or should the API make duplicate execution impossible?

### Partial Failure

> Which recovery steps have a correct answer, and which require judgment?

### Provider Independence

> What does a provider abstraction actually guarantee, and what does it not guarantee?

### Production Design

> If we removed the LLM, which parts of this system should still be fully unit-testable?

---

# Final Takeaway

The intended conceptual progression is:

```text
1. Wow:
   The model can choose and compose tools.

2. Friction:
   The model is bad at owning waiting, guarantees,
   approvals, persistence, and reliability.

3. Architecture:
   The agent is one component inside a normal,
   well-engineered software system.
```

The sentence participants should leave with is:

> **Use agents where flexibility is valuable. Use deterministic software where correctness is knowable and must be guaranteed.**