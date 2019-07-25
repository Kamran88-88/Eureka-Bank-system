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
   public class JewelryTableViewModel
    {
        public static Jewelries Jewelries { get; set; }
        public ObservableCollection<string> Currencies { get; set; }
        public RelayCommand OpenClientSerchTableCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }

        public JewelryTableViewModel()
        {
            Jewelries = new Jewelries();
            Jewelries.TypeOfPledge = "Zinyət əşyası";
            OpenClientSerchTableCommand = new RelayCommand(OpenClientSerchTable);
            SaveCommand = new RelayCommand(Save);
            Currencies = new ObservableCollection<string>(MyRepository.Currencies);
        }

        void Save(object a)
        {
            Jewelries.Price = 0;
            foreach (var item in Jewelries.Jeweleries)
            {
                Jewelries.Price += item.Price;
            }
            //Jewelries jewelries = new Jewelries();
            //jewelries.Copy(Jewelries);
            //ProcuringTableViewModel.ProcuringList.Add(jewelries);
            int ListSize;
            Jewelries jewelries = new Jewelries();
            jewelries.Copy(Jewelries);

            try
            {
                var ItemDelete = ProcuringTableViewModel.JewelriesList.Where(x => x.Id == jewelries.Id).Select(x => x).First();
                ProcuringTableViewModel.JewelriesList.Remove(ItemDelete);
            }
            catch (Exception) { }
            ProcuringTableViewModel.JewelriesList.Add(jewelries);

            ListSize = ProcuringTableViewModel.ProcuringList.Count;
            for (int i = ListSize - 1; i >= 0; i--)
            {
                var jeweleriess = ProcuringTableViewModel.ProcuringList[i] is Jewelries;
                if (jeweleriess)
                {
                    ProcuringTableViewModel.ProcuringList.Remove(ProcuringTableViewModel.ProcuringList[i]);
                }
            }
            foreach (var item in ProcuringTableViewModel.JewelriesList)
            {
                ProcuringTableViewModel.ProcuringList.Add(item);
            }

        }

        void OpenClientSerchTable(object a)
        {
            var param = a as string;
            MainViewModel.parametr2 = param;

            ClientSerchViewModel clientSerchViewModel = new ClientSerchViewModel();
            ClientSerchView clientSerchView = new ClientSerchView();
            clientSerchView.DataContext = clientSerchViewModel;
            clientSerchView.ShowDialog();
        }


    }
}
