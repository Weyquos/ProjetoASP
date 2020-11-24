using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Models
{
    [Table("Usuarios")]
    public class UsuarioView : BaseModel
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Senha { get; set; }

        [Display(Name = "Confirmar Senha")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [NotMapped]
        [Compare("Senha", ErrorMessage = "As senhas não são iguais.")]
        public string ConfirmacaoSenha { get; set; }
    }
}
