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
  public class DepositTableViewModel
    {
        public static Deposit Deposit { get; set; }

        public ObservableCollection<string> TypesOfDeposit { get; set; }
        public ObservableCollection<string> Currencies { get; set; }
        public ObservableCollection<string> Banks { get; set; }

        public RelayCommand ChangePledgerCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }


        public DepositTableViewModel()
        {
            Deposit = new Deposit();
            Deposit.TypeOfPledge = "Nağd pul girovu";
            TypesOfDeposit = new ObservableCollection<string>(MyRepository.TypesOfDeposit);
            Currencies = new ObservableCollection<string>(MyRepository.Currencies);
            ChangePledgerCommand = new RelayCommand(OpenSerchClientTable);
            SaveCommand = new RelayCommand(Save);
            Banks = new ObservableCollection<string>(MyRepository.Banks);
        }


        void Save(object a)
        {
            Deposit deposit = new Deposit();
            deposit.Copy(Deposit);
            deposit.Price = deposit.Amount;
            ProcuringTableViewModel.ProcuringList.Add(deposit);
        }

       void OpenSerchClientTable(object a)
        {
            ClientSerchViewModel clientSerchViewModel = new ClientSerchViewModel();
            ClientSerchView clientSerchView = new ClientSerchView();
            clientSerchView.DataContext = clientSerchViewModel;
            clientSerchView.ShowDialog();
        }


    }
}
