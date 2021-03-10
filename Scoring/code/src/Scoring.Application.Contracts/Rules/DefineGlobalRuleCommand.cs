using System;
using System.Collections.Generic;
using System.Text;

namespace Scoring.Application.Contracts.Rules
{
    public class DefineGlobalRuleCommand
    {
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Increasing { get; set; }
        public byte Points { get; set; }
    }
}
