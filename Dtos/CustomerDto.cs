using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public DocumentTypeDto DocumentType { get; set; }

        public byte DocumentTypeId { get; set; }

        [Required]
        public string DocumentNumber { get; set; }
    }
}