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

namespace Eureka_Bank_system.ViewModels
{
    class CarPledgeTableViewModel
    {
        public static Car Car { get; set; }
        public ObservableCollection<string> Currencies { get; set; }

        public RelayCommand ChangePledgerCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }

        public CarPledgeTableViewModel()
        {
            Car = new Car();
            Car.TypeOfPledge = "Avtomobil girovu";
            Car.Pledger.Copy(Nagd_istehlak_ViewModel.StaticPerson);
            Currencies = new ObservableCollection<string>(MyRepository.Currencies);

            ChangePledgerCommand = new RelayCommand(OpenClientCerchTable);
            SaveCommand = new RelayCommand(Save);
        }

        void OpenClientCerchTable(object a)
        {
            ClientSerchView clientSerchView = new ClientSerchView();
            ClientSerchViewModel clientSerchViewModel = new ClientSerchViewModel();

            clientSerchView.DataContext = clientSerchViewModel;
            clientSerchView.ShowDialog();
        }

        void Save(object a)
        {
            int ListSize;
            Car car = new Car();
            car.Copy(Car);

            try
            {
                var ItemDelete = ProcuringTableViewModel.CarList.Where(x => x.Id == car.Id).Select(x => x).First();
                ProcuringTableViewModel.CarList.Remove(ItemDelete);
            }
            catch (Exception) { }
            ProcuringTableViewModel.CarList.Add(car);

            ListSize = ProcuringTableViewModel.ProcuringList.Count;
            for (int i = ListSize - 1; i >= 0; i--)
            {
                var carr = ProcuringTableViewModel.ProcuringList[i] is Car;
                if (carr)
                {
                    ProcuringTableViewModel.ProcuringList.Remove(ProcuringTableViewModel.ProcuringList[i]);
                }
            }
            foreach (var item in ProcuringTableViewModel.CarList)
            {
                ProcuringTableViewModel.ProcuringList.Add(item);
            }
        }
    }
}
