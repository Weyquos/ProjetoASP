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

        public List<Livro> Listar() => _context.Livros.ToList();
        public Livro BuscarPorId(int id) => _context.Livros.Find(id);
        public Livro BuscarPorNome(string nome) => _context.Livros.FirstOrDefault(x => x.Nome == nome);
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
