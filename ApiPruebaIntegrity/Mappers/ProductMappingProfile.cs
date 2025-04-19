using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;
using ApiPruebaIntegrity.Models;
using AutoMapper;

namespace ApiPruebaIntegrity.Mappers
{
    public class ProductMappingProfile: Profile
    {
        public ProductMappingProfile()
        {

            CreateMap<ProductReqDTO, Product>();
            CreateMap<Product, ProductRespDTO>();
        }
    }
}
