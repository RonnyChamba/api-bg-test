using ApiPruebaIntegrity.Models;

namespace ApiPruebaIntegrity.DTOs.Response
{
    public record UserRespDTO
    (
        int Id,
        string Names,
        string LasName,
        string Username,
        string Email,
        int CompanyId,
        string Rol,
        string Status,
        string CreateAt
    );
}
