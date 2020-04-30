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
    public class EquipmentsController : Controller
    {
        private db_AlquilerEquipoEntities db = new db_AlquilerEquipoEntities();

        // GET: Equipments
        public ActionResult Index()
        {
            var equipment = db.Equipment.Include(e => e.EquipmentState).Include(e => e.EquipmentType);
            return View(equipment.ToList());
        }

        // GET: Equipments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = db.Equipment.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // GET: Equipments/Create
        public ActionResult Create()
        {
            ViewBag.EquipmentStateId = new SelectList(db.EquipmentState, "Id", "Name");
            ViewBag.EquipmentTypeId = new SelectList(db.EquipmentType, "Id", "Name");
            return View();
        }

        // POST: Equipments/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Name,Description,Cost,EquipmentStateId,Stock,EquipmentTypeId,CompanyId,PriceByHour,PriceByDay,PriceByWeek,ExtraHour,ExtraDay,ImagePath")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                db.Equipment.Add(equipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquipmentStateId = new SelectList(db.EquipmentState, "Id", "Name", equipment.EquipmentStateId);
            ViewBag.EquipmentTypeId = new SelectList(db.EquipmentType, "Id", "Name", equipment.EquipmentTypeId);
            return View(equipment);
        }

        // GET: Equipments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = db.Equipment.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipmentStateId = new SelectList(db.EquipmentState, "Id", "Name", equipment.EquipmentStateId);
            ViewBag.EquipmentTypeId = new SelectList(db.EquipmentType, "Id", "Name", equipment.EquipmentTypeId);
            return View(equipment);
        }

        // POST: Equipments/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,Description,Cost,EquipmentStateId,Stock,EquipmentTypeId,CompanyId,PriceByHour,PriceByDay,PriceByWeek,ExtraHour,ExtraDay,ImagePath")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipmentStateId = new SelectList(db.EquipmentState, "Id", "Name", equipment.EquipmentStateId);
            ViewBag.EquipmentTypeId = new SelectList(db.EquipmentType, "Id", "Name", equipment.EquipmentTypeId);
            return View(equipment);
        }

        // GET: Equipments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = db.Equipment.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipment equipment = db.Equipment.Find(id);
            db.Equipment.Remove(equipment);
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
