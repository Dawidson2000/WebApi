using Application.Models.User;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterUser, UserEntity>();
        }
    }
}
