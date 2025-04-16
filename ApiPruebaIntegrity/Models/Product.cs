using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaIntegrity.Models
{

    [Table("products")]
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Code { set; get; }

        [MaxLength(200)]
        public string Description { set; get; }

        [MaxLength(100)]
        public string Status { set; get; }

        [Column(TypeName ="decimal(7,2)")]
        public decimal Price { set; get; }
        public int SaleCount { set; get; }
        public DateTime CreateAt { set; get; }
    }
}
