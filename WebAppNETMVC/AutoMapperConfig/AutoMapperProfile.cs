using AutoMapper;
using WebAppNETMVC.Data;
using WebAppNETMVC.DTO;

namespace WebAppNETMVC.AutoMapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
           //Source -> Destination
            //CreateMap<LoginBORequest, LoginRequest>();
            CreateMap<uspValidateUser_Result, LoginBOResponse>();
            CreateMap<customer, CustomerBOResponse>();
            CreateMap<customer, CustomerBOResponseWithPaging>();
            CreateMap<CustomerBORequest, customer>();
            //CreateMap<UserBORequest, user>();
            //CreateMap<user, UserBOResponse>();
            CreateMap<UserBORequest, uspValidateUser_Result>();
            CreateMap<uspValidateUser_Result, UserBOResponse>();

            CreateMap<LoginBORequest, uspValidateUser_Result>();
        }
    }
}