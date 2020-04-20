using SI656_AlquilerEquipos.Data;
using SI656_AlquilerEquipos.Services.BussinesService;
using SI656_AlquilerEquipos.Services.BussinesService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SI656_AlquilerEquipos.Web.ViewModel.User;

namespace SI656_AlquilerEquipos.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _usuarioService;

        public UserController()
        {
            _usuarioService = new UserService(context);
        }

        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            var vm = new IndexViewModel();
            vm.UserList = await _usuarioService.GetUserListBasicInfoAsync();
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
            var user = new User()
            {
              Name = vm.Name,
              FatherLastName = vm.FatherLastName,
              MotherLastName = vm.MotherLastName,
              NameUser = vm.NameUser,
              Password = vm.Password,
              RolId = vm.RolId,
              Email = vm.Email,
              MobileNumber = vm.MobileNumber
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
                Id = user.Id,
                Name = user.Name,
                FatherLastName = user.FatherLastName,
                MotherLastName = user.MotherLastName,
                NameUser = user.NameUser,
                Password = user.Password,
                RolId = user.RolId,
                Email = user.Email,
                MobileNumber = user.MobileNumber
            };
            return View(vm);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(EditViewModel vm)
        {
            // TODO: Add update logic here
            var user = await _usuarioService.GetByIdAsync(vm.Id);
            user.Name = vm.Name;
            user.FatherLastName = vm.FatherLastName;
            user.MotherLastName = vm.MotherLastName;
            user.NameUser = vm.NameUser;
            user.Password = vm.Password;
            user.RolId = vm.RolId;
            user.Email = vm.Email;
            user.MobileNumber = vm.MobileNumber;
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