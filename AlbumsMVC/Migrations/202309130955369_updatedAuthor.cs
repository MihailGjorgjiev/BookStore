namespace AlbumsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedAuthor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "Description", c => c.String());
            AlterColumn("dbo.Authors", "ImageURL", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "ImageURL", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "Description", c => c.String(nullable: false));
        }
    }
}
