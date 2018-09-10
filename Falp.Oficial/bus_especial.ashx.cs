using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Falp.Entidades;
using Falp.Capa_Negocios;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Data;

namespace Falp.Oficial
{
    /// <summary>
    /// Descripción breve de bus_especial
    /// </summary>
    public class bus_especial : IHttpHandler
    {


        public void ProcessRequest(HttpContext context)
        {

            string descripcion = context.Request.QueryString["q"];
            int cod_distribucion = Convert.ToInt32(context.Request.QueryString["q1"]);
       
            List<Utilidades> lista_alimentos_especial = new UtilidadesNE().Cargar_alimentos_menu_extra_extra(cod_distribucion, descripcion);

            context.Response.Write(lista_alimentos_especial.ToString()); 
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}