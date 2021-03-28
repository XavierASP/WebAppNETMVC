using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppNETMVC.DTO;

namespace WebAppNETMVC.IService
{
    public interface ILoginService
    {
        UserBOResponse SignUp(UserBORequest userBORequest);
        LoginBOResponse ValidateUser(LoginBORequest loginBORequest);

    }
}
