using Books.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Books.DataBase
{
    public class BooksDbContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        
    }
}