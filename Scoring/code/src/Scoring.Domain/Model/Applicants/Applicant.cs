using System;
using Framework.Domain;

namespace Scoring.Domain.Model.Applicants
{
    public class Applicant : AggregateRoot<long>
    {
        public string Fullname { get; set; }
        public DateTime HireDate { get; private set; }
        public long PositionId { get; private set; }
        public Applicant(long id, string fullname, DateTime hireDate, long positionId) : base(id)
        {
            Fullname = fullname;
            HireDate = hireDate;
            PositionId = positionId;
        }
        public void ChangePosition(long positionId)
        {
            this.PositionId = positionId;
        }
    }
}
