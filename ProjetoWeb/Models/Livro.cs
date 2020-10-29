using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Models
{
    [Table("Livros")]
    public class Livro : BaseModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(100, ErrorMessage ="Máximo de 100 Caracteres")]
        [MinLength(1, ErrorMessage = "Campo não pode ser vazio")]
        public string Nome { get; set; }
       
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 Caracteres")]
        [MinLength(1, ErrorMessage = "Campo não pode ser vazio")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 Caracteres")]
        [MinLength(1, ErrorMessage = "Campo não pode ser vazio")]
        public string Editora { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(1,10000, ErrorMessage ="Quantia de Livros iguais limitada entre 1 e 10000")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(1, 10000, ErrorMessage = "Quantia de páginas limitada entre 1 e 10000")]
        public int NumPag { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(1, 3000, ErrorMessage = "Ano de Publicação inválido")]
        public int AnoPub { get; set; }
    }
}
