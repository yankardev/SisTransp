using SisTransp.Aplicacion.Servicios;
using SisTransp.Dominio.Entidades;
using System.Web.Mvc;

namespace SisTransp.Presentacion.Controllers
{
    public class ViajeController : Controller
    {
        ViajeServicio _viajeServicio = new ViajeServicio();

        ChoferServicio _choferServicio = new ChoferServicio();

        UnidadServicio _unidadServicio = new UnidadServicio();

        RutaServicio _rutaServicio = new RutaServicio();


        public ActionResult Index()
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var lista = _viajeServicio.Listar();

            return View(lista);
        }


        public ActionResult Create()
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.Choferes =
                new SelectList(
                    _choferServicio.Listar(),
                    "IdChofer",
                    "NombreCompleto");

            ViewBag.Unidades =
                new SelectList(
                    _unidadServicio.Listar(),
                    "IdUnidad",
                    "Placa");

            ViewBag.Rutas =
                new SelectList(
                    _rutaServicio.Listar(),
                    "IdRuta",
                    "Destino");

            return View();
        }


        [HttpPost]
        public ActionResult Create(Viaje viaje)
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            _viajeServicio.Registrar(viaje);

            return RedirectToAction("Index");
        }


        public ActionResult CambiarEstado(int id, string estado)
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            _viajeServicio.CambiarEstado(id, estado);

            return RedirectToAction("Index");
        }
    }
}