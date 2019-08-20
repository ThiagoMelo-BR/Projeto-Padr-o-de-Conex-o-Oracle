using Microsoft.AspNetCore.Mvc;
using PRJ_MVC_CORE_ORACLE.Repositories;

namespace PRJ_MVC_CORE_ORACLE.Controllers
{
    public class DepartamentoController : Controller
    {
        protected readonly IDeparmentoRepository deparmentoRepository;

        public DepartamentoController(IDeparmentoRepository deparmentoRepository)
        {
            this.deparmentoRepository = deparmentoRepository;
        }

        [HttpGet]
        public JsonResult GetDepartamentos()
        {
            return Json(deparmentoRepository.GetDepartamentos());
        }

    }
}