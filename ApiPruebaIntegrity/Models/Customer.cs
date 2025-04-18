using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaIntegrity.Models
{

    [Table("customers")]
    public class Customer
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string FullName { set; get; }

        [MaxLength(15)]
        public string CellPhone { set; get; }

        [MaxLength(100)]
        public string Email { set; get; }

        [MaxLength(100)]
        public string Address { set; get; }
 
       public int CompanyId { get; set; }

        public Company Company { get; set; }

        [MaxLength(10)]
        public string Status { set; get; }

        public DateTime CreateAt { set; get; }
    }
}
