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
        private readonly AluguelDAO _aluguelDAO;
        private readonly UsuarioDAO _usuarioDAO;
        private readonly CategoriaDAO _categoriaDAO;
        private readonly ItemAlugadoDAO _itemAlugadoDAO;
        private readonly Sessao _sessao;
        public HomeController(LivroDAO livroDAO, CategoriaDAO categoriaDAO, ItemAlugadoDAO itemAlugadoDAO, UsuarioDAO usuarioDAO, Sessao sessao, AluguelDAO aluguelDAO)
        {
            _categoriaDAO = categoriaDAO;
            _livroDAO = livroDAO;
            _itemAlugadoDAO = itemAlugadoDAO;
            _sessao = sessao;
            _usuarioDAO = usuarioDAO;
            _aluguelDAO = aluguelDAO;
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
            string email = User.Identity.Name;
            Usuario usuario = _usuarioDAO.BuscarPorEmail(email);
            _usuarioDAO.BuscarPorEmail(email);
            ItemAlugado item = new ItemAlugado
            {
                Livro = livro,
                Usuario = usuario
            };
            _itemAlugadoDAO.Cadastrar(item);
            return RedirectToAction("MeusFavoritos");
        }

        public IActionResult MeusFavoritos()
        {
            string email = User.Identity.Name;
            _usuarioDAO.BuscarPorEmail(email);
            return View(_itemAlugadoDAO.ListarPorCarrinhoId(email));
        }

        public IActionResult Alugar(int id) 
        {
            Livro livro = _livroDAO.BuscarPorId(id);
            string email = User.Identity.Name;
            Usuario usuario = _usuarioDAO.BuscarPorEmail(email);
            _usuarioDAO.BuscarPorEmail(email);
            Aluguel aluguel = new Aluguel
            {
                Livro = livro,
                Usuario = usuario
            };
            _aluguelDAO.Alugar(id,livro, usuario);
            return RedirectToAction("MeusLivros");
        }

        [Authorize]
        public IActionResult MeusLivros()
        {
            string email = User.Identity.Name;
            _usuarioDAO.BuscarPorEmail(email);
            return View(_aluguelDAO.ListarLivrosLocados(email));
        }
        
        public IActionResult Remover(int id)
        {
            _itemAlugadoDAO.Remover(id);
            return RedirectToAction("MeusFavoritos", "Home");
        }

        /*public IActionResult Alugar(int id)
        {
            Livro livro = _livroDAO.BuscarPorId(id);
            _livroDAO.Alugar(id, livro);
            return RedirectToAction("Index", "Livro");
        }*/

        public IActionResult Devolver(int id)
        {
            Livro livro = _livroDAO.BuscarPorId(id);
            string email = User.Identity.Name;
            Usuario usuario = _usuarioDAO.BuscarPorEmail(email);
            _usuarioDAO.BuscarPorEmail(email);
            Aluguel aluguel = new Aluguel
            {
                Livro = livro,
                Usuario = usuario
            };
            _aluguelDAO.Devolver(id, livro, usuario);
            return RedirectToAction("MeusLivros");
        }
    }
}
