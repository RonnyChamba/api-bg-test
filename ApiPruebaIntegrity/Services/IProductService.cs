using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;

namespace ApiPruebaIntegrity.Services
{
    public interface IProductService
    {
        Task<GenericRespDTO<string>> SaveProduct(GenericReqDTO<ProductReqDTO> reqDTO);
        Task<GenericRespDTO<List<ProductRespDTO>>> FindAllProducts(string paramFilter);
        Task<GenericRespDTO<ProductRespDTO>> FindProductById(int id);
        Task<GenericRespDTO<string>> UpdateProduct(GenericReqDTO<UpdateProductReqDTO> reqDTO, int id);
        Task<GenericRespDTO<string>> DeleteProduct(int id);

    }
}
