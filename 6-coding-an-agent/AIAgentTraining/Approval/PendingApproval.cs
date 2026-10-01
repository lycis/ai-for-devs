using AIAgentTraining.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIAgentTraining.Approval
{
    public record PendingApproval(string Description, Func<Task<BookingResult>> Action);
}
