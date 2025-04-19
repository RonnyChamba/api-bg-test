using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaIntegrity.Controllers
{
    [ApiController]
    [Route("/api/v1/invoices")]
    public class InvoiceController: ControllerBase
    {

        public readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        { 
            _invoiceService = invoiceService;
        
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] GenericReqDTO<InvoiceReqDTO> reqDTO)
        {

            var response = await _invoiceService.CreateInvoice(reqDTO);

            return Ok(response);
        
        }

        

    }
}
