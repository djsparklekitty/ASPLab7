using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Models
{
    public class Book
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Title { get; set; }

        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Author { get; set; }
        public string Publisher { get; set; }

        [Display(Name="Publication Date")]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        [Range(1, 4)]
        public int Rating { get; set; }

        [StringLength(60, MinimumLength =1)]
        public string Name { get; set; }


    }
}
