Yes. With the latest decisions, I’d simplify the whole module around one clear experimental progression:

> **Round 1: Let the agent decide.**  
> **Round 2: Control the next step.**  
> **Round 3: Control the environment as well.**

The dojo is not about finishing FairShare. It is about repeatedly starting from zero and observing how the development experience changes as we introduce more deliberate control.

# Module 2: AI-Assisted Coding, Staying in Control

**Duration:** 2 hours  
**Format:** Coding dojo in pairs or groups of three  
**Tool:** GitHub Copilot Agent Mode, with alternatives possible  
**Application:** FairShare, a small expense-splitting application  
**Main learning question:** *How can we use a coding agent productively without handing over the engineering decisions?*

The three rounds should use roughly the same amount of coding time. That is important because we want participants to compare the experience, not race toward a finished product.

| Time | Phase | What happens |
|---|---|---|
| 00:00–00:10 | Setup | Explain dojo, FairShare and observation criteria |
| 00:10–00:25 | Round 1: One-shot | Start from zero, give only the product idea |
| 00:25–00:35 | Reflection 1 | Inspect what happened and who made which decisions |
| 00:35–00:45 | Input: Elephant Carpaccio | Introduce thin vertical slicing |
| 00:45–01:05 | Round 2: Slice & build | Start from zero, work through small useful increments |
| 01:05–01:15 | Reflection 2 | Compare one-shot vs. sliced development |
| 01:15–01:25 | Input: Context Engineering | Introduce persistent project instructions |
| 01:25–01:45 | Round 3: Context + slices | Start from zero again, define project context, then code incrementally |
| 01:45–01:57 | Final comparison | Compare all three experiences and inspect code smells |
| 01:57–02:00 | Close | Derive principles and bridge to Module 3 |

---

# 00:00–00:10: Set up the dojo

The first thing I would establish is that this is explicitly **not a build challenge**.

Tell them something along the lines of:

> We are going to start the same application three times. You are not expected to finish it. The interesting part is how the experience and the resulting code change depending on how we work with the agent.

Then introduce FairShare with deliberately little detail.

### Slide 1: AI-Assisted Coding: Staying in Control

Large central question:

> **How much should the coding agent decide for us?**

### Slide 2: Today is a coding dojo

Show the experimental setup:

```text
Same idea
Same people
Same coding agent

Three different ways of working
```

Then explicitly:

> We optimize for learning, not completion.

### Slide 3: FairShare

Use only this requirement:

> **FairShare is a small application for splitting shared expenses between friends.**
>
> Users should be able to add people, record shared expenses, specify who paid and who participated, see current balances, and determine who should pay whom to settle the group.

No stack. No architecture. No UI prescription. No persistence decision.

That ambiguity is the experiment.

### Slide 4: What should we observe?

Give every team four dimensions to keep in mind throughout all three rounds:

| Dimension | Question |
|---|---|
| **Progress** | How much visible functionality appeared? |
| **Understanding** | How well do we understand the resulting code? |
| **Control** | How many important decisions did we consciously make? |
| **Noise** | How much unnecessary code, scope or complexity appeared? |

I would not ask them to assign numerical scores during coding. Just have these questions visible, then let them rate the rounds during the reflections.

---

# 00:10–00:25: Round 1, One-shot FairShare

Everybody starts from an **empty folder**.

No repository template. No framework. No existing source code.

They give the agent essentially this:

> Build a small application called FairShare for splitting expenses between a group of friends.
>
> Users should be able to add people, record shared expenses, specify who paid and who participated, see current balances, and determine who should pay whom to settle the group.
>
> Build a usable version of the application.

And then let it work.

The important instruction from you is:

> **Don't try to steer it yet. See where it goes.**

They can respond to genuine questions from the agent, but they should resist turning the round into a careful engineering conversation.

### Slide 5: Round 1, One-shot it

Show the prompt and:

> **15 minutes**
>
> Let the agent decide how to get there.

During the exercise, walk around and observe what happens.

You're looking for things like technology choices, generated architecture, dependencies, styling, persistence, abstractions, and assumptions.

Some groups may get a polished web app. Someone might end up with Flask. Someone else React. Somebody's Copilot may decide that expense splitting requires Docker and a database cluster from Mordor.

Excellent.

---

# 00:25–00:35: Reflection 1

Do not start with criticism.

Start with:

> **What was surprisingly good?**

Modern coding agents may produce a lot in fifteen minutes. Acknowledge that.

Then shift:

> **What decisions did the AI make that you didn't make?**

Collect examples on a board.

Technology. Architecture. Data structure. State management. Persistence. Dependencies. Error handling. UI framework. File structure.

Then ask:

> If this were a pull request, how confident would you feel approving it?

This leads into the key distinction:

### Slide 6: Working code ≠ controlled engineering

Something like:

```text
The agent delivered an outcome.

But who designed the path to that outcome?
```

The lesson is not:

> One-shot prompting doesn't work.

It clearly can.

The lesson is:

> **The larger the task, the more engineering decisions we implicitly delegate.**

---

# 00:35–00:45: Introduce Elephant Carpaccio

Now introduce the first control mechanism.

### Slide 7: The Elephant

```text
"Build FairShare"
```

That is a perfectly reasonable product goal.

But it is a huge **agent task**.

Then:

### Slide 8: Slice the elephant

Introduce the idea of **small useful vertical increments**.

Use FairShare directly.

A technical decomposition might be:

```text
Create model
Create service
Create UI
Create repository
```

That is small-ish work, but not really Elephant Carpaccio.

Contrast it with:

> Alice paid €20 for dinner shared with Bob.  
> The application shows that Bob owes Alice €10.

That is tiny but meaningful and end-to-end.

### Slide 9: How thin is useful?

This is the key question for Round 2:

> **How small can the next step become while it still represents meaningful progress?**

Explicitly warn against turning this into microscopic task decomposition.

“Create `Expense.ts`” is small.

It is not necessarily useful.

The idea is:

> **Small enough to understand and review. Big enough to mean something.**

---

# 00:45–01:05: Round 2, Slice and build

Everybody starts from **zero again**.

Completely empty folder.

First, give them a few minutes to decide their first several slices.

Do not provide the correct slicing beforehand.

One team might choose:

```text
1. Fixed Alice and Bob, €20 dinner → show Bob owes Alice €10
2. Let the amount be entered
3. Let the names be entered
4. Choose the payer
5. Add another participant
...
```

Another team may choose something different.

That's useful.

Then they start coding.

The rule is simple:

> **Give the agent only the current slice.**

A prompt might be:

> Implement only this increment:
>
> Alice paid €20 for dinner shared equally with Bob. Show that Bob owes Alice €10.
>
> Do not implement later FairShare functionality yet.

Then the next slice.

And the next.

No requirement to finish.

### Slide 10: Round 2, Small useful increments

Show the loop:

```text
Choose next useful slice
        ↓
Give it to the agent
        ↓
Inspect what changed
        ↓
Run it
        ↓
Accept / redirect
        ↓
Choose next slice
```

There is one question I would keep permanently visible:

> **Would you accept this change before moving on?**

Not “is FairShare finished?”

Not even merely “does it run?”

Would you accept *this change*?

That is the beginning of control.

And importantly, I would still **not introduce TDD here**. Compilation, execution, manual inspection and diff review are enough. Tests become the stronger automated feedback mechanism in Module 3.

---

# 01:05–01:15: Reflection 2

Now compare the experiences, not just the code.

### Slide 11: Round 1 vs. Round 2

Put the four dimensions back up:

| | One-shot | Sliced |
|---|---|---|
| Progress | ? | ? |
| Understanding | ? | ? |
| Control | ? | ? |
| Noise | ? | ? |

Let the participants fill this in through discussion.

Interesting questions:

> Did Round 2 feel slower?

Probably.

> Did you understand more of what was happening?

Likely.

> When did the AI still make decisions you weren't happy with?

This last question is your bridge to Round 3.

Because slicing controls **what happens next**.

It does not necessarily control **how the software should be built**.

### Slide 12: We controlled WHAT. What about HOW?

Something like:

```text
ROUND 2

Developer:
"Implement this next behaviour."

Agent:
"Sure. I'll decide how."
```

Now we're ready for context engineering.

---

# 01:15–01:25: Introduce persistent project context

Start with a group question:

> Even with small slices, what decisions was the agent still making for you?

You'll likely get:

technology, architecture, dependency choices, naming, coding style, abstractions, state management.

Then:

> What if we define those decisions once, before we start coding?

Introduce repository-level instructions.

Because this is a GitHub Copilot workshop, I would use:

```text
.github/copilot-instructions.md
```

Then briefly mention that `AGENTS.md` is another increasingly common agent-oriented mechanism, especially if you want the concept to transfer beyond Copilot.

But don't turn this into a configuration lecture.

### Slide 13: From prompts to project context

Use this distinction:

```text
PROMPT
What do I want next?

PROJECT CONTEXT
How do we build software here?
```

That's probably one of the most important slides in the module.

### Slide 14: What belongs in project context?

Four areas:

| Area | Examples |
|---|---|
| Technology | language, framework, runtime |
| Architecture | responsibility boundaries, layering |
| Coding guidelines | simplicity, naming, reuse |
| Agent boundaries | scope, dependencies, unrelated changes |

Then make an important point:

> **The goal isn't more context. It's relevant, stable context.**

---

# 01:25–01:45: Round 3, Context + slices

Again:

**empty folder.**

No existing FairShare.

This time the first task is **not coding**.

Give the groups around five minutes to decide what kind of software they want to build and create:

```text
.github/copilot-instructions.md
```

You can give them a skeleton, but not the decisions.

For example:

```markdown
# FairShare Project Instructions

## Technology

## Architecture

## Coding Guidelines

## Scope and Agent Behaviour
```

Now they have to fill it.

One team may decide:

```markdown
## Technology
- Use React and TypeScript.
- Keep data in memory.
- Do not create a backend.
```

Another might choose plain HTML and JavaScript.

Another could deliberately choose Python.

That's fine.

The important thing is:

> **This time the humans made the decision.**

Then they work exactly as they did in Round 2.

Small vertical slice.

Agent implements it inside the project context.

Next slice.

Continue until the timer ends.

### Slide 15: Round 3, Define the world first

Visual:

```text
Project instructions
 technology
 architecture
 coding conventions
 boundaries
       │
       ▼
     Agent  ◄── small current slice
       │
       ▼
     Code
```

And underneath:

> **Stable information lives in the environment.  
> Current intent lives in the prompt.**

That is the central context-engineering lesson.

---

# 01:45–01:57: Compare all three

This should be the richest discussion of the session.

### Slide 16: Three ways of working

| Round | Developer controls |
|---|---|
| **1. One-shot** | Desired outcome |
| **2. Sliced** | Outcome + next step |
| **3. Contextualized** | Outcome + next step + technical decision space |

Then bring back the four observation dimensions one final time.

Let teams compare their own experience:

> Which round produced the fastest visible result?

> In which round did you understand the code best?

> In which round did you feel most able to redirect the agent?

> Where did unnecessary code appear?

> Did project instructions ever become too restrictive?

> Did slicing ever become too small?

This prevents the conclusion from turning into:

> Round 3 good, Round 1 bad.

Sometimes one-shotting is entirely sensible.

If I ask an agent to create a disposable script or prototype, I may happily let it make many decisions.

The skill is knowing **how much control the situation warrants**.

---

# Add a short AI Code Smell Safari here

This is also where I would explicitly connect back to the module announcement.

### Slide 17: What did the agent leave behind?

Have the groups look briefly for:

- **Scope creep:** functionality they did not ask for
- **Code bloat:** much more code than the behaviour justified
- **Premature abstraction:** interfaces, factories, layers or patterns without current need
- **Duplication:** a new implementation of something already present
- **Speculative complexity:** solving imagined future requirements

This should stay quick, perhaps five minutes embedded into the final comparison.

We're not teaching refactoring yet. We're training the eye.

---

# 01:57–02:00: Closing

I would end with three rather than five or ten principles, because they map exactly onto the three rounds.

### Slide 18: Staying in control

> **1. Control the size of the next decision.**  
> Work in the smallest useful increments.
>
> **2. Control the technical decision space.**  
> Give the agent persistent architecture, technology and coding context.
>
> **3. Keep reviewing what the agent introduces.**  
> Progress is useful only while you still understand and own the software.

Then bridge directly to Module 3.

Something like:

> Today our feedback loop was mostly human:
>
> **change → inspect → run → decide**
>
> That's better than blindly generating the whole application.
>
> But we can make the feedback much faster and more objective.

Then reveal:

> **Module 3: Tests as an AI Harness**

---

# Slide deck shape

That gives us a relatively lean deck of about **18 slides**, but many are exercise instructions or discussion canvases rather than lecture material:

| Slides | Purpose |
|---|---|
| 1–4 | Setup, FairShare, experiment |
| 5–6 | Round 1 + reflection |
| 7–10 | Carpaccio + Round 2 |
| 11–12 | Reflection and transition |
| 13–15 | Context engineering + Round 3 |
| 16–17 | Final comparison and code smells |
| 18 | Takeaways |

That is exactly where I would want the ratio to be.

The slides create **rhythm**, not content density.

The content happens in the code.

---

## The conceptual arc

If I reduced the entire module to one picture, it would now be:

```text
ROUND 1
Goal
  ↓
Agent decides the path


ROUND 2
Goal
+ small useful increments
  ↓
Developer controls the path


ROUND 3
Goal
+ small useful increments
+ persistent technical context
  ↓
Developer controls the path
and defines the terrain
```

That feels much more coherent than our earlier version.

And it gives Module 2 a very distinct identity:

> **Not “How do I get Copilot to write better code?”**

but:

> **“How do I design the collaboration so that I remain the engineer?”**

That is the session I would build.