using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;

namespace ApiPruebaIntegrity.Services
{
    public interface ICompanyService
    {

       Task< GenericRespDTO<CompanyRespDTO>> RetrieveCompanyUserInSession();
       Task< GenericRespDTO<string>> UpdateCompanyInSession(GenericReqDTO<CompanySimpleReqDTO> reqDTO, int id);
    }
}
