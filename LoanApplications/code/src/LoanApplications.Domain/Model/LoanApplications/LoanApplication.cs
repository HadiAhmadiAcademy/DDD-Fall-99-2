using System;
using System.Collections.Generic;
using System.Text;
using Framework.Domain;
using LoanApplications.Domain.Model.LoanApplications.Exceptions;
using LoanApplications.Domain.Model.LoanApplications.States;

namespace LoanApplications.Domain.Model.LoanApplications
{
    public class LoanApplication : AggregateRoot<long>
    {
        public long ApplicantId { get; private set; }
        public long LoanAmount { get; private set; }
        public TimeSpan PaybackPeriod { get; private set; }
        //public double InterestRate { get; set; }
        public LoanApplicationState State { get; private set; }
        public LoanApplication(long id, long applicantId, long loanAmount, TimeSpan paybackPeriod) : base(id)
        {
            ApplicantId = applicantId;
            LoanAmount = loanAmount;
            PaybackPeriod = paybackPeriod;
            State = LoanApplicationState.InitialState();
        }
        public void Update(long loanAmount, TimeSpan paybackPeriod)
        {
            if (!this.State.CanUpdate()) throw new UpdateOnIllegalStateException();

            this.LoanAmount = loanAmount;
            this.PaybackPeriod = paybackPeriod;
        }
        public void Confirm()
        {
            this.Confirm(this.LoanAmount, this.PaybackPeriod);
        }
        public void Confirm(long loanAmount, TimeSpan paybackPeriod)
        {
            this.State = this.State.Confirm();
            this.LoanAmount = loanAmount;
            this.PaybackPeriod = paybackPeriod;
        }
        public void Reject()
        {
            this.State = this.State.Reject();
        }
        public void Cancel()
        {
            this.State = this.State.Cancel();
        }
        public void FinalConfirm()
        {
            this.State = this.State.FinalConfirm();
        }
    }
}
