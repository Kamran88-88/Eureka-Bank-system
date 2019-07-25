using Eureka_Bank_system.Models;
using Eureka_Bank_system.MyCommand;
using Eureka_Bank_system.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.Specialized;
using Eureka_Bank_system.Views;

namespace Eureka_Bank_system.ViewModels
{
    public class ClientSerchViewModel
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Father_Name { get; set; }
        public int Client_Code { get; set; }
        public string Fin_Code { get; set; }

        public ObservableCollection<Person> ClientSerchResult { get; set; }

        public Person SelectedPerson { get; set; }

        public RelayCommand SelectCommand { get; set; }
        public RelayCommand SerchCommand { get; set; }
        public RelayCommand OpenClientTableCommand { get; set; }

        public ClientSerchViewModel()
        {
            ClientSerchResult = new ObservableCollection<Person>();
            SelectCommand = new RelayCommand(Select);
            SerchCommand = new RelayCommand(Serch);
            OpenClientTableCommand = new RelayCommand(OpenClientTable);
        }
        void OpenClientTable(object a)
        {
            var param = a as string;
            MainViewModel.parametr = param;
            Client_table client_Table = new Client_table();          
            Client_table_ViewModel client_Table_ViewModel = new Client_table_ViewModel();
            client_Table_ViewModel.ClientCodeEditable = true;
            client_Table.DataContext = client_Table_ViewModel;
            client_Table.ShowDialog();
        }

        void Select(object a)
        {
            var param = a as string;
            MainViewModel.parametr = param;

            Client_table client_Table = new Client_table();
            Client_table_ViewModel client_Table_ViewModel = new Client_table_ViewModel();
         
            client_Table_ViewModel.Person1.Copy(SelectedPerson);
            client_Table.DataContext = client_Table_ViewModel;
            client_Table.ShowDialog();
        }

        void Serch(object a)
        {
            List<Person> list = new List<Person>();            
            if (!string.IsNullOrWhiteSpace(Surname) && string.IsNullOrWhiteSpace(Name) && string.IsNullOrWhiteSpace(Father_Name) && Client_Code == 0 && string.IsNullOrWhiteSpace(Fin_Code))
            {
                IEnumerable<Person> serchresult = from person in MyRepository.PeopleRepository
                                                  where person.Surname.ToLower() == Surname.ToLower()
                                                  select person;
                list = serchresult.ToList();
            }
            else if (!string.IsNullOrWhiteSpace(Surname) && !string.IsNullOrWhiteSpace(Name) && string.IsNullOrWhiteSpace(Father_Name) && Client_Code == 0 && string.IsNullOrWhiteSpace(Fin_Code))
            {
                IEnumerable<Person> serchresult = from person in MyRepository.PeopleRepository
                                                  where person.Surname.ToLower() == Surname.ToLower() & person.Name.ToLower() == Name.ToLower()
                                                  select person;
                list = serchresult.ToList();
            }
            else if (!string.IsNullOrWhiteSpace(Surname) && !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Father_Name) && Client_Code == 0 && string.IsNullOrWhiteSpace(Fin_Code))
            {
                IEnumerable<Person> serchresult = from person in MyRepository.PeopleRepository
                                                  where person.Surname.ToLower() == Surname.ToLower() &
                                                  person.Name.ToLower() == Name.ToLower() &
                                                  person.Father_name.ToLower() == Father_Name.ToLower()
                                                  select person;
                list = serchresult.ToList(); ;
            }
            else if (Client_Code != 0)
            {
                IEnumerable<Person> serchresult = from person in MyRepository.PeopleRepository
                                                  where person.ClientCode == Client_Code
                                                  select person;
                list = serchresult.ToList();
            }
            else if (!string.IsNullOrWhiteSpace(Fin_Code))
            {
                IEnumerable<Person> serchresult = from person in MyRepository.PeopleRepository
                                                  where person.FinCode.ToLower() == Fin_Code.ToLower()
                                                  select person;
                list = serchresult.ToList();
            }
            else if (!string.IsNullOrWhiteSpace(Surname) && !string.IsNullOrWhiteSpace(Father_Name))
            {
                IEnumerable<Person> serchresult = from person in MyRepository.PeopleRepository
                                                  where person.Surname.ToLower() == Surname.ToLower() &
                                                  person.Father_name.ToLower() == Father_Name.ToLower()
                                                  select person;
                list = serchresult.ToList();
            }
            else if (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Father_Name))
            {
                IEnumerable<Person> serchresult = from person in MyRepository.PeopleRepository
                                                  where person.Name.ToLower() == Name.ToLower() &
                                                  person.Father_name.ToLower() == Father_Name.ToLower()
                                                  select person;
                list = serchresult.ToList();
            }
            else if (!string.IsNullOrWhiteSpace(Father_Name))
            {
                IEnumerable<Person> serchresult = from person in MyRepository.PeopleRepository
                                                  where person.Father_name.ToLower() == Father_Name.ToLower()
                                                  select person;
                list = serchresult.ToList();
            }
            else if (!string.IsNullOrWhiteSpace(Name))
            {
                IEnumerable<Person> serchresult = from person in MyRepository.PeopleRepository
                                                  where person.Name.ToLower() == Name.ToLower()
                                                  select person;
                list = serchresult.ToList();
            }

            ClientSerchResult.Clear();
            foreach (var item in list)
            {
                ClientSerchResult.Add(item);
            }

        }
    }
}
