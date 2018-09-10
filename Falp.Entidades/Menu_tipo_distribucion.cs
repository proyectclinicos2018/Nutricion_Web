using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Falp.Entidades
{
   public  class Menu_tipo_distribucion
    {
        protected int id;
        protected int cod_pedido_det;
        protected int cod_tipo_distribucion;
        protected string nom_tipo_distribucion;
        protected string user_crea;
        protected DateTime fecha_crea;
        protected string user_modifica;
        protected DateTime fecha_modifica;

        public int _Id
        {
            get { return id; }
            set { id = value; }
        }
        public int _Cod_pedido_det
        {
            get { return cod_pedido_det; }
            set { cod_pedido_det = value; }
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

         public Menu_tipo_distribucion()
        { }

         public Menu_tipo_distribucion(int id, int cod_pedido_det, int cod_tipo_distribucion, string nom_tipo_distribucion,
                                   string user_crea, DateTime fecha_crea,
                                   string user_modifica, DateTime fecha_modifica)
         {
             this._Id = id;
             this._Cod_pedido_det = cod_pedido_det;
             this._Cod_tipo_distribucion = cod_tipo_distribucion;
             this._Nom_tipo_distribucion = nom_tipo_distribucion;
             this._User_crea = user_crea;
             this._Fecha_crea = fecha_crea;
             this._User_modifica = user_modifica;
             this._Fecha_modifica = fecha_modifica;
         }
    }
}
