using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SI656_AlquilerEquipos.Models;

namespace SI656_AlquilerEquipos.Controllers
{
    public class EquipoController : Controller
    {
        // GET: Equipo
        public ActionResult Index()
        {
            List<equipo> equipos = new List<equipo>();
            using (db_AlquilerEquipoEntities db = new db_AlquilerEquipoEntities()) {
                equipos = db.equipo.ToList<equipo>();
            }
                return View(equipos);
        }

        // GET: Equipo/Create
        public ActionResult Create()
        {
            return View(new equipo());
        }

        // POST: Equipo/Create
        [HttpPost]
        public ActionResult Create(equipo equipoModel)
        {
            
                // TODO: Add insert logic here
                using (db_AlquilerEquipoEntities db = new db_AlquilerEquipoEntities())
                {
                    db.equipo.Add(equipoModel);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
           
        }

        // GET: Equipo/Edit/5
        public ActionResult Edit(int id)
        {
            equipo equipoModel = new equipo();
            using (db_AlquilerEquipoEntities db = new db_AlquilerEquipoEntities())
            {
                equipoModel = db.equipo.Where(x => x.id == id).FirstOrDefault();
            }
            return View(equipoModel);
        }

        // POST: Equipo/Edit/5
        [HttpPost]
        public ActionResult Edit(equipo equipoModel)
        {

            // TODO: Add update logic here
            using (db_AlquilerEquipoEntities db = new db_AlquilerEquipoEntities())
            {
                var updateEquipo = db.equipo.Single(p => p.id == equipoModel.id);
                TryUpdateModel(updateEquipo);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
            
        }

        // GET: Equipo/Delete/5
        public ActionResult Delete(int id)
        {
            equipo equipoModel = new equipo();
            using (db_AlquilerEquipoEntities db = new db_AlquilerEquipoEntities())
            {
                equipoModel = db.equipo.Where(x => x.id == id).FirstOrDefault();
            }
            return View(equipoModel);
        }

        // POST: Equipo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            
                // TODO: Add delete logic here
                using (db_AlquilerEquipoEntities db = new db_AlquilerEquipoEntities())
                {
                equipo equipoModel = db.equipo.Where(x => x.id == id).FirstOrDefault();
                db.equipo.Remove(equipoModel);
                db.SaveChanges();
                }
                return RedirectToAction("Index");
            
        }
    }
}
