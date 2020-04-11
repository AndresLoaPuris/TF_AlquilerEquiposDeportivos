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
            var clientes = new List<cliente>();
            clientes = await _clienteService.GetAllClientAsync();
            return View(clientes);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View(new cliente());
        }

        // POST: Cliente/Create
        [HttpPost]
        public async Task<ActionResult> Create(cliente clienteModel)
        {
            // TODO: Add insert logic here
            await _clienteService.AddClientAsync(clienteModel);
            return RedirectToAction("Index");
        }

        // GET: Cliente/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var clienteModel = new cliente();
            clienteModel = await _clienteService.GetByIdAsync(id);
            return View(clienteModel);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(cliente ClienteModel)
        {
            // TODO: Add update logic here
            await _clienteService.UpdateClientAsync(ClienteModel);
            return RedirectToAction("Index");

        }

        // GET: Cliente/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var clienteModel = new cliente();
            clienteModel = await _clienteService.GetByIdAsync(id);
            return View(clienteModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            // TODO: Add delete logic here
            await _clienteService.DeleteClientAsync(id);
            return RedirectToAction("Index");
        }
    }
}