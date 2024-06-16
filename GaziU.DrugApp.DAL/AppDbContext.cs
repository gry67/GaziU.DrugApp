using GaziU.DrugApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaziU.DrugApp.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DrugManagementApp;Integrated Security=True;");
        }

        public DbSet<BarnesAkatiziOlcegi> BarnesAkatiziKayitlari { get; set; }
        public DbSet<BeckAnksiyeteOlcegiKayit> BeckAnksiyeteKayitlari { get; set; }
        public DbSet<BeckDepresyonOlcegiKayit> BeckDepresyonKayitlari { get; set; }
        public DbSet<ActiveIngredient> ActiveIngredients { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<MedicineType> MedicineTypes { get; set;}
        public DbSet<Hasta> Hastalar{ get; set;}
        public DbSet<Doktor> Doktorlar{ get; set;}
        public DbSet<DoktorMuayeneKaydi> doktorMuayeneKayitlari{ get; set;}
        public DbSet<HastaIlacKayit> HastaIlacKayitlari{ get; set;}



    }
}
