using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;

namespace ApiPruebaIntegrity.Services
{
    public interface IUserService
    {

       Task<GenericRespDTO<string>> SaveCompany(GenericReqDTO<CompanyReqDTO> reqDTO);
       Task<GenericRespDTO<string>> SaveUser(GenericReqDTO<UserReqDTO> reqDTO);

        Task<GenericRespDTO<List<UserRespDTO>>> FindAllUsers(string name);

        Task<GenericRespDTO<UserRespDTO>> FindUser(int id);
        Task<GenericRespDTO<bool>> ExistUserByUsername(GenericReqDTO<string> reqDTO);
    }
}
