namespace LoanApplications.Domain.Model.LoanApplications.States
{
    public class ConfirmedState : LoanApplicationState
    {
        public override LoanApplicationState FinalConfirm()
        {
            return StatePool.GetState<FinalConfirmedState>();
        }
        public override LoanApplicationState Cancel()
        {
            return StatePool.GetState<CancelledState>();
        }
    }
}