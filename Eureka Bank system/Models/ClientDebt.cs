using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka_Bank_system.Models
{


   public class ClientDebt:Entitiy
    {
        public decimal InitialAmount { get; set; }
        public decimal PrincipalAmount { get; set; } = 1200;
        public decimal PercentageAmount { get; set; } = 56;
        public decimal PenaltyAmount { get; set; }
        public decimal OverduePrincipalDebt { get; set; }
        public decimal OverduePercentageDebt { get; set; }
        public decimal PayableDebt { get; set; }
        public int OverdueDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
