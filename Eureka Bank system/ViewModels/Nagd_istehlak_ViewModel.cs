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
using System.Windows.Input;
using Microsoft.VisualBasic;


namespace Eureka_Bank_system.ViewModels
{
    public class Nagd_istehlak_ViewModel 
    {
        public Loan Loan { get; set; }


        public static Person Person { get; set; }
        public static Person StaticPerson { get; set; }

        public static  ObservableCollection<object> ProcuringList { get; set; }

        public static ObservableCollection<Person> GuaranterList { get; set; }
        public static ObservableCollection<Thing> ThingList { get; set; }
        public static ObservableCollection<Car> CarList { get; set; }
        public static ObservableCollection<House> HouseList { get; set; }
        public static ObservableCollection<Jewelries> JewelriesList { get; set; }
        public static ObservableCollection<Deposit> DepositList { get; set; }
        public static ObservableCollection<int> Periods { get; set; }


        public ObservableCollection<Promotion> Promotions { get; set; }
        public static ObservableCollection<Product> LoanProducts { get; set; }
        


        public RelayCommand PersonTableCommand { get; set; }
        public RelayCommand OpenSerchTableCommand { get; set; }
        public RelayCommand OpenProcuringTableCommand { get; set; }
        public RelayCommand EnterTextboxCommand { get; set; }
        public RelayCommand OpenPromotionTableCommand { get; set; }
        public RelayCommand OpenSchedulePaymentCommand { get; set; }

        public Nagd_istehlak_ViewModel()
        {

            Loan = new Loan();

            Promotions = new ObservableCollection<Promotion>(MyRepository.Promotions);
            LoanProducts = new ObservableCollection<Product>(MyRepository.LoanProducts);

            Periods = new ObservableCollection<int>(MyRepository.Periods);

            ProcuringList = new ObservableCollection<object>();

            GuaranterList = new ObservableCollection<Person>();
            ThingList = new ObservableCollection<Thing>();
            CarList = new ObservableCollection<Car>();
            HouseList = new ObservableCollection<House>();
            JewelriesList = new ObservableCollection<Jewelries>();
            DepositList = new ObservableCollection<Deposit>();

            PersonTableCommand = new RelayCommand(OpenClientTable);
            OpenSerchTableCommand = new RelayCommand(OpenSerchTable);
            OpenProcuringTableCommand = new RelayCommand(OpenProcuringTable);
            EnterTextboxCommand = new RelayCommand(EnterTextbox);
            OpenPromotionTableCommand = new RelayCommand(OpenPromotionTable);
            OpenSchedulePaymentCommand = new RelayCommand(OpenSchedulePayment);


            Person = new Person();
            StaticPerson = new Person();
        }

        void OpenSchedulePayment(object a)
        {
            Loan.PayInfo.Pmt = Financial.Pmt(Loan.Rate / 1200, Loan.Period, Loan.Sum);
            Loan.PayInfo.RoundPmt = -(double)Math.Round(Loan.PayInfo.Pmt * 100)/100;
            Loan.CreatePaymentSchedule();

            PaymentScheduleView paymentScheduleView = new PaymentScheduleView();
            PaymentSheduleViewModel paymentSheduleViewModel = new PaymentSheduleViewModel();
            paymentSheduleViewModel.Person = Person;
            paymentSheduleViewModel.Loan = Loan;
            paymentScheduleView.DataContext = paymentSheduleViewModel;
            paymentScheduleView.ShowDialog();
        }

        void OpenPromotionTable(object a)
        {
            PromotionView promotionView = new PromotionView();
            PromotionViewModel promotionViewModel = new PromotionViewModel();
            promotionViewModel.Promotions = Promotions;
            promotionView.DataContext = promotionViewModel;
            promotionView.ShowDialog();
        }

        void EnterTextbox(object a)
        {
            try
            {
                var FindPerson = MyRepository.PeopleRepository.Where(x => x.ClientCode == StaticPerson.ClientCode).Select(x => x).First();
                StaticPerson.Copy(FindPerson);
               Person.Copy(FindPerson);
            }
            catch (Exception) {}
        }

        public void OpenProcuringTable(object a)
        {
            ProcuringTableView procuringTableView = new ProcuringTableView();
            ProcuringTableViewModel procuringTableViewModel = new ProcuringTableViewModel();
            ProcuringTableViewModel.ProcuringList = ProcuringList;
            ProcuringTableViewModel.GuaranterList = GuaranterList;
            ProcuringTableViewModel.ThingList = ThingList;
            ProcuringTableViewModel.CarList = CarList;
            ProcuringTableViewModel.HouseList = HouseList;
            ProcuringTableViewModel.JewelriesList = JewelriesList;
            ProcuringTableViewModel.DepositList = DepositList;

            procuringTableView.DataContext = procuringTableViewModel;
            procuringTableView.ShowDialog();
        }

        public void OpenClientTable(object a)
        {
            MainViewModel.parametr1 = "FromNağdTablo";
            var param = a as string;
            Client_table client_Table = new Client_table();
            Client_table_ViewModel client_Table_ViewModel = new Client_table_ViewModel();

            try
            {              
                if (param == "Ətraflı")
            {
                    client_Table_ViewModel.Person1.Copy(Person);               
                    client_Table_ViewModel.ClientCodeEditable = false;
            }
            else
            {
                    client_Table_ViewModel.ClientCodeEditable = true;
            }
            client_Table.DataContext = client_Table_ViewModel;
            client_Table.ShowDialog();
            }
            catch (Exception) { MessageBox.Show("Müştərini seçməmisiniz!"); }

        }

        public void OpenSerchTable(object a)
        {
            MainViewModel.parametr1 = "FromNağdTablo";
            ClientSerchView clientSerchView = new ClientSerchView();
            ClientSerchViewModel clientSerchViewModel = new ClientSerchViewModel();
            clientSerchView.DataContext = clientSerchViewModel;
            clientSerchView.ShowDialog();
        }

    }
}
