using System;
using System.Collections.Generic;
using System.Text;

namespace AIAgentTraining.Models
{
    public enum BookingStatus
    {
        Pending,
        Confirmed,
        Failed,
        Cancelled
    }

    public record BookingResult(string BookingId, BookingStatus Status, decimal Price);
}
