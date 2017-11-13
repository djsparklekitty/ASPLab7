using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesBook.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesBook.Models.BookContext _context;
        public const string RATING_NAME = "Ratingname";
        public IndexModel(RazorPagesBook.Models.BookContext context)
        {
            _context = context;
        }
        string ratingname; 
        
        public IList<Book> Book { get; set; }
        public SelectList Authors;
        public string BookAuthor { get; set; }


        [BindProperty]
        public string RatingName
        {
            get { return ratingname; }
            set { ratingname = value; }
        }

        public async Task OnGetAsync(string bookAuthor,string searchString)
        {
            IQueryable<string> authorQuery = from b in _context.Book
                                            orderby b.Author
                                            select b.Author;


            var books = from b in _context.Book
                         select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(bookAuthor))
            {
                books = books.Where(x => x.Author == bookAuthor);
            }

            Authors = new SelectList(await authorQuery.Distinct().ToListAsync());
            Book = await books.ToListAsync();


            //Book = await _context.Book.ToListAsync();
        }

        public IActionResult OnPost()
        {
            ratingname = Request.Form["text1"];
            HttpContext.Session.SetString(RATING_NAME, ratingname);
            Book = _context.Book.ToList();
            return Page();
        }
    }
}
