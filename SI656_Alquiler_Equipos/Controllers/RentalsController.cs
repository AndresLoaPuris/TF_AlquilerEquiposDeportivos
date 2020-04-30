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
    [Authorize]
    public class RentalsController : Controller
    {
        private db_AlquilerEquipoEntities db = new db_AlquilerEquipoEntities();

        // GET: Rentals
        public ActionResult Index()
        {
            var rental = db.Rental.Include(r => r.Client).Include(r => r.RentalState).Include(r => r.User);
            return View(rental.ToList());
        }

        // GET: Rentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rental.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // GET: Rentals/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name");
            ViewBag.RentalStateId = new SelectList(db.RentalState, "Id", "Name");
            ViewBag.UserId = new SelectList(db.User, "Id", "Name");
            return View();
        }

        // POST: Rentals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateCreated,TotalPrice,OrderDate,ClientId,UserId,RentalStateId")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                db.Rental.Add(rental);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name", rental.ClientId);
            ViewBag.RentalStateId = new SelectList(db.RentalState, "Id", "Name", rental.RentalStateId);
            ViewBag.UserId = new SelectList(db.User, "Id", "Name", rental.UserId);
            return View(rental);
        }

        // GET: Rentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rental.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name", rental.ClientId);
            ViewBag.RentalStateId = new SelectList(db.RentalState, "Id", "Name", rental.RentalStateId);
            ViewBag.UserId = new SelectList(db.User, "Id", "Name", rental.UserId);
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateCreated,TotalPrice,OrderDate,ClientId,UserId,RentalStateId")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rental).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Client, "Id", "Name", rental.ClientId);
            ViewBag.RentalStateId = new SelectList(db.RentalState, "Id", "Name", rental.RentalStateId);
            ViewBag.UserId = new SelectList(db.User, "Id", "Name", rental.UserId);
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rental.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rental rental = db.Rental.Find(id);
            db.Rental.Remove(rental);
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
