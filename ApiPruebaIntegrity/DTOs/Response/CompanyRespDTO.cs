namespace ApiPruebaIntegrity.DTOs.Response
{
    public record CompanyRespDTO(

        int Id,
        string FullName,
        decimal PorcentajeIva,
        string City
    );
}
