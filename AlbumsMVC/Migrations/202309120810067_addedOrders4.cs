namespace AlbumsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOrders4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DateOfPurchase", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "DateOfPurchase");
        }
    }
}
