using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;

namespace ApiPruebaIntegrity.Services
{
    public interface ICustomerService
    {
        Task<GenericRespDTO<string>> SaveCustomer(GenericReqDTO<CustomerReqDTO> reqDTO);
    }
}
