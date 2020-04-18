using SI656_AlquilerEquipos.Data;
using SI656_AlquilerEquipos.Services.BussinesService;
using SI656_AlquilerEquipos.Services.BussinesService.Interface;
using SI656_AlquilerEquipos.Web.ViewModel.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SI656_AlquilerEquipos.Web.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly IClienteService _clienteService;

        public ClienteController()
        {
            _clienteService = new ClienteService(context);
        }

        // GET: Cliente
        public async Task<ActionResult> Index()
        {
            var vm = new IndexViewModel();
            vm.ClientList = await _clienteService.GetAllClientAsync();
            return View(vm);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            var vm = new CreateViewModel();

            return View(vm);
        }

        // POST: Cliente/Create
        [HttpPost]
        public async Task<ActionResult> Create(CreateViewModel vm)
        {
            // TODO: Add insert logic here
            var newClient = new cliente() {
                nombre = vm.Name,
                sexo = vm.Gender,
                tipo_documento_id = vm.DocumentType,
                documento = vm.DocumentNumber
            };
            await _clienteService.AddClientAsync(newClient);
            return RedirectToAction("Index");
        }

        // GET: Cliente/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            
            var client = await _clienteService.GetByIdAsync(id);
            var vm = new EditViewModel() {
                Id = client.id,
                Name = client.nombre,
                DocumentType = client.tipo_documento_id,
                DocumentNumber = client.documento,
                Gender = client.sexo
            };
            return View(vm);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(EditViewModel vm)
        {
            // TODO: Add update logic here
            var client = await _clienteService.GetByIdAsync(vm.Id);
            client.nombre = vm.Name;
            client.sexo = vm.Gender;
            client.tipo_documento_id = vm.DocumentType;
            client.documento = vm.DocumentNumber;
            await _clienteService.UpdateClientAsync(client);
            return RedirectToAction("Index");
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                var clienteModel = new cliente();
                clienteModel = await _clienteService.GetByIdAsync(id);
                return Json(new { isOk = true, message = "Ok" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e) {
                return Json(new { isOk = false, message = $"{e.Message}" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}