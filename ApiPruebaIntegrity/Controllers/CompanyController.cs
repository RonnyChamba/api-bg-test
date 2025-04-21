using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaIntegrity.Controllers
{
    [ApiController]
    [Route("/api/v1/companies")]
    public class CompanyController : ControllerBase
    {

        public readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        { 
            _companyService = companyService;
        
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> RetrieveCompanyUserInSession()
        { 
            var response = await _companyService.RetrieveCompanyUserInSession();

            return Ok(response);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany([FromBody] GenericReqDTO<CompanySimpleReqDTO> reqDTO, int id)
        {
            var response = await _companyService.UpdateCompanyInSession(reqDTO, id);

            return Ok(response);
        }
    }
}
