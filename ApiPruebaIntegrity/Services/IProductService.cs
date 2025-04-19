using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;

namespace ApiPruebaIntegrity.Services
{
    public interface IProductService
    {
        Task<GenericRespDTO<string>> SaveProduct(GenericReqDTO<ProductReqDTO> reqDTO);
    }
}
