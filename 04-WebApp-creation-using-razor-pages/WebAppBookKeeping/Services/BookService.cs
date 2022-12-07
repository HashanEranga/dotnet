﻿using System;
using System.Xml.Linq;
using WebAppBookKeeping.Models;

namespace WebAppBookKeeping.Services
{
    public class BookService
    {
        static List<Book> Books { get; }
        static int NextId = 3;

        static BookService()
        {
            Books = new List<Book>
            {
                new Book{Id = 1, Name = "Software Engineering", Language = BookLang.English, Author = "Hashan Eranga" },
                new Book{Id = 2, Name = "Bio Science", Language = BookLang.Sinhala, Author = "Ishini Amasha"}
            };
        }

        public static List<Book> GetAllBooks() => Books;
        public static Book? GetBook(int Id) => Books.FirstOrDefault(book => book.Id == Id);
        public static void AddBook(Book book)
        {
            book.Id = NextId++;
            Books.Add(book);
        }
        public static void DeleteBook(int Id)
        {
            var book = GetBook(Id);
            if (book is null) return;
            Books.Remove(book);
        }
        public static void UpdateBook(Book book)
        {
            int index = Books.FindIndex(listBook => listBook.Id == book.Id);
            if (index < 0) return;
            Books[index] = book;
        }

    }
}

