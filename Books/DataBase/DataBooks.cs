using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.DataBase
{
    public static class DataBooks
    {
        public static List<Book> books = new List<Book>()
        {
            new Book {ID=1, BookName="One Hundred Years of Solitude", AuthorName="Gabriel Garcia Marquez", BookCategory=Category.Drama, BookCondition=Condition.Good, Price=5, ImagePath="~/Images/marquez.jpg", Availability= "Available" },
            new Book {ID=2 ,BookName="Hunger", AuthorName="Knut Hamsun", BookCategory=Category.Drama, BookCondition=Condition.Poor, Price=4, ImagePath="~/Images/hamsun.jpg", Availability= "Available" },
            new Book {ID=3 ,BookName="The Fortress", AuthorName="Mesa Selimovic", BookCategory=Category.Drama, BookCondition=Condition.Fair, Price=7, ImagePath= "~/Images/mesa.jpg" ,Availability= "Available"},
            new Book {ID=4 ,BookName="To Kill a Mockingbird", AuthorName="Harper Lee", BookCategory=Category.Drama, BookCondition=Condition.New, Price=13, ImagePath= "~/Images/harper.jpg" ,Availability= "Available"}
        };

        public static IEnumerable<Book> GetBooks()
        {
            return books;
        }
        public static Book Get(int id)
        {
            return books.FirstOrDefault(r => r.ID == id);
        }
        public static void Add(Book book)
        {
            books.Add(book);
        }
        public static void Remove(int id)
        {
            var b = Get(id);
            if(b!= null)
            {
                books.Remove(b);
            }
        }
        public static void Update(Book b)
        {
            var book = Get(b.ID);
            if(book != null)
            {
                book.ID = b.ID;
                book.BookName = b.BookName;
                book.AuthorName = b.AuthorName;
                book.BookCategory = b.BookCategory;
                book.BookCondition = b.BookCondition;
                book.ImagePath = b.ImagePath;
            }
        }
        public static IEnumerable<Book> SearchBook(string text)
        {
            List<Book> searchedBooks = new List<Book>();
            foreach (Book b in books)
            {
                if (b.BookName.ToUpper().Contains(text.ToUpper()) || b.AuthorName.ToUpper().Contains(text.ToUpper()))
                {
                    searchedBooks.Add(b);
                }
            }
            return searchedBooks;
        }
    }
}