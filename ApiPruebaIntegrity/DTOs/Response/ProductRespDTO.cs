using System.ComponentModel.DataAnnotations;

namespace ApiPruebaIntegrity.DTOs.Response
{
    public record ProductRespDTO(

        int Id,
        string Code,
        string Description,
        decimal Price,
        string Status,
        string CreateAt,
        int SaleCount
    );
}
