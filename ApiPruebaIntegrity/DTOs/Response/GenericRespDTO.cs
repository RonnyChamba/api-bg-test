namespace ApiPruebaIntegrity.DTOs.Response
{
    public record GenericRespDTO<T>
    (
        string Status,
        string Message,
        T Data
    );
}
