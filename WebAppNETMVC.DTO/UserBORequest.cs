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
        public string username { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        public string confirm_password { get; set; }
        public string login_ipaddress { get; set; }
        public string time_zone { get; set; }
        public Nullable<System.DateTime> last_accessed_date { get; set; }

    }
}
