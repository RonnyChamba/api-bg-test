using System.ComponentModel.DataAnnotations;

namespace ApiPruebaIntegrity.DTOs.Request
{
    public record InvoicePayFormReqDTO(

        [Required(ErrorMessage = "The payFormId field is required")]
        int PayFormId,

        [Required(ErrorMessage = "The description field is required")]
         string Description,

        [Required(ErrorMessage = "The total field is required")]
         decimal Total
    );
}
