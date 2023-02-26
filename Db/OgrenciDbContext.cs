using DevExpress.Xpf.Docking.VisualElements;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Db
{
    public class OgrenciDbContext : DbContext
    {

        public DbSet<DersProgrami> DersProgramlari { get; set; }

        public DbSet<DersProgramiLog> DersDegisimLogs { get; set; }

        public DbSet<Ogretmen> OgretmenBilgileri { get; set; }

        public DbSet<Sinif> SinifListesi { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
            var cnnstr = "server=.;database=ogrenciDb;trusted_connection=true;Encrypt=False";
            optionsBuilder.UseSqlServer(cnnstr);

            optionsBuilder.EnableDetailedErrors(true);
           

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DersProgrami>().ToTable(nameof(DersProgrami));
            modelBuilder.Entity<DersProgramiLog>().ToTable(nameof(DersProgramiLog));
            modelBuilder.Entity<Ogretmen>().ToTable(nameof(Ogretmen));
            modelBuilder.Entity<Sinif>().ToTable(nameof(Sinif));

            base.OnModelCreating(modelBuilder);
        }

    }
}
