using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Models
{
    [Table("ItensAlugados")]
    public class ItemAlugado : BaseModel
    {     
        public ItemAlugado()
        {
            Livro = new Livro();
        }
        public Livro Livro { get; set; }
        public int Quantidade { get; set; }
        public string CarrinhoId { get; set; }
    }
}
