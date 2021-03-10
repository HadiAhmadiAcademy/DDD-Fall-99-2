using Framework.Core.Specifications;
using Scoring.Domain.Model.Applicants;

namespace Scoring.Domain.Model.Rules.Conditions
{
    public class PositionCondition : CompositeSpecification<Applicant>
    {
        public long TargetPositionId { get; private set; }
        public PositionCondition(long targetPositionId)
        {
            TargetPositionId = targetPositionId;
        }
        public override bool IsSatisfiedBy(Applicant applicant)
        {
            return applicant.PositionId == TargetPositionId;
        }
    }
}