using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Models
{
    public class DocumentType
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}