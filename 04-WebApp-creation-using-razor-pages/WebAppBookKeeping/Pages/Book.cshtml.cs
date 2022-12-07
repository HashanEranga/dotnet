using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppBookKeeping.Models;
using WebAppBookKeeping.Services;

namespace WebAppBookKeeping.Pages
{

    public class BookModel : PageModel
    {
        [BindProperty]
        public Book NewBook { get; set; } = new();
        public List<Book> books = new();
        public void OnGet()
        {
            books = BookService.GetAllBooks();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            BookService.AddBook(NewBook);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int Id)
        {
            BookService.DeleteBook(Id);
            return RedirectToAction("Get");
        }
    }

}
