using AutoMapper;
using MyApi.Application.Commands;
using MyApi.Application.Responses;
using MyApi.Domain.Entities;

namespace MyApi.Application.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
        }
    }
}
