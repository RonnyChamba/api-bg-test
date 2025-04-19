using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;

namespace ApiPruebaIntegrity.Services
{
    public interface IProductService
    {
        Task<GenericRespDTO<string>> SaveProduct(GenericReqDTO<ProductReqDTO> reqDTO);
        Task<GenericRespDTO<List<ProductRespDTO>>> FindAllProducts(string paramFilter);

    }
}
