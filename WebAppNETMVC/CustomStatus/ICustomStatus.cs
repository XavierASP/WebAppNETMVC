using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppNETMVC.CustomStatus
{
    public interface ICustomStatus
    {
        int StatusCode { get; set; }
        string StatusDescription { get; set; }
    }
}
