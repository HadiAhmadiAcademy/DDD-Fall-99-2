using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scoring.Domain.Model.Rules
{
    public interface IRuleRepository
    {
        void Add(Rule rule);
        Task<List<Rule>> GetActiveRules();
    }
}