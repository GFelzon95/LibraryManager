using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Book Title")]
        public string Name { get; set; }

        [Display(Name = "Author")]
        public string Author { get; set; }

        public string Description { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Display(Name = "Date Published")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }

        [Display(Name = "Number available")]
        public byte NumberAvailable { get; set; }
    }
}