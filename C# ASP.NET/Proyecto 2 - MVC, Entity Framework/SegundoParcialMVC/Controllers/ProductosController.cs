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
    public class ProductosController : Controller
    {
        private BaseDatosEntities db = new BaseDatosEntities();

        // GET: Productos
        [Filtros.UsuarioLogueado]
        public ActionResult Index()
        {
            if (Session["esAdmin"].Equals(true))
            {
                return View("IndexAdmin");
            }
            else
            {
                return View(db.Producto.ToList());
            }
        }
        [Filtros.UsuarioLogueado]
        public ActionResult Comprar(int id, int cantidad)
        {
            Compra compra = new Compra();
            Producto producto = db.Producto.Find(id);
            producto.cantidad-=cantidad;
            compra.nombre_producto = producto.nombre;
            compra.nombre_usuario = Session["nombre"].ToString();
            compra.monto = producto.precio*cantidad;
            db.Compra.Add(compra);
            db.Entry(compra).State = EntityState.Added;
            db.Entry(producto).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Productos/Details/5
        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productos/Create
        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult Create([Bind(Include = "id,nombre,color,precio,cantidad")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producto);
        }

        // GET: Productos/Edit/5
        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult Edit([Bind(Include = "id,nombre,color,precio,cantidad")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        // GET: Productos/Delete/5
        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Filtros.UsuarioLogueado]
        [Filtros.UsuarioAdmin]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
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
            return View(db.Producto.ToList());
        }

        [Filtros.UsuarioLogueado]
        public ActionResult DetailsComun(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }
    }
}
