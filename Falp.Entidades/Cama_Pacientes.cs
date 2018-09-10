using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Falp.Entidades
{
   public  class Cama_Pacientes:Pacientes
    {
         private int id;
         private string num_cama;
         private string cod_cama;
         private string cod_habitacion;
         private string nom_habitacion;
         private string cod_servicio;
         private string nom_servicio;
         private string cod_paciente;
         private string nom_paciente;
         private string estado;
         private string nom_estado;
         private string estado_cama;
         protected int cod_menu;
         protected int cod_turno;
         protected string nom_turno;
         protected int cod_tipo_comida;
         protected string nom_tipo_comida;
         protected int cod_tipo_alimento;
         protected string nom_tipo_alimento;
         protected int cod_tipo_distribucion;
         protected string nom_tipo_distribucion;
         private int cantidad;
         private string fecha_hosp;
         private  string fecha_alta;
         private string fecha_pedido;
         private string ingesta;
         private string vale_impreso;
         private string vigencia_comida;
         private string vigencia_alimento;
         private string hora;

         public int _Cod_menu
         {
             get { return cod_menu; }
             set { cod_menu = value; }
         }

         public int _Cod_tipo_comida
         {
             get { return cod_tipo_comida; }
             set { cod_tipo_comida = value; }
         }

         public string _Nom_tipo_comida
         {
             get { return nom_tipo_comida; }
             set { nom_tipo_comida = value; }
         }

 
         public int _Cod_tipo_distribucion
         {
             get { return cod_tipo_distribucion; }
             set { cod_tipo_distribucion = value; }
         }

         public string _Nom_tipo_distribucion
         {
             get { return nom_tipo_distribucion; }
             set { nom_tipo_distribucion = value; }
         }

  
         public int _Cod_tipo_alimento
         {
             get { return cod_tipo_alimento; }
             set { cod_tipo_alimento = value; }
         }

         public string _Nom_tipo_alimento
         {
             get { return nom_tipo_alimento; }
             set { nom_tipo_alimento = value; }
         }

         public int _Cod_turno
         {
             get { return cod_turno; }
             set { cod_turno = value; }
         }



         public string _Nom_turno
         {
             get { return nom_turno; }
             set { nom_turno = value; }
         }

        public int _Id
        {
            get { return id; }
            set { id = value; }
        }

        public string _Num_cama
        {
            get { return num_cama; }
            set { num_cama = value; }
        }
        public string _Cod_cama
        {
            get { return cod_cama; }
            set { cod_cama = value; }
        }

        public string _Cod_habitacion
        {
            get { return cod_habitacion; }
            set { cod_habitacion = value; }
        }

        public string _Nom_habitacion
        {
            get { return nom_habitacion; }
            set { nom_habitacion = value; }
        }

        public string _Cod_servicio
        {
            get { return cod_servicio; }
            set { cod_servicio = value; }
        }

        public string _Nom_servicio
        {
            get { return nom_servicio; }
            set { nom_servicio = value; }
        }


        public string _Cod_paciente
        {
            get { return cod_paciente; }
            set { cod_paciente = value; }
        }

        public string _Nom_paciente
        {
            get { return nom_paciente; }
            set { nom_paciente = value; }
        }

        public string _Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string _Nom_estado
        {
            get { return nom_estado; }
            set { nom_estado = value; }
        }


        public string _Estado_cama
        {
            get { return estado_cama; }
            set { estado_cama = value; }
        }

        public int _Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }


        public string _Fecha_hosp
        {
            get { return fecha_hosp; }
            set { fecha_hosp = value; }
        }
        public string _Fecha_pedido
        {
            get { return fecha_pedido; }
            set { fecha_pedido = value; }
        }

        public string _Fecha_alta
        {
            get { return fecha_alta; }
            set { fecha_alta = value; }
        }

        public string _Ingesta
        {
            get { return ingesta; }
            set { ingesta = value; }
        }

        public string _Vale_impreso
        {
            get { return vale_impreso; }
            set { vale_impreso = value; }
        }

        public string _Vigencia_comida
        {
            get { return vigencia_comida; }
            set { vigencia_comida = value; }
        }
        public string _Vigencia_alimento
        {
            get { return vigencia_alimento; }
            set { vigencia_alimento = value; }
        }
        public string _Hora
        {
            get { return hora; }
            set { hora = value; }
        }


        public Cama_Pacientes()
        { }

        public Cama_Pacientes(int id, string cod_cama, string cod_habitacion, string nom_habitacion, string cod_servicio, string nom_servicio, string cod_paciente, string nom_paciente, string num_cama, string estado, int cantidad, string nom_estado, int cod_menu, string fecha_hosp, string fecha_alta,string fecha_pedido, string ingesta, string vale_impreso,string vigencia_comida,string vigencia_alimento,string hora)
        {
            this._Id = id;
            this._Num_cama = num_cama;
            this._Cod_cama = cod_cama;
            this._Cod_habitacion = cod_habitacion;
            this._Nom_habitacion = nom_habitacion;
            this._Cod_servicio = cod_servicio;
            this._Nom_servicio = nom_servicio;
            this._Cod_paciente = cod_paciente;
            this._Nom_paciente = nom_paciente;
            this._Estado = estado;
            this._Nom_estado = nom_estado;
            this._Cantidad = cantidad;
            this._Cod_menu = cod_menu;
            this._Fecha_hosp = fecha_hosp;
            this._Fecha_alta = fecha_alta;
            this._Fecha_pedido = fecha_pedido;
            this._Ingesta = ingesta;
            this._Vale_impreso = vale_impreso;
            this._Vigencia_comida = vigencia_comida;
            this._Vigencia_alimento = vigencia_alimento;
            this._Hora = hora;

        }


    }
}
