using System;
using System.Collections.Generic;
using System.Text;

namespace AIAgentTraining.Models
{
    public record Flight(string Id, string From, string To, DateTime Departure, DateTime Arrival, decimal Price);
}
