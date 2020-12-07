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
        public List<ItemAlugado> ListarPorCarrinhoId(string usuarioEmail) => _context.ItensAlugados.Include(x => x.Livro.Categoria).Where(x => x.Usuario.Email == usuarioEmail).ToList();
        public ItemAlugado BuscarPorId(int id) => _context.ItensAlugados.Find(id);

        /*
        public List<ItemAlugado> ProcurarPorId(int id) => _context.ItensAlugados.Where(x => x.Livro.Id == id).ToList();
        public ItemAlugado ProcurarPorId(int id) => _context.ItensAlugados.FirstOrDefault(x => x.Livro.Id == id);
        public bool ValidarAdd(int id)
        {
            if(ProcurarPorId(id) == null)
            {
                return true;
            }
            return false;
        }
        
        public void Cadastrar(ItemAlugado item)
        {
            if (ProcurarPorId(item.Livro.Id) == null)
            {
                _context.ItensAlugados.Add(item);
                _context.SaveChanges();
            }
        }
         */

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
