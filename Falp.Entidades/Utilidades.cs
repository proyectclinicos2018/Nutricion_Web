using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Falp.Entidades
{
   public  class Utilidades:Cama_Pacientes
    {
       protected int cod_tipo_bus;
       protected string nom_tipo_bus;
       protected int cod_tipo_doc;
       protected string nom_tipo_doc;
       protected int cod_tipo_consistencia;
       protected string nom_tipo_consistencia;
       protected int cod_tipo_digestabilidad;
       protected string nom_tipo_digestabilidad;
       protected int cod_tipo_aporte_nutrientes;
       protected string nom_tipo_aporte_nutrientes;
       protected int cod_tipo_volumen;
       protected string nom_tipo_volumen;
       protected int cod_tipo_temperatura;
       protected string nom_tipo_temperatura;
       protected int cod_tipo_sales;
       protected string nom_tipo_sales;
       protected string no_sal;
       protected string no_dulzor;
       protected string no_lactosa;

       protected int cod_consistencia_pref;
       protected int cod_digestabilidad_pref;
       protected int cod_sales_pref;
       protected int cod_dulzor_pref;
       protected int cod_lactosa_pref;

       protected int id_tipo_nutrientes;
       protected int cod_tipo_nutrientes;
       protected string nom_tipo_nutrientes;
       protected string est_tipo_nutrientes;


       protected int id_tipo_comida;
       protected int cod_tipo_comida;
       protected string nom_tipo_comida;

       protected int cod_servicio;
       protected string nom_servicio;

       protected int cod_estado;
       protected string nom_estado;

       protected int id_tipo_distribucion;
       protected int cod_tipo_distribucion;
       protected string nom_tipo_distribucion;

       protected int id_tipo_alimento;
       protected int cod_tipo_alimento;
       protected string nom_tipo_alimento;
       protected int cantidad;
       protected string vigencia;
       protected string estado;

       /*****  Dulzor  ******/
       protected int cod_dulzor;
       protected string nom_dulzor;

       /*****  lactosa  ******/
       protected int cod_lactosa;
       protected string nom_lactosa;

  

       /*****  REGIMEN ******/
       protected int cod_regimen;
       protected string nom_regimen;

  

       /*****  aislamiento ******/
       protected int cod_aislamiento;
       protected string nom_aislamiento;

       /*****  bandeja ******/
       protected int cod_bandeja;
       protected string nom_bandeja;

       /*****  turno ******/
       protected int cod_turno;
       protected string nom_turno;

       /*****  turno ******/
       protected int cod_alimento;
       protected string nom_alimento;

       protected int cod_alimento_especial;
       protected string nom_alimento_especial;
       protected string observacion;
       protected string comentario_tipo_comida;
       protected string vale_impreso;
       protected string ingesta;
       protected string mixto;

       /***** ingesta ******/



        public int _Cod_tipo_bus
        {
            get { return cod_tipo_bus; }
            set { cod_tipo_bus = value; }
        }

        public string _Nom_tipo_bus
        {
            get { return nom_tipo_bus; }
            set { nom_tipo_bus = value; }
        }


        public int _Cod_tipo_doc
        {
            get { return cod_tipo_doc; }
            set { cod_tipo_doc = value; }
        }

        public string _Nom_tipo_doc
        {
            get { return nom_tipo_doc; }
            set { nom_tipo_doc = value; }
        }
        public int _Cod_tipo_consistencia
        {
            get { return cod_tipo_consistencia; }
            set { cod_tipo_consistencia = value; }
        }

        public string _Nom_tipo_consistencia
        {
            get { return nom_tipo_consistencia; }
            set { nom_tipo_consistencia = value; }
        }

        public int _Cod_tipo_digestabilidad
        {
            get { return cod_tipo_digestabilidad; }
            set { cod_tipo_digestabilidad = value; }
        }

        public string _Nom_tipo_digestabilidad
        {
            get { return nom_tipo_digestabilidad; }
            set { nom_tipo_digestabilidad = value; }
        }

        public string _Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }


        public int _Cod_tipo_aporte_nutrientes
        {
            get { return cod_tipo_aporte_nutrientes; }
            set { cod_tipo_aporte_nutrientes = value; }
        }

        public string _Nom_tipo_aporte_nutrientes
        {
            get { return nom_tipo_aporte_nutrientes; }
            set { nom_tipo_aporte_nutrientes = value; }
        }

        public int _Cod_tipo_volumen
        {
            get { return cod_tipo_volumen; }
            set { cod_tipo_volumen = value; }
        }

        public string _Nom_tipo_volumen
        {
            get { return nom_tipo_volumen; }
            set { nom_tipo_volumen = value; }
        }


        public int _Cod_tipo_temperatura
        {
            get { return cod_tipo_temperatura; }
            set { cod_tipo_temperatura = value; }
        }

        public string _Nom_tipo_temperatura
        {
            get { return nom_tipo_temperatura; }
            set { nom_tipo_temperatura = value; }
        }

        public int _Cod_tipo_sales
        {
            get { return cod_tipo_sales; }
            set { cod_tipo_sales = value; }
        }

        public string _Nom_tipo_sales
        {
            get { return nom_tipo_sales; }
            set { nom_tipo_sales = value; }
        }

   

        public int _Id_tipo_nutrientes
        {
            get { return id_tipo_nutrientes; }
            set { id_tipo_nutrientes = value; }
        }


        public int _Id_tipo_comida
        {
            get { return id_tipo_comida; }
            set { id_tipo_comida = value; }
        }


        public int _Cod_tipo_nutrientes
        {
            get { return cod_tipo_nutrientes; }
            set { cod_tipo_nutrientes = value; }
        }

        public string _Nom_tipo_nutrientes
        {
            get { return nom_tipo_nutrientes; }
            set { nom_tipo_nutrientes = value; }
        }
        public string _Est_tipo_nutrientes
        {
            get { return est_tipo_nutrientes; }
            set { est_tipo_nutrientes = value; }
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

        public int _Id_tipo_distribucion
        {
            get { return id_tipo_distribucion; }
            set { id_tipo_distribucion = value; }
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

        public int _Id_tipo_alimento
        {
            get { return id_tipo_alimento; }
            set { id_tipo_alimento = value; }
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

        public int _Cod_alimento
        {
            get { return cod_alimento; }
            set { cod_alimento = value; }
        }

        public string _Nom_alimento
        {
            get { return nom_alimento; }
            set { nom_alimento = value; }
        }

        public int _Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public string _Vigencia
        {
            get { return vigencia; }
            set { vigencia = value; }
        }

        public string _Estado
        {
            get { return estado; }
            set { estado = value; }
        }



        public int _Cod_servicio
        {
            get { return cod_servicio; }
            set { cod_servicio = value; }
        }

        public string _Nom_servicio
        {
            get { return nom_servicio; }
            set { nom_servicio = value; }
        }
        public int _Cod_estado
        {
            get { return cod_estado; }
            set { cod_estado = value; }
        }

        public string _Nom_estado
        {
            get { return nom_estado; }
            set { nom_estado= value; }
        }



        public int _Cod_regimen
        {
            get { return cod_regimen; }
            set { cod_regimen = value; }
        }

        public string _Nom_regimen
        {
            get { return nom_regimen; }
            set { nom_regimen = value; }
        }
        public int _Cod_bandeja
        {
            get { return cod_bandeja; }
            set { cod_bandeja = value; }
        }

        public string _Nom_bandeja
        {
            get { return nom_bandeja; }
            set { nom_bandeja = value; }
        }


        public int _Cod_aislamiento
        {
            get { return cod_aislamiento; }
            set { cod_aislamiento = value; }
        }

        public string _Nom_aislamiento
        {
            get { return nom_aislamiento; }
            set { nom_aislamiento = value; }
        }

        public int _Cod_dulzor
        {
            get { return cod_dulzor; }
            set { cod_dulzor = value; }
        }

        public string _Nom_dulzor
        {
            get { return nom_dulzor; }
            set { nom_dulzor = value; }
        }

        public int _Cod_lactosa
        {
            get { return cod_lactosa; }
            set { cod_lactosa = value; }
        }

        public string _Nom_lactosa
        {
            get { return nom_lactosa; }
            set { nom_lactosa = value; }
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

        public int _Cod_alimento_especial
        {
            get { return cod_alimento_especial; }
            set { cod_alimento_especial = value; }
        }

        public string _Nom_alimento_especial
        {
            get { return nom_alimento_especial; }
            set { nom_alimento_especial = value; }
        }

        public string _Comentario_tipo_comida
        {
            get { return comentario_tipo_comida; }
            set { comentario_tipo_comida = value; }
        }

        public string _Vale_impreso
        {
            get { return vale_impreso; }
            set { vale_impreso = value; }
        }

        public string _Ingesta
        {
            get { return ingesta; }
            set { ingesta = value; }
        }
        public string _Mixto
        {
            get { return mixto; }
            set { mixto = value; }
        }

        public int _Cod_consistencia_pref
        {
            get { return cod_consistencia_pref; }
            set { cod_consistencia_pref = value; }
        }

        public int _Cod_digestabilidad_pref
        {
            get { return cod_digestabilidad_pref; }
            set { cod_digestabilidad_pref = value; }
        }

        public int _Cod_dulzor_pref
        {
            get { return cod_dulzor_pref; }
            set { cod_dulzor_pref = value; }
        }

        public int _Cod_sales_pref
        {
            get { return cod_sales_pref; }
            set { cod_sales_pref = value; }
        }

        public int _Cod_lactosa_pref
        {
            get { return cod_lactosa_pref; }
            set { cod_lactosa_pref = value; }
        }

        public string  _No_sal
        {
            get { return no_sal; }
            set {  no_sal = value; }
        }
        public string _No_dulzor
        {
            get { return no_dulzor; }
            set { no_dulzor = value; }
        }

        public string _No_lactosa
        {
            get { return no_lactosa; }
            set { no_lactosa = value; }
        }

  
  
  
  

        public Utilidades()
        { }

        public Utilidades(int cod_tipo_bus,string nom_tipo_bus,
                          int cod_tipo_doc, string nom_tipo_doc,
                          int cod_tipo_consistencia, string nom_tipo_consistencia,
                          int cod_tipo_digestabilidad, string nom_tipo_digestabilidad,
                          int cod_tipo_aporte_nutrientes, string nom_tipo_aporte_nutrientes,
                          int cod_tipo_volumen, string nom_tipo_volumen,
                          int cod_tipo_temperatura, string nom_tipo_temperatura,
                          int cod_tipo_sales, string nom_tipo_sales,string ingesta,
                          int id_tipo_nutrientes,int cod_tipo_nutrientes, string nom_tipo_nutrientes, string est_tipo_nutrientes,
                          int id_tipo_comida, int cod_tipo_comida, string nom_tipo_comida,
                          int id_tipo_distribucion,int cod_tipo_distribucion, string nom_tipo_distribucion,
                          int cod_tipo_alimento, string nom_tipo_alimento,
                          int cod_alimento, string nom_alimento,
                          int cod_servicio, string nom_servicio,
                          int cod_estado, string nom_estado,
                          string  vale_impreso,
                          int cod_regimen, string nom_regimen,
                          int cod_aislamiento, string nom_aislamiento,
                          int cod_bandeja, string nom_bandeja,
                          int cod_dulzor, string nom_dulzor,
                          int cod_lactosa, string nom_lactosa,
                          int cod_turno, string nom_turno,
                          int cod_alimento_especial, string nom_alimento_especial,
                          int id_tipo_alimento, int cantidad, string vigencia, string estado,
                          string comentario_tipo_comida,
                          string mixto, string no_sal,string  no_lactosa, string no_dulzor,
                          int cod_sal_pref, int cod_lactosas_pref, int cod_dulzor_pref, int cod_consistencia_pref, int cod_digestabilidad_pref
            
            )

        {
            this._Cod_tipo_bus = cod_tipo_bus;
            this._Nom_tipo_bus = nom_tipo_bus;
            this._Cod_tipo_doc = cod_tipo_doc;
            this._Nom_tipo_doc = nom_tipo_doc;
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

            this._Id_tipo_nutrientes = id_tipo_nutrientes;
            this._Cod_tipo_nutrientes = cod_tipo_nutrientes;
            this._Nom_tipo_nutrientes = nom_tipo_nutrientes;
            this._Est_tipo_nutrientes = est_tipo_nutrientes;
            this._Id_tipo_comida = id_tipo_comida;
            this._Cod_tipo_comida = cod_tipo_comida;
            this._Nom_tipo_comida = nom_tipo_comida;

            this._Id_tipo_distribucion = id_tipo_distribucion;
            this._Cod_tipo_distribucion = cod_tipo_distribucion;
            this._Nom_tipo_distribucion = nom_tipo_distribucion;

            this._Id_tipo_alimento = id_tipo_alimento;
            this._Cod_tipo_alimento = cod_tipo_alimento;
            this._Nom_tipo_alimento = nom_tipo_alimento;

            this._Cod_alimento = cod_alimento;
            this._Nom_alimento = nom_alimento;

            this._Cod_servicio = cod_servicio;
            this._Nom_servicio = nom_servicio;
            this._Cod_estado = cod_estado;
            this._Nom_estado = nom_estado;

  

            this._Cod_regimen = cod_regimen;
            this._Nom_regimen = nom_regimen;

            this._Cod_bandeja = cod_bandeja;
            this._Nom_bandeja = nom_bandeja;

            this._Cod_aislamiento = cod_aislamiento;
            this._Nom_aislamiento = nom_aislamiento;

            this._Cod_lactosa = cod_lactosa;
            this._Nom_lactosa = nom_lactosa;

            this._Cod_dulzor = cod_dulzor;
            this._Nom_dulzor = nom_dulzor;

            this._Cod_turno = cod_turno;
            this._Nom_turno = nom_turno;

            this._Cod_alimento_especial = cod_alimento_especial;
            this._Nom_alimento_especial = nom_alimento_especial;
 
            this._Cantidad = cantidad;
            this._Vigencia = vigencia;
            this._Estado = estado;
            this._Comentario_tipo_comida = comentario_tipo_comida;
            this._Vale_impreso = vale_impreso;
            this._Mixto = mixto;
            this._Ingesta = ingesta;
            this._No_sal = no_sal;
            this._No_lactosa = no_lactosa;
            this._No_dulzor = no_dulzor;
            this._Cod_lactosa_pref = cod_lactosa_pref;
            this._Cod_dulzor_pref = cod_dulzor_pref;
            this._Cod_sales_pref = cod_sal_pref;
            this._Cod_consistencia_pref = cod_consistencia_pref;
            this._Cod_digestabilidad_pref = cod_digestabilidad_pref;
   
        }


    }
}
