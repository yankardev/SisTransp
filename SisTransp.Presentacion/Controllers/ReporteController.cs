using SisTransp.Aplicacion.Servicios;
using System.Web.Mvc;

namespace SisTransp.Presentacion.Controllers
{
    public class ReporteController : Controller
    {
        ViajeServicio _viajeServicio = new ViajeServicio();

        public ActionResult Index()
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var lista = _viajeServicio.Listar();

            return View(lista);
        }
    }
}