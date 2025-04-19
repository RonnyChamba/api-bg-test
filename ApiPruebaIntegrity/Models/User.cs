using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaIntegrity.Models
{
    [Table("users")]
    public class User
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Names { set; get; }


        [MaxLength(100)]
        public string LasName { set; get; }


        [MaxLength(100)]
        public string Username { set; get; }


        [MaxLength(100)]
        public string Password { set; get; }


        [MaxLength(100)]
        public string Email { set; get; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }


        [MaxLength(10)]
        public string Rol { set; get; }


        [MaxLength(10)]
        public string Status { set; get; }

        public DateTime CreateAt { set; get; }
    }
}
