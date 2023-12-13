namespace LibraryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBadRecordToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "HasABadRecord", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "HasABadRecord");
        }
    }
}
