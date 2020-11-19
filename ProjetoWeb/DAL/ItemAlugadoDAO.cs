using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.DAL
{
    public class ItemAlugadoDAO
    {
        private readonly Context _context;
        public ItemAlugadoDAO(Context context) => _context = context;
        public List<ItemAlugado> ListarPorCarrinhoId(string id) => _context.ItensAlugados.Include(x => x.Livro.Categoria).Where(x => x.CarrinhoId == id).ToList();
        public ItemAlugado BuscarPorId(int id) => _context.ItensAlugados.Find(id);
        public void Cadastrar(ItemAlugado item)
        {
            _context.ItensAlugados.Add(item);
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            _context.ItensAlugados.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
    }
}
