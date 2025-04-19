using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaIntegrity.Controllers
{

    [ApiController]
    [Route("/api/v1/public")]
    public class PublicController:ControllerBase
    {

        private readonly IUserService _userService;

        public PublicController(IUserService userService) {
            _userService = userService;
        }

        [HttpPost]
        [Route("register-company")]
        public async Task<IActionResult> SaveCompany([FromBody] GenericReqDTO<CompanyReqDTO> reqDTO) {

            var response = await _userService.SaveCompany(reqDTO);

            return Ok(response);
        }
    }
}
