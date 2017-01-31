namespace w03b.Migrations.AddressMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceCode = c.String(nullable: false, maxLength: 128),
                        ProvinceName = c.String(),
                    })
                .PrimaryKey(t => t.ProvinceCode);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        Population = c.Int(nullable: false),
                        Province_ProvinceCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Provinces", t => t.Province_ProvinceCode)
                .Index(t => t.Province_ProvinceCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "Province_ProvinceCode", "dbo.Provinces");
            DropIndex("dbo.Cities", new[] { "Province_ProvinceCode" });
            DropTable("dbo.Cities");
            DropTable("dbo.Provinces");
        }
    }
}
