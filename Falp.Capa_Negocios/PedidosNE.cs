using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falp.Entidades;
using Falp.Capa_Datos;

namespace Falp.Capa_Negocios
{
   public  class PedidosNE
    {
        string res = "";
        PedidosDA var = new PedidosDA();
       Pedidos ped=new Pedidos() ;


        public Pedidos Cargar_pedidos(int cod_pedido)
        {
            return var.Cargar_pedidos(cod_pedido);
        }
        public Pedidos Cargar_pedidos2(int cod_pedido)
        {
            return var.Cargar_pedidos2(cod_pedido);
        }

        public Pedidos Cargar_Observacion(string cod_pedido)
        {
            return var.Cargar_Observacion(cod_pedido);
        }

        public Pedidos Extraer_opc_comida(string cod_pedido)
        {
            return var.Extraer_opc_comida(cod_pedido);
        }


        public List<Pedidos> Cargar_alimentos_pedidos(string fecha, int cod_tipo_comida, int cod_tipo_distribucion,string cod_pedido)
        {
            return var.Cargar_alimentos_pedidos(fecha, cod_tipo_comida, cod_tipo_distribucion, cod_pedido);
        }

        public int Validar_alimento_pedido(string fecha, int cod_tipo_comida, int cod_tipo_distribucion,string cod_pedido)
        {
            return var.Validar_alimento_pedido(fecha, cod_tipo_comida, cod_tipo_distribucion, cod_pedido);
        }



        public string Registrar_Pedido(int consistencia,int digestabilidad,int cobro,int lactosa,int dulzor,
                 int tipo_sales, string user, string cod_cama, string cod_paciente,int cod_opc_comida,string comentario,int aislamiento,int c_estado)
        {

            ped._Cod_tipo_consistencia = Convert.ToInt32(consistencia);
            ped._Cod_tipo_digestabilidad = Convert.ToInt32(digestabilidad);
            ped._Cod_tipo_sales = Convert.ToInt32(tipo_sales);
            ped._Cod_regimen = cobro;
            ped._Cod_lactosa = lactosa;
            ped._Cod_dulzor = dulzor;
            ped._Cod_opc_comida = cod_opc_comida;

            ped._User_crea = user;
            ped._Observaciones = comentario;
            ped._Cod_cama = cod_cama;
            ped._Cod_paciente = Convert.ToInt32(cod_paciente);
            ped._Cod_aislamiento = aislamiento;
            ped._Cod_estado = c_estado;
    


            return var.Registrar_Pedido(ped);
        }

        public string Registrar_Pedido(int consistencia, int digestabilidad, int cobro, int lactosa, int dulzor,
            int tipo_sales, string user, string cod_cama, string cod_paciente, int cod_opc_comida, string comentario, int aislamiento, int c_estado,string fecha)
        {

            ped._Cod_tipo_consistencia = Convert.ToInt32(consistencia);
            ped._Cod_tipo_digestabilidad = Convert.ToInt32(digestabilidad);
            ped._Cod_tipo_sales = Convert.ToInt32(tipo_sales);
            ped._Cod_regimen = cobro;
            ped._Cod_lactosa = lactosa;
            ped._Cod_dulzor = dulzor;
            ped._Cod_opc_comida = cod_opc_comida;

            ped._User_crea = user;
            ped._Observaciones = comentario;
            ped._Cod_cama = cod_cama;
            ped._Cod_paciente = Convert.ToInt32(cod_paciente);
            ped._Cod_aislamiento = aislamiento;
            ped._Cod_estado = c_estado;



            return var.Registrar_Pedido(ped,fecha);
        }

        public string Modificar_Pedido(string cod_pedido, int consistencia, int digestabilidad, int cobro, int lactosa, int dulzor,
              int tipo_sales, string user, string cod_cama, string cod_paciente, int cod_opc_comida, string comentario, int aislamiento,int c_estado)
        {
            ped._Cod_pedido = Convert.ToInt32(cod_pedido);
            ped._Cod_tipo_consistencia = Convert.ToInt32(consistencia);
            ped._Cod_tipo_digestabilidad = Convert.ToInt32(digestabilidad);
            ped._Cod_tipo_sales = Convert.ToInt32(tipo_sales);
            ped._Cod_regimen = cobro;
            ped._Cod_lactosa = lactosa;
            ped._Cod_dulzor = dulzor;
            ped._Cod_opc_comida = cod_opc_comida;
            ped._User_crea = user;
            ped._Observaciones = comentario;
            ped._Cod_cama = cod_cama;
            ped._Cod_paciente = Convert.ToInt32(cod_paciente);
            ped._Cod_aislamiento = aislamiento;
            ped._Cod_estado = c_estado;



            return var.Modificar_Pedido(ped);
        }


        public string Registrar_opc_comida(string cod_pedido,int consistencia, int digestabilidad, int cobro, int lactosa, int dulzor,
              int tipo_sales, string user, int cod_opc_comida, string comentario, int aislamiento,string val_d,string val_c1,string val_a,string val_o,string val_c,string val_c2,string val_ce,string val_hco)
        {

            ped._Cod_tipo_consistencia = Convert.ToInt32(consistencia);
            ped._Cod_tipo_digestabilidad = Convert.ToInt32(digestabilidad);
            ped._Cod_tipo_sales = Convert.ToInt32(tipo_sales);
            ped._Cod_regimen = cobro;
            ped._Cod_lactosa = lactosa;
            ped._Cod_dulzor = dulzor;
            ped._Cod_opc_comida = cod_opc_comida;
            ped._Cod_pedido = Convert.ToInt32(cod_pedido);
            ped._User_crea = user;
            ped._Observaciones = comentario;
            ped._Cod_aislamiento = aislamiento;



            return var.Registrar_opc_comida(ped,val_d,val_c1,val_a,val_o,val_c,val_c2,val_ce,val_hco);
        }

        public string Modificar_opc_comida(int id_opc,string cod_pedido, int consistencia, int digestabilidad, int cobro, int lactosa, int dulzor,
        int tipo_sales, string user, int cod_opc_comida, string comentario, int aislamiento, string val_d, string val_c1, string val_a, string val_o, string val_c, string val_c2, string val_ce, string val_hco)
        {
            ped._Id_opc_comida = id_opc;
            ped._Cod_tipo_consistencia = Convert.ToInt32(consistencia);
            ped._Cod_tipo_digestabilidad = Convert.ToInt32(digestabilidad);
            ped._Cod_tipo_sales = Convert.ToInt32(tipo_sales);
            ped._Cod_regimen = cobro;
            ped._Cod_lactosa = lactosa;
            ped._Cod_dulzor = dulzor;
            ped._Cod_opc_comida = cod_opc_comida;
            ped._Cod_pedido = Convert.ToInt32(cod_pedido);
            ped._User_crea = user;
            ped._Observaciones = comentario;
            ped._Cod_aislamiento = aislamiento;



            return var.Modificar_opc_comida(ped, val_d, val_c1, val_a, val_o, val_c, val_c2, val_ce, val_hco);
        }


        public string Registrar_Pedido(int cod_pedido,int cod_op_alimento,string user)
        {
            return var.Registrar_Pedido(cod_pedido,cod_op_alimento,user);
        }


        public string Eliminar_Pedido(string user, string cod_pedido, string cod_tipo_comida,int id_tipo_comida,string cod_paciente)
        {


            ped._User_crea = user;
            ped._Cod_pedido = Convert.ToInt32(cod_pedido);
            ped._Cod_tipo_comida = Convert.ToInt32(cod_tipo_comida);
            ped._Cod_paciente = Convert.ToInt32(cod_paciente);
            ped._Id_tipo_comida = id_tipo_comida;

            return var.Eliminar_Pedido(ped);
        }

        public string Eliminar_alimentos_Pedido(string user, string cod_pedido, string cod_tipo_comida, int id_tipo_comida, string cod_paciente)
        {


            ped._User_crea = user;
            ped._Cod_pedido = Convert.ToInt32(cod_pedido);
            ped._Cod_tipo_comida = Convert.ToInt32(cod_tipo_comida);
            ped._Cod_paciente = Convert.ToInt32(cod_paciente);
            ped._Id_tipo_comida = id_tipo_comida;

            return var.Eliminar_Alimentos_Pedido(ped);
        }


        public string Eliminar_Pedido( int cod_comida, int cod_distribucion)
        {


            ped._Id_tipo_comida = Convert.ToInt32(cod_comida);
            ped._Id_tipo_distribucion = Convert.ToInt32(cod_distribucion);
            return var.Eliminar_Pedido2(ped);
        }

        public string Eliminar_Pedido3(int cod_comida)
        {

            ped._Id_tipo_comida = Convert.ToInt32(cod_comida);
            return var.Eliminar_Pedido3(ped);
        }

        public string Registrar_alimentos_extra(int cod_tipo_comida,int cod_distribucion,int id_distribucion, int cod_alimento,string user,string tipo, string nom_alimento, int cod_consistencia,int cod_digestabilidad,int  cod_lactosa,int cod_dulzor, int cod_volumen,int cod_temperatura,int cod_sal,string comentario,int cod_pedido)
        {

            ped._User_crea = user;
            ped._Cod_tipo_comida = Convert.ToInt32(cod_tipo_comida);
            ped._Cod_tipo_distribucion = Convert.ToInt32(cod_distribucion);
            ped._Id_tipo_distribucion= id_distribucion;
            ped._Cod_tipo_alimento = Convert.ToInt32(cod_alimento);
            ped._Nom_tipo_alimento = nom_alimento;
            ped._Cod_pedido = cod_pedido;

            return var.Registrar_alimentos_extra(ped,tipo, cod_consistencia, cod_digestabilidad,  cod_lactosa, cod_dulzor,  cod_volumen, cod_temperatura, cod_sal, comentario);
        }

        public string Registrar_alimentos_especiales(int cod_tipo_comida, int cod_distribucion,int id_distribucion, int cod_alimento, string user, string tipo, string nom_alimento)
        {

            ped._User_crea = user;
            ped._Cod_tipo_comida = Convert.ToInt32(cod_tipo_comida);
            ped._Cod_tipo_distribucion = Convert.ToInt32(cod_distribucion);
            ped._Id_tipo_distribucion = id_distribucion;
            ped._Cod_tipo_alimento = Convert.ToInt32(cod_alimento);
            ped._Nom_tipo_alimento = nom_alimento;

            return var.Registrar_alimentos_especiales(ped, tipo);
        }

        public string Registrar_Pedido(string user, string cod_cama, string cod_paciente)
        {


            ped._User_crea = user;
            ped._Cod_cama = cod_cama;
            ped._Cod_paciente = Convert.ToInt32(cod_paciente);

            return var.Registrar_Pedido_nue(ped);
        }

        public string Registrar_Observaciones(string user,string cod_paciente ,string descripcion)
        {


            ped._User_crea = user;
            ped._Cod_paciente = Convert.ToInt32(cod_paciente);
            ped._Observaciones = descripcion;

            return var.Registrar_Observaciones(ped);
        }

        public string Modificar_Observaciones(string user, string cod_paciente, string descripcion)
        {


            ped._User_crea = user;
            ped._Cod_paciente = Convert.ToInt32(cod_paciente);
            ped._Observaciones = descripcion;

            return var.Modificar_Observaciones(ped);
        }

        public string Registrar_Nutrientes(int cod_menu, string cod_nutrientes)
        {

            ped._Id = cod_menu;
            ped._Nom_tipo_nutrientes = cod_nutrientes;


            return var.Registrar_Nutrientes(ped);
        }


        public string Modificar_Pedido(string cod_pedido,string consistencia, string digestabilidad, string aporte_nutrientes, string volumen,
             string temperatura, string tipo_sales,  string diagnostico, string amnesis, string observacion, string user, string cod_cama, string cod_paciente)
        {
            ped._Id = Convert.ToInt32(cod_pedido);
            ped._Cod_tipo_consistencia = Convert.ToInt32(consistencia);
            ped._Cod_tipo_digestabilidad = Convert.ToInt32(digestabilidad);
            ped._Cod_tipo_aporte_nutrientes = Convert.ToInt32(aporte_nutrientes);
            ped._Cod_tipo_volumen = Convert.ToInt32(volumen);
            ped._Cod_tipo_temperatura = Convert.ToInt32(temperatura);
            ped._Cod_tipo_sales = Convert.ToInt32(tipo_sales);
            ped._Diagnostico = diagnostico;
            ped._Amnesis_alim = amnesis;
            ped._User_modifica = user;
            ped._Observaciones = observacion;
            ped._Cod_cama = cod_cama;
            ped._Cod_paciente = Convert.ToInt32(cod_paciente);



            return var.Modificar_Pedido(ped);
        }



        public string Modificar_Nutrientes(int cod_menu, string cod_nutrientes,string estado)
        {

            ped._Id = cod_menu;
            ped._Cod_tipo_nutrientes = Convert.ToInt32(cod_nutrientes);
            ped._Est_tipo_nutrientes = estado;
            return var.Modificar_Nutrientes(ped);
        }



        public string Eliminar_Nutrientes(int cod_pedido)
        {
            return var.Eliminar_Nutrientes(cod_pedido);
        }


        public string Cambiar_estado(string cod_pedido, int valor)
        {
            return var.Cambiar_estado(cod_pedido, valor);
        }

        public string Cambiar_menu()
        {
            return var.Cambiar_menu();
        }

        public string Cambiar_estado_pedido(string fecha)
        {
            return var.Cambiar_estado_pedido(fecha);
        }
    }
}
