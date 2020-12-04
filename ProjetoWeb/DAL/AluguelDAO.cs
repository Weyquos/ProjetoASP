using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.DAL
{
    public class AluguelDAO
    {
        private readonly Context _context;
        public AluguelDAO(Context context) => _context = context;
        public List<Aluguel> ListarLivrosLocados(string usuarioEmail) => _context.Alugueis.Include(x => x.Livro.Categoria).Where(x => x.Usuario.Email == usuarioEmail).Where(x => x.Livro.Status.Equals("Locado")).ToList();

        public bool Alugar(int id, Livro livro, Usuario usuario)
        {
            {
                if (livro.Status == "Disponível")
                {
                    livro.Status = "Locado";
                    Aluguel aluguel = new Aluguel
                    {
                        Livro = livro,
                        Usuario = usuario
                    };
                    _context.Alugueis.Add(aluguel);
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

        public bool Devolver(int id, Livro livro, Usuario usuario)
        {

            {
                if (livro.Status == "Locado")
                {
                    livro.Status = "Disponível";
                    Aluguel aluguel = new Aluguel
                    {
                        Livro = livro,
                        Usuario = usuario
                    };
                    _context.Alugueis.Add(aluguel);
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
