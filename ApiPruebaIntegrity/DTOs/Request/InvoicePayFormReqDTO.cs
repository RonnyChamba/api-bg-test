using System.ComponentModel.DataAnnotations;

namespace ApiPruebaIntegrity.DTOs.Request
{
    public record InvoicePayFormReqDTO(

        [Required(ErrorMessage = "The Id field is required")]
        int Id,

        [Required(ErrorMessage = "The description field is required")]
         string Description,

        [Required(ErrorMessage = "The total field is required")]
         decimal Total
    );
}
