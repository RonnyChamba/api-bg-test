using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.Enums;
using ApiPruebaIntegrity.Services;
using ApiPruebaIntegrity.Util;
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> FindAllInvoice(string? valueFilter,
                                                        InvoiceFilterTypeEnum? invoiceFilterType,
                                                        ComparisonOperatorEnum? comparisonOperator) {

            var response = await _invoiceService.FindAllInvoice(FilterUtil.GenericReqFilterInvoice(
                valueFilter,
                invoiceFilterType,
                comparisonOperator
                ));

            return Ok(response);
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> FindInvoice(int id)
        {
            var response = await _invoiceService.FindFullInvoice(id);

            return Ok(response);
        }



    }
}
