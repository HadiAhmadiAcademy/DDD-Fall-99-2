using System;
using System.Threading.Tasks;
using LoanApplications.Domain.Model.Shared;
using LoanApplications.Domain.Services;

namespace LoanApplications.ACL.Scoring
{
    public class HttpBasedScoreLookup : IScoreLookup
    {
        public Task<Score> GetScoreOfApplicant(long applicantId)
        {
            var score = 0;

            //Call rest api of scoring and get score of applicant

            //TODO: add retry-pattern
            //TODO: add Circuit-Breaker pattern

            return Task.FromResult(new Score(score));
        }
    }
}
