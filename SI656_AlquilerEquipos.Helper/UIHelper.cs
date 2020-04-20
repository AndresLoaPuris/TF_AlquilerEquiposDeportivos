using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI656_AlquilerEquipos.Helper
{
    public static class UIHelper
    {
        public static string RenderAlertNotificacion(string type, string title, string message)
        {
            var sb = new StringBuilder();

            sb.Append("<script>")
                .Append("$(document).ready(function () {")
                .Append("swal({")
                .Append($"title: '{title}',")
                .Append($"text: '{message}',")
                .Append($"type: '{type}',")
                //.Append("confirmButtonColor: '#ef4554',")
                .Append("showConfirmButton: false,")
                .Append("timer: 5000,")
                .Append("})")
                .Append("});")
                .Append("</script>");

            return sb.ToString();
        }

    }
}
