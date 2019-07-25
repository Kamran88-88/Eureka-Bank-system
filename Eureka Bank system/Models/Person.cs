using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Eureka_Bank_system.Models
{
    public class Person : Entitiy, INotifyPropertyChanged
    {
        public string TypeOfPledge { get; set; }
        //---
        private int clientcode;
        public int ClientCode
        {
            get { return clientcode; }
            set { clientcode = value; OnPropertyChanged(); }
        }
        //--
        private string fullname;
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; OnPropertyChanged(); }
        }
        //---

        private double totaloffiialincome;
        public double TotalOffiialIncome
        {
            get { return totaloffiialincome; }
            set { totaloffiialincome = value; OnPropertyChanged(); }
        }

        private double totaloffiiaoutcome;
        public double TotalOffiialOutcome
        {
            get { return totaloffiiaoutcome; }
            set { totaloffiiaoutcome = value; OnPropertyChanged(); }
        }

        private string firsworkname;

        public string FirsWorkName
        {
            get { return firsworkname; }
            set { firsworkname = value; OnPropertyChanged(); }
        }


        public bool CheckedIndividual { get; set; }
        public bool CheckedIndividualOwner { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Father_name { get; set; }
        public double TIN { get; set; }
        public string FinCode { get; set; }
        public string Sex { get; set; } = "Seçin";
        public string Note { get; set; }
       


        public Passport Passport { get; set; }
        public DateTime BirthDay { get; set; }

        public ObservableCollection<Address> Adresses { get; set; }
        public ObservableCollection<Phone> Phones { get; set; }
        public ObservableCollection<WorkPlace> WorkPlaces { get; set; }
        public ObservableCollection<ClientDebt> Debts { get; set; }
        public ObservableCollection<PersonIncomeOutcome> PersonIncomeOutcomes { get; set; }
        //public ObservableCollection<Person> PersonGuaranties { get; set; }


        public Person()
        {
            Passport = new Passport();

            WorkPlaces = new ObservableCollection<WorkPlace>()
            {
                new WorkPlace(),
                 new WorkPlace()
            };

            PersonIncomeOutcomes = new ObservableCollection<PersonIncomeOutcome>
            {
                new PersonIncomeOutcome()
            };

            Adresses = new ObservableCollection<Address>()
            {
                new Address(),
              new Address()
            };
            Debts = new ObservableCollection<ClientDebt>()
            {
                new ClientDebt()
            };
            Phones = new ObservableCollection<Phone>()
            {
                new Phone()
                {
                    PhoneType="Ev"
                },
                new Phone()
                {
                    PhoneType="İş"
                },
                new Phone()
                {
                    PhoneType="Mobil"
                },
                 new Phone()
                {
                    PhoneType="Digər"
                },
                  new Phone()
                {
                    PhoneType="Digər"
                },
                   new Phone()
                {
                    PhoneType="Digər"
                }
            };

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void Copy(Person person)
        {
            if (person != null)
            {
                DateTime dateTime = new DateTime(person.BirthDay.Year, person.BirthDay.Month, person.BirthDay.Day);
                Passport.Seria = person.Passport.Seria;
                Passport.Number = person.Passport.Number;
                Passport.Organization = person.Passport.Organization;
                Passport.StartDate = person.Passport.StartDate;
                Passport.EndDate = person.Passport.EndDate;

                CheckedIndividual = person.CheckedIndividual;
                CheckedIndividualOwner = person.CheckedIndividualOwner;
                ClientCode = person.ClientCode;
                Surname = person.Surname;
                Name = person.Name;
                Father_name = person.Father_name;
                TIN = person.TIN;
                FinCode = person.FinCode;
                Sex = person.Sex;
                Note = person.Note;
                Sex = person.Sex;
                FullName = person.FullName;
                BirthDay = dateTime;
                Adresses = new ObservableCollection<Address>(person.Adresses);
                Phones = new ObservableCollection<Phone>(person.Phones);
                WorkPlaces = new ObservableCollection<WorkPlace>(person.WorkPlaces);
                Debts = new ObservableCollection<ClientDebt>(person.Debts);
                PersonIncomeOutcomes = new ObservableCollection<PersonIncomeOutcome>(person.PersonIncomeOutcomes);
                TotalOffiialIncome = person.TotalOffiialIncome;
                TotalOffiialOutcome = person.TotalOffiialOutcome;
                FirsWorkName = person.FirsWorkName;
                Id = person.Id;
                //PersonGuaranties = new ObservableCollection<Person>(person.PersonGuaranties);    
            }
        }
    }
}
