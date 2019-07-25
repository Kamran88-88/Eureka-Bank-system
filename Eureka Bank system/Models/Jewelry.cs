using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka_Bank_system.Models
{
    public class Jewelry : BasePledge
    {
        public double Carat { get; set; } //Zinyət əşyasının əyarı
        public double Weight { get; set; } //zinyət əşyasının çəkisi
        public long Census { get; set; }  // Hansı siyahıya aiddir onu göstərmək üçündür. Siyahıya mənsubluq. Sabah SQL bazada yığılmış zinyət əşyalarını bazadan oxuyub listə dolduranda bilsin hansı listə hansı zinyət əşyalarını doldurmaq lazımdır.
        public Jewelry()  //long Id
        {
          //  Census = Id;
        }
    }
}
