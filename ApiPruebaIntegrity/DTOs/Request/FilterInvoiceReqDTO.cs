namespace ApiPruebaIntegrity.DTOs.Request
{
    public record FilterInvoiceReqDTO(
    
        string ValueFilter,
        string FilterType,
        string OperatorType
    );
}
