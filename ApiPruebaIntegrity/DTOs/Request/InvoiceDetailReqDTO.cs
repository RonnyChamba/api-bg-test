using System.ComponentModel.DataAnnotations;

namespace ApiPruebaIntegrity.DTOs.Request
{
    public record InvoiceDetailReqDTO(

         [Required(ErrorMessage = "The Id field is required")]
         int Id,

         [Required(ErrorMessage = "The description field is required")]
         string Description,

         [Required(ErrorMessage = "The code field is required")]
         string Code,

         [Required(ErrorMessage = "The price field is required")]
         decimal Price,

         [Required(ErrorMessage = "The amount field is required")]
         decimal Amount,

         [Required(ErrorMessage = "The subtotal field is required")]
         decimal Subtotal
            
    );
}
