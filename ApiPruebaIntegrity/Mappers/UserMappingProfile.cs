using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;
using ApiPruebaIntegrity.Models;
using AutoMapper;

namespace ApiPruebaIntegrity.Mappers
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile() {

            CreateMap<UserReqDTO, User>();
            CreateMap<User, UserRespDTO>();
        }
    }
}
