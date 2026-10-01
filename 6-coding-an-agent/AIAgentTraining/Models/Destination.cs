using System;
using System.Collections.Generic;
using System.Text;

namespace AIAgentTraining.Models
{
    public record Destination(string Id, string Name, string Country, int TemperatureCelsius, decimal TypicalWeekendCost);
}
