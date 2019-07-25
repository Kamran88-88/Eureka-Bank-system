//using Eureka_Bank_system.Models;
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
using System.Windows.Controls;


namespace Eureka_Bank_system.ViewModels
{
    
   public class MainViewModel :Window, INotifyPropertyChanged
    {
        MyRepository MyRepository = new MyRepository(); //bu ona gore lazimdir ki, repositoridekibutun listler ve reference typeler construktorda elan oluna bilsinler
        public static string parametr = "1"; //bu dəyişən client table-dakı save düyməsi basılarkən client tablenin haradan açıldığını ayır etmək üçündür. 
        public static string parametr1 = "1";
        public static string parametr2 = "1";


        public RelayCommand IstehlakNağdPul { get; set; }
        public RelayCommand EshyaKrediti { get; set; }
        public RelayCommand NisyeAlqiSatqi { get; set; }
        public RelayCommand AvtoKredit { get; set; }

        private int selectedindex;
        public int SelectedIndex
        {
            get { return selectedindex; }
            set { selectedindex = value; OnPropertyChanged(); }
        }


        private string myvisibility;
        public string MyVisibility
        {
            get { return myvisibility; }
            set { myvisibility = value; OnPropertyChanged(); }
        }

        private string myvisibility1;
        public string MyVisibility1
        {
            get { return myvisibility1; }
            set { myvisibility1 = value; OnPropertyChanged(); }
        }

        private string myvisibility2;
        public string MyVisibility2
        {
            get { return myvisibility2; }
            set { myvisibility2 = value; OnPropertyChanged(); }
        }

        private string myvisibility3;
        public string MyVisibility3
        {
            get { return myvisibility3; }
            set { myvisibility3 = value; OnPropertyChanged(); }
        }




        private string tabctrlvisibility;
        public string TabctrlVisibility
        {
            get { return tabctrlvisibility; }
            set { tabctrlvisibility = value; OnPropertyChanged(); }
        }

       // public Consumer_Loan_Table consumer_Loan_Table { get; set; }



        public MainViewModel()
        {
            MyRepository myRepository = new MyRepository();
         

            IstehlakNağdPul = new RelayCommand(NagdPulIst_tablosu);
            EshyaKrediti = new RelayCommand(Eshyakred_tablosu);
            NisyeAlqiSatqi = new RelayCommand(NisyeAlqiSatqi_tablosu);
            AvtoKredit = new RelayCommand(AvtoKredit_Tablosu);



            MyVisibility = Visibility.Collapsed.ToString();
            MyVisibility1 = Visibility.Collapsed.ToString();
            MyVisibility2 = Visibility.Collapsed.ToString();
            MyVisibility3 = Visibility.Collapsed.ToString();
            TabctrlVisibility = Visibility.Collapsed.ToString();
        }


        public void NagdPulIst_tablosu(object a)
        {
            TabctrlVisibility = Visibility.Visible.ToString();
            MyVisibility = Visibility.Visible.ToString();
            SelectedIndex = 0;

        }

        public void Eshyakred_tablosu(object a)
        {
            TabctrlVisibility = Visibility.Visible.ToString();
            MyVisibility1 = Visibility.Visible.ToString();
            SelectedIndex = 1;
        }
        public void NisyeAlqiSatqi_tablosu(object a)
        {
            TabctrlVisibility = Visibility.Visible.ToString();
            MyVisibility2 = Visibility.Visible.ToString();
            SelectedIndex = 2;
        }
        public void AvtoKredit_Tablosu(object a)
        {
            TabctrlVisibility = Visibility.Visible.ToString();
            MyVisibility3 = Visibility.Visible.ToString();
            SelectedIndex = 3;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
