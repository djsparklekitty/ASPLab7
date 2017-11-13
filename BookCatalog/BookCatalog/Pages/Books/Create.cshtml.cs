using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookCatalog.Models;
using Microsoft.AspNetCore.Http;
using BookCatalog.Pages;

namespace BookCatalog.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly BookCatalog.Models.BookContext _context;
        public string UserName { get; set; }
        string username;

        public CreateModel(BookCatalog.Models.BookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGet()
        {
            username = HttpContext.Session.GetString(IndexModel.USER_NAME);
            UserName = username;
            return Page();
        }

        

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}