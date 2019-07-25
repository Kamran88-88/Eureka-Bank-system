using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka_Bank_system.Models
{
   public class PayInfo
    {
        public double Pmt { get; set; } // aylıq ödəniş olduğu kimi
        public double RoundPmt { get; set; } // aylıq ödəniş yuvarlaqlaşmış formada 100-də birə qədər
        public int CountOfPay { get; set; } // ödəniş sayı üçün cədvəldə
        public string PayDate { get; set; } // cədvəldəki ödəniş tarixləri üçün

        public double CalculatedInterest { get; set; } // cədvəldəki hesablanmış faizləri göstərmək üçün
        public double PaidPrincipalDebt { get; set; } //  cədvəldəki əsas borcdan ödənilən hissəni göstərmək üçün
        public double ResidualPrinsipalDebt { get; set; } //  cədvəldəki əsas borc qalığını göstərmək üçün

        public double RoundCalculatedInterest { get; set; } // cədvəldəki hesablanmış faizləri göstərmək üçün
        public double RoundPaidPrincipalDebt { get; set; } //  cədvəldəki əsas borcdan ödənilən hissəni göstərmək üçün
        public double RoundResidualPrinsipalDebt { get; set; } //  cədvəldəki əsas borc qalığını göstərmək üçün



        public void Copy(PayInfo payInfo)
        {
            Pmt = payInfo.Pmt;
            RoundPmt = payInfo.RoundPmt;
            CountOfPay = payInfo.CountOfPay;
            PayDate = payInfo.PayDate;
            CalculatedInterest = payInfo.CalculatedInterest;
            PaidPrincipalDebt = payInfo.PaidPrincipalDebt;
            ResidualPrinsipalDebt = payInfo.ResidualPrinsipalDebt;
            RoundCalculatedInterest = payInfo.RoundCalculatedInterest;
            RoundPaidPrincipalDebt = payInfo.RoundPaidPrincipalDebt;
            RoundResidualPrinsipalDebt = payInfo.RoundResidualPrinsipalDebt;
        }
    }
}
