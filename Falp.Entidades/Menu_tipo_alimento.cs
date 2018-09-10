using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Falp.Entidades
{
    public class Menu_tipo_alimento
    {
        protected int id;
        protected int cod_pedido_reg_det;
        protected int cod_tipo_distribucion;
        protected string nom_tipo_distribucion;
        protected int cod_tipo_alimentos;
        protected string nom_tipo_alimentos;
        protected int cantidad;
        protected string vigencia;
        protected string estado;
        protected string user_crea;
        protected DateTime fecha_crea;
        protected string user_modifica;
        protected DateTime fecha_modifica;
     


        //  datos tipo comida  
        protected int cod_pedido;
        protected int cod_tipo_comida;
        protected double calorias;
        protected double proteinas;
        protected double lipidos;
        protected double hyc;
        protected double sodio;
        protected int ing_id;
        protected double ing_calorias;
        protected double ing_proteinas;
        protected double ing_lipidos;
        protected double ing_hyc;
        protected double ing_sodio;

        protected int hc;
        protected double gr_i;
        protected string ing_gr_c;
        protected double cc_i;
        protected string ing_cc_c;
        protected string ing_cc_total;

        protected double ajuste_calorias;
        protected double ajuste_proteinas;
        protected double ajuste_lipidos;
        protected double ajuste_hyc;
        protected double ajuste_sodio;
        protected double ajuste_cc_c;
        protected double ajuste_cc_total;
        protected int porcentaje;
        protected string mixto;


        protected double sub_calorias;
        protected double sub_proteinas;
        protected double sub_lipidos;
        protected double sub_hyc;
        protected double sub_sodio;
        protected double sub_cc_total;
       

        public int _Id
        {
            get { return id; }
            set { id = value; }
        }

        public int _Ing_id
        {
            get { return ing_id; }
            set {ing_id = value; }
        }
        public int _Cod_pedido_reg_det
        {
            get { return cod_pedido_reg_det; }
            set { cod_pedido_reg_det= value; }
        }

        public int _Cod_tipo_alimentos
        {
            get { return cod_tipo_alimentos; }
            set { cod_tipo_alimentos = value; }
        }



        public string _Nom_tipo_alimentos
        {
            get { return nom_tipo_alimentos; }
            set { nom_tipo_alimentos = value; }
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

        public string _Mixto
        {
            get { return mixto; }
            set { mixto = value; }
        }

        public string _Estado
        {
            get { return estado; }
            set { estado = value; }
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

        public double _Calorias
        {
            get { return calorias; }
            set { calorias = value; }
        }


        public double _Proteinas
        {
            get { return proteinas; }
            set { proteinas = value; }
        }

        public double _Lipidos
        {
            get { return lipidos; }
            set { lipidos = value; }
        }
        public double _Hyc
        {
            get { return hyc; }
            set { hyc = value; }
        }

        public double _Sodio
        {
            get { return sodio; }
            set { sodio = value; }
        }


 // ingestas 

        public double _Ing_calorias
        {
            get { return ing_calorias; }
            set { ing_calorias = value; }
        }


        public double _Ing_proteinas
        {
            get { return ing_proteinas; }
            set { ing_proteinas = value; }
        }

        public double _Ing_lipidos
        {
            get { return ing_lipidos; }
            set { ing_lipidos = value; }
        }
        public double _Ing_hyc
        {
            get { return ing_hyc; }
            set { ing_hyc = value; }
        }

        public double _Ing_sodio
        {
            get { return ing_sodio; }
            set { ing_sodio = value; }
        }

        public int _Porcentaje
        {
            get { return porcentaje; }
            set { porcentaje = value; }
        }

//--------------------------------

        public int _Hc
        {
            get { return hc; }
            set { hc = value; }
        }

        public double _Gr_i
        {
            get { return gr_i; }
            set { gr_i = value; }
        }

        public string _Ing_gr_c
        {
            get { return ing_gr_c; }
            set { ing_gr_c = value; }
        }

        public double _Cc_i
        {
            get { return cc_i; }
            set { cc_i = value; }
        }

        public string _Ing_cc_c
        {
            get { return ing_cc_c; }
            set { ing_cc_c = value; }
        }
        public string _Ing_cc_total
        {
            get { return ing_cc_total; }
            set { ing_cc_total = value; }
        }

        public double _Ajuste_calorias
        {
            get { return ajuste_calorias; }
            set { ajuste_calorias = value; }
        }
        public double _Ajuste_proteinas
        {
            get { return ajuste_proteinas; }
            set { ajuste_proteinas = value; }
        }

        public double _Ajuste_lipidos
        {
            get { return ajuste_lipidos; }
            set { ajuste_lipidos = value; }
        }
        public double _Ajuste_hyc
        {
            get { return ajuste_hyc; }
            set { ajuste_hyc = value; }
        }

        public double _Ajuste_sodio
        {
            get { return ajuste_sodio; }
            set { ajuste_sodio = value; }
        }

        public double _Ajuste_cc_c
        {
            get { return ajuste_cc_c; }
            set { ajuste_cc_c = value; }
        }

        public double _Ajuste_cc_total
        {
            get { return ajuste_cc_total; }
            set { ajuste_cc_total = value; }
        }


        public double _Sub_calorias
        {
            get { return sub_calorias; }
            set { sub_calorias = value; }
        }
        public double _Sub_proteinas
        {
            get { return sub_proteinas; }
            set { sub_proteinas = value; }
        }

        public double _Sub_lipidos
        {
            get { return sub_lipidos; }
            set { sub_lipidos = value; }
        }
        public double _Sub_hyc
        {
            get { return sub_hyc; }
            set { sub_hyc = value; }
        }

        public double _Sub_sodio
        {
            get { return sub_sodio; }
            set { sub_sodio = value; }
        }



        public double _Sub_cc_total
        {
            get { return sub_cc_total; }
            set { sub_cc_total = value; }
        }
  
       

         public Menu_tipo_alimento()
        { }

         public Menu_tipo_alimento(int id, int cod_pedido_reg_det, int cod_tipo_alimentos, string nom_tipo_alimentos,int cantidad,string vigencia, string estado, int cod_tipo_distribucion,string nom_tipo_distribucion,
                                   string user_crea, DateTime fecha_crea,string user_modifica, DateTime fecha_modifica,string mixto, int ing_calorias, int ing_proteinas, int ing_lipidos, int ing_hyc , int  ing_sodio,int  ing_id,
                                   double gr_i, string ing_gr_c, double cc_i, string ing_cc_c, string ing_cc_total, double calorias, double proteinas, double lipidos, double hyc, double sodio, int cod_pedido, int cod_tipo_comida,
                                   double ajuste_calorias, double ajuste_proteinas, double ajuste_lipidos, double ajuste_hyc, double ajuste_sodio, double ajuste_cc_c, double ajuste_cc_total, int porcentaje,
                                   double sub_calorias, double sub_proteinas, double sub_lipidos, double sub_hyc, double sub_sodio, double sub_cc_c, double sub_cc_total)
         {
             this._Id = id;
             this._Cod_pedido_reg_det = cod_pedido_reg_det;
             this._Cod_tipo_alimentos = cod_tipo_alimentos;
             this._Nom_tipo_alimentos = nom_tipo_alimentos;
             this._Cod_tipo_distribucion = cod_tipo_distribucion;
             this._Nom_tipo_distribucion = nom_tipo_distribucion;
             this._Cantidad = cantidad;
             this._Vigencia=vigencia;
             this._Estado = estado;
             this._User_crea = user_crea;
             this._Fecha_crea = fecha_crea;
             this._User_modifica = user_modifica;
             this._Fecha_modifica = fecha_modifica;
             this._Gr_i= gr_i;
             this._Ing_gr_c = ing_gr_c;
             this._Gr_i = gr_i;
             this._Cc_i = cc_i;
             this._Ing_cc_c = ing_cc_c;
             this._Ing_cc_total = ing_cc_total;
             this._Calorias = calorias;
             this._Proteinas = proteinas;
             this._Lipidos = lipidos;
             this._Hyc = hyc;
             this._Sodio = sodio;
             this._Ing_calorias = ing_calorias;
             this._Ing_proteinas = ing_proteinas;
             this._Ing_lipidos = ing_lipidos;
             this._Ing_hyc = ing_hyc;
             this._Ing_sodio = sodio;
             this._Cod_pedido = cod_pedido;
             this._Cod_tipo_comida = cod_tipo_comida;
             this._Ajuste_proteinas = ajuste_proteinas;
             this._Ajuste_lipidos = ajuste_lipidos;
             this._Ajuste_hyc = ajuste_hyc;
             this._Ajuste_sodio = ajuste_sodio;
             this._Ajuste_cc_c = ajuste_cc_c;
             this._Ajuste_cc_total = ajuste_cc_total;


             this._Sub_proteinas = sub_proteinas;
             this._Sub_lipidos = sub_lipidos;
             this._Sub_hyc = sub_hyc;
             this._Sub_sodio = sub_sodio;
             this._Sub_cc_total = sub_cc_total;
             this._Mixto = mixto;
             this._Ing_id = ing_id;
             this._Porcentaje = porcentaje;
             
         }
    }
}
