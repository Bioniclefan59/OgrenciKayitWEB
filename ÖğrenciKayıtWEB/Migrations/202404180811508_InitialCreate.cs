namespace ÖğrenciKayıtWEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bolumler",
                c => new
                    {
                        BolumID = c.Int(nullable: false, identity: true),
                        BolumAdi = c.String(),
                    })
                .PrimaryKey(t => t.BolumID);
            
            CreateTable(
                "dbo.Dersler",
                c => new
                    {
                        DersID = c.Int(nullable: false, identity: true),
                        BolumID = c.Int(nullable: false),
                        DersKodu = c.String(),
                        DersAdi = c.String(),
                        Kredi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DersID)
                .ForeignKey("dbo.Bolumler", t => t.BolumID, cascadeDelete: true)
                .Index(t => t.BolumID);
            
            CreateTable(
                "dbo.Notlar",
                c => new
                    {
                        ogrenci_no = c.Int(nullable: false),
                        ders_id = c.Int(nullable: false),
                        ara_sinav1 = c.Int(nullable: false),
                        ara_sinav2 = c.Int(nullable: false),
                        final = c.Int(nullable: false),
                        Dersler_DersID = c.Int(),
                    })
                .PrimaryKey(t => new { t.ogrenci_no, t.ders_id })
                .ForeignKey("dbo.Dersler", t => t.Dersler_DersID)
                .ForeignKey("dbo.Ogrenciler", t => t.ogrenci_no, cascadeDelete: true)
                .Index(t => t.ogrenci_no)
                .Index(t => t.Dersler_DersID);
            
            CreateTable(
                "dbo.Ogrenciler",
                c => new
                    {
                        ogrenci_no = c.Int(nullable: false, identity: true),
                        ad = c.String(),
                        soyad = c.String(),
                        bolum = c.String(),
                        sinif = c.Int(nullable: false),
                        dogum_tarihi = c.DateTime(nullable: false),
                        cinsiyet = c.String(),
                        kayit_tarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ogrenci_no);
            
            CreateTable(
                "dbo.OgrenciAtamalari",
                c => new
                    {
                        AtamaID = c.Int(nullable: false, identity: true),
                        ogrenci_no = c.Int(nullable: false),
                        DersID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AtamaID)
                .ForeignKey("dbo.Dersler", t => t.DersID, cascadeDelete: true)
                .ForeignKey("dbo.Ogrenciler", t => t.ogrenci_no, cascadeDelete: true)
                .Index(t => t.ogrenci_no)
                .Index(t => t.DersID);
            
            CreateTable(
                "dbo.OgrencilerDerslers",
                c => new
                    {
                        Ogrenciler_ogrenci_no = c.Int(nullable: false),
                        Dersler_DersID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ogrenciler_ogrenci_no, t.Dersler_DersID })
                .ForeignKey("dbo.Ogrenciler", t => t.Ogrenciler_ogrenci_no, cascadeDelete: true)
                .ForeignKey("dbo.Dersler", t => t.Dersler_DersID, cascadeDelete: true)
                .Index(t => t.Ogrenciler_ogrenci_no)
                .Index(t => t.Dersler_DersID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OgrenciAtamalari", "ogrenci_no", "dbo.Ogrenciler");
            DropForeignKey("dbo.OgrenciAtamalari", "DersID", "dbo.Dersler");
            DropForeignKey("dbo.Notlar", "ogrenci_no", "dbo.Ogrenciler");
            DropForeignKey("dbo.OgrencilerDerslers", "Dersler_DersID", "dbo.Dersler");
            DropForeignKey("dbo.OgrencilerDerslers", "Ogrenciler_ogrenci_no", "dbo.Ogrenciler");
            DropForeignKey("dbo.Notlar", "Dersler_DersID", "dbo.Dersler");
            DropForeignKey("dbo.Dersler", "BolumID", "dbo.Bolumler");
            DropIndex("dbo.OgrencilerDerslers", new[] { "Dersler_DersID" });
            DropIndex("dbo.OgrencilerDerslers", new[] { "Ogrenciler_ogrenci_no" });
            DropIndex("dbo.OgrenciAtamalari", new[] { "DersID" });
            DropIndex("dbo.OgrenciAtamalari", new[] { "ogrenci_no" });
            DropIndex("dbo.Notlar", new[] { "Dersler_DersID" });
            DropIndex("dbo.Notlar", new[] { "ogrenci_no" });
            DropIndex("dbo.Dersler", new[] { "BolumID" });
            DropTable("dbo.OgrencilerDerslers");
            DropTable("dbo.OgrenciAtamalari");
            DropTable("dbo.Ogrenciler");
            DropTable("dbo.Notlar");
            DropTable("dbo.Dersler");
            DropTable("dbo.Bolumler");
        }
    }
}
