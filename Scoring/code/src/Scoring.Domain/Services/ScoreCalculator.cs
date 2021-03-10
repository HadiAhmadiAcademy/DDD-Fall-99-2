using System.Linq;
using System.Threading.Tasks;
using Scoring.Domain.Model.Applicants;
using Scoring.Domain.Model.Rules;

namespace Scoring.Domain.Services
{
    public class ScoreCalculator : IScoreCalculator
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IRuleRepository _ruleRepository;
        public ScoreCalculator(IApplicantRepository applicantRepository,
                                IRuleRepository ruleRepository)
        {
            _applicantRepository = applicantRepository;
            _ruleRepository = ruleRepository;
        }

        public async Task<long> GetScoreOfApplicant(long applicantId)
        {
            var applicant = await _applicantRepository.Get(applicantId);
            var activeRules = await _ruleRepository.GetActiveRules();
            return activeRules.Sum(a => a.GetPointsFor(applicant));
        }
    }
}