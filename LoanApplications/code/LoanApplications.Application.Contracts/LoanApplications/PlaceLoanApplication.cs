using System;

namespace LoanApplications.Application.Contracts.LoanApplications
{
    public class PlaceLoanApplication
    {
        public long ApplicantId { get; set; }
        public long LoanAmount { get; set; }
        public long PaybackPeriodDays { get; set; }
    }
}
