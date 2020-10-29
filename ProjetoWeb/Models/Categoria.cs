using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Models
{
    [Table("Categorias")]
    public class Categoria : BaseModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(100, ErrorMessage ="Máximo de 100 Caracteres")]
        [MinLength(1, ErrorMessage = "Campo não pode ser vazio")]
        public string Nome { get; set; }
       
    }
}
