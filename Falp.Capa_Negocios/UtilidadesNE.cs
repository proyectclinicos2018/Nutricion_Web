using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falp.Entidades;
using Falp.Capa_Datos;

namespace Falp.Capa_Negocios
{
   public  class UtilidadesNE
    {
        string res = "";
        UtilidadesDA var = new UtilidadesDA();
       

        public List<Utilidades> Cargartipo_bus() 
        {
            return var.Cargar_tipo_bus();
        }

        public List<Utilidades> Cargartipo_doc()
        {
            return var.Cargar_tipo_doc();
        }

        public List<Utilidades> Cargartipo_consistencia()
        {
            return var.Cargar_tipo_consistencia();
        }

        public List<Utilidades> Cargartipo_digestabilidad()
        {
            return var.Cargar_tipo_digestabilidad();
        }

        public List<Utilidades> Cargartipo_aporte_nutrientes()
        {
            return var.Cargar_tipo_aporte_nutrientes();
        }

        public List<Utilidades> Cargartipo_volumen()
        {
            return var.Cargar_tipo_volumen();
        }

        public List<Utilidades> Cargartipo_temperatura()
        {
            return var.Cargar_tipo_temperatura();
        }

        public List<Utilidades> Cargartipo_dulzor()
        {
            return var.Cargar_tipo_dulzor();
        }

        public List<Utilidades> Cargartipo_lactosa()
        {
            return var.Cargar_tipo_lactosa();
        }

        public List<Utilidades> Cargartipo_sales()
        {
            return var.Cargar_tipo_sales();
        }

    
        public List<Utilidades> Cargarservicio()
        {
            return var.Cargarservicio();
        }

        public List<Utilidades> Cargarturno()
        {
            return var.Cargarturno();
        }

        public List<Utilidades> Cargarestado()
        {
            return var.Cargarestado();
        }
        public List<Utilidades> Cargartipo_nutrientes()
        {
            return var.Cargar_tipo_nutrientes();
        }


        public List<Utilidades> Cargarregimen()
        {
            return var.Cargarregimen();
        }

        public List<Utilidades> Cargarbandeja()
        {
            return var.Cargarbandeja();
        }

        public List<Utilidades> Cargaraislamiento()
        {
            return var.Cargaraislamiento();
        }

        public List<Utilidades> Cargartipo_nutrientes_pedido(int cod_pedido)
        {
            return var.Cargar_tipo_nutrientes_pedido(cod_pedido);
        }

        public List<Utilidades> Cargartipo_comida()
        {
            return var.Cargar_tipo_comida();
        }
        public List<Utilidades> Cargaralimentos_pedido(int cod_pedido)
        {
            return var.Cargar_alimentos_pedido(cod_pedido);
        }

        public List<Utilidades> Cargartipo_distribucion(int cod_tipo_comida)
        {
            return var.Cargar_tipo_distribucion(cod_tipo_comida);
        }

        public List<Utilidades> Cargartipo_alimento(int cod_tipo_distribucion)
        {
            return var.Cargar_tipo_alimento(cod_tipo_distribucion);
        }

      
        public List<Utilidades> Cargar_alimentos_menu(int cod_tipo_comida,int cod_tipo_distribucion,int cod_cobro,int cod_consistencia,int cod_digestabilidad,int cod_sal,int cod_lactosa,int cod_dulzor)
        {
            return var.Cargar_alimentos_menu(cod_tipo_comida, cod_tipo_distribucion, cod_cobro, cod_consistencia, cod_digestabilidad, cod_sal, cod_lactosa, cod_dulzor);
        }

        public List<Utilidades> Cargar_Colacion_Ant(int cod_tipo_comida, int cod_tipo_distribucion, int cod_menu)
        {
            return var.Cargar_Colacion_Ant(cod_tipo_comida, cod_tipo_distribucion, cod_menu);
        }

        public List<Utilidades> Cargar_Colacion_mat_noct(int cod_tipo_comida, int cod_tipo_distribucion)
        {
            return var.Cargar_Colacion_mat_noct(cod_tipo_comida, cod_tipo_distribucion);
        }


       //  metodo que buscar  las colaciones , desayuno y once 
        public List<Utilidades> Cargar_alimentos_menu_colacion( int cod_tipo_distribucion, int cod_cobro, int cod_consistencia, int cod_digestabilidad, int cod_sal, int cod_lactosa, int cod_dulzor,string descripcion)
        {
            return var.Cargar_alimentos_menu_colacion( cod_tipo_distribucion, cod_cobro, cod_consistencia, cod_digestabilidad, cod_sal, cod_lactosa, cod_dulzor,descripcion );
        }
    

        public List<Utilidades> Cargar_alimentos_menu_libre( int cod_tipo_distribucion,string  descripcion)
        {
            return var.Cargar_alimentos_menu_libre( cod_tipo_distribucion,  descripcion);
        }


        public List<Utilidades> Cargar_alimentos_menu_extra( int cod_tipo_comida, int cod_tipo_distribucion,string descripcion)
        {
            return var.Cargar_alimentos_menu_extra( cod_tipo_comida, cod_tipo_distribucion,descripcion);
        }

        public List<Utilidades> Cargar_alimentos_menu_especiales(int cod_tipo_comida, int cod_tipo_distribucion, string descripcion)
        {
            return var.Cargar_alimentos_menu_especiales(cod_tipo_comida, cod_tipo_distribucion, descripcion);
        }

        public List<Utilidades> Cargar_alimentos_especiales_cod( int cod_tipo_distribucion)
        {
            return var.Cargar_alimentos_especiales_cod( cod_tipo_distribucion);
        }


        public List<Utilidades> Cargar_alimentos_menu_extra_extra(int cod_tipo_distribucion,string  descripcion)
        {
            return var.Cargar_alimentos_menu_extra_extra( cod_tipo_distribucion, descripcion);
        }
     

        public Utilidades Extraer_componentes_alimento(string cod_alimento,string  cod_distribucion)
        {
            return var.Extraer_componentes_alimento(cod_alimento, cod_distribucion);
        }


        public List<Utilidades> Cargar_pedidos_registrados(int cod_pedido)
        {
            return var.Cargar_pedidos_registrados(cod_pedido);
        }

        public Utilidades Extraer_codigo_especial()
        {
            return var.Extraer_codigo_especial();
        }


       

      
    }
}
