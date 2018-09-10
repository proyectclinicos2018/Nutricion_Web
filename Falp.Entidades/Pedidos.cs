using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Falp.Entidades
{
    public class Pedidos:Utilidades
    {

 
       protected int cod_pedido;
       protected int cod_paciente;
       protected string nom_paciente;
       protected string cod_cama;
       protected string num_cama;
       protected int cod_menu;
       protected int cod_tipo_menu;
       protected string  nom_tipo_menu;
       protected int dia;
       protected int regimen;
       protected int cod_opc_comida;
       protected string diagnostico;
       protected string amnesis_alim;
       protected string observaciones;
       protected string vigente;
       protected string user_crea;
       protected DateTime fecha_crea;
       protected string user_modifica;
       protected DateTime fecha_modifica;
       protected DateTime fecha_pedido;
       protected int id_opc_comida;
       protected string  cod_d;
       protected string cod_c1;
       protected string cod_a;
       protected string cod_o;
       protected string cod_c;
       protected string cod_c2;
       protected string cod_ce;
       protected string cod_hco;



       public int _Id_opc_comida
       {
           get { return id_opc_comida; }
           set { id_opc_comida = value; }
       }

       public int _Cod_pedido
       {
           get { return cod_pedido; }
           set { cod_pedido = value; }
       }
       public int _Cod_paciente
       {
           get { return cod_paciente; }
           set { cod_paciente = value; }
       }

       public string _Nom_paciente
       {
           get { return nom_paciente; }
           set { nom_paciente = value; }
       }

       public string _Cod_cama
       {
           get { return cod_cama; }
           set { cod_cama = value; }
       }

       public string _Num_cama
       {
           get { return num_cama; }
           set { num_cama = value; }
       }

       public int _Cod_menu
       {
           get { return cod_menu; }
           set { cod_menu = value; }
       }

       public int _Dia
       {
           get { return dia; }
           set { dia = value; }
       }
       public int _Regimen
       {
           get { return regimen; }
           set { regimen = value; }
       }

       public int _Cod_tipo_menu
       {
           get { return cod_tipo_menu; }
           set { cod_tipo_menu = value; }
       }
       public int _Cod_opc_comida
       {
           get { return cod_opc_comida; }
           set { cod_opc_comida = value; }
       }

          public string _Nom_tipo_menu
       {
           get { return nom_tipo_menu; }
           set { nom_tipo_menu = value; }
       }



       public string _Diagnostico
       {
           get { return diagnostico; }
           set { diagnostico = value; }
       }

       public string _Amnesis_alim
       {
           get { return amnesis_alim; }
           set { amnesis_alim = value; }
       }

       public string _Observaciones
       {
           get { return observaciones; }
           set { observaciones = value; }
       }

       public string _Vigente
       {
           get { return vigente; }
           set { vigente = value; }
       }
       public string _User_crea
       {
           get { return user_crea; }
           set { user_crea = value; }
       }

       public DateTime _Fecha_crea
       {
           get { return fecha_crea; }
           set { fecha_crea = value; }
       }

       public string _User_modifica
       {
           get { return user_modifica; }
           set { user_modifica = value; }
       }

       public DateTime _Fecha_modifica
       {
           get { return fecha_modifica; }
           set { fecha_modifica = value; }
       }

       public DateTime _Fecha_pedido
       {
           get { return fecha_pedido; }
           set { fecha_pedido = value; }
       }


       public string _Cod_d
       {
           get { return cod_d; }
           set { cod_d = value; }
       }
       public string _Cod_c1
       {
           get { return cod_c1; }
           set { cod_c1 = value; }
       }

       public string _Cod_a
       {
           get { return cod_a; }
           set { cod_a = value; }
       }

       public string _Cod_o
       {
           get { return cod_o; }
           set { cod_o = value; }
       }

       public string _Cod_c
       {
           get { return cod_c; }
           set { cod_c = value; }
       }

       public string _Cod_c2
       {
           get { return cod_c2; }
           set { cod_c2 = value; }
       }

       public string _Cod_ce
       {
           get { return cod_ce; }
           set { cod_ce = value; }
       }

       public string _Cod_hco
       {
           get { return cod_hco; }
           set { cod_hco = value; }
       }

       public Pedidos()
        { }

        public Pedidos(int cod_pedido,int cod_paciente,string nom_paciente,
                          string cod_cama, string num_cama,
                          int dia, int regimen,
                          int cod_menu, string num_menu,
                          string  diagnostico, string amnesis_ali ,
                          string  observacion, string vigencia,
                          int cod_tipo_consistencia, string nom_tipo_consistencia,
                          int cod_tipo_digestabilidad, string nom_tipo_digestabilidad,
                          int cod_tipo_aporte_nutrientes, string nom_tipo_aporte_nutrientes,
                          int cod_tipo_volumen, string nom_tipo_volumen,
                          int cod_tipo_temperatura, string nom_tipo_temperatura,
                          int cod_tipo_sales, string nom_tipo_sales,
                          int cod_opc_comida,
                          int cod_tipo_nutrientes, string nom_tipo_nutrientes,
                          string  user_crea, DateTime fecha_crea  ,int id_opc_comida,
                          string user_modifica, DateTime fecha_modifica,
                          int cod_tipo_menu, string  nom_tipo_menu,
                          string d,string c1,string a,string o,string c,
                          string c2,string ce,string hco,
                          DateTime fecha_pedido)

        {
            this._Cod_pedido = cod_pedido;
            this._Cod_paciente = cod_paciente;
            this._Nom_paciente = nom_paciente;
            this._Cod_cama = cod_cama;
            this._Num_cama = num_cama;
            this._Dia = dia;
            this._Regimen = regimen;
            this._Diagnostico = diagnostico;
            this._Amnesis_alim = amnesis_alim;
            this._Observaciones = observaciones;
            this._Cod_tipo_consistencia = cod_tipo_consistencia;
            this._Nom_tipo_consistencia = nom_tipo_consistencia;
            this._Cod_tipo_digestabilidad = cod_tipo_digestabilidad;
            this._Nom_tipo_digestabilidad = nom_tipo_digestabilidad;
            this._Cod_tipo_volumen = cod_tipo_volumen;
            this._Nom_tipo_volumen = nom_tipo_volumen;
            this._Cod_tipo_temperatura = cod_tipo_temperatura;
            this._Nom_tipo_temperatura = nom_tipo_temperatura;
            this._Cod_tipo_sales = cod_tipo_sales;
            this._Nom_tipo_sales = nom_tipo_sales;

            this._Cod_tipo_nutrientes = cod_tipo_nutrientes;
            this._Nom_tipo_nutrientes = nom_tipo_nutrientes;
            this._User_crea= user_crea;
            this._Fecha_crea =fecha_crea;
            this._User_modifica = user_modifica;
            this._Fecha_modifica =fecha_modifica;
            this._Fecha_pedido = fecha_pedido;
            this._Cod_tipo_menu= cod_tipo_menu;
            this._Nom_tipo_menu = nom_tipo_menu;
            this._Cod_opc_comida = cod_opc_comida;
            this._Cod_d = cod_d;
            this._Cod_c1 = cod_c1;
            this._Cod_a = cod_a;
            this._Cod_o = cod_o;
            this._Cod_c = cod_c;
            this._Cod_c2 = cod_c2;
            this._Cod_ce = cod_ce;
            this._Cod_hco = cod_hco;
            this._Id_opc_comida = id_opc_comida;
           
        }

    }
}
