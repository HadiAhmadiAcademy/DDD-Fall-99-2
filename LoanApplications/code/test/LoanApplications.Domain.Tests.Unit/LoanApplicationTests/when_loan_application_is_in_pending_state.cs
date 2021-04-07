using System;
using System.Collections.Generic;
using FluentAssertions;
using LoanApplications.Domain.Model.LoanApplications;
using LoanApplications.Domain.Model.LoanApplications.States;
using Xunit;

namespace LoanApplications.Domain.Tests.Unit.LoanApplicationTests
{
    public class when_loan_application_is_in_pending_state
    {
        public static IEnumerable<object[]> ValidTransitions =>
            new List<object[]>
            {
                new object[] { new Action<LoanApplication>(a=> a.Confirm()), typeof(ConfirmedState) },
                new object[] { new Action<LoanApplication>(a=> a.Cancel()), typeof(CancelledState) },
                new object[] { new Action<LoanApplication>(a=> a.Reject()), typeof(RejectedState) },
            };

        public static IEnumerable<object[]> InvalidTransitions =>
            new List<object[]>
            {
                new object[] { new Action<LoanApplication>(a=> a.FinalConfirm()) },
            };

        [Theory]
        [MemberData(nameof(ValidTransitions))]
        public void valid_state_transitions(Action<LoanApplication> transition, Type expectedState)
        {
            var loanApplication = new LoanApplication(1, 10, 10000, TimeSpan.FromDays(365));    

            transition.Invoke(loanApplication);

            loanApplication.State.Should().BeOfType(expectedState);
        }

        [Theory]
        [MemberData(nameof(InvalidTransitions))]
        public void invalid_state_transitions(Action<LoanApplication> transition)
        {
            var loanApplication = new LoanApplication(1, 10, 10000, TimeSpan.FromDays(365));

            Action stateTransition = ()=> transition.Invoke(loanApplication);

            stateTransition.Should().Throw<NotSupportedException>();
        }
    }
}