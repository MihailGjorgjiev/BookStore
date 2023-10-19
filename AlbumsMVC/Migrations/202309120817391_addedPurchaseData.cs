namespace AlbumsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPurchaseData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        CardNumber = c.String(),
                        FullName = c.String(),
                        CVV = c.String(),
                        ExpirationDate = c.DateTime(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PurchaseDatas");
        }
    }
}
