using System;
using _03_WebAPI_dotnet_core_controllers.Models;

namespace _03_WebAPI_dotnet_core_controllers.Services
{
    public class BookService
    {
        static List<Book> Books { get; }
        static int NextId = 3;

        static BookService()
        {
            Books = new List<Book>
            {
                new Book{Id = 1, Name = "Software Engineering", Author = "Hashan Eranga" },
                new Book{Id = 2, Name = "Bio Science", Author = "Ishini Amasha"}
            };
        }

        public static List<Book> GetAll() => Books;
        public static Book Get(int Id) => Books.FirstOrDefault(book => book.Id == Id);
        public static void Add(Book book)
        {
            book.Id = NextId++;
            Books.Add(book);
        }
        public static void Delete(int Id)
        {
            Book book = Get(Id);
            if (book is null) return;
            Books.Remove(book);
        }
        public static void Update(Book book)
        {
            int index = Books.FindIndex(listBook => listBook.Id == book.Id);
            if (index < 0) return;
            Books[index] = book;
        }

    }
}

