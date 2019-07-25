using Eureka_Bank_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

namespace Eureka_Bank_system.ViewModels
{
  public class PaymentSheduleViewModel
    {
        public Person Person { get; set; }
        public  Loan Loan { get; set; }
       
    }
}
