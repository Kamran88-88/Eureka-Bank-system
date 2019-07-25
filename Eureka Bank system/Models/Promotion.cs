using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Eureka_Bank_system.Models
{
   public class Promotion:Entitiy
    {
        public string EndDate { get; set; }
        public string StartDate { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }

        public Promotion()
        {
            StartDate = ((DateTime.Now).ToString("dd.MM.yyyy"));
            EndDate = (new DateTime(2021,2,13)).ToString("dd.MM.yyyy");
        }

        public void Copy(Promotion promotion)
        {
            EndDate = promotion.EndDate;
            StartDate = promotion.StartDate;
            Name = promotion.Name;
            IsChecked = promotion.IsChecked;
        }
    }
}
