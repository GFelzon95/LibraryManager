namespace LibraryManager.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedDocumentTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO DocumentTypes (Id, Name) VALUES (1, 'National ID')");
            Sql("INSERT INTO DocumentTypes (Id, Name) VALUES (2, 'Passport')");
            Sql("INSERT INTO DocumentTypes (Id, Name) VALUES (3, 'Driver''s License')");
            Sql("INSERT INTO DocumentTypes (Id, Name) VALUES (4, 'Postal Id')");
        }

        public override void Down()
        {
        }
    }
}
