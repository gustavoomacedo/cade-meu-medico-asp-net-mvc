using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(CidadeMetadado))]
    public partial class Cidade
    {
    }

    public class CidadeMetadado
    {
        [Required(ErrorMessage = "Obrigatório informar o Nome da cidade")]
        [StringLength(80, ErrorMessage = "O Nome deve possuir no máximo 80 caracteres")]
        public string Nome { get; set; }
    }
}