using SI656_Alquiler_Equipos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SI656_Alquiler_Equipos.Controllers
{
    public class AccountController : Controller
    {
        private db_AlquilerEquipoEntities db = new db_AlquilerEquipoEntities();

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin userLogin)
        {
            
            bool isValid = db.User.Any(x => x.NameUser == userLogin.NameUser && x.Password == userLogin.Password);
            if (isValid) {
                FormsAuthentication.SetAuthCookie(userLogin.NameUser, false);
                return RedirectToAction("Index", "Users");
            }
            ModelState.AddModelError("", "Invalid UserName and Password");
            return View();
        }


        public ActionResult SignUp()
        {
            ViewBag.RolId = new SelectList(db.Rol, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "Id,Name,MotherLastName,FatherLastName,NameUser,Password,RolId,Email,MobileNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            ViewBag.RolId = new SelectList(db.Rol, "Id", "Name", user.RolId);
            return View(user);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}