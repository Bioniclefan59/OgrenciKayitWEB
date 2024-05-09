using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OgrenciBilgiKayit.Entity_Classes;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OgrenciBilgiKayitWEB.OkulDBContext
{
    public class OkulDBCntxt : DbContext
    {
        public DbSet<Ogrenciler> Ogrenciler { get; set; }
        public DbSet<Dersler> Dersler { get; set; }
        public DbSet<Notlar> Notlar { get; set; }
        public DbSet<Bolumler> Bolumler { get; set; }
        public DbSet<OgrenciAtamalari> OgrenciAtamalari { get; set; }
        //public DbSet<Kullanici> Kullanici { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenciler>().ToTable("Ogrenciler");
            modelBuilder.Entity<Dersler>().ToTable("Dersler");
            modelBuilder.Entity<Notlar>().ToTable("Notlar");
            modelBuilder.Entity<Bolumler>().ToTable("Bolumler");
            modelBuilder.Entity<OgrenciAtamalari>().ToTable("OgrenciAtamalari");
            //modelBuilder.Entity<Kullanici>().ToTable("Kullanici");

            modelBuilder.Entity<Bolumler>().HasKey(e => e.BolumID);
            modelBuilder.Entity<Dersler>().HasKey(e => e.DersID);
            modelBuilder.Entity<Notlar>().HasKey(e => new { e.ogrenci_no, e.ders_id });
            modelBuilder.Entity<Ogrenciler>().HasKey(e => e.ogrenci_no);
            modelBuilder.Entity<OgrenciAtamalari>().HasKey(e => e.AtamaID);
            //modelBuilder.Entity<Kullanici>().HasKey(e => e.Id);
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public OkulDBCntxt() : base("name=cnt")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OkulDBCntxt>());
            Database.SetInitializer(new CreateDatabaseIfNotExists<OkulDBCntxt>());
        }
        public void BolumleriDoldur()
        {
            if (!Bolumler.Any())
            {
                var branches = new List<Bolumler>
                {
                    new Bolumler { BolumAdi = "Bilgisayar Mühendisliği" },
                    new Bolumler { BolumAdi = "Elektrik Elektronik Mühendisliği" },
                    new Bolumler { BolumAdi = "Mekatronik Mühendisliği" },
                    new Bolumler { BolumAdi = "Makine Mühendisliği" },
                    new Bolumler { BolumAdi = "Metalurji" },
                    new Bolumler { BolumAdi = "İnşaat Mühendisliği" },
                    new Bolumler { BolumAdi = "Yazılım Mühendisliği" }
                };

                Bolumler.AddRange(branches);
                SaveChanges();
            }
        }
        public void OrnekDersleDoldur()
        {
            using (var dbContext = new OkulDBCntxt())
            {
                if (!dbContext.Dersler.Any())
                {
                    var bolumNames = new List<string>
            {
                "Bilgisayar Mühendisliği",
                "Elektrik Elektronik Mühendisliği",
                "Mekatronik Mühendisliği",
                "Makine Mühendisliği",
                "Metalurji",
                "İnşaat Mühendisliği",
                "Yazılım Mühendisliği"
            };

                    var sampleDersler = new List<Dersler>();
                    foreach (var bolumName in bolumNames)
                    {
                        for (int i = 1; i <= 4; i++)
                        {
                            var bolumID = dbContext.Bolumler.FirstOrDefault(b => b.BolumAdi == bolumName)?.BolumID ?? 0;

                            var ders = new Dersler
                            {
                                BolumID = bolumID,
                                DersKodu = $"{bolumName.Substring(0, 3)}{i}",
                                DersAdi = $"{bolumName} Ders{i}",
                                Kredi = 3
                            };
                            sampleDersler.Add(ders);
                        }
                    }

                    dbContext.Dersler.AddRange(sampleDersler);
                    dbContext.SaveChanges();
                }
            }
        }
        public void InsertOgrenciAtama(int ogrenciNo, int dersID)
        {
            var atama = new OgrenciAtamalari
            {
                ogrenci_no = ogrenciNo,
                DersID = dersID
            };

            OgrenciAtamalari.Add(atama);
            SaveChanges();
        }
        /*protected override void Seed(OkulDBCntxt cntxt)
        {
            cntxt.Kullanici.AddOrUpdate(u => u.KullaniciAdi,
                new kullanici { KullaniciAdi = "admin", Sifre = "admin123" });
        }*/
    }
}