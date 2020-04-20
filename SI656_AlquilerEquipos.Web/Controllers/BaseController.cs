using SI656_AlquilerEquipos.Data;
using SI656_AlquilerEquipos.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SI656_AlquilerEquipos.Web.Controllers
{
    public class CargarDatosContext {
        public db_AlquilerEquipoEntities context { get; set; }
        public HttpSessionStateBase session { get; set; }
        public HttpContextBase httpContext { get; set; }
    }

    public class BaseController : Controller
    {
        internal db_AlquilerEquipoEntities context { get; set; }
        private CargarDatosContext cargarDatosContext { get; set; }
        public BaseController() {
            context = new db_AlquilerEquipoEntities();
        }
        public void InvalidarContext()
        {
            context = new db_AlquilerEquipoEntities();
        }

        public CargarDatosContext CargarDatosContext()
        {
            if (cargarDatosContext == null)
            {
                cargarDatosContext =
                    new CargarDatosContext { context = context, session = Session, httpContext = HttpContext };
            }

            return cargarDatosContext;
        }

        public void AlertNotification(string type, string title, string message) => TempData["AlertNotification"] =
           UIHelper.RenderAlertNotificacion(type, title, message);

    }
}