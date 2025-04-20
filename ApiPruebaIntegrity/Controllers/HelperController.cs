using ApiPruebaIntegrity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaIntegrity.Controllers
{
    [ApiController]
    [Route("/api/v1/helpers")]
    public class HelperController: ControllerBase
    {

        private readonly IHelperService _helperService;

        public HelperController(IHelperService helperService)
        {
            _helperService = helperService;
        }

        [Authorize]
        [HttpGet("getting-pay-forms")]
        public async  Task<ActionResult> GettingPayForms() {
            
            var response = await _helperService.FindAllPayForm();

            return Ok(response);
        }
    }
}
