using ApiPruebaIntegrity.Models;

namespace ApiPruebaIntegrity.DTOs.Response
{
    public record RetrieveFullInvoiceRespDTO(

        int Id,
        string InvoiceNumber,
        string FullNameCustomer,
        string EmailCustomer,
        string CellPhoneCustomer,
        string FullNameUser,
        string Status,
        decimal PorcentajeIva,
        decimal IvaValue,
        decimal SubTotal,
        string StatusPay,
        decimal Total,
        string CreateAt,
        List<InvoiceDetailRespDTO> Details,
        int CustomerId,
        int UserId,
        int CompanyId,
        List<InvoicePayFormRespDTO> InvoicePayForm
    );
}
