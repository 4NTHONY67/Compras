using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Compras.Models;

namespace Compras.Controllers
{
    public class ComprasClientesController : Controller
    {
        private clientesEntities db = new clientesEntities();

        // GET: ComprasClientes
        public ActionResult Index()
        {
            return View(db.ComprasCliente.ToList());
        }

        // GET: ComprasClientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComprasCliente comprasCliente = db.ComprasCliente.Find(id);
            if (comprasCliente == null)
            {
                return HttpNotFound();
            }
            return View(comprasCliente);
        }

        // GET: ComprasClientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComprasClientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompraId,ClienteId,NumeroCompras")] ComprasCliente comprasCliente)
        {
            if (ModelState.IsValid)
            {
                db.ComprasCliente.Add(comprasCliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comprasCliente);
        }

        // GET: ComprasClientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComprasCliente comprasCliente = db.ComprasCliente.Find(id);
            if (comprasCliente == null)
            {
                return HttpNotFound();
            }
            return View(comprasCliente);
        }

        // POST: ComprasClientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompraId,ClienteId,NumeroCompras")] ComprasCliente comprasCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comprasCliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comprasCliente);
        }

        // GET: ComprasClientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComprasCliente comprasCliente = db.ComprasCliente.Find(id);
            if (comprasCliente == null)
            {
                return HttpNotFound();
            }
            return View(comprasCliente);
        }

        // POST: ComprasClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComprasCliente comprasCliente = db.ComprasCliente.Find(id);
            db.ComprasCliente.Remove(comprasCliente);
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
    }
}
