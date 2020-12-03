namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initiation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        AddressHousename = c.String(),
                        AddressStreetName = c.String(nullable: false, maxLength: 200),
                        AddressHouseNumber = c.Int(),
                        AddressFlatNumber = c.Int(),
                        AddressPostCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("dbo.PostCodes", t => t.AddressPostCode)
                .ForeignKey("dbo.Streets", t => t.AddressStreetName)
                .Index(t => t.AddressStreetName)
                .Index(t => t.AddressPostCode);
            
            CreateTable(
                "dbo.PostCodes",
                c => new
                    {
                        PostCodeId = c.Int(nullable: false, identity: true),
                        FirstCodePart = c.String(nullable: false, maxLength: 2),
                        SecondCodePart = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.PostCodeId)
                .ForeignKey("dbo.ArbitraryCodes", t => t.SecondCodePart)
                .ForeignKey("dbo.AreaCodes", t => t.FirstCodePart)
                .Index(t => t.FirstCodePart)
                .Index(t => t.SecondCodePart);
            
            CreateTable(
                "dbo.ArbitraryCodes",
                c => new
                    {
                        ArbitraryCodeCode = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.ArbitraryCodeCode);
            
            CreateTable(
                "dbo.AreaCodes",
                c => new
                    {
                        AreaCodeCode = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.AreaCodeCode);
            
            CreateTable(
                "dbo.Streets",
                c => new
                    {
                        StreetName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.StreetName);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        PersonFirstName = c.String(nullable: false, maxLength: 100),
                        PersonLastName = c.String(nullable: false, maxLength: 100),
                        PersonDateOfBirth = c.DateTime(nullable: false),
                        UserLogin = c.String(maxLength: 50),
                        UserPassword = c.String(maxLength: 50),
                        UserAddress = c.Int(),
                        UserEmail = c.String(maxLength: 50),
                        Salary = c.Double(),
                        TelNumber = c.String(),
                        AccountOpenDate = c.DateTime(),
                        AccountStatus = c.Int(),
                        Fine = c.Double(),
                        Biography = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Addresses", t => t.UserAddress)
                .Index(t => t.UserAddress);
            
            CreateTable(
                "dbo.BorrowRecords",
                c => new
                    {
                        BorrowRecordID = c.Int(nullable: false, identity: true),
                        ItemID = c.Int(nullable: false),
                        PatronID = c.Int(nullable: false),
                        BorrowedDate = c.DateTime(nullable: false),
                        ReturnedDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        isRenewed = c.Boolean(nullable: false),
                        Fine = c.Double(),
                    })
                .PrimaryKey(t => t.BorrowRecordID)
                .ForeignKey("dbo.Items", t => t.ItemID)
                .ForeignKey("dbo.People", t => t.PatronID)
                .Index(t => t.ItemID)
                .Index(t => t.PatronID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        TitleID = c.Int(nullable: false),
                        ISBN = c.String(nullable: false, maxLength: 17),
                        Overview = c.String(),
                        PublisherName = c.String(nullable: false, maxLength: 100),
                        PublishedDate = c.DateTime(nullable: false),
                        LanguageName = c.String(nullable: false, maxLength: 100),
                        TypeName = c.String(nullable: false, maxLength: 100),
                        FormatName = c.String(nullable: false, maxLength: 100),
                        Price = c.Double(nullable: false),
                        isReserved = c.Boolean(nullable: false),
                        isBorrowed = c.Boolean(),
                        isInUsed = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Formats", t => t.FormatName)
                .ForeignKey("dbo.Languages", t => t.LanguageName)
                .ForeignKey("dbo.Publishers", t => t.PublisherName)
                .ForeignKey("dbo.Titles", t => t.TitleID)
                .ForeignKey("dbo.Types", t => t.TypeName)
                .Index(t => t.TitleID)
                .Index(t => t.PublisherName)
                .Index(t => t.LanguageName)
                .Index(t => t.TypeName)
                .Index(t => t.FormatName);
            
            CreateTable(
                "dbo.Formats",
                c => new
                    {
                        FormatName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.FormatName);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.LanguageName);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PublisherName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.PublisherName);
            
            CreateTable(
                "dbo.ReservationRecords",
                c => new
                    {
                        ReservationRecordID = c.Int(nullable: false, identity: true),
                        ItemID = c.Int(nullable: false),
                        PatronID = c.Int(nullable: false),
                        ReservationDate = c.DateTime(nullable: false),
                        isResolved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationRecordID)
                .ForeignKey("dbo.Items", t => t.ItemID)
                .ForeignKey("dbo.People", t => t.PatronID)
                .Index(t => t.ItemID)
                .Index(t => t.PatronID);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        TitleID = c.Int(nullable: false, identity: true),
                        AuthorID = c.Int(nullable: false),
                        TitleName = c.String(nullable: false, maxLength: 500),
                        GenreName = c.String(nullable: false, maxLength: 100),
                        isBestseller = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TitleID)
                .ForeignKey("dbo.People", t => t.AuthorID)
                .ForeignKey("dbo.Genres", t => t.GenreName)
                .Index(t => t.AuthorID)
                .Index(t => t.GenreName);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.GenreName);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        TypeName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.TypeName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BorrowRecords", "PatronID", "dbo.People");
            DropForeignKey("dbo.BorrowRecords", "ItemID", "dbo.Items");
            DropForeignKey("dbo.Items", "TypeName", "dbo.Types");
            DropForeignKey("dbo.Items", "TitleID", "dbo.Titles");
            DropForeignKey("dbo.Titles", "GenreName", "dbo.Genres");
            DropForeignKey("dbo.Titles", "AuthorID", "dbo.People");
            DropForeignKey("dbo.ReservationRecords", "PatronID", "dbo.People");
            DropForeignKey("dbo.ReservationRecords", "ItemID", "dbo.Items");
            DropForeignKey("dbo.Items", "PublisherName", "dbo.Publishers");
            DropForeignKey("dbo.Items", "LanguageName", "dbo.Languages");
            DropForeignKey("dbo.Items", "FormatName", "dbo.Formats");
            DropForeignKey("dbo.People", "UserAddress", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "AddressStreetName", "dbo.Streets");
            DropForeignKey("dbo.Addresses", "AddressPostCode", "dbo.PostCodes");
            DropForeignKey("dbo.PostCodes", "FirstCodePart", "dbo.AreaCodes");
            DropForeignKey("dbo.PostCodes", "SecondCodePart", "dbo.ArbitraryCodes");
            DropIndex("dbo.Titles", new[] { "GenreName" });
            DropIndex("dbo.Titles", new[] { "AuthorID" });
            DropIndex("dbo.ReservationRecords", new[] { "PatronID" });
            DropIndex("dbo.ReservationRecords", new[] { "ItemID" });
            DropIndex("dbo.Items", new[] { "FormatName" });
            DropIndex("dbo.Items", new[] { "TypeName" });
            DropIndex("dbo.Items", new[] { "LanguageName" });
            DropIndex("dbo.Items", new[] { "PublisherName" });
            DropIndex("dbo.Items", new[] { "TitleID" });
            DropIndex("dbo.BorrowRecords", new[] { "PatronID" });
            DropIndex("dbo.BorrowRecords", new[] { "ItemID" });
            DropIndex("dbo.People", new[] { "UserAddress" });
            DropIndex("dbo.PostCodes", new[] { "SecondCodePart" });
            DropIndex("dbo.PostCodes", new[] { "FirstCodePart" });
            DropIndex("dbo.Addresses", new[] { "AddressPostCode" });
            DropIndex("dbo.Addresses", new[] { "AddressStreetName" });
            DropTable("dbo.Types");
            DropTable("dbo.Genres");
            DropTable("dbo.Titles");
            DropTable("dbo.ReservationRecords");
            DropTable("dbo.Publishers");
            DropTable("dbo.Languages");
            DropTable("dbo.Formats");
            DropTable("dbo.Items");
            DropTable("dbo.BorrowRecords");
            DropTable("dbo.People");
            DropTable("dbo.Streets");
            DropTable("dbo.AreaCodes");
            DropTable("dbo.ArbitraryCodes");
            DropTable("dbo.PostCodes");
            DropTable("dbo.Addresses");
        }
    }
}
