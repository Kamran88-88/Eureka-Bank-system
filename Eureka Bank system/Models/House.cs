using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka_Bank_system.Models
{
   public class House:Entitiy
    {
        public double Price { get; set; } //girovun dəyəri
        public string Currency { get; set; }
        public string TypeOfPledge { get; set; }

        public Address Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string TypeOfBuilding { get; set; }
        public string TypeOfOwnerShip { get; set; }
        public double PledgePrice { get; set; }
        public double Area { get; set; }
        public string HouseDocumentNo { get; set; }
        public ObservableCollection<Person> Pledgers { get; set; }

        public House()
        {
            Address = new Address();
            Pledgers = new ObservableCollection<Person>();
        }

        public void Copy(House house)
        {       
            Price = house.Price;
            Currency = house.Currency;
            TypeOfPledge = house.TypeOfPledge;
            Id = house.Id;

            Address.Copy(house.Address);
            City = house.City;
            Region = house.Region;
            TypeOfBuilding = house.TypeOfBuilding;
            TypeOfOwnerShip = house.TypeOfOwnerShip;
            PledgePrice = house.PledgePrice;
            Area = house.Area;
            HouseDocumentNo = house.HouseDocumentNo;
            foreach (var person in Pledgers) //bəlkə buranı dəyişdim və hər əlavə edilən persona yeni adres vrib sonra əlavə elədim
            {
                house.Pledgers.Add(person);
            }
        }
    }
}
