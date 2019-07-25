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
    public class ColateralTableViewModel
    {
        public static Thing Thing { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand ChangePledgerCommand { get; set; }
        public ObservableCollection<string> Currencies { get; set; }
        

        public ColateralTableViewModel()
        {
            Thing = new Thing();
            Thing.TypeOfPledge = "Əşya girovu";
           
            Thing.Pledger.Copy(Nagd_istehlak_ViewModel.StaticPerson);
            SaveCommand = new RelayCommand(Save);

            ChangePledgerCommand = new RelayCommand(OpenClientCerchTable);

            Currencies = new ObservableCollection<string>(MyRepository.Currencies);
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
            Thing thing = new Thing();
            thing.Copy(Thing);

                try
                {
                    var ItemDelete = ProcuringTableViewModel.ThingList.Where(x => (x as Entitiy).Id == thing.Id).Select(x => x).First();
                    ProcuringTableViewModel.ThingList.Remove(ItemDelete);
                }
                catch (Exception) { }                        
            ProcuringTableViewModel.ThingList.Add(thing);

            ListSize = ProcuringTableViewModel.ProcuringList.Count;
            for (int i = ListSize - 1; i >= 0; i--)
            {
                var thng = ProcuringTableViewModel.ProcuringList[i] is Thing;
                if (thng)
                {
                    ProcuringTableViewModel.ProcuringList.Remove(ProcuringTableViewModel.ProcuringList[i]);
                }
            }
            foreach (var item in ProcuringTableViewModel.ThingList)
            {
                ProcuringTableViewModel.ProcuringList.Add(item);
            }
            
        }
    }
}