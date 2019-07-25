using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka_Bank_system.Models
{
    public class Address : Entitiy
    {
        public string Adress { get; set; }
        public string AdressType { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public void Copy(Address address)
        {
            Adress = address.Adress;
            AdressType = address.AdressType;
            Region = address.Region;
            City = address.City;
            Country = address.Country;
        }
    }
}
