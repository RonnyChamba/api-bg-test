using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.Services;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SaveCustomer([FromBody] GenericReqDTO<CustomerReqDTO> reqDTO)
        { 
        
            var response = await _customerService.SaveCustomer(reqDTO);
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> FindAllCustomers(string? name)
        {
            var response = await _customerService.FindAllCustomers(name?? "");

            return Ok(response);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> FindCustomer(int id)
        {
            var response = await _customerService.FindCustomer(id);

           return Ok(response);
        }

    }
}
