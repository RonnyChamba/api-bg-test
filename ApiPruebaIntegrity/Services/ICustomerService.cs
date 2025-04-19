using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;

namespace ApiPruebaIntegrity.Services
{
    public interface ICustomerService
    {
        Task<GenericRespDTO<string>> SaveCustomer(GenericReqDTO<CustomerReqDTO> reqDTO);
        Task<GenericRespDTO<List<CustomerRespDTO>>> FindAllCustomers(string name);
        Task<GenericRespDTO<CustomerRespDTO>> FindCustomer(int id);
        Task<GenericRespDTO<string>> UpdateCustomer( GenericReqDTO<UpdateCustomerReqDTO> reqDTO, int id);
        Task<GenericRespDTO<string>> DeleteCustomer(int id);
    }
}
