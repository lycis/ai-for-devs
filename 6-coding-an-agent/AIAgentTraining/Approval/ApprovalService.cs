using System;
using System.Collections.Generic;
using System.Text;

namespace AIAgentTraining.Approval
{
    public class ApprovalService
    {
        public PendingApproval? PendingApproval { get; private set; }

        public void RequestApproval(PendingApproval approval)
        {
            PendingApproval = approval;
        }

        internal void ClearPendingApproval()
        {
            PendingApproval = null;
        }
    }
}
