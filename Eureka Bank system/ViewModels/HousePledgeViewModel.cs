using Eureka_Bank_system.Models;
using Eureka_Bank_system.MyCommand;
using Eureka_Bank_system.Repository;
using Eureka_Bank_system.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Eureka_Bank_system.ViewModels
{
   public class HousePledgeViewModel
    {
        public static House House { get; set; }
        public Person SelectedPerson { get; set; }

        public ObservableCollection<Address> Cities { get; set; }
        public ObservableCollection<Address> Regions { get; set; }
        public ObservableCollection<string> TypesOfBuilding { get; set; }
        public ObservableCollection<string> TypesOfOwnerShip { get; set; }
        public ObservableCollection<string> Currencies { get; set; }

        public RelayCommand OpenClientSerchTableCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand ShowDetailCommand { get; set; }

        public HousePledgeViewModel()
        {
            SelectedPerson = new Person();
            House = new House();
            House.TypeOfPledge = "Daşınmaz əmlak girovu";
            Cities = new ObservableCollection<Address>(MyRepository.Cities);
            Regions = new ObservableCollection<Address>(MyRepository.Regions);
            TypesOfBuilding = new ObservableCollection<string>(MyRepository.TypesOfBuilding);
            TypesOfOwnerShip = new ObservableCollection<string>(MyRepository.TypesOfOwnerShip);
            Currencies = new ObservableCollection<string>(MyRepository.Currencies);
            OpenClientSerchTableCommand = new RelayCommand(OpenClientSerchTable);
            SaveCommand = new RelayCommand(Save);
            ShowDetailCommand = new RelayCommand(ShowDetails);
        }

       void ShowDetails(object a)
        {
            Client_table_ViewModel client_Table_ViewModel = new Client_table_ViewModel();
            Client_table client_Table = new Client_table();
            client_Table_ViewModel.Person1 = SelectedPerson;
            client_Table.DataContext = client_Table_ViewModel;
            client_Table.ShowDialog();
        }

        void Save(object a)
        {
            int ListSize;
            House house = new House();
            house.Copy(House);

            try
            {
                var ItemDelete = ProcuringTableViewModel.HouseList.Where(x => x.Id == house.Id).Select(x => x).First();
                ProcuringTableViewModel.HouseList.Remove(ItemDelete);
            }
            catch (Exception) { }
            ProcuringTableViewModel.HouseList.Add(house);

            ListSize = ProcuringTableViewModel.ProcuringList.Count;
            for (int i = ListSize - 1; i >= 0; i--)
            {
                var housee = ProcuringTableViewModel.ProcuringList[i] is House;
                if (housee)
                {
                    ProcuringTableViewModel.ProcuringList.Remove(ProcuringTableViewModel.ProcuringList[i]);
                }
            }
            foreach (var item in ProcuringTableViewModel.HouseList)
            {
                ProcuringTableViewModel.ProcuringList.Add(item);
            }
        }

        void OpenClientSerchTable(object a)
        {
            ClientSerchViewModel clientSerchViewModel = new ClientSerchViewModel();
            ClientSerchView client_Table = new ClientSerchView();
            client_Table.DataContext = clientSerchViewModel;
            client_Table.ShowDialog();
        }
    }
}
