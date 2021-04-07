using Framework.Domain;

namespace LoanApplications.Domain.Model.LoanApplications
{
    public interface ILoanApplicationRepository : IRepository
    {
        LoanApplication Get(long id);
        void Add(LoanApplication loanApplication);
    }
}