using SisTransp.Aplicacion.Servicios;
using SisTransp.Dominio.Entidades;
using System.Web.Mvc;

namespace SisTransp.Presentacion.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioServicio _usuarioServicio = new UsuarioServicio();

        public ActionResult Index()
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (Session["Rol"].ToString() != "Administrador")
            {
                TempData["ErrorPermiso"] = "No tienes permiso para acceder al módulo Usuarios.";
                return RedirectToAction("Index", "Dashboard");
            }

            var lista = _usuarioServicio.Listar();

            return View(lista);
        }

        public ActionResult Create()
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (Session["Rol"].ToString() != "Administrador")
            {
                TempData["ErrorPermiso"] = "No tienes permiso para crear usuarios.";
                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.Roles = new SelectList(
                _usuarioServicio.ListarRoles(),
                "IdRol",
                "Nombre"
            );

            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (Session["Rol"].ToString() != "Administrador")
            {
                TempData["ErrorPermiso"] = "No tienes permiso para crear usuarios.";
                return RedirectToAction("Index", "Dashboard");
            }

            _usuarioServicio.Registrar(usuario);

            TempData["Mensaje"] = "Usuario registrado correctamente.";

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (Session["Rol"].ToString() != "Administrador")
            {
                TempData["ErrorPermiso"] = "No tienes permiso para editar usuarios.";
                return RedirectToAction("Index", "Dashboard");
            }

            var usuario = _usuarioServicio.Obtener(id);

            ViewBag.Roles = new SelectList(
                _usuarioServicio.ListarRoles(),
                "IdRol",
                "Nombre",
                usuario.IdRol
            );

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            if (Session["IdUsuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (Session["Rol"].ToString() != "Administrador")
            {
                TempData["ErrorPermiso"] = "No tienes permiso para editar usuarios.";
                return RedirectToAction("Index", "Dashboard");
            }

            _usuarioServicio.Editar(usuario);

            TempData["Mensaje"] = "Usuario actualizado correctamente.";

            return RedirectToAction("Index");
        }
    }
}