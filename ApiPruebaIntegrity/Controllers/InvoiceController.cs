using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;
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
        private readonly IReportService _reportService;

        public InvoiceController(IInvoiceService invoiceService, IReportService reportService)
        { 
            _invoiceService = invoiceService;
            _reportService = reportService;
        
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

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice([FromBody] GenericReqDTO<InvoiceReqDTO> reqDTO, int id)
        {
            var response = await _invoiceService.UpdateInvoice(reqDTO, id);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("{id}/report-pdf")]
        public async Task<IActionResult> GenerateReportPdfInvoice(int id)
        {
            var response = await _reportService.GeneratPdfInvoice(id);

            byte[] fileBytes = FileUtil.ReadAndDeletePdf(response.Data);

            return File(fileBytes, "application/pdf", "report_invoice.pdf");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var response = await _invoiceService.DeleteInvoice(id);

            return Ok(response);
        }



    }
}
