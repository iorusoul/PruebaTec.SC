using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.SoyCalidad.Application;
using PruebaTecnica.SoyCalidad.Domain;
namespace PruebaTecnica.SoyCalidad.Controllers
{
    public class AsignaturasController : Controller
    {
        private readonly IAsignaturasService _asignaturaService;
        public AsignaturasController(IAsignaturasService asignaturaService)
        {
            _asignaturaService = asignaturaService;
        }
        // GET: AsignaturasController
        public async ValueTask<ActionResult> Index(int page = 1)
        {
            var conteo = await _asignaturaService.ContarRegistrosDeAsignaturaPorIdPrograma(1);
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(conteo / (double)5);
            ViewBag.TotalRegs = conteo;
            var asignaturas = await _asignaturaService.ObtenerAsignaturasPorProgramaIdPaginado(1,page);//lemandamos id de programa y pagina 1
            return View(asignaturas);
        }
        //refresca el listado con una parte del paginado...
        public async ValueTask<IActionResult> RefrescarTabla(int page)
        {
            if (page <= 0)
                page = 1;

            var asignaturas = await _asignaturaService.ObtenerAsignaturasPorProgramaIdPaginado(1, page);//lemandamos id de programa y pagina 1
            return PartialView("_TablaAsignaturas", asignaturas);
        }

    }
}
