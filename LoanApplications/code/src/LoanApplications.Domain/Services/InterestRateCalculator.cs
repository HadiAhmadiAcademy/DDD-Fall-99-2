using System.Threading.Tasks;
using LoanApplications.Domain.Model.LoanApplications;

namespace LoanApplications.Domain.Services
{
    public class InterestRateCalculator : IInterestRateCalculator
    {
        private readonly IScoreLookup _scoreLookup;
        public InterestRateCalculator(IScoreLookup scoreLookup)
        {
            _scoreLookup = scoreLookup;
        }

        public Task<InterestRate> CalculateInterestRateForApplicant(long applicantId)
        {
            var score = _scoreLookup.GetScoreOfApplicant(applicantId);

            //calculate the interest rate based on score

            return Task.FromResult(new InterestRate(0));
        }
    }
}