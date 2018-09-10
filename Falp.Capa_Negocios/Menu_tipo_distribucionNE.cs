using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falp.Entidades;
using Falp.Capa_Datos;

namespace Falp.Capa_Negocios
{
    public class Menu_tipo_distribucionNE
    {
        string res = "";
        Menu_tipo_distribucionDA var = new Menu_tipo_distribucionDA();
        Menu_tipo_distribucion mtc = new Menu_tipo_distribucion();

        public string Registrar_Tipo_Distribucion(int cod_pedido_det, int cod_tipo_distribucion, string user, string mixto,string obs)
        {

            mtc._Cod_pedido_det = cod_pedido_det;
            mtc._Cod_tipo_distribucion = cod_tipo_distribucion;
            mtc._User_crea = user;
          

            return var.Registrar_Tipo_Distribucion(mtc,mixto,obs);
        }

        public string Modificar_Tipo_Distribucion(int cod_pedido_det, int cod_tipo_distribucion, string user, string mixto,string obs)
        {

            mtc._Cod_pedido_det = cod_pedido_det;
            mtc._Cod_tipo_distribucion = cod_tipo_distribucion;
            mtc._User_crea = user;
           


            return var.Modificar_Tipo_Distribucion(mtc, mixto,obs);
        }


      /*  public string Registrar_Tipo_Distribucion(int cod_pedido_det, int cod_tipo_distribucion, string user)
        {

            mtc._Cod_pedido_det = cod_pedido_det;
            mtc._Cod_tipo_distribucion = cod_tipo_distribucion;
            mtc._User_crea = user;
          

            return var.Registrar_Tipo_Distribucion(mtc);
        }*/
    }
}
