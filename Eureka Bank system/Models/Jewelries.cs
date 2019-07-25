using Eureka_Bank_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka_Bank_system.Models
{
   public class Jewelries:Entitiy
    {
        public ObservableCollection<Jewelry> Jeweleries { get; set; }
        public Person Appraiser { get; set; } //Qiymətləndirici
        public Person Pledger  { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public string TypeOfPledge { get; set; }

        public Jewelries()
        {
            Appraiser = new Person();
            Pledger = new Person();

            Jeweleries = new ObservableCollection<Jewelry>()
            {
                new Jewelry()
            };
            Pledger.Copy(Nagd_istehlak_ViewModel.StaticPerson); 
        }

      public void Copy(Jewelries jewelries)
        {
            Appraiser.Copy(jewelries.Appraiser);
            Pledger.Copy(jewelries.Pledger);
            Price = jewelries.Price;
            Currency = jewelries.Currency;
            TypeOfPledge = jewelries.TypeOfPledge;
            Jeweleries = jewelries.Jeweleries;
            Id = jewelries.Id;
        }
    }
}
