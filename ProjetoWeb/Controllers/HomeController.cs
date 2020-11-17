using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoWeb.DAL;

namespace ProjetoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly LivroDAO _livroDAO;
        private readonly CategoriaDAO _categoriaDAO;
        public HomeController(LivroDAO livroDAO, CategoriaDAO categoriaDAO)
        {
            _categoriaDAO = categoriaDAO;
            _livroDAO = livroDAO;
        }
        public IActionResult Index(int id)
        {
            ViewBag.Categorias = _categoriaDAO.Listar();
            if (id == 0)
            {
                return View(_livroDAO.Listar());
            }
            return View(_livroDAO.ListarPorCategoria(id));
        }
    }
}
