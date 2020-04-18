using SI656_AlquilerEquipos.Data;
using SI656_AlquilerEquipos.Services.BussinesService;
using SI656_AlquilerEquipos.Services.BussinesService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SI656_AlquilerEquipos.Web.ViewModel.Equipo;

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
            var vm = new IndexViewModel();
            vm.EquipmentList = await _equipoService.GetAllEquipmentAsync();
            return View(vm);
        }

        // GET: Equipo/Create
        public ActionResult Create()
        {
            var vm = new CreateViewModel();
            return View(vm);
        }

        // POST: Equipo/Create
        [HttpPost]
        public async Task<ActionResult> Create(CreateViewModel vm)
        {
            // TODO: Add insert logic here
            var equipment = new equipo()
            {
                codigo = vm.Code,
                nombre = vm.Name,
                descripcion = vm.Description,
                costo = vm.Cost,
                estado_id = vm.StateType
            };
            await _equipoService.AddEquipmentAsync(equipment);
            return RedirectToAction("Index");
        }

        // GET: Equipo/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var equipment = await _equipoService.GetByIdAsync(id);
            var vm = new EditViewModel()
            {
                Id = equipment.id,
                Code = equipment.codigo,
                Name = equipment.nombre,
                Description = equipment.descripcion,
                Cost = equipment.costo,
                StateType = equipment.estado_id
            };
            return View(vm);
        }

        // POST: Equipo/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(EditViewModel vm)
        {
            // TODO: Add update logic here
            var equipment = await _equipoService.GetByIdAsync(vm.Id);
            equipment.codigo = vm.Code;
            equipment.nombre = vm.Name;
            equipment.descripcion = vm.Description;
            equipment.costo = vm.Cost;
            equipment.estado_id = vm.StateType;
            await _equipoService.UpdateEquipmentAsync(equipment);
            return RedirectToAction("Index");
        }

        // POST: Equipo/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                await _equipoService.DeleteEquipmentAsync(id);
                return Json(new { isOk = true, message = "Ok" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { isOk = false, message = $"{e.Message}" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}