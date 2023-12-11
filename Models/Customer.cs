using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        public DocumentType DocumentType { get; set; }
        public byte DocumentTypeId { get; set; }

        public string DocumentNumber { get; set; }
    }
}