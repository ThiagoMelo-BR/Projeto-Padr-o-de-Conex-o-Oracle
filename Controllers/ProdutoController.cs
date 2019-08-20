using System.Collections.Generic;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using PRJ_MVC_CORE_ORACLE.Models;
using PRJ_MVC_CORE_ORACLE.Repositories;

namespace PRJ_MVC_CORE_ORACLE.Controllers
{
    public class ProdutoController : Controller
    {
        protected readonly IProdutoRepository produtoRepository;
        protected readonly IDeparmentoRepository deparmentoRepository;
        protected readonly ISecaoRepository secaoRepository;
        protected readonly IFornecedorRepository fornecedorRepository;

        IList<Departamento> departamentos;
        IList<Secao> secoes;
        IList<Fornecedor> fornecedores;

        public void CarregarDepartamentos()
        {
            departamentos = deparmentoRepository.GetDepartamentos();
            ViewBag.departamentos = departamentos;
        }

        public void CarregarFornecedores()
        {
            fornecedores = fornecedorRepository.GetFornecedores();
            ViewBag.fornecedores = fornecedores;
        }

        public void CarregarAuxiliares()
        {
            CarregarDepartamentos();
            CarregarSecoes();
            CarregarFornecedores();
        }

        public void CarregarSecoes()
        {
            secoes = secaoRepository.GetSecoes();
            ViewBag.secoes = secoes;
        }

        public ProdutoController(IProdutoRepository produtoRepository,
            IDeparmentoRepository deparmentoRepository,
            ISecaoRepository secaoRepository,
            IFornecedorRepository fornecedorRepository)
        {
            this.produtoRepository = produtoRepository;
            this.deparmentoRepository = deparmentoRepository;
            this.secaoRepository = secaoRepository;
            this.fornecedorRepository = fornecedorRepository;
        }

        
        public IActionResult Index()
        {
            return View(produtoRepository.GetProdutos());
        }

        public IActionResult Editar(int id)
        {
            CarregarAuxiliares();
            var produto = produtoRepository.GetProduto(id);
            return View("Cadastrar", produto);
        }

        public IActionResult Cadastrar(Produto produto)
        {
            CarregarAuxiliares();
            produto = new Produto();         
            return View(produto);
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            var p = produtoRepository.GetProduto(id);
            produtoRepository.Excluir(p);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AtualizarProduto([FromForm] Produto produto)
        {          
            produtoRepository.Atualizar(produto);
            return RedirectToAction("Index");
        }
               
        [HttpGet]
        public JsonResult GetProdutos()
        {
            return Json(produtoRepository.GetProdutos());
        }

        [HttpPost]        
        public IActionResult CadastrarProduto([FromBody] Produto Produto)
        {
            produtoRepository.Atualizar(Produto);
            return Ok(new { retorno = "Dados gravados com sucesso!"});
        }

        [HttpPost]
        public IActionResult ExcluirProduto(int id)
        {
            var p = produtoRepository.GetProduto(id);
            produtoRepository.Excluir(p);
            return Ok(new { retorno = "Produto excluído com sucesso!" });
        }
    }
}