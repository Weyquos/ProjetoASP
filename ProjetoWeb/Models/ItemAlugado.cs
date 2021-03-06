﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Models
{
    [Table("ItensAlugados")] //Itens favoritos
    public class ItemAlugado : BaseModel
    {     
        public ItemAlugado()
        {
            Usuario = new Usuario();
            Livro = new Livro();
        }
        public Usuario Usuario { get; set; }
        public Livro Livro { get; set; }
    }
}
