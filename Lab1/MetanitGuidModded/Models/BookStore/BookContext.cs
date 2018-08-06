using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MetanitGuidModded.Models.BookStore
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }

    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "Ferrohydrostatics", Author = "R. Rozenzweig", Price = 220 });
            db.Books.Add(new Book { Name = "Harry Potter 1", Author = "J. Rowling", Price = 180 });
            db.Books.Add(new Book { Name = "Harry Potter 2", Author = "J. Rowling", Price = 177 });

            base.Seed(db);

        }
    }
}