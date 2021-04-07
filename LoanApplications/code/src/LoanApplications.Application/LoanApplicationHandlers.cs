using System;
using System.Threading.Tasks;
using Framework.Application;
using LoanApplications.Application.Contracts.LoanApplications;
using LoanApplications.Domain.Model.LoanApplications;

namespace LoanApplications.Application
{
    public class LoanApplicationHandlers : ICommandHandler<PlaceLoanApplication>,
                                            ICommandHandler<RejectLoanApplication>,
                                            ICommandHandler<ConfirmLoanApplicationWithConsiderations>,
                                            ICommandHandler<ConfirmLoanApplication>,
                                            ICommandHandler<CancelLoanApplication>
    {
        private readonly ILoanApplicationRepository _repository;
        public LoanApplicationHandlers(ILoanApplicationRepository repository)
        {
            _repository = repository;
        }

        public  Task Handle(PlaceLoanApplication command)
        {
            var paybackPeriod = TimeSpan.FromDays(command.PaybackPeriodDays);
            var loanApplication = new LoanApplication(0, command.ApplicantId, command.LoanAmount, paybackPeriod);
            _repository.Add(loanApplication);
            return Task.CompletedTask;
        }

        public async Task Handle(RejectLoanApplication command)
        {
            var loanApplication = await _repository.Get(command.ApplicationId);
            loanApplication.Reject();
        }

        public async Task Handle(ConfirmLoanApplication command)
        {
            var loanApplication = await _repository.Get(command.ApplicationId);
            loanApplication.Confirm();
        }
        public async Task Handle(ConfirmLoanApplicationWithConsiderations command)
        {
            var loanApplication = await _repository.Get(command.ApplicationId);
            var paybackPeriod = TimeSpan.FromDays(command.PaybackPeriodDays);
            loanApplication.Confirm(command.LoanAmount, paybackPeriod);
        }

        public async Task Handle(CancelLoanApplication command)
        {
            var loanApplication = await _repository.Get(command.ApplicationId);
            loanApplication.Cancel();
        }
    }
}
