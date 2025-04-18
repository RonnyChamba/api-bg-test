using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;

namespace ApiPruebaIntegrity.Services
{
    public interface IUserService
    {

       Task<GenericRespDTO<string>> SaveCompany(GenericReqDTO<CompanyReqDTO> reqDTO);
       Task<GenericRespDTO<string>> SaveUser(GenericReqDTO<UserReqDTO> reqDTO);
       Task<GenericRespDTO<bool>> ExistUserByUsername(GenericReqDTO<string> reqDTO);
    }
}
