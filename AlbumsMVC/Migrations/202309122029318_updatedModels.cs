namespace AlbumsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "UserId" });
            AlterColumn("dbo.Orders", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.PurchaseDatas", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.PurchaseDatas", "CardNumber", c => c.String(nullable: false));
            AlterColumn("dbo.PurchaseDatas", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.PurchaseDatas", "CVV", c => c.String(nullable: false));
            AlterColumn("dbo.PurchaseDatas", "Address", c => c.String(nullable: false));
            CreateIndex("dbo.Orders", "UserId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "UserId" });
            AlterColumn("dbo.PurchaseDatas", "Address", c => c.String());
            AlterColumn("dbo.PurchaseDatas", "CVV", c => c.String());
            AlterColumn("dbo.PurchaseDatas", "FullName", c => c.String());
            AlterColumn("dbo.PurchaseDatas", "CardNumber", c => c.String());
            AlterColumn("dbo.PurchaseDatas", "Email", c => c.String());
            AlterColumn("dbo.Orders", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "UserId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
