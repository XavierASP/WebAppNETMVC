using System.Linq;
using WebAppNETMVC.Data;
using WebAppNETMVC.DTO;

namespace WebAppNETMVC.Repository
{
    public class LoginRepository : Repository<uspValidateUser_Result>, ILoginRepository 
    {
        BikeStoresContext _bikeStoresContext;
        public LoginRepository(BikeStoresContext bikeStoresContext) : base(bikeStoresContext)
        {
            this._bikeStoresContext = bikeStoresContext;
        }

        public uspValidateUser_Result ValidateUser(uspValidateUser_Result loginRequest)
        {
            var response = _bikeStoresContext.uspValidateUser(loginRequest.username, loginRequest.password);
            var result = response.FirstOrDefault();
            return result;
        }

        public uspValidateUser_Result SignUp(uspValidateUser_Result uspValidateUser_Result)
        {
           return Add(uspValidateUser_Result);
        }
    }
}
