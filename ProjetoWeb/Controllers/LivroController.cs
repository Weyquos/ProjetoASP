using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoWeb.DAL;
using ProjetoWeb.Models;

namespace ProjetoWeb.Controllers
{
    public class LivroController : Controller
    {
        private readonly LivroDAO _livroDAO;
        private readonly IWebHostEnvironment _hosting;
        private readonly CategoriaDAO _categoriaDAO;
        public LivroController(LivroDAO livroDAO, CategoriaDAO categoriaDAO,IWebHostEnvironment hosting)
        {
            _categoriaDAO = categoriaDAO;
            _livroDAO = livroDAO;
            _hosting = hosting;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de Livros";
            return View(_livroDAO.Listar());
        }

        public IActionResult Cadastrar()
        {
            ViewBag.Categorias = new SelectList(_categoriaDAO.Listar(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Livro livro, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if(file != null)
                {
                    string arquivo = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}"; 
                    string caminho = Path.Combine(_hosting.WebRootPath, "images", arquivo);
                    file.CopyTo(new FileStream(caminho, FileMode.CreateNew));
                    livro.Imagem = arquivo;
                }
                else
                {
                    livro.Imagem = "semimagem.jpg";
                }
                livro.Categoria = _categoriaDAO.BuscarPorId(livro.CategoriaId);
                if (_livroDAO.Cadastrar(livro))
                {
                    return RedirectToAction("Index", "Livro");
                }
                ModelState.AddModelError("", "Já existe um livro cadastrado com esse nome.");              
            }
            ViewBag.Categorias = new SelectList(_categoriaDAO.Listar(), "Id", "Nome");
            return View(livro);
        }

        public IActionResult Remover(int id)
        {
            _livroDAO.Remover(id);
            return RedirectToAction("Index", "Livro");
        }

        public IActionResult Alterar(int id)
        {
            //Ver como faz para puxar a imagem antiga caso uma nova não tenha sido selecionada.
            ViewBag.Categorias = new SelectList(_categoriaDAO.Listar(), "Id", "Nome");
            return View(_livroDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Livro livro, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string arquivo = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    string caminho = Path.Combine(_hosting.WebRootPath, "images", arquivo);
                    file.CopyTo(new FileStream(caminho, FileMode.CreateNew));
                    livro.Imagem = arquivo;
                }
                {
                    _livroDAO.Alterar(livro);
                    return RedirectToAction("Index", "Livro");
                }
            }          
            return View(livro);
        }
        
    }
}
