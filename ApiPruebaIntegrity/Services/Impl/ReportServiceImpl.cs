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
        private readonly IPdfService _pdfService;
        private readonly ISessionService _sessionService;
        public ReportServiceImpl(ILogger<ReportServiceImpl> logger, DBContextTest dBContextTest, ISessionService sessionService, IPdfService pdfService)
        { 
            _logger = logger;
            _dBContextTest = dBContextTest;
            _sessionService = sessionService;
            _pdfService = pdfService;
        
        }

        public async Task<GenericRespDTO<string>> GeneratPdfInvoice(int id)
        {
            _logger.LogInformation("Invoice report: {}", id);

            var invoiceFullModel = await RetriveFullInvoice(id);

            var company = await RetrieveCompanySession();

            var templateHtml = await RetriveTemplateHtmlInvoice(TemplateUtil.MnemonicTemplateHtmlReport);

            var keyValueToReplace = PdfUtil.GenerateKeysInvoicePdf(invoiceFullModel, company);

            var templateReplaced = TemplateUtil.ReemplazarPlaceholders(templateHtml.Html, keyValueToReplace);

            _logger.LogInformation("Template replaced: {}", templateReplaced);

            var pdfPath = await _pdfService.ConvertHtmlToPdf(templateReplaced, "");

            return new GenericRespDTO<string>("OK", "Report .pdf generate", pdfPath);
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

        private async Task<Template> RetriveTemplateHtmlInvoice(string mnemonic)
        {
            return await _dBContextTest
                .Templates
                .Where(template => template.Mnemonic.Equals(mnemonic))
                .FirstOrDefaultAsync()
                ?? throw new NotFoundException($"Template with mnemonic {mnemonic} not exists");

        }

        private async Task<Company> RetrieveCompanySession() {

            var companyId = _sessionService.RetrieveIdCompanySession();

            return await _dBContextTest
                .Companies
                .Where(x => x.Id == companyId)
                .FirstOrDefaultAsync()
                 ?? throw new NotFoundException($"Company with id {companyId} not exists");


        }



    }
}
