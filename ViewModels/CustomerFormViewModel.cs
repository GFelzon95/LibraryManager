using LibraryManager.Models;
using System.Collections.Generic;

namespace LibraryManager.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }

        public IEnumerable<DocumentType> DocumentTypes { get; set; }
    }
}