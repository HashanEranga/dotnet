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
        public BookController()
        {
        }

        // Get All Books
        [HttpGet]
        public ActionResult<List<Book>> GetAll() => BookService.GetAll();

        // Get by Id Action
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int Id)
        {
            var book = BookService.Get(Id);
            if (book is null) return NotFound();
            return book;
        }

        // POST Action

        // PUT Action

        // Delete Action
    }
}

