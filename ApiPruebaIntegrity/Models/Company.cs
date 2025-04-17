using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaIntegrity.Models
{

    [Table("company")]
    public class Company
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string FullName { set; get; }
        [MaxLength(50)]
        public decimal PorcentajeIva { set; get; }

        [MaxLength(100)]
        public string City { set; get; }
    }
}
