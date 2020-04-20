using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace SI656_AlquilerEquipos.Helper
{
    public enum SessionKey
    {
        UsuarioId,
        Permisos,
        AccessToken,
    }

    public static class SessionHelper
    {

        #region Private

        private static object Get(HttpSessionState Session, String Key)
        {
            return Session[Key];
        }

        private static void Set(HttpSessionState Session, String Key, object Value)
        {
            Session[Key] = Value;
        }

        private static bool Exists(HttpSessionState Session, String Key)
        {
            return Session[Key] != null;
        }

        private static object Get(HttpSessionStateBase Session, String Key)
        {
            return Session[Key];
        }

        private static void Set(HttpSessionStateBase Session, String Key, object Value)
        {
            Session[Key] = Value;
        }

        private static bool Exists(HttpSessionStateBase Session, String Key)
        {
            return Session[Key] != null;
        }

        #endregion

        #region Getters setters GlobalKey
        //HttpSessionState
        public static object Get(this HttpSessionState Session, SessionKey Key)
        {
            return Get(Session, Key.ToString());
        }

        public static void Set(this HttpSessionState Session, SessionKey Key, object Value)
        {
            Set(Session, Key.ToString(), Value);
        }

        public static bool Exists(this HttpSessionState Session, SessionKey Key)
        {
            return Exists(Session, Key.ToString());
        }

        //HttpSessionStateBase
        public static object Get(this HttpSessionStateBase Session, SessionKey Key)
        {
            return Get(Session, Key.ToString());
        }

        public static void Set(this HttpSessionStateBase Session, SessionKey Key, object Value)
        {
            Set(Session, Key.ToString(), Value);
        }

        public static bool Exists(this HttpSessionStateBase Session, SessionKey Key)
        {
            return Exists(Session, Key.ToString());
        }
        #endregion

        #region IsLoggedIn
        public static Boolean IsLoggedIn(this HttpSessionState Session)
        {
            return Get(Session, SessionKey.UsuarioId) != null;
        }

        public static Boolean IsLoggedIn(this HttpSessionStateBase Session)
        {
            return Get(Session, SessionKey.UsuarioId) != null;
        }
        #endregion

        #region AccessToken
        public static String GetAccessToken(this HttpSessionState Session)
        {
            return Get(Session, SessionKey.AccessToken).ToString();
        }

        public static String GetAccessToken(this HttpSessionStateBase Session)
        {
            return Get(Session, SessionKey.AccessToken).ToString();
        }
        #endregion

        public static Boolean IsAuthorize(this HttpSessionState session, params String[] permisos)
        {
            var lstPermisos = new List<String>();

            foreach (var permiso in permisos)
            {
                if (permisos.Contains(permiso))
                    return true;
            }

            return false;
        }

        public static Boolean IsAnyAuth(this HttpSessionState Session, params String[] permisos)
        {
            var lstPermisos = new List<String>();

            foreach (var permiso in permisos)
            {
                if (lstPermisos.Any(x => x.StartsWith(permiso)))
                    return true;
            }

            return false;
        }


        #region UsuarioId
        public static Int32 GetUsuarioId(this HttpSessionState Session)
        {
            return (int)Get(Session, SessionKey.UsuarioId);
        }

        public static Int32 GetUsuarioId(this HttpSessionStateBase Session)
        {
            return (int)Get(Session, SessionKey.UsuarioId);
        }
        #endregion

       

        #region GetPermisos

        public static String[] GetPermisos(this HttpSessionState Session)
        {
            return (String[])Get(Session, SessionKey.Permisos);
        }

        public static String[] GetPermisos(this HttpSessionStateBase Session)
        {
            return (String[])Get(Session, SessionKey.Permisos);
        }

        #endregion

    }

}
