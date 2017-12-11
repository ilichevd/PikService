namespace DataAccessLevel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01_InitialModelCreating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catalogs",
                c => new
                    {
                        CatalogId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Descr = c.String(),
                    })
                .PrimaryKey(t => t.CatalogId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        CatalogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Catalogs", t => t.CatalogId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CatalogId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        FIO = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "CatalogId", "dbo.Catalogs");
            DropIndex("dbo.Tasks", new[] { "CatalogId" });
            DropIndex("dbo.Tasks", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
            DropTable("dbo.Catalogs");
        }
    }
}
