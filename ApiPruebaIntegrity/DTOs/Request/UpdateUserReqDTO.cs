using System.ComponentModel.DataAnnotations;

namespace ApiPruebaIntegrity.DTOs.Request
{
    public record UpdateUserReqDTO
    (

        [Required(ErrorMessage = "The Names field is required")]
         [StringLength(100, ErrorMessage = "The Names field must not exceed 100 characters.")]
         string Names,

         [Required(ErrorMessage = "The LastName field is required")]
         [StringLength(100, ErrorMessage = "The LastName field must not exceed 100 characters.")]
         string LasName,

         [Required(ErrorMessage = "The Email field is required")]
         [StringLength(100, ErrorMessage = "The Email field must not exceed 100 characters.")]
         [EmailAddress(ErrorMessage ="The Email field is incorrect")]
         string Email
    );
}
