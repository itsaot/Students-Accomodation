using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication20.Models
{
    public class Document
    {
        [Key]
        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [NotMapped]
        public IFormFile BookingProof { get; set; }
        [NotMapped]
        public IFormFile PaymentProof { get; set; }
    }
}
