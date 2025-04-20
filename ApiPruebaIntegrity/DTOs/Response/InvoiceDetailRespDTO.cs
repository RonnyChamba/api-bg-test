using ApiPruebaIntegrity.Models;

namespace ApiPruebaIntegrity.DTOs.Response
{
    public record InvoiceDetailRespDTO(

        int Id,
        string Description,
        string Code,
        decimal Price,
        decimal Amount,
        decimal Subtotal,
        int InvoiceId,
        int ProductId
    );
}
