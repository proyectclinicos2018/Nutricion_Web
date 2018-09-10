using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falp.Entidades;
using Falp.Capa_Datos;


namespace Falp.Capa_Negocios
{
   public  class Menu_tipo_alimentosNE
    {
        string res = "";
        Menu_tipo_alimentosDA var = new Menu_tipo_alimentosDA();
        Menu_tipo_alimento mtc = new Menu_tipo_alimento();

        public string Registrar_Tipo_Alimento(int cod_pedido_reg_det,int cod_dis, int cod_tipo_alimentos,int cod_comparacion,string nom_tipo_alimento,int cantidad, string vigencia, string estado, string user,int cod_consistencia,int cod_digestabilidad,int cod_lactosa,int cod_dulzor,int cod_volumen,int cod_temperatura,int cod_sal ,string comentario,string cod_pedido)
        {

            mtc._Cod_pedido_reg_det = cod_pedido_reg_det;
            mtc._Cod_tipo_distribucion = cod_dis;
            mtc._Cod_tipo_alimentos = cod_tipo_alimentos;
            mtc._Nom_tipo_alimentos = nom_tipo_alimento;
            mtc._Cantidad=cantidad;
            mtc._Vigencia = vigencia;
            mtc._Estado = estado;




            return var.Registrar_Tipo_Alimento(mtc,cod_comparacion,cod_consistencia,cod_digestabilidad,cod_lactosa,cod_dulzor,cod_volumen,cod_temperatura,cod_sal,comentario,cod_pedido);
        }

       /* public string Registrar_Tipo_Alimento(int cod_dis, int cod_ali, int cant, string vig, string est, string user, string fecha)
        {
            mtc._Cod_pedido_reg_det = cod_dis;
            mtc._Cod_tipo_alimentos = cod_ali;
            mtc._Cantidad = cant;
            mtc._Vigencia = vig;
            mtc._Estado = est;

            mtc._User_crea = user;
            mtc._Fecha_crea = Convert.ToDateTime(fecha);

            return var.Registrar_Tipo_Alimento(mtc);
        }*/


        public string Modificar_Tipo_Alimento(int cod_distribucion, int cod_dis, int cod_ali, int cant, string vig, string est, string user, int cod_consistencia, int cod_digestabilidad, int cod_lactosa, int cod_dulzor, int cod_volumen, int cod_temperatura, int cod_sal, string comentario)
        {
            mtc._Cod_pedido_reg_det = cod_distribucion;
            mtc._Cod_tipo_distribucion = cod_dis;
            mtc._Cod_tipo_alimentos = cod_ali;
            mtc._Cantidad = cant;
            mtc._Vigencia = vig;
            mtc._Estado = est;

            mtc._User_crea = user;
          //  mtc._Fecha_crea = Convert.ToDateTime(fecha);

            return var.Modificar_Tipo_Alimento(mtc, cod_consistencia, cod_digestabilidad, cod_lactosa, cod_dulzor, cod_volumen, cod_temperatura, cod_sal, comentario);
        }


        #region ingesta

        public List<Menu_tipo_alimento> Listado_ingesta(string cod_pedido, string cod_tipo_comida)
        {
            return var.Listado_ingesta(cod_pedido, cod_tipo_comida);
        }

        public List<Menu_tipo_alimento> Listado_ingesta_2(string cod_pedido, string cod_tipo_comida)
        {
            return var.Listado_ingesta_2(cod_pedido, cod_tipo_comida);
        }

        public string Restablecer(string cod_pedido, string cod_tipo_comida)
        {
            return var.Restablecer(cod_pedido, cod_tipo_comida);
        }

        public List<Menu_tipo_alimento> Validar_ingesta(string cod_pedido)
        {
            return var.Validar_ingesta(cod_pedido);
        }


        #endregion 

       
        public string Registrar_Ingesta(string cod_pedido, string cod_tipo_comida, int cod_al, double gr_c, double cc_c, double calorias, double proteinas,
                                       double lipidos, double hyc, double sodio, double cc_total, string user, int porcentaje,int cantidad)
        {

            mtc._Cod_pedido =   Convert.ToInt32(cod_pedido);
            mtc._Cod_tipo_comida = Convert.ToInt32(cod_tipo_comida);
            mtc._Cod_tipo_alimentos = cod_al;
            mtc._Gr_i= gr_c;
            mtc._Cc_i = cc_c;
            mtc._Calorias = calorias;
            mtc._Proteinas= proteinas;
            mtc._Lipidos = lipidos;
            mtc._Hyc = hyc;
            mtc._Sodio = sodio;
            mtc._Ing_cc_total = cc_total.ToString();
            mtc._User_crea = user;
            mtc._Porcentaje = porcentaje;
            mtc._Cantidad = cantidad;


            return var.Registrar_Ingesta( mtc);
        }


        public string Modificar_Ingesta(int cod_ingesta, string cod_pedido, string cod_tipo_comida, int cod_al, double gr_c, double cc_c, double calorias, double proteinas,
                                   double lipidos, double hyc, double sodio, double cc_total, string user, int porcentaje,int cantidad)
        {

            mtc._Cod_pedido = Convert.ToInt32(cod_pedido);
            mtc._Ing_id = cod_ingesta;
            mtc._Cod_tipo_comida = Convert.ToInt32(cod_tipo_comida);
            mtc._Cod_tipo_alimentos = cod_al;
            mtc._Gr_i = gr_c;
            mtc._Cc_i = cc_c;
            mtc._Calorias = calorias;
            mtc._Proteinas = proteinas;
            mtc._Lipidos = lipidos;
            mtc._Hyc = hyc;
            mtc._Sodio = sodio;
            mtc._Ing_cc_total=cc_total.ToString();
            mtc._User_crea = user;
            mtc._Porcentaje = porcentaje;
            mtc._Cantidad = cantidad;

            return var.Modificar_Ingesta( mtc);
        }


        public string Modificar_totales(int cod_ingesta, string cod_pedido, string cod_tipo_comida, double scod_c, double scod_p, double scod_l, double scod_hyc, double scod_s,
                                 double scod_total, double cod_ajc, double cod_ajp, double cod_ajl, double cod_ajhyc, double cod_ajs, double cod_ajtotal, string user, double cod_sgc)
        {

            mtc._Cod_pedido = Convert.ToInt32(cod_pedido);
            mtc._Ing_id = cod_ingesta;
            mtc._Cod_tipo_comida = Convert.ToInt32(cod_tipo_comida);
            mtc._Sub_calorias = scod_c;
            mtc._Sub_proteinas = scod_p;
            mtc._Sub_lipidos = scod_l;
            mtc._Sub_hyc = scod_hyc;
            mtc._Sub_sodio = scod_s;
            mtc._Sub_cc_total = scod_total;

            mtc._Ajuste_calorias = cod_ajc;
            mtc._Ajuste_proteinas = cod_ajp;
            mtc._Ajuste_lipidos = cod_ajl;
            mtc._Ajuste_hyc = cod_ajhyc;
            mtc._Ajuste_sodio = cod_ajs;
            mtc._Ajuste_cc_total = cod_ajtotal;
            mtc._User_crea = user;

            return var.Modificar_totales(mtc, cod_sgc);
        }




        public List<Menu_tipo_alimento> Obtener_resumen()
        {
            return var.Obtener_resumen();
        }
    }
}
