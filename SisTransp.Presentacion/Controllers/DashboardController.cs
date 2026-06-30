using SisTransp.Aplicacion.Servicios;
using System.Web.Mvc;

namespace SisTransp.Presentacion.Controllers
{
    public class DashboardController : Controller
    {
        ChoferServicio choferServicio = new ChoferServicio();
        UnidadServicio unidadServicio = new UnidadServicio();
        RutaServicio rutaServicio = new RutaServicio();
        ViajeServicio viajeServicio = new ViajeServicio();
        CombustibleServicio combustibleServicio = new CombustibleServicio();
        CajaServicio cajaServicio = new CajaServicio();

        public ActionResult Index()
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.TotalChoferes = choferServicio.Listar().Count;
            ViewBag.TotalUnidades = unidadServicio.Listar().Count;
            ViewBag.TotalRutas = rutaServicio.Listar().Count;
            ViewBag.TotalViajes = viajeServicio.Listar().Count;
            ViewBag.TotalCombustible = combustibleServicio.Listar().Count;
            ViewBag.TotalCaja = cajaServicio.Listar().Count;

            return View();
        }
    }
}