using SI656_AlquilerEquipos.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SI656_AlquilerEquipos.Web.ViewModel.Auth;
using SI656_AlquilerEquipos.Services.BussinesService.Interface;
using SI656_AlquilerEquipos.Services.BussinesService;

namespace SI656_AlquilerEquipos.Web.Controllers
{
    public class AuthController : BaseController
    {

        private IUserService _userService;

        public AuthController()
        {
            _userService = new UserService(context);
        }

        [HttpPost]
        public async Task<ActionResult> Authentication(IndexViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToAction("Index", "Auth");

                Session.Clear();

                var user = await _userService.Authentication(vm.Email, vm.Password);
                if (user == null)
                {
                    AlertNotification("error", "Ups!", $"El correo y/o contraseña son incorrecta(s).");
                    return RedirectToAction("Index", "Auth");
                }

                Session.Set(SessionKey.UsuarioId, user.Id);
                Session.Timeout = 525600;

                return RedirectToAction("Index", "Client");
            }
            catch
            {
                AlertNotification("error", "Ups!", $"Parece que ocurrio un error en el sistema.");
                return RedirectToAction("Index", "Auth");
            }
        }

        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }
    }
}
