using DevExpress.XtraRichEdit.API.Native;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Db;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OgrenciDbContext dc = new OgrenciDbContext();

        public List<DersProgrami> DersProgramiListeFiltreli { get; set; }
        public List<Ogretmen> OgretmenListesi { get;  set; }

        public List<Sinif> SinifListesi { get; set; }

        public MainWindow()
        {
          

            this.Loaded += MainWindow_Loaded;
            OgretmenListesi = dc.OgretmenBilgileri.ToList();
            SinifListesi=dc.SinifListesi.ToList();

            this.DataContext = OgretmenListesi;




        }

      
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            this.btn1.Click += Btn1_Click;
            this.btn2.Click += Btn2_Click;
            this.btn3.Click += Btn3_Click;

            btnKaydet.Click += BtnKaydet_Click;



            OgretmenListesi = dc.OgretmenBilgileri.ToList();


            cboSinifListesi.ItemsSource = SinifListesi;
            cboSinifListesi.DisplayMember = "SinifAd";



            cboOgretmenler.ItemsSource = OgretmenListesi;

            cboOgretmenler.DisplayMember = "AdSoyad";

            dtDersGunu.EditValue = DateTime.Now.Date;

            
            
            tw1.AddingNewRow += (sender, e) =>
            {
                var dersGunu = (DateTime)dtDersGunu.EditValue;
                e.NewObject = new DersProgrami()
                {
                   Tarih= dersGunu
                };
            };


            tw1.RowUpdated += (sender, e) =>
            {
                //var satir = e.Row as DersProgrami;

                //if(satir.Id==0)
                //{
                //    dc.DersProgramlari.Add(satir);
                //    dc.SaveChanges();
                //}
                //else
                //{
                //    var cevap = OgretmenGuncellemeKontrol(satir);

                //    if(cevap.Length>0)
                //    {
                //        MessageBox.Show(cevap);
                //        return;
                //    }

                //    dc.SaveChanges(true);
                //}
            };

            tw1.ValidateCell += (sender, e) =>
            {
                

                var satir1 = e.Row as DersProgrami;

              
                //var kopyaSatir_str= JsonConvert.SerializeObject(satir1);
                //var kopyaSatir = JsonConvert.DeserializeObject(kopyaSatir_str) as DersProgrami;

                //kopyaSatir.Ders3 = e.Value?.ToString();


                var cevap1 = OgretmenGuncellemeKontrol(satir1);

                if (cevap1.Length > 0)
                {
                    MessageBox.Show(cevap1);

                    e.SetError(cevap1);
                    return;
                }

               
            };



        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            var dersGunu = (DateTime)dtDersGunu.EditValue;

            DersProgramiListeFiltreli = dc.DersProgramlari
                .Where(c=>c.Tarih== dersGunu)
                .Where(c => c.Sinif1 == cboSinifListesi.Text || c.Sinif2 == cboSinifListesi.Text || c.Sinif3 == cboSinifListesi.Text)
                .ToList();

            grd1.ItemsSource = DersProgramiListeFiltreli;

        }

        public string OgretmenGuncellemeKontrol(DersProgrami dersSatir)
        {

            var validationText = "";

            var ders1_liste = DersProgramiListeFiltreli
                .Where(c => c.Ders1 != null)
                .Select(c => c.Ders1)
                .GroupBy(g => g.ToString())
                .Select(std => new
                 {
                     Key = std.Key,

                     TekrarSayisi = std.Count()
                 })
                .ToList();

            var ders1_tekrar_varmi = ders1_liste.Any(c => c.TekrarSayisi > 1);

            if (ders1_tekrar_varmi) validationText += "Ders1 için yinelenen değerler mevcut.\r\n";

            /////////////////////////////////////////
            
            var ders2_liste = DersProgramiListeFiltreli
                .Where(c => c.Ders2 != null)
                .Select(c => c.Ders2)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var ders2_tekrar_varmi = ders2_liste.Any(c => c.TekrarSayisi > 1);

            if (ders2_tekrar_varmi) validationText += "Ders2 için yinelenen değerler mevcut..\r\n";

            /////////////////////////////////////////

            var ders3_liste = DersProgramiListeFiltreli
                .Where(c => c.Ders3 != null)
                .Select(c => c.Ders3)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var ders3_tekrar_varmi = ders3_liste.Any(c => c.TekrarSayisi > 1);

            if (ders3_tekrar_varmi) validationText += "Ders3 için yinelenen değerler mevcut..\r\n";
            /////////////////////////////////////////

            var ders4_liste = DersProgramiListeFiltreli
                .Where(c => c.Ders4 != null)
                .Select(c => c.Ders4)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var ders4_tekrar_varmi = ders4_liste.Any(c => c.TekrarSayisi > 1);

            if (ders4_tekrar_varmi) validationText += "Ders4 için yinelenen değerler mevcut.";

            /////////////////////////////////////////

            var ders5_liste = DersProgramiListeFiltreli
                .Where(c => c.Ders5 != null)
                .Select(c => c.Ders5)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var ders5_tekrar_varmi = ders5_liste.Any(c => c.TekrarSayisi > 1);

            if (ders5_tekrar_varmi) validationText += "Ders5 için yinelenen değerler mevcut.";

            /////////////////////////////////////////

            var ders6_liste = DersProgramiListeFiltreli
                .Where(c => c.Ders6 != null)
                .Select(c => c.Ders6)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var ders6_tekrar_varmi = ders6_liste.Any(c => c.TekrarSayisi > 1);

            if (ders6_tekrar_varmi) validationText += "Ders6 için yinelenen değerler mevcut.";

            /////////////////////////////////////////

            var ders7_liste = DersProgramiListeFiltreli
                .Where(c => c.Ders7 != null)
                .Select(c => c.Ders7)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var ders7_tekrar_varmi = ders7_liste.Any(c => c.TekrarSayisi > 1);

            if (ders7_tekrar_varmi) validationText += "Ders7 için yinelenen değerler mevcut.";

            /////////////////////////////////////////

            var ders8_liste = DersProgramiListeFiltreli
                .Where(c => c.Ders8 != null)
                .Select(c => c.Ders8)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var ders8_tekrar_varmi = ders8_liste.Any(c => c.TekrarSayisi > 1);

            if (ders8_tekrar_varmi) validationText += "Ders8 için yinelenen değerler mevcut.";

            /////////////////////////////////////////

            var ders9_liste = DersProgramiListeFiltreli
                .Where(c => c.Ders9 != null)
                .Select(c => c.Ders9)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var ders9_tekrar_varmi = ders9_liste.Any(c => c.TekrarSayisi > 1);

            if (ders9_tekrar_varmi) validationText += "Ders9 için yinelenen değerler mevcut.";

            /////////////////////////////////////////

            var ders10_liste = DersProgramiListeFiltreli
                .Where(c => c.Ders10 != null)
                .Select(c => c.Ders10)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var ders10_tekrar_varmi = ders10_liste.Any(c => c.TekrarSayisi > 1);

            if (ders10_tekrar_varmi) validationText += "Ders10 için yinelenen değerler mevcut.";

            /////////////////////////////////////////

            var ders11_liste = DersProgramiListeFiltreli
                .Where(c => c.Ders11 != null)
                .Select(c => c.Ders11)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var ders11_tekrar_varmi = ders11_liste.Any(c => c.TekrarSayisi > 1);

            if (ders11_tekrar_varmi) validationText += "Ders11 için yinelenen değerler mevcut.";

            /////////////////////////////////////////

            var sinif1_liste = DersProgramiListeFiltreli
                .Where(c => c.Sinif1 != null)
                .Select(c => c.Sinif1)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var sinif1_tekrar_varmi = sinif1_liste.Any(c => c.TekrarSayisi > 1);

            if (sinif1_tekrar_varmi) validationText += "Sinif1 için yinelenen değerler mevcut.";

            /////////////////////////////////////////

            var sinif2_liste = DersProgramiListeFiltreli
                .Where(c => c.Sinif2 != null)
                .Select(c => c.Sinif2)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var sinif2_tekrar_varmi = sinif2_liste.Any(c => c.TekrarSayisi > 1);

            if (sinif2_tekrar_varmi) validationText += "Sinif2 için yinelenen değerler mevcut.";

            /////////////////////////////////////////

            var sinif3_liste = DersProgramiListeFiltreli
                .Where(c => c.Sinif3 != null)
                .Select(c => c.Sinif3)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var sinif3_tekrar_varmi = sinif1_liste.Any(c => c.TekrarSayisi > 1);

            if (sinif3_tekrar_varmi) validationText += "Sinif3 için yinelenen değerler mevcut.";

            /////////////////////////////////////////

            var sinif4_liste = DersProgramiListeFiltreli
                .Where(c => c.Sinif4 != null)
                .Select(c => c.Sinif4)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var sinif4_tekrar_varmi = sinif4_liste.Any(c => c.TekrarSayisi > 1);

            if (sinif4_tekrar_varmi) validationText += "Sinif4 için yinelenen değerler mevcut.";

            /////////////////////////////////////////

            var sinif5_liste = DersProgramiListeFiltreli
                .Where(c => c.Sinif5 != null)
                .Select(c => c.Sinif5)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var sinif5_tekrar_varmi = sinif5_liste.Any(c => c.TekrarSayisi > 1);

            if (sinif5_tekrar_varmi) validationText += "Sinif5 için yinelenen değerler mevcut.";

            /////////////////////////////////////////

            var sinif6_liste = DersProgramiListeFiltreli
                .Where(c => c.Sinif6 != null)
                .Select(c => c.Sinif6)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var sinif6_tekrar_varmi = sinif6_liste.Any(c => c.TekrarSayisi > 1);

            if (sinif6_tekrar_varmi) validationText += "Sinif6 için yinelenen değerler mevcut.";

            /////////////////////////////////////////

            var sinif7_liste = DersProgramiListeFiltreli
                .Where(c => c.Sinif7 != null)
                .Select(c => c.Sinif7)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var sinif7_tekrar_varmi = sinif7_liste.Any(c => c.TekrarSayisi > 1);

            if (sinif7_tekrar_varmi) validationText += "Sinif7 için yinelenen değerler mevcut.";

            /////////////////////////////////////////

            var sinif8_liste = DersProgramiListeFiltreli
                .Where(c => c.Sinif8 != null)
                .Select(c => c.Sinif8)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var sinif8_tekrar_varmi = sinif8_liste.Any(c => c.TekrarSayisi > 1);

            if (sinif8_tekrar_varmi) validationText += "Sinif8 için yinelenen değerler mevcut.";

            /////////////////////////////////////////

            var sinif9_liste = DersProgramiListeFiltreli
                .Where(c => c.Sinif9 != null)
                .Select(c => c.Sinif9)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var sinif9_tekrar_varmi = sinif9_liste.Any(c => c.TekrarSayisi > 1);

            if (sinif9_tekrar_varmi) validationText += "Sinif9 için yinelenen değerler mevcut.";

            /////////////////////////////////////////

            var sinif10_liste = DersProgramiListeFiltreli
                .Where(c => c.Sinif10 != null)
                .Select(c => c.Sinif10)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var sinif10_tekrar_varmi = sinif10_liste.Any(c => c.TekrarSayisi > 1);

            if (sinif10_tekrar_varmi) validationText += "Sinif10 için yinelenen değerler mevcut.";

            /////////////////////////////////////////

            var sinif11_liste = DersProgramiListeFiltreli
                .Where(c => c.Sinif11 != null)
                .Select(c => c.Sinif11)
                .GroupBy(g => g.ToString())
                .Select(std => new
                {
                    Key = std.Key,

                    TekrarSayisi = std.Count()
                })
                .ToList();

            var sinif11_tekrar_varmi = sinif11_liste.Any(c => c.TekrarSayisi > 1);

            if (sinif11_tekrar_varmi) validationText += "Sinif11 için yinelenen değerler mevcut.";

            return validationText;
        }
      

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            var dersGunu = (DateTime)dtDersGunu.EditValue;

            DersProgramiListeFiltreli = dc.DersProgramlari
                .Where(c => c.Tarih == dersGunu)
                .ToList();

            grd1.ItemsSource = DersProgramiListeFiltreli;
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {

            //if(cboOgretmenler.SelectedItem==null)
            //{
            //    MessageBox.Show("Öğretmen seçiniz");
            //    return;
            //}




            var adsoyad = cboOgretmenler.Text;

            //adsoyad = t1.Text;

            DersProgramiListeFiltreli = dc.DersProgramlari
                .Where(c => (c.Ders1 != null && c.Ders1.Contains(adsoyad))
                || (c.Ders2 != null && c.Ders2.Contains(adsoyad))
                || (c.Ders3 != null && c.Ders3.Contains(adsoyad))
                || (c.Ders4 != null && c.Ders4.Contains(adsoyad))
                || (c.Ders5 != null && c.Ders5.Contains(adsoyad))
                || (c.Ders6 != null && c.Ders5.Contains(adsoyad))
                || (c.Ders7 != null && c.Ders5.Contains(adsoyad))
                || (c.Ders8 != null && c.Ders5.Contains(adsoyad))
                || (c.Ders9 != null && c.Ders5.Contains(adsoyad))
                || (c.Ders10 != null && c.Ders5.Contains(adsoyad))
                || (c.Ders11 != null && c.Ders5.Contains(adsoyad))
                )
                .ToList();

            grd1.ItemsSource = DersProgramiListeFiltreli;
        }


        private void BtnKaydet_Click(object sender, RoutedEventArgs e)
        {
            dc.SaveChanges();
        }

    }
}
