using ApiPruebaIntegrity.Data;
using ApiPruebaIntegrity.DTOs.Response;
using ApiPruebaIntegrity.Exceptions;
using ApiPruebaIntegrity.Models;
using ApiPruebaIntegrity.Util;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaIntegrity.Services.Impl
{
    public class ReportServiceImpl : IReportService
    {

        private readonly ILogger<ReportServiceImpl> _logger;
        private readonly DBContextTest _dBContextTest;
        public ReportServiceImpl(ILogger<ReportServiceImpl> logger, DBContextTest dBContextTest)
        { 
            _logger = logger;
            _dBContextTest = dBContextTest;
        
        }

        public async Task<GenericRespDTO<string>> GeneratPdfInvoice(int id)
        {
            _logger.LogInformation("Invoice report: {}", id);


            var invoiceFullModel = await RetriveFullInvoice(id);


            throw new NotImplementedException();
        }

        private async Task<Invoice> RetriveFullInvoice(int id) 
        {
            return await _dBContextTest
                .Invoices
                .Include(x=>x.Details)
                .Include(x=>x.InvoicePayForm)
                .Where(invoice => invoice.Id == id &&
                       invoice.Status.Equals(IntegrityApiConstants.StatusActive))
                .FirstOrDefaultAsync()
                ?? throw new NotFoundException($"Invoice with id {id} not exists");
        
        }
    }
}
