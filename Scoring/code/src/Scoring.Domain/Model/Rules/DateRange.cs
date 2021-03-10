using System;
using System.Collections.Generic;
using Framework.Domain;

namespace Scoring.Domain.Model.Rules
{
    public class DateRange : ValueObject<DateRange>
    {
        public DateTime? StartDate { get;private  set; }
        public DateTime? EndDate { get;  private set; }
        protected DateRange() { }
        public DateRange(DateTime? startDate, DateTime? endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
        public bool IsInRange(DateTime dateTime)
        {
            return this.StartDate >= dateTime && this.EndDate <= dateTime;
        }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return StartDate;
            yield return EndDate;
        }
    }
}