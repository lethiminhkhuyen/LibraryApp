namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;
    using LibraryApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryApp.Models.LibraryDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LibraryApp.Models.LibraryDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
           
            context.Genres.AddOrUpdate(s => s.GenreName, new Genre("Science-fiction"), 
                                                         new Genre("Satire"),
                                                         new Genre("Drama"),
                                                         new Genre("Adrventure"),
                                                         new Genre("Romance"),
                                                         new Genre("Mystery"),
                                                         new Genre("Horror"),
                                                         new Genre("Health"),
                                                         new Genre("Guide"),
                                                         new Genre("Travel"),
                                                         new Genre("Children"),
                                                         new Genre("Religion"),
                                                         new Genre("Science"),
                                                         new Genre("History"),
                                                         new Genre("Math"),
                                                         new Genre("Anthology"),
                                                         new Genre("Poetry"),
                                                         new Genre("Encyclopedias"),
                                                         new Genre("Dictionaries"),
                                                         new Genre("Comics"),
                                                         new Genre("Art"),
                                                         new Genre("Cookbooks"),
                                                         new Genre("Diaries"),
                                                         new Genre("Journals"),
                                                         new Genre("Autobiographies"),
                                                         new Genre("Biographies"),
                                                         new Genre("Fantasy"));
            context.Languages.AddOrUpdate(s => s.LanguageName, new Language("English"),
                                                                new Language("French"),
                                                                new Language("German"),
                                                                new Language("Spanish"),
                                                                new Language("Italian"));
            context.Types.AddOrUpdate(s => s.TypeName, new Models.Type("Book"),
                                                        new Models.Type("Audiobook"),
                                                        new Models.Type("Reference Book"),
                                                        new Models.Type("Magazine"));
            context.Formats.AddOrUpdate(s => s.FormatName, new Format("Paperback"),
                                                            new Format("Hardcover"),
                                                            new Format("Audio CD"),
                                                            new Format("Mp3 CD"));
            context.AreaCodes.AddOrUpdate(s => s.AreaCodeCode, new AreaCode("03"));
            context.ArbitraryCodes.AddOrUpdate(s => s.ArbitraryCodeCode, new ArbitraryCode("134"));
            context.Streets.AddOrUpdate(s => s.StreetName, new Street("Domeyki Ignacego"));
            context.PostCodes.AddOrUpdate(s => new { s.FirstCodePart, s.SecondCodePart }, new PostCode(context.AreaCodes.First(s => s.AreaCodeCode == "03").AreaCodeCode, context.ArbitraryCodes.First(s => s.ArbitraryCodeCode == "134").ArbitraryCodeCode));
            context.Addresses.AddOrUpdate(s => new { s.AddressStreetName, s.AddressHouseNumber, s.AddressFlatNumber, s.AddressPostCode },
                                                             new Address(context.Streets.First(s => s.StreetName == "Domeyki Ignacego").StreetName, 14, 4, context.PostCodes.First(s => s.FirstCodePart == "03" && s.SecondCodePart == "134").PostCodeId));
            context.Librarians.AddOrUpdate(s => new { s.PersonFirstName, s.PersonLastName }, new Librarian("Anna", "Lechowicz", DateTime.ParseExact("1988-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture), "anna@lechowicz.com", "Haslo-123", 2500, context.Addresses.First(s => s.AddressStreetName == "Domeyki Ignacego" && s.AddressHouseNumber == 14 && s.AddressFlatNumber == 4).AddressID));
            /*context.AreaCodes.AddOrUpdate(s => s.AreaCodeCode, new AreaCode("03"),
                                                                new AreaCode("04"));
            context.ArbitraryCodes.AddOrUpdate(s => s.ArbitraryCodeCode, new ArbitraryCode("134"),
                                                                         new ArbitraryCode("156"),
                                                                         new ArbitraryCode("172"),
                                                                         new ArbitraryCode("192"),
                                                                         new ArbitraryCode("103"));*/
            /* context.Authors.AddOrUpdate(s => new { s.PersonFirstName, s.PersonLastName }, new Author("Joanne", "Rowling", DateTime.ParseExact("1965-07-31", "yyyy-MM-dd", CultureInfo.InvariantCulture), "Joanne Rowling, CH, OBE, FRSL, FRCPE, writing under the pen names J. K. Rowling and Robert Galbraith, is a British novelist, philanthropist, film and television producer and screenwriter best known for writing the Harry Potter fantasy series."),
                                                         new Author("Paulo", "Coelho", DateTime.ParseExact("1947-08-24", "yyyy-MM-dd", CultureInfo.InvariantCulture), "Paulo Coelho de Souza is a Brazilian lyricist and novelist and the recipient of numerous international awards. He is best known for his widely translated novel The Alchemist."),
                                                         new Author("Mandy", "Kirkby", DateTime.ParseExact("1952-05-18", "yyyy-MM-dd", CultureInfo.InvariantCulture), "Mandy Kirkby is an editor and flower enthusiast."));
             context.Titles.AddOrUpdate(s => new { s.TitleName, s.AuthorID}, new Title(context.Authors.First(s => s.PersonFirstName == "Joanne" && s.PersonLastName == "Rowling").PersonId, "Harry Potter and the Philosopher's Stone", context.Genres.First(s => s.GenreName == "Fantasy").GenreName, true),
                                                         new Title(context.Authors.First(s => s.PersonFirstName == "Joanne" && s.PersonLastName == "Rowling").PersonId, "Harry Potter and the Chamber of Secrets", context.Genres.First(s => s.GenreName == "Fantasy").GenreName, true),
                                                         new Title(context.Authors.First(s => s.PersonFirstName == "Joanne" && s.PersonLastName == "Rowling").PersonId, "Harry Potter and the Prisoner of Azkaban", context.Genres.First(s => s.GenreName == "Fantasy").GenreName, true),
                                                         new Title(context.Authors.First(s => s.PersonFirstName == "Joanne" && s.PersonLastName == "Rowling").PersonId, "Harry Potter and the Goblet of Fire", context.Genres.First(s => s.GenreName == "Fantasy").GenreName, true),
                                                         new Title(context.Authors.First(s => s.PersonFirstName == "Joanne" && s.PersonLastName == "Rowling").PersonId, "Harry Potter and the Order of the Phoenix", context.Genres.First(s => s.GenreName == "Fantasy").GenreName, true),
                                                         new Title(context.Authors.First(s => s.PersonFirstName == "Joanne" && s.PersonLastName == "Rowling").PersonId, "Harry Potter and the Half-Blood Prince", context.Genres.First(s => s.GenreName == "Fantasy").GenreName, true),
                                                         new Title(context.Authors.First(s => s.PersonFirstName == "Joanne" && s.PersonLastName == "Rowling").PersonId, "Harry Potter and the Deathly Hallows", context.Genres.First(s => s.GenreName == "Fantasy").GenreName, true),
                                                         new Title(context.Authors.First(s => s.PersonFirstName == "Paulo" && s.PersonLastName == "Coelho").PersonId, "The Alchemist", context.Genres.First(s => s.GenreName == "Fantasy").GenreName, true),
                                                         new Title(context.Authors.First(s => s.PersonFirstName == "Paulo" && s.PersonLastName == "Coelho").PersonId, "The Pilgrimage", context.Genres.First(s => s.GenreName == "Fantasy").GenreName),
                                                         new Title(context.Authors.First(s => s.PersonFirstName == "Mandy" && s.PersonLastName == "Kirkby").PersonId, "A Victorian Flower Dictionary: The Language of Flowers Companion", context.Genres.First(s => s.GenreName == "Dictionaries").GenreName));
             context.Publishers.AddOrUpdate(s => s.PublisherName, new Publisher("Bloomsbury Children's Books"),
                                                                  new Publisher("HarperCollins"),
                                                                  new Publisher("Harper Thorsons"),
                                                                  new Publisher("Thorsons"),
                                                                  new Publisher("Ballantine Books"));
             context.BorrowAbles.AddOrUpdate(s => s.ISBN, new BorrowAble(context.Titles.First(s => s.TitleName == "Harry Potter and the Philosopher's Stone").TitleID, "ISBN9781408855652", "Harry Potter has never even heard of Hogwarts when the letters start dropping on the doormat at number four, Privet Drive. Addressed in green ink on yellowish parchment with a purple seal, they are swiftly confiscated by his grisly aunt and uncle. Then, on Harry's eleventh birthday, a great beetle-eyed giant of a man called Rubeus Hagrid bursts in with some astonishing news: Harry Potter is a wizard, and he has a place at Hogwarts School of Witchcraft and Wizardry. An incredible adventure is about to begin!", context.Publishers.First(s => s.PublisherName == "Bloomsbury Children's Books").PublisherName, DateTime.ParseExact("2014-09-01", "yyyy-MM-dd", CultureInfo.InvariantCulture), context.Languages.First(s => s.LanguageName == "English").LanguageName, context.Types.First(s => s.TypeName == "Book").TypeName, 5.24, context.Formats.First(s => s.FormatName == "Paperback").FormatName),
                                                      new BorrowAble(context.Titles.First(s => s.TitleName == "Harry Potter and the Chamber of Secrets").TitleID, "ISBN9781408855669", "Harry Potter's summer has included the worst birthday ever, doomy warnings from a house-elf called Dobby, and rescue from the Dursleys by his friend Ron Weasley in a magical flying car! Back at Hogwarts School of Witchcraft and Wizardry for his second year, Harry hears strange whispers echo through empty corridors - and then the attacks start. Students are found as though turned to stone . Dobby's sinister predictions seem to be coming true.", context.Publishers.First(s => s.PublisherName == "Bloomsbury Children's Books").PublisherName, DateTime.ParseExact("2014-09-01", "yyyy-MM-dd", CultureInfo.InvariantCulture), context.Languages.First(s => s.LanguageName == "English").LanguageName, context.Types.First(s => s.TypeName == "Book").TypeName, 5.75, context.Formats.First(s => s.FormatName == "Paperback").FormatName),
                                                      new BorrowAble( context.Titles.First(s => s.TitleName == "Harry Potter and the Prisoner of Azkaban").TitleID, "ISBN9781408855675", "When the Knight Bus crashes through the darkness and screeches to a halt in front of him, it's the start of another far from ordinary year at Hogwarts for Harry Potter. Sirius Black, escaped mass-murderer and follower of Lord Voldemort, is on the run - and they say he is coming after Harry. In his first ever Divination class, Professor Trelawney sees an omen of death in Harry's tea leaves . But perhaps most terrifying of all are the Dementors patrolling the school grounds, with their soul-sucking kiss.", context.Publishers.First(s => s.PublisherName == "Bloomsbury Children's Books").PublisherName, DateTime.ParseExact("2014-09-01", "yyyy-MM-dd", CultureInfo.InvariantCulture), context.Languages.First(s => s.LanguageName == "English").LanguageName, context.Types.First(s => s.TypeName == "Book").TypeName, 5.75, context.Formats.First(s => s.FormatName == "Paperback").FormatName),
                                                      new BorrowAble(context.Titles.First(s => s.TitleName == "Harry Potter and the Goblet of Fire").TitleID, "ISBN9781408855928", "he Triwizard Tournament is to be held at Hogwarts. Only wizards who are over seventeen are allowed to enter - but that doesn't stop Harry dreaming that he will win the competition. Then at Hallowe'en, when the Goblet of Fire makes its selection, Harry is amazed to find his name is one of those that the magical cup picks out. He will face death-defying tasks, dragons and Dark wizards, but with the help of his best friends, Ron and Hermione, he might just make it through - alive!", context.Publishers.First(s => s.PublisherName == "Bloomsbury Children's Books").PublisherName, DateTime.ParseExact("2014-09-01", "yyyy-MM-dd", CultureInfo.InvariantCulture), context.Languages.First(s => s.LanguageName == "English").LanguageName, context.Types.First(s => s.TypeName == "Book").TypeName, 14.58, context.Formats.First(s => s.FormatName == "Hardcover").FormatName),
                                                      new BorrowAble(context.Titles.First(s => s.TitleName == "Harry Potter and the Order of the Phoenix").TitleID, "ISBN9781408855690", "Dark times have come to Hogwarts. After the Dementors' attack on his cousin Dudley, Harry Potter knows that Voldemort will stop at nothing to find him. There are many who deny the Dark Lord's return, but Harry is not alone: a secret order gathers at Grimmauld Place to fight against the Dark forces. Harry must allow Professor Snape to teach him how to protect himself from Voldemort's savage assaults on his mind. But they are growing stronger by the day and Harry is running out of time.", context.Publishers.First(s => s.PublisherName == "Bloomsbury Children's Books").PublisherName, DateTime.ParseExact("2014-09-01", "yyyy-MM-dd", CultureInfo.InvariantCulture), context.Languages.First(s => s.LanguageName == "English").LanguageName, context.Types.First(s => s.TypeName == "Book").TypeName, 4.57, context.Formats.First(s => s.FormatName == "Paperback").FormatName),
                                                      new BorrowAble(context.Titles.First(s => s.TitleName == "Harry Potter and the Half-Blood Prince").TitleID, "ISBN9781408855706", "When Dumbledore arrives at Privet Drive one summer night to collect Harry Potter, his wand hand is blackened and shrivelled, but he does not reveal why. Secrets and suspicion are spreading through the wizarding world, and Hogwarts itself is not safe. Harry is convinced that Malfoy bears the Dark Mark: there is a Death Eater amongst them. Harry will need powerful magic and true friends as he explores Voldemort's darkest secrets, and Dumbledore prepares him to face his destiny.", context.Publishers.First(s => s.PublisherName == "Bloomsbury Children's Books").PublisherName, DateTime.ParseExact("2014-09-01", "yyyy-MM-dd", CultureInfo.InvariantCulture), context.Languages.First(s => s.LanguageName == "English").LanguageName, context.Types.First(s => s.TypeName == "Book").TypeName, 4.00, context.Formats.First(s => s.FormatName == "Paperback").FormatName),
                                                      new BorrowAble(context.Titles.First(s => s.TitleName == "Harry Potter and the Deathly Hallows").TitleID, "ISBN9781408855713", "As he climbs into the sidecar of Hagrid's motorbike and takes to the skies, leaving Privet Drive for the last time, Harry Potter knows that Lord Voldemort and the Death Eaters are not far behind. The protective charm that has kept Harry safe until now is now broken, but he cannot keep hiding. The Dark Lord is breathing fear into everything Harry loves, and to stop him Harry will have to find and destroy the remaining Horcruxes. The final battle must begin - Harry must stand and face his enemy.", context.Publishers.First(s => s.PublisherName == "Bloomsbury Children's Books").PublisherName, DateTime.ParseExact("2014-09-01", "yyyy-MM-dd", CultureInfo.InvariantCulture), context.Languages.First(s => s.LanguageName == "English").LanguageName, context.Types.First(s => s.TypeName == "Book").TypeName, 4.00, context.Formats.First(s => s.FormatName == "Paperback").FormatName),
                                                      new BorrowAble(context.Titles.First(s => s.TitleName == "The Alchemist").TitleID, "ISBN9780722532935", "A global phenomenon, The Alchemist has been read and loved by over 62 million readers, topping bestseller lists in 74 countries worldwide. Now this magical fable is beautifully repackaged in an edition that lovers of Paulo Coelho will want to treasure forever. Every few decades a book is published that changes the lives of its readers forever.This is such a book � a beautiful parable about learning to listen to your heart, read the omens strewn along life�s path and, above all, follow your dreams.", context.Publishers.First(s => s.PublisherName == "HarperCollins").PublisherName, DateTime.ParseExact("1995-04-01", "yyyy-MM-dd", CultureInfo.InvariantCulture), context.Languages.First(s => s.LanguageName == "English").LanguageName, context.Types.First(s => s.TypeName == "Book").TypeName, 7.19, context.Formats.First(s => s.FormatName == "Paperback").FormatName),
                                                      new BorrowAble(context.Titles.First(s => s.TitleName == "The Alchemist").TitleID, "ISBN9780008144227", "A global phenomenon, The Alchemist has been read and loved by over 62 million readers, topping bestseller lists in 74 countries worldwide. Now this magical fable is beautifully repackaged in an edition that lovers of Paulo Coelho will want to treasure forever. Every few decades a book is published that changes the lives of its readers forever.This is such a book � a beautiful parable about learning to listen to your heart, read the omens strewn along life�s path and, above all, follow your dreams.", context.Publishers.First(s => s.PublisherName == "Harper Thorsons").PublisherName, DateTime.ParseExact("2015-07-02", "yyyy-MM-dd", CultureInfo.InvariantCulture), context.Languages.First(s => s.LanguageName == "English").LanguageName, context.Types.First(s => s.TypeName == "Book").TypeName, 7.19, context.Formats.First(s => s.FormatName == "Hardcover").FormatName),
                                                      new BorrowAble(context.Titles.First(s => s.TitleName == "The Pilgrimage").TitleID, "ISBN9780722534878", "The 25th anniversary edition of The Pilgrimage, the precursor to The Alchemist. In this gripping story, Paulo Coelho is on a quest for the ultimate in self - knowledge, wisdom and spiritual mastery. Guided by his mysterious companion Petrus, he takes the road to Santiago, going throush a series of trials and tests along the way�even coming face to face with someone who may just be the devil himself.", context.Publishers.First(s => s.PublisherName == "Thorsons").PublisherName, DateTime.ParseExact("1997-01-05", "yyyy-MM-dd", CultureInfo.InvariantCulture), context.Languages.First(s => s.LanguageName == "English").LanguageName, context.Types.First(s => s.TypeName == "Book").TypeName, 8.99, context.Formats.First(s => s.FormatName == "Paperback").FormatName));
             context.NonBorrowAbles.AddOrUpdate(s => s.ISBN, new NonBorrowAble(context.Titles.First(s => s.TitleName == "A Victorian Flower Dictionary: The Language of Flowers Companion").TitleID, "ISBN9780345532862", "Daffodils signal new beginnings, daisies innocence. Lilacs mean the first emotions of love, periwinkles tender recollection. Early Victorians used flowers as a way to express their feelings--love or grief, jealousy or devotion. Now, modern-day romantics are enjoying a resurgence of this bygone custom, and this book will share the historical, literary, and cultural significance of flowers with a whole new generation. With lavish illustrations, a dual dictionary of flora and meanings, and suggestions for creating expressive arrangements, this keepsake is the perfect compendium for everyone who has ever given or received a bouquet.", context.Publishers.First(s => s.PublisherName == "Ballantine Books").PublisherName, DateTime.ParseExact("2011-09-20", "yyyy-MM-dd", CultureInfo.InvariantCulture), context.Languages.First(s => s.LanguageName == "English").LanguageName, context.Types.First(s => s.TypeName == "Reference Book").TypeName, 12.23, context.Formats.First(s => s.FormatName == "Hardcover").FormatName));
             */
            /* context.PostCodes.AddOrUpdate(s => new {s.FirstCodePart, s.SecondCodePart }, new PostCode(context.AreaCodes.First(s => s.AreaCodeCode == "03").AreaCodeCode, context.ArbitraryCodes.First(s => s.ArbitraryCodeCode == "134").ArbitraryCodeCode),
                                                              new PostCode(context.AreaCodes.First(s => s.AreaCodeCode == "03").AreaCodeCode, context.ArbitraryCodes.First(s => s.ArbitraryCodeCode == "156").ArbitraryCodeCode),
                                                              new PostCode(context.AreaCodes.First(s => s.AreaCodeCode == "03").AreaCodeCode, context.ArbitraryCodes.First(s => s.ArbitraryCodeCode == "172").ArbitraryCodeCode),
                                                              new PostCode(context.AreaCodes.First(s => s.AreaCodeCode == "03").AreaCodeCode, context.ArbitraryCodes.First(s => s.ArbitraryCodeCode == "192").ArbitraryCodeCode),
                                                              new PostCode(context.AreaCodes.First(s => s.AreaCodeCode == "03").AreaCodeCode, context.ArbitraryCodes.First(s => s.ArbitraryCodeCode == "103").ArbitraryCodeCode));
             context.Streets.AddOrUpdate(s => s.StreetName, new Street("Domeyki Ignacego"),
                                                            new Street("Aleja Krakowska"),
                                                            new Street("Swietokrzyska"));
             context.Addresses.AddOrUpdate(s => new {s.AddressStreetName, s.AddressHouseNumber, s.AddressFlatNumber, s.AddressPostCode },
                                                             new Address(context.Streets.First(s => s.StreetName == "Domeyki Ignacego").StreetName, 14, 4, context.PostCodes.First( s => s.FirstCodePart == "03"&& s.SecondCodePart == "134").PostCodeId),
                                                             new Address(context.Streets.First(s => s.StreetName == "Domeyki Ignacego").StreetName, 1, 1, context.PostCodes.First(s => s.FirstCodePart == "03" && s.SecondCodePart == "156").PostCodeId),
                                                             new Address(context.Streets.First(s => s.StreetName == "Domeyki Ignacego").StreetName, 3, 5, context.PostCodes.First(s => s.FirstCodePart == "03" && s.SecondCodePart == "172").PostCodeId),
                                                             new Address(context.Streets.First(s => s.StreetName == "Domeyki Ignacego").StreetName, 10, 7, context.PostCodes.First(s => s.FirstCodePart == "03" && s.SecondCodePart == "192").PostCodeId),
                                                             new Address(context.Streets.First(s => s.StreetName == "Domeyki Ignacego").StreetName, 5, 2, context.PostCodes.First(s => s.FirstCodePart == "03" && s.SecondCodePart == "103").PostCodeId));
             context.Librarians.AddOrUpdate(s => new { s.PersonFirstName, s.PersonLastName}, new Librarian("Anna", "Lechowicz", DateTime.ParseExact("1988-05-31", "yyyy-MM-dd", CultureInfo.InvariantCulture), "anna@lechowicz.com", "Haslo-123", context.Addresses.First(s => s.AddressStreetName == "Domeyki Ignacego" && s.AddressHouseNumber == 14 && s.AddressFlatNumber == 4).AddressID, 2500));
             *//*context.Patrons.AddOrUpdate(s => new { s.PersonFirstName, s.PersonLastName}, new Patron("Marta", "Jackowiak", DateTime.ParseExact("1988-03-11", "yyyy-MM-dd", CultureInfo.InvariantCulture),"marta@jackowiak.com", "123456789", "Haslo-1234", context.Addresses.First(s => s.AddressStreetName == "Domeyki Ignacego" && s.AddressHouseNumber == 1 && s.AddressFlatNumber == 1).AddressID),
                                                           new Patron("Katarzyna", "Stankiewicz", DateTime.ParseExact("1986-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),"kasia@stankiewicz.com", "123456781", "Haslo-12345", context.Addresses.First(s => s.AddressStreetName == "Domeyki Ignacego" && s.AddressHouseNumber == 3 && s.AddressFlatNumber == 5).AddressID));
              */

        }
    }
}
;