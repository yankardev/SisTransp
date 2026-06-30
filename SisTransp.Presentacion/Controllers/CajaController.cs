using SisTransp.Aplicacion.Servicios;
using SisTransp.Dominio.Entidades;
using System.Linq;
using System.Web.Mvc;

namespace SisTransp.Presentacion.Controllers
{
    public class CajaController : Controller
    {
        CajaServicio _cajaServicio = new CajaServicio();

        ViajeServicio _viajeServicio = new ViajeServicio();

        public ActionResult Index()
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var lista = _cajaServicio.Listar();

            return View(lista);
        }

        public ActionResult Create()
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var viajes = _viajeServicio.Listar()
                .Where(x => x.Estado == "Programado" || x.Estado == "En Ruta")
                .ToList();

            ViewBag.Viajes =
                new SelectList(
                    viajes,
                    "IdViaje",
                    "Descripcion");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Caja caja)
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            _cajaServicio.Registrar(caja);

            return RedirectToAction("Index");
        }
    }
}