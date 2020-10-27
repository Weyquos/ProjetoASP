using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoWeb.DAL;
using ProjetoWeb.Models;

namespace ProjetoWeb.Controllers
{
    public class LivroController : Controller
    {
        private readonly LivroDAO _livroDAO;
        public LivroController(LivroDAO livroDAO) => _livroDAO = livroDAO;

        public IActionResult Index()
        {
            ViewBag.Livros = _livroDAO.Listar();
            return View();
        }
        
        public IActionResult Cadastrar() => View();

        [HttpPost]
        public IActionResult Cadastrar(string Nome, string Autor, string Editora, int NumPag, int Quantidade, int AnoPub)
        {
            Livro livro = new Livro 
            {
                Nome = Nome,
                Autor = Autor,
                Editora = Editora,
                NumPag = NumPag,
                Quantidade = Quantidade,
                AnoPub = AnoPub
            };

            _livroDAO.Cadastrar(livro);

            return RedirectToAction("Index", "Livro");
        }

        public IActionResult Remover(int id)
        {
            _livroDAO.Remover(id);
            return RedirectToAction("Index", "Livro");
        }

        public IActionResult Alterar(int id)
        {
            ViewBag.Livro = _livroDAO.BuscarPorId(id);
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(int Id, string Nome, string Autor, string Editora, int NumPag, int Quantidade, int AnoPub)
        {
            Livro livro = _livroDAO.BuscarPorId(Id);
            livro.Nome = Nome;
            livro.Autor = Autor;
            livro.Editora = Editora;
            livro.NumPag = NumPag;
            livro.Quantidade = Quantidade;

            _livroDAO.Alterar(livro);

            return RedirectToAction("Index", "Livro");
        }
        
    }
}
