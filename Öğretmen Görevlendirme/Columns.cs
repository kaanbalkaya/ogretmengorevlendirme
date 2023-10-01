using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Öğretmen_Görevlendirme
{
    namespace OgretmenListesi
    {

        //<summary>
        //Öğretmen listesi.xlsx dosyasındaki sütun isimleri 
        //</summary>
        enum Columns
        {
            Sira,
            Brans,
            TC_No,
            Ad_Soyadi,
            Kadro_Kurum_Kodu,
            Kadro_Ders_Sayisi = 6,
            Gorevlendirme_Kurum_Kodu,
            Gorevlendirme_Ders_Sayisi = 9,
            Toplam_Ders_Sayisi,
            Ozel_Durum
        }
    }
    namespace OkulListesi
    {
        enum Columns
        {
            Sira,
            Kurum_Kodu,
            Kurum_Adi,

        }

    }


    namespace IhtiyacListesi
    {
        enum Columns
        {
            //S.N.	Kurum Kodu	Okul Adı	Dersin Adı	Girilecek Ders Saati	İhtiyaç Nedeni (Boş Norm, Asker, Raporlu,  Ücretsiz İzinli, Sözleşmeli Öğrt., Grv. İdareci Yerine vb.)	
            //ÖĞRETMEN BİLGİSİ	Varsa İhtiyacın Sona Ereceği Tarih
            Sira,
            Kurum_Kodu,
            Ders = 3,
            Ders_Saati,
            Ihtiyac_Nedeni,
            Ogretmen_Bilgisi,
            Ihtiyacin_Sona_Erme_Tarihi

        }
    }
}
