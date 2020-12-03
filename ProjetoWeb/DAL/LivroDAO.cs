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
        public List<Livro> ListarPorCategoria(int id) => _context.Livros.Where(x => x.CategoriaId == id).ToList();

        public List<Livro> ListarLivrosLocados() => _context.Livros.Include(x => x.Categoria).Where(x => x.Status.Equals("Locado")).ToList();
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

        public bool Alugar(int id, Livro livro)
        {

            {
                if (livro.Status == "Disponível")
                {
                    livro.Status = "Locado";
                    _context.Livros.Update(livro);
                    _context.SaveChanges();
                    return true;
                }

                if (livro.Status == "Locado")
                {
                    return false;
                }
            }
            return false;
        }

        public bool Devolver(int id, Livro livro)
        {

            {
                if (livro.Status == "Locado")
                {
                    livro.Status = "Disponível";
                    _context.Livros.Update(livro);
                    _context.SaveChanges();
                    return true;
                }

                if (livro.Status == "Disponível")
                {
                    return false;
                }
            }
            return false;
        }
    }
}
