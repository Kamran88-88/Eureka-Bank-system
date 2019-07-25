using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka_Bank_system.Models
{
   public class PersonIncomeOutcome
    {
        public double Income { get; set; }
        public double Outcome { get; set; }
        public string IncomeExplanation { get; set; } //gəlir açıqlaması  
        public string OutcomeExplanation { get; set; } //xərcin açıqlaması  
    }
}
