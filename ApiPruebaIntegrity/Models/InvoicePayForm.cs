using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaIntegrity.Models
{

    [Table("invoice_pay_form")]
    public class InvoicePayForm
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Description { set; get; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal Total { set; get; }

        [ForeignKey("invoice_id")]
        public Invoice Invoice { get; set; }

        [ForeignKey("pay_form_id")]
        public PayForm PayForm { get; set; }

    }
}
