using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaIntegrity.Models
{
    [Table("invoice_details")]
    public class InvoiceDetail
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
        
        [MaxLength(100)]
        public string Code { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }

        public decimal Amount { get; set; }

        public decimal Subtotal { get; set; }
        public Invoice Invoice { get; set; }
        public int InvoiceId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }

    }
}
