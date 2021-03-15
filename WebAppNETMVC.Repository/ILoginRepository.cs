using WebAppNETMVC.Data;
using WebAppNETMVC.DTO;

namespace WebAppNETMVC.Repository
{
    public interface ILoginRepository 
    {
        uspValidateUser_Result ValidateUser(LoginBORequest loginRequest);
    }
}
