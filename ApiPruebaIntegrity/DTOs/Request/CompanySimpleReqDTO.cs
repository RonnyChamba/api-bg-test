using System.ComponentModel.DataAnnotations;

namespace ApiPruebaIntegrity.DTOs.Request
{
    public record CompanySimpleReqDTO(


        [Required(ErrorMessage = "The fullName field is required")]
        [StringLength(100, ErrorMessage = "The FullName field must not exceed 100 characters.")]
        string FullName,

        [Required(ErrorMessage = "The porcentajeIva field is required")]
        decimal PorcentajeIva,

        [Required(ErrorMessage = "The city field is required")]
        [StringLength(100, ErrorMessage = "The city field must not exceed 100 characters.")]
       string City
    );
}
