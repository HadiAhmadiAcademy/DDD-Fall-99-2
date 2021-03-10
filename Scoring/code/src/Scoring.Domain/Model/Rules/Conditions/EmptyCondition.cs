using Framework.Core.Specifications;
using Scoring.Domain.Model.Applicants;

namespace Scoring.Domain.Model.Rules.Conditions
{
    public class EmptyCondition : ISpecification<Applicant>
    {
        public static EmptyCondition Instance = new EmptyCondition();
        public bool IsSatisfiedBy(Applicant entity) => true;
    }
}