using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Falp.Entidades;
using Falp.Capa_Negocios;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.Drawing;

namespace Falp.Oficial
{
    public partial class Generar_Ingesta : System.Web.UI.Page
    {

        #region Variables

        static string user = "";
        string rut = "";
        int cod_servicio = 0;
        int cod_estado = 0;
        int cod_turno = 0;
        int cod_tipo_comida = 0;
        int tipo_doc = 0;
        string fecha ="";
        static string cod_pedido = "0";
        static int cod_ingesta = 0;
        static string cod_cama = "";
        static int  cod_paciente = 0;
        static int cod_menu = 0;
        static string nom_paciente = "";
        static string taj_d = "";
       


        #region variables tipo comida

        static string var_cod_desayuno = "1";
        static string var_cod_colacion_matinal = "2";
        static string var_cod_almuerzo = "3";
        static string var_cod_once = "4";
        static string var_cod_cena = "5";
        static string var_cod_colacion_nocturna = "6";
        static string var_cod_colacion_extra = "7";
        static string var_cod_hidricos = "8";

        #endregion 
      
        #region variables totales

        static int var_f_c = 1;
        static int var_f_p = 2;
        static int var_f_l = 3;
        static int var_f_hyc = 4;
        static int var_f_s = 5;
        static int var_f_total = 6;

        static int res_f_c = 0;
        static int res_f_p = 0;
        static int res_f_l = 0;
        static int res_f_hyc = 0;
        static int res_f_s = 0;
        static int res_f_total = 0;
        

        #endregion 


        #region Variables de Ingesta

        static double gr_i = 0;
        static double gr_c = 0;

        static int calorias = 0;
        static int proteinas = 0;
        static int lipidos = 0;
        static int hyc = 0;
        static int sodio = 0;
        static double res_gr = 0;
        static  double res_c = 0;
        static double res_p = 0;
        static double res_l = 0;
        static double res_hyc = 0;
        static double res_s = 0;
        static double res_total = 0;
        static double res = 0;
        double cc_i = 0;
        double cc_c = 0;
        double cc_total = 0;
        double res_cc_c = 0;
        static int cchco_i = 0;



       


        // codigo ingesta

        static int cod_ing_d = 0;
        static int cod_ing_c1 = 0;
        static int cod_ing_a = 0;
        static int cod_ing_o = 0;
        static int cod_ing_c = 0;
        static int cod_ing_c2 = 0;
        static int cod_ing_ce = 0;
        static int cod_ing_hco = 0;

        #endregion 

        List<Cama_Pacientes> lista_cama_paciente = new List<Cama_Pacientes>();

        #endregion

        #region DataTable
       static  DataTable dt_listado_cama = new DataTable();
       static  DataTable dt_ingesta = new DataTable();
       static  DataTable dt_resumen = new DataTable();
       static DataTable dt_total = new DataTable();
       static DataTable dt_d = new DataTable();
       static DataTable dt_a = new DataTable();
       static DataTable dt_o = new DataTable();
       static DataTable dt_c = new DataTable();
       static DataTable dt_c1 = new DataTable();
       static DataTable dt_c2 = new DataTable();
       static DataTable dt_ce = new DataTable();
       static DataTable dt_hco = new DataTable();

        #endregion 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["Usuario"] != null)
                {

                    user = Session["Usuario"].ToString();
                    cod_pedido = Session["_Cod_pedido"].ToString();
              

                   cod_paciente = Convert.ToInt32(Session["Cod_Paciente"].ToString());
                   txtcama.Text = Session["Cama"].ToString();
                    txthabitacion.Text = Session["Habitacion"].ToString();
                    txtnombre.Text = Session["Nom_Paciente"].ToString();
                    txtservicio.Text = Session["Nom_Servicio"].ToString();
                    txtrut.Text= Session["Rut"].ToString();
                    txtficha.Text = Session["Ficha"].ToString();
                    fecha=Session["Fecha_pedido"].ToString();
                    txtcama.Enabled=false;
                    txthabitacion.Enabled = false;
                    txtnombre.Enabled = false;
                    txtservicio.Enabled = false;
                    txtrut.Enabled = false;
                    txtficha.Enabled = false;
                 //  Cargar_valores_cero();
                    Valida_ingesta();
                    cargar_grillas();

                   

                    DateTime f = Convert.ToDateTime(fecha);

                    string fecha_hoy = DateTime.Now.ToString("dd-MM-yyyy");
                    DateTime f2 = Convert.ToDateTime(fecha_hoy);
                    f2 = f2.AddDays(-1);

                 if (Convert.ToInt32(cod_pedido) > 0)
                 {

                     if (Convert.ToDateTime(f) == Convert.ToDateTime(f2) || Convert.ToDateTime(f) == Convert.ToDateTime(fecha_hoy))
                     {
                     }

                     else{

                         btn_guardar.Enabled = false;
                         btn_ra_2.Enabled = false;
                         btn_rc_2.Enabled = false;
                         btn_rc1_2.Enabled = false;
                         btn_rce_2.Enabled = false;
                         btn_todo_d.Enabled = false;
                         btn_todo_c1.Enabled = false;
                         btn_todo_a.Enabled = false;
                         btn_todo_o.Enabled = false;
                         btn_todo_c.Enabled = false;
                         btn_todo_c2.Enabled = false;
                         btn_todo_ce.Enabled = false;
                         btn_todo_hco.Enabled = false;
                         btn_restablecer_total.Enabled = false;
                         btn_rhco_2.Enabled = false;
                         btn_ro_2.Enabled = false;
                         btn_rc2_2.Enabled = false;
                         btn_rd_2.Enabled = false;

                         txtmsg.Text = "Estimado usuario, No se puede generar Ingesta";
                         Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
                     }
                 }


               
                }
                else
                {
                    Response.Redirect("index.aspx");
                    Session["Usuario"] = "";
                }

            }
            MaintainScrollPositionOnPostBack = true;
        }




        #region Cargar


        #region Cargar Conexion

        #endregion

        #region Cargar Grilla

        protected void cargar_grillas()
        {
            List<Menu_tipo_alimento> resumen = new Menu_tipo_alimentosNE().Obtener_resumen();
            dt_resumen = ConvertToDataTable(resumen);
            Session["dt_resumen"] = dt_resumen;
            Cargar_grilla_desayuno();
            
            Cargar_grilla_colacion_man();
            Cargar_grilla_almuerzo();
            Cargar_grilla_once();
            Cargar_grilla_cena();
            Cargar_grilla_colacion_noc();
            Cargar_grilla_colacion_extra();
            Cargar_grilla_hidrico();
            calcular_resumen_total();
            calcular__total();
            d_s.Text = taj_d;


        }


        #region Listar Grilla

        protected void grillaresumen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grillaresumen.PageIndex = e.NewPageIndex;
            grillaresumen.DataBind();


        }
        #region  grilla

    


        #endregion



        #endregion

  

        #region Pintar Grilla

        #endregion

        #region Pintar Extraer grilla

        #endregion

        #endregion

        #region Cargar DataTables

        #endregion


        #endregion

        #region Botones

        protected void Restablecer_total(object sender, EventArgs e)
        {
            Restablecer(var_cod_desayuno);
            Restablecer(var_cod_colacion_matinal);
            Restablecer(var_cod_almuerzo);
            Restablecer(var_cod_once);
            Restablecer(var_cod_colacion_nocturna);
            Restablecer(var_cod_colacion_extra);
            Restablecer(var_cod_hidricos);
            Response.Redirect("Generar_Ingesta.aspx");
        }

        protected void Restablecer_d(object sender, EventArgs e)
        {
            Restablecer(var_cod_desayuno);
            Response.Redirect("Generar_Ingesta.aspx");
 
        }

        protected void Restablecer_c1(object sender, EventArgs e)
        {
            Restablecer(var_cod_colacion_matinal);
            Response.Redirect("Generar_Ingesta.aspx");
        }

        protected void Restablecer_a(object sender, EventArgs e)
        {
            Restablecer(var_cod_almuerzo);
            Response.Redirect("Generar_Ingesta.aspx");
        }

        protected void Restablecer_o(object sender, EventArgs e)
        {
            Restablecer(var_cod_once);
            Response.Redirect("Generar_Ingesta.aspx");
     
        }

        protected void Restablecer_c(object sender, EventArgs e)
        {
           Restablecer(var_cod_cena);
           Response.Redirect("Generar_Ingesta.aspx");
        }

        protected void Restablecer_c2(object sender, EventArgs e)
        {
            Restablecer(var_cod_colacion_nocturna);
            Response.Redirect("Generar_Ingesta.aspx");
        }

        protected void Restablecer_ce(object sender, EventArgs e)
        {
            Restablecer(var_cod_colacion_extra);
            Response.Redirect("Generar_Ingesta.aspx");
        }

        protected void Restablecer_hco(object sender, EventArgs e)
        {
            Restablecer(var_cod_hidricos);
            Response.Redirect("Generar_Ingesta.aspx");
        }

        protected void   Guardar(object sender, EventArgs e)
        {

           Guardar_d();
           Guardar_c1();
           Guardar_a();
           Guardar_o();
           Guardar_c();
           Guardar_c2();
           Guardar_ce();
           Guardar_hco();
           Valida_ingesta();
           cargar_grillas();
     

          txtmsg_21.Text = "Estimado Usuario, Fue  Guardado Correctamente la Ingesta";
          ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { msg(); });", true);

        }

        protected void btnatras(object sender, EventArgs e)
        {
            Response.Redirect("Listado_Camas.aspx");
        }


        protected void Calcular_d(object sender, EventArgs e)
        {
            string porcentaje = "txtporcentaje_d";
            string var_cc = "txtccd_c";
            comio_todo(grilladesayuno, var_cod_desayuno, porcentaje, var_cc);
        }
        protected void Calcular_c1(object sender, EventArgs e)
        {
            string porcentaje = "txtporcentaje_c1";
            string var_cc = "txtccc1_c";
            comio_todo(grillacolacion_man, var_cod_colacion_matinal, porcentaje, var_cc);
        }

        protected void Calcular_a(object sender, EventArgs e)
        {
            string porcentaje = "txtporcentaje_a";
            string var_cc = "txtcca_c";
            comio_todo(grillaalmuerzo, var_cod_almuerzo, porcentaje, var_cc);
        }
        protected void Calcular_o(object sender, EventArgs e)
        {
            string porcentaje = "txtporcentaje_o";
            string var_cc = "txtcco_c";
            comio_todo(grillaonce, var_cod_once, porcentaje, var_cc);
        }
        protected void Calcular_c(object sender, EventArgs e)
        {
            string porcentaje = "txtporcentaje_c";
            string var_cc = "txtccc_c";
            comio_todo(grillacena, var_cod_cena, porcentaje, var_cc);
        }
        protected void Calcular_c2(object sender, EventArgs e)
        {
            string porcentaje = "txtporcentaje_c2";
            string var_cc = "txtccc2_c";
            comio_todo(grillacolacion_noc, var_cod_colacion_nocturna, porcentaje, var_cc);
        }
        protected void Calcular_ce(object sender, EventArgs e)
        {
            string porcentaje = "txtporcentaje_ce";
            string var_cc = "txtccce_c";
            comio_todo(grillaextra, var_cod_colacion_extra, porcentaje, var_cc);
        }
        protected void Calcular_hco(object sender, EventArgs e)
        {
            string porcentaje = "txtporcentaje_hco";
            string var_cc = "txtcchco_c";
            comio_todo(grillahidrico, var_cod_hidricos, porcentaje, var_cc);
        }

        #endregion

        #region Metodos

     

  

        protected double reset_valor(string v)
        {
            double valor = 0;

            if (v == "")
            {
                valor = 0;
            }

            else
            {
                valor = Convert.ToDouble(v);
            }


            return valor;
        }

         protected void   Restablecer( string cod)
         {
            string r = new Menu_tipo_alimentosNE().Restablecer(cod_pedido, cod);
         }

         protected double calculo_ingerido(double tex, int gr)
         {
             double res = 0;

             res =Math.Round(tex * gr / 100,1);
             return res;
         }

         protected double calculo_consumo(double var_r, double var_c)
         {
             double res = 0;
             res = Math.Round((var_r * var_c / 100),1);
             
             return res;
         }

        #region  Desayuno

        void Valida_ingesta()
        {
            cod_ing_d = 0;
            cod_ing_c1 = 0;
            cod_ing_a=0;
            cod_ing_o = 0;
            cod_ing_c = 0;
            cod_ing_c1=0;
            cod_ing_ce = 0;
            cod_ing_hco = 0;

            List<Menu_tipo_alimento> valida_ingesta = new Menu_tipo_alimentosNE().Validar_ingesta(cod_pedido);
            dt_ingesta = ConvertToDataTable(valida_ingesta);

            Session["dt_ingesta"] = dt_ingesta;


            foreach (DataRow miRow1 in dt_ingesta.Select(" _Cod_tipo_comida= " + var_cod_desayuno))
            {
                cod_ing_d = Convert.ToInt32(miRow1["_Ing_id"].ToString());
            }
            foreach (DataRow miRow1 in dt_ingesta.Select(" _Cod_tipo_comida= " + var_cod_colacion_matinal))
            {
                cod_ing_c1 = Convert.ToInt32(miRow1["_Ing_id"].ToString());
            }

            foreach (DataRow miRow1 in dt_ingesta.Select(" _Cod_tipo_comida= " + var_cod_almuerzo))
            {
                cod_ing_a = Convert.ToInt32(miRow1["_Ing_id"].ToString());
            }
            foreach (DataRow miRow1 in dt_ingesta.Select(" _Cod_tipo_comida= " + var_cod_once))
            {
                cod_ing_o = Convert.ToInt32(miRow1["_Ing_id"].ToString());
            }
            foreach (DataRow miRow1 in dt_ingesta.Select(" _Cod_tipo_comida= " + var_cod_cena))
            {
                cod_ing_c = Convert.ToInt32(miRow1["_Ing_id"].ToString());
            }
            foreach (DataRow miRow1 in dt_ingesta.Select(" _Cod_tipo_comida= " + var_cod_colacion_nocturna))
            {
                cod_ing_c2 = Convert.ToInt32(miRow1["_Ing_id"].ToString());
            }
            foreach (DataRow miRow1 in dt_ingesta.Select(" _Cod_tipo_comida= " + var_cod_colacion_extra))
            {
                cod_ing_ce = Convert.ToInt32(miRow1["_Ing_id"].ToString());
            }

            foreach (DataRow miRow1 in dt_ingesta.Select(" _Cod_tipo_comida= " + var_cod_hidricos))
            {
                cod_ing_hco = Convert.ToInt32(miRow1["_Ing_id"].ToString());
            }

            if (cod_ing_d > 0 && cod_ing_c1 > 0 && cod_ing_a > 0 && cod_ing_o > 0 && cod_ing_c > 0 && cod_ing_c2 > 0)
            {
                string res = new PedidosNE().Cambiar_estado(cod_pedido, 9);

            }

        }
        void Cargar_grilla_desayuno()
        {
           
            List<Menu_tipo_alimento> lista_desayuno;
            if (cod_ing_d == 0)
            {
                 lista_desayuno = new Menu_tipo_alimentosNE().Listado_ingesta(cod_pedido, var_cod_desayuno);
              
            }
            else
            {
                lista_desayuno = new Menu_tipo_alimentosNE().Listado_ingesta_2(cod_pedido, var_cod_desayuno);
              
            }

            dt_d = ConvertToDataTable(lista_desayuno);
            num_d.Text= dt_d.Rows.Count.ToString();

            grilladesayuno.DataSource = dt_d;
            Session["dt_d"] = dt_d;
            grilladesayuno.DataBind();
            extraer_datos_d();
            calcular__total();
        }


        protected void comio_todo(GridView grilla,string cod,string var_gr,string var_cc)
        {
    
            dt_d = (DataTable)Session["dt_d"];
            int tol = 0; int cont = 0; double total_gr_c = 0;
            double c_total1 = 0; double p_total = 0; double l_total = 0; double hyc_total = 0; double s_total = 0; double total = 0; double cc_total = 0; double gr_total = 0;

            foreach (GridViewRow row1 in grilla.Rows)
            {
                cont++;

                TextBox val = row1.FindControl(var_gr) as TextBox;
                TextBox val2 = row1.FindControl(var_cc) as TextBox;
                val.Text = "100";
              
                double _valor_c = (Convert.ToDouble(row1.Cells[10].Text.ToString()) * Convert.ToInt32(row1.Cells[1].Text.ToString()));
                double _valor_g = (Convert.ToDouble(row1.Cells[3].Text.ToString()) * Convert.ToInt32(row1.Cells[1].Text.ToString()));
                row1.Cells[3].Text = _valor_g.ToString();
                row1.Cells[4].Text = _valor_g.ToString();
                row1.Cells[5].Text = calculo_consumo(100, Convert.ToDouble(grilla.DataKeys[row1.RowIndex]["_Calorias"].ToString()) * Convert.ToInt32(row1.Cells[1].Text.ToString())).ToString();
                row1.Cells[6].Text = calculo_consumo(100, Convert.ToDouble(grilla.DataKeys[row1.RowIndex]["_Proteinas"].ToString()) * Convert.ToInt32(row1.Cells[1].Text.ToString())).ToString();
                row1.Cells[7].Text = calculo_consumo(100, Convert.ToDouble(grilla.DataKeys[row1.RowIndex]["_Lipidos"].ToString()) * Convert.ToInt32(row1.Cells[1].Text.ToString())).ToString();
                row1.Cells[8].Text = calculo_consumo(100, Convert.ToDouble(grilla.DataKeys[row1.RowIndex]["_Hyc"].ToString()) * Convert.ToInt32(row1.Cells[1].Text.ToString())).ToString();
                row1.Cells[9].Text = calculo_consumo(100, Convert.ToDouble(grilla.DataKeys[row1.RowIndex]["_Sodio"].ToString()) * Convert.ToInt32(row1.Cells[1].Text.ToString())).ToString();

                row1.Cells[10].Text = (calculo_consumo(100, _valor_c)).ToString();
                val2.Text = (_valor_c).ToString();

                total_gr_c = total_gr_c + Convert.ToDouble(row1.Cells[4].Text.Equals(string.Empty) ? 0 : Convert.ToDouble(row1.Cells[4].Text));
                c_total1 = c_total1 + Convert.ToDouble(row1.Cells[5].Text.Equals(string.Empty) ? 0 : Convert.ToDouble(row1.Cells[5].Text));
                p_total = p_total + Convert.ToDouble(row1.Cells[6].Text.Equals(string.Empty) ? 0 : Convert.ToDouble(row1.Cells[6].Text));
                l_total = l_total + Convert.ToDouble(row1.Cells[7].Text.Equals(string.Empty) ? 0 : Convert.ToDouble(row1.Cells[7].Text));
                hyc_total = hyc_total + Convert.ToDouble(row1.Cells[8].Text.Equals(string.Empty) ? 0 : Convert.ToDouble(row1.Cells[8].Text));
                s_total = s_total + Convert.ToDouble(row1.Cells[9].Text.Equals(string.Empty) ? 0 : Convert.ToDouble(row1.Cells[9].Text));


                cc_total = cc_total + _valor_c;

    
                   
            }
               switch(cod)
               {
               case "1":
                       sd_gr_c.Text = total_gr_c.ToString();
                       d_c.Text = c_total1.ToString();  sd_c.Text = c_total1.ToString();
                       d_p.Text = p_total.ToString(); sd_p.Text = p_total.ToString();
                       d_l.Text = l_total.ToString(); sd_l.Text = l_total.ToString();
                       d_hyc.Text = hyc_total.ToString(); sd_hyc.Text = hyc_total.ToString();
                       d_s.Text = s_total.ToString(); sd_s.Text = s_total.ToString();
                       d_total.Text= cc_total.ToString(); sd_total.Text = cc_total.ToString();
                   
                   break;
               case "2":
                       sc1_gr_c.Text = total_gr_c.ToString();
                       c1_c.Text = c_total1.ToString();  sc1_c.Text = c_total1.ToString();
                       c1_p.Text = p_total.ToString(); sc1_p.Text = p_total.ToString();
                       c1_l.Text = l_total.ToString(); sc1_l.Text = l_total.ToString();
                       c1_hyc.Text = hyc_total.ToString(); sc1_hyc.Text = hyc_total.ToString();
                       c1_s.Text = s_total.ToString(); sc1_s.Text = s_total.ToString();
                       c1_total.Text= cc_total.ToString(); sc1_total.Text = cc_total.ToString();

                   break;
               case "3":
                       sa_gr_c.Text = total_gr_c.ToString();
                       a_c.Text = c_total1.ToString();  sa_c.Text = c_total1.ToString();
                       a_p.Text = p_total.ToString(); sa_p.Text = p_total.ToString();
                       a_l.Text = l_total.ToString(); sa_l.Text = l_total.ToString();
                       a_hyc.Text = hyc_total.ToString(); sa_hyc.Text = hyc_total.ToString();
                       a_s.Text = s_total.ToString(); sa_s.Text = s_total.ToString();
                       a_total.Text= cc_total.ToString(); sa_total.Text = cc_total.ToString();                   
                   
                   break;
               case "4":
                       so_gr_c.Text = total_gr_c.ToString();
                        o_c.Text = c_total1.ToString();  so_c.Text = c_total1.ToString();
                       o_p.Text = p_total.ToString(); so_p.Text = p_total.ToString();
                       o_l.Text = l_total.ToString(); so_l.Text = l_total.ToString();
                       o_hyc.Text = hyc_total.ToString(); so_hyc.Text = hyc_total.ToString();
                       o_s.Text = s_total.ToString(); so_s.Text = s_total.ToString();
                       o_total.Text= cc_total.ToString(); so_total.Text = cc_total.ToString();                  
                    
                   break;
               case "5":
                       sc_gr_c.Text = total_gr_c.ToString();
                       c_c.Text = c_total1.ToString();  sc_c.Text = c_total1.ToString();
                       c_p.Text = p_total.ToString(); sc_p.Text = p_total.ToString();
                       c_l.Text = l_total.ToString(); sc_l.Text = l_total.ToString();
                       c_hyc.Text = hyc_total.ToString(); sc_hyc.Text = hyc_total.ToString();
                       c_s.Text = s_total.ToString(); sc_s.Text = s_total.ToString();
                       c_total.Text= cc_total.ToString(); sc_total.Text = cc_total.ToString();
                   
                   break;
               case "6":
                       sc2_gr_c.Text = total_gr_c.ToString();
                       c2_c.Text = c_total1.ToString();  sc2_c.Text = c_total1.ToString();
                       c2_p.Text = p_total.ToString(); sc2_p.Text = p_total.ToString();
                       c2_l.Text = l_total.ToString(); sc2_l.Text = l_total.ToString();
                       c2_hyc.Text = hyc_total.ToString(); sc2_hyc.Text = hyc_total.ToString();
                       c2_s.Text = s_total.ToString(); sc2_s.Text = s_total.ToString();
                       c2_total.Text= cc_total.ToString(); sc2_total.Text = cc_total.ToString();                   
                   
                   
                   break;
               case "7":
                       sce_gr_c.Text = total_gr_c.ToString();
                       ce_c.Text = c_total1.ToString();  sce_c.Text = c_total1.ToString();
                       ce_p.Text = p_total.ToString(); sce_p.Text = p_total.ToString();
                       ce_l.Text = l_total.ToString(); sce_l.Text = l_total.ToString();
                       ce_hyc.Text = hyc_total.ToString(); sce_hyc.Text = hyc_total.ToString();
                       ce_s.Text = s_total.ToString(); sce_s.Text = s_total.ToString();
                       ce_total.Text= cc_total.ToString(); sce_total.Text = cc_total.ToString();                   
                   
                   
                   break;
               case "8":
                       shco_gr_c.Text = total_gr_c.ToString(); 
                       hco_c.Text = c_total1.ToString();  shco_c.Text = c_total1.ToString();
                       hco_p.Text = p_total.ToString(); shco_p.Text = p_total.ToString();
                       hco_l.Text = l_total.ToString(); shco_l.Text = l_total.ToString();
                       hco_hyc.Text = hyc_total.ToString(); shco_hyc.Text = hyc_total.ToString();
                       hco_s.Text = s_total.ToString(); shco_s.Text = s_total.ToString();
                       hco_total.Text= cc_total.ToString(); shco_total.Text = cc_total.ToString();                   
                   
                   break;

               }
            

            calcular_resumen(cod, c_total1.ToString(), p_total.ToString(), l_total.ToString(), hyc_total.ToString(), s_total.ToString(), cc_total.ToString(), gr_total);
            calcular__total();       
      
        }
    

      
        protected void extraer_datos_d()
        {
            dt_d = (DataTable)Session["dt_d"];
            int tol = 0;
            int cont = 0;
            double total_gr_c = 0;
            foreach (GridViewRow row1 in grilladesayuno.Rows)
            {
                cont++;

                TextBox val = row1.FindControl("txtporcentaje_d") as TextBox;
                TextBox val2 = row1.FindControl("txtccd_c") as TextBox;
                val.Text = grilladesayuno.DataKeys[row1.RowIndex]["_Porcentaje"].ToString();
                val2.Text = grilladesayuno.DataKeys[row1.RowIndex]["_Ing_cc_total"].ToString();

                total_gr_c = calcular_gr_cc( grilladesayuno);
                if (cont == 1)
                {
                    if(sd_gr_c.Text==""){sd_gr_c.Text="0";}
                    sd_gr_c.Text =  total_gr_c.ToString();
                    sd_c.Text = grilladesayuno.DataKeys[row1.RowIndex]["_Sub_calorias"].ToString();
                    sd_p.Text = grilladesayuno.DataKeys[row1.RowIndex]["_Sub_proteinas"].ToString();
                    sd_l.Text = grilladesayuno.DataKeys[row1.RowIndex]["_Sub_lipidos"].ToString();
                    sd_hyc.Text = grilladesayuno.DataKeys[row1.RowIndex]["_Sub_hyc"].ToString();
                    sd_s.Text = grilladesayuno.DataKeys[row1.RowIndex]["_Sub_sodio"].ToString();
                    sd_total.Text = grilladesayuno.DataKeys[row1.RowIndex]["_Sub_cc_total"].ToString();
                    d_c.Text = grilladesayuno.DataKeys[row1.RowIndex]["_Ajuste_calorias"].ToString();
                    d_p.Text = grilladesayuno.DataKeys[row1.RowIndex]["_Ajuste_proteinas"].ToString();
                    d_l.Text = grilladesayuno.DataKeys[row1.RowIndex]["_Ajuste_lipidos"].ToString();
                    d_hyc.Text = grilladesayuno.DataKeys[row1.RowIndex]["_Ajuste_hyc"].ToString();
                    d_s.Text = grilladesayuno.DataKeys[row1.RowIndex]["_Ajuste_sodio"].ToString();
                    taj_d = grilladesayuno.DataKeys[row1.RowIndex]["_Ajuste_sodio"].ToString();
                    d_total.Text = grilladesayuno.DataKeys[row1.RowIndex]["_Ajuste_cc_total"].ToString();

                    string c = d_c.Text.Equals(string.Empty) ? "0" : d_c.Text;
                    string p = d_p.Text.Equals(string.Empty) ? "0" : d_p.Text;
                    string l = d_l.Text.Equals(string.Empty) ? "0" : d_l.Text;
                    string hyc = d_hyc.Text.Equals(string.Empty) ? "0" : d_hyc.Text;
                    string s = d_s.Text.Equals(string.Empty) ? "0" : d_s.Text;
                    string total = d_total.Text.Equals(string.Empty) ? "0" : d_total.Text;
                    calcular_resumen(var_cod_desayuno, c, p, l, hyc, s, total, total_gr_c);
                }

            }
                    
        }

        protected double calcular_gr_cc(GridView grilla)
        {
            double val = 0;
            double total_gr_c = 0;
            foreach (GridViewRow row1 in grilla.Rows)
            {
                string valor = grilla.DataKeys[row1.RowIndex]["_Ing_gr_c"].ToString();
                if (valor == "") { valor = "0"; }
                total_gr_c = total_gr_c + Convert.ToDouble(valor);
            }

            val = total_gr_c;


            return val;
        }

        protected double calcular_cc_cc(GridView grilla)
        {
            double val = 0;
            double total_cc_c = 0;
            foreach (GridViewRow row1 in grilla.Rows)
            {

                string valor = grilla.DataKeys[row1.RowIndex]["_Ing_cc_c"].ToString();
                if (valor == "") { valor = "0"; }
                total_cc_c = total_cc_c + Convert.ToDouble(valor);

            }

            val = total_cc_c;


            return val;
        }


        protected void grilladesayuno_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grilladesayuno.PageIndex = e.NewPageIndex;
            grilladesayuno.DataBind();
            Cargar_grilla_desayuno();

        }
        protected void limpiar_d()
        {
            sd_c.Text = "";
            sd_p.Text = "";
            sd_l.Text = "";
            sd_hyc.Text = "";
            sd_s.Text = "";

            d_c.Text = "";
            d_p.Text = "";
            d_l.Text = "";
            d_hyc.Text = "";
            d_s.Text = "";
      
        }
        protected void calcular_resumen(string var_cod, string var_c, string var_p, string var_l, string var_hyc, string var_s, string var_total, double total_gr_c)
        {
            dt_resumen = (DataTable)Session["dt_resumen"];
            foreach (DataRow row2 in dt_resumen.Select("_Cod_tipo_comida = '" + var_cod + "'"))
            {
                double d = Convert.ToDouble(total_gr_c);
                double d1 = Convert.ToDouble(var_c);
                row2["_Ing_gr_c"] = Convert.ToDouble(total_gr_c);
                row2["_Calorias"] = Convert.ToDouble(var_c);
                row2["_Proteinas"] = Convert.ToDouble(var_p);
                row2["_Lipidos"] = Convert.ToDouble(var_l);
                row2["_Hyc"] = Convert.ToDouble(var_hyc);
                row2["_Sodio"] = Convert.ToDouble(var_s);
                row2["_Hc"] = Convert.ToDouble(var_total);
            }

            dt_resumen.AcceptChanges();
            grillaresumen.DataSource = dt_resumen;
            Session["dt_resumen"] = dt_resumen;
     
            grillaresumen.DataBind();
        }

        protected void calcular__total()
        {
            double v_c = 0; double v_p = 0; double v_l = 0; double v_hyc = 0; double v_s = 0; double v_total_cc = 0; double v_total_gr = 0;
            limpiar_totales();
            foreach (DataRow row2 in dt_resumen.Rows)
            {
                v_total_gr = v_total_gr + Convert.ToDouble(row2["_Ing_gr_c"].ToString());
                v_c = v_c + Convert.ToDouble(row2["_Calorias"].ToString());
                v_p = v_p + Convert.ToDouble(row2["_Proteinas"].ToString());
                v_l = v_l + Convert.ToDouble(row2["_Lipidos"].ToString());
                v_hyc = v_hyc + Convert.ToDouble(row2["_Hyc"].ToString());
                v_s = v_s + Convert.ToDouble(row2["_Sodio"].ToString());
                v_total_cc = v_total_cc + Convert.ToDouble(row2["_Hc"].ToString());

                if (row2["_Cod_tipo_comida"].ToString() == "9")
                {
                     row2["_Ing_gr_c"]= v_total_gr;
                     row2["_Calorias"] = v_c;
                     row2["_Proteinas"] = v_p;
                     row2["_Lipidos"] = v_l;
                     row2["_Hyc"] = v_hyc;
                     row2["_Sodio"] = v_s;
                     row2["_Hc"] = v_total_cc;

                }
  
            }

            dt_resumen.AcceptChanges();
            grillaresumen.DataSource = dt_resumen;
            Session["dt_resumen"] = dt_resumen;

            grillaresumen.DataBind();
        }

        protected void  limpiar_totales()
        {
            foreach (DataRow row2 in dt_resumen.Select("_Cod_tipo_comida = '" + 9 + "'"))
            {
                row2["_Ing_gr_c"] =0;
                row2["_Calorias"] = 0;
                row2["_Proteinas"] = 0;
                row2["_Lipidos"] = 0;
                row2["_Hyc"] = 0;
                row2["_Sodio"] = 0;
                row2["_Hc"] = 0;
            }
        }
      
      protected DataTable calcular_total_gr(int total_gr_c)
      {
          
        foreach (DataRow row2 in dt_resumen.Select("_Cod_tipo_comida = '" + 9 + "'"))
        {
            if (row2["_Ing_gr_c"].ToString() == "")
            {
                row2["_Ing_gr_c"] = total_gr_c;
            }
            else
            {
                int val = Convert.ToInt32(row2["_Ing_gr_c"].ToString());
                row2["_Ing_gr_c"] = val + total_gr_c;
            }
       }
        dt_resumen.AcceptChanges();
        return dt_resumen;
    }
        #endregion

        #region  Colacion Mantinal

        void Cargar_grilla_colacion_man()
        {
            DataTable dt_prueba = new DataTable();
            List<Menu_tipo_alimento> lista_c12 = new List<Menu_tipo_alimento>();

            List<Menu_tipo_alimento> lista_c1;
            if (cod_ing_c1 == 0)
            {
                lista_c1 = new Menu_tipo_alimentosNE().Listado_ingesta(cod_pedido, var_cod_colacion_matinal);

            }
            else
            {
                lista_c1 = new Menu_tipo_alimentosNE().Listado_ingesta_2(cod_pedido, var_cod_colacion_matinal);
            }


            dt_c1 = ConvertToDataTable(lista_c1);
            num_c1.Text = dt_c1.Rows.Count.ToString();



            if (Convert.ToInt32(num_c1.Text) == 0)
            {
                c1_c.Enabled = false;
                c1_p.Enabled = false;
                c1_l.Enabled = false;
                c1_hyc.Enabled = false;
                c1_s.Enabled = false;
                c1_total.Enabled = false;
            }
            else
            {
                c1_c.Enabled = true;
                c1_p.Enabled = true;
                c1_l.Enabled = true;
                c1_hyc.Enabled = true;
                c1_s.Enabled = true;
                c1_total.Enabled = true;
            }
            grillacolacion_man.DataSource = dt_c1;         
            grillacolacion_man.DataBind();
            Session["dt_c1"] = dt_c1;

            extraer_datos_c1();
        }

        protected void grillacolacion_man_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grillacolacion_man.PageIndex = e.NewPageIndex;
            grillacolacion_man.DataBind();
            Cargar_grilla_colacion_man();

        }

        protected void extraer_datos_c1()
        {

            int cont = 0;
            double total_gr_c = 0;
            foreach (GridViewRow row2 in grillacolacion_man.Rows)
            {
                cont++;
                TextBox valc1 = row2.FindControl("txtporcentaje_c1") as TextBox;
                valc1.Text = grillacolacion_man.DataKeys[row2.RowIndex]["_Porcentaje"].ToString();
                TextBox valc12 = row2.FindControl("txtccc1_c") as TextBox;
    
                valc12.Text = grillacolacion_man.DataKeys[row2.RowIndex]["_Ing_cc_total"].ToString();
                total_gr_c = calcular_gr_cc(grillacolacion_man);
                if (cont == 1)
                {

                    sc1_gr_c.Text = total_gr_c.ToString();
                    sc1_c.Text = grillacolacion_man.DataKeys[row2.RowIndex]["_Sub_calorias"].ToString();
                    sc1_p.Text = grillacolacion_man.DataKeys[row2.RowIndex]["_Sub_proteinas"].ToString();
                    sc1_l.Text = grillacolacion_man.DataKeys[row2.RowIndex]["_Sub_lipidos"].ToString();
                    sc1_hyc.Text = grillacolacion_man.DataKeys[row2.RowIndex]["_Sub_hyc"].ToString();
                    sc1_s.Text = grillacolacion_man.DataKeys[row2.RowIndex]["_Sub_sodio"].ToString();
                    sc1_total.Text = grillacolacion_man.DataKeys[row2.RowIndex]["_Sub_cc_total"].ToString();
                    c1_c.Text = grillacolacion_man.DataKeys[row2.RowIndex]["_Ajuste_calorias"].ToString();
                    c1_p.Text = grillacolacion_man.DataKeys[row2.RowIndex]["_Ajuste_proteinas"].ToString();
                    c1_l.Text = grillacolacion_man.DataKeys[row2.RowIndex]["_Ajuste_lipidos"].ToString();
                    c1_hyc.Text = grillacolacion_man.DataKeys[row2.RowIndex]["_Ajuste_hyc"].ToString();
                    c1_s.Text = grillacolacion_man.DataKeys[row2.RowIndex]["_Ajuste_sodio"].ToString();
                    c1_total.Text = grillacolacion_man.DataKeys[row2.RowIndex]["_Ajuste_cc_total"].ToString();

                    string c = c1_c.Text.Equals(string.Empty) ? "0" : c1_c.Text;
                    string p = c1_p.Text.Equals(string.Empty) ? "0" : c1_p.Text;
                    string l = c1_l.Text.Equals(string.Empty) ? "0" : c1_l.Text;
                    string hyc = c1_hyc.Text.Equals(string.Empty) ? "0" : c1_hyc.Text;
                    string s = c1_s.Text.Equals(string.Empty) ? "0" : c1_s.Text;
                    string total = c1_total.Text.Equals(string.Empty) ? "0" : c1_total.Text;
                    calcular_resumen(var_cod_colacion_matinal, c, p, l, hyc, s, total,total_gr_c);

                }

            }
        }

        protected void limpiar_c1()
        {
            sc1_c.Text = "";
            sc1_p.Text = "";
            sc1_l.Text = "";
            sc1_hyc.Text = "";
            sc1_s.Text = "";

            c1_c.Text = "";
            c1_p.Text = "";
            c1_l.Text = "";
            c1_hyc.Text = "";
            c1_s.Text = "";
        }

      
        protected void calcular_resumen_total()
        {
            double cal = 0; double pro = 0; double lip = 0; double hyc = 0; double sod = 0; double tol_cc = 0;
            
            dt_resumen = (DataTable)Session["dt_resumen"];
            foreach (DataRow row2 in dt_resumen.Rows)
            {
                cal = cal + Convert.ToDouble(row2["_Calorias"].ToString());
                pro = pro + Convert.ToDouble(row2["_Proteinas"].ToString());
                lip = lip + Convert.ToDouble(row2["_Lipidos"].ToString());
                hyc = hyc + Convert.ToDouble(row2["_Hyc"].ToString());
                sod = sod + Convert.ToDouble(row2["_Sodio"].ToString());
                tol_cc = tol_cc + Convert.ToDouble(row2["_Hc"].ToString());


                if (Convert.ToInt32(row2["_Cod_tipo_comida"].ToString()) == 9)
                {
                    row2["_Calorias"] = cal;
                    row2["_Proteinas"] = pro;
                    row2["_Lipidos"] = lip;
                    row2["_Hyc"] = hyc;
                    row2["_Sodio"] = sod;
                    row2["_Hc"] = tol_cc;

                }

            }

            dt_resumen.AcceptChanges();
            grillaresumen.DataSource = dt_resumen;
            Session["dt_resumen"] = dt_resumen;

            grillaresumen.DataBind();
        }

       
        #endregion

        #region  Almuerzo

        void Cargar_grilla_almuerzo()
        {
            DataTable dt_prueba = new DataTable();
            List<Menu_tipo_alimento> lista_a_2 = new List<Menu_tipo_alimento>();
            List<Menu_tipo_alimento> lista_a;
            if (cod_ing_a == 0)
            {
                lista_a = new Menu_tipo_alimentosNE().Listado_ingesta(cod_pedido, var_cod_almuerzo);
            }
            else
            {
                lista_a = new Menu_tipo_alimentosNE().Listado_ingesta_2(cod_pedido, var_cod_almuerzo);

            }
            dt_a = ConvertToDataTable(lista_a);
            num_a.Text = dt_a.Rows.Count.ToString();


            if (Convert.ToInt32(num_a.Text) == 0)
            {
                a_c.Enabled = false;
                a_p.Enabled = false;
                a_l.Enabled = false;
                a_hyc.Enabled = false;
                a_s.Enabled = false;
                a_total.Enabled = false;
            }
            else
            {
                a_c.Enabled = true;
                a_p.Enabled = true;
                a_l.Enabled = true;
                a_hyc.Enabled = true;
                a_s.Enabled = true;
                a_total.Enabled = true;
            }

            grillaalmuerzo.DataSource = dt_a;
            Session["dt_a"] = dt_a;
            grillaalmuerzo.DataBind();

            extraer_datos_a();
        }
        protected void grillaalmuerzo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grillaalmuerzo.PageIndex = e.NewPageIndex;
            grillaalmuerzo.DataBind();
            Cargar_grilla_almuerzo();

        }
        protected void extraer_datos_a()
        {

            int cont = 0;
            double total_gr_c = 0;
            foreach (GridViewRow row1 in grillaalmuerzo.Rows)
            {
                cont++;
                TextBox vala = row1.FindControl("txtporcentaje_a") as TextBox;
                vala.Text = grillaalmuerzo.DataKeys[row1.RowIndex]["_Porcentaje"].ToString();
                TextBox vala2 = row1.FindControl("txtcca_c") as TextBox;
             
               vala2.Text = grillaalmuerzo.DataKeys[row1.RowIndex]["_Ing_cc_total"].ToString();

               total_gr_c = calcular_gr_cc(grillaalmuerzo);
               if (cont == 1)
               {
                   sa_gr_c.Text = total_gr_c.ToString();
                   sa_c.Text = grillaalmuerzo.DataKeys[row1.RowIndex]["_Sub_calorias"].ToString();
                   sa_p.Text = grillaalmuerzo.DataKeys[row1.RowIndex]["_Sub_proteinas"].ToString();
                   sa_l.Text = grillaalmuerzo.DataKeys[row1.RowIndex]["_Sub_lipidos"].ToString();
                   sa_hyc.Text = grillaalmuerzo.DataKeys[row1.RowIndex]["_Sub_hyc"].ToString();
                   sa_s.Text = grillaalmuerzo.DataKeys[row1.RowIndex]["_Sub_sodio"].ToString();
                   sa_total.Text = grillaalmuerzo.DataKeys[row1.RowIndex]["_Sub_cc_total"].ToString();
                   a_c.Text = grillaalmuerzo.DataKeys[row1.RowIndex]["_Ajuste_calorias"].ToString();
                   a_p.Text = grillaalmuerzo.DataKeys[row1.RowIndex]["_Ajuste_proteinas"].ToString();
                   a_l.Text = grillaalmuerzo.DataKeys[row1.RowIndex]["_Ajuste_lipidos"].ToString();
                   a_hyc.Text = grillaalmuerzo.DataKeys[row1.RowIndex]["_Ajuste_hyc"].ToString();
                   a_s.Text = grillaalmuerzo.DataKeys[row1.RowIndex]["_Ajuste_sodio"].ToString();
                   a_total.Text = grillaalmuerzo.DataKeys[row1.RowIndex]["_Ajuste_cc_total"].ToString();


                   string c = a_c.Text.Equals(string.Empty) ? "0" : a_c.Text;
                   string p = a_p.Text.Equals(string.Empty) ? "0" : a_p.Text;
                   string l = a_l.Text.Equals(string.Empty) ? "0" : a_l.Text;
                   string hyc = a_hyc.Text.Equals(string.Empty) ? "0" : a_hyc.Text;
                   string s = a_s.Text.Equals(string.Empty) ? "0" : a_s.Text;
                   string total = a_total.Text.Equals(string.Empty) ? "0" : a_total.Text;
                   calcular_resumen(var_cod_almuerzo, c, p, l, hyc, s, total, total_gr_c);
               }

            }

        }
        protected void limpiar_resultados()
        {
            res = 0;
            res_c = 0;
            res_p = 0;
            res_l = 0;
            res_hyc = 0;
            res_s = 0;
            res_cc_c = 0;
        }
        protected void limpiar_a()
        {

            sa_c.Text = "";
            sa_p.Text = "";
            sa_l.Text = "";
            sa_hyc.Text = "";
            sa_s.Text = "";

            a_c.Text = "";
            a_p.Text = "";
            a_l.Text = "";
            a_hyc.Text = "";
            a_s.Text = "";
        }

        #endregion

        #region  Once

        void Cargar_grilla_once()
        {
   
         
            List<Menu_tipo_alimento> lista_o;
            if (cod_ing_o == 0)
            {
                lista_o = new Menu_tipo_alimentosNE().Listado_ingesta(cod_pedido, var_cod_once);

            }
            else
            {
                lista_o = new Menu_tipo_alimentosNE().Listado_ingesta_2(cod_pedido, var_cod_once);

            }


            dt_o = ConvertToDataTable(lista_o);
            num_o.Text = dt_o.Rows.Count.ToString();



            if (Convert.ToInt32(num_o.Text) == 0)
            {
                o_c.Enabled = false;
                o_p.Enabled = false;
                o_l.Enabled = false;
                o_hyc.Enabled = false;
               o_s.Enabled = false;
                o_total.Enabled = false;
            }
            else
            {
                o_c.Enabled = true;
                o_p.Enabled = true;
                o_l.Enabled = true;
                o_hyc.Enabled = true;
                o_s.Enabled = true;
                o_total.Enabled = true;
            }
            grillaonce.DataSource = dt_o;
            Session["dt_o"] = dt_o;
            grillaonce.DataBind();

            extraer_datos_o();
        }
        protected void grillaonce_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grillaonce.PageIndex = e.NewPageIndex;
            grillaonce.DataBind();
            Cargar_grilla_once();
        }
        protected void extraer_datos_o()
        {

            int cont = 0;
            double total_gr_c = 0;
            foreach (GridViewRow row1 in grillaonce.Rows)
            {
                cont++;
                TextBox valo = row1.FindControl("txtporcentaje_o") as TextBox;
                valo.Text = grillaonce.DataKeys[row1.RowIndex]["_Porcentaje"].ToString();
                TextBox valo2 = row1.FindControl("txtcco_c") as TextBox;
                valo2.Text = grillaonce.DataKeys[row1.RowIndex]["_Ing_cc_total"].ToString();
                total_gr_c = calcular_gr_cc(grillaonce);
                if (cont == 1)
                {
                    so_gr_c.Text = total_gr_c.ToString();
                    so_c.Text = grillaonce.DataKeys[row1.RowIndex]["_Sub_calorias"].ToString();
                    so_p.Text = grillaonce.DataKeys[row1.RowIndex]["_Sub_proteinas"].ToString();
                    so_l.Text = grillaonce.DataKeys[row1.RowIndex]["_Sub_lipidos"].ToString();
                    so_hyc.Text = grillaonce.DataKeys[row1.RowIndex]["_Sub_hyc"].ToString();
                    so_s.Text = grillaonce.DataKeys[row1.RowIndex]["_Sub_sodio"].ToString();
                    so_total.Text = grillaonce.DataKeys[row1.RowIndex]["_Sub_cc_total"].ToString();
                    o_c.Text = grillaonce.DataKeys[row1.RowIndex]["_Ajuste_calorias"].ToString();
                    o_p.Text = grillaonce.DataKeys[row1.RowIndex]["_Ajuste_proteinas"].ToString();
                    o_l.Text = grillaonce.DataKeys[row1.RowIndex]["_Ajuste_lipidos"].ToString();
                    o_hyc.Text = grillaonce.DataKeys[row1.RowIndex]["_Ajuste_hyc"].ToString();
                    o_s.Text = grillaonce.DataKeys[row1.RowIndex]["_Ajuste_sodio"].ToString();
                    o_total.Text = grillaonce.DataKeys[row1.RowIndex]["_Ajuste_cc_total"].ToString();

                    string c = o_c.Text.Equals(string.Empty) ? "0" : o_c.Text;
                    string p = o_p.Text.Equals(string.Empty) ? "0" : o_p.Text;
                    string l = o_l.Text.Equals(string.Empty) ? "0" : o_l.Text;
                    string hyc = o_hyc.Text.Equals(string.Empty) ? "0" : o_hyc.Text;
                    string s = o_s.Text.Equals(string.Empty) ? "0" : o_s.Text;
                    string total = o_total.Text.Equals(string.Empty) ? "0" : o_total.Text;
                    calcular_resumen(var_cod_once, c, p, l, hyc, s, total, total_gr_c);

                }

            }

   
          


        }
        protected void limpiar_o()
        {
            so_c.Text = "";
            so_p.Text = "";
            so_l.Text = "";
            so_hyc.Text = "";
            so_s.Text = "";

            o_c.Text = "";
            o_p.Text = "";
            o_l.Text = "";
            o_hyc.Text = "";
            o_s.Text = "";
        }    
   

        #endregion

        #region  Cena

        void Cargar_grilla_cena()
        {

            List<Menu_tipo_alimento> lista_c;
            if (cod_ing_c == 0)
            {
                lista_c = new Menu_tipo_alimentosNE().Listado_ingesta(cod_pedido, var_cod_cena);

            }
            else
            {
                lista_c = new Menu_tipo_alimentosNE().Listado_ingesta_2(cod_pedido, var_cod_cena);

            }


            dt_c = ConvertToDataTable(lista_c);
            num_c.Text = dt_c.Rows.Count.ToString();
            if (Convert.ToInt32(num_c.Text) == 0)
            {
                c_c.Enabled = false;
                c_p.Enabled = false;
                c_l.Enabled = false;
                c_hyc.Enabled = false;
                c_s.Enabled = false;
               c_total.Enabled = false;
            }
            else
            {
                c_c.Enabled = true;
                c_p.Enabled = true;
                c_l.Enabled = true;
                c_hyc.Enabled = true;
                c_s.Enabled = true;
                c_total.Enabled = true;
            }
            grillacena.DataSource = dt_c;
            Session["dt_c"] = dt_c;
            grillacena.DataBind();

            extraer_datos_c();
        }
        protected void grillacena_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grillacena.PageIndex = e.NewPageIndex;
            grillacena.DataBind();
            Cargar_grilla_once();
        }
        protected void extraer_datos_c()
        {

            int cont = 0;
            double total_gr_c=0;
            foreach (GridViewRow row1 in grillacena.Rows)
            {
                cont++;
                TextBox valc = row1.FindControl("txtporcentaje_c") as TextBox;
                valc.Text = grillacena.DataKeys[row1.RowIndex]["_Porcentaje"].ToString();
                TextBox valc2 = row1.FindControl("txtccc_c") as TextBox;
                valc2.Text = grillacena.DataKeys[row1.RowIndex]["_Ing_cc_total"].ToString();
                total_gr_c = calcular_gr_cc(grillacena);

                if (cont == 1)
                {
                    sc_gr_c.Text = total_gr_c.ToString();
                    sc_c.Text = grillacena.DataKeys[row1.RowIndex]["_Sub_calorias"].ToString();
                    sc_p.Text = grillacena.DataKeys[row1.RowIndex]["_Sub_proteinas"].ToString();
                    sc_l.Text = grillacena.DataKeys[row1.RowIndex]["_Sub_lipidos"].ToString();
                    sc_hyc.Text = grillacena.DataKeys[row1.RowIndex]["_Sub_hyc"].ToString();
                    sc_s.Text = grillacena.DataKeys[row1.RowIndex]["_Sub_sodio"].ToString();
                    sc_total.Text = grillacena.DataKeys[row1.RowIndex]["_Sub_cc_total"].ToString();
                    c_c.Text = grillacena.DataKeys[row1.RowIndex]["_Ajuste_calorias"].ToString();
                    c_p.Text = grillacena.DataKeys[row1.RowIndex]["_Ajuste_proteinas"].ToString();
                    c_l.Text = grillacena.DataKeys[row1.RowIndex]["_Ajuste_lipidos"].ToString();
                    c_hyc.Text = grillacena.DataKeys[row1.RowIndex]["_Ajuste_hyc"].ToString();
                    c_s.Text = grillacena.DataKeys[row1.RowIndex]["_Ajuste_sodio"].ToString();
                    c_total.Text = grillacena.DataKeys[row1.RowIndex]["_Ajuste_cc_total"].ToString();

                    string c = c_c.Text.Equals(string.Empty) ? "0" : c_c.Text;
                    string p = c_p.Text.Equals(string.Empty) ? "0" : c_p.Text;
                    string l = c_l.Text.Equals(string.Empty) ? "0" : c_l.Text;
                    string hyc = c_hyc.Text.Equals(string.Empty) ? "0" : c_hyc.Text;
                    string s = c_s.Text.Equals(string.Empty) ? "0" : c_s.Text;
                    string total = c_total.Text.Equals(string.Empty) ? "0" : c_total.Text;
                    calcular_resumen(var_cod_cena, c, p, l, hyc, s, total, total_gr_c);

                }

            }

     
      


        }
        protected void limpiar_c()
        {
            sc_c.Text = "";
            sc_p.Text = "";
            sc_l.Text = "";
            sc_hyc.Text = "";
            sc_s.Text = "";

            c_c.Text = "";
            c_p.Text = "";
            c_l.Text = "";
            c_hyc.Text = "";
            c_s.Text = "";
                 
        }

        #endregion

        #region  Colacion Nocturna

        void Cargar_grilla_colacion_noc()
        {


            List<Menu_tipo_alimento> lista_c2;
            if (cod_ing_c2 == 0)
            {
                lista_c2 = new Menu_tipo_alimentosNE().Listado_ingesta(cod_pedido, var_cod_colacion_nocturna);

            }
            else
            {
                lista_c2 = new Menu_tipo_alimentosNE().Listado_ingesta_2(cod_pedido, var_cod_colacion_nocturna);

            }


            dt_c2 = ConvertToDataTable(lista_c2);
            num_c2.Text = dt_c2.Rows.Count.ToString();


            if (Convert.ToInt32(num_c2.Text) == 0)
            {
                c2_c.Enabled = false;
                c2_p.Enabled = false;
                c2_l.Enabled = false;
                c2_hyc.Enabled = false;
                c2_s.Enabled = false;
                c2_total.Enabled = false;
            }
            else
            {
                c2_c.Enabled = true;
                c2_p.Enabled = true;
                c2_l.Enabled = true;
                c2_hyc.Enabled = true;
                c2_s.Enabled = true;
                c2_total.Enabled = true;
            }
            grillacolacion_noc.DataSource = dt_c2;
            Session["dt_c2"] = dt_c2;
            grillacolacion_noc.DataBind();

            extraer_datos_c2() ;
        }

        protected void grillacolacion_noc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grillacolacion_noc.PageIndex = e.NewPageIndex;
            grillacolacion_noc.DataBind();
            Cargar_grilla_colacion_noc();
        }

        protected void limpiar_c2()
        {

            sc2_c.Text = "";
            sc2_p.Text = "";
            sc2_l.Text = "";
            sc2_hyc.Text = "";
            sc2_s.Text = "";

            c2_c.Text = "";
            c2_p.Text = "";
            c2_l.Text = "";
            c2_hyc.Text = "";
            c2_s.Text = "";

        }

        protected void extraer_datos_c2()
        {

            int cont = 0;
            double total_gr_c=0;
            foreach (GridViewRow row1 in grillacolacion_noc.Rows)
            {
                cont++;
                TextBox valc2 = row1.FindControl("txtporcentaje_c2") as TextBox;
                valc2.Text = grillacolacion_noc.DataKeys[row1.RowIndex]["_Porcentaje"].ToString();
                TextBox valc22 = row1.FindControl("txtccc2_c") as TextBox;
                valc22.Text = grillacolacion_noc.DataKeys[row1.RowIndex]["_Ing_cc_total"].ToString();

                total_gr_c = calcular_gr_cc(grillacolacion_noc);
                if (cont == 1)
                {
                    sc2_gr_c.Text = total_gr_c.ToString();
                    sc2_c.Text = grillacolacion_noc.DataKeys[row1.RowIndex]["_Sub_calorias"].ToString();
                    sc2_p.Text = grillacolacion_noc.DataKeys[row1.RowIndex]["_Sub_proteinas"].ToString();
                    sc2_l.Text = grillacolacion_noc.DataKeys[row1.RowIndex]["_Sub_lipidos"].ToString();
                    sc2_hyc.Text = grillacolacion_noc.DataKeys[row1.RowIndex]["_Sub_hyc"].ToString();
                    sc2_s.Text = grillacolacion_noc.DataKeys[row1.RowIndex]["_Sub_sodio"].ToString();
                    sc2_total.Text = grillacolacion_noc.DataKeys[row1.RowIndex]["_Sub_cc_total"].ToString();
                    c2_c.Text = grillacolacion_noc.DataKeys[row1.RowIndex]["_Ajuste_calorias"].ToString();
                    c2_p.Text = grillacolacion_noc.DataKeys[row1.RowIndex]["_Ajuste_proteinas"].ToString();
                    c2_l.Text = grillacolacion_noc.DataKeys[row1.RowIndex]["_Ajuste_lipidos"].ToString();
                    c2_hyc.Text = grillacolacion_noc.DataKeys[row1.RowIndex]["_Ajuste_hyc"].ToString();
                    c2_s.Text = grillacolacion_noc.DataKeys[row1.RowIndex]["_Ajuste_sodio"].ToString();
                    c2_total.Text = grillacolacion_noc.DataKeys[row1.RowIndex]["_Ajuste_cc_total"].ToString();

                    string c = c2_c.Text.Equals(string.Empty) ? "0" : c2_c.Text;
                    string p = c2_p.Text.Equals(string.Empty) ? "0" : c2_p.Text;
                    string l = c2_l.Text.Equals(string.Empty) ? "0" : c2_l.Text;
                    string hyc = c2_hyc.Text.Equals(string.Empty) ? "0" : c2_hyc.Text;
                    string s = c2_s.Text.Equals(string.Empty) ? "0" : c2_s.Text;
                    string total = c2_total.Text.Equals(string.Empty) ? "0" : c2_total.Text;
                    calcular_resumen(var_cod_colacion_nocturna, c, p, l, hyc, s, total, total_gr_c);



                }

            }

  
     


        }


        #endregion 

        #region  Colacion Extra

        void Cargar_grilla_colacion_extra()
        {
            DataTable dt_prueba = new DataTable();
            List<Menu_tipo_alimento> lista_ce_2 = new List<Menu_tipo_alimento>();

            List<Menu_tipo_alimento> lista_ce;
            if (cod_ing_ce == 0)
            {
                lista_ce = new Menu_tipo_alimentosNE().Listado_ingesta(cod_pedido, var_cod_colacion_extra);

            }
            else
            {
                lista_ce = new Menu_tipo_alimentosNE().Listado_ingesta_2(cod_pedido, var_cod_colacion_extra);

            }

            dt_ce = ConvertToDataTable(lista_ce);
            num_ce.Text = dt_ce.Rows.Count.ToString();

            if (Convert.ToInt32(num_ce.Text) == 0)
            {
                ce_c.Enabled = false;
                ce_p.Enabled = false;
                ce_l.Enabled = false;
                ce_hyc.Enabled = false;
                ce_s.Enabled = false;
                ce_total.Enabled = false;
            }
            else
            {
                ce_c.Enabled = true;
                ce_p.Enabled = true;
                ce_l.Enabled = true;
                ce_hyc.Enabled = true;
                ce_s.Enabled = true;
                ce_total.Enabled = true;
            }
            grillaextra.DataSource = dt_ce;
            Session["dt_ce"] = dt_ce;
            grillaextra.DataBind();

            extraer_datos_ce();
        }
        protected void grillaextra_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grillaextra.PageIndex = e.NewPageIndex;
            grillaextra.DataBind();
            Cargar_grilla_colacion_extra();
        }
        protected void limpiar_ce()
        {

            sce_c.Text = "";
            sce_p.Text = "";
            sce_l.Text = "";
            sce_hyc.Text = "";
            sce_s.Text = "";
            sce_total.Text = "";
            ce_c.Text = "";
            ce_p.Text = "";
            ce_l.Text = "";
            ce_hyc.Text = "";
            ce_s.Text = "";
            ce_total.Text = "";

        }        
        protected void extraer_datos_ce()
        {

            int cont = 0;
            double total_gr_c = 0;
            foreach (GridViewRow row1 in grillaextra.Rows)
            {
                cont++;
                TextBox valce = row1.FindControl("txtporcentaje_ce") as TextBox;
                valce.Text = grillaextra.DataKeys[row1.RowIndex]["_Porcentaje"].ToString();
                TextBox valce2 = row1.FindControl("txtccce_c") as TextBox;
                valce2.Text = grillaextra.DataKeys[row1.RowIndex]["_Ing_cc_total"].ToString();

                total_gr_c = calcular_gr_cc(grillaextra);

                if (cont == 1)
                {
                    sce_gr_c.Text = total_gr_c.ToString();
                    sce_c.Text = grillaextra.DataKeys[row1.RowIndex]["_Sub_calorias"].ToString();
                    sce_p.Text = grillaextra.DataKeys[row1.RowIndex]["_Sub_proteinas"].ToString();
                    sce_l.Text = grillaextra.DataKeys[row1.RowIndex]["_Sub_lipidos"].ToString();
                    sce_hyc.Text = grillaextra.DataKeys[row1.RowIndex]["_Sub_hyc"].ToString();
                    sce_s.Text = grillaextra.DataKeys[row1.RowIndex]["_Sub_sodio"].ToString();
                    sce_total.Text = grillaextra.DataKeys[row1.RowIndex]["_Sub_cc_total"].ToString();
                    ce_c.Text = grillaextra.DataKeys[row1.RowIndex]["_Ajuste_calorias"].ToString();
                    ce_p.Text = grillaextra.DataKeys[row1.RowIndex]["_Ajuste_proteinas"].ToString();
                    ce_l.Text = grillaextra.DataKeys[row1.RowIndex]["_Ajuste_lipidos"].ToString();
                    ce_hyc.Text = grillaextra.DataKeys[row1.RowIndex]["_Ajuste_hyc"].ToString();
                    ce_s.Text = grillaextra.DataKeys[row1.RowIndex]["_Ajuste_sodio"].ToString();
                    ce_total.Text = grillaextra.DataKeys[row1.RowIndex]["_Ajuste_cc_total"].ToString();

                    string c = ce_c.Text.Equals(string.Empty) ? "0" : ce_c.Text;
                    string p = ce_p.Text.Equals(string.Empty) ? "0" : ce_p.Text;
                    string l = ce_l.Text.Equals(string.Empty) ? "0" : ce_l.Text;
                    string hyc = ce_hyc.Text.Equals(string.Empty) ? "0" : ce_hyc.Text;
                    string s = ce_s.Text.Equals(string.Empty) ? "0" : ce_s.Text;
                    string total = ce_total.Text.Equals(string.Empty) ? "0" : ce_total.Text;
                    calcular_resumen(var_cod_colacion_extra, c, p, l, hyc, s, total, total_gr_c);


                }

            }

  
       


        }


        #endregion

        #region  Hidricos

        void Cargar_grilla_hidrico()
        {
            DataTable dt_prueba = new DataTable();
            List<Menu_tipo_alimento> lista_hco_2 = new List<Menu_tipo_alimento>();


            List<Menu_tipo_alimento> lista_hco;
            if (cod_ing_hco == 0)
            {
                lista_hco = new Menu_tipo_alimentosNE().Listado_ingesta(cod_pedido, var_cod_hidricos);

            }
            else
            {
                lista_hco = new Menu_tipo_alimentosNE().Listado_ingesta_2(cod_pedido, var_cod_hidricos);

            }

            dt_hco = ConvertToDataTable(lista_hco);
            num_h.Text = dt_hco.Rows.Count.ToString();




            if (Convert.ToInt32(num_h.Text)==0)
            {
                hco_c.Enabled = false;
                hco_p.Enabled = false;
                hco_l.Enabled = false;
                hco_hyc.Enabled = false;
                hco_s.Enabled = false;
                hco_total.Enabled = false;
            }
            else{
                hco_c.Enabled = true;
                hco_p.Enabled = true;
                hco_l.Enabled = true;
                hco_hyc.Enabled = true;
                hco_s.Enabled = true;
                hco_total.Enabled = true;
            }
            grillahidrico.DataSource = dt_hco;
            Session["dt_hco"] = dt_hco;
            grillahidrico.DataBind();

            extraer_datos_hco();
        }
        protected void grillahidrico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grillahidrico.PageIndex = e.NewPageIndex;
            grillahidrico.DataBind();
            Cargar_grilla_hidrico();
        }
        protected void extraer_datos_hco()
        {

            int cont = 0;
            double total_gr_c = 0;
            foreach (GridViewRow row1 in grillahidrico.Rows)
            {
                cont++;
                TextBox valhco = row1.FindControl("txtporcentaje_hco") as TextBox;
                valhco.Text = grillahidrico.DataKeys[row1.RowIndex]["_Porcentaje"].ToString();
                TextBox valhco2 = row1.FindControl("txtcchco_c") as TextBox;
                valhco2.Text = grillahidrico.DataKeys[row1.RowIndex]["_Ing_cc_total"].ToString();
                total_gr_c = calcular_gr_cc(grillahidrico);

                if (cont == 1)
                {
                    shco_gr_c.Text = total_gr_c.ToString();
                    shco_c.Text = grillahidrico.DataKeys[row1.RowIndex]["_Sub_calorias"].ToString();
                    shco_p.Text = grillahidrico.DataKeys[row1.RowIndex]["_Sub_proteinas"].ToString();
                    shco_l.Text = grillahidrico.DataKeys[row1.RowIndex]["_Sub_lipidos"].ToString();
                    shco_hyc.Text = grillahidrico.DataKeys[row1.RowIndex]["_Sub_hyc"].ToString();
                    shco_s.Text = grillahidrico.DataKeys[row1.RowIndex]["_Sub_sodio"].ToString();
                    shco_total.Text = grillahidrico.DataKeys[row1.RowIndex]["_Sub_cc_total"].ToString();
                    hco_c.Text = grillahidrico.DataKeys[row1.RowIndex]["_Ajuste_calorias"].ToString();
                    hco_p.Text = grillahidrico.DataKeys[row1.RowIndex]["_Ajuste_proteinas"].ToString();
                    hco_l.Text = grillahidrico.DataKeys[row1.RowIndex]["_Ajuste_lipidos"].ToString();
                    hco_hyc.Text = grillahidrico.DataKeys[row1.RowIndex]["_Ajuste_hyc"].ToString();
                    hco_s.Text = grillahidrico.DataKeys[row1.RowIndex]["_Ajuste_sodio"].ToString();
                    hco_total.Text = grillahidrico.DataKeys[row1.RowIndex]["_Ajuste_cc_total"].ToString();

                    string c = hco_c.Text.Equals(string.Empty) ? "0" : hco_c.Text;
                    string p = hco_p.Text.Equals(string.Empty) ? "0" : hco_p.Text;
                    string l = hco_l.Text.Equals(string.Empty) ? "0" : hco_l.Text;
                    string hyc = hco_hyc.Text.Equals(string.Empty) ? "0" : hco_hyc.Text;
                    string s = hco_s.Text.Equals(string.Empty) ? "0" : hco_s.Text;
                    string total = hco_total.Text.Equals(string.Empty) ? "0" : hco_total.Text;
                    calcular_resumen(var_cod_hidricos, c, p, l, hyc, s, total, total_gr_c);
                }



            }

      
     


        }
        protected void limpiar_hco()
        {


            hco_c.Text = "";
            hco_p.Text = "";
            hco_l.Text = "";
            hco_hyc.Text = "";
            hco_s.Text = "";

            hco_c.Text = "";
            hco_p.Text = "";
            hco_l.Text = "";
            hco_hyc.Text = "";
            hco_s.Text = "";

        }




        #endregion

     

        #region Convertir Lista en Datatables

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        #endregion 

        #region Guardar

        protected void Guardar_valores(GridView grilla, DataTable dt,string var_porcentaje, string var_cc, string cod ,string var_c, string  var_p, string var_l, string var_hyc,string var_s,string var_total ,
                                        string var_sgc, string  var_sc, string  var_sp, string  var_sl, string var_shyc,string  var_ss, string var_stotal, string var_gr)
        {
             double r_cc_i = 0; double r_gr_c = 0;
             double cod_ajc = 0; double cod_ajp = 0; double cod_ajl = 0; double cod_ajhyc = 0; double cod_ajs = 0; double cod_ajtotal = 0; double cod_ajgrtotal = 0;

            double cod_sc = 0; double cod_sp = 0; double cod_sl = 0; double cod_shyc = 0; double cod_ss = 0; double cod_stotal = 0; double cod_sgc = 0;
            double calorias = 0; double proteinas = 0; double lipidos = 0; double hyc = 0; double sodio = 0; double cc_i = 0; double gr_consumidos = 0;
            double cc_c = 0; double c_total = 0; int cod_al = 0; double gr_i = 0; double porcentaje = 0;
            res_c = 0; res_p = 0; res_l = 0; res_hyc = 0; res_s = 0; res_total = 0;
            string v_gr = ""; string v_cc = ""; int cantidad = 0;
            double r_calorias = 0; double r_proteinas = 0; double r_lipidos = 0;
            double r_hyc = 0; double r_sodio = 0;
            TextBox valor_1;
            TextBox valor_2;
            TextBox valor_3;

            if(dt.Rows.Count>0)
            {
               

                foreach (GridViewRow row in grilla.Rows)
                {
                   res = 0;
                   r_calorias = 0;
                   r_proteinas = 0;
                   r_lipidos = 0;
                   r_hyc = 0;
                   r_sodio = 0;
                

                   cod_al = Convert.ToInt32(grilla.DataKeys[row.RowIndex]["_Cod_tipo_alimentos"].ToString());
                   cod_ingesta = Convert.ToInt32(grilla.DataKeys[row.RowIndex]["_Ing_id"].ToString());
                  // gr_i = Convert.ToDouble(row.Cells[3].Text.Equals(string.Empty) ? 0 : Convert.ToDouble(row.Cells[3].Text));
                 //   gr_consumidos = Convert.ToInt32(grilla.DataKeys[row.RowIndex]["_Ing_gr_c"].ToString());
                    calorias = Convert.ToDouble(grilla.DataKeys[row.RowIndex]["_Calorias"].ToString());
                    proteinas = Convert.ToDouble(grilla.DataKeys[row.RowIndex]["_Proteinas"].ToString());
                    lipidos = Convert.ToDouble(grilla.DataKeys[row.RowIndex]["_Lipidos"].ToString());
                    hyc = Convert.ToDouble(grilla.DataKeys[row.RowIndex]["_Hyc"].ToString());
                    sodio = Convert.ToDouble(grilla.DataKeys[row.RowIndex]["_Sodio"].ToString());
                    cantidad = Convert.ToInt32(row.Cells[1].Text);
                  //  cc_i = Convert.ToDouble(row.Cells[10].Text.Equals(string.Empty) ? 0 : Convert.ToDouble(row.Cells[10].Text));
                    
                   valor_1 = row.FindControl(var_porcentaje) as TextBox;
                   porcentaje = reset_valor(valor_1.Text);

                   if (gr_i >= 0)
                   {

                       //    calcular 


                       #region  Porcentaje consumido

                       res = porcentaje;

                       #endregion

                       #region  Calculo Gramos Consumidos
                       gr_i = Convert.ToDouble(row.Cells[3].Text.ToString()) * Convert.ToInt32(row.Cells[1].Text.ToString());
                       r_gr_c = calculo_consumo(res, gr_i);
                    

                       #endregion

                   

                        #region  Calculo Calorias
                        calorias = calorias * cantidad;
                        r_calorias = calculo_consumo(res, calorias);
                        row.Cells[5].Text = r_calorias.ToString();
                        res_c = res_c + (r_calorias);
                        
                        #endregion

                        #region  Calculo Proteinas
                        proteinas = proteinas * cantidad;
                        r_proteinas = calculo_consumo(res, proteinas);
                        row.Cells[6].Text = r_proteinas.ToString();
                        res_p = res_p + r_proteinas;

                        #endregion

                        #region  Calculo Lipidos
                        lipidos = lipidos * cantidad;
                        r_lipidos = calculo_consumo(res, lipidos);
                        row.Cells[7].Text = r_lipidos.ToString();
                        res_l = res_l + r_lipidos;

                        #endregion

                        #region  Calculo Hyc
                        hyc = hyc * cantidad;
                        r_hyc = calculo_consumo(res, hyc);
                        row.Cells[8].Text = r_hyc.ToString();
                        res_hyc = res_hyc + r_hyc;

                        #endregion

                        #region  Calculo Sodio
                        sodio = sodio * cantidad;
                        r_sodio = calculo_consumo(res, sodio);
                        row.Cells[9].Text = r_sodio.ToString();
                        res_s = res_s + r_sodio;

                        #endregion


                   }
                   else
                   {
                       res_c = 0;
                       res_p = 0;
                       res_l = 0;
                       res_hyc = 0;
                       res_s = 0;
                       res_total = 0;
                   }

                   TextBox val2 = row.FindControl(var_cc) as TextBox;
                   cc_i = Convert.ToDouble(row.Cells[10].Text.ToString()) * Convert.ToInt32(row.Cells[1].Text.ToString());
                   r_cc_i = calculo_consumo(res, cc_i);
                   val2.Text = r_cc_i.ToString();
                   c_total = c_total + Convert.ToDouble(r_cc_i);


                 /*  r_cc_i = calculo_consumo(res, cc_i);
                   TextBox val2 = row.FindControl(var_cc) as TextBox;
                   val2.Text = r_cc_i.ToString();
                   c_total = c_total + Convert.ToDouble(r_cc_i);*/


                  //  int c = Convert.ToInt32(sd_c.Text);

                   cod_sgc = reset_valor(var_sgc);
                   cod_sc = reset_valor(var_sc);
                   cod_sp = reset_valor(var_sp);
                   cod_sl = reset_valor(var_sl);
                   cod_shyc = reset_valor(var_shyc);
                   cod_ss = reset_valor(var_ss);
                   cod_stotal = reset_valor(var_stotal);
                   

                    cod_ajc = reset_valor(var_c);
                    cod_ajp = reset_valor(var_p);
                    cod_ajl = reset_valor(var_l);
                    cod_ajhyc = reset_valor(var_hyc);
                    cod_ajs = reset_valor(var_s);
                    cod_ajtotal = reset_valor(var_total);




                    double g_c = r_gr_c;
                    double c_c = r_cc_i;



                
                        if (cod_ingesta == 0)
                        {

                            string var = new Menu_tipo_alimentosNE().Registrar_Ingesta(cod_pedido, cod, cod_al, g_c, c_c, r_calorias, r_proteinas, r_lipidos, r_hyc, r_sodio, c_c, user, Convert.ToInt32(porcentaje), cantidad);


                        }
                        else
                        {
                            string var = new Menu_tipo_alimentosNE().Modificar_Ingesta(cod_ingesta, cod_pedido, cod, cod_al, g_c, c_c, r_calorias, r_proteinas, r_lipidos, r_hyc, r_sodio, c_c, user, Convert.ToInt32(porcentaje), cantidad);


                        }

                        string var1 = new Menu_tipo_alimentosNE().Modificar_totales(cod_ingesta, cod_pedido, cod, cod_sc, cod_sp, cod_sl, cod_shyc, cod_ss, cod_stotal, cod_ajc, cod_ajp, cod_ajl, cod_ajhyc, cod_ajs, cod_ajtotal, user, cod_sgc);
            
                    }

         
           
       
            }
           
        }

        protected void Guardar_d( )
        {
            dt_d = (DataTable)Session["dt_d"];
            string var_porcentaje = "txtporcentaje_d";
            string var_cc="txtccd_c";
            string var_gr = "sd_gr_c";
            string cod="1";

            string var_sgc = reset_valor(sd_gr_c.Text).ToString();
            string var_sc = reset_valor(d_c.Text).ToString();
            string var_sp = reset_valor(d_p.Text).ToString();
            string var_sl = reset_valor(d_l.Text).ToString();
            string var_shyc = reset_valor(d_hyc.Text).ToString();
            string var_ss = reset_valor(d_s.Text).ToString();
            string var_stotal = reset_valor(d_total.Text).ToString(); 

            string var_c = reset_valor(d_c.Text).ToString();
            string var_p = reset_valor(d_p.Text).ToString();
            string var_l = reset_valor(d_l.Text).ToString();
            string var_hyc = reset_valor(d_hyc.Text).ToString();
            string var_s = reset_valor(d_s.Text).ToString();
            string var_total = reset_valor(d_total.Text).ToString();
            Guardar_valores(grilladesayuno, dt_d, var_porcentaje, var_cc, cod, var_c, var_p, var_l, var_hyc, var_s, var_total,
                            var_sgc, var_sc, var_sp, var_sl, var_shyc, var_ss, var_stotal,var_gr);
               
        }


        protected void Guardar_c1()
        {

            dt_c1 = (DataTable)Session["dt_c1"];
            string var_porcentaje = "txtporcentaje_c1";
            string var_cc = "txtccc1_c";
            string var_gr = "sc1_gr_c";
            string cod = var_cod_colacion_matinal;

            string var_sgc = reset_valor(sc1_gr_c.Text).ToString();
            string var_sc = reset_valor(c1_c.Text).ToString();
            string var_sp = reset_valor(c1_p.Text).ToString();
            string var_sl = reset_valor(c1_l.Text).ToString();
            string var_shyc = reset_valor(c1_hyc.Text).ToString();
            string var_ss = reset_valor(c1_s.Text).ToString();
            string var_stotal = reset_valor(c1_total.Text).ToString(); 


            string var_c = reset_valor(c1_c.Text).ToString();
            string var_p = reset_valor(c1_p.Text).ToString();
            string var_l = reset_valor(c1_l.Text).ToString();
            string var_hyc = reset_valor(c1_hyc.Text).ToString();
            string var_s = reset_valor(c1_s.Text).ToString();
            string var_total = reset_valor(c1_total.Text).ToString();
            Guardar_valores(grillacolacion_man, dt_c1, var_porcentaje, var_cc, cod, var_c, var_p, var_l, var_hyc, var_s, var_total,
                            var_sgc, var_sc, var_sp, var_sl, var_shyc, var_ss, var_stotal,var_gr);
          

        }

        protected void Guardar_a()
        {

            dt_a = (DataTable)Session["dt_a"];
            string var_porcentaje = "txtporcentaje_a";
            string var_cc = "txtcca_c";
            string var_gr = "sa_gr_c";
            string cod = var_cod_almuerzo;

            string var_sgc = reset_valor(sa_gr_c.Text).ToString();
            string var_sc = reset_valor(a_c.Text).ToString();
            string var_sp = reset_valor(a_p.Text).ToString();
            string var_sl = reset_valor(a_l.Text).ToString();
            string var_shyc = reset_valor(a_hyc.Text).ToString();
            string var_ss = reset_valor(a_s.Text).ToString();
            string var_stotal = reset_valor(a_total.Text).ToString(); 

            string var_c = reset_valor(a_c.Text).ToString();
            string var_p = reset_valor(a_p.Text).ToString();
            string var_l = reset_valor(a_l.Text).ToString();
            string var_hyc = reset_valor(a_hyc.Text).ToString();
            string var_s = reset_valor(a_s.Text).ToString();
            string var_total = reset_valor(a_total.Text).ToString();
            Guardar_valores(grillaalmuerzo, dt_a, var_porcentaje, var_cc, cod, var_c, var_p, var_l, var_hyc, var_s, var_total,
                             var_sgc, var_sc, var_sp, var_sl, var_shyc, var_ss, var_stotal,var_gr);
      
  
        }

        protected void Guardar_o()
        {
            dt_o = (DataTable)Session["dt_o"];
            string var_porcentaje = "txtporcentaje_o";
            string var_cc = "txtcco_c";
            string var_gr = "so_gr_c";
            string cod = var_cod_once;

            string var_sgc = reset_valor(so_gr_c.Text).ToString();
            string var_sc = reset_valor(o_c.Text).ToString();
            string var_sp = reset_valor(o_p.Text).ToString();
            string var_sl = reset_valor(o_l.Text).ToString();
            string var_shyc = reset_valor(o_hyc.Text).ToString();
            string var_ss = reset_valor(o_s.Text).ToString();
            string var_stotal = reset_valor(o_total.Text).ToString(); 

            string var_c = reset_valor(o_c.Text).ToString();
            string var_p = reset_valor(o_p.Text).ToString();
            string var_l = reset_valor(o_l.Text).ToString();
            string var_hyc = reset_valor(o_hyc.Text).ToString();
            string var_s = reset_valor(o_s.Text).ToString();
            string var_total = reset_valor(o_total.Text).ToString();
            Guardar_valores(grillaonce, dt_o, var_porcentaje, var_cc, cod, var_c, var_p, var_l, var_hyc, var_s, var_total,
                             var_sgc, var_sc, var_sp, var_sl, var_shyc, var_ss, var_stotal,var_gr);
           

           
        }
      
        protected void Guardar_c()
        {

            dt_c = (DataTable)Session["dt_c"];
            string var_porcentaje = "txtporcentaje_c";
            string var_cc = "txtccc_c";
            string var_gr = "sc_gr_c";
            string cod = var_cod_cena;

            string var_sgc = reset_valor(sc_gr_c.Text).ToString();
            string var_sc = reset_valor(c_c.Text).ToString();
            string var_sp = reset_valor(c_p.Text).ToString();
            string var_sl = reset_valor(c_l.Text).ToString();
            string var_shyc = reset_valor(c_hyc.Text).ToString();
            string var_ss = reset_valor(c_s.Text).ToString();
            string var_stotal = reset_valor(c_total.Text).ToString(); 

            string var_c = reset_valor(c_c.Text).ToString();
            string var_p = reset_valor(c_p.Text).ToString();
            string var_l = reset_valor(c_l.Text).ToString();
            string var_hyc = reset_valor(c_hyc.Text).ToString();
            string var_s = reset_valor(c_s.Text).ToString();
            string var_total = reset_valor(c_total.Text).ToString();
            Guardar_valores(grillacena, dt_c, var_porcentaje, var_cc, cod, var_c, var_p, var_l, var_hyc, var_s, var_total,
                             var_sgc, var_sc, var_sp, var_sl, var_shyc, var_ss, var_stotal,var_gr);
     

        }

        protected void Guardar_c2()
        {

            dt_c2 = (DataTable)Session["dt_c2"];
            string var_porcentaje = "txtporcentaje_c2";
            string var_cc = "txtccc2_c";
            string var_gr = "sc2_gr_c";
            string cod = var_cod_colacion_nocturna;

            string var_sgc = reset_valor(sc2_gr_c.Text).ToString();
            string var_sc = reset_valor(c2_c.Text).ToString();
            string var_sp = reset_valor(c2_p.Text).ToString();
            string var_sl = reset_valor(c2_l.Text).ToString();
            string var_shyc = reset_valor(c2_hyc.Text).ToString();
            string var_ss = reset_valor(c2_s.Text).ToString();
            string var_stotal = reset_valor(c2_total.Text).ToString(); 

            string var_c = reset_valor(c2_c.Text).ToString();
            string var_p = reset_valor(c2_p.Text).ToString();
            string var_l = reset_valor(c2_l.Text).ToString();
            string var_hyc = reset_valor(c2_hyc.Text).ToString();
            string var_s = reset_valor(c2_s.Text).ToString();
            string var_total = reset_valor(c2_total.Text).ToString();
            Guardar_valores(grillacolacion_noc, dt_c2, var_porcentaje, var_cc, cod, var_c, var_p, var_l, var_hyc, var_s, var_total,
                             var_sgc, var_sc, var_sp, var_sl, var_shyc, var_ss, var_stotal,var_gr);
         
        
        }
       
        protected void Guardar_ce()
        {
            dt_ce = (DataTable)Session["dt_ce"];
            string var_porcentaje = "txtporcentaje_ce";
            string var_cc = "txtccce_c";
            string var_gr = "sce_gr_c";
            string cod = var_cod_colacion_extra;

            string var_sgc = reset_valor(sce_gr_c.Text).ToString();
            string var_sc = reset_valor(ce_c.Text).ToString();
            string var_sp = reset_valor(ce_p.Text).ToString();
            string var_sl = reset_valor(ce_l.Text).ToString();
            string var_shyc = reset_valor(ce_hyc.Text).ToString();
            string var_ss = reset_valor(ce_s.Text).ToString();
            string var_stotal = reset_valor(ce_total.Text).ToString(); 

            string var_c = reset_valor(ce_c.Text).ToString();
            string var_p = reset_valor(ce_p.Text).ToString();
            string var_l = reset_valor(ce_l.Text).ToString();
            string var_hyc = reset_valor(ce_hyc.Text).ToString();
            string var_s = reset_valor(ce_s.Text).ToString();
            string var_total = reset_valor(ce_total.Text).ToString();
            Guardar_valores(grillaextra, dt_ce, var_porcentaje, var_cc, cod, var_c, var_p, var_l, var_hyc, var_s, var_total,
                             var_sgc, var_sc, var_sp, var_sl, var_shyc, var_ss, var_stotal,var_gr);
        
 
        }

        protected void Guardar_hco()
        {

            dt_hco = (DataTable)Session["dt_hco"];
            string var_porcentaje = "txtporcentaje_hco";
            string var_cc = "txtcchco_c";
            string var_gr = "shco_gr_c";
            string cod = var_cod_hidricos;

            string var_sgc = reset_valor(shco_gr_c.Text).ToString();
            string var_sc = reset_valor(hco_c.Text).ToString();
            string var_sp = reset_valor(hco_p.Text).ToString();
            string var_sl = reset_valor(hco_l.Text).ToString();
            string var_shyc = reset_valor(hco_hyc.Text).ToString();
            string var_ss = reset_valor(hco_s.Text).ToString();
            string var_stotal = reset_valor(hco_total.Text).ToString(); 

            string var_c = reset_valor(hco_c.Text).ToString();
            string var_p = reset_valor(hco_p.Text).ToString();
            string var_l = reset_valor(hco_l.Text).ToString();
            string var_hyc = reset_valor(hco_hyc.Text).ToString();
            string var_s = reset_valor(hco_s.Text).ToString();
            string var_total = reset_valor(hco_total.Text).ToString();
            Guardar_valores(grillahidrico, dt_hco, var_porcentaje, var_cc, cod, var_c, var_p, var_l, var_hyc, var_s, var_total,
                             var_sgc, var_sc, var_sp, var_sl, var_shyc, var_ss, var_stotal,var_gr);
           
        }

        #endregion 


        #endregion

        #region Validaciones

        #endregion


        protected void txtporcentaje_d_TextChanged(object sender, EventArgs e)
        {
             TextBox v = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)v.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            TextBox v1 = (TextBox)currentRow.FindControl("txtporcentaje_d");    

            string porcentaje = v1.Text;
            if(v1.Text==""){ porcentaje="0";}

            if (Convert.ToInt32(porcentaje) > 0 && Convert.ToInt32(porcentaje) < 101)
            {
               
                dt_d = (DataTable)Session["dt_d"];
                string var_porcentaje = "txtporcentaje_d";
                string var_cc = "txtccd_c";
                string cod = "1";
                string var_c = reset_valor(d_c.Text).ToString();
                string var_p = reset_valor(d_p.Text).ToString();
                string var_l = reset_valor(d_l.Text).ToString();
                string var_hyc = reset_valor(d_hyc.Text).ToString();
                string var_s = reset_valor(d_s.Text).ToString();
                string var_total = reset_valor(d_total.Text).ToString();
                calcular(grilladesayuno, var_porcentaje, var_cc, cod, var_c, var_p, var_l, var_hyc, var_s, var_total);
            }
            else
            {
                v1.Text = "";
            }
        }


        protected void txtporcentaje_c1_TextChanged(object sender, EventArgs e)
        {
            TextBox v = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)v.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            TextBox v1 = (TextBox)currentRow.FindControl("txtporcentaje_c1");

            string porcentaje = v1.Text;
            if(v1.Text==""){ porcentaje="0";}

            if (Convert.ToInt32(porcentaje) > 0 && Convert.ToInt32(porcentaje) < 101)
            {
                string var_porcentaje = "txtporcentaje_c1";
                string var_cc = "txtccc1_c";
                string cod = "2";
                string var_c = reset_valor(c1_c.Text).ToString();
                string var_p = reset_valor(c1_p.Text).ToString();
                string var_l = reset_valor(c1_l.Text).ToString();
                string var_hyc = reset_valor(c1_hyc.Text).ToString();
                string var_s = reset_valor(c1_s.Text).ToString();
                string var_total = reset_valor(c1_total.Text).ToString();
                calcular(grillacolacion_man, var_porcentaje, var_cc, cod, var_c, var_p, var_l, var_hyc, var_s, var_total);
            }
            else
            {
                v1.Text = "";

            }


        }



        protected void txtporcentaje_a_TextChanged(object sender, EventArgs e)
        {
            TextBox v = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)v.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            TextBox v1 = (TextBox)currentRow.FindControl("txtporcentaje_a");

            string porcentaje = v1.Text;

          if(v1.Text==""){ porcentaje="0";}

            if (Convert.ToInt32(porcentaje) > 0 && Convert.ToInt32(porcentaje) < 101)
            {
                string var_porcentaje = "txtporcentaje_a";
                string var_cc = "txtcca_c";
                string cod = "3";
                string var_c = reset_valor(a_c.Text).ToString();
                string var_p = reset_valor(a_p.Text).ToString();
                string var_l = reset_valor(a_l.Text).ToString();
                string var_hyc = reset_valor(a_hyc.Text).ToString();
                string var_s = reset_valor(a_s.Text).ToString();
                string var_total = reset_valor(a_total.Text).ToString();
                calcular(grillaalmuerzo, var_porcentaje, var_cc, cod, var_c, var_p, var_l, var_hyc, var_s, var_total);
            }
            else
            {
                v1.Text = "";

            }
        }



        protected void txtporcentaje_o_TextChanged(object sender, EventArgs e)
        {
            TextBox v = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)v.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            TextBox v1 = (TextBox)currentRow.FindControl("txtporcentaje_o");

            string porcentaje = v1.Text;

            if(v1.Text==""){ porcentaje="0";}

            if (Convert.ToInt32(porcentaje) > 0 && Convert.ToInt32(porcentaje) < 101)
            {

                string var_porcentaje = "txtporcentaje_o";
                string var_cc = "txtcco_c";
                string cod = "4";
                string var_c = reset_valor(o_c.Text).ToString();
                string var_p = reset_valor(o_p.Text).ToString();
                string var_l = reset_valor(o_l.Text).ToString();
                string var_hyc = reset_valor(o_hyc.Text).ToString();
                string var_s = reset_valor(o_s.Text).ToString();
                string var_total = reset_valor(o_total.Text).ToString();
                calcular(grillaonce, var_porcentaje, var_cc, cod, var_c, var_p, var_l, var_hyc, var_s, var_total);

            }
            else
            {
                v1.Text = "";

            }
        }




        protected void txtporcentaje_c_TextChanged(object sender, EventArgs e)
        {
            TextBox v = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)v.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            TextBox v1 = (TextBox)currentRow.FindControl("txtporcentaje_c");

            string porcentaje = v1.Text;

            if(v1.Text==""){ porcentaje="0";}

            if (Convert.ToInt32(porcentaje) > 0 && Convert.ToInt32(porcentaje) < 101)
            {

                string var_porcentaje = "txtporcentaje_c";
                string var_cc = "txtccc_c";
                string cod = "5";
                string var_c = reset_valor(c_c.Text).ToString();
                string var_p = reset_valor(c_p.Text).ToString();
                string var_l = reset_valor(c_l.Text).ToString();
                string var_hyc = reset_valor(c_hyc.Text).ToString();
                string var_s = reset_valor(c_s.Text).ToString();
                string var_total = reset_valor(c_total.Text).ToString();
                calcular(grillacena, var_porcentaje, var_cc, cod, var_c, var_p, var_l, var_hyc, var_s, var_total);

            }
            else
            {
                v1.Text = "";

            }
        }

        protected void txtporcentaje_c2_TextChanged(object sender, EventArgs e)
        {
            TextBox v = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)v.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            TextBox v1 = (TextBox)currentRow.FindControl("txtporcentaje_c2");

            string porcentaje = v1.Text;

            if(v1.Text==""){ porcentaje="0";}

            if (Convert.ToInt32(porcentaje) > 0 && Convert.ToInt32(porcentaje) < 101)
            {
                string var_porcentaje = "txtporcentaje_c2";
                string var_cc = "txtccc2_c";
                string cod = "6";
                string var_c = reset_valor(c2_c.Text).ToString();
                string var_p = reset_valor(c2_p.Text).ToString();
                string var_l = reset_valor(c2_l.Text).ToString();
                string var_hyc = reset_valor(c2_hyc.Text).ToString();
                string var_s = reset_valor(c2_s.Text).ToString();
                string var_total = reset_valor(c2_total.Text).ToString();
                calcular(grillacolacion_noc, var_porcentaje, var_cc, cod, var_c, var_p, var_l, var_hyc, var_s, var_total);

            }
            else
            {
                v1.Text = "";

            }
        }

        protected void txtporcentaje_ce_TextChanged(object sender, EventArgs e)
        {
            TextBox v = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)v.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            TextBox v1 = (TextBox)currentRow.FindControl("txtporcentaje_ce");

            string porcentaje = v1.Text;

            
            if(v1.Text==""){ porcentaje="0";}

            if (Convert.ToInt32(porcentaje) > 0 && Convert.ToInt32(porcentaje) < 101)
            {

                string var_porcentaje = "txtporcentaje_ce";
                string var_cc = "txtccce_c";
                string cod = "7";
                string var_c = reset_valor(ce_c.Text).ToString();
                string var_p = reset_valor(ce_p.Text).ToString();
                string var_l = reset_valor(ce_l.Text).ToString();
                string var_hyc = reset_valor(ce_hyc.Text).ToString();
                string var_s = reset_valor(ce_s.Text).ToString();
                string var_total = reset_valor(ce_total.Text).ToString();
                calcular(grillacolacion_noc, var_porcentaje, var_cc, cod, var_c, var_p, var_l, var_hyc, var_s, var_total);

            }
            else
            {
                v1.Text = "";

            }
        }


        protected void txtporcentaje_hco_TextChanged(object sender, EventArgs e)
        {
            TextBox v = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)v.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            TextBox v1 = (TextBox)currentRow.FindControl("txtporcentaje_hco");

            string porcentaje = v1.Text;

             if(v1.Text==""){ porcentaje="0";}

            if (Convert.ToInt32(porcentaje) > 0 && Convert.ToInt32(porcentaje) < 101)
            {

                string var_porcentaje = "txtporcentaje_hco";
                string var_cc = "txtcchco_c";
                string cod = "8";
                string var_c = reset_valor(hco_c.Text).ToString();
                string var_p = reset_valor(hco_p.Text).ToString();
                string var_l = reset_valor(hco_l.Text).ToString();
                string var_hyc = reset_valor(hco_hyc.Text).ToString();
                string var_s = reset_valor(hco_s.Text).ToString();
                string var_total = reset_valor(hco_total.Text).ToString();
                calcular(grillahidrico, var_porcentaje, var_cc, cod, var_c, var_p, var_l, var_hyc, var_s, var_total);

            }
            else
            {
                v1.Text = "";

            }
        }


        protected void calcular(GridView grilla, string var_porcentaje, string var_cc, string cod, string var_c, string var_p, string var_l, string var_hyc, string var_s, string var_total)
        {

            double res = 0; double r_calorias = 0; double r_proteinas = 0; double r_lipidos = 0; double r_hyc = 0; double r_sodio = 0; double r_cc_i = 0; double r_gr_c = 0;
            double cod_ajc = 0; double cod_ajp = 0; double cod_ajl = 0; double cod_ajhyc = 0; double cod_ajs = 0; double cod_ajtotal = 0;
            double calorias = 0; double proteinas = 0; double lipidos = 0; double hyc = 0; double sodio = 0; double cc_i = 0; double gr_consumidos = 0;
            double cc_c = 0; double c_total = 0; int cod_al = 0; double gr_i = 0; double porcentaje = 0;
            res_c = 0; res_p = 0; res_l = 0; res_hyc = 0; res_s = 0; res_total = 0;
            string v_gr = ""; string v_cc = "";
            int cantidad = 0;
            TextBox valor_1;
            TextBox valor_2;
            TextBox valor_3;

         
               
                foreach (GridViewRow row in grilla.Rows)
                {

                    res = 0;
                    r_calorias = 0;
                    r_proteinas = 0;
                    r_lipidos = 0;
                    r_hyc = 0;
                    r_sodio = 0;
                   
                    cod_al = Convert.ToInt32(grilla.DataKeys[row.RowIndex]["_Cod_tipo_alimentos"].ToString());
                    cod_ingesta = Convert.ToInt32(grilla.DataKeys[row.RowIndex]["_Ing_id"].ToString());
                    cantidad = Convert.ToInt32(row.Cells[1].Text.Equals(string.Empty) ? 0 : Convert.ToDouble(row.Cells[1].Text));
                   // gr_i = Convert.ToDouble(row.Cells[3].Text.Equals(string.Empty) ? 0 : Convert.ToDouble(row.Cells[3].Text));
                    //   gr_consumidos = Convert.ToInt32(grilla.DataKeys[row.RowIndex]["_Ing_gr_c"].ToString());
                    calorias = Convert.ToDouble(grilla.DataKeys[row.RowIndex]["_Calorias"].ToString());
                    proteinas = Convert.ToDouble(grilla.DataKeys[row.RowIndex]["_Proteinas"].ToString());
                    lipidos = Convert.ToDouble(grilla.DataKeys[row.RowIndex]["_Lipidos"].ToString());
                    hyc = Convert.ToDouble(grilla.DataKeys[row.RowIndex]["_Hyc"].ToString());
                    sodio = Convert.ToDouble(grilla.DataKeys[row.RowIndex]["_Sodio"].ToString());
                    //cc_i = Convert.ToDouble(row.Cells[10].Text.Equals(string.Empty) ? 0 : Convert.ToDouble(row.Cells[10].Text));

                    valor_1 = row.FindControl(var_porcentaje) as TextBox;
                    porcentaje = reset_valor(valor_1.Text);                  
                   
                    if (gr_i >= 0)
                    {

                        //    calcular 


                        #region  Porcentaje consumido

                        res = porcentaje;

                        #endregion

                        #region  Calculo Gramos Consumidos
                        gr_i =  Convert.ToDouble(row.Cells[3].Text.ToString()) * Convert.ToInt32(row.Cells[1].Text.ToString());
                        
                        r_gr_c = calculo_consumo(res, gr_i);
                        row.Cells[4].Text = r_gr_c.ToString();
                        res_gr = res_gr + r_gr_c;

                        #endregion

                        #region  Calculo Calorias
                        calorias = calorias * cantidad;
                        r_calorias = calculo_consumo(res, calorias);
                        row.Cells[5].Text = r_calorias.ToString();
                        res_c = res_c + (r_calorias);
                        
                        #endregion

                        #region  Calculo Proteinas
                        proteinas = proteinas * cantidad;
                        r_proteinas = calculo_consumo(res, proteinas);
                        row.Cells[6].Text = r_proteinas.ToString();
                        res_p = res_p + r_proteinas;

                        #endregion

                        #region  Calculo Lipidos
                        lipidos = lipidos * cantidad;
                        r_lipidos = calculo_consumo(res, lipidos);
                        row.Cells[7].Text = r_lipidos.ToString();
                        res_l = res_l + r_lipidos;

                        #endregion

                        #region  Calculo Hyc
                        hyc = hyc * cantidad;
                        r_hyc = calculo_consumo(res, hyc);
                        row.Cells[8].Text = r_hyc.ToString();
                        res_hyc = res_hyc + r_hyc;

                        #endregion

                        #region  Calculo Sodio
                        sodio = sodio * cantidad;
                        r_sodio = calculo_consumo(res, sodio);
                        row.Cells[9].Text = r_sodio.ToString();
                        res_s = res_s + r_sodio;

                        #endregion

 
                    }
                    else
                    {
                        res_c = 0;
                        res_p = 0;
                        res_l = 0;
                        res_hyc = 0;
                        res_s = 0;
                        res_total = 0;
                    }
                    TextBox val2 = row.FindControl(var_cc) as TextBox;
                    cc_i = Convert.ToDouble(row.Cells[10].Text.ToString()) * Convert.ToInt32(row.Cells[1].Text.ToString());
                   r_cc_i = calculo_consumo(res, cc_i);     
                    val2.Text = r_cc_i.ToString();
                    c_total = c_total + Convert.ToDouble(r_cc_i);
                }
            
            llenar_ajuste(grilla, cod,var_cc);
        }


        protected void llenar_ajuste(GridView grilla, string cod,string var_cc)
        {
            int tol = 0; int cont = 0; double total_gr_c = 0;
            double c_total1 = 0; double p_total = 0; double l_total = 0; double hyc_total = 0; double s_total = 0; double total = 0; double cc_total = 0; double gr_total = 0;
            TextBox valor_cc;
            foreach (GridViewRow row1 in grilla.Rows)
            {
                cont++;

                total_gr_c = total_gr_c + Convert.ToDouble(row1.Cells[4].Text.Equals(string.Empty) ? 0 : Convert.ToDouble(row1.Cells[4].Text));
                c_total1 = c_total1 + Convert.ToDouble(row1.Cells[5].Text.Equals(string.Empty) ? 0 : Convert.ToDouble(row1.Cells[5].Text));
                p_total = p_total + Convert.ToDouble(row1.Cells[6].Text.Equals(string.Empty) ? 0 : Convert.ToDouble(row1.Cells[6].Text));
                l_total = l_total + Convert.ToDouble(row1.Cells[7].Text.Equals(string.Empty) ? 0 : Convert.ToDouble(row1.Cells[7].Text));
                hyc_total = hyc_total + Convert.ToDouble(row1.Cells[8].Text.Equals(string.Empty) ? 0 : Convert.ToDouble(row1.Cells[8].Text));
                s_total = s_total + Convert.ToDouble(row1.Cells[9].Text.Equals(string.Empty) ? 0 : Convert.ToDouble(row1.Cells[9].Text));

                valor_cc = row1.FindControl(var_cc) as TextBox;
             
                cc_total = cc_total + Convert.ToDouble(reset_valor(valor_cc.Text));



            }
            switch (cod)
            {
                case "1":
                    sd_gr_c.Text = total_gr_c.ToString();
                    d_c.Text = c_total1.ToString(); sd_c.Text = c_total1.ToString();
                    d_p.Text = p_total.ToString(); sd_p.Text = p_total.ToString();
                    d_l.Text = l_total.ToString(); sd_l.Text = l_total.ToString();
                    d_hyc.Text = hyc_total.ToString(); sd_hyc.Text = hyc_total.ToString();
                    d_s.Text = s_total.ToString(); sd_s.Text = s_total.ToString();
                    d_total.Text = cc_total.ToString(); sd_total.Text = cc_total.ToString();

                    break;
                case "2":
                    sc1_gr_c.Text = total_gr_c.ToString();
                    c1_c.Text = c_total1.ToString(); sc1_c.Text = c_total1.ToString();
                    c1_p.Text = p_total.ToString(); sc1_p.Text = p_total.ToString();
                    c1_l.Text = l_total.ToString(); sc1_l.Text = l_total.ToString();
                    c1_hyc.Text = hyc_total.ToString(); sc1_hyc.Text = hyc_total.ToString();
                    c1_s.Text = s_total.ToString(); sc1_s.Text = s_total.ToString();
                    c1_total.Text = cc_total.ToString(); sc1_total.Text = cc_total.ToString();

                    break;
                case "3":
                    sa_gr_c.Text = total_gr_c.ToString();
                    a_c.Text = c_total1.ToString(); sa_c.Text = c_total1.ToString();
                    a_p.Text = p_total.ToString(); sa_p.Text = p_total.ToString();
                    a_l.Text = l_total.ToString(); sa_l.Text = l_total.ToString();
                    a_hyc.Text = hyc_total.ToString(); sa_hyc.Text = hyc_total.ToString();
                    a_s.Text = s_total.ToString(); sa_s.Text = s_total.ToString();
                    a_total.Text = cc_total.ToString(); sa_total.Text = cc_total.ToString();

                    break;
                case "4":
                    so_gr_c.Text = total_gr_c.ToString();
                    o_c.Text = c_total1.ToString(); so_c.Text = c_total1.ToString();
                    o_p.Text = p_total.ToString(); so_p.Text = p_total.ToString();
                    o_l.Text = l_total.ToString(); so_l.Text = l_total.ToString();
                    o_hyc.Text = hyc_total.ToString(); so_hyc.Text = hyc_total.ToString();
                    o_s.Text = s_total.ToString(); so_s.Text = s_total.ToString();
                    o_total.Text = cc_total.ToString(); so_total.Text = cc_total.ToString();

                    break;
                case "5":
                    sc_gr_c.Text = total_gr_c.ToString();
                    c_c.Text = c_total1.ToString(); sc_c.Text = c_total1.ToString();
                    c_p.Text = p_total.ToString(); sc_p.Text = p_total.ToString();
                    c_l.Text = l_total.ToString(); sc_l.Text = l_total.ToString();
                    c_hyc.Text = hyc_total.ToString(); sc_hyc.Text = hyc_total.ToString();
                    c_s.Text = s_total.ToString(); sc_s.Text = s_total.ToString();
                    c_total.Text = cc_total.ToString(); sc_total.Text = cc_total.ToString();

                    break;
                case "6":
                    sc2_gr_c.Text = total_gr_c.ToString();
                    c2_c.Text = c_total1.ToString(); sc2_c.Text = c_total1.ToString();
                    c2_p.Text = p_total.ToString(); sc2_p.Text = p_total.ToString();
                    c2_l.Text = l_total.ToString(); sc2_l.Text = l_total.ToString();
                    c2_hyc.Text = hyc_total.ToString(); sc2_hyc.Text = hyc_total.ToString();
                    c2_s.Text = s_total.ToString(); sc2_s.Text = s_total.ToString();
                    c2_total.Text = cc_total.ToString(); sc2_total.Text = cc_total.ToString();


                    break;
                case "7":
                    sce_gr_c.Text = total_gr_c.ToString();
                    ce_c.Text = c_total1.ToString(); sce_c.Text = c_total1.ToString();
                    ce_p.Text = p_total.ToString(); sce_p.Text = p_total.ToString();
                    ce_l.Text = l_total.ToString(); sce_l.Text = l_total.ToString();
                    ce_hyc.Text = hyc_total.ToString(); sce_hyc.Text = hyc_total.ToString();
                    ce_s.Text = s_total.ToString(); sce_s.Text = s_total.ToString();
                    ce_total.Text = cc_total.ToString(); sce_total.Text = cc_total.ToString();


                    break;
                case "8":
                    shco_gr_c.Text = total_gr_c.ToString();
                    hco_c.Text = c_total1.ToString(); shco_c.Text = c_total1.ToString();
                    hco_p.Text = p_total.ToString(); shco_p.Text = p_total.ToString();
                    hco_l.Text = l_total.ToString(); shco_l.Text = l_total.ToString();
                    hco_hyc.Text = hyc_total.ToString(); shco_hyc.Text = hyc_total.ToString();
                    hco_s.Text = s_total.ToString(); shco_s.Text = s_total.ToString();
                    hco_total.Text = cc_total.ToString(); shco_total.Text = cc_total.ToString();

                    break;

            }

            calcular_resumen(cod, c_total1.ToString(), p_total.ToString(), l_total.ToString(), hyc_total.ToString(), s_total.ToString(), cc_total.ToString(), total_gr_c);
            calcular__total();  
        }
      

      
    }
}