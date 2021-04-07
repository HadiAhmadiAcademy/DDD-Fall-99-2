using System;
using System.Collections.Generic;

namespace LoanApplications.Domain.Model.LoanApplications.States
{
    public static class StatePool
    {
        private static Dictionary<string, object> _states = new Dictionary<string, object>()
        {
            { nameof(PendingState), new PendingState()},
            { nameof(ConfirmedState), new ConfirmedState()},
            { nameof(RejectedState), new RejectedState()},
            { nameof(CancelledState), new CancelledState()},
            { nameof(FinalConfirmedState), new FinalConfirmedState()},
        };
        public static T GetState<T>() where T : LoanApplicationState
        {
            return GetState(typeof(T)) as T;
        }

        public static LoanApplicationState GetState(Type type)
        {
            return _states[type.Name] as LoanApplicationState;
        }
    }
}