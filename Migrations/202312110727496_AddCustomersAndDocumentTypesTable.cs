namespace LibraryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomersAndDocumentTypesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 10),
                        DocumentTypeId = c.Byte(nullable: false),
                        DocumentNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentTypeId, cascadeDelete: true)
                .Index(t => t.DocumentTypeId);
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "DocumentTypeId", "dbo.DocumentTypes");
            DropIndex("dbo.Customers", new[] { "DocumentTypeId" });
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.Customers");
        }
    }
}
