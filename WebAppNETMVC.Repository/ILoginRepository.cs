using WebAppNETMVC.Data;
using WebAppNETMVC.DTO;

namespace WebAppNETMVC.Repository
{
    public interface ILoginRepository : IRepository<uspValidateUser_Result>
    {
        uspValidateUser_Result ValidateUser(uspValidateUser_Result loginRequest);
        uspValidateUser_Result SignUp(uspValidateUser_Result uspValidateUser_Result);

    }
}
