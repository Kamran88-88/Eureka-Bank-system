using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka_Bank_system.Models
{
   public class Loan:Entitiy
    {
        public double Rate { get; set; }
        public double Period { get; set; }
        public double Sum { get; set; }
        public PayInfo PayInfo { get; set; }
        public ObservableCollection<PayInfo> MonthlyPays { get; set; }

       
        public Loan()
        {
            MonthlyPays = new ObservableCollection<PayInfo>();
            PayInfo = new PayInfo();           
        }

        public void CreatePaymentSchedule()
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Today;

            MonthlyPays.Clear();
            for (int i = 0; i < Period; i++)
            {
                PayInfo.CountOfPay++;
                dateTime.AddMonths(1);
                PayInfo.PayDate = dateTime.AddMonths(1).ToString("dd/MM/yyyy");

                var ConvertingDate = Convert.ToDateTime(PayInfo.PayDate);
                var Difference = (ConvertingDate - dateTime).TotalDays;
                
                
                

                if (i==0)
                {
                    PayInfo.CalculatedInterest = Sum * Rate / 100 * 30 / 360;
                    PayInfo.PaidPrincipalDebt = -PayInfo.Pmt - PayInfo.CalculatedInterest; //cədvəli yazmağı burdan davam etmək lazımdır. 
                    PayInfo.RoundCalculatedInterest = (double)Math.Round(PayInfo.CalculatedInterest * 100) / 100; //hesablanmış faiz
                    PayInfo.RoundPaidPrincipalDebt = (double)Math.Round(PayInfo.PaidPrincipalDebt * 100) / 100; //ödənmiş əsas borc
                    PayInfo.ResidualPrinsipalDebt = Sum - PayInfo.PaidPrincipalDebt; //qalıq əsas borc
                    PayInfo.RoundResidualPrinsipalDebt = (double)Math.Round(PayInfo.ResidualPrinsipalDebt*100)/100;
                }
                else
                {
                    PayInfo.CalculatedInterest = PayInfo.ResidualPrinsipalDebt * Rate / 100 * 30 / 360;
                    PayInfo.PaidPrincipalDebt = -PayInfo.Pmt - PayInfo.CalculatedInterest;
                    PayInfo.RoundCalculatedInterest = (double)Math.Round(PayInfo.CalculatedInterest * 100) / 100; //hesablanmış faiz
                    PayInfo.RoundPaidPrincipalDebt = (double)Math.Round(PayInfo.PaidPrincipalDebt * 100) / 100; //ödənmiş əsas borc

                    PayInfo.ResidualPrinsipalDebt -= PayInfo.PaidPrincipalDebt;
                    PayInfo.RoundResidualPrinsipalDebt = (double)Math.Round(PayInfo.ResidualPrinsipalDebt*100)/100;
                }
               


                dateTime = dateTime.AddMonths(1);
                
                PayInfo payInfo = new PayInfo();
                payInfo.Copy(PayInfo);
                MonthlyPays.Add(payInfo);
            }
            
            PayInfo.CountOfPay = 0;
        }
    }
}
