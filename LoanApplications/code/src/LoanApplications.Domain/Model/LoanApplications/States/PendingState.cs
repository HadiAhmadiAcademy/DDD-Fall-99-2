namespace LoanApplications.Domain.Model.LoanApplications.States
{
    public class PendingState : LoanApplicationState
    {
        internal PendingState() { }

        public override LoanApplicationState Confirm()
        {
            return StatePool.GetState<ConfirmedState>();
        }
        public override LoanApplicationState Reject()
        {
            return StatePool.GetState<RejectedState>();
        }
        public override LoanApplicationState Cancel()
        {
            return StatePool.GetState<CancelledState>();
        }

        public override bool CanUpdate() => true;
    }
}