using SI656_AlquilerEquipos.Data;
using SI656_AlquilerEquipos.Services.BussinesService;
using SI656_AlquilerEquipos.Services.BussinesService.Interface;
using SI656_AlquilerEquipos.Web.ViewModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SI656_AlquilerEquipos.Web.Controllers
{
    public class ClientController : BaseController
    {
        private readonly IClientService _clientService;

        public ClientController()
        {
            _clientService = new ClientService(context);
        }

        // GET: Cliente
        public async Task<ActionResult> Index()
        {
            var vm = new IndexViewModel();
            vm.ClientList = await _clientService.GetClientListBasicInfoAsync();
            return View(vm);
        }

        // GET: Cliente/Create
        public async Task<ActionResult> Create()
        {
            var vm = new CreateViewModel();
            vm.GenderList = await _clientService.GetAllGenderAsync();
            vm.DocumentTypes = await _clientService.GetAllDocumentTypeAsync();
            return View(vm);
        }

        // POST: Cliente/Create
        [HttpPost]
        public async Task<ActionResult> Create(CreateViewModel vm)
        {
            // TODO: Add insert logic here
            var newClient = new Client() {
                Name = vm.Name,
                FatherLastName = vm.FatherLastName,
                MotherLastName = vm.MotherLastName,
                GenderId = vm.GenderId,
                DocumentTypeId = vm.DocumentType,
                DocumentNumber = vm.DocumentNumber,
                Email = vm.Email,
                Address = vm.Address,
                Age = vm.Age,
                MobileNumber = vm.MobileNumber,
            };
            await _clientService.AddClientAsync(newClient);
            return RedirectToAction("Index");
        }

        // GET: Cliente/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            
            var client = await _clientService.GetByIdAsync(id);
            var vm = new EditViewModel() {
                Id = client.Id,
                Name = client.Name,
                MotherLastName = client.MotherLastName,
                FatherLastName = client.FatherLastName,
                DocumentType = client.DocumentTypeId,
                DocumentNumber = client.DocumentNumber,
                GenderId = client.GenderId,
                Email = client.Email,
                Address = client.Address,
                Age = client.Age,
                MobileNumber = client.MobileNumber,
            };
            vm.GenderList = await _clientService.GetAllGenderAsync();
            vm.DocumentTypes = await _clientService.GetAllDocumentTypeAsync();
            return View(vm);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(EditViewModel vm)
        {
            // TODO: Add update logic here
            var client = await _clientService.GetByIdAsync(vm.Id);
            client.Name = vm.Name;
            client.MotherLastName = vm.MotherLastName;
            client.FatherLastName = vm.FatherLastName;
            client.GenderId = vm.GenderId;
            client.DocumentTypeId= vm.DocumentType;
            client.DocumentNumber = vm.DocumentNumber;
            client.Email = vm.Email;
            client.Address = vm.Address;
            client.Age = vm.Age;
            client.MobileNumber = vm.MobileNumber;
            await _clientService.UpdateClientAsync(client);
            return RedirectToAction("Index");
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                var clienteModel = new Client();
                clienteModel = await _clientService.GetByIdAsync(id);
                return Json(new { isOk = true, message = "Ok" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e) {
                return Json(new { isOk = false, message = $"{e.Message}" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}