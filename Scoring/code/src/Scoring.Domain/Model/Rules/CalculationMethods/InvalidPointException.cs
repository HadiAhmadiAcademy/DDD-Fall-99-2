using System;

namespace Scoring.Domain.Model.Rules.CalculationMethods
{
    public class InvalidPointException : Exception
    {
        public InvalidPointException() : base("Point should be between 1 and 100")
        {
            
        }
    }
}