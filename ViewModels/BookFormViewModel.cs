using LibraryManager.Models;
using System.Collections.Generic;

namespace LibraryManager.ViewModels
{
    public class BookFormViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}