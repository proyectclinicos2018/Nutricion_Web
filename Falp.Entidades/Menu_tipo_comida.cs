using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Falp.Entidades
{
   public  class Menu_tipo_comida
    {

        protected int id;
        protected int cod_pedido;
        protected int cod_tipo_comida;
        protected string nom_tipo_comida;
        protected string user_crea;
        protected DateTime fecha_crea;
        protected string user_modifica;
        protected DateTime fecha_modifica;

        public int _Id
        {
            get { return id; }
            set { id = value; }
        }
        public int _Cod_pedido
        {
            get { return cod_pedido; }
            set { cod_pedido = value; }
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

         public Menu_tipo_comida()
        { }

         public Menu_tipo_comida(int id, int cod_pedido, int cod_tipo_comida, string nom_tipo_comida,
                                   string user_crea, DateTime fecha_crea,
                                   string user_modifica, DateTime fecha_modifica)
         {
             this._Id = id;
             this._Cod_pedido = cod_pedido;
             this._Cod_tipo_comida = cod_tipo_comida;
             this._Nom_tipo_comida = nom_tipo_comida;
             this._User_crea = user_crea;
             this._Fecha_crea = fecha_crea;
             this._User_modifica = user_modifica;
             this._Fecha_modifica = fecha_modifica;
         }
    }
}
