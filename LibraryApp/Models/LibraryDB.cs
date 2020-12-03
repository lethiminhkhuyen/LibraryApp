using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class LibraryDB : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet< Language> Languages { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<NonBorrowAble> NonBorrowAbles { get; set; }
        public DbSet<BorrowAble> BorrowAbles { get; set; }
        public DbSet<AreaCode> AreaCodes { get; set; }
        public DbSet<ArbitraryCode> ArbitraryCodes { get; set; }
        public DbSet<PostCode> PostCodes { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Patron> Patrons { get; set; }
        public DbSet<ReservationRecord> ReservationRecords { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            //Person Config
            modelBuilder.Entity<Person>().HasKey(s => s.PersonId).Property(s => s.PersonId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Person>().Property(s => s.PersonFirstName).IsRequired();
            modelBuilder.Entity<Person>().Property(s => s.PersonLastName).IsRequired();
            modelBuilder.Entity<Person>().Property(s => s.PersonDateOfBirth).IsRequired();

            //Author config
            modelBuilder.Entity<Author>().Property(s => s.Biography).IsOptional();

            // Genre Config
            modelBuilder.Entity<Genre>().HasKey(s => s.GenreName).Property(s => s.GenreName).HasMaxLength(100);

            //Title config
            modelBuilder.Entity<Title>().HasKey(s => s.TitleID).Property(s => s.TitleID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Title>().Property(s => s.isBestseller).IsRequired();
            modelBuilder.Entity<Title>().HasRequired(s => s.author).WithMany(c => c.titles).HasForeignKey(s => s.AuthorID).WillCascadeOnDelete(false);
            modelBuilder.Entity<Title>().HasRequired(s => s.genre).WithMany(c => c.titles).HasForeignKey(s => s.GenreName).WillCascadeOnDelete(false);
            modelBuilder.Entity<Title>().Property(s => s.TitleName).IsRequired().HasMaxLength(500);

           // Language Config
            modelBuilder.Entity<Language>().HasKey(s => s.LanguageName).Property(s => s.LanguageName).HasMaxLength(100);

            // Publisher Config
            modelBuilder.Entity<Publisher>().HasKey(s => s.PublisherName).Property(s => s.PublisherName).HasMaxLength(100);

            // Type Config
            modelBuilder.Entity<Type>().HasKey(s => s.TypeName).Property(s => s.TypeName).HasMaxLength(100);

            //Format config
            modelBuilder.Entity<Format>().HasKey(s => s.FormatName).Property(s => s.FormatName).HasMaxLength(100);

            //Item config
            modelBuilder.Entity<Item>().HasKey(s => s.ItemID).Property(s => s.ItemID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Item>().Property(s => s.ISBN).IsRequired().HasMaxLength(17);
            modelBuilder.Entity<Item>().Property(s => s.Overview).IsOptional();
            modelBuilder.Entity<Item>().Property(s => s.PublishedDate).IsRequired();
            modelBuilder.Entity<Item>().Property(s => s.Price).IsRequired();
            modelBuilder.Entity<Item>().Property(s => s.Amount).IsRequired();
            modelBuilder.Entity<Item>().Property(s => s.remainAmount).IsRequired();
            modelBuilder.Entity<Item>().Property(s => s.isReserved).IsRequired();
            modelBuilder.Entity<Item>().HasRequired(s => s.tile).WithMany(c => c.items).HasForeignKey(s => s.TitleID).WillCascadeOnDelete(false);
            modelBuilder.Entity<Item>().HasRequired(s => s.publisher).WithMany(c => c.items).HasForeignKey(s => s.PublisherName).WillCascadeOnDelete(false);
            modelBuilder.Entity<Item>().HasRequired(s => s.language).WithMany(c => c.items).HasForeignKey(s => s.LanguageName).WillCascadeOnDelete(false);
            modelBuilder.Entity<Item>().HasRequired(s => s.type).WithMany(c => c.items).HasForeignKey(s => s.TypeName).WillCascadeOnDelete(false);
            modelBuilder.Entity<Item>().HasRequired(s => s.format).WithMany(c => c.items).HasForeignKey(s => s.FormatName).WillCascadeOnDelete(false);

            //NonBorrowable config
            modelBuilder.Entity<NonBorrowAble>().Property(s => s.isInUsed).IsRequired();

            //Borrowable config
            modelBuilder.Entity<BorrowAble>().Property(s => s.isBorrowed).IsRequired();

            //AreaCode config
            modelBuilder.Entity<AreaCode>().HasKey(s => s.AreaCodeCode).Property(s => s.AreaCodeCode).HasMaxLength(2);

            //Arbitrary config
            modelBuilder.Entity<ArbitraryCode>().HasKey(s => s.ArbitraryCodeCode).Property(s => s.ArbitraryCodeCode).HasMaxLength(3);

            //Postcode config
            modelBuilder.Entity<PostCode>().HasKey(s => s.PostCodeId).Property(s => s.PostCodeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<PostCode>().HasRequired(s => s.areaCode).WithMany(c => c.postCodes).HasForeignKey(s => s.FirstCodePart).WillCascadeOnDelete(false);
            modelBuilder.Entity<PostCode>().HasRequired(s => s.arbitraryCode).WithMany(c => c.postCodes).HasForeignKey(s => s.SecondCodePart).WillCascadeOnDelete(false);

            //Street config
            modelBuilder.Entity<Street>().HasKey(s => s.StreetName).Property(s => s.StreetName).HasMaxLength(200);

            //Address config
            modelBuilder.Entity<Address>().HasKey(s => s.AddressID).Property( s => s.AddressID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Address>().Property(s => s.AddressHousename).IsOptional();
            modelBuilder.Entity<Address>().HasRequired(s => s.street).WithMany(c => c.addresses).HasForeignKey(s => s.AddressStreetName).WillCascadeOnDelete(false);
            modelBuilder.Entity<Address>().Property(s => s.AddressHouseNumber).IsOptional();
            modelBuilder.Entity<Address>().Property(s => s.AddressFlatNumber).IsOptional();
            modelBuilder.Entity<Address>().HasRequired(s => s.postCode).WithMany(c => c.addresses).HasForeignKey(s => s.AddressPostCode).WillCascadeOnDelete(false);

            //User config
            modelBuilder.Entity<User>().Property(s => s.UserLogin).IsRequired();
            modelBuilder.Entity<User>().Property(s => s.UserPassword).IsRequired();
            modelBuilder.Entity<User>().Property(s => s.UserEmail).IsRequired();
            modelBuilder.Entity<User>().HasRequired(s => s.address).WithMany(c => c.users).HasForeignKey(s => s.UserAddress).WillCascadeOnDelete(false);

            //Librarian config
            modelBuilder.Entity<Librarian>().Property(s => s.Salary).IsRequired();

            //Patron config
            modelBuilder.Entity<Patron>().Property(s => s.TelNumber).IsRequired();
            modelBuilder.Entity<Patron>().Property(s => s.AccountOpenDate).IsRequired();
            modelBuilder.Entity<Patron>().Property(s => s.AccountStatus).IsRequired();
            modelBuilder.Entity<Patron>().Property(s => s.Fine).IsOptional();

            //ReservationRecord config
            modelBuilder.Entity<ReservationRecord>().HasKey(s => s.ReservationRecordID).Property(s => s.ReservationRecordID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ReservationRecord>().HasRequired(s => s.item).WithMany(c => c.reservationRecords).HasForeignKey(s => s.ItemID).WillCascadeOnDelete(false);
            modelBuilder.Entity<ReservationRecord>().HasRequired(s => s.patron).WithMany(c => c.reservationRecords).HasForeignKey(s => s.PatronID).WillCascadeOnDelete(false);
            modelBuilder.Entity<ReservationRecord>().Property(s => s.ReservationDate).IsRequired();
            modelBuilder.Entity<ReservationRecord>().Property(s => s.isResolved).IsRequired();

            //BorrowAbleRecord config
            modelBuilder.Entity<BorrowRecord>().HasKey(s => s.BorrowRecordID).Property(s => s.BorrowRecordID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<BorrowRecord>().HasRequired(s => s.borrowAble).WithMany(c => c.borrowRecords).HasForeignKey(s => s.ItemID).WillCascadeOnDelete(false);
            modelBuilder.Entity<BorrowRecord>().HasRequired(s => s.patron).WithMany(c => c.borrowRecords).HasForeignKey(s => s.PatronID).WillCascadeOnDelete(false);
            modelBuilder.Entity<BorrowRecord>().Property(s => s.BorrowedDate).IsRequired();
            modelBuilder.Entity<BorrowRecord>().Property(s => s.ReturnedDate).IsRequired();
            modelBuilder.Entity<BorrowRecord>().Property(s => s.DueDate).IsRequired();
            modelBuilder.Entity<BorrowRecord>().Property(s => s.isRenewed).IsRequired();
            modelBuilder.Entity<BorrowRecord>().Property(s => s.isPaid).IsRequired();
            modelBuilder.Entity<BorrowRecord>().Property(s => s.Fine).IsOptional();

        }
    }
}
