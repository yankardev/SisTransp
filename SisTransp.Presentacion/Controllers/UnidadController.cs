using SisTransp.Aplicacion.Servicios;
using SisTransp.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace SisTransp.Presentacion.Controllers
{
    public class UnidadController : Controller
    {
        UnidadServicio _unidadServicio = new UnidadServicio();
        public ActionResult Index()
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var lista = _unidadServicio.Listar();

            return View(lista);
        }

        public ActionResult Details(int id)
        {
            var unidad = _unidadServicio.Obtener(id);
            return View(unidad);
        }

        public ActionResult Create()
        {
            ViewBag.Marcas = new List<string>
            {
                "Volvo",
                "Scania",
                "Mercedes",
                "Freightliner",
                "International"
            };
            ViewBag.Modelos = new List<string>
            {
                "FH540",
                "FH460",
                "R500",
                "G410",
                "Actros",
                "Cascadia",
                "LT625"
            };
            return View();
        }
        [HttpPost]
        public ActionResult Create(Unidad unidad)
        {
            if (!ModelState.IsValid)
            {
                return View(unidad);
            }
            _unidadServicio.Registrar(unidad);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Marcas = new List<string>
            {
                "Volvo",
                "Scania",
                "Mercedes",
                "Freightliner",
                "International"
            };
            ViewBag.Modelos = new List<string>
            {
                "FH540",
                "FH460",
                "R500",
                "G410",
                "Actros",
                "Cascadia",
                "LT625"
            };
            var unidad = _unidadServicio.Obtener(id);
            return View(unidad);
        }

        [HttpPost]
        public ActionResult Edit(Unidad unidad)
        {
            if (!ModelState.IsValid)
            {
                return View(unidad);
            }
            _unidadServicio.Editar(unidad);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _unidadServicio.Eliminar(id);
            return RedirectToAction("Index");
        }

        public ActionResult CambiarEstado(int id,string estado)
        {
            _unidadServicio.CambiarEstado(id,estado);
            return RedirectToAction("Index");
        }
    }
}