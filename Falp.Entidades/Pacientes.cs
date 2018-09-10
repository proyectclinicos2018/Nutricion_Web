using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Falp.Entidades
{
   public  class Pacientes
    {

       protected int id_pac;
       protected int correlativo;
       private int cod_nhc;
       protected int ficha;
       protected int folio;
       protected string tipo_doc;
       protected string num_doc;
       protected string nombres;
       protected string apellidos;
 


       public int _Id_pac
       {
           get { return id_pac; }
           set { id_pac = value; }
       }
       public int _Correlativo
       {
           get { return correlativo; }
           set { correlativo = value; }
       }

       public int _Ficha
       {
           get { return ficha; }
           set { ficha = value; }
       }

       public int _Cod_nhc
       {
           get { return cod_nhc; }
           set { cod_nhc = value; }
       }


       public int _Folio
       {
           get { return folio; }
           set { folio = value; }
       }

       public string _Tipo_doc
       {
           get { return tipo_doc; }
           set { tipo_doc = value; }
       }

       public string _Num_doc
       {
           get { return num_doc; }
           set { num_doc = value; }
       }

       public string _Nombres
       {
           get { return nombres; }
           set { nombres = value; }
       }

       public string _Apellidos
       {
           get { return apellidos; }
           set { apellidos = value; }
       }


        public Pacientes()
        { }

        public Pacientes(int id,int correlativo ,int ficha, int folio,string tipo_doc, string num_doc,string nombres,int cod_nhc, string apellidos , int id_pac)

        {
            this._Id_pac = id_pac;
            this._Correlativo = correlativo;
            this._Ficha = ficha;
            this._Folio = folio;
            this._Tipo_doc= tipo_doc;
            this._Num_doc = num_doc;
            this._Nombres = nombres;
            this._Cod_nhc = cod_nhc;
            this._Apellidos = apellidos;
        }

    }
}
