namespace LibraryManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataNotationToCheckOut : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CheckOuts", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.CheckOuts", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.CheckOuts", new[] { "Book_Id" });
            DropIndex("dbo.CheckOuts", new[] { "Customer_Id" });
            AlterColumn("dbo.CheckOuts", "Book_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.CheckOuts", "Customer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.CheckOuts", "Book_Id");
            CreateIndex("dbo.CheckOuts", "Customer_Id");
            AddForeignKey("dbo.CheckOuts", "Book_Id", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CheckOuts", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckOuts", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.CheckOuts", "Book_Id", "dbo.Books");
            DropIndex("dbo.CheckOuts", new[] { "Customer_Id" });
            DropIndex("dbo.CheckOuts", new[] { "Book_Id" });
            AlterColumn("dbo.CheckOuts", "Customer_Id", c => c.Int());
            AlterColumn("dbo.CheckOuts", "Book_Id", c => c.Int());
            CreateIndex("dbo.CheckOuts", "Customer_Id");
            CreateIndex("dbo.CheckOuts", "Book_Id");
            AddForeignKey("dbo.CheckOuts", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.CheckOuts", "Book_Id", "dbo.Books", "Id");
        }
    }
}
