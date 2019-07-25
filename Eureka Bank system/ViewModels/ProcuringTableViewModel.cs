using Eureka_Bank_system.Models;
using Eureka_Bank_system.MyCommand;
using Eureka_Bank_system.Repository;
using Eureka_Bank_system.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Eureka_Bank_system.ViewModels
{
    class ProcuringTableViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<string> Procurings { get; set; }
        public static ObservableCollection<object> ProcuringList { get; set; }

        public static ObservableCollection<Person> GuaranterList { get; set; }
        public static ObservableCollection<Thing> ThingList { get; set; }
        public static ObservableCollection<Car> CarList { get; set; }
        public static ObservableCollection<House> HouseList { get; set; }
        public static ObservableCollection<Jewelries> JewelriesList { get; set; }
        public static ObservableCollection<Deposit> DepositList { get; set; }



        public string SelectedItem { get; set; }
        public object Selectitm { get; set; }
        public static int ID { get; set; } = 0;


        public RelayCommand CreateCommand { get; set; }
        public RelayCommand OpenSelectedTableCommand { get; set; }


        public ProcuringTableViewModel()
        {
            OpenSelectedTableCommand = new RelayCommand(OpenTable);
            Procurings = new ObservableCollection<string>(MyRepository.Procurings); //girovların adlarıdır siyahıdan seçmək üçün
            ProcuringList = new ObservableCollection<object>();
    
            GuaranterList = new ObservableCollection<Person>();
            ThingList = new ObservableCollection<Thing>();
            CarList = new ObservableCollection<Car>();

            CreateCommand = new RelayCommand(CreateProcuring);
        }

        void OpenTable(object a)
        {

            switch (Selectitm.GetType().Name)
            {
                case "Person":
                    MainViewModel.parametr1 = "Zaminlik";
                    Client_table client_Table = new Client_table();
                    Client_table_ViewModel client_Table_ViewModel = new Client_table_ViewModel();
                    client_Table_ViewModel.Person1.Copy(Selectitm as Person);
                    client_Table.DataContext = client_Table_ViewModel;
                    client_Table.ShowDialog();
                    break;
                case "Thing":
                    ColateralTableViewModel colateralTableViewModel = new ColateralTableViewModel();
                    CollateralTableView collateralTableView = new CollateralTableView();
                    ColateralTableViewModel.Thing.Copy(Selectitm as Thing);
                    collateralTableView.DataContext = colateralTableViewModel;
                    collateralTableView.ShowDialog();
                    break;

                case "Car":
                    CarPledgeTableViewModel carPledgeTableViewModel = new CarPledgeTableViewModel();
                    CarPledgeTableView carPledgeTableView = new CarPledgeTableView();
                    CarPledgeTableViewModel.Car.Copy(Selectitm as Car);
                    carPledgeTableView.DataContext = carPledgeTableViewModel;
                    carPledgeTableView.ShowDialog();
                    break;
                case "House":
                    HousePledgeViewModel housePledgeViewModel = new HousePledgeViewModel();
                    HousePledgeView housePledgeView = new HousePledgeView();
                    HousePledgeViewModel.House.Copy(Selectitm as House);
                    housePledgeView.DataContext = housePledgeViewModel;
                    housePledgeView.ShowDialog();
                    break;
                case "Jewelries":
                    JewelryTableViewModel jewelryTableViewModel = new JewelryTableViewModel();
                    JewelryTableView jewelryTableView = new JewelryTableView();
                    JewelryTableViewModel.Jewelries.Copy(Selectitm as Jewelries);
                    jewelryTableView.DataContext = jewelryTableViewModel;
                    jewelryTableView.ShowDialog();
                    break;
                case "Deposit": MessageBox.Show("Hello Deposit"); break;
            }

            //  MessageBox.Show(Selectitm.GetType().ToString());
        }

        void CreateProcuring(object a)
        {
            switch (SelectedItem)
            {
                case "Zaminlik":
                    MainViewModel.parametr1 = "Zaminlik";
                    ClientSerchView clientSerchView = new ClientSerchView();
                    ClientSerchViewModel clientSerchViewModel = new ClientSerchViewModel();
                    clientSerchView.DataContext = clientSerchViewModel;
                    clientSerchView.ShowDialog();
                    break;
                case "Əşya girovu":
                    MainViewModel.parametr1 = "Əşya girovu";
                    CollateralTableView collateralTableView = new CollateralTableView();
                    ColateralTableViewModel colateralTableViewModel = new ColateralTableViewModel();
                    ColateralTableViewModel.Thing.Id = ++ID;
                    collateralTableView.DataContext = colateralTableViewModel;
                    collateralTableView.ShowDialog();
                    break;
                case "Avtomobil girovu":
                    MainViewModel.parametr1 = "Avtomobil girovu";
                    CarPledgeTableView carPledgeTableView = new CarPledgeTableView();
                    CarPledgeTableViewModel pledgeTableViewModel = new CarPledgeTableViewModel();
                    CarPledgeTableViewModel.Car.Id = ++ID;
                    carPledgeTableView.DataContext = pledgeTableViewModel;
                    carPledgeTableView.ShowDialog();
                    break;
                case "Daşınmaz əmlak girovu":
                    MainViewModel.parametr1 = "Daşınmaz əmlak girovu";
                    HousePledgeView housePledgeView = new HousePledgeView();
                    HousePledgeViewModel housePledgeViewModel = new HousePledgeViewModel();
                    HousePledgeViewModel.House.Id = ++ID;
                    housePledgeView.DataContext = housePledgeViewModel;
                    housePledgeView.ShowDialog();
                    break;
                case "Zinyət əşyası":
                    MainViewModel.parametr1 = "Zinyət əşyası";
                    JewelryTableViewModel jewelryTableViewModel = new JewelryTableViewModel();
                    JewelryTableView jewelryTableView = new JewelryTableView();
                    JewelryTableViewModel.Jewelries.Id = ++ID;
                    jewelryTableView.DataContext = jewelryTableViewModel;
                    jewelryTableView.ShowDialog();

                    break;
                case "Nağd pul girovu":
                    MainViewModel.parametr1 = "Nağd pul girovu";
                    DepositTableView depositTableView = new DepositTableView();
                    DepositTableViewModel depositTableViewModel = new DepositTableViewModel();
                    depositTableView.DataContext = depositTableViewModel;
                    depositTableView.ShowDialog();
                    break;
                case "Dövriyyə vəsaiti":
                    MainViewModel.parametr1 = "Dövriyyə vəsaiti";
                    break;
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
