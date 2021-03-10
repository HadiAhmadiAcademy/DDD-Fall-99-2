using System;
using Scoring.Domain.Model.Applicants;
using Scoring.Domain.Model.Rules;
using Scoring.Domain.Model.Rules.CalculationMethods;
using Scoring.Domain.Model.Rules.Conditions;
using Xunit;

namespace Scoring.Domain.Tests.Unit
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            const long TechnicalLead = 10;
            var applicant = new Applicant(1, "John Doe", new DateTime(2010, 01, 01), TechnicalLead);

            
            var activePeriod = new DateRange(new DateTime(2000,01,01), new DateTime(2020,01,01));
            var condition = new HireDateCondition(new DateTime(2015,01,01))
                                            .And(new PositionCondition(TechnicalLead));
            var tenPointsReward = new Penalty(new Point(10));

            var rule = new Rule("My Rule", activePeriod, condition, tenPointsReward);

            var point = rule.GetPointsFor(applicant);

        }
    }
}
