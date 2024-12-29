using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication20.Models
{
    public class StudentBooking
    {
       
        public int Id { get; set; }
        

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = " Contact is required")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string PhoneNumber { get; set; }




        [Required(ErrorMessage = "Gender is required")]

        public Gender gender { get; set; }
        public enum Gender { Male, Female }



        [Required(ErrorMessage = "Room Type is required")]
        public RoomType roomType { get; set; }
        public enum RoomType
        {
            Single,
            Double,
            Triple
        }
        [Required(ErrorMessage = "Booking Start Date is required")]
        [DataType(DataType.Date)]
        public DateTime BookingStartDate { get; set; } 

        [Required(ErrorMessage = "Booking End Date is required")]
        [DataType(DataType.Date)]
        public DateTime BookingEndDate { get; set; }

        [Required(ErrorMessage = "Room Number is required")]
        public int RoomNumber { get; set; } // Assuming you have a finite number of rooms

        [Required(ErrorMessage = "Emergency Contact is required")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Emergency Contact must be 10 digits")]
        public string EmergencyContact { get; set; }

       


        public int DurationOfStay => (BookingEndDate - BookingStartDate).Days;
    }
}
