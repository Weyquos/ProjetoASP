using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Models
{
    [Table("Alugueis")]
    public class Aluguel : BaseModel
    {
        public Aluguel()
        {
            Usuario = new Usuario();
            Livro = new Livro();
        }
        public Usuario Usuario { get; set; }
        public Livro Livro { get; set; }
    }
}
