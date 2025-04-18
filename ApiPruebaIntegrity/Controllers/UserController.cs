using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaIntegrity.Controllers
{
    [ApiController]
    [Route("/api/v1/users")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SaveUser([FromBody] GenericReqDTO<UserReqDTO> reqDTO) { 
        
            var response = await _userService.SaveUser(reqDTO);

            return Ok(response);

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> FindAllUser(string? name)
        {
            var response = await _userService.FindAllUsers(name??"");

            return Ok(response);

        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> FindUser(int id)
        {
            var response = await _userService.FindUser(id);

            return Ok(response);

        }

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] GenericReqDTO<UpdateUserReqDTO> reqDTO, int id)
        {
            var response = await _userService.UpdateUser(reqDTO, id);

            return Ok(response);

        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await _userService.DeleteUser(id);
            return Ok(response);

        }

        [Authorize]
        [HttpPatch("update-passsword/{id}")]
        public async Task<IActionResult> UpdatePasswordUser([FromBody] GenericReqDTO<string> reqDTO, int id)
        {
            var response = await _userService.UpdatePasswordUser(reqDTO, id);

            return Ok(response);

        }

    }
}
