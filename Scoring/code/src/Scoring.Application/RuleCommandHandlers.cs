using System;
using System.Threading.Tasks;
using Framework.Application;
using Scoring.Application.Contracts.Rules;
using Scoring.Domain.Model.Rules;

namespace Scoring.Application
{
    public class RuleCommandHandlers : ICommandHandler<DefineGlobalRuleCommand>
    {
        private readonly IRuleRepository _ruleRepository;
        public RuleCommandHandlers(IRuleRepository ruleRepository)
        {
            _ruleRepository = ruleRepository;
        }

        public Task Handle(DefineGlobalRuleCommand command)
        {
            var activePeriod = new DateRange(command.StartDate, command.EndDate);
            var calculationMethod = CalculationMethodFactory.Create(command.Increasing, command.Points);
            var rule = new Rule(command.Title, activePeriod, calculationMethod);
            _ruleRepository.Add(rule);
            return Task.CompletedTask;
        }
    }
}
