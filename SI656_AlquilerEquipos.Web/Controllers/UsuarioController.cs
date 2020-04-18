using SI656_AlquilerEquipos.Data;
using SI656_AlquilerEquipos.Services.BussinesService;
using SI656_AlquilerEquipos.Services.BussinesService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SI656_AlquilerEquipos.Web.ViewModel.Usuario;

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
            var vm = new IndexViewModel();
            vm.UserList = await _usuarioService.GetAllUserAsync();
            return View(vm);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            var vm = new CreateViewModel();
            return View(vm);
        }

        // POST: Usuario/Create
        [HttpPost]
        public async Task<ActionResult> Create(CreateViewModel vm)
        {
            // TODO: Add insert logic here
            var user = new usuario()
            {
                nombre = vm.Name,
                usuario1 = vm.User,
                cargo_id = vm.Rol,
                clave = vm.Password
            };
            await _usuarioService.AddUserAsync(user);
            return RedirectToAction("Index");
        }

        // GET: Usuario/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var user = await _usuarioService.GetByIdAsync(id);
            var vm = new EditViewModel()
            {
                Id = user.id,
                Name = user.nombre,
                User = user.usuario1,
                Password = user.clave,
                Rol = user.cargo_id
            };
            return View(vm);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(EditViewModel vm)
        {
            // TODO: Add update logic here
            var user = await _usuarioService.GetByIdAsync(vm.Id);
            user.nombre = vm.Name;
            user.usuario1 = vm.User;
            user.clave = vm.Password;
            user.cargo_id = vm.Rol;
            await _usuarioService.UpdateUserAsync(user);
            return RedirectToAction("Index");

        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                await _usuarioService.DeleteUserAsync(id);
                return Json(new { isOk = true, message = "Ok" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { isOk = false, message = $"{e.Message}" }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}