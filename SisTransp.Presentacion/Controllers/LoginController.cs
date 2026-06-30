using SisTransp.Aplicacion.Servicios;
using System.Web.Mvc;

namespace SisTransp.Presentacion.Controllers
{
    public class LoginController : Controller
    {
        UsuarioServicio servicio = new UsuarioServicio();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string correo, string clave)
        {
            var usuario = servicio.Login(correo, clave);

            if (usuario != null)
            {
                Session["IdUsuario"] = usuario.IdUsuario;
                Session["NombreUsuario"] = usuario.NombreCompleto;
                Session["Rol"] = usuario.Rol;

                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.Error = "Correo o clave incorrectos";
            return View();
        }

        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}