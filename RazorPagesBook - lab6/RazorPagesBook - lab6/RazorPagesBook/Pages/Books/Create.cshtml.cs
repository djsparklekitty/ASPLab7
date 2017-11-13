using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesBook.Models;
using Microsoft.AspNetCore.Http;

namespace RazorPagesBook.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesBook.Models.BookContext _context;

        public CreateModel(RazorPagesBook.Models.BookContext context)
        {
            _context = context;
        }

        public string RatingName { get; set; }


        public IActionResult OnGet()
        {
            string ratingname = HttpContext.Session.GetString(IndexModel.RATING_NAME);
            RatingName = ratingname;
            return Page();
        }


        [BindProperty]
        public Book Book { get; set; }

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