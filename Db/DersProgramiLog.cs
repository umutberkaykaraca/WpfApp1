using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Db
{
    public class DersProgramiLog
    {
        [Key]
        public int Id { get; set; }
        public string DersDegisimNot { get; set; }
        public DateTime Tarih { get; set; }
        public string Guncelleyen { get; set; }

    }
}
