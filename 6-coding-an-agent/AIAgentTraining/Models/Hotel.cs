using System;
using System.Collections.Generic;
using System.Text;

namespace AIAgentTraining.Models
{
    public record Hotel(string Id, string City, string Name, decimal PricePerNight, decimal Rating, bool Available);
}
