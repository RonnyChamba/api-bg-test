using System.ComponentModel.DataAnnotations;

namespace ApiPruebaIntegrity.DTOs.Request
{
    public record UpdateProductReqDTO(

        [Required(ErrorMessage = "The code field is required")]
        [StringLength(50, ErrorMessage = "The code field must not exceed 50 characters.")]
        string Code,

        [Required(ErrorMessage = "The description field is required")]
        [StringLength(200, ErrorMessage = "The description field must not exceed 200 characters.")]
        string Description,

        decimal Price
    );
}
