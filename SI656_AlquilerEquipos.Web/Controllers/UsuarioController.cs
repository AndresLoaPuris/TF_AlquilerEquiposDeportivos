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
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController()
        {
            _usuarioService = new UsuarioService(context);
        }

        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            var usuarios = new List<usuario>();
            usuarios = await _usuarioService.GetAllUserAsync();
            return View(usuarios);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View(new usuario());
        }

        // POST: Usuario/Create
        [HttpPost]
        public async Task<ActionResult> Create(usuario usuarioModel)
        {
            // TODO: Add insert logic here
            await _usuarioService.AddUserAsync(usuarioModel);
            return RedirectToAction("Index");
        }

        // GET: Usuario/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var usuarioModel = new usuario();
            usuarioModel = await _usuarioService.GetByIdAsync(id);
            return View(usuarioModel);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(usuario usuarioModel)
        {
            // TODO: Add update logic here
            await _usuarioService.UpdateUserAsync(usuarioModel);
            return RedirectToAction("Index");

        }

        // GET: Usuario/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var usuarioModel = new usuario();
            usuarioModel = await _usuarioService.GetByIdAsync(id);
            return View(usuarioModel);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            // TODO: Add delete logic here
            await _usuarioService.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }
    }
}