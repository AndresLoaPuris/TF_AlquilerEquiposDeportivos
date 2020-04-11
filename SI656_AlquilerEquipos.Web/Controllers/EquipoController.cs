using SI656_AlquilerEquipos.Data;
using SI656_AlquilerEquipos.Services.BussinesService;
using SI656_AlquilerEquipos.Services.BussinesService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SI656_AlquilerEquipos.Web.Controllers
{
    public class EquipoController : BaseController
    {
        private readonly IEquipoService _equipoService;

        public EquipoController()
        {
            _equipoService = new EquipoService(context);
        }


        // GET: Equipo
        public async Task<ActionResult> Index()
        {
            var equipos = new List<equipo>();
            equipos = await _equipoService.GetAllEquipmentAsync();
            return View(equipos);
        }

        // GET: Equipo/Create
        public ActionResult Create()
        {
            return View(new equipo());
        }

        // POST: Equipo/Create
        [HttpPost]
        public async Task<ActionResult> Create(equipo equipoModel)
        {
            // TODO: Add insert logic here
            await _equipoService.AddEquipmentAsync(equipoModel);
            return RedirectToAction("Index");
        }

        // GET: Equipo/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var equipoModel = new equipo();
            equipoModel = await _equipoService.GetByIdAsync(id);
            return View(equipoModel);
        }

        // POST: Equipo/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(equipo equipoModel)
        {
            // TODO: Add update logic here
            await _equipoService.UpdateEquipmentAsync(equipoModel);
            return RedirectToAction("Index");

        }

        // GET: Equipo/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var equipoModel = new equipo();
            equipoModel = await _equipoService.GetByIdAsync(id);
            return View(equipoModel);
        }

        // POST: Equipo/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            // TODO: Add delete logic here
            await _equipoService.DeleteEquipmentAsync(id);
            return RedirectToAction("Index");
        }
    }
}