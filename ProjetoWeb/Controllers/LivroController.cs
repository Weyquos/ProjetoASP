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
            return View(_livroDAO.Listar());
        }
        
        public IActionResult Cadastrar() => View();

        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            if (ModelState.IsValid)
            {
                if (_livroDAO.Cadastrar(livro))
                {
                    return RedirectToAction("Index", "Livro");
                }
                ModelState.AddModelError("", "Já existe um livro cadastrado com esse nome.");              
            }
            return View(livro);
        }

        public IActionResult Remover(int id)
        {
            _livroDAO.Remover(id);
            return RedirectToAction("Index", "Livro");
        }

        public IActionResult Alterar(int id)
        {     
            return View(_livroDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Livro livro)
        {
            if (ModelState.IsValid)
            {
                _livroDAO.Alterar(livro);
                return RedirectToAction("Index", "Livro");
            }
            return View(livro);
        }
        
    }
}
