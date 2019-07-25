﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka_Bank_system.Models
{
  public  class BasePledge
    {
        public Person Pledger { get; set; } //girov qoyan
        public string Name { get; set; } //girovun adı
        public double Price { get; set; } //girovun dəyəri
        public string Currency { get; set; }
        public string TypeOfPledge { get; set; }
        public string Manufacturer { get; set; } //istehsalçı

        public BasePledge()
        {
            Pledger = new Person();
        }

        public virtual void Copy(BasePledge item)
        {
            Pledger.Copy(item.Pledger);
            Name = item.Name;
            Manufacturer = item.Manufacturer;
            Price = item.Price;
            Currency = item.Currency;
            TypeOfPledge = item.TypeOfPledge;
        }
    }
}
