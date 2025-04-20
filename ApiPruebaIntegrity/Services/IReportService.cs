using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;

namespace ApiPruebaIntegrity.Services
{
    public interface IReportService
    {
        Task<GenericRespDTO<string>> GeneratPdfInvoice(int id);
    }
}
