using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.DAL
{
    public class LivroDAO
    {
        private readonly Context _context;
        public LivroDAO(Context context) => _context = context;
        public List<Livro> Listar() => _context.Livros.Include(x => x.Categoria).ToList();
        public Livro BuscarPorId(int id) => _context.Livros.Find(id);
        public Livro BuscarPorNome(string nome) => _context.Livros.FirstOrDefault(x => x.Nome == nome);
        public List<Livro> BuscarPorCategoria(int id) => _context.Livros.Where(x => x.CategoriaId == id).ToList();
        public bool Cadastrar(Livro livro)
        {
            if(BuscarPorNome(livro.Nome) == null)
            {
                _context.Livros.Add(livro);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public void Remover(int id)
        {
            _context.Livros.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
        public void Alterar(Livro livro)
        {
            _context.Livros.Update(livro);
            _context.SaveChanges();
        }
    }
}
