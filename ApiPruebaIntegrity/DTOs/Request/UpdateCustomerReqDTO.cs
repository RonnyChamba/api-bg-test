using System.ComponentModel.DataAnnotations;

namespace ApiPruebaIntegrity.DTOs.Request
{
    public record UpdateCustomerReqDTO(

        [Required(ErrorMessage = "The fullName field is required")]
        [StringLength(100, ErrorMessage = "The FullName field must not exceed 100 characters.")]
        string FullName,

        [Required(ErrorMessage = "The cellPhone field is required")]
        [StringLength(15, ErrorMessage = "The cellPhone field must not exceed 15 characters.")]
        string CellPhone,

        [Required(ErrorMessage = "The email field is required")]
        [StringLength(100, ErrorMessage = "The email field must not exceed 100 characters.")]
        [EmailAddress(ErrorMessage ="The email field is incorrect")]
        string Email,

        [Required(ErrorMessage = "The address field is required")]
        [StringLength(100, ErrorMessage = "The address field must not exceed 100 characters.")]
        string Address
    );
}
