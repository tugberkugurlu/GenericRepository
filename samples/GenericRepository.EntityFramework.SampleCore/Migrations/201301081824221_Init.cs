namespace GenericRepository.EntityFramework.SampleCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ISOCode = c.String(),
                        CreatedOn = c.DateTimeOffset(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resorts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        Name = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        CreatedOn = c.DateTimeOffset(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResortId = c.Int(nullable: false),
                        Name = c.String(),
                        Category = c.Int(nullable: false),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        CreatedOn = c.DateTimeOffset(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resorts", t => t.ResortId, cascadeDelete: true)
                .Index(t => t.ResortId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Hotels", new[] { "ResortId" });
            DropIndex("dbo.Resorts", new[] { "CountryId" });
            DropForeignKey("dbo.Hotels", "ResortId", "dbo.Resorts");
            DropForeignKey("dbo.Resorts", "CountryId", "dbo.Countries");
            DropTable("dbo.Hotels");
            DropTable("dbo.Resorts");
            DropTable("dbo.Countries");
        }
    }
}
