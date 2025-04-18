using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.Security.DTOs;
using ApiPruebaIntegrity.Security.Service;
using Microsoft.AspNetCore.Mvc;
namespace ApiPruebaIntegrity.Security.Controllers
{
    [ApiController]
    [Route("/api/v1/auth")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService) { 
            
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> AuthUser([FromBody] GenericReqDTO<LoginReqDTO> reqDTO) { 
        
            var response = await _authenticationService.AuthUser(reqDTO);

            return Ok(response);
        }

    }
}
