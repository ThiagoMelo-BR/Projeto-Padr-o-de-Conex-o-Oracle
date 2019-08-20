using Microsoft.AspNetCore.Mvc;
using PRJ_MVC_CORE_ORACLE.Repositories;

namespace PRJ_MVC_CORE_ORACLE.Controllers
{
    public class SecaoController : Controller
    {
        protected readonly ISecaoRepository secaoRepository;

        public SecaoController(ISecaoRepository secaoRepository)
        {
            this.secaoRepository = secaoRepository;
        }

        public JsonResult GetSecoes()
        {
            return Json(secaoRepository.GetSecoes());
        }
    }
}