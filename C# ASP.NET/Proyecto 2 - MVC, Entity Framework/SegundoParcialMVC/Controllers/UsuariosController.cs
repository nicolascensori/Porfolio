using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SegundoParcialMVC.Models;

namespace SegundoParcialMVC.Controllers
{
    public class UsuariosController : Controller
    {
        private BaseDatosEntities db = new BaseDatosEntities();

        // GET: Usuarios
        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult Index()
        {
            if (Session["esAdmin"].Equals(true))
            {
                return View("IndexAdmin");
            }
            return View(db.Usuario.ToList());
        }

        // GET: Usuarios/Details/5
        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/RegistrarUsuario
        public ActionResult RegistrarUsuario()
        {
            return View();
        }


        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        public ActionResult RegistrarUsuario([Bind(Include = "nombre,email,clave")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                foreach (Usuario usr in db.Usuario.ToList())
                {
                    if (usuario.nombre.Equals(usr.nombre))
                        ViewBag.nombreExiste = "El nombre de usuario ya esta en uso";
                    if (usuario.email.Equals(usr.email))
                        ViewBag.emailExiste = "El email ya esta en uso";
                }

                if (ViewBag.nombreExiste == null && ViewBag.emailExiste == null)
                {
                    usuario.esAdmin = false;
                    db.Usuario.Add(usuario);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login");
                }
                else
                    return View();
            }
            return View();
        }

        // GET: Usuarios/Edit/5
        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult Edit([Bind(Include = "id,nombre,email,clave,esAdmin")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        [Filtros.UsuarioAdmin]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult IndexParcial()
        {
            return View(db.Usuario.ToList());
        }

    }
}
