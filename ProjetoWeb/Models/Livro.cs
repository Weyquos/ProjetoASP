using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Models
{
    [Table("Livros")]
    public class Livro : BaseModel
    {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public int Quantidade { get; set; }
        public int NumPag { get; set; }
        public int AnoPub { get; set; }
    }
}
