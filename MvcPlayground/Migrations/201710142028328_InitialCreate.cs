namespace MvcPlayground.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArtistId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 256),
                        Cover = c.String(maxLength: 256),
                        Tracks = c.Int(),
                        Discs = c.Int(),
                        Downloads = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Cover = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlbumId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                        FileId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 256),
                        ReleaseDate = c.DateTime(storeType: "date"),
                        Length = c.Int(nullable: false),
                        TrackNr = c.Int(),
                        DiscNr = c.Int(),
                        Rating = c.Int(nullable: false),
                        Comments = c.String(maxLength: 2048),
                        Lyrics = c.String(maxLength: 2048),
                        Cover = c.String(maxLength: 256),
                        Downloads = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Files", t => t.FileId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.AlbumId)
                .Index(t => t.GenreId)
                .Index(t => t.FileId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(nullable: false, maxLength: 256),
                        Filename = c.String(nullable: false, maxLength: 256),
                        Size = c.Int(nullable: false),
                        DateCreated = c.DateTime(storeType: "date"),
                        DateModified = c.DateTime(storeType: "date"),
                        MimeType = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Songs", "FileId", "dbo.Files");
            DropForeignKey("dbo.Songs", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Songs", new[] { "FileId" });
            DropIndex("dbo.Songs", new[] { "GenreId" });
            DropIndex("dbo.Songs", new[] { "AlbumId" });
            DropIndex("dbo.Albums", new[] { "ArtistId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Files");
            DropTable("dbo.Songs");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
