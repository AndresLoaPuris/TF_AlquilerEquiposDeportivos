using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SI656_Alquiler_Equipos.Models;

namespace SI656_Alquiler_Equipos.Controllers
{
    public class ClientsController : Controller
    {
        private db_AlquilerEquipoEntities db = new db_AlquilerEquipoEntities();

        // GET: Clients
        public ActionResult Index()
        {
            var client = db.Client.Include(c => c.DocumentType).Include(c => c.User).Include(c => c.User1);
            return View(client.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.DocumentTypeId = new SelectList(db.DocumentType, "Id", "Name");
            ViewBag.UserCreatedId = new SelectList(db.User, "Id", "Name");
            ViewBag.UserModifiedId = new SelectList(db.User, "Id", "Name");
            return View();
        }

        // POST: Clients/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,MotherLastName,FatherLastName,Gender,DocumentNumber,DocumentTypeId,Email,Address,Age,MobileNumber,DateCreated,UserCreatedId,UserModifiedId")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Client.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DocumentTypeId = new SelectList(db.DocumentType, "Id", "Name", client.DocumentTypeId);
            ViewBag.UserCreatedId = new SelectList(db.User, "Id", "Name", client.UserCreatedId);
            ViewBag.UserModifiedId = new SelectList(db.User, "Id", "Name", client.UserModifiedId);
            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocumentTypeId = new SelectList(db.DocumentType, "Id", "Name", client.DocumentTypeId);
            ViewBag.UserCreatedId = new SelectList(db.User, "Id", "Name", client.UserCreatedId);
            ViewBag.UserModifiedId = new SelectList(db.User, "Id", "Name", client.UserModifiedId);
            return View(client);
        }

        // POST: Clients/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,MotherLastName,FatherLastName,Gender,DocumentNumber,DocumentTypeId,Email,Address,Age,MobileNumber,DateCreated,UserCreatedId,UserModifiedId")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocumentTypeId = new SelectList(db.DocumentType, "Id", "Name", client.DocumentTypeId);
            ViewBag.UserCreatedId = new SelectList(db.User, "Id", "Name", client.UserCreatedId);
            ViewBag.UserModifiedId = new SelectList(db.User, "Id", "Name", client.UserModifiedId);
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Client.Find(id);
            db.Client.Remove(client);
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
