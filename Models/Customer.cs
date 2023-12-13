using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public DocumentType DocumentType { get; set; }

        [Required(ErrorMessage = "Please select a type of ID")]
        [Display(Name = "Document Type")]
        public byte DocumentTypeId { get; set; }

        [Required]
        [Display(Name = "Document Number")]
        public string DocumentNumber { get; set; }

        public bool HasABadRecord { get; set; }
    }
}