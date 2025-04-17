using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.Models;
using AutoMapper;

namespace ApiPruebaIntegrity.Mappers
{
    public class CompanyMappingProfile:Profile
    {

        public CompanyMappingProfile() {

            CreateMap<CompanyReqDTO, Company>();

        }
       
       
    }
}
