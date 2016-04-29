namespace PintrestClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixpins : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotoUrl = c.String(),
                        Body = c.String(),
                        PinUrl = c.String(),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.UserId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pins", "UserId_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Pins", new[] { "UserId_Id" });
            DropTable("dbo.Pins");
        }
    }
}
