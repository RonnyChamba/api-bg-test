using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;

namespace ApiPruebaIntegrity.Services
{
    public interface IUserService
    {

        GenericRespDTO<string> SaveCompany(GenericReqDTO<CompanyReqDTO> reqDTO);
    }
}
