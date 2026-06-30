using SisTransp.Aplicacion.Servicios;
using SisTransp.Dominio.Entidades;
using System.Linq;
using System.Web.Mvc;

namespace SisTransp.Presentacion.Controllers
{
    public class CombustibleController : Controller
    {
        CombustibleServicio _combustibleServicio = new CombustibleServicio();

        ViajeServicio _viajeServicio = new ViajeServicio();

        public ActionResult Index()
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (Session["Rol"].ToString() != "Administrador" &&
                Session["Rol"].ToString() != "Combustible")
            {
                TempData["ErrorPermiso"] = "No tienes permiso para acceder a este módulo.";
                return RedirectToAction("Index", "Dashboard");
            }

            var lista = _combustibleServicio.Listar();

            return View(lista);
        }

        public ActionResult Create()
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var viajes = _viajeServicio.Listar().
                Where(x => x.Estado == "Programado" || x.Estado == "En Ruta")
                .ToList();
            ViewBag.Viajes = new SelectList(
                    viajes,
                    "IdViaje",
                    "Descripcion");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Combustible combustible)
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            _combustibleServicio.Registrar(combustible);

            return RedirectToAction("Index");
        }
    }
}