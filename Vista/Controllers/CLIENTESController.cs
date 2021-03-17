using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vista.Models;

namespace Vista.Controllers
{
    public class CLIENTESController : Controller
    {
        private PRUEBAHCEntities db = new PRUEBAHCEntities();

        // GET: CLIENTES
        public ActionResult Index()
        {
            var cLIENTES = db.CLIENTES.Include(c => c.TIPODOCUMENTO);
            return View(cLIENTES.ToList());
        }

        // GET: CLIENTES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTES cLIENTES = db.CLIENTES.Find(id);
            if (cLIENTES == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTES);
        }

        // GET: CLIENTES/Create
        public ActionResult Create()
        {
            ViewBag.CLI_TIPO_DOCUMENTO = new SelectList(db.TIPODOCUMENTO, "TD_ID", "TD_DESCRIPCION");
            return View();
        }

        // POST: CLIENTES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CLI_ID,CLI_PRIMER_NOMBRE,CLI_SEGUNDO_NOMBRE,CLI_PRIMER_APELLIDO,CLI_SEGUNDO_APELLIDO,CLI_TIPO_DOCUMENTO,CLI_DOCUMENTO,CLI_NUMERO_MOVIL,CLI_DIRECCION,CLI_EMAIL,CLI_PRESUPUESTO,CLI_ROW_CREATE,CLI_ROW_MODIFY")] CLIENTES cLIENTES)
        {
            if (ModelState.IsValid)
            {
                db.CLIENTES.Add(cLIENTES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CLI_TIPO_DOCUMENTO = new SelectList(db.TIPODOCUMENTO, "TD_ID", "TD_DESCRIPCION", cLIENTES.CLI_TIPO_DOCUMENTO);
            return View(cLIENTES);
        }

        // GET: CLIENTES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTES cLIENTES = db.CLIENTES.Find(id);
            if (cLIENTES == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLI_TIPO_DOCUMENTO = new SelectList(db.TIPODOCUMENTO, "TD_ID", "TD_DESCRIPCION", cLIENTES.CLI_TIPO_DOCUMENTO);
            return View(cLIENTES);
        }

        // POST: CLIENTES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CLI_ID,CLI_PRIMER_NOMBRE,CLI_SEGUNDO_NOMBRE,CLI_PRIMER_APELLIDO,CLI_SEGUNDO_APELLIDO,CLI_TIPO_DOCUMENTO,CLI_DOCUMENTO,CLI_NUMERO_MOVIL,CLI_DIRECCION,CLI_EMAIL,CLI_PRESUPUESTO,CLI_ROW_CREATE,CLI_ROW_MODIFY")] CLIENTES cLIENTES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLIENTES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLI_TIPO_DOCUMENTO = new SelectList(db.TIPODOCUMENTO, "TD_ID", "TD_DESCRIPCION", cLIENTES.CLI_TIPO_DOCUMENTO);
            return View(cLIENTES);
        }

        // GET: CLIENTES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTES cLIENTES = db.CLIENTES.Find(id);
            if (cLIENTES == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTES);
        }

        // POST: CLIENTES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLIENTES cLIENTES = db.CLIENTES.Find(id);
            db.CLIENTES.Remove(cLIENTES);
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
