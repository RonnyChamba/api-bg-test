using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;
using ApiPruebaIntegrity.Security.DTOs;

namespace ApiPruebaIntegrity.Security.Service
{
    public interface IAuthenticationService
    {
        Task <GenericRespDTO<string>> AuthUser(GenericReqDTO<LoginReqDTO> reqDTO);
    }
}
