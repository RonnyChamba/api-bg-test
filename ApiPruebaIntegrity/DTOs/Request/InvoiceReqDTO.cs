using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPruebaIntegrity.DTOs.Request
{
    public record InvoiceReqDTO(

        [Required(ErrorMessage = "The origin field is required")]
        string CreateAt,

        [Required(ErrorMessage = "The StatusPay field is required")]
         string StatusPay,

        [Required(ErrorMessage = "The porcentajeIva field is required")]
         decimal PorcentajeIva,

        [Required(ErrorMessage = "The ivaValue field is required")]
        decimal IvaValue,

        [Required(ErrorMessage = "The subTotal field is required")]
        decimal SubTotal,

        [Required(ErrorMessage = "The total field is required")]
        decimal Total,

        [Required(ErrorMessage = "The invoiceDetails field is required")]
        [MinLength(1, ErrorMessage = "At least one invoiceDetails must be provided.")]
        List<InvoiceDetailReqDTO> InvoiceDetails,

        [Required(ErrorMessage = "The customerId field is required")]
        int CustomerId,

        [Required(ErrorMessage = "The InvoicePayForm field is required")]
        [MinLength(1, ErrorMessage = "At least one invoicePayForm must be provided.")]
        List<InvoicePayFormReqDTO> InvoicePayForm   
    );
}
