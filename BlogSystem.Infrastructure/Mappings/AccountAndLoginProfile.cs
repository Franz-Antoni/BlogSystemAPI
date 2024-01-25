using AutoMapper;
using BlogSystem.Core.Dtos.AccountAndLogin.Request;
using BlogSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Infrastructure.Mappings
{
    public class AccountAndLoginProfile : Profile
    {
        public AccountAndLoginProfile()
        {
            CreateMap<CreateAccountAndLoginRequest, UserAccount>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth));

            CreateMap<CreateAccountAndLoginRequest, UserLogin>()
                .ForMember(dest => dest.LoginName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.EmailAddress));
        }
    }
}
