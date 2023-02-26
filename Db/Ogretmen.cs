using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Db
{
    public class Ogretmen: BindableBase
    {

        [Key]
        public int Id { get; set; }
       

        public string AdSoyad
        {
            get { return GetValue<string>(nameof(AdSoyad)); }
            set { SetValue(value, nameof(AdSoyad)); }
        }

        public bool AktifMi { get; set; }
    }
}
