namespace AlbumsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBooks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Description");
        }
    }
}
