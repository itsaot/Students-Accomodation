using System.ComponentModel.DataAnnotations;

namespace WebApplication20.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your feedback")]
        [Display(Name = "Feedback")]
        public string Message { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime FeedbackDate { get; set; }
    }
}
