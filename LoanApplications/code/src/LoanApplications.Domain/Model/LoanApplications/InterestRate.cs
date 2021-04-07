using System;
using System.Collections.Generic;
using Framework.Domain;

namespace LoanApplications.Domain.Model.LoanApplications
{
    public class InterestRate : ValueObject<InterestRate>
    {
        public double Value { get; private set; }
        public InterestRate(double value)
        {
            if (value < 0) 
                throw new ArgumentOutOfRangeException(nameof(value),"interest rate should be zero or greater than zero");
            Value = value;
        }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}