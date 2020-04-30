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
    public class RentalDetailsController : Controller
    {
        private db_AlquilerEquipoEntities db = new db_AlquilerEquipoEntities();

        // GET: RentalDetails
        public ActionResult Index()
        {
            var rentalDetail = db.RentalDetail.Include(r => r.Equipment).Include(r => r.Rental);
            return View(rentalDetail.ToList());
        }

        // GET: RentalDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalDetail rentalDetail = db.RentalDetail.Find(id);
            if (rentalDetail == null)
            {
                return HttpNotFound();
            }
            return View(rentalDetail);
        }

        // GET: RentalDetails/Create
        public ActionResult Create()
        {
            ViewBag.EquipmentId = new SelectList(db.Equipment, "Id", "Code");
            ViewBag.RentalId = new SelectList(db.Rental, "Id", "Id");
            return View();
        }

        // POST: RentalDetails/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubTotal,EquipmentId,RentalId,StartDate,ExpirationDate,Quantity")] RentalDetail rentalDetail)
        {
            if (ModelState.IsValid)
            {
                db.RentalDetail.Add(rentalDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquipmentId = new SelectList(db.Equipment, "Id", "Code", rentalDetail.EquipmentId);
            ViewBag.RentalId = new SelectList(db.Rental, "Id", "Id", rentalDetail.RentalId);
            return View(rentalDetail);
        }

        // GET: RentalDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalDetail rentalDetail = db.RentalDetail.Find(id);
            if (rentalDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipmentId = new SelectList(db.Equipment, "Id", "Code", rentalDetail.EquipmentId);
            ViewBag.RentalId = new SelectList(db.Rental, "Id", "Id", rentalDetail.RentalId);
            return View(rentalDetail);
        }

        // POST: RentalDetails/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubTotal,EquipmentId,RentalId,StartDate,ExpirationDate,Quantity")] RentalDetail rentalDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentalDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipmentId = new SelectList(db.Equipment, "Id", "Code", rentalDetail.EquipmentId);
            ViewBag.RentalId = new SelectList(db.Rental, "Id", "Id", rentalDetail.RentalId);
            return View(rentalDetail);
        }

        // GET: RentalDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalDetail rentalDetail = db.RentalDetail.Find(id);
            if (rentalDetail == null)
            {
                return HttpNotFound();
            }
            return View(rentalDetail);
        }

        // POST: RentalDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentalDetail rentalDetail = db.RentalDetail.Find(id);
            db.RentalDetail.Remove(rentalDetail);
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
