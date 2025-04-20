using ApiPruebaIntegrity.Enums;

namespace ApiPruebaIntegrity.DTOs.Request
{
    public record FilterInvoiceReqDTO(
    
        string? ValueFilter,
        InvoiceFilterTypeEnum? InvoiceFilterType,
        ComparisonOperatorEnum? ComparisonOperator
    );
}
