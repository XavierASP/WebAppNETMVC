using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppNETMVC.DTO
{
    public class LoginBORequest
    {
        [Required(ErrorMessage = "Please Enter Username")]
        public string username { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string password { get; set; }
    }
}
