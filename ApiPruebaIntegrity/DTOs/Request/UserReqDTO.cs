
using System.ComponentModel.DataAnnotations;

namespace ApiPruebaIntegrity.DTOs.Request
{
    public record UserReqDTO
    (

         [Required(ErrorMessage = "The Names field is required")]
         [StringLength(100, ErrorMessage = "The Names field must not exceed 100 characters.")]
         string Names,

         [Required(ErrorMessage = "The LastName field is required")]
         [StringLength(100, ErrorMessage = "The LastName field must not exceed 100 characters.")]
         string LasName,

         [Required(ErrorMessage = "The Username field is required")]
         [StringLength(100, ErrorMessage = "The Username field must not exceed 100 characters.")]
         string Username,

         [Required(ErrorMessage = "The Password field is required")]
         [StringLength(25, ErrorMessage = "The Password field must not exceed 25 characters.")]
         string Password,

         [Required(ErrorMessage = "The Email field is required")]
         [StringLength(100, ErrorMessage = "The Email field must not exceed 100 characters.")]
         string Email,

         [Required(ErrorMessage = "The Rol field is required")]
         [StringLength(10, ErrorMessage = "The Rol field must not exceed 10 characters.")]
         string Rol

    );
}
