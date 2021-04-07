using System.Threading.Tasks;
using Framework.Domain;

namespace LoanApplications.Domain.Model.LoanApplications
{
    public interface ILoanApplicationRepository : IRepository
    {
        Task<LoanApplication> Get(long id);
        void Add(LoanApplication loanApplication);
    }
}