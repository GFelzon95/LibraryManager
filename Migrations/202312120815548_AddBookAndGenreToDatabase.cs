namespace LibraryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookAndGenreToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Author = c.String(),
                        Description = c.String(),
                        GenreId = c.Byte(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        NumberInStock = c.Byte(nullable: false),
                        NumberAvailable = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "GenreId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
        }
    }
}
