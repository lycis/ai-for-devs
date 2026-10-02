# Modul 6: Building Your First AI Agent

**120 Minuten**, Coding-Workshop in Zweier- oder Dreiergruppen mit einem C#-Reiseassistenten. Leitfrage: Was ändert sich, wenn wir Anwendungen mit LLMs und Agenten bauen?

- [Starterprojekt](AIAgentTraining/)
- [Kopierbare Aufgaben und Beobachtungsbogen](arbeitsblatt-modul-6.md)
- [Trainerleitfaden](Trainer/modul-6-leitfaden.md)
- [Lösungshinweise für Trainer](Trainer/Solutions.md)
- [Ursprüngliche ausführliche Outline](Trainer/LESSON_PLAN.md)

## Ablauf

| Zeit | Phase | Material |
| --- | --- | --- |
| 00:00–00:10 | Einstieg: Was ist ein Agent? | Starter und Demo |
| 00:10–00:30 | Runde 1: Read-only Travel Agent | Arbeitsblatt, AgentFactory.cs |
| 00:30–00:50 | Runde 2: Buchung mit menschlicher Freigabe | Arbeitsblatt, Approval/ und Program.cs |
| 00:50–01:20 | Runde 3: Externe Zustände und Warten | Arbeitsblatt, Program.cs und BookingMonitor.cs |
| 01:20–01:35 | Runde 4: Teilfehler und Recovery | Arbeitsblatt, FailedHotelBooking |
| 01:35–01:45 | Produktionsfragen: Duplikate und Preisänderung | Arbeitsblatt, Diskussion |
| 01:45–01:52 | Agent Harness und Providergrenzen | Trainerimpuls |
| 01:52–02:00 | Architekturvergleich und Transfer | Arbeitsblatt |

## Vorbereiten und starten

Voraussetzungen: .NET-10-SDK, C#-Entwicklungsumgebung und freigegebener Mistral-Zugang. Das Starterprojekt verwendet Microsoft Agent Framework und `Microsoft.Extensions.AI`; Modell und Endpoint stehen in `AgentFactory.cs`.

Aus dem Repositoryroot:

```powershell
cd 6-coding-an-agent/AIAgentTraining
dotnet restore
Copy-Item .env.example .env
# In .env den eigenen MISTRAL_API_KEY eintragen.
dotnet run
```

Eine bestehende `.env` behalten. API-Key nicht in Prompts, Arbeitsblätter oder Git übernehmen. `exit` beendet die Konsole. Die Travel API enthält fiktive Daten; Modellaufrufe gehen an den konfigurierten Provider.

Das Arbeitsblatt kann über einen Markdown-Editor gedruckt oder als PDF exportiert werden. Für Modul 6 liegt derzeit keine MARP-Präsentation vor; der Trainer führt mit Starterprojekt und Leitfaden durch die Phasen.

## Entscheidungen für das Review

- Deutsch wie Modul 2, englische Modulnamen und API-Bezeichner bleiben erhalten.
- Die vier Übungen bauen im selben Projekt aufeinander auf. Rollen pro Runde wechseln und Änderungen beziehungsweise Beobachtungen sichern.
- Setup vor dem Workshop prüfen. Die 120 Minuten enthalten keine separate Pause; für eine Pause den Ablauf bewusst anpassen.
- Modell interpretiert und empfiehlt, Runtime führt aus und wartet, Mensch beziehungsweise Policy entscheidet über folgenreiche Aktionen.
- `Program.cs` enthält den Polling-TODO. `BookingMonitor.cs` ist bereits implementiert und dient als Vergleich oder alternative Integration.
- Die drei implementierten Szenarien sind `HappyPath`, `DelayedBookingConfirmation` und `FailedHotelBooking`. Preisänderung und Idempotenz sind Diskussionsfälle, keine vorhandenen Szenarien.
- Der Starter speichert nur eine ausstehende Freigabe. Buchungen einzeln anfordern; Queue, Persistenz und robuste Wiederaufnahme sind Erweiterungen.
- Der [Trainerleitfaden](Trainer/modul-6-leitfaden.md) ist maßgeblich. Die ursprüngliche Outline enthält weitergehende Entwürfe, die nicht vollständig im Starter umgesetzt sind.

Grundlage ist das [Curriculum](../Curriculum.md). Kernprinzip: Agenten dort einsetzen, wo Interpretation und Abwägung helfen; bekannte Regeln und Ausführungsgarantien in deterministischem Code verankern.
