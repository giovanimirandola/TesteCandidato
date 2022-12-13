using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteCandidatoWebApplication.Models
{
    public class CEP
    {
        public int Id { get; set; }

        [Column(TypeName = "char"), MaxLength(9)]
        public string? Cep { get; set; }

        [MaxLength(500)]        
        public string? Logradouro { get; set; }

        [MaxLength(500)]
        public string? Complemento { get; set; }

        [MaxLength(500)]
        public string? Bairro { get; set; }

        [MaxLength(500)]
        public string? Localidade { get; set; }

        [Column(TypeName = "char"), MaxLength(2)]
        public string? UF { get; set; }

        public long? Unidade { get; set; }

        public int? IBGE { get; set; }

        [MaxLength(500)]
        public long? GIA { get; set; }
    }
}
