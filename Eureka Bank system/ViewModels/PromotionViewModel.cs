using Eureka_Bank_system.Models;
using Eureka_Bank_system.MyCommand;
using Eureka_Bank_system.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Eureka_Bank_system.ViewModels
{
   public class PromotionViewModel
    {
        public  ObservableCollection<Promotion> Promotions { get; set; }

        public PromotionViewModel()
        {
            Promotions = new ObservableCollection<Promotion>();
        
        }            

    }
}
