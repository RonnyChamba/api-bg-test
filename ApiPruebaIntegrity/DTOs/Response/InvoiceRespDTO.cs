using System.ComponentModel.DataAnnotations;

namespace ApiPruebaIntegrity.DTOs.Response
{
    public record InvoiceRespDTO(
        int Id,
        string InvoiceNumber,
        string FullNameCustomer,
        string FullNameUser,
        string StatusPay,
        string CreateAt,
        decimal Total
    );
}
