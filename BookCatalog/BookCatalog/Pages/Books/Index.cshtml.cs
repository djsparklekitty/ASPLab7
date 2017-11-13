using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookCatalog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace BookCatalog.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookCatalog.Models.BookContext _context;

        public const string USER_NAME = "username";

        public IndexModel(BookCatalog.Models.BookContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }
        public SelectList Authors;
        public string BookAuthor { get; set; }
        string username;

        [BindProperty]
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        public async Task OnGetAsync(string BookAuthor, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> authorQuery = from b in _context.Book
                                            orderby b.Author
                                            select b.Author;

            var books = from b in _context.Book
                         select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(BookAuthor))
            {
                books = books.Where(x => x.Author == BookAuthor);
            }
            Authors = new SelectList(await authorQuery.Distinct().ToListAsync());
            Book = await books.ToListAsync();
        }

        public async Task OnPostAsync()
        {
            username = Request.Form["username"];
            HttpContext.Session.SetString(USER_NAME, username);
            Book = _context.Book.ToList();

            //added this so that after you click Save Name it doesn't remove the 
            //authors from the Book Author search list
            IQueryable<string> authorQuery = from b in _context.Book
                                             orderby b.Author
                                             select b.Author;
            
            Authors = new SelectList(await authorQuery.Distinct().ToListAsync());
        }
    }
}
