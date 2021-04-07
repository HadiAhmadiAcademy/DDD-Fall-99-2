using System;
using System.Collections.Generic;
using System.Text;
using Framework.Domain;

namespace LoanApplications.Domain.Model.Shared
{
    public class Score : ValueObject<Score>
    {
        public long Value { get; private set; }
        public Score(long value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return this.Value;
        }
    }
}
