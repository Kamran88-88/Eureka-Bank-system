using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka_Bank_system.Models
{
   public class Phone:Entitiy
    {
        public string Number { get; set; }
        public string PhoneType { get; set; } = "Digər";
        public string NumberOwner { get; set; }
        public string KinshipRate { get; set; }
    }
}
