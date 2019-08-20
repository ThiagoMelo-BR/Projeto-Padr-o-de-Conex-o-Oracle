using Microsoft.AspNetCore.Mvc;
using PRJ_MVC_CORE_ORACLE.Repositories;

namespace PRJ_MVC_CORE_ORACLE.Controllers
{
    public class FornecedorController : Controller
    {
        protected readonly IFornecedorRepository fornecedorRepository;

        public FornecedorController(IFornecedorRepository forncedorRepository)
        {
            this.fornecedorRepository = forncedorRepository;
        }

        public JsonResult GetFornecedores()
        {
            return Json(fornecedorRepository.GetFornecedores());
        }
    }
}