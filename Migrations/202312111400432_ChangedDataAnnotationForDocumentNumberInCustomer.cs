namespace LibraryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDataAnnotationForDocumentNumberInCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "DocumentNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "DocumentNumber", c => c.String());
        }
    }
}
