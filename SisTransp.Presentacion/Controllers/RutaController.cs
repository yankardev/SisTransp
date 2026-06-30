using SisTransp.Aplicacion.Servicios;
using SisTransp.Dominio.Entidades;
using System.Web.Mvc;

namespace SisTransp.Presentacion.Controllers
{
    public class RutaController : Controller
    {
        RutaServicio servicio = new RutaServicio();

        public ActionResult Index()
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var lista = servicio.Listar();

            return View(lista);
        }

        public ActionResult Details(int id)
        {
            var ruta = servicio.Obtener(id);
            return View(ruta);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Ruta ruta)
        {
            servicio.Registrar(ruta);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var ruta = servicio.Obtener(id);
            return View(ruta);
        }

        [HttpPost]
        public ActionResult Edit(Ruta ruta)
        {
            servicio.Editar(ruta);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            servicio.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}