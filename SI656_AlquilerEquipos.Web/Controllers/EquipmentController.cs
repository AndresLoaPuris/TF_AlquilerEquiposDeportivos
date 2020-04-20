using SI656_AlquilerEquipos.Data;
using SI656_AlquilerEquipos.Services.BussinesService;
using SI656_AlquilerEquipos.Services.BussinesService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SI656_AlquilerEquipos.Web.ViewModel.Equipment;

namespace SI656_AlquilerEquipos.Web.Controllers
{
    public class EquipmentController : BaseController
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController()
        {
            _equipmentService = new EquipmentService(context);
        }


        // GET: Equipo
        public async Task<ActionResult> Index()
        {
            var vm = new IndexViewModel();
            vm.EquipmentList = await _equipmentService.GetEquipmentBasicInfoDTOsAsync();
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
            var equipment = new Equipment()
            {
                Code = vm.Code,
                Name = vm.Name,
                Description = vm.Description,
                Cost = vm.Cost,
                EquipmentStateId = vm.EsquipmentStateId,
                EquipmentTypeId = vm.EquipmentTypeId,
                PriceByHour = vm.PriceByHour,
                PriceByDay = vm.PriceByDay,
                PriceByWeek = vm.PriceByWeek,
                ExtraHour = vm.ExtraHour,
                ExtraDay = vm.ExtraDay,
                Stock = vm.Stock,
                ImagePath = vm.ImagePath
            };
            await _equipmentService.AddEquipmentAsync(equipment);
            return RedirectToAction("Index");
        }

        // GET: Equipo/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var equipment = await _equipmentService.GetByIdAsync(id);
            var vm = new EditViewModel()
            {
                Id = equipment.Id,
                Code = equipment.Code,
                Name = equipment.Name,
                Description = equipment.Description,
                Cost = equipment.Cost,
                EquipmentStateId = equipment.EquipmentStateId,
                PriceByHour = equipment.PriceByHour,
                EquipmentTypeId = equipment.EquipmentTypeId,
                PriceByDay = equipment.PriceByDay,
                PriceByWeek = equipment.PriceByWeek,
                ExtraHour = equipment.ExtraHour,
                ExtraDay = equipment.ExtraDay,
                Stock = equipment.Stock,
                ImagePath = equipment.ImagePath,
            };
            return View(vm);
        }

        // POST: Equipo/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(EditViewModel vm)
        {
            // TODO: Add update logic here
            var equipment = await _equipmentService.GetByIdAsync(vm.Id);
            equipment.Code = vm.Code;
            equipment.Name = vm.Name;
            equipment.Description = vm.Description;
            equipment.Cost = vm.Cost;
            equipment.EquipmentStateId = vm.EquipmentStateId;
            equipment.PriceByHour = vm.PriceByHour;
            equipment.EquipmentTypeId = vm.EquipmentTypeId;
            equipment.PriceByDay = vm.PriceByDay;
            equipment.PriceByWeek = vm.PriceByWeek;
            equipment.ExtraHour = vm.ExtraHour;
            equipment.ExtraDay = vm.ExtraDay;
            equipment.Stock = vm.Stock;
            equipment.ImagePath = vm.ImagePath;
            await _equipmentService.UpdateEquipmentAsync(equipment);
            return RedirectToAction("Index");
        }

        // POST: Equipo/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                await _equipmentService.DeleteEquipmentAsync(id);
                return Json(new { isOk = true, message = "Ok" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { isOk = false, message = $"{e.Message}" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}