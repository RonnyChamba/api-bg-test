using ApiPruebaIntegrity.DTOs.Response;
using ApiPruebaIntegrity.Models;
using AutoMapper;

namespace ApiPruebaIntegrity.Mappers
{
    public class UtilMappingProfile:Profile
    {
        public UtilMappingProfile() { 
            
            CreateMap<PayForm, PayFormRespDTO>();
        }
    }
}
