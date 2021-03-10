using System.Threading.Tasks;

namespace Scoring.Domain.Services
{
    public interface IScoreCalculator
    {
        Task<long> GetScoreOfApplicant(long applicantId);
    }
}