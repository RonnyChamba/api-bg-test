using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaIntegrity.Models
{
    public class Template
    {
        public string Id { get; set; }
        public string Mnemonic { get; set; }

        [Column(TypeName = "text")]
        public string Html { get; set; }
    }
}
