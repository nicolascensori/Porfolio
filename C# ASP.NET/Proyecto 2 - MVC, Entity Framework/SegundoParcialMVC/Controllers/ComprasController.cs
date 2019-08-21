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
    public class ComprasController : Controller
    {
        private BaseDatosEntities db = new BaseDatosEntities();
        [Filtros.UsuarioLogueado]
        // GET: Compras
        public ActionResult Index()
        {
            if (Session["esAdmin"].Equals(true))
            {
                return View("IndexAdmin");
            }
            else {
                List<Compra> listaFiltrada = db.Compra.ToList().FindAll(EncontrarCompra);
                return View(listaFiltrada);
            }
        }

        // GET: Compras/Details/5
        [Filtros.UsuarioLogueado]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compras/Create
        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult Create([Bind(Include = "id,nombre_usuario,nombre_producto,monto")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Compra.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compra);
        }

        // GET: Compras/Edit/5
        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult Edit([Bind(Include = "id,nombre_usuario,nombre_producto,monto")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compra);
        }

        // GET: Compras/Delete/5
        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult DeleteConfirmed(int id)
        {
            Compra compra = db.Compra.Find(id);
            db.Compra.Remove(compra);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult IndexParcial()
        {
            return View(db.Compra.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EncontrarCompra(Compra comp)
        {
            
            if (comp.nombre_usuario.Equals(Session["nombre"]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
