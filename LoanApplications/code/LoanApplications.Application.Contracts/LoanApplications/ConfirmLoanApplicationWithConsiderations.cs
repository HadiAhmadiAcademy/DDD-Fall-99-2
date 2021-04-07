namespace LoanApplications.Application.Contracts.LoanApplications
{
    public class ConfirmLoanApplicationWithConsiderations
    {
        public long ApplicationId { get; set; }
        public long LoanAmount { get; set; }
        public long PaybackPeriodDays { get; set; }
    }
}