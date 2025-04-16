using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaIntegrity.Models
{

    [Table("users")]
    public class User
    {

        public int Id { get; set; }

        public string Names { set; get; }
        
        public string LasName { set; get; }

        public string Username { set; get; } 

        public string Password { set; get; }

        public string Email { set; get; }

        public DateTime CreateAt { set; get; }

        
    }
}
