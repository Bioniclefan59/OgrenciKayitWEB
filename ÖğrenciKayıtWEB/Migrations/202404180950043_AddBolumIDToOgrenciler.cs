namespace ÖğrenciKayıtWEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBolumIDToOgrenciler : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ogrenciler", "BolumID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ogrenciler", "BolumID");
        }
    }
}
