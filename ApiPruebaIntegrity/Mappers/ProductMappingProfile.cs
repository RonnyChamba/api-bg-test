using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.Models;
using AutoMapper;

namespace ApiPruebaIntegrity.Mappers
{
    public class ProductMappingProfile: Profile
    {
        public ProductMappingProfile()
        {

            CreateMap<ProductReqDTO, Product>();
        }
    }
}
