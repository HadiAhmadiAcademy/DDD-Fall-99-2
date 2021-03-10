using System;
using Framework.Core.Specifications;
using Scoring.Domain.Model.Applicants;

namespace Scoring.Domain.Model.Rules.Conditions
{
    public class HireDateCondition : CompositeSpecification<Applicant>
    {
        public DateTime TargetHireDate { get;private set; }
        public HireDateCondition(DateTime targetHireDate)
        {
            TargetHireDate = targetHireDate;
        }
        public override bool IsSatisfiedBy(Applicant applicant)
        {
            return applicant.HireDate <= TargetHireDate;
        }
    }
}