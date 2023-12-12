namespace LibraryManager.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id, Name) VALUES('1', 'Adventure')");
            Sql("INSERT INTO Genres(Id, Name) VALUES('2', 'Romance')");
            Sql("INSERT INTO Genres(Id, Name) VALUES('3', 'Horror')");
            Sql("INSERT INTO Genres(Id, Name) VALUES('4', 'Science Fiction')");
            Sql("INSERT INTO Genres(Id, Name) VALUES('5', 'Fantasy')");
            Sql("INSERT INTO Genres(Id, Name) VALUES('6', 'Mystery')");
            Sql("INSERT INTO Genres(Id, Name) VALUES('7', 'Philosophy')");
        }

        public override void Down()
        {
        }
    }
}
