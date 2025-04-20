using ApiPruebaIntegrity.Models;

namespace ApiPruebaIntegrity.DTOs.Response
{
    public record InvoicePayFormRespDTO(

        int Id,
        string Description,
        decimal Total,
        int InvoiceId,
        int PayFormId
    );
}
