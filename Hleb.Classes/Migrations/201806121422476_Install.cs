namespace Hleb.Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Install : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipeId = c.String(),
                        UserId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favourites", "UserId", "dbo.Users");
            DropIndex("dbo.Favourites", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Favourites");
        }
    }
}
