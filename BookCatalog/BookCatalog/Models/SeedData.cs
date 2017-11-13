using BookCatalog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookContext(
                serviceProvider.GetRequiredService<DbContextOptions<BookContext>>()))
            {
                // Look for any movies.
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = "The Way of Kings",
                        PublicationDate = DateTime.Parse("2010-8-31"),
                        Author = "Brandon Sanderson",
                        Publisher = "Tor Books",
                        Rating = 4,
                        Name = "Robin",
                    },

                    new Book
                    {
                        Title = "Words of Radiance",
                        PublicationDate = DateTime.Parse("2014-3-4"),
                        Author = "Brandon Sanderson",
                        Publisher = "Tor Books",
                        Rating = 4,
                        Name = "Robin",
                    },

                    new Book
                    {
                        Title = "The Rithmatist",
                        PublicationDate = DateTime.Parse("2013-5-13"),
                        Author = "Brandon Sanderson",
                        Publisher = "Tor Books",
                        Rating = 4,
                        Name = "Robin",
                    },

                    new Book
                    {
                        Title = "Ready Player One",
                        PublicationDate = DateTime.Parse("2011-8-16"),
                        Author = "Ernest Cline",
                        Publisher = "Random House",
                        Rating = 4,
                        Name = "Robin",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}