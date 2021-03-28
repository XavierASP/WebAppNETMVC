using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppNETMVC.Data;
using WebAppNETMVC.DTO;
using WebAppNETMVC.IService;
using WebAppNETMVC.Repository;

namespace WebAppNETMVC.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;

        public LoginService(ILoginRepository loginRepository,IMapper mapper) 
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }

        public UserBOResponse SignUp(UserBORequest userBORequest)
        {
            var userRequest = _mapper.Map<uspValidateUser_Result>(userBORequest);
            uspValidateUser_Result user = _loginRepository.SignUp(userRequest);
            return _mapper.Map<UserBOResponse>(user);
        }
        public LoginBOResponse ValidateUser(LoginBORequest loginBORequest)
        {
            var loginRequest = _mapper.Map<uspValidateUser_Result>(loginBORequest);
            var response = _loginRepository.ValidateUser(loginRequest);
            //var result = response.FirstOrDefault();
            var result = _mapper.Map<LoginBOResponse>(response);
            return result;
        }
    }
}
