using SegundoParcialMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SegundoParcialMVC.Controllers
{
    public class LoginController : Controller
    {
        private BaseDatosEntities db = new BaseDatosEntities();

        // GET: Login
        public ActionResult Index()
        {
            HttpCookie cookie = null;
            cookie = Request.Cookies["RememberCookie"];
            if (HttpContext.Session["nombre"] != null)
            {
                return RedirectToAction("Index", "Usuarios");
            }
            if (cookie != null)
            {
                return CheckUsr(cookie["email"], cookie["clave"], false);
            }
            else
                return View();
        }

        // POST
        [HttpPost]
        public ActionResult CheckUsr(String email, String clave, bool recordarmeChk)
        {
            foreach (Usuario usr in db.Usuario.ToList())
            {
                if (usr.clave.Equals(clave) && usr.email.Equals(email) && recordarmeChk && usr.esAdmin == false)
                {
                    guardarCookie(usr.email, usr.clave, usr.nombre, false);
                    guardarSesion(usr.id, usr.email, usr.clave, usr.nombre, false);
                    return RedirectToAction("Index", "Productos");
                }
                else if (usr.clave.Equals(clave) && usr.email.Equals(email) && !recordarmeChk && usr.esAdmin == false)
                {
                    guardarSesion(usr.id, usr.email, usr.clave, usr.nombre, false);
                    return RedirectToAction("Index", "Productos");
                }
                else if (usr.clave.Equals(clave) && usr.email.Equals(email) && recordarmeChk && usr.esAdmin == true)
                {
                    guardarCookie(usr.email, usr.clave, usr.nombre, true);
                    guardarSesion(usr.id, usr.email, usr.clave, usr.nombre, true);
                    return View("IndexAdmin");
                }
                else if (usr.clave.Equals(clave) && usr.email.Equals(email) && !recordarmeChk && usr.esAdmin == true)
                {
                    guardarSesion(usr.id, usr.email, usr.clave, usr.nombre, true);
                    return View("IndexAdmin");
                }
            }

            ViewBag.error = "El usuario y/o la contraseña son incorrectos";

            return View("Index");

        }
        private void guardarCookie(String email, String clave, String nombreUsuario, bool esAdmin)
        {
            HttpCookie cookie = new HttpCookie("RememberCookie");
            cookie["nombre"] = nombreUsuario;
            cookie["email"] = email;
            cookie["clave"] = clave;
            cookie["esAdmin"] = esAdmin.ToString();
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cookie);
        }

        private void guardarSesion(int id, String email, String clave, String nombreUsuario, bool esAdmin)
        {
            HttpContext.Session.Add("id", id);
            HttpContext.Session.Add("nombre", nombreUsuario);
            HttpContext.Session.Add("email", email);
            HttpContext.Session.Add("clave", clave);
            HttpContext.Session.Add("esAdmin", esAdmin);
            HttpContext.Session.Timeout = 5;
        }

        private void eliminarCookies()
        {
            HttpCookie cookie = Request.Cookies["RememberCookie"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddSeconds(-10);
                Response.Cookies.Add(cookie);
            }
        }

        public ActionResult CerrarSesion()
        {
            HttpContext.Session.Abandon();
            eliminarCookies();
            return RedirectToAction("Index");
        }
    }
}