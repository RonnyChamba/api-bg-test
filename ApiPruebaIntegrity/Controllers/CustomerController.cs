using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaIntegrity.Controllers
{
    [ApiController]
    [Route("/api/v1/customers")]
    public class CustomerController: ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        { 
            _customerService = customerService;
        
        }

        [HttpPost]
        public async Task<IActionResult> SaveCustomer([FromBody] GenericReqDTO<CustomerReqDTO> reqDTO)
        { 
        
            var response = await _customerService.SaveCustomer(reqDTO);
            return Ok(response);
        }

    }
}
