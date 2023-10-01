using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Öğretmen_Görevlendirme
{
    internal class Okul
    {
        string sira;
        public string kurum_kodu {get;set; }
        string kurum_adi;
        public string bolge{ get; set;}
        public List<Ihtiyac> ihtiyaclar { get; set; }

        public Okul() { }
        public Okul(string sira, string kurum_kodu, string kurum_adi,string bolge)
        {
            this.sira = sira;
            this.kurum_kodu = kurum_kodu;
            this.kurum_adi = kurum_adi;
            this.bolge = bolge;
            this.ihtiyaclar= new List<Ihtiyac>();
        }

        
        public string ToString()
        {
            return bolge+" - "+kurum_kodu+" - "+kurum_adi;
        }

        
    }
}
