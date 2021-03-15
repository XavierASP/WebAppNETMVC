using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppNETMVC.DTO
{
    public class LoginBOResponse
    {
        public int status_code { get; set; }
        public string status_description { get; set; }
        public int user_id { get; set; }
        public string username { get; set; }
        public Nullable<System.DateTime> last_login_date { get; set; }
        public Nullable<int> login_failed_count { get; set; }
        public string login_ipaddress { get; set; }
        public string time_zone { get; set; }
        public Nullable<System.DateTime> last_accessed_date { get; set; }
        public Nullable<bool> account_lock { get; set; }
    }
}
