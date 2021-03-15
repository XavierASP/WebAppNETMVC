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

        public uspValidateUser_Result ValidateUser(LoginBORequest loginRequest)
        {
            var response = _bikeStoresContext.uspValidateUser(loginRequest.Username, loginRequest.Password);
            var result = response.FirstOrDefault();
            return result;
        }
    }
}
