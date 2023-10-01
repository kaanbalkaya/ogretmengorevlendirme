using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Öğretmen_Görevlendirme
{
    internal class Ihtiyac
    {

        //ÖĞRETMEN BİLGİSİ	Varsa İhtiyacın Sona Ereceği Tarih

        string sira_no;
        string ders;
        public int ders_saati { get; set; }
        public string kurum_kodu { get; set; } 
        string ihtiyac_nedeni;
        string ogretmen_bilgisi;
        string ihtiyacin_sona_erecegi_tarih;

        public Ihtiyac() { }

        public Ihtiyac(string sira_no, string kurum_kodu,  string ders, int ders_saati, string ihtiyac_nedeni, string ogretmen_bilgisi, string ihtiyacın_sona_erecegi_tarih)
        {
            this.sira_no = sira_no;
            this.kurum_kodu= kurum_kodu;
            this.ders = ders;
            this.ders_saati = ders_saati;
            this.ihtiyac_nedeni = ihtiyac_nedeni;
            this.ogretmen_bilgisi=ogretmen_bilgisi;
            this.ihtiyacin_sona_erecegi_tarih=ihtiyacin_sona_erecegi_tarih;
        }

        

        public string ToString()
        {
            return sira_no+" - "+ders+" - "+ders_saati.ToString();
        }


        //büyükten küçüğe sıralamak için
        internal static int comparer(Ihtiyac x, Ihtiyac y)
        {
            if (x.ders_saati < y.ders_saati) return 1;
            else return -1;
        }

    }
}
