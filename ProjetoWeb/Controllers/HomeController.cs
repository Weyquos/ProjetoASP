using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoWeb.DAL;
using ProjetoWeb.Models;
using ProjetoWeb.Utils;

namespace ProjetoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly LivroDAO _livroDAO;
        private readonly UsuarioDAO _usuarioDAO;
        private readonly CategoriaDAO _categoriaDAO;
        private readonly ItemAlugadoDAO _itemAlugadoDAO;
        private readonly Sessao _sessao;
        public HomeController(LivroDAO livroDAO, CategoriaDAO categoriaDAO, ItemAlugadoDAO itemAlugadoDAO, UsuarioDAO usuarioDAO, Sessao sessao)
        {
            _categoriaDAO = categoriaDAO;
            _livroDAO = livroDAO;
            _itemAlugadoDAO = itemAlugadoDAO;
            _sessao = sessao;
            _usuarioDAO = usuarioDAO;
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

        public IActionResult AdicionarAoCarrinho(int id) //adicionar aos favoritos
        {
            Livro livro = _livroDAO.BuscarPorId(id);
            var email = User.Identity.Name;
            _usuarioDAO.BuscarPorEmail(email);
            ItemAlugado item = new ItemAlugado
            {
                Livro = livro
                //Usuario = 
            };
            _itemAlugadoDAO.Cadastrar(item);
            return RedirectToAction("MeusFavoritos");
        }

        //public IActionResult MeusFavoritos()
        //{
           // string carrinhoId = _sessao.BuscarCarrinhoId();
            //return View(_itemAlugadoDAO.ListarPorCarrinhoId(carrinhoId));
       // }
        /* Adicionar na função a parte de puxar os itens alugados */
        [Authorize]
        public IActionResult MeusLivros()
        {
            return View(_livroDAO.ListarLivrosLocados());
        }
        
        public IActionResult Remover(int id)
        {
            _itemAlugadoDAO.Remover(id);
            return RedirectToAction("MeusFavoritos", "Home");
        }
    }
}
