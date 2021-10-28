﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAGINAWEB.Models
{
    public class UserMaster
    {
        [Key]
        public int User_id { get; set; }
        [DisplayName("First name")]
        public string User_firstname { get; set; }
        [DisplayName("Middle name")]
        public string User_lastname { get; set; }
        [DisplayName("Address line1")]
        public string Company_address_line1 { get; set; }
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string User_email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [RegularExpression(@"^[a-zA-Z0-9\s]{8,15}$", ErrorMessage = "Please enter more than 8 character and special characters are not allowed")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        private DateTime _date = DateTime.Now;
        [DisplayName("Created Date")]
        public DateTime Create_date { get { return _date; } set { _date = value; } }
    }
}
}
