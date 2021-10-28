using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAGINAWEB.Models
{
    public class RegistrationModel
    {
        [Key]
        public int User_id { get; set; }
        [Required(ErrorMessage = "Please enter first name")]
        [DisplayName("First name")]
        public string User_firstname { get; set; }

        [DisplayName("Last name")]
        [Required(ErrorMessage = "Please enter last name")]
        public string User_lastname { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string User_email { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [DisplayName("Password")]
        [RegularExpression(@"^[a-zA-Z0-9\s]{8,15}$", ErrorMessage = "Please enter more than 8 character and special characters are not allowed")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Compare("Password", ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        public String ConfirmPassword { get; set; }
        private DateTime _date = DateTime.Now;
        [DisplayName("Created Date")]
        public DateTime Create_date { get { return _date; } set { _date = value; } }

    }
}
