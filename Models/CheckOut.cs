using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Models
{
    public class CheckOut
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Book Book { get; set; }

        public DateTime DateCheckedOut { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}