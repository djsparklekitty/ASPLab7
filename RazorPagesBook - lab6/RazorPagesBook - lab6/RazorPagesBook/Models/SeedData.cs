using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RazorPagesBook.Models
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
                        Title = "The Martain Chronicles",
                        Author = "Ray Bradbury",
                        PublicationDate = DateTime.Parse("01-12-1950"),
                        Rating = 5,
                        RatingName = "Jack"
                    },

                    new Book
                    {
                        Title = "Fahrenheit 451",
                        Author = "Ray Bradbury",
                        PublicationDate = DateTime.Parse("12-01-1953"),
                        Rating = 5,
                        RatingName = "Jack"
                    },

                    new Book
                    {
                        Title = "Dandelion Wine",
                        Author = "Ray Bradbury",
                        PublicationDate = DateTime.Parse("09-13-1957"),
                        Rating = 3,
                        RatingName = "Jack"
                    },

                    new Book
                    {
                        Title = "The Great Gatsby ",
                        Author = "F. Scott Fitzgerald",
                        PublicationDate = DateTime.Parse("10-12-1925"),
                        Rating = 4,
                        RatingName = "Jack"
                    },

                    new Book
                    {
                        Title = "Tender Is the Night",
                        Author = "F. Scott Fitzgerald",
                        PublicationDate = DateTime.Parse("11-23-1934"),
                        Rating = 4,
                        RatingName = "Jack"
                    },

                    new Book
                    {
                        Title = "Fear and Loathing in Las Vegas",
                        Author = "Hunter S. Thompson",
                        PublicationDate = DateTime.Parse("03-21-1971"),
                        Rating = 4,
                        RatingName = "Jack"
                    },
                    new Book
                    {
                        Title = "The Alchemist",
                        Author = "Paulo Coelhoe",
                        PublicationDate = DateTime.Parse("01-22-1988"),
                        Rating = 5,
                        RatingName = "Jack"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}