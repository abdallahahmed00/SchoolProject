using AutoMapper;
using Core.Features.User.Commands.Models;
using Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.AppUserMapping
{
    public partial class ApplicationUserProfile
    {
        public void AddUserMapping()
        {
            CreateMap<AddUserCommand, User>()
                //.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                //.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                //.ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                //.ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                //.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
   ;
        }
    }
}
