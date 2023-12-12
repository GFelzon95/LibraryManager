using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.ViewModels
{
    public class BookFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Book Title")]
        public string Name { get; set; }

        [Display(Name = "Author")]
        public string Author { get; set; }

        public string Description { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Display(Name = "Date Published")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        public byte? NumberInStock { get; set; }

        [Display(Name = "Number available")]
        public byte? NumberAvailable { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public BookFormViewModel()
        {
            Id = 0;
        }

        public BookFormViewModel(Book book)
        {
            Id = book.Id;
            Name = book.Name;
            Author = book.Author;
            Description = book.Description;
            GenreId = book.GenreId;
            ReleaseDate = book.ReleaseDate;
            NumberInStock = book.NumberInStock;
            NumberAvailable = book.NumberAvailable;
        }

        public string Title
        {
            get
            {
                return Id == 0 ? "New Book" : "Edit Book";
            }
        }
    }
}