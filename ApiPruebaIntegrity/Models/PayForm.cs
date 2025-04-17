using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaIntegrity.Models
{
    [Table("pay_forms")]
    public class PayForm
    {

        public int Id { get; set; }

        [MaxLength(100)]
        public string Description { set; get; }
        
    }
}
