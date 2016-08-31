using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(Usuario))]
    public partial class Usuario
    {
    }
    public class UsuarioMetadado
    {
        [Required(ErrorMessage = "Obrigatório informar o Nome")]
        [StringLength(80, ErrorMessage = "O Nome deve possuir no máximo 80 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Login")]
        [StringLength(15, ErrorMessage = "O Nome deve possuir no máximo 15 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Senha")]
        [StringLength(16, ErrorMessage = "O Senha deve possuir no máximo 16 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Email")]
        [StringLength(50, ErrorMessage = "O Email deve possuir no máximo 80 caracteres")]
        [EmailAddress(ErrorMessage ="Digite um e-mail válido")]
        public string Email { get; set; }
    }
}