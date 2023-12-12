using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public GenreDto Genre { get; set; }

        public byte GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }
    }
}