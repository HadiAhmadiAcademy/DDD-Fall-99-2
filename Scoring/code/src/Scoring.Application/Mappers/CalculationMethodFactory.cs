using System;
using System.Collections.Generic;
using System.Text;
using Scoring.Domain.Model.Rules.CalculationMethods;

namespace Scoring.Application
{
    public static class CalculationMethodFactory
    {
        public static CalculationMethod Create(bool isIncreasing, byte pointValue)
        {
            var point = new Point(pointValue);

            if (isIncreasing) 
                return new Reward(point);
            return new Penalty(point);
        }
    }
}
