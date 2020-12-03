namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRulesForFines : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BorrowRecords", "isPaid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BorrowRecords", "isPaid");
        }
    }
}
