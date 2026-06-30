using SisTransp.Aplicacion.Servicios;
using SisTransp.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SisTransp.Presentacion.Controllers
{
    public class ChoferController : Controller
    {
        ChoferServicio servicio = new ChoferServicio();

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
            var chofer = servicio.Obtener(id);
            return View(chofer);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Chofer chofer)
        {
            if (ModelState.IsValid)
            {
                servicio.Registrar(chofer);
                return RedirectToAction("Index");
            }
            return View(chofer);
        }
        public ActionResult Edit(int id)
        {
            var chofer = servicio.Obtener(id);
            return View(chofer);
        }
        [HttpPost]
        public ActionResult Edit(Chofer chofer)
        {
            if (ModelState.IsValid)
            {
                servicio.Editar(chofer);
                return RedirectToAction("Index");
            }
            return View(chofer);
        }
        public ActionResult Delete(int id)
        {
            servicio.Eliminar(id);

            return RedirectToAction("Index");
        }

    }
}