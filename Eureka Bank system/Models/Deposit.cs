using Eureka_Bank_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka_Bank_system.Models
{
   public class Deposit:BasePledge
    {

        public double Amount { get; set; }
        public string Account { get; set; }
        public string BankName { get; set; }

        public Deposit()
        {
            Pledger.Copy(Nagd_istehlak_ViewModel.StaticPerson);
        }

        public override void Copy(BasePledge item)
        {
            base.Copy(item);
            Amount = (item as Deposit).Amount;
            Account = (item as Deposit).Account;
            BankName = (item as Deposit).BankName;
        }
    }
}
