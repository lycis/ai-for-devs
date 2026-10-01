# AI Agent Development in C#

This module is a hands-on introduction to building AI agents as part of a well-engineered .NET application.

You will build a small travel assistant that can search travel options, propose bookings, request human approval, and deal with external booking state.

The central idea is:

> **Use agents where flexibility and judgment are valuable. Use deterministic software where correctness can be known and enforced.**

## Project

All exercises happen inside:

```text
AIAgentTraining/
```

The starter project already contains:

- the fake travel API
- travel DTOs
- agent setup
- approval infrastructure
- booking scenarios
- the console application

Your task is to extend the agent and complete selected parts of the application logic.

## Setup

From the project directory:

```bash
cd AIAgentTraining
dotnet restore
```

Create a `.env` file:

```env
MISTRAL_API_KEY=your-api-key
```

Then run:

```bash
dotnet run
```

The project uses:

- C#
- .NET
- Microsoft Agent Framework
- `Microsoft.Extensions.AI`
- Mistral via its OpenAI-compatible API
- `mistral-small-2603`

Do not commit your `.env` file.

---

# Exercise 1: Build the Travel Agent

The starter agent can search destinations.

Add the remaining read-only tools:

```text
SearchFlights
SearchHotels
```

Use `AIFunctionFactory.Create(...)` to expose the existing methods from `TravelService`.

Try prompts such as:

> I want a warm weekend destination from Vienna with a total budget of €1,000. Find me a reasonable option.

The agent may decide to:

```text
Search destinations
        ↓
Search flights
        ↓
Search hotels
        ↓
Compare options
        ↓
Recommend
```

The sequence is not hardcoded.

### Think about

- Are your tool names clear?
- Are parameter names meaningful?
- Which facts should come from tools rather than the model?
- What happens when tool descriptions are ambiguous?

---

# Exercise 2: Add Booking

Now expose booking functionality:

```text
BookFlight
BookHotel
```

Booking is different from searching because it has consequences.

The important rule is:

> **A prompt instruction is not an approval mechanism.**

Instead, booking requests must go through the provided `ApprovalService`.

The intended flow is:

```text
Agent requests booking
        ↓
ApprovalService stores request
        ↓
Human approves or rejects
        ↓
Application executes action
```

The agent may request an action, but it must not be able to bypass the approval boundary.

### Think about

- Which actions require approval?
- Who decides whether an operation is consequential?
- Which values should the model supply?
- Which values should your application retrieve authoritatively?

---

# Exercise 3: Waiting for External Systems

Bookings may not complete immediately.

Depending on the configured scenario:

```text
BookHotel(...)
→ Pending
```

The application can query:

```csharp
GetBookingStatus(bookingId)
```

Complete:

```csharp
WaitForBookingToFinish(...)
```

The method should:

1. query the booking status
2. wait while the status is `Pending`
3. stop when the booking reaches a terminal state
4. return the final result

The important architectural boundary is:

```text
Agent
  │
  │ decides what should happen
  ▼
Runtime
  │
  │ waits / polls
  ▼
Travel API
```

> **Waiting is not reasoning.**

In a production application this might use asynchronous workers, callbacks, queues, or durable workflows. For this exercise, keep it simple.

---

# Exercise 4: Failure and Recovery

The fake API supports a scenario where:

```text
Flight → Confirmed
Hotel  → Failed
```

The agent now receives an imperfect real-world situation.

Possible responses include:

- search for another hotel
- cancel the flight
- keep the flight
- ask the user what to do

The distinction matters:

```text
Agent
→ proposes a recovery strategy

Human / policy
→ approves consequential decisions

Runtime
→ performs the requested actions reliably
```

### Think about

Which parts require judgment, and which have a deterministic correct implementation?

For example:

```text
Should we search for another hotel?
```

may require judgment.

But:

```text
Cancel booking F-0001 exactly once
```

is a runtime responsibility.

---

# Travel API Scenarios

`TravelService` supports three deterministic scenarios:

### `HappyPath`

```text
Flight → Confirmed
Hotel  → Confirmed
```

### `DelayedBookingConfirmation`

A booking remains pending for several status checks:

```text
Pending
Pending
Confirmed
```

### `FailedHotelBooking`

```text
Flight → Confirmed
Hotel  → Failed
```

Use `TravelService.SetScenario(...)` to switch between them.

---

# Responsibility Model

| Responsibility | Owner |
|---|---|
| Interpret user intent | Agent |
| Compare alternatives | Agent |
| Select useful tools | Agent |
| Explain recommendations | Agent |
| Query authoritative systems | Runtime / Tools |
| Wait and poll | Runtime |
| Retries and timeouts | Runtime |
| Persistence | Runtime |
| Idempotency | Runtime |
| Execute transactions | Runtime |
| Approve consequential actions | Human / Policy |
| Choose between subjective alternatives | Agent / Human |

A useful design question is:

> **Can ordinary software determine and enforce the correct result?**

If yes, prefer deterministic code.

If the problem involves ambiguity, interpretation, incomplete information, or contextual judgment, an agent may be useful.

---

# Takeaway

The progression of the exercise is intentional:

```text
1. The agent can choose and compose tools.

2. Consequential actions need boundaries.

3. Waiting and reliability belong outside the model.

4. The agent becomes one component
   inside a conventional software system.
```

> **Use agents where flexibility is valuable. Use deterministic software where correctness can be known and guaranteed.**