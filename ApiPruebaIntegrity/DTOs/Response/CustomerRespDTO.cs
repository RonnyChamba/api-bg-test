namespace ApiPruebaIntegrity.DTOs.Response
{
    public record CustomerRespDTO(
        int    Id,
        string FullName,
        string CellPhone,
        string Email,
        string Address,
        string Status,
        string CreateAt
    );
}
