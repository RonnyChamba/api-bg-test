using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaIntegrity.Models
{
    [Table("invoices")]
    public class Invoice
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string InvoiceNumber { set; get; }

        [MaxLength(100)]
        public string FullNameCustomer { set; get; }

        [MaxLength(100)]
        public string EmailCustomer { set; get; }

        [MaxLength(100)]
        public string CellPhoneCustomer { set; get; }

        [MaxLength(100)]
        public string FullNameUser { set; get; }

        [MaxLength(20)]
        public string Status { set; get; }

        [MaxLength(50)]
        public string PayForm { set; get; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal PorcentajeIva { set; get; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal IvaValue { set; get; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal SubTotal { set; get; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal Total { set; get; }

        public DateTime CreateAt { set; get; }

        public List<InvoiceDetail> Details { get; set; } = new List<InvoiceDetail>();

        [ForeignKey("customer_id")]
        public Customer customer { get; set; }

        [ForeignKey("user_id")]
        public User User { get; set; }
    }
}
