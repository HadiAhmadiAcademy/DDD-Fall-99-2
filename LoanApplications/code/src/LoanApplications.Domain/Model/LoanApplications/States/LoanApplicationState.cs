using System;

namespace LoanApplications.Domain.Model.LoanApplications.States
{
    public abstract class LoanApplicationState
    {
        internal LoanApplicationState() { }
        public static LoanApplicationState InitialState()
        {
            return StatePool.GetState<PendingState>();
        }
        public virtual LoanApplicationState Confirm()
        {
            throw new NotSupportedException();
        }
        public virtual LoanApplicationState Reject()
        {
            throw new NotSupportedException();
        }
        public virtual LoanApplicationState Cancel()
        {
            throw new NotSupportedException();
        }
        public virtual LoanApplicationState FinalConfirm()
        {
            throw new NotSupportedException();
        }
        public virtual bool CanUpdate() => false;
    }
}