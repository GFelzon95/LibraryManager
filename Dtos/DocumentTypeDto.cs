using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Dtos
{
    public class DocumentTypeDto
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}