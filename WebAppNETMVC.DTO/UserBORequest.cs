using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppNETMVC.DTO
{
    public class UserBORequest
    {
        [Required(ErrorMessage = "Please Enter Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string LoginIPAddress { get; set; }
        public string TimeZone { get; set; }
        public Nullable<System.DateTime> LastAccessedDate { get; set; }

    }
}
