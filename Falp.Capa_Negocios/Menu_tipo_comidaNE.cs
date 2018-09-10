using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falp.Entidades;
using Falp.Capa_Datos;

namespace Falp.Capa_Negocios
{
   public  class Menu_tipo_comidaNE
    {
        string res = "";
        Menu_tipo_comidaDA var = new Menu_tipo_comidaDA();
        Menu_tipo_comida mtc = new Menu_tipo_comida();

        public string Registrar_Tipo_Comida(int cod_menu, int cod_tipo_comida, string user,string vigencia)
        {

            mtc._Cod_pedido = cod_menu;
            mtc._Cod_tipo_comida = cod_tipo_comida;
            mtc._User_crea = user;
           
        

            return var.Registrar_Tipo_Comida(mtc,vigencia);
        }

        public string Modificar_Tipo_Comida(int cod_menu, int id_tipo_comida, string user,string v)
        {

            mtc._Cod_pedido = cod_menu;
            mtc._Cod_tipo_comida = id_tipo_comida;
            mtc._User_crea = user;


            return var.Modificar_Tipo_Comida(mtc,v);
        }

         public string Modificar_Tipo_Comida_comentario(string cod_pedido, int cod_tipo_comida, string comentario,string user)
        {

            mtc._Cod_pedido = Convert.ToInt32(cod_pedido);
            mtc._Cod_tipo_comida = cod_tipo_comida;
            mtc._User_crea = user;


            return var.Modificar_Tipo_Comida_comentario(mtc,comentario);
        }
    }
}
