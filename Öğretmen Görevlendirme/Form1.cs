using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Runtime.CompilerServices;

namespace Öğretmen_Görevlendirme
{

    public partial class Form1 : Form
    {   //<summary>
        //Bolgeler[bolge_ismi]=list<Okul>
        //</summary>
        Dictionary<string, List<Okul>> bolgeler;

        //<summary>
        //okullar[kurum_kodu]=kurum
        //</summary>
        Dictionary<string, Okul> okullar;

        //<summary>
        //ogretmenler[tc_no]=ogretmen
        //</summary>
        Dictionary<string, Ogretmen> ogretmenler;

        //<summary>
        //bolgebransihtiyaclar[bolge][ders]=list<ihtiyac>
        //</summary>
        Dictionary<string, Dictionary<string, List<Ihtiyac>>> bolgebransihtiyaclar;

        //<summary>
        //bolgebransogretmenler[bolge][ders]=list<ogretmen>
        //</summary>
        Dictionary<string, Dictionary<string, List<Ogretmen>>> bolgebransogretmenler;

        //<summary>
        //bolgeihtiyacogretmen[bolge].add(tuple<ihtiyac,ogretmen>)
        //</summary>
        Dictionary<string, List<Tuple<Ihtiyac, Ogretmen>>> bolgeihtiyacogretmen;

        public void init()
        {
            bolgeler = new Dictionary<string, List<Okul>>();
            okullar = new Dictionary<string, Okul>();
            ogretmenler = new Dictionary<string, Ogretmen>();
            bolgebransihtiyaclar = new Dictionary<string, Dictionary<string, List<Ihtiyac>>>();
            bolgebransogretmenler = new Dictionary<string, Dictionary<string, List<Ogretmen>>>();
            bolgeihtiyacogretmen = new Dictionary<string, List<Tuple<Ihtiyac, Ogretmen>>>();
        }

        public Form1()
        {
            init();
            InitializeComponent();
        }

        private void bolgeBtn_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            SpreadsheetDocument spreadsheetDocument;
            try
            {
                spreadsheetDocument = SpreadsheetDocument.Open(openFileDialog1.FileName, false);
                openFileDialog1.FileName = string.Empty;
            }
            catch
            {
                MessageBox.Show("Okul bölgeleri dosyasına ulaşılamadı");
                return;
            }

            bolgeBtn.Text += " Yüklendi.";
            bolgeBtn.Enabled = false;
            ReadBolgeFileDOM(spreadsheetDocument);
            foreach (var bolge in bolgeler.Keys)
            {
                bolgelerCombo.Items.Add(bolge);

            }
            ogretmenBtn.Visible = true;
            ogretmenBtn.Enabled = true;


        }



        //<summary>
        //Bolgeler.xlsx dosyasından verileri okumak için kullanılan fonksiyon
        //</summary>
        private void ReadBolgeFileDOM(SpreadsheetDocument spreadsheetDocument)
        {
            WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
            WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
            SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
            var stringTable = spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();


            if (stringTable == null)
            {
                MessageBox.Show("stringable not found, sorry!!!");
                return;
            }

            string bolge = string.Empty;
            foreach (var r in sheetData.Elements<Row>())
            {

                string sira = string.Empty;
                string kurum_kodu = string.Empty;
                string kurum_adi = string.Empty;

                int cell_counter = 0;
                foreach (Cell c in r.Elements<Cell>())
                {

                    var value = c.InnerText;
                    if (value == "")
                        break;
                    if (c.DataType != null)
                    {
                        if (c.DataType.Value == CellValues.SharedString)
                        {

                            value = stringTable.SharedStringTable.ElementAt(int.Parse(value)).InnerText;

                            if (value.Contains("Eğitim Bölgesi"))
                            {
                                var subs = value.Split(":");
                                bolge = subs[1];

                                if (!bolgeler.Keys.Contains<string>(bolge))
                                {
                                    bolgeler[bolge] = new List<Okul>();
                                }

                            }

                            if (value.Contains("Sıra"))
                                break;

                        }
                    }

                    OkulListesi.Columns column = (OkulListesi.Columns)cell_counter++;

                    switch (column)
                    {
                        case OkulListesi.Columns.Sira:
                            sira = value; break;
                        case OkulListesi.Columns.Kurum_Kodu:
                            kurum_kodu = value; break;
                        case OkulListesi.Columns.Kurum_Adi:
                            kurum_adi = value; break;

                    }

                }


                if (bolge != string.Empty && sira != string.Empty && kurum_kodu != string.Empty && kurum_adi != string.Empty)
                {
                    var okul = new Okul(sira, kurum_kodu, kurum_adi, bolge);
                    okullar[okul.kurum_kodu] = okul;
                    bolgeler[bolge].Add(okul);
                }

            }

        }

        private void ogretmenBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            SpreadsheetDocument spreadsheetDocument;
            try
            {
                spreadsheetDocument = SpreadsheetDocument.Open(openFileDialog1.FileName, false);
                openFileDialog1.FileName = string.Empty;
            }
            catch
            {
                MessageBox.Show("öğretmen listesi dosyasına ulaşılamadı");
                return;
            }

            ogretmenBtn.Text += " Yüklendi.";
            ogretmenBtn.Enabled = false;
            ReadOgretmenFileDOM(spreadsheetDocument);

            ihtiyacBtn.Visible = true;
            ihtiyacBtn.Enabled = true;

        }


        private void ReadOgretmenFileDOM(SpreadsheetDocument spreadsheetDocument)
        {

            WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
            var stringTable = spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();


            if (stringTable == null)
            {
                MessageBox.Show("stringable not found, sorry!!!");
                return;
            }

            foreach (WorksheetPart worksheetPart in spreadsheetDocument.WorkbookPart.WorksheetParts)
            {

                foreach (SheetData sheetData in worksheetPart.Worksheet.Elements<SheetData>())
                {

                    if (sheetData.HasChildren)
                    {
                        int irow = 0;
                        foreach (Row row in sheetData.Elements<Row>())
                        {

                            if (irow++ < 3)
                                continue;

                            string sira = string.Empty;
                            string brans = string.Empty;
                            string tc_kimlik = string.Empty;
                            string ad_soyad = string.Empty;
                            //kadrosunun olduğu okul ve okuldaki ders sayısını tutar.
                            Okul kadrolu_okul = new Okul();
                            int kadro_ders_sayisi = 0;
                            Tuple<Okul, int> kadrolu_kayit = null;
                            //okul ile o okuldaki ders sayısını tutan tupleların oluşturduğu liste, öğretmenin görevlendirildiği tüm okulları kaydeder.
                            int gorevlendirme_ders_sayisi = 0;
                            Tuple<Okul, int> gorevlendirme = null;
                            Okul tmp_okul = new Okul();
                            int toplam_ders = 0;
                            int cell_counter = 0;

                            foreach (Cell c in row.Elements<Cell>())
                            {
                                var value = c.InnerText;
                                OgretmenListesi.Columns column = (OgretmenListesi.Columns)cell_counter++;

                                if (value == "" || value.Contains("ÖĞRETMEN GÖREVLENDİRME LİSTESİ") || value.Contains("S.N."))
                                    break;
                                if (c.DataType != null)
                                {
                                    if (c.DataType.Value == CellValues.SharedString)
                                        value = stringTable.SharedStringTable.ElementAt(int.Parse(value)).InnerText;

                                }

                                switch (column)
                                {
                                    case OgretmenListesi.Columns.Sira: sira = value; break;
                                    case OgretmenListesi.Columns.Brans: brans = value; break;
                                    case OgretmenListesi.Columns.TC_No: tc_kimlik = value; break;
                                    case OgretmenListesi.Columns.Ad_Soyadi: ad_soyad = value; break;
                                    case OgretmenListesi.Columns.Kadro_Kurum_Kodu:
                                        kadrolu_okul = okullar[value];
                                        break;
                                    case OgretmenListesi.Columns.Kadro_Ders_Sayisi:
                                        kadro_ders_sayisi = int.Parse(value);
                                        kadrolu_kayit = new Tuple<Okul, int>(kadrolu_okul, kadro_ders_sayisi);
                                        break;
                                    case OgretmenListesi.Columns.Gorevlendirme_Kurum_Kodu:
                                        tmp_okul = okullar[value];
                                        break;
                                    case OgretmenListesi.Columns.Gorevlendirme_Ders_Sayisi:
                                        gorevlendirme_ders_sayisi = int.Parse(value);
                                        gorevlendirme = new Tuple<Okul, int>(tmp_okul, gorevlendirme_ders_sayisi);
                                        break;
                                    case OgretmenListesi.Columns.Toplam_Ders_Sayisi:
                                        toplam_ders = int.Parse(value);
                                        break;
                                    case OgretmenListesi.Columns.Ozel_Durum:
                                        string ozel_durum = value;
                                        Ogretmen ogretmen = new Ogretmen(sira, brans, tc_kimlik, ad_soyad, kadrolu_kayit, gorevlendirme, toplam_ders, ozel_durum);

                                        if (!ogretmenler.Keys.Contains(tc_kimlik))
                                        {
                                            ogretmenler[tc_kimlik] = ogretmen;
                                        }
                                        else
                                        {
                                            ogretmenler[tc_kimlik].add_gorevlendirme(gorevlendirme);
                                        }


                                        if (!bolgebransogretmenler.Keys.Contains(kadrolu_okul.bolge))
                                            bolgebransogretmenler[kadrolu_okul.bolge] = new Dictionary<string, List<Ogretmen>>();
                                        if (!bolgebransogretmenler[kadrolu_okul.bolge].Keys.Contains(brans))
                                            bolgebransogretmenler[kadrolu_okul.bolge][brans] = new List<Ogretmen>();
                                        bolgebransogretmenler[kadrolu_okul.bolge][brans].Add(ogretmen);
                                        break;

                                }

                            }
                        }
                    }
                }
            }
        }

        private void ihtiyacBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            SpreadsheetDocument spreadsheetDocument;
            try
            {
                spreadsheetDocument = SpreadsheetDocument.Open(openFileDialog1.FileName, false);
                openFileDialog1.FileName = string.Empty;
            }
            catch
            {
                MessageBox.Show("ihtiyaç listesi dosyasına ulaşılamadı");
                return;
            }

            ihtiyacBtn.Text += " Yüklendi.";
            ihtiyacBtn.Enabled = false;
            ReadIhtiyacFileDOM(spreadsheetDocument);

            bolgelerCombo.Enabled = true;
            bolgelerCombo.Visible = true;

        }

        private void ReadIhtiyacFileDOM(SpreadsheetDocument spreadsheetDocument)
        {
            WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
            var stringTable = spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();


            if (stringTable == null)
            {
                MessageBox.Show("stringable not found, sorry!!!");
                return;
            }

            foreach (WorksheetPart worksheetPart in spreadsheetDocument.WorkbookPart.WorksheetParts)
            {

                foreach (SheetData sheetData in worksheetPart.Worksheet.Elements<SheetData>())
                {

                    if (sheetData.HasChildren)
                    {
                        int irow = 0;
                        foreach (Row row in sheetData.Elements<Row>())
                        {

                            if (irow++ < 2)
                            {
                                continue;
                            }
                            //S.N.	Kurum Kodu	Okul Adı	Dersin Adı	Girilecek Ders Saati	İhtiyaç Nedeni
                            //ÖĞRETMEN BİLGİSİ	Varsa İhtiyacın Sona Ereceği Tarih
                            string sira = string.Empty;
                            int ders_sayisi = 0;
                            string ders = string.Empty;
                            string kurum_kodu = string.Empty;
                            //okul ile o okuldaki ders sayısını tutan tupleların oluşturduğu liste
                            Tuple<Okul, int> gorevlendirme = null;
                            string ihtiyac_nedeni = string.Empty;
                            string ogretmen_bilgisi = string.Empty;
                            string sona_erme_tarihi = string.Empty;

                            int cell_counter = 0;

                            foreach (Cell c in row.Elements<Cell>())
                            {
                                var value = c.InnerText;
                                IhtiyacListesi.Columns column = (IhtiyacListesi.Columns)cell_counter++;
                                if (value == "")
                                    continue;
                                if (value.Contains("İHTİYAÇ LİSTESİ") || value.Contains("S.N."))
                                    break;
                                if (c.DataType != null)
                                {
                                    if (c.DataType.Value == CellValues.SharedString)
                                        value = stringTable.SharedStringTable.ElementAt(int.Parse(value)).InnerText;

                                }

                                switch (column)
                                {
                                    case IhtiyacListesi.Columns.Sira: sira = value; break;

                                    case IhtiyacListesi.Columns.Kurum_Kodu: kurum_kodu = value; break;

                                    case IhtiyacListesi.Columns.Ders_Saati:
                                        ders_sayisi = int.Parse(value);
                                        break;

                                    case IhtiyacListesi.Columns.Ders: ders = value; break;
                                    case IhtiyacListesi.Columns.Ihtiyac_Nedeni: ihtiyac_nedeni = value; break;
                                    case IhtiyacListesi.Columns.Ogretmen_Bilgisi: ogretmen_bilgisi = value; break;
                                    case IhtiyacListesi.Columns.Ihtiyacin_Sona_Erme_Tarihi:
                                        sona_erme_tarihi = value;
                                        Ihtiyac ihtiyac = new Ihtiyac(sira, kurum_kodu, ders, ders_sayisi, ihtiyac_nedeni, ogretmen_bilgisi, sona_erme_tarihi);

                                        okullar[kurum_kodu].ihtiyaclar.Add(ihtiyac);
                                        if (!bolgebransihtiyaclar.Keys.Contains(okullar[kurum_kodu].bolge))
                                            bolgebransihtiyaclar[okullar[kurum_kodu].bolge] = new Dictionary<string, List<Ihtiyac>>();
                                        if (!bolgebransihtiyaclar[okullar[kurum_kodu].bolge].Keys.Contains(ders))
                                            bolgebransihtiyaclar[okullar[kurum_kodu].bolge][ders] = new List<Ihtiyac>();
                                        bolgebransihtiyaclar[okullar[kurum_kodu].bolge][ders].Add(ihtiyac);
                                        break;

                                }

                            }
                        }
                    }
                }
            }
            foreach (var bolge in bolgebransogretmenler.Keys)
            {
                foreach (var brans in bolgebransogretmenler[bolge].Keys)
                    bolgebransogretmenler[bolge][brans].Sort(Ogretmen.comparer);

            }
            foreach (var bolge in bolgebransihtiyaclar.Keys)
            {
                foreach (var brans in bolgebransihtiyaclar[bolge].Keys)
                    bolgebransihtiyaclar[bolge][brans].Sort(Ihtiyac.comparer);
            }
        }


        private void bolgelerCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            string bolge = bolgelerCombo.SelectedItem.ToString();
            bransCombo.Items.Clear();

            if (bolgeler.Keys.Contains<string>(bolge))
            {
                if (!bolgebransihtiyaclar.Keys.Contains(bolge))
                {
                    MessageBox.Show("Seçilen bölgede ihitiyaç bulunmamaktadır.");
                    return;
                }
                foreach (var brans in bolgebransihtiyaclar[bolge].Keys)
                {
                    bransCombo.Items.Add(brans);

                }

                bransCombo.Enabled = true;
                bransCombo.Visible = true;
            }

        }
        private void bransCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string brans = bransCombo.SelectedItem.ToString();

            foreach (var bolge in bolgebransogretmenler.Keys)
            {

                if (!bolgebransogretmenler[bolge].Keys.Contains<string>(brans))
                    continue;
                bolgelerList.Items.Add(bolge);

            }

            bolgelerList.Enabled = true;
            bolgelerList.Visible = true;
            secilenbolgelerList.Enabled = true;
            secilenbolgelerList.Visible = true;
            bolgesecBtn.Enabled = true;
            bolgesecBtn.Visible = true;
            bolgesilBtn.Enabled = true;
            bolgesilBtn.Visible = true;

        }

        private void distributeBtn_Click(object sender, EventArgs e)
        {
            if (secilenbolgelerList.Items.Count == 0)
            {
                MessageBox.Show("Bölge Tercihlerinizi Aktarınız.");

            }
            else
            {
                foreach (var b in secilenbolgelerList.Items)
                {
                    string bolge = b.ToString();
                    string brans = bransCombo.SelectedItem.ToString();
                    if (!bolgebransogretmenler[bolge].Keys.Contains(brans))
                    {
                        MessageBox.Show("Seçilen bölgede ilgili branşta öğretmen bulunmuyor.");
                        return;
                    }
                    foreach (var ihtiyac in bolgebransihtiyaclar[bolge][brans])
                    {

                        foreach (var ogretmen in bolgebransogretmenler[bolge][brans])
                        {
                            if (ogretmen.toplam_ders >= 30 || ihtiyac.ders_saati <= 0)
                                continue;

                            if (ihtiyac.ders_saati >= 30 - ogretmen.toplam_ders)
                            {
                                ogretmen.add_gorevlendirme(new Tuple<Okul, int>(okullar[ihtiyac.kurum_kodu], ihtiyac.ders_saati));
                                ogretmen.toplam_ders += ihtiyac.ders_saati;
                                ihtiyac.ders_saati = 0;
                                if (!bolgeihtiyacogretmen.Keys.Contains(bolge))
                                    bolgeihtiyacogretmen[bolge] = new List<Tuple<Ihtiyac, Ogretmen>>();
                                bolgeihtiyacogretmen[bolge].Add(new Tuple<Ihtiyac, Ogretmen>(ihtiyac, ogretmen));
                            }
                        }
                    }
                }
                raporBtn.Visible = true;
                raporBtn.Enabled = true;
            }

        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            init();

            distributeBtn.Text = "Dağıt";
            distributeBtn.Visible = false;
            distributeBtn.Enabled = false;
            // bolgeBtn
            bolgeBtn.Text = "Bölgeler Dosyası";
            bolgeBtn.Enabled = true;
            // openFileDialog1
            openFileDialog1.FileName = string.Empty;
            // textBox1
            textBox1.Text = string.Empty;
            // ogretmenBtn
            ogretmenBtn.Text = "Öğretmen Listesi";
            ogretmenBtn.Enabled = false;
            ogretmenBtn.Visible = false;
            // bolgelerCombo
            bolgelerCombo.Text = "Eğitim Bölgeleri";
            bolgelerCombo.Items.Clear();
            bolgelerCombo.Enabled = false;
            bolgelerCombo.Visible = false;
            // okullarCombo
            bransCombo.Enabled = false;
            bransCombo.Text = "Okullar";
            bransCombo.Items.Clear();
            bransCombo.Enabled = false;
            bransCombo.Visible = false;
            // ihtiyacBtn
            ihtiyacBtn.Text = "İhtiyaç Listesi";
            ihtiyacBtn.Enabled = false;
            ihtiyacBtn.Visible = false;
            //raporBtn
            raporBtn.Visible = false;
            raporBtn.Enabled = false;
            //openFileDialog1
            openFileDialog1.FileName = string.Empty;
            //bolge ListBoxları
            bolgelerList.Enabled = false;
            bolgelerList.Visible = false;
            bolgelerList.Items.Clear();
            secilenbolgelerList.Enabled = false;
            secilenbolgelerList.Visible = false;
            secilenbolgelerList.Items.Clear();
            //bolge listbox butonları
            bolgesecBtn.Enabled = false;
            bolgesecBtn.Visible = false;
            bolgesilBtn.Enabled = false;
            bolgesilBtn.Visible = false;

        }

        private void raporBtn_Click(object sender, EventArgs e)
        {
            foreach (var bolge in bolgeihtiyacogretmen.Keys)
            {
                foreach (var gorevlendirme in bolgeihtiyacogretmen[bolge])
                    textBox1.Text += gorevlendirme.Item1.ToString() + " -> " + gorevlendirme.Item2.ToString() + "  \n";
            }
        }

        private void bolgesecBtn_Click(object sender, EventArgs e)
        {
            if (bolgelerList.SelectedIndex == -1)
            {
                MessageBox.Show("Bölgw seçiniz.");
                return;
            }
            secilenbolgelerList.Items.Add(bolgelerList.Items[bolgelerList.SelectedIndex].ToString());
            bolgelerList.Items.RemoveAt(bolgelerList.SelectedIndex);
            distributeBtn.Enabled = true;
            distributeBtn.Visible = true;
        }

        private void bolgesilBtn_Click(object sender, EventArgs e)
        {
            if (secilenbolgelerList.SelectedIndex == -1)
            {
                MessageBox.Show("Bölgw seçiniz.");
                return;
            }
            bolgelerList.Items.Add(secilenbolgelerList.Items[secilenbolgelerList.SelectedIndex].ToString());
            secilenbolgelerList.Items.RemoveAt(secilenbolgelerList.SelectedIndex);
            if (secilenbolgelerList.Items.Count == 0)
            {
                distributeBtn.Enabled = false;
                distributeBtn.Visible = false;
            }
        }
    }
}