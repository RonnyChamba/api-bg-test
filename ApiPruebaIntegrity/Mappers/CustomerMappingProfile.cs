using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;
using ApiPruebaIntegrity.Models;
using AutoMapper;

namespace ApiPruebaIntegrity.Mappers
{
    public class CustomerMappingProfile : Profile
    {

        public CustomerMappingProfile() 
        {
            CreateMap<CustomerReqDTO, Customer>();
            CreateMap<Customer, CustomerRespDTO>();
           
        } 
    }
}
