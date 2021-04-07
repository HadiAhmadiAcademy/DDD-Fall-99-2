using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.Specifications;
using Framework.Domain;
using Scoring.Domain.Model.Applicants;
using Scoring.Domain.Model.Rules.CalculationMethods;
using Scoring.Domain.Model.Rules.Conditions;

namespace Scoring.Domain.Model.Rules
{
    public class Rule : AggregateRoot<Guid>
    {
        public string Title { get; private set; }
        public ISpecification<Applicant> Condition { get; private set; }
        public CalculationMethod CalculationMethod { get; private set; }
        public bool IsActive { get; private set; }
        public DateRange ActivePeriod { get; private set; }
        public Rule(string title, DateRange activePeriod, ISpecification<Applicant> condition, CalculationMethod calculationMethod) : base(Guid.NewGuid())
        {
            Title = title;
            Condition = condition;
            CalculationMethod = calculationMethod;
            ActivePeriod = activePeriod;
            IsActive = true;
        }
        public Rule(string title, DateRange activePeriod, CalculationMethod calculationMethod) 
            : this(title, activePeriod, EmptyCondition.Instance, calculationMethod)
        {
        }


        public void Activate()
        {
            this.IsActive = true;
        }
        public void Deactivate()
        {
            this.IsActive = false;
        }
        public long GetPointsFor(Applicant applicant)
        {
            if (!IsActive) return 0;
            if (!ActivePeriod.IsInRange(DateTime.Now)) return 0;
            if (!Condition.IsSatisfiedBy(applicant)) return 0;

            return CalculationMethod.Calculate();
        }
    }
}