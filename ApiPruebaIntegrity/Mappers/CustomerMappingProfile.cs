using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.Models;
using AutoMapper;

namespace ApiPruebaIntegrity.Mappers
{
    public class CustomerMappingProfile : Profile
    {

        public CustomerMappingProfile() 
        {
            CreateMap<CustomerReqDTO, Customer>();
           
        } 
    }
}
