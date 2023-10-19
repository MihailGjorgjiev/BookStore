namespace AlbumsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteStore : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StoreAlbums", "Store_Id", "dbo.Stores");
            DropForeignKey("dbo.StoreAlbums", "Album_Id", "dbo.Albums");
            DropIndex("dbo.StoreAlbums", new[] { "Store_Id" });
            DropIndex("dbo.StoreAlbums", new[] { "Album_Id" });
            DropTable("dbo.Stores");
            DropTable("dbo.StoreAlbums");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StoreAlbums",
                c => new
                    {
                        Store_Id = c.Int(nullable: false),
                        Album_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Store_Id, t.Album_Id });
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.StoreAlbums", "Album_Id");
            CreateIndex("dbo.StoreAlbums", "Store_Id");
            AddForeignKey("dbo.StoreAlbums", "Album_Id", "dbo.Albums", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StoreAlbums", "Store_Id", "dbo.Stores", "Id", cascadeDelete: true);
        }
    }
}
