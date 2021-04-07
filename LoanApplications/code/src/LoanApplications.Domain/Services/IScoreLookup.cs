using System.Threading.Tasks;
using LoanApplications.Domain.Model.Shared;

namespace LoanApplications.Domain.Services
{
    public interface IScoreLookup
    {
        Task<Score> GetScoreOfApplicant(long applicantId);
    }
}