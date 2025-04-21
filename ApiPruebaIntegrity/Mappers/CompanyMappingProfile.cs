using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;
using ApiPruebaIntegrity.Models;
using AutoMapper;

namespace ApiPruebaIntegrity.Mappers
{
    public class CompanyMappingProfile:Profile
    {

        public CompanyMappingProfile() {

            CreateMap<CompanyReqDTO, Company>();
            CreateMap<Company, CompanyRespDTO>();

        }
       
       
    }
}
