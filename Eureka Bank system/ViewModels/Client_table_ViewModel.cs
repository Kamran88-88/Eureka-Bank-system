using Eureka_Bank_system.Models;
using Eureka_Bank_system.MyCommand;
using Eureka_Bank_system.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace Eureka_Bank_system.ViewModels
{
    class Client_table_ViewModel : Window, INotifyPropertyChanged
    {
        private Person person1;
        public Person Person1
        {
            get { return person1; }
            set { person1 = value; OnPropertyChanged(); }
        }

        private bool clientcodeeditable;
        public bool ClientCodeEditable
        {
            get { return clientcodeeditable; }
            set { clientcodeeditable = value; OnPropertyChanged(); }
        }

        public ObservableCollection<string> Sexes { get; set; }
        public ObservableCollection<Address> AddressTypes { get; set; }
        public ObservableCollection<Address> Cities { get; set; }
        public ObservableCollection<Address> Regions { get; set; }
        public ObservableCollection<Address> Countries { get; set; }
        public ObservableCollection<WorkPlace> Legals { get; set; }
        public ObservableCollection<WorkPlace> Areas { get; set; }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CheckedCommand { get; set; }

        public Client_table_ViewModel()
        {
            Person1 = new Person();
            SaveCommand = new RelayCommand(Save);
            Sexes = new ObservableCollection<string>(MyRepository.Sexes);
            AddressTypes = new ObservableCollection<Address>(MyRepository.AddressTypes);
            Cities = new ObservableCollection<Address>(MyRepository.Cities);
            Regions = new ObservableCollection<Address>(MyRepository.Regions);
            Countries = new ObservableCollection<Address>(MyRepository.Countries);
            Legals = new ObservableCollection<WorkPlace>(MyRepository.Legals);
            Areas = new ObservableCollection<WorkPlace>(MyRepository.Areas);
        }

        void Save(object a)
        {
            Person1.TotalOffiialIncome = 0;
            foreach (var item in Person1.WorkPlaces)
            {
                Person1.TotalOffiialIncome += item.Salary;
            }

            Person1.TotalOffiialOutcome = 0;
            foreach (var item in Person1.PersonIncomeOutcomes)
            {
                Person1.TotalOffiialOutcome += item.Outcome;
            }

            Person1.FirsWorkName = Person1.WorkPlaces[0].Name;
            Person1.FullName = $"{Person1.Surname} {Person1.Name} {Person1.Father_name}";
            Person person = new Person(); //bu ona görə lazımdır ki, hər yeni yaranan personun yeni adresi olsun ki, person siyahısındakı personların adresləri müxtəlif olsun. adreslər eyni olarsa yığılan personların hamısıson yığılan persona bərabər olacaq. siyahıda müxtəlif personlar deyil yaradılmış person syı qədər eyni adamlar olacaq. müxtəlif adamlar yığılmasına baxmayaraq.
            person.Copy(Person1);

            int ListSize;
            switch (MainViewModel.parametr1)
            {
                case "Zaminlik":
                    try
                    {
                        person.TypeOfPledge = "Zaminlik";
                        var itemToDelete = ProcuringTableViewModel.GuaranterList.Where(x => x.ClientCode == Person1.ClientCode).Select(x => x).First();
                        ProcuringTableViewModel.GuaranterList.Remove(itemToDelete);
                    }
                    catch (Exception) { }
                    ProcuringTableViewModel.GuaranterList.Add(person);
                     ListSize = ProcuringTableViewModel.ProcuringList.Count;
                    for (int i = ListSize - 1; i >= 0; i--)
                    {
                        var per = ProcuringTableViewModel.ProcuringList[i] is Person;
                        if (per)
                        {
                            ProcuringTableViewModel.ProcuringList.Remove(ProcuringTableViewModel.ProcuringList[i]);
                        }
                    }
                    foreach (var item in ProcuringTableViewModel.GuaranterList)
                    {
                        ProcuringTableViewModel.ProcuringList.Add(item);
                    }
                    break;
                case "Əşya girovu": ColateralTableViewModel.Thing.Pledger.Copy(person); break;
                case "Avtomobil girovu": CarPledgeTableViewModel.Car.Pledger.Copy(person); break;
                case "Daşınmaz əmlak girovu":
                    try
                    {
                        var itemToDelete = HousePledgeViewModel.House.Pledgers.Where(x => x.ClientCode == Person1.ClientCode).Select(x => x).First();
                        HousePledgeViewModel.House.Pledgers.Remove(itemToDelete);
                    }
                    catch (Exception) { }
                    HousePledgeViewModel.House.Pledgers.Add(person);
                    break;
                case "Zinyət əşyası":
                    if (MainViewModel.parametr2.SequenceEqual("Girovqoyan"))
                    {
                        JewelryTableViewModel.Jewelries.Pledger.Copy(person);
                    }
                    else if (MainViewModel.parametr2.SequenceEqual("Qiymətləndirici"))
                    {
                        JewelryTableViewModel.Jewelries.Appraiser.Copy(person);
                    }
                    break;
                case "Nağd pul girovu": DepositTableViewModel.Deposit.Pledger.Copy(person); break;

                default:
                    MessageBox.Show("FromNağdTablo");
                    Nagd_istehlak_ViewModel.Person.Copy(Person1);
                    Nagd_istehlak_ViewModel.StaticPerson.Copy(Person1);
                    break;
            }

            try
            {
                var itemToDelete = MyRepository.PeopleRepository.Where(x => x.ClientCode == Person1.ClientCode).Select(x => x).First();
                MyRepository.PeopleRepository.Remove(itemToDelete);
            }
            catch (Exception) { }
            MyRepository.PeopleRepository.Add(person);

            MessageBox.Show("Saved!");

        }

        void Check(object a)
        {
            var param = a as string;
            if (param == "Individual")
            {
                Person1.CheckedIndividual = true;
            }
            else
            {
                Person1.CheckedIndividualOwner = true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
