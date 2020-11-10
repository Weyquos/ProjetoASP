using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.DAL
{
    public class CategoriaDAO
    {
        private readonly Context _context;
        public CategoriaDAO(Context context) => _context = context;

        public List<Categoria> Listar() => _context.Categorias.ToList();
        public Categoria BuscarPorId(int id) => _context.Categorias.Find(id);
        public Categoria BuscarPorNome(string nome) => _context.Categorias.FirstOrDefault(x => x.Nome == nome);
        public bool Cadastrar(Categoria categoria)
        {
            if(BuscarPorNome(categoria.Nome) == null)
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public void Remover(int id)
        {
            _context.Categorias.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
        public void Alterar(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }
    }
}
