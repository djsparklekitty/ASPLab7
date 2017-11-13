using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5.Model
{
    public class Book
    {
        // Store the following information about each book
        //• Title
        //• Author
        //• Publication date
        //• Rating(one to five)
        //• Name of person who did the rating
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Rating { get; set; }
        public string NameofRate { get; set; }
    }
}
