namespace LibraryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCheckOutToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCheckedOut = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Book_Id = c.Int(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Book_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckOuts", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.CheckOuts", "Book_Id", "dbo.Books");
            DropIndex("dbo.CheckOuts", new[] { "Customer_Id" });
            DropIndex("dbo.CheckOuts", new[] { "Book_Id" });
            DropTable("dbo.CheckOuts");
        }
    }
}
