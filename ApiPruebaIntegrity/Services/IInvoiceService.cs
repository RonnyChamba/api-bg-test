using ApiPruebaIntegrity.DTOs.Request;
using ApiPruebaIntegrity.DTOs.Response;

namespace ApiPruebaIntegrity.Services
{
    public interface IInvoiceService
    {
        Task <GenericRespDTO<string>> CreateInvoice(GenericReqDTO<InvoiceReqDTO> reqDTO);
        Task <GenericRespDTO<List<InvoiceRespDTO>>> FindAllInvoice(GenericReqDTO<FilterInvoiceReqDTO> reqDTO);
        Task <GenericRespDTO<RetrieveFullInvoiceRespDTO>> FindFullInvoice(int id);

        Task<GenericRespDTO<string>> UpdateInvoice(GenericReqDTO<InvoiceReqDTO> reqDTO, int id);
        Task <GenericRespDTO<string>> DeleteInvoice(int id);
    }
}
