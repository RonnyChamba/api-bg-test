using System.ComponentModel.DataAnnotations;

namespace ApiPruebaIntegrity.DTOs.Request
{
    public record GenericReqDTO<T>
    (
        [Required(ErrorMessage ="The origin field is required")]
        string Origin,

        [Required(ErrorMessage ="The payload field is required")]
        T Payload
        
    );
}
