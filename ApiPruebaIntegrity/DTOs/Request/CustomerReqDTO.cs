namespace ApiPruebaIntegrity.DTOs.Request
{
    public record CustomerReqDTO(
        string FullName,
        string CellPhone,
        string Email,
        string Address
    );
}
