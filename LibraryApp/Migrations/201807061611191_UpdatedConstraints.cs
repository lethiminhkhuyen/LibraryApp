namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedConstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "PersonFirstName", c => c.String(nullable: false));
            AlterColumn("dbo.People", "PersonLastName", c => c.String(nullable: false));
            AlterColumn("dbo.People", "UserLogin", c => c.String());
            AlterColumn("dbo.People", "UserPassword", c => c.String());
            AlterColumn("dbo.People", "UserEmail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "UserEmail", c => c.String(maxLength: 50));
            AlterColumn("dbo.People", "UserPassword", c => c.String(maxLength: 50));
            AlterColumn("dbo.People", "UserLogin", c => c.String(maxLength: 50));
            AlterColumn("dbo.People", "PersonLastName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.People", "PersonFirstName", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
