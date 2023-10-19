namespace AlbumsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedAuthorModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Authors", "ImageURL", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "ImageURL");
            DropColumn("dbo.Authors", "Description");
        }
    }
}
