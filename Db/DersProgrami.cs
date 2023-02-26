using DevExpress.Mvvm;
using DevExpress.Pdf.Native.BouncyCastle.Asn1;
using DevExpress.Portable.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Db
{
    public class DersProgrami: BindableBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
     

        public string Ders1
        {
            get { return GetValue<string>(nameof(Ders1)); }
            set { SetValue(value, nameof(Ders1)); }
        }
        public string? Sinif1 { get; set; }
        public string? Durum1 { get; set; }
        public string? Ders2 {get;set;}
        public string? Sinif2 { get; set; }
        public string? Durum2 { get; set; }
      
        public string Ders3
        {
            get { return GetValue<string>(nameof(Ders3)); }
            set { SetValue(value, nameof(Ders3)); }
        }

        public string? Sinif3 { get; set; }
        public string? Durum3 { get; set; }
        public string? Ders4 { get; set; }
        public string? Sinif4 { get; set; }
        public string? Durum4 { get; set; }
        public string? Ders5 { get; set; }
        public string? Sinif5 { get; set; }
        public string? Durum5 { get; set; }
        public string? Ders6 { get; set; }
        public string? Sinif6 { get; set; }
        public string? Durum6 { get; set; }
        public string? Ders7 { get; set; }
        public string? Sinif7 { get; set; }
        public string? Durum7 { get; set; }
        public string? Ders8 { get; set; }
        public string? Sinif8 { get; set; }
        public string? Durum8 { get; set; }
        public string? Ders9 { get; set; }
        public string? Sinif9 { get; set; }
        public string? Durum9 { get; set; }
        public string? Ders10 { get; set; }
        public string? Sinif10 { get; set; }
        public string? Durum10 { get; set; }
        public string? Ders11 { get; set; }
        public string? Sinif11 { get; set; }
        public string? Durum11 { get; set; }


    }
}
