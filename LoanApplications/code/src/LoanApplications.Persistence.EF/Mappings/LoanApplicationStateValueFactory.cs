using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoanApplications.Domain.Model.LoanApplications.States;

namespace LoanApplications.Persistence.EF.Mappings
{
    public static class LoanApplicationStateValueFactory
    {
        //TODO: use reflection and attributes here 
        private static Dictionary<Type, int> _values = new Dictionary<Type, int>()
        {
            { typeof(PendingState), 1 },
            { typeof(ConfirmedState), 2 },
            { typeof(FinalConfirmedState), 3 },
            { typeof(CancelledState), -1 },
            { typeof(RejectedState), -2 },
        };

        public static int GetValue(Type type)
        {
            return _values[type];
        }
        public static LoanApplicationState GetState(int value)
        {
            var type = _values.FirstOrDefault(a => a.Value == value);
            return StatePool.GetState(type.Key);
        }
    }
}
