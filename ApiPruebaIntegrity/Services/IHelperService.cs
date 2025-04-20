using ApiPruebaIntegrity.DTOs.Response;

namespace ApiPruebaIntegrity.Services
{
    public interface IHelperService
    {
        Task<GenericRespDTO<List<PayFormRespDTO>>> FindAllPayForm();
    }
}
