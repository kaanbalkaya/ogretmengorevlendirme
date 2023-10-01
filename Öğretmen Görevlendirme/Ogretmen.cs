using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Öğretmen_Görevlendirme
{
    internal class Ogretmen
    {
        string sira;
        string brans;
        string tc_kimlik;
        string ad_soyad;
        //kadrosunun olduğu okul ve okuldaki ders sayısını tutar.
        Tuple<Okul,int> kadrolu_okul;
        //okul ile o okuldaki ders sayısını tutan tupleların oluşturduğu liste, öğretmenin görevlendirildiği tüm okulları kaydeder.
        List<Tuple<Okul, int>> gorevlendirme_okullar;
        public int toplam_ders { get; set; }
        string ozel_durum;
        public Ogretmen() { 
            kadrolu_okul=new Tuple<Okul, int>(new Okul(), 0);
            gorevlendirme_okullar=new List<Tuple<Okul, int>>();
        }
        public Ogretmen(string sira, string brans, string tc_kimlik, string ad_soyad, Tuple<Okul, int> kadrolu_okul, Tuple<Okul, int> gorevlendirme, int toplam_ders, string ozel_durum)
        {
            this.sira = sira;
            this.brans = brans;
            this.tc_kimlik = tc_kimlik;
            this.ad_soyad = ad_soyad;
            this.kadrolu_okul = kadrolu_okul;
            this.gorevlendirme_okullar=new List<Tuple<Okul, int>>();
            this.gorevlendirme_okullar.Add(gorevlendirme);
            this.toplam_ders = toplam_ders;
            this.ozel_durum = ozel_durum;
        }

        public Okul kadro_kaydi()
        {
            return kadrolu_okul.Item1;
        }
        public void add_gorevlendirme(Tuple<Okul, int> gorevlendirme)
        {
            gorevlendirme_okullar.Add(gorevlendirme);
        }

        public string ToString()
        {
            return tc_kimlik+" - "+ad_soyad+" - "+brans+" - "+kadrolu_okul.Item1.ToString();
        }

        //küçükten büyüğe sıralamak için
        internal static int comparer(Ogretmen x, Ogretmen y)
        {
            if (x.toplam_ders > y.toplam_ders) return 1;
            else return -1;
        }
    }
}
