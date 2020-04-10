using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SI656_AlquilerEquipos.Models;

namespace SI656_AlquilerEquipos.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<cliente> clientes = new List<cliente>();
            using (db_AlquilerEquipoEntities db = new db_AlquilerEquipoEntities())
            {
                clientes = db.cliente.ToList<cliente>();
            }
            return View(clientes);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View(new cliente());
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(cliente clienteModel)
        {
            // TODO: Add insert logic here
            using (db_AlquilerEquipoEntities db = new db_AlquilerEquipoEntities())
            {
                db.cliente.Add(clienteModel);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            cliente clienteModel = new cliente();
            using (db_AlquilerEquipoEntities db = new db_AlquilerEquipoEntities())
            {
                clienteModel = db.cliente.Where(x => x.id == id).FirstOrDefault();
            }
            return View(clienteModel);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(cliente clienteModel)
        {

            // TODO: Add update logic here
            using (db_AlquilerEquipoEntities db = new db_AlquilerEquipoEntities())
            {
                var updateCliente = db.cliente.Single(p => p.id == clienteModel.id);
                TryUpdateModel(updateCliente);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            cliente clienteModel = new cliente();
            using (db_AlquilerEquipoEntities db = new db_AlquilerEquipoEntities())
            {
                clienteModel = db.cliente.Where(x => x.id == id).FirstOrDefault();
            }
            return View(clienteModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            // TODO: Add delete logic here
            using (db_AlquilerEquipoEntities db = new db_AlquilerEquipoEntities())
            {
                cliente clienteModel = db.cliente.Where(x => x.id == id).FirstOrDefault();
                db.cliente.Remove(clienteModel);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
