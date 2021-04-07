using System.Threading.Tasks;
using LoanApplications.Domain.Model.LoanApplications;

namespace LoanApplications.Domain.Services
{
    //TODO: add IDomainServiceInterface
    public interface IInterestRateCalculator
    {
        Task<InterestRate> CalculateInterestRateForApplicant(long applicantId);
    }
}