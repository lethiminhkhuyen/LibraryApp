namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRaimainingAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "remainAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "remainAmount");
        }
    }
}
