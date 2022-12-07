using System;
using _03_WebAPI_dotnet_core_controllers.Models;
using _03_WebAPI_dotnet_core_controllers.Services;
using Microsoft.AspNetCore.Mvc;

namespace _03_WebAPI_dotnet_core_controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        // Get All Books
        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks() => BookService.GetAllBooks();

        // Get by Id Action
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = BookService.GetBook(id);
            if (book is null) return NotFound();
            return book;
        }

        // POST Action
        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            BookService.AddBook(book);
            return CreatedAtAction(nameof(CreateBook), new { Id = book.Id }, book);
        }

        // PUT Action
        [HttpPut("{id}")]
        public IActionResult EditBook(int id, Book book)
        {
            if (id != book.Id) return BadRequest();
            var currentBook = BookService.GetBook(id);
            if (currentBook is null) return NotFound();
            BookService.UpdateBook(book);
            return NoContent();
        }

        // Delete Action
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = BookService.GetBook(id);
            if (book is null) return NotFound();
            BookService.DeleteBook(book.Id);
            return NoContent();
        }
    }
}

