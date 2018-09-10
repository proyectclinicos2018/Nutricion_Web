using System;
using System.ServiceModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ServiceModel.Activation;
using System.Web.Script.Serialization;
using Falp.Entidades;
using Falp.Capa_Negocios;

namespace Falp.Oficial
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service" en el código, en svc y en el archivo de configuración a la vez.

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : IService
    {
        public void DoWork()
        {
        }

        public string Lista__liquido(string prefix)
        {

          /*  string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            int cod_consistencia = Convert.ToInt32(Session["Consistencia"].ToString());
            int cod_cobro = Convert.ToInt32(Session["Regimen"].ToString());
            int cod_digestabilidad = Convert.ToInt32(Session["Digestabilidad"].ToString());
            int cod_sal = Convert.ToInt32(Session["Sal"].ToString());
            int cod_lactosa = Convert.ToInt32(Session["Lactosa"].ToString());
            int cod_dulzor = Convert.ToInt32(Session["Dulzor"].ToString());*/

            int cod_consistencia = Convert.ToInt32(1);
            int cod_cobro = Convert.ToInt32(1);
            int cod_digestabilidad = Convert.ToInt32(1);
            int cod_sal = Convert.ToInt32(1);
            int cod_lactosa = Convert.ToInt32(1);
            int cod_dulzor = Convert.ToInt32(1);
            int cod_tipo_comida = 1;
            int cod_tipo_distribucion = 7; // Convert.ToInt32(cbotipo_distribucion.SelectedValue);
            List<Utilidades> lista_alimentos_liquido = new UtilidadesNE().Cargar_alimentos_menu(cod_tipo_comida, cod_tipo_distribucion, 1, 1, 1, 1, 1, 1);


            return (new JavaScriptSerializer().Serialize(lista_alimentos_liquido));
            
        }
    }
}
