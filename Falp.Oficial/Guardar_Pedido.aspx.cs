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
    public partial class Guardar_Pedido : System.Web.UI.Page
    {


        #region Variables

        #region Variables Staticas

        string user = "";
        static string cod_estado = "";
        static string cod_cama = "";
        static string cod_paciente = "";
        static string cod_pedido = "";
        static string nom_paciente = "";
        static string cod_alimento = "";
        static int cod_alimentoaux = 0;
        static int cod_estado_alimento = 0;
        static int cod_especial = 0;
        static int cod_super_especial = 0;

        static int cod_regimen = 0;
        static int cod_aislamiento = 0;
        static int cod_bandeja = 0;

        static int cod_distribucion = 0;

        static string comentario_tiempo_comida = "";
        static string mixto = "";
        static string comentario_alimento = "";
        static int cod_tipo_comida = 0;

        static string vig = "";
        static string vale = "";
        static string ingesta = "";

        static int cod_consistencia_fil = 0;
        static int cod_cobro_fil = 0;
        static int cod_digestabilidad_fil = 0;
        static int cod_lactosa_fil = 0;
        static int cod_dulzor_fil = 0;
        static int cod_sal_fil = 0;



        //  CODIGOS  DE COMPONENTES

        static int cod_consistencia = 0;
        static int cod_digestabilidad = 0;
        static int cod_lactosa = 0;
        static int cod_dulzor = 0;
        static int cod_sal = 0;
        static int cod_temperatura = 0;
        static int cod_volumen = 0;


        #region variables tipo comida

        static int var_cod_desayuno = 1;
        static int var_cod_colacion_matinal = 2;
        static int var_cod_almuerzo = 3;
        static int var_cod_once = 4;
        static int var_cod_cena = 5;
        static int var_cod_colacion_nocturna = 6;
        static int var_cod_colacion_extra = 7;
        static int var_cod_hidricos = 8;

        #endregion

        #region variables Distribucion

        static int var_cod_sopa = 1;
        static int var_cod_ensalada = 2;
        static int var_cod_plato_fondo = 3;
        static int var_cod_acompañamiento = 4;
        static int var_cod_postre = 5;
        static int var_cod_liquido = 7;
        static int var_cod_solido = 8;
        static int var_cod_agregado = 9;
        static int var_cod_hidrico = 10;
        #endregion

        #endregion

        #region Datatables

        static DataTable dtalimentos_liquido = new DataTable();
        static DataTable dtalimentos_solido = new DataTable();
        static DataTable dtalimentos_agregado = new DataTable();
        static DataTable dtalimentos_sopa = new DataTable();
        static DataTable dtalimentos_ensaladas = new DataTable();
        static DataTable dtalimentos_plato_fondo = new DataTable();
        static DataTable dtalimentos_acompañamiento = new DataTable();
        static DataTable dtalimentos_postre = new DataTable();
        static DataTable dtalimentos_hidricos = new DataTable();
        static DataTable dtextra_agregado = new DataTable();
        static DataTable dt = new DataTable();
        static DataTable dt_pedido_registrado = new DataTable();
        static DataTable dtalimentos = new DataTable();

        #region DataTable_especial

        static DataTable dtsuper_especial = new DataTable();
        static DataTable dtespecial = new DataTable();
        static DataTable dtespecial_2 = new DataTable();
        static DataTable dt_componentes = new DataTable();
        static int cod_alimento_especial_2 = 0;
        static string nom_alimento_especial_2 = "";
        #endregion

        #region DataTable_extras

        static DataTable dtextra = new DataTable();
        static DataTable dtextras_2 = new DataTable();
        static int cod_alimento_extras_2 = 0;
        static string nom_alimento_extras_2 = "";
        #endregion

        #endregion

        #region   Listas

        List<string> list_dt = new List<string>();
        List<string> list_dtespecial = new List<string>();
        List<string> list_dtsuper_especial = new List<string>();

        #endregion

        #region Datos Conexion

        #endregion

        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["Usuario"] != null)
                {

                    user = Session["Usuario"].ToString();
                    txtalimento.Text = Session["Tipo_Alimento"].ToString();
                    cod_pedido = Session["_Cod_pedido"].ToString();
                    cod_tipo_comida = Convert.ToInt32(Session["_Cod_tipo_comida"].ToString());
                    bloquear_componentes();
                    cargar_vig();
                    btn_agregar_ali.Visible = false;
                    Cargar_tipo_consistencia();
                    Cargar_tipo_digestabilidad();
                    Cargar_tipo_dulzor();
                    Cargar_tipo_lactosa();
                    Cargar_tipo_sal();
                    Cargar_tipo_temperatura();
                    Cargar_tipo_volumen();

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

        protected void cargar_vig()
        {
            vig = Session["VIG"].ToString();
           // vale = Session["_Vale"].ToString();
          
            if (vig == "N")
            {
                bloquear();

            }
            else
            {
                if (vig == "M")
                {

                    switch (cod_tipo_comida)
                    {
                        case 1:
                            string ingesta_d = Session["_Ingesta_d"].ToString();
                            if (ingesta_d == "S")
                            {
                                bloquear_colacion();

                            }
                            else
                            {
                                habilitar_colacion();
                            }
                            break;

                        case 8:
                            string ingesta_hco = Session["_Ingesta_hco"].ToString();
                            if (ingesta_hco == "S")
                            {
                                Cargar_datos_pedidos();
                                cargar_grillas();
                                cbotemperatura2.Enabled = false;
                                cbovolumen2.Enabled = false;
                                cboconsistencia.Enabled = false;
                                cbodigestabilidad.Enabled = false;
                                txtcomentario.Enabled = false;

                                cbodulzor.Enabled = false;
                                cbolactosa.Enabled = false;
                                cbotipo_sal.Enabled = false;

                                btn_guardar_1.Enabled = false;
                                btn_origen.Enabled = false;
                                btn_ag_hidrico_2.Enabled = false;
                                grilla_hidrico.Enabled = false;


                            }
                            else
                            {
                                Cargar_datos_pedidos();
                                cargar_grillas();
                                cbotemperatura2.Enabled = true;
                                cbovolumen2.Enabled = true;
                                cboconsistencia.Enabled = true;
                                cbodigestabilidad.Enabled = true;
                                txtcomentario.Enabled = true;

                                cbodulzor.Enabled = true;
                                cbolactosa.Enabled = true;
                                cbotipo_sal.Enabled = true;

                                btn_guardar_1.Enabled = true;
                                btn_origen.Enabled = true;
                                btn_ag_hidrico_2.Enabled = true;
                                grilla_hidrico.Enabled = true;
                            }

                            break;
                    }
                }

                else
                {

                    switch (cod_tipo_comida)
                    {
                        case 1:
                            string ingesta_d = Session["_Ingesta_d"].ToString();
                            if (ingesta_d == "S")
                            {
                                bloquear_colacion();

                            }
                            else
                            {
                                habilitar_colacion();
                            }

                            break;
                        case 2:
                            string ingesta_c1 = Session["_Ingesta_c1"].ToString();
                            if (ingesta_c1 == "S")
                            {
                                bloquear_colacion();
                            }
                            else
                            {
                                habilitar_colacion();
                            }


                            break;
                        case 3:
                            string ingesta_a = Session["_Ingesta_a"].ToString();
                            if (ingesta_a == "S")
                            {
                                bloquear_almuerzosycena();
                            }
                            else
                            {
                                habilitar_almuerzosycena();
                            }

                            break;
                        case 4:
                            string ingesta_o = Session["_Ingesta_o"].ToString();
                            if (ingesta_o == "S")
                            {
                                bloquear_colacion();
                            }
                            else
                            {
                                habilitar_colacion();
                            }

                            break;
                        case 5:
                            string ingesta_c = Session["_Ingesta_c"].ToString();
                            if (ingesta_c == "S")
                            {
                                bloquear_almuerzosycena();
                            }
                            else
                            {
                                habilitar_almuerzosycena();
                            }


                            break;
                        case 6:
                            string ingesta_c2 = Session["_Ingesta_c2"].ToString();
                            if (ingesta_c2 == "S")
                            {
                                bloquear_colacion();
                            }
                            else
                            {
                                habilitar_colacion();
                            }

                            break;
                        case 7:
                            string ingesta_ce = Session["_Ingesta_ce"].ToString();
                            if (ingesta_ce == "S")
                            {
                                bloquear_colacion();
                            }
                            else
                            {
                                habilitar_colacion();
                            }

                            break;
                        case 8:
                            string ingesta_hco = Session["_Ingesta_hco"].ToString();
                            if (ingesta_hco == "S")
                            {
                                Cargar_datos_pedidos();
                                cargar_grillas();
                                cbotemperatura2.Enabled = false;
                                cbovolumen2.Enabled = false;
                                cboconsistencia.Enabled = false;
                                cbodigestabilidad.Enabled = false;
                                txtcomentario.Enabled = false;

                                cbodulzor.Enabled = false;
                                cbolactosa.Enabled = false;
                                cbotipo_sal.Enabled = false;

                                btn_guardar_1.Enabled = false;
                                btn_origen.Enabled = false;
                                btn_ag_hidrico_2.Enabled = false;
                                grilla_hidrico.Enabled = false;


                            }
                            else
                            {
                                Cargar_datos_pedidos();
                                cargar_grillas();
                                cbotemperatura2.Enabled = true;
                                cbovolumen2.Enabled = true;
                                cboconsistencia.Enabled = true;
                                cbodigestabilidad.Enabled = true;
                                txtcomentario.Enabled = true;

                                cbodulzor.Enabled = true;
                                cbolactosa.Enabled = true;
                                cbotipo_sal.Enabled = true;

                                btn_guardar_1.Enabled = true;
                                btn_origen.Enabled = true;
                                btn_ag_hidrico_2.Enabled = true;
                                grilla_hidrico.Enabled = true;
                            }


                            break;

                    }
                }
               

            }
        }


        #region Cargar Conexion

        #endregion

        #region Cargar Grilla

        #region Listar Grilla

        #region Liquido

        protected void cargar_dt_liquido()
        {
            // dtalimentos_liquido = (DataTable)Session["tbl_alimentos_liquido"];
            dtalimentos_liquido.Clear();
            grilla_liquido.DataSource = dtalimentos_liquido;
            grilla_liquido.DataBind();
        }

        protected void cargar_dt_solido()
        {
            // dtalimentos_liquido = (DataTable)Session["tbl_alimentos_liquido"];
            dtalimentos_solido.Clear();
            grilla_solido.DataSource = dtalimentos_solido;
            grilla_solido.DataBind();
        }

        protected void cargar_dt_agregado()
        {
            // dtalimentos_liquido = (DataTable)Session["tbl_alimentos_liquido"];
            dtalimentos_agregado.Clear();
            grilla_agregado.DataSource = dtalimentos_agregado;
            grilla_agregado.DataBind();
        }

        protected void Cargar_grilla_extra_especiales()
        {

            cod_tipo_comida = Convert.ToInt32(Session["_Cod_tipo_comida"].ToString());
            int cod_tipo_distribucion = Convert.ToInt32(Session["_Cod_Distribucion"].ToString());// Convert.ToInt32(cbotipo_distribucion.SelectedValue);
            List<Utilidades> lista_alimentos_menu_extra = new UtilidadesNE().Cargar_alimentos_menu_especiales(cod_tipo_comida, cod_tipo_distribucion, "");

            dtespecial = ConvertToDataTable(lista_alimentos_menu_extra);
            dtespecial.AcceptChanges();
            Session["tbl_alimentos_especiales"] = dtespecial;
            grilla_especial.DataSource = new DataView(dtespecial, "_Vigencia ='S' and _Cod_tipo_distribucion=" + cod_tipo_distribucion + "", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
            grilla_especial.DataBind();


        }

        protected DataTable Cargar_grilla_extra_especiales_codigo()
        {
            DataTable dt_2 = new DataTable();
            int cod_tipo_distribucion = Convert.ToInt32(Session["_Cod_Distribucion"].ToString());// Convert.ToInt32(cbotipo_distribucion.SelectedValue);
            List<Utilidades> lista_alimentos_menu_extra = new UtilidadesNE().Cargar_alimentos_especiales_cod(cod_tipo_distribucion);

            dt_componentes = ConvertToDataTable(lista_alimentos_menu_extra);
            Session["dt_componentes"] = dt_componentes;
            return dt_2;

        }




        #endregion


        #region Hidricos


        protected void cargar_dt_hidrico()
        {
            dtalimentos_hidricos.Clear();
            grilla_hidrico.DataSource = dtalimentos_hidricos;
            grilla_hidrico.DataBind();
        }

        #endregion

        #endregion

        #region Agrupar

        #endregion

        #region Agregar Imagen

        #endregion

        #region Ocultar Columnas

        #endregion

        #region Ordenar Columnas

        #endregion

        #region Pintar Grilla

        #endregion

        #region Pintar Extraer grilla

        #region Extraer Componetes del alimento Extras y Especiales

        protected void grilla_extra_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grilla_extra.Rows)
            {
                if (row.RowIndex == grilla_extra.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    cod_alimento = grilla_extra.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                    cod_alimentoaux = Convert.ToInt32(cod_alimento);
                    Session["_Cod_tipo_alimento"] = cod_alimento;
                    Session["_Nom_tipo_alimento"] = row.Cells[2].Text.Trim();
                    Session["_Nom_tipo_distribucion"] = row.Cells[1].Text.Trim();
                    Session["Tipo"] = row.Cells[3].Text.Trim();

                     if(cod_distribucion==8)
                     {
                        int _num_dis=  Convert.ToInt32(grilla_extra.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString());
                         if(_num_dis==5)
                         {
                             Session["_Cod_Distribucion"] = "8";
                         }
                     }
                     else
                     {
                         Session["_Cod_Distribucion"] = grilla_extra.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString();
                     }
                 
                    cod_alimento = grilla_extra.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();

                    cod_consistencia = Convert.ToInt32(grilla_extra.DataKeys[row.RowIndex]["_Cod_tipo_consistencia"].ToString());
                    cod_digestabilidad = Convert.ToInt32(grilla_extra.DataKeys[row.RowIndex]["_Cod_tipo_digestabilidad"].ToString());
                    cod_lactosa = Convert.ToInt32(grilla_extra.DataKeys[row.RowIndex]["_Cod_lactosa"].ToString());
                    cod_dulzor = Convert.ToInt32(grilla_extra.DataKeys[row.RowIndex]["_Cod_dulzor"].ToString());
                    cod_temperatura = Convert.ToInt32(grilla_extra.DataKeys[row.RowIndex]["_Cod_tipo_temperatura"].ToString());
                    cod_volumen = Convert.ToInt32(grilla_extra.DataKeys[row.RowIndex]["_Cod_tipo_volumen"].ToString());
                    cod_sal = Convert.ToInt32(grilla_extra.DataKeys[row.RowIndex]["_Cod_tipo_sales"].ToString());

                    guardar_alimento_extra();
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }

        }

        protected void grilla_extra_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grilla_extra, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void grilla_especial2_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grilla_especial, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void grilla_especial2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grilla_especial.Rows)
            {
                if (row.RowIndex == grilla_especial.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    cod_alimento = grilla_especial.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                    cod_alimentoaux = Convert.ToInt32(cod_alimento);
                    cod_alimento_especial_2 = Convert.ToInt32(cod_alimento);
                    Session["_Cod_tipo_alimento"] = cod_alimento;
                    Session["_Nom_tipo_alimento"] = row.Cells[2].Text.Trim();
                    nom_alimento_especial_2=row.Cells[2].Text.Trim();
                    Session["_Nom_tipo_distribucion"] = row.Cells[1].Text.Trim();
                    Session["Tipo"] = row.Cells[3].Text.Trim();
                    cod_alimento = grilla_especial.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();

                    cod_consistencia = Convert.ToInt32(grilla_especial.DataKeys[row.RowIndex]["_Cod_tipo_consistencia"].ToString());
                    cod_digestabilidad = Convert.ToInt32(grilla_especial.DataKeys[row.RowIndex]["_Cod_tipo_digestabilidad"].ToString());
                    cod_lactosa = Convert.ToInt32(grilla_especial.DataKeys[row.RowIndex]["_Cod_lactosa"].ToString());
                    cod_dulzor = Convert.ToInt32(grilla_especial.DataKeys[row.RowIndex]["_Cod_dulzor"].ToString());
                    cod_temperatura = Convert.ToInt32(grilla_especial.DataKeys[row.RowIndex]["_Cod_tipo_temperatura"].ToString());
                    cod_volumen = Convert.ToInt32(grilla_especial.DataKeys[row.RowIndex]["_Cod_tipo_volumen"].ToString());
                    cod_sal = Convert.ToInt32(grilla_especial.DataKeys[row.RowIndex]["_Cod_tipo_sales"].ToString());
                    guardar_alimento_extra();
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }




        }

        #endregion

        #endregion

        #endregion

        #region Cargar DataTables

        #endregion


        #endregion

        #region Botones

        #region Botones Agregar Alimentos Extras o Especiales

        protected void btn_agregar_liquido(object sender, EventArgs e)
        {
            cod_alimentoaux = 0;
            Session["_Cod_tipo_alimento"] = "";
            dtextra.Clear();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { Agregar(); });", true);
            Session["_Cod_Distribucion"] = var_cod_liquido;
            cod_distribucion = var_cod_liquido;
            Session["_Nom_tipo_distribucion"] = "LIQUIDO";
            Cargar_extras_condicionados();
            Cargar_grilla_extra_especiales();
            Cargar_grilla_extra_especiales_codigo();
            txtespecial.Text = "";
           // txtmsg.Text = "Estimado usuario, El Alimento sea  Registrado Correctamente";
         //   Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);



        }

        protected void btn_agregar_solido(object sender, EventArgs e)
        {
            cod_alimentoaux = 0;
            Session["_Cod_tipo_alimento"] = "";
            dtextra.Clear();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { Agregar(); });", true);
            Session["_Cod_Distribucion"] = var_cod_solido;
            cod_distribucion = var_cod_solido;
            Session["_Nom_tipo_distribucion"] = "SOLIDO";
            txtespecial.Text = "";
            Cargar_extras_condicionados();
            Cargar_grilla_extra_especiales();
            Cargar_grilla_extra_especiales_codigo();
          //  txtmsg.Text = "Estimado usuario, El Alimento sea  Registrado Correctamente";
           // Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
        }

        protected void btn_agregar_agregado(object sender, EventArgs e)
        {
            cod_alimentoaux = 0;
            Session["_Cod_tipo_alimento"] = "";
            dtextra.Clear();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { Agregar(); });", true);
            Session["_Cod_Distribucion"] = var_cod_agregado;
            txtespecial.Text = "";
            cod_distribucion = var_cod_agregado;
            Session["_Nom_tipo_distribucion"] = "AGREGADO";
            Cargar_extras_condicionados();
            Cargar_grilla_extra_especiales();
            Cargar_grilla_extra_especiales_codigo();

          //  txtmsg.Text = "Estimado usuario, El Alimento sea  Registrado Correctamente";
           // Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
        }

        protected void btn_agregar_sopa(object sender, EventArgs e)
        {
            cod_alimentoaux = 0;
            Session["_Cod_tipo_alimento"] = "";
            dtextra.Clear();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { Agregar(); });", true);
            Session["_Cod_Distribucion"] = var_cod_sopa;
            txtespecial.Text = "";
            cod_distribucion = var_cod_sopa;
            Session["_Nom_tipo_distribucion"] = "SOPA";
            Cargar_extras_condicionados();
            Cargar_grilla_extra_especiales();
            Cargar_grilla_extra_especiales_codigo();

            //txtmsg.Text = "Estimado usuario, El Alimento sea  Registrado Correctamente";
           // Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
        }

        protected void btn_agregar_ensalada(object sender, EventArgs e)
        {
            cod_alimentoaux = 0;
            Session["_Cod_tipo_alimento"] = "";
            dtextra.Clear();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { Agregar(); });", true);
            Session["_Cod_Distribucion"] = var_cod_ensalada;
            txtespecial.Text = "";
            cod_distribucion = var_cod_ensalada;
            Session["_Nom_tipo_distribucion"] = "ENSALADA";
            Cargar_extras_condicionados();
            Cargar_grilla_extra_especiales();
            Cargar_grilla_extra_especiales_codigo();

          //  txtmsg.Text = "Estimado usuario, El Alimento sea  Registrado Correctamente";
          //  Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
        }

        protected void btn_agregar_plato_fondo(object sender, EventArgs e)
        {
            cod_alimentoaux = 0;
            Session["_Cod_tipo_alimento"] = "";
            dtextra.Clear();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { Agregar(); });", true);
            Session["_Cod_Distribucion"] = var_cod_plato_fondo;
            cod_distribucion = var_cod_plato_fondo;
            Session["_Nom_tipo_distribucion"] = "PLATO FONDO";
            Cargar_extras_condicionados();
            Cargar_grilla_extra_especiales();
            Cargar_grilla_extra_especiales_codigo();
            txtespecial.Text = "";
          //  txtmsg.Text = "Estimado usuario, El Alimento sea  Registrado Correctamente";
          //  Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
        }

        protected void btn_agregar_acompañamiento(object sender, EventArgs e)
        {
            cod_alimentoaux = 0;
            Session["_Cod_tipo_alimento"] = "";
            dtextra.Clear();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { Agregar(); });", true);
            Session["_Cod_Distribucion"] = var_cod_acompañamiento;
            cod_distribucion = var_cod_acompañamiento;
            Session["_Nom_tipo_distribucion"] = "ACOMPAÑAMIENTO";
            Cargar_extras_condicionados();
            Cargar_grilla_extra_especiales();
            Cargar_grilla_extra_especiales_codigo();
            txtespecial.Text = "";
          //  txtmsg.Text = "Estimado usuario, El Alimento sea  Registrado Correctamente";
          //  Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

        }

        protected void btn_agregar_postre(object sender, EventArgs e)
        {
            cod_alimentoaux = 0;
            Session["_Cod_tipo_alimento"] = "";
            dtextra.Clear();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { Agregar(); });", true);
            Session["_Cod_Distribucion"] = var_cod_postre;
            cod_distribucion = var_cod_postre;
            txtespecial.Text = "";
            Session["_Nom_tipo_distribucion"] = "POSTRE";
            Cargar_extras_condicionados();
            Cargar_grilla_extra_especiales();
            Cargar_grilla_extra_especiales_codigo();


        //    txtmsg.Text = "Estimado usuario, El Alimento sea  Registrado Correctamente";
          //  Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

        }

        protected void btn_agregar_hidrico(object sender, EventArgs e)
        {
            cod_alimentoaux = 0;
            Session["_Cod_tipo_alimento"] = "";
            dtextra.Clear();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { Agregar(); });", true);
            Session["_Cod_Distribucion"] = var_cod_hidrico;
            cod_distribucion = var_cod_hidrico;
            Session["_Nom_tipo_distribucion"] = "HIDRICOS";
            Cargar_extras_condicionados();
            Cargar_grilla_extra_especiales();
            Cargar_grilla_extra_especiales_codigo();
            txtespecial.Text = "";
         //   txtmsg.Text = "Estimado usuario, El Alimento sea  Registrado Correctamente";
         //   Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
        }

        protected void btn_cerrar(object sender, EventArgs e)
        {

        }

        #endregion

        #region Botone Volver  a Generar Pedido

        protected void volver(object sender, EventArgs e)
        {
            Response.Redirect("Generar_Pedido.aspx");
            Session["Tipo_Alimento"] = string.Empty;
        }

        protected void btn_volver(object sender, EventArgs e)
        {
            Response.Redirect("Listado_Camas.aspx");
        }

        #endregion

        #region Botones Eliminar


        protected void btn_eliminar_sopa(object sender, EventArgs e)
        {
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow row = (GridViewRow)btndetails.NamingContainer;
                string a = grilla_sopa.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                string d = grilla_sopa.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString();
                Session["_Cod_tipo_alimento"] = grilla_sopa.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                Session["_Cod_tipo_distribucion"] = grilla_sopa.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString();

                string nom = row.Cells[1].Text.Trim();
                delete();
                //   txtmsg2.Text = "Estimado usuario, Fue Eliminado  Correctamente  el Alimento " + nom + "";
                // Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "msg_1();", true);


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btn_eliminar_ensalada(object sender, EventArgs e)
        {
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow row = (GridViewRow)btndetails.NamingContainer;
                Session["_Cod_tipo_alimento"] = grilla_ensalada.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                Session["_Cod_tipo_distribucion"] = grilla_ensalada.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString();

                string nom = row.Cells[1].Text.Trim();
                delete();
                //txtmsg2.Text = "Estimado usuario, Fue Eliminado  Correctamente  el Alimento " + nom + "";
                //  Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "msg_1();", true);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btn_eliminar_plato_fondo(object sender, EventArgs e)
        {
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow row = (GridViewRow)btndetails.NamingContainer;
                Session["_Cod_tipo_alimento"] = grilla_plato_fondo.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                Session["_Cod_tipo_distribucion"] = grilla_plato_fondo.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString();
                string nom = row.Cells[1].Text.Trim();
                delete();
                // txtmsg2.Text = "Estimado usuario, Fue Eliminado  Correctamente  el Alimento " + nom + "";
                //  Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "msg_1();", true);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btn_eliminar_acompañamiento(object sender, EventArgs e)
        {
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow row = (GridViewRow)btndetails.NamingContainer;
                Session["_Cod_tipo_alimento"] = grilla_acompañamiento.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                Session["_Cod_tipo_distribucion"] = grilla_acompañamiento.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString();
                string nom = row.Cells[1].Text.Trim();
                delete();
                // txtmsg2.Text = "Estimado usuario, Fue Eliminado  Correctamente  el Alimento " + nom + "";
                //  Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "msg_1();", true);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btn_eliminar_postre(object sender, EventArgs e)
        {
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow row = (GridViewRow)btndetails.NamingContainer;
                Session["_Cod_tipo_alimento"] = grilla_postre.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                Session["_Cod_tipo_distribucion"] = grilla_postre.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString();
                string nom = row.Cells[1].Text.Trim();
                delete();
                // txtmsg2.Text = "Estimado usuario, Fue Eliminado  Correctamente  el Alimento " + nom + "";
                //  Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "msg_1();", true);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btn_eliminar_liquido(object sender, EventArgs e)
        {
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow row = (GridViewRow)btndetails.NamingContainer;
                Session["_Cod_tipo_alimento"] = grilla_liquido.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                string dis = grilla_liquido.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString();
                Session["_Cod_tipo_distribucion"] = grilla_liquido.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString();
                string nom = row.Cells[1].Text.Trim();
                delete();
                //  txtmsg2.Text = "Estimado usuario, Fue Eliminado  Correctamente  el Alimento '" + nom + "'";
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { msg_1(); });", true);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btn_eliminar_solido(object sender, EventArgs e)
        {
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow row = (GridViewRow)btndetails.NamingContainer;
                Session["_Cod_tipo_alimento"] = grilla_solido.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                Session["_Cod_tipo_distribucion"] = grilla_solido.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString();
                // txt_ali1.Text = row.Cells[1].Text.Trim().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                string nom = row.Cells[1].Text.Trim();
                delete();
                // txtmsg2.Text = "Estimado usuario, Fue Eliminado  Correctamente  el Alimento " + nom + "";
                //  Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "msg_1();", true);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btn_eliminar_agregado(object sender, EventArgs e)
        {
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow row = (GridViewRow)btndetails.NamingContainer;
                Session["_Cod_tipo_alimento"] = grilla_agregado.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                Session["_Cod_tipo_distribucion"] = grilla_agregado.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString();
                string nom = row.Cells[1].Text.Trim();
                delete();
                // txtmsg2.Text = "Estimado usuario, Fue Eliminado  Correctamente  el Alimento " + nom + "";
                //  Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "msg_1();", true);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btn_eliminar_hidrico(object sender, EventArgs e)
        {
            try
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow row = (GridViewRow)btndetails.NamingContainer;
                Session["_Cod_tipo_alimento"] = grilla_hidrico.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                Session["_Cod_tipo_distribucion"] = grilla_hidrico.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString();
                string nom = row.Cells[1].Text.Trim();
                delete();
                //  txtmsg2.Text = "Estimado usuario, Fue Eliminado  Correctamente  el Alimento " + nom + "";
                //  Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "msg_1();", true);
            }
            catch (Exception ex)
            {

                throw;
            }
        }




        #endregion

        #region Botones Extras y Especiales

        protected void buscar_extras(object sender, EventArgs e)
        {

            dtextra = (DataTable)Session["tbl_alimentos_extra"];
            DataView dvSol = dtextra.AsDataView();
            dvSol.RowFilter = "_Nom_tipo_alimento Like '" + txtextra.Text + "%'";

            grilla_extra.DataSource = dvSol;
            grilla_extra.DataBind();
            txtextra.Text = "";

            if (dvSol.Count > 0)
            {

            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { Agregar(); });", true);

        }






        #endregion

        #region Botones Guardar

        protected void Guardar(object sender, EventArgs e)
        {
            // Cargar_datos_pedidos();
            int cod = cod_tipo_comida;

            switch (cod)
            {
                case 1:

                    Guardar_liquido();
                    Guardar_solido();
                    Guardar_agregar();
                    Guardar_hidricos();



                    break;
                case 2:

                    Guardar_liquido();
                    Guardar_solido();
                    Guardar_agregar();
                    Guardar_hidricos();


                    break;
                case 3:

                    Guardar_sopa();
                    Guardar_ensalada();
                    Guardar_plato_fondo();
                    Guardar_acompañamiento();
                    Guardar_postre();
                    Guardar_hidricos();



                    break;
                case 4:

                    Guardar_liquido();
                    Guardar_solido();
                    Guardar_agregar();
                    Guardar_hidricos();


                    break;
                case 5:

                    Guardar_sopa();
                    Guardar_ensalada();
                    Guardar_plato_fondo();
                    Guardar_acompañamiento();
                    Guardar_postre();
                    Guardar_hidricos();

                    break;
                case 6:

                    Guardar_liquido();
                    Guardar_solido();
                    Guardar_agregar();
                    Guardar_hidricos();


                    break;
                case 7:

                    Guardar_liquido();
                    Guardar_solido();
                    Guardar_agregar();
                    Guardar_hidricos();


                    break;
                case 8:

                    Guardar_hidricos();


                    break;



                default:
                    Console.WriteLine("Default case");
                    break;
            }

          
            Cargar_datos_pedidos();
            cargar_grillas();

            Response.Redirect("Generar_Pedido.aspx");

        }

        #endregion

        #region Botones Volver Valores Originales

        protected void Volver_valores(object sender, EventArgs e)
        {
            restablacer_pedido();
            Cargar_datos_pedidos();
            cargar_grillas();

            cboconsistencia.SelectedIndex = 0;
            cbodigestabilidad.SelectedIndex = 0;
            cbolactosa.SelectedIndex = 0;
            cbodulzor.SelectedIndex = 0;
            cbotemperatura2.SelectedIndex = 0;
            cbovolumen2.SelectedIndex = 0;
            cbotipo_sal.SelectedIndex = 0;
            txtal.Text = "";
            ck_mixto.Checked = false;
            txtmsg2.Text = "Estimado usuario, Fue Restablecido  los Valores Originales ";
            Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "msg_1();", true);
        }

        #endregion



        #region Botones Volver Valores Originales

        protected void btn_agregar_cant_li(object sender, EventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow row = (GridViewRow)btndetails.NamingContainer;
            int cod_a = Convert.ToInt32(grilla_liquido.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString());
            int cod_d = Convert.ToInt32(grilla_liquido.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString());

            dtalimentos_liquido = Agregar_cantidad(dtalimentos_liquido,cod_d, cod_a);

            Session["tbl_alimentos_liquido"] = dtalimentos_liquido;
            dtalimentos_liquido.AcceptChanges();
            grilla_liquido.DataSource = new DataView(dtalimentos_liquido, "_Vigencia ='S' ", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
            grilla_liquido.DataBind();
        }

        protected void btn_agregar_cant_so(object sender, EventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow row = (GridViewRow)btndetails.NamingContainer;
            int cod_a = Convert.ToInt32(grilla_solido.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString());
            int cod_d = Convert.ToInt32(grilla_solido.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString());

            dtalimentos_solido = Agregar_cantidad(dtalimentos_solido, cod_d, cod_a);

            Session["tbl_alimentos_solido"] = dtalimentos_solido;
            dtalimentos_solido.AcceptChanges();
            grilla_solido.DataSource = new DataView(dtalimentos_solido, "_Vigencia ='S' ", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
            grilla_solido.DataBind();
        }

        protected void btn_agregar_cant_ag(object sender, EventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow row = (GridViewRow)btndetails.NamingContainer;
            int cod_a = Convert.ToInt32(grilla_agregado.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString());
            int cod_d = Convert.ToInt32(grilla_agregado.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString());

            dtalimentos_agregado = Agregar_cantidad(dtalimentos_agregado,cod_d, cod_a);
            Session["tbl_alimentos_agregado"] = dtalimentos_agregado;
            dtalimentos_agregado.AcceptChanges();
            grilla_agregado.DataSource = new DataView(dtalimentos_agregado, "_Vigencia ='S' ", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
            grilla_agregado.DataBind();
        }


        protected void btn_agregar_cant_hi(object sender, EventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow row = (GridViewRow)btndetails.NamingContainer;
            int cod_a = Convert.ToInt32(grilla_hidrico.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString());
            int cod_d = Convert.ToInt32(grilla_hidrico.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString());

            dtalimentos_hidricos = Agregar_cantidad(dtalimentos_hidricos, cod_d, cod_a);
            Session["tbl_alimentos_hidricos"] = dtalimentos_hidricos;
            dtalimentos_hidricos.AcceptChanges();
            grilla_hidrico.DataSource = new DataView(dtalimentos_hidricos, "_Vigencia ='S' ", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
            grilla_hidrico.DataBind();
        }


        protected void btn_agregar_cant_sop(object sender, EventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow row = (GridViewRow)btndetails.NamingContainer;
            int cod_a = Convert.ToInt32(grilla_sopa.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString());
            int cod_d = Convert.ToInt32(grilla_sopa.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString());


            dtalimentos_sopa = Agregar_cantidad(dtalimentos_sopa, cod_d, cod_a);
            Session["tbl_alimentos_sopa"] = dtalimentos_sopa;
            dtalimentos_sopa.AcceptChanges();
            grilla_sopa.DataSource = new DataView(dtalimentos_sopa, "_Vigencia ='S' ", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
            grilla_sopa.DataBind();
        }


        protected void btn_agregar_cant_en(object sender, EventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow row = (GridViewRow)btndetails.NamingContainer;
            int cod_a = Convert.ToInt32(grilla_ensalada.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString());
            int cod_d = Convert.ToInt32(grilla_ensalada.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString());

            dtalimentos_ensaladas = Agregar_cantidad(dtalimentos_ensaladas, cod_d, cod_a);
            Session["tbl_alimentos_ensaladas"] = dtalimentos_ensaladas;
            dtalimentos_ensaladas.AcceptChanges();
            grilla_ensalada.DataSource = new DataView(dtalimentos_ensaladas, "_Vigencia ='S' ", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
            grilla_ensalada.DataBind();
        }


        protected void btn_agregar_cant_pf(object sender, EventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow row = (GridViewRow)btndetails.NamingContainer;
            int cod_a = Convert.ToInt32(grilla_plato_fondo.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString());
            int cod_d = Convert.ToInt32(grilla_plato_fondo.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString());

            dtalimentos_plato_fondo = Agregar_cantidad(dtalimentos_plato_fondo, cod_d, cod_a);
            Session["tbl_alimentos_plato_fondo"] = dtalimentos_plato_fondo;
            dtalimentos_plato_fondo.AcceptChanges();
            grilla_plato_fondo.DataSource = new DataView(dtalimentos_plato_fondo, "_Vigencia ='S' ", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
            grilla_plato_fondo.DataBind();
        }


        protected void btn_agregar_cant_ac(object sender, EventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow row = (GridViewRow)btndetails.NamingContainer;
            int cod_a = Convert.ToInt32(grilla_acompañamiento.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString());
            int cod_d = Convert.ToInt32(grilla_acompañamiento.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString());

            dtalimentos_acompañamiento = Agregar_cantidad(dtalimentos_acompañamiento, cod_d, cod_a);
            Session["tbl_alimentos_acompañamiento"] = dtalimentos_acompañamiento;
            dtalimentos_acompañamiento.AcceptChanges();
            grilla_acompañamiento.DataSource = new DataView(dtalimentos_acompañamiento, "_Vigencia ='S' ", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
            grilla_acompañamiento.DataBind();
        }


        protected void btn_agregar_cant_po(object sender, EventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow row = (GridViewRow)btndetails.NamingContainer;
            int cod_a = Convert.ToInt32(grilla_postre.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString());
            int cod_d = Convert.ToInt32(grilla_postre.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString());

            dtalimentos_postre = Agregar_cantidad(dtalimentos_postre, cod_d, cod_a);
            Session["tbl_alimentos_postre"] = dtalimentos_postre;
            dtalimentos_postre.AcceptChanges();
            grilla_postre.DataSource = new DataView(dtalimentos_postre, "_Vigencia ='S' ", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
            grilla_postre.DataBind();
        }





        #endregion



        #endregion

        #region Metodos

        private DataTable Agregar_cantidad(DataTable dt,int cod_d, int cod_a)
        {

            foreach (DataRow miRow in dt.Select("_Cod_tipo_distribucion = '" + cod_d + "'  and  _Cod_tipo_alimento='" + cod_a + "' "))
                {
                    miRow["_Cantidad"] = Convert.ToInt32(miRow["_Cantidad"]) +1;
                }
    
            dt.AcceptChanges();
   
            return dt;
        }

        private void bloquear_colacion()
        {
            Cargar_datos_pedidos();
            cargar_grillas();
            cbotemperatura2.Enabled = false;
            cbovolumen2.Enabled = false;
            cboconsistencia.Enabled = false;
            cbodigestabilidad.Enabled = false;
            txtcomentario.Enabled = false;

            cbodulzor.Enabled = false;
            cbolactosa.Enabled = false;
            cbotipo_sal.Enabled = false;

            btn_guardar_1.Enabled = false;
            btn_origen.Enabled = false;
            btn_ag_liquidos_2.Enabled = false;
            btn_ag_solido_2.Enabled = false;
            btn_ag_agregado_2.Enabled = false;
            btn_ag_hidrico_2.Enabled = false;

        
        }

        private void habilitar_colacion()
        {
            Cargar_datos_pedidos();
            cargar_grillas();
            cbotemperatura2.Enabled = true;
            cbovolumen2.Enabled = true;
            cboconsistencia.Enabled = true;
            cbodigestabilidad.Enabled = true;
            txtcomentario.Enabled = true;

            cbodulzor.Enabled = true;
            cbolactosa.Enabled = true;
            cbotipo_sal.Enabled = true;

            btn_guardar_1.Enabled = true;
            btn_origen.Enabled = true;
            btn_ag_liquidos_2.Enabled = true;
            btn_ag_solido_2.Enabled = true;
            btn_ag_agregado_2.Enabled = true;
            btn_ag_hidrico_2.Enabled = true;



        }

        private void bloquear_almuerzosycena()
        {
            Cargar_datos_pedidos();
            cargar_grillas();
            cbotemperatura2.Enabled = false;
            cbovolumen2.Enabled = false;
            cboconsistencia.Enabled = false;
            cbodigestabilidad.Enabled = false;
            txtcomentario.Enabled = false;

            cbodulzor.Enabled = false;
            cbolactosa.Enabled = false;
            cbotipo_sal.Enabled = false;

            btn_guardar_1.Enabled = false;
            btn_origen.Enabled = false;
            btn_ag_sopa_2.Enabled = false;
            btn_ag_acompañamiento_2.Enabled = false;
            btn_ag_plato_fondo_2.Enabled = false;
            btn_ag_postre_2.Enabled = false;
            btn_ag_ensaladas_2.Enabled = false;
            btn_ag_hidrico_2.Enabled = false;

            grilla_acompañamiento.Enabled = false;
            grilla_ensalada.Enabled = false;
            grilla_hidrico.Enabled = false;
            grilla_plato_fondo.Enabled = false;
            grilla_postre.Enabled = false;
            grilla_sopa.Enabled = false;


        }

        private void habilitar_almuerzosycena()
        {

            Cargar_datos_pedidos();
            cargar_grillas();
            cbotemperatura2.Enabled = true;
            cbovolumen2.Enabled = true;
            cboconsistencia.Enabled = true;
            cbodigestabilidad.Enabled = true;
            txtcomentario.Enabled = true;

            cbodulzor.Enabled = true;
            cbolactosa.Enabled = true;
            cbotipo_sal.Enabled = true;

            btn_guardar_1.Enabled = true;
            btn_origen.Enabled = true;
            btn_ag_sopa_2.Enabled = true;
            btn_ag_acompañamiento_2.Enabled = true;
            btn_ag_plato_fondo_2.Enabled = true;
            btn_ag_postre_2.Enabled = true;
            btn_ag_ensaladas_2.Enabled = true;
            btn_ag_hidrico_2.Enabled = true;

            grilla_acompañamiento.Enabled = true;
            grilla_ensalada.Enabled = true;
            grilla_hidrico.Enabled = true;
            grilla_plato_fondo.Enabled = true;
            grilla_postre.Enabled = true;
            grilla_sopa.Enabled = true;

        }

        protected void bloquear_componentes()
        {
            cbotemperatura2.Enabled = false;
            cbovolumen2.Enabled = false;
            cboconsistencia.Enabled = false;
            cbodigestabilidad.Enabled = false;
            txtcomentario.Enabled = false;

            cbodulzor.Enabled = false;
            cbolactosa.Enabled = false;
            cbotipo_sal.Enabled = false;
        }

        protected void Habilitar_componentes()
        {
            cbotemperatura2.Enabled = true;
            cbovolumen2.Enabled = true;
            cboconsistencia.Enabled = true;
            cbodigestabilidad.Enabled = true;
            txtcomentario.Enabled = true;

            cbodulzor.Enabled = true;
            cbolactosa.Enabled = true;
            cbotipo_sal.Enabled = true;
        }

        //  este metodo  extrae  de una lista con todos los pedidos  del paciente  y  los  direcciona  a la grilla que corresponde  
        // llenando los DataTables de cada distribución


        protected void Cargar_extras_condicionados()
        {
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            cod_consistencia_fil = Convert.ToInt32(Session["Consistencia"].ToString());
            cod_cobro_fil = Convert.ToInt32(Session["Regimen"].ToString());
            cod_digestabilidad_fil = Convert.ToInt32(Session["Digestabilidad"].ToString());
            cod_sal_fil = Convert.ToInt32(Session["Sal"].ToString());
            cod_lactosa_fil = Convert.ToInt32(Session["Lactosa"].ToString());
            cod_dulzor_fil = Convert.ToInt32(Session["Dulzor"].ToString());
            string descripcion = txtextra.Text.ToUpper();
            List<Utilidades> lista_alimentos_condicionados = new List<Utilidades>();
            switch (Convert.ToInt32(cod_distribucion))
            {

                case 1:
                    lista_alimentos_condicionados = new UtilidadesNE().Cargar_alimentos_menu_colacion(cod_distribucion, cod_cobro_fil, cod_consistencia_fil, cod_digestabilidad_fil, cod_sal_fil, cod_lactosa_fil, cod_dulzor_fil, descripcion);

                    break;
                case 2:
                    lista_alimentos_condicionados = new UtilidadesNE().Cargar_alimentos_menu_colacion(cod_distribucion, cod_cobro_fil, cod_consistencia_fil, cod_digestabilidad_fil, cod_sal_fil, cod_lactosa_fil, cod_dulzor_fil, descripcion);


                    break;
                case 3:

                    lista_alimentos_condicionados = new UtilidadesNE().Cargar_alimentos_menu_colacion(cod_distribucion, cod_cobro_fil, cod_consistencia_fil, cod_digestabilidad_fil, cod_sal_fil, cod_lactosa_fil, cod_dulzor_fil, descripcion);


                    break;
                case 4:

                    lista_alimentos_condicionados = new UtilidadesNE().Cargar_alimentos_menu_colacion(cod_distribucion, cod_cobro_fil, cod_consistencia_fil, cod_digestabilidad_fil, cod_sal_fil, cod_lactosa_fil, cod_dulzor_fil, descripcion);



                    break;
                case 5:

                    lista_alimentos_condicionados = new UtilidadesNE().Cargar_alimentos_menu_colacion(cod_distribucion, cod_cobro_fil, cod_consistencia_fil, cod_digestabilidad_fil, cod_sal_fil, cod_lactosa_fil, cod_dulzor_fil, descripcion);

                    break;
                case 7:

                    lista_alimentos_condicionados = new UtilidadesNE().Cargar_alimentos_menu_colacion(cod_distribucion, cod_cobro_fil, cod_consistencia_fil, cod_digestabilidad_fil, cod_sal_fil, cod_lactosa_fil, cod_dulzor_fil, descripcion);


                    break;
                case 8:
                    lista_alimentos_condicionados = new UtilidadesNE().Cargar_alimentos_menu_colacion(cod_distribucion, cod_cobro_fil, cod_consistencia_fil, cod_digestabilidad_fil, cod_sal_fil, cod_lactosa_fil, cod_dulzor_fil, descripcion);

                    break;
                case 9:
                    lista_alimentos_condicionados = new UtilidadesNE().Cargar_alimentos_menu_colacion(cod_distribucion, cod_cobro_fil, cod_consistencia_fil, cod_digestabilidad_fil, cod_sal_fil, cod_lactosa_fil, cod_dulzor_fil, descripcion);


                    break;
                case 10:
                    lista_alimentos_condicionados = new UtilidadesNE().Cargar_alimentos_menu_colacion(cod_distribucion, cod_cobro_fil, cod_consistencia_fil, cod_digestabilidad_fil, cod_sal_fil, cod_lactosa_fil, cod_dulzor_fil, descripcion);


                    break;
            }

            dtextra = ConvertToDataTable(lista_alimentos_condicionados);
            Session["tbl_alimentos_extra"] = dtextra;
            grilla_extra.DataSource = new DataView(dtextra, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
            grilla_extra.DataBind();

        }

        protected void bloquear()
        {

            Cargar_datos_pedidos();
            cargar_grillas();
            cbotemperatura2.Enabled = false;
            cbovolumen2.Enabled = false;
            cboconsistencia.Enabled = false;
            cbodigestabilidad.Enabled = false;
            txtcomentario.Enabled = false;

            cbodulzor.Enabled = false;
            cbolactosa.Enabled = false;
            cbotipo_sal.Enabled = false;

            btn_guardar_1.Enabled = false;
            btn_origen.Enabled = false;
            btn_ag_liquidos_2.Enabled = false;
            btn_ag_solido_2.Enabled = false;
            btn_ag_agregado_2.Enabled = false;
            btn_ag_sopa_2.Enabled = false;
            btn_ag_acompañamiento_2.Enabled = false;
            btn_ag_plato_fondo_2.Enabled = false;
            btn_ag_postre_2.Enabled = false;
            btn_ag_ensaladas_2.Enabled = false;
            btn_ag_hidrico_2.Enabled = false;

            grilla_acompañamiento.Enabled = false;
            grilla_agregado.Enabled = false;
            grilla_ensalada.Enabled = false;
            grilla_hidrico.Enabled = false;
            grilla_liquido.Enabled = false;
            grilla_plato_fondo.Enabled = false;
            grilla_postre.Enabled = false;
            grilla_solido.Enabled = false;
            grilla_sopa.Enabled = false;
        }

        #region valida_pedido

        protected void validar_liquidos_pedido()
        {

            int cont = 0;
            int cont2 = 0;
            foreach (DataRow miRow1 in dt_pedido_registrado.Select("_Cod_tipo_distribucion = '" + var_cod_liquido + "' and  _Cod_tipo_comida=" + cod_tipo_comida))
            {
                cont++;
                DataRow Fila1 = dtalimentos_liquido.NewRow();
                int cd = Convert.ToInt32(miRow1["_Cod_tipo_alimento"].ToString());
                Session["Comentario_comida"] = miRow1["_Comentario_tipo_comida"].ToString();

                int c = 0;
                foreach (DataRow miRow in dtalimentos_liquido.Select("_Cod_tipo_distribucion = '" + var_cod_liquido + "' and  _Cod_tipo_comida='" + cod_tipo_comida + " ' and  _Cod_tipo_alimento='" + cd + "' "))
                {
                    c++;
                }

                if (c == 0)
                {

                    Fila1["_Cod_tipo_distribucion"] = Convert.ToInt32(miRow1["_Cod_tipo_distribucion"].ToString());
                    Fila1["_Cod_tipo_comida"] = miRow1["_Cod_tipo_comida"].ToString();
                    Fila1["_Id_tipo_alimento"] = Convert.ToInt32(miRow1["_Id_tipo_alimento"].ToString());
                    Fila1["_Cod_tipo_alimento"] = miRow1["_Cod_tipo_alimento"].ToString();
                    Fila1["_Nom_tipo_alimento"] = miRow1["_Nom_tipo_alimento"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila1["_Nom_tipo_distribucion"] = miRow1["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila1["_Vigencia"] = miRow1["_Vigencia"].ToString();
                    Fila1["_Cantidad"] = miRow1["_Cantidad"].ToString();
                    Fila1["_Estado"] = miRow1["_Estado"].ToString();

                    Fila1["_Cod_tipo_consistencia"] = miRow1["_Cod_tipo_consistencia"].ToString();
                    Fila1["_Cod_tipo_digestabilidad"] = miRow1["_Cod_tipo_digestabilidad"].ToString();
                    Fila1["_Cod_lactosa"] = miRow1["_Cod_lactosa"].ToString();
                    Fila1["_Cod_dulzor"] = miRow1["_Cod_dulzor"].ToString();
                    Fila1["_Cod_tipo_volumen"] = miRow1["_Cod_tipo_volumen"].ToString();
                    Fila1["_Cod_tipo_temperatura"] = miRow1["_Cod_tipo_temperatura"].ToString();
                    Fila1["_Cod_tipo_sales"] = miRow1["_Cod_tipo_sales"].ToString();
                    Fila1["_Observacion"] = miRow1["_Observacion"].ToString();


                    dtalimentos_liquido.Rows.Add(Fila1);



                }
                Session["tbl_alimentos_liquido"] = dtalimentos_liquido;
                dtalimentos_liquido.AcceptChanges();
                grilla_liquido.DataSource = new DataView(dtalimentos_liquido, "_Vigencia ='S' ", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
                grilla_liquido.DataBind();

            }

            if (cont == 0)
            {
               
                if(cod_tipo_comida==1 || cod_tipo_comida==4)
                {
                    dtalimentos_liquido = Cargar_Colacion_Ant(dtalimentos_liquido, var_cod_liquido);
                    dtalimentos_liquido.AcceptChanges();
                    Session["tbl_alimentos_liquido"] = dtalimentos_liquido;
                    grilla_liquido.DataSource = new DataView(dtalimentos_liquido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                    grilla_liquido.DataBind();
                }

                else{
                    if (cod_tipo_comida == 2 || cod_tipo_comida == 6)
                    {
                        dtalimentos_liquido = Cargar_Colacion_mat_noct(dtalimentos_liquido, var_cod_liquido);
                        dtalimentos_liquido.AcceptChanges();
                        Session["tbl_alimentos_liquido"] = dtalimentos_liquido;
                        grilla_liquido.DataSource = new DataView(dtalimentos_liquido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_liquido.DataBind();
                    }

                    else
                    {
                        cargar_dt_liquido();
                    }
                 
                }

            }



        }

        protected void validar_solido_pedido()
        {
            int cont = 0;
            int cont2 = 0;
            dt.Clear();
            foreach (DataRow miRow1 in dt_pedido_registrado.Select("_Cod_tipo_distribucion = '" + var_cod_solido + "' and  _Cod_tipo_comida=" + cod_tipo_comida))
            {
                cont++;

                DataRow Fila1 = dtalimentos_solido.NewRow();
                int cd = Convert.ToInt32(miRow1["_Cod_tipo_alimento"].ToString());
                Session["Comentario_comida"] = miRow1["_Comentario_tipo_comida"].ToString();
                int c = 0;
                foreach (DataRow miRow in dtalimentos_solido.Select("_Cod_tipo_distribucion = '" + var_cod_solido + "' and  _Cod_tipo_comida='" + cod_tipo_comida + " ' and  _Cod_tipo_alimento='" + cd + "' "))
                {
                    c++;
                }

                if (c == 0)
                {

                    Fila1["_Cod_tipo_distribucion"] = Convert.ToInt32(miRow1["_Cod_tipo_distribucion"].ToString());
                    Fila1["_Cod_tipo_comida"] = miRow1["_Cod_tipo_comida"].ToString();
                    Fila1["_Id_tipo_alimento"] = Convert.ToInt32(miRow1["_Id_tipo_alimento"].ToString());
                    Fila1["_Cod_tipo_alimento"] = miRow1["_Cod_tipo_alimento"].ToString();
                    Fila1["_Nom_tipo_alimento"] = miRow1["_Nom_tipo_alimento"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila1["_Nom_tipo_distribucion"] = miRow1["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila1["_Vigencia"] = miRow1["_Vigencia"].ToString();
                    Fila1["_Cantidad"] = miRow1["_Cantidad"].ToString();
                    Fila1["_Estado"] = miRow1["_Estado"].ToString();

                    Fila1["_Cod_tipo_consistencia"] = miRow1["_Cod_tipo_consistencia"].ToString();
                    Fila1["_Cod_tipo_digestabilidad"] = miRow1["_Cod_tipo_digestabilidad"].ToString();
                    Fila1["_Cod_lactosa"] = miRow1["_Cod_lactosa"].ToString();
                    Fila1["_Cod_dulzor"] = miRow1["_Cod_dulzor"].ToString();
                    Fila1["_Cod_tipo_volumen"] = miRow1["_Cod_tipo_volumen"].ToString();
                    Fila1["_Cod_tipo_temperatura"] = miRow1["_Cod_tipo_temperatura"].ToString();
                    Fila1["_Cod_tipo_sales"] = miRow1["_Cod_tipo_sales"].ToString();
                    Fila1["_Observacion"] = miRow1["_Observacion"].ToString();


                    dtalimentos_solido.Rows.Add(Fila1);



                }
                dtalimentos_solido.AcceptChanges();
                Session["tbl_alimentos_solido"] = dtalimentos_solido;

                grilla_solido.DataSource = new DataView(dtalimentos_solido, "_Vigencia ='S' ", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
                grilla_solido.DataBind();
            }

            if (cont == 0)
            {
                if (cod_tipo_comida == 1 || cod_tipo_comida == 4)
                {
                    dtalimentos_solido = Cargar_Colacion_Ant(dtalimentos_solido, var_cod_solido);
                    dtalimentos_solido.AcceptChanges();
                    Session["tbl_alimentos_solido"] = dtalimentos_solido;
                    grilla_solido.DataSource = new DataView(dtalimentos_solido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                    grilla_solido.DataBind();
                }

                else
                {
                    if (cod_tipo_comida == 2 || cod_tipo_comida == 6)
                    {
                        dtalimentos_solido = Cargar_Colacion_mat_noct(dtalimentos_agregado, var_cod_solido);
                        dtalimentos_solido.AcceptChanges();
                        Session["tbl_alimentos_solido"] = dtalimentos_solido;
                        grilla_solido.DataSource = new DataView(dtalimentos_solido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_solido.DataBind();
                    }

                    else
                    {
                        cargar_dt_solido();
                    }
                    
                }
              

            }

            if (dtalimentos_solido.Rows.Count < 1)
            {
                grilla_solido.EmptyDataText = "Estimado Usuario, No existen datos asociados";
            }
        }

        protected void validar_agregado_pedido()
        {
            int cont = 0;
            int cont2 = 0;
            int c = 0;
            dt.Clear();
            foreach (DataRow miRow1 in dt_pedido_registrado.Select("_Cod_tipo_distribucion = '" + var_cod_agregado + "' and  _Cod_tipo_comida=" + cod_tipo_comida))
            {
                cont++;

                DataRow Fila1 = dtalimentos_agregado.NewRow();
                int cd = Convert.ToInt32(miRow1["_Cod_tipo_alimento"].ToString());
                Session["Comentario_comida"] = miRow1["_Comentario_tipo_comida"].ToString();
                
                foreach (DataRow miRow in dtalimentos_agregado.Select("_Cod_tipo_distribucion = '" + var_cod_agregado + "' and  _Cod_tipo_comida='" + cod_tipo_comida + " ' and  _Cod_tipo_alimento='" + cd + "' "))
                {
                    c++;
                }

                if (c == 0)
                {

                    Fila1["_Cod_tipo_distribucion"] = Convert.ToInt32(miRow1["_Cod_tipo_distribucion"].ToString());
                    Fila1["_Cod_tipo_comida"] = miRow1["_Cod_tipo_comida"].ToString();
                    Fila1["_Id_tipo_alimento"] = Convert.ToInt32(miRow1["_Id_tipo_alimento"].ToString());
                    Fila1["_Cod_tipo_alimento"] = miRow1["_Cod_tipo_alimento"].ToString();
                    Fila1["_Nom_tipo_alimento"] = miRow1["_Nom_tipo_alimento"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila1["_Nom_tipo_distribucion"] = miRow1["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila1["_Vigencia"] = miRow1["_Vigencia"].ToString();
                    Fila1["_Cantidad"] = miRow1["_Cantidad"].ToString();
                    Fila1["_Estado"] = miRow1["_Estado"].ToString();

                    Fila1["_Cod_tipo_consistencia"] = miRow1["_Cod_tipo_consistencia"].ToString();
                    Fila1["_Cod_tipo_digestabilidad"] = miRow1["_Cod_tipo_digestabilidad"].ToString();
                    Fila1["_Cod_lactosa"] = miRow1["_Cod_lactosa"].ToString();
                    Fila1["_Cod_dulzor"] = miRow1["_Cod_dulzor"].ToString();
                    Fila1["_Cod_tipo_volumen"] = miRow1["_Cod_tipo_volumen"].ToString();
                    Fila1["_Cod_tipo_temperatura"] = miRow1["_Cod_tipo_temperatura"].ToString();
                    Fila1["_Cod_tipo_sales"] = miRow1["_Cod_tipo_sales"].ToString();
                    Fila1["_Observacion"] = miRow1["_Observacion"].ToString();

                    dtalimentos_agregado.Rows.Add(Fila1);

                }
                dtalimentos_agregado.AcceptChanges();
                Session["tbl_alimentos_agregado"] = dtalimentos_agregado;

                grilla_agregado.DataSource = new DataView(dtalimentos_agregado, "_Vigencia ='S' ", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
                grilla_agregado.DataBind();
            }

            if (cont == 0)
            {
                if (cod_tipo_comida == 1 || cod_tipo_comida == 4)
                {
                    dtalimentos_agregado = Cargar_Colacion_Ant(dtalimentos_agregado, var_cod_agregado);
                    dtalimentos_agregado.AcceptChanges();
                    Session["tbl_alimentos_agregado"] = dtalimentos_agregado;
                    grilla_agregado.DataSource = new DataView(dtalimentos_agregado, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                    grilla_agregado.DataBind();
                }

                else
                {

                    if (cod_tipo_comida == 2 || cod_tipo_comida == 6)
                    {
                        dtalimentos_agregado = Cargar_Colacion_mat_noct(dtalimentos_agregado, var_cod_agregado);
                        dtalimentos_agregado.AcceptChanges();
                        Session["tbl_alimentos_agregado"] = dtalimentos_agregado;
                        grilla_agregado.DataSource = new DataView(dtalimentos_agregado, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_agregado.DataBind();
                    }

                    else
                    {
                        cargar_dt_agregado();
                    }
                }

            }


            if (dtalimentos_agregado.Rows.Count < 1)
            {
                grilla_agregado.EmptyDataText = "Estimado Usuario, No existen datos asociados";
            }

        }

        protected void validar_hidricos_pedido()
        {
            int cont = 0;
            int cont2 = 0;
            dt.Clear();
            foreach (DataRow miRow1 in dt_pedido_registrado.Select("_Cod_tipo_distribucion = '" + var_cod_hidrico + "' and  _Cod_tipo_comida=" + cod_tipo_comida))
            {
                cont++;

                DataRow Fila1 = dtalimentos_hidricos.NewRow();
                int cd = Convert.ToInt32(miRow1["_Cod_tipo_alimento"].ToString());
                Session["Comentario_comida"] = miRow1["_Comentario_tipo_comida"].ToString();
                int c = 0;
                foreach (DataRow miRow in dtalimentos_hidricos.Select("_Cod_tipo_distribucion = '" + var_cod_hidrico + "' and  _Cod_tipo_comida='" + cod_tipo_comida + " ' and  _Cod_tipo_alimento='" + cd + "' "))
                {
                    c++;
                }

                if (c == 0)
                {


                    Fila1["_Cod_tipo_distribucion"] = Convert.ToInt32(miRow1["_Cod_tipo_distribucion"].ToString());
                    Fila1["_Cod_tipo_comida"] = miRow1["_Cod_tipo_comida"].ToString();
                    Fila1["_Id_tipo_alimento"] = Convert.ToInt32(miRow1["_Id_tipo_alimento"].ToString());
                    Fila1["_Cod_tipo_alimento"] = miRow1["_Cod_tipo_alimento"].ToString();
                    Fila1["_Nom_tipo_alimento"] = miRow1["_Nom_tipo_alimento"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila1["_Nom_tipo_distribucion"] = miRow1["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila1["_Vigencia"] = miRow1["_Vigencia"].ToString();
                    Fila1["_Cantidad"] = miRow1["_Cantidad"].ToString();
                    Fila1["_Estado"] = miRow1["_Estado"].ToString();

                    Fila1["_Cod_tipo_consistencia"] = miRow1["_Cod_tipo_consistencia"].ToString();
                    Fila1["_Cod_tipo_digestabilidad"] = miRow1["_Cod_tipo_digestabilidad"].ToString();
                    Fila1["_Cod_lactosa"] = miRow1["_Cod_lactosa"].ToString();
                    Fila1["_Cod_dulzor"] = miRow1["_Cod_dulzor"].ToString();
                    Fila1["_Cod_tipo_volumen"] = miRow1["_Cod_tipo_volumen"].ToString();
                    Fila1["_Cod_tipo_temperatura"] = miRow1["_Cod_tipo_temperatura"].ToString();
                    Fila1["_Cod_tipo_sales"] = miRow1["_Cod_tipo_sales"].ToString();
                    Fila1["_Observacion"] = miRow1["_Observacion"].ToString();


                    dtalimentos_hidricos.Rows.Add(Fila1);


                }


                dtalimentos_hidricos.AcceptChanges();
                Session["tbl_alimentos_hidricos"] = dtalimentos_hidricos;
                grilla_hidrico.DataSource = new DataView(dtalimentos_hidricos, "_Vigencia ='S' ", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);

                grilla_hidrico.DataBind();

            }
            if (cont == 0)
            {
                if (cod_tipo_comida == 1 || cod_tipo_comida == 4)
                {
                    dtalimentos_hidricos = Cargar_Colacion_Ant(dtalimentos_hidricos, var_cod_hidrico);
                    dtalimentos_hidricos.AcceptChanges();
                    Session["tbl_alimentos_hidricos"] = dtalimentos_hidricos;
                    grilla_hidrico.DataSource = new DataView(dtalimentos_hidricos, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                    grilla_hidrico.DataBind();
                }

                else
                {
                    cargar_dt_hidrico();
                }
                

            }


        }

        protected void validar_sopa_pedido()
        {
            dt.Clear();
            int cont = 0;
            int cont2 = 0;
            foreach (DataRow miRow1 in dt_pedido_registrado.Select("_Cod_tipo_distribucion = '" + var_cod_sopa + "' and  _Cod_tipo_comida=" + cod_tipo_comida))
            {
                cont++;
            }

            if (cont == 0)
            {

              dtalimentos_sopa=Cargar_Menu(dtalimentos_sopa, 1);
              dtalimentos_sopa.AcceptChanges();
              Session["tbl_alimentos_sopa"] = dtalimentos_sopa;
              grilla_sopa.DataSource = new DataView(dtalimentos_sopa, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
              grilla_sopa.DataBind();
            
            }
            else
            {
                foreach (DataRow miRow1 in dt_pedido_registrado.Select("_Cod_tipo_distribucion = '" + var_cod_sopa + "' and  _Cod_tipo_comida=" + cod_tipo_comida))
                {
                    cont++;


                    DataRow Fila1 = dtalimentos_sopa.NewRow();
                    int cd = Convert.ToInt32(miRow1["_Cod_tipo_alimento"].ToString());
                    Session["Comentario_comida"] = miRow1["_Comentario_tipo_comida"].ToString();
                    int c = 0;
                    foreach (DataRow miRow in dtalimentos_sopa.Select("_Cod_tipo_distribucion = '" + var_cod_sopa + "' and  _Cod_tipo_comida='" + cod_tipo_comida + " ' and  _Cod_tipo_alimento='" + cd + "' "))
                    {
                        c++;
                    }

                    if (c == 0)
                    {

                        Fila1["_Cod_tipo_distribucion"] = Convert.ToInt32(miRow1["_Cod_tipo_distribucion"].ToString());
                        Fila1["_Cod_tipo_comida"] = miRow1["_Cod_tipo_comida"].ToString();
                        Fila1["_Id_tipo_alimento"] = Convert.ToInt32(miRow1["_Id_tipo_alimento"].ToString());
                        Fila1["_Cod_tipo_alimento"] = miRow1["_Cod_tipo_alimento"].ToString();
                        Fila1["_Nom_tipo_alimento"] = miRow1["_Nom_tipo_alimento"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                        Fila1["_Nom_tipo_distribucion"] = miRow1["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                        Fila1["_Vigencia"] = miRow1["_Vigencia"].ToString();
                        Fila1["_Cantidad"] = miRow1["_Cantidad"].ToString();
                        Fila1["_Estado"] = miRow1["_Estado"].ToString();

                        Fila1["_Cod_tipo_consistencia"] = miRow1["_Cod_tipo_consistencia"].ToString();
                        Fila1["_Cod_tipo_digestabilidad"] = miRow1["_Cod_tipo_digestabilidad"].ToString();
                        Fila1["_Cod_lactosa"] = miRow1["_Cod_lactosa"].ToString();
                        Fila1["_Cod_dulzor"] = miRow1["_Cod_dulzor"].ToString();
                        Fila1["_Cod_tipo_volumen"] = miRow1["_Cod_tipo_volumen"].ToString();
                        Fila1["_Cod_tipo_temperatura"] = miRow1["_Cod_tipo_temperatura"].ToString();
                        Fila1["_Cod_tipo_sales"] = miRow1["_Cod_tipo_sales"].ToString();
                        Fila1["_Observacion"] = miRow1["_Observacion"].ToString();


                        dtalimentos_sopa.Rows.Add(Fila1);




                    }

                    dtalimentos_sopa.AcceptChanges();
                    Session["tbl_alimentos_sopa"] = dtalimentos_sopa;

                    grilla_sopa.DataSource = new DataView(dtalimentos_sopa, "_Vigencia ='S' ", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
                    grilla_sopa.DataBind();

                }
            }
            if (dtalimentos_sopa.Rows.Count < 1)
            {
                dtalimentos_sopa.Clear();
                grilla_sopa.DataSource = new DataView(dtalimentos_sopa, "_Vigencia ='S' ", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
                Session["tbl_alimentos_sopa"] = dtalimentos_sopa;
                grilla_sopa.EmptyDataText = "Estimado Usuario, No existen datos asociados";
            }


        }

        protected void validar_ensalada_pedido()
        {
            int cont = 0;
            int cont2 = 0;
            dt.Clear();


            foreach (DataRow miRow1 in dt_pedido_registrado.Select("_Cod_tipo_distribucion = '" + var_cod_ensalada + "' and  _Cod_tipo_comida=" + cod_tipo_comida))
            {
                cont++;
            }

            if (cont == 0)
            {
                //Cargar_extras_condicionados();

                dtalimentos_ensaladas = Cargar_Menu(dtalimentos_ensaladas, 2);
               dtalimentos_ensaladas.AcceptChanges();
               Session["dt_alimentos_ensaladas"] = dtalimentos_ensaladas;
               grilla_ensalada.DataSource = new DataView(dtalimentos_ensaladas, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                grilla_ensalada.DataBind();
  

            }
            else
            {
                foreach (DataRow miRow1 in dt_pedido_registrado.Select("_Cod_tipo_distribucion = '" + var_cod_ensalada + "' and  _Cod_tipo_comida=" + cod_tipo_comida))
                {


                    DataRow Fila1 = dtalimentos_ensaladas.NewRow();
                    int cd = Convert.ToInt32(miRow1["_Cod_tipo_alimento"].ToString());
                    Session["Comentario_comida"] = miRow1["_Comentario_tipo_comida"].ToString();
                    int c = 0;
                    foreach (DataRow miRow in dtalimentos_ensaladas.Select("_Cod_tipo_distribucion = '" + var_cod_ensalada + "' and  _Cod_tipo_comida='" + cod_tipo_comida + " ' and  _Cod_tipo_alimento='" + cd + "' "))
                    {
                        c++;
                    }

                    if (c == 0)
                    {


                        Fila1["_Cod_tipo_distribucion"] = Convert.ToInt32(miRow1["_Cod_tipo_distribucion"].ToString());
                        Fila1["_Cod_tipo_comida"] = miRow1["_Cod_tipo_comida"].ToString();
                        Fila1["_Id_tipo_alimento"] = Convert.ToInt32(miRow1["_Id_tipo_alimento"].ToString());
                        Fila1["_Cod_tipo_alimento"] = miRow1["_Cod_tipo_alimento"].ToString();
                        Fila1["_Nom_tipo_alimento"] = miRow1["_Nom_tipo_alimento"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                        Fila1["_Nom_tipo_distribucion"] = miRow1["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                        Fila1["_Vigencia"] = miRow1["_Vigencia"].ToString();
                        Fila1["_Cantidad"] = miRow1["_Cantidad"].ToString();
                        Fila1["_Estado"] = miRow1["_Estado"].ToString();

                        Fila1["_Cod_tipo_consistencia"] = miRow1["_Cod_tipo_consistencia"].ToString();
                        Fila1["_Cod_tipo_digestabilidad"] = miRow1["_Cod_tipo_digestabilidad"].ToString();
                        Fila1["_Cod_lactosa"] = miRow1["_Cod_lactosa"].ToString();
                        Fila1["_Cod_dulzor"] = miRow1["_Cod_dulzor"].ToString();
                        Fila1["_Cod_tipo_volumen"] = miRow1["_Cod_tipo_volumen"].ToString();
                        Fila1["_Cod_tipo_temperatura"] = miRow1["_Cod_tipo_temperatura"].ToString();
                        Fila1["_Cod_tipo_sales"] = miRow1["_Cod_tipo_sales"].ToString();
                        Fila1["_Observacion"] = miRow1["_Observacion"].ToString();


                        string val = miRow1["_Mixto"].ToString();
                        if (val == "S")
                        {
                            ck_mixto.Checked = true;
                        }
                        else
                        {
                            ck_mixto.Checked = false;

                        }

                        dtalimentos_ensaladas.Rows.Add(Fila1);



                    }
                    dtalimentos_ensaladas.AcceptChanges();
                    Session["tbl_alimentos_ensaladas"] = dtalimentos_ensaladas;

                    grilla_ensalada.DataSource = new DataView(dtalimentos_ensaladas, "_Vigencia ='S' ", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
                    grilla_ensalada.DataBind();
                }
            }
            if (dtalimentos_ensaladas.Rows.Count < 1)
            {
                grilla_ensalada.EmptyDataText = "Estimado Usuario, No existen datos asociados";
            }


        }

        protected void validar_plato_fondo_pedido()
        {
            int cont = 0;
            int cont2 = 0;
            dt.Clear();

            foreach (DataRow miRow1 in dt_pedido_registrado.Select("_Cod_tipo_distribucion = '" + var_cod_plato_fondo + "' and  _Cod_tipo_comida=" + cod_tipo_comida))
            {
                cont++;
            }

            if (cont == 0)
            {

                dtalimentos_plato_fondo = Cargar_Menu(dtalimentos_plato_fondo, 3);
                dtalimentos_plato_fondo.AcceptChanges();
                Session["dt_alimentos_plato_fondo"] = dtalimentos_plato_fondo;
                grilla_plato_fondo.DataSource = new DataView(dtalimentos_plato_fondo, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                grilla_plato_fondo.DataBind();

            }
            else
            {
                foreach (DataRow miRow1 in dt_pedido_registrado.Select("_Cod_tipo_distribucion = '" + var_cod_plato_fondo + "' and  _Cod_tipo_comida=" + cod_tipo_comida))
                {


                    DataRow Fila1 = dtalimentos_plato_fondo.NewRow();
                    int cd = Convert.ToInt32(miRow1["_Cod_tipo_alimento"].ToString());
                    Session["Comentario_comida"] = miRow1["_Comentario_tipo_comida"].ToString();
                    int c = 0;
                    foreach (DataRow miRow in dtalimentos_plato_fondo.Select("_Cod_tipo_distribucion = '" + var_cod_plato_fondo + "' and  _Cod_tipo_comida='" + cod_tipo_comida + " ' and  _Cod_tipo_alimento='" + cd + "' "))
                    {
                        c++;
                    }

                    if (c == 0)
                    {

                        Fila1["_Cod_tipo_distribucion"] = Convert.ToInt32(miRow1["_Cod_tipo_distribucion"].ToString());
                        Fila1["_Cod_tipo_comida"] = miRow1["_Cod_tipo_comida"].ToString();
                        Fila1["_Id_tipo_alimento"] = Convert.ToInt32(miRow1["_Id_tipo_alimento"].ToString());
                        Fila1["_Cod_tipo_alimento"] = miRow1["_Cod_tipo_alimento"].ToString();
                        Fila1["_Nom_tipo_alimento"] = miRow1["_Nom_tipo_alimento"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                        Fila1["_Nom_tipo_distribucion"] = miRow1["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                        Fila1["_Vigencia"] = miRow1["_Vigencia"].ToString();
                        Fila1["_Cantidad"] = miRow1["_Cantidad"].ToString();
                        Fila1["_Estado"] = miRow1["_Estado"].ToString();

                        Fila1["_Cod_tipo_consistencia"] = miRow1["_Cod_tipo_consistencia"].ToString();
                        Fila1["_Cod_tipo_digestabilidad"] = miRow1["_Cod_tipo_digestabilidad"].ToString();
                        Fila1["_Cod_lactosa"] = miRow1["_Cod_lactosa"].ToString();
                        Fila1["_Cod_dulzor"] = miRow1["_Cod_dulzor"].ToString();
                        Fila1["_Cod_tipo_volumen"] = miRow1["_Cod_tipo_volumen"].ToString();
                        Fila1["_Cod_tipo_temperatura"] = miRow1["_Cod_tipo_temperatura"].ToString();
                        Fila1["_Cod_tipo_sales"] = miRow1["_Cod_tipo_sales"].ToString();
                        Fila1["_Observacion"] = miRow1["_Observacion"].ToString();


                        dtalimentos_plato_fondo.Rows.Add(Fila1);



                    }

                    dtalimentos_plato_fondo.AcceptChanges();
                    Session["tbl_alimentos_plato_fondo"] = dtalimentos_plato_fondo;

                    grilla_plato_fondo.DataSource = new DataView(dtalimentos_plato_fondo, "_Vigencia ='S' ", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
                    grilla_plato_fondo.DataBind();
                }

            }
            if (dtalimentos_plato_fondo.Rows.Count < 1)
            {
                grilla_plato_fondo.EmptyDataText = "Estimado Usuario, No existen datos asociados";
            }

        }

        protected void validar_acompañamiento_pedido()
        {
            int cont = 0;
            int cont2 = 0;
            dt.Clear();

            foreach (DataRow miRow1 in dt_pedido_registrado.Select("_Cod_tipo_distribucion = '" + var_cod_acompañamiento + "' and  _Cod_tipo_comida=" + cod_tipo_comida))
            {
                cont++;
            }

            if (cont == 0)
            {
               
                
                dtalimentos_acompañamiento = Cargar_Menu(dtalimentos_acompañamiento, 4);
                dtalimentos_acompañamiento.AcceptChanges();
                Session["dt_alimentos_acompañamiento"] = dtalimentos_acompañamiento;
                grilla_acompañamiento.DataSource = new DataView(dtalimentos_acompañamiento, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                grilla_acompañamiento.DataBind();

            }
            else
            {
                foreach (DataRow miRow1 in dt_pedido_registrado.Select("_Cod_tipo_distribucion = '" + var_cod_acompañamiento + "' and  _Cod_tipo_comida=" + cod_tipo_comida))
                {


                    DataRow Fila1 = dtalimentos_acompañamiento.NewRow();
                    int cd = Convert.ToInt32(miRow1["_Cod_tipo_alimento"].ToString());
                    Session["Comentario_comida"] = miRow1["_Comentario_tipo_comida"].ToString();
                    int c = 0;
                    foreach (DataRow miRow in dtalimentos_acompañamiento.Select("_Cod_tipo_distribucion = '" + var_cod_acompañamiento + "' and  _Cod_tipo_comida='" + cod_tipo_comida + " ' and  _Cod_tipo_alimento='" + cd + "' "))
                    {
                        c++;
                    }

                    if (c == 0)
                    {

                        Fila1["_Cod_tipo_distribucion"] = Convert.ToInt32(miRow1["_Cod_tipo_distribucion"].ToString());
                        Fila1["_Cod_tipo_comida"] = miRow1["_Cod_tipo_comida"].ToString();
                        Fila1["_Id_tipo_alimento"] = Convert.ToInt32(miRow1["_Id_tipo_alimento"].ToString());
                        Fila1["_Cod_tipo_alimento"] = miRow1["_Cod_tipo_alimento"].ToString();
                        Fila1["_Nom_tipo_alimento"] = miRow1["_Nom_tipo_alimento"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                        Fila1["_Nom_tipo_distribucion"] = miRow1["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                        Fila1["_Vigencia"] = miRow1["_Vigencia"].ToString();
                        Fila1["_Cantidad"] = miRow1["_Cantidad"].ToString();
                        Fila1["_Estado"] = miRow1["_Estado"].ToString();

                        Fila1["_Cod_tipo_consistencia"] = miRow1["_Cod_tipo_consistencia"].ToString();
                        Fila1["_Cod_tipo_digestabilidad"] = miRow1["_Cod_tipo_digestabilidad"].ToString();
                        Fila1["_Cod_lactosa"] = miRow1["_Cod_lactosa"].ToString();
                        Fila1["_Cod_dulzor"] = miRow1["_Cod_dulzor"].ToString();
                        Fila1["_Cod_tipo_volumen"] = miRow1["_Cod_tipo_volumen"].ToString();
                        Fila1["_Cod_tipo_temperatura"] = miRow1["_Cod_tipo_temperatura"].ToString();
                        Fila1["_Cod_tipo_sales"] = miRow1["_Cod_tipo_sales"].ToString();
                        Fila1["_Observacion"] = miRow1["_Observacion"].ToString();


                        dtalimentos_acompañamiento.Rows.Add(Fila1);



                    }

                    dtalimentos_acompañamiento.AcceptChanges();
                    Session["tbl_alimentos_acompañamiento"] = dtalimentos_acompañamiento;

                    grilla_acompañamiento.DataSource = new DataView(dtalimentos_acompañamiento, "_Vigencia ='S' ", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
                    grilla_acompañamiento.DataBind();
                }

            }
            if (dtalimentos_acompañamiento.Rows.Count < 1)
            {
                grilla_acompañamiento.EmptyDataText = "Estimado Usuario, No existen datos asociados";
            }
        }

        protected void validar_postre_pedido()
        {
            dt.Clear();
            int cont2 = 0;
            int cont = 0;

            foreach (DataRow miRow1 in dt_pedido_registrado.Select("_Cod_tipo_distribucion = '" + var_cod_postre + "' and  _Cod_tipo_comida=" + cod_tipo_comida))
            {
                cont++;
            }

            if (cont == 0)
            {
              

                dtalimentos_postre = Cargar_Menu(dtalimentos_postre, 5);
                dtalimentos_postre.AcceptChanges();
                Session["dt_alimentos_postre"] = dtalimentos_postre;
                grilla_postre.DataSource = new DataView(dtalimentos_postre, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                grilla_postre.DataBind();

            }
            else
            {
                foreach (DataRow miRow1 in dt_pedido_registrado.Select("_Cod_tipo_distribucion = '" + var_cod_postre + "' and  _Cod_tipo_comida=" + cod_tipo_comida))
                {

                    DataRow Fila1 = dtalimentos_postre.NewRow();
                    int cd = Convert.ToInt32(miRow1["_Cod_tipo_alimento"].ToString());
                    Session["Comentario_comida"] = miRow1["_Comentario_tipo_comida"].ToString();
                    int c = 0;
                    foreach (DataRow miRow in dtalimentos_postre.Select("_Cod_tipo_distribucion = '" + var_cod_postre + "' and  _Cod_tipo_comida='" + cod_tipo_comida + " ' and  _Cod_tipo_alimento='" + cd + "' "))
                    {
                        c++;
                    }

                    if (c == 0)
                    {

                        Fila1["_Cod_tipo_distribucion"] = Convert.ToInt32(miRow1["_Cod_tipo_distribucion"].ToString());
                        Fila1["_Cod_tipo_comida"] = miRow1["_Cod_tipo_comida"].ToString();
                        Fila1["_Id_tipo_alimento"] = Convert.ToInt32(miRow1["_Id_tipo_alimento"].ToString());
                        Fila1["_Cod_tipo_alimento"] = miRow1["_Cod_tipo_alimento"].ToString();
                        Fila1["_Nom_tipo_alimento"] = miRow1["_Nom_tipo_alimento"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                        Fila1["_Nom_tipo_distribucion"] = miRow1["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                        Fila1["_Vigencia"] = miRow1["_Vigencia"].ToString();
                        Fila1["_Cantidad"] = miRow1["_Cantidad"].ToString();
                        Fila1["_Estado"] = miRow1["_Estado"].ToString();

                        Fila1["_Cod_tipo_consistencia"] = miRow1["_Cod_tipo_consistencia"].ToString();
                        Fila1["_Cod_tipo_digestabilidad"] = miRow1["_Cod_tipo_digestabilidad"].ToString();
                        Fila1["_Cod_lactosa"] = miRow1["_Cod_lactosa"].ToString();
                        Fila1["_Cod_dulzor"] = miRow1["_Cod_dulzor"].ToString();
                        Fila1["_Cod_tipo_volumen"] = miRow1["_Cod_tipo_volumen"].ToString();
                        Fila1["_Cod_tipo_temperatura"] = miRow1["_Cod_tipo_temperatura"].ToString();
                        Fila1["_Cod_tipo_sales"] = miRow1["_Cod_tipo_sales"].ToString();
                        Fila1["_Observacion"] = miRow1["_Observacion"].ToString();


                        dtalimentos_postre.Rows.Add(Fila1);



                    }

                    dtalimentos_postre.AcceptChanges();
                    Session["tbl_alimentos_postre"] = dtalimentos_postre;

                    grilla_postre.DataSource = new DataView(dtalimentos_postre, "_Vigencia ='S' ", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
                    grilla_postre.DataBind();
                }

            }
            if (dtalimentos_postre.Rows.Count < 1)
            {
                grilla_postre.EmptyDataText = "Estimado Usuario, No existen datos asociados";
            }
        }

        #endregion

        #region Cargar datos en blanco

        protected void Cargar_datos_pedidos()
        {
            string fec_pedido = Session["Fecha_pedido"].ToString();
            List<Utilidades> lista_pedido_registrados = new UtilidadesNE().Cargar_pedidos_registrados(Convert.ToInt32(cod_pedido));
            dt_pedido_registrado = ConvertToDataTable(lista_pedido_registrados);

            foreach (DataRow rx in dt_pedido_registrado.Select("_Cod_tipo_comida = '" + cod_tipo_comida + "'"))
            {
                Session["Comentario_comida"] = rx["_Comentario_tipo_comida"].ToString();
            }


            dtalimentos_sopa = ConvertToDataTable(lista_pedido_registrados);
            dtalimentos_sopa.Clear();
            Session["tbl_alimentos_sopa"] = dtalimentos_sopa;


            dtalimentos_ensaladas = ConvertToDataTable(lista_pedido_registrados);
            dtalimentos_ensaladas.Clear();
            Session["tbl_alimentos_ensaladas"] = dtalimentos_ensaladas;


            dtalimentos_plato_fondo = ConvertToDataTable(lista_pedido_registrados);
            dtalimentos_plato_fondo.Clear();
            Session["tbl_alimentos_plato_fondo"] = dtalimentos_plato_fondo;


            dtalimentos_acompañamiento = ConvertToDataTable(lista_pedido_registrados);
            dtalimentos_acompañamiento.Clear();
            Session["tbl_alimentos_acompañamiento"] = dtalimentos_acompañamiento;


            dtalimentos_postre = ConvertToDataTable(lista_pedido_registrados);
            dtalimentos_postre.Clear();
            Session["tbl_alimentos_postre"] = dtalimentos_postre;


            dtalimentos_liquido = ConvertToDataTable(lista_pedido_registrados);
            dtalimentos_liquido.Clear();
            Session["tbl_alimentos_liquido"] = dtalimentos_liquido;


            dtalimentos_solido = ConvertToDataTable(lista_pedido_registrados);
            dtalimentos_solido.Clear();
            Session["tbl_alimentos_solido"] = dtalimentos_solido;


            dtalimentos_agregado = ConvertToDataTable(lista_pedido_registrados);
            dtalimentos_agregado.Clear();
            Session["tbl_alimentos_agregado"] = dtalimentos_agregado;


            dtalimentos_hidricos = ConvertToDataTable(lista_pedido_registrados);
            dtalimentos_hidricos.Clear();
            Session["tbl_alimentos_hidricos"] = dtalimentos_hidricos;


            dtsuper_especial = ConvertToDataTable(lista_pedido_registrados);
            dtsuper_especial.Clear();
            Session["tbl_super_especial"] = dtsuper_especial;


            dtespecial = ConvertToDataTable(lista_pedido_registrados);
            dtespecial.Clear();
            Session["tbl_alimentos_especiales"] = dtespecial;


            dtextra = ConvertToDataTable(lista_pedido_registrados);
            dtextra.Clear();
            Session["tbl_extra"] = dtextra;


            dtextras_2 = ConvertToDataTable(lista_pedido_registrados);
            dtextras_2.Clear();
            Session["tbl_extras_2"] = dtextras_2;


            dtespecial_2 = ConvertToDataTable(lista_pedido_registrados);
            dtespecial_2.Clear();
            Session["tbl_dtespecial_2"] = dtespecial_2;



        }

        #endregion

        #region  Cargar Menu

        protected DataTable Cargar_Menu( DataTable dt,int cod_distribucion)
        {
          
                string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                cod_consistencia_fil = Convert.ToInt32(Session["Consistencia"].ToString());
                cod_cobro_fil = Convert.ToInt32(Session["Regimen"].ToString());
                cod_digestabilidad_fil = Convert.ToInt32(Session["Digestabilidad"].ToString());
                cod_sal_fil = Convert.ToInt32(Session["Sal"].ToString());
                cod_lactosa_fil = Convert.ToInt32(Session["Lactosa"].ToString());
                cod_dulzor_fil = Convert.ToInt32(Session["Dulzor"].ToString());
                List<Utilidades> lista_menu_condicionados = new List<Utilidades>();


                lista_menu_condicionados = new UtilidadesNE().Cargar_alimentos_menu(cod_tipo_comida, cod_distribucion, cod_cobro_fil, cod_consistencia_fil, cod_digestabilidad_fil, cod_sal_fil, cod_lactosa_fil, cod_dulzor_fil);

                dt = ConvertToDataTable(lista_menu_condicionados);
                return dt;
           
        

        }

        #endregion


        #region  Cargar Colacion Anterior

        protected DataTable Cargar_Colacion_Ant(DataTable dt, int cod_distribucion)
        {
            List<Utilidades> lista_menu_condicionados = new List<Utilidades>();


            lista_menu_condicionados = new UtilidadesNE().Cargar_Colacion_Ant(cod_tipo_comida, cod_distribucion, Convert.ToInt32(cod_pedido));

            dt = ConvertToDataTable(lista_menu_condicionados);
            return dt;

        }

        #endregion


        #region  Cargar Colacion mant_noct

        protected DataTable Cargar_Colacion_mat_noct(DataTable dt, int cod_distribucion)
        {
            List<Utilidades> lista_menu_condicionados = new List<Utilidades>();


            lista_menu_condicionados = new UtilidadesNE().Cargar_Colacion_mat_noct(cod_tipo_comida, cod_distribucion);

            dt = ConvertToDataTable(lista_menu_condicionados);
            return dt;

        }

        #endregion

        #region Cargar  Grillas

        protected void cargar_grillas()
        {
            int cont = 0;
            int cod = cod_tipo_comida;

            switch (cod)
            {
                case 1:
                    validar_liquidos_pedido();
                    validar_solido_pedido();
                    validar_agregado_pedido();
                    validar_hidricos_pedido();
                    alm_1.Visible = false;
                    alm_2.Visible = false;
                    alm_3.Visible = false;
                    alm_4.Visible = false;
                    alm_5.Visible = false;



                    break;
                case 2:

                    validar_liquidos_pedido();
                    validar_solido_pedido();
                    validar_agregado_pedido();
                    validar_hidricos_pedido();
                    alm_1.Visible = false;
                    alm_2.Visible = false;
                    alm_3.Visible = false;
                    alm_4.Visible = false;
                    alm_5.Visible = false;


                    break;
                case 3:
                    desa_liquido.Visible = false;
                    desa_solidos.Visible = false;
                    desa_agregados.Visible = false;
                    validar_sopa_pedido();
                    validar_ensalada_pedido();
                    validar_plato_fondo_pedido();
                    validar_acompañamiento_pedido();
                    validar_postre_pedido();
                    validar_hidricos_pedido();
               
                    break;
                case 4:

                    validar_liquidos_pedido();
                    validar_solido_pedido();
                    validar_agregado_pedido();
                    validar_hidricos_pedido();
                    alm_1.Visible = false;
                    alm_2.Visible = false;
                    alm_3.Visible = false;
                    alm_4.Visible = false;
                    alm_5.Visible = false;


                    break;

                case 5:
                    desa_liquido.Visible = false;
                    desa_solidos.Visible = false;
                    desa_agregados.Visible = false;
                    validar_sopa_pedido();
                    validar_ensalada_pedido();
                    validar_plato_fondo_pedido();
                    validar_acompañamiento_pedido();
                    validar_postre_pedido();
                    validar_hidricos_pedido();
             


                    break;
                case 6:

                    validar_liquidos_pedido();
                    validar_solido_pedido();
                    validar_agregado_pedido();
                    validar_hidricos_pedido();
                    alm_1.Visible = false;
                    alm_2.Visible = false;
                    alm_3.Visible = false;
                    alm_4.Visible = false;
                    alm_5.Visible = false;
               

                    break;
                case 7:

                    validar_liquidos_pedido();
                    validar_solido_pedido();
                    validar_agregado_pedido();
                    validar_hidricos_pedido();
                    alm_1.Visible = false;
                    alm_2.Visible = false;
                    alm_3.Visible = false;
                    alm_4.Visible = false;
                    alm_5.Visible = false;


                    break;
                case 8:

                    validar_hidricos_pedido();
                    alm_1.Visible = false;
                    alm_2.Visible = false;
                    alm_3.Visible = false;
                    alm_4.Visible = false;
                    alm_5.Visible = false;
                    desa_liquido.Visible = false;
                    desa_solidos.Visible = false;
                    desa_agregados.Visible = false;


                    break;



                default:
                    Console.WriteLine("Default case");
                    break;
            }

        }

        #endregion

        #region Buscar Autocomplete de alimentos

      
        #endregion




        #region Modificacion Combox

        protected void cboconsistencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_cambiar_componente();
        }

        protected void cbodigestabilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_cambiar_componente();
        }

        protected void cbotipo_sal_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_cambiar_componente();
        }

        protected void cbolactosa_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_cambiar_componente();
        }

        protected void cbodulzor_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_cambiar_componente();
        }

        protected void cbotemperatura2_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_cambiar_componente();
        }

        protected void cbovolumen2_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_cambiar_componente();
        }

        protected void txtcomentario_TextChanged(object sender, EventArgs e)
        {
            comentario_alimento = txtcomentario.Text.ToUpper();
            btn_cambiar_componente();
        }


        #endregion

        #region selecccion_alimento

        #region selecccion_liquido

        protected void grilla_liquido_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (vig == "S")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grilla_liquido, "Select$" + e.Row.RowIndex);
                    e.Row.ToolTip = " Seleccione con un Click la Fila deseada";

                }
            }
        }

        protected void grilla_liquido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vig == "S")
            {
                foreach (GridViewRow row in grilla_liquido.Rows)
                {
                    if (row.RowIndex == grilla_liquido.SelectedIndex)
                    {
                        row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                        row.ToolTip = string.Empty;
                        cod_alimento = grilla_liquido.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                        cod_alimentoaux = Convert.ToInt32(cod_alimento);
                        Session["_Cod_tipo_alimento"] = cod_alimento;
                        Session["_Nom_tipo_alimento"] = row.Cells[1].Text.Trim();
                        Session["_Nom_tipo_distribucion"] = grilla_liquido.DataKeys[row.RowIndex]["_Nom_tipo_distribucion"].ToString();
                        cod_distribucion = Convert.ToInt32(grilla_liquido.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString());
                        Session["Tipo"] = row.Cells[2].Text.Trim();
                        txtal.Text = row.Cells[1].Text.Trim().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");

                        if (Convert.ToInt32(cod_alimento) < 20170000)
                        {
                            cboconsistencia.SelectedValue = grilla_liquido.DataKeys[row.RowIndex]["_Cod_tipo_consistencia"].ToString();
                            cbodigestabilidad.SelectedValue = grilla_liquido.DataKeys[row.RowIndex]["_Cod_tipo_digestabilidad"].ToString();
                            cbolactosa.SelectedValue = grilla_liquido.DataKeys[row.RowIndex]["_Cod_lactosa"].ToString();
                            cbodulzor.SelectedValue = grilla_liquido.DataKeys[row.RowIndex]["_Cod_dulzor"].ToString();
                            cbotemperatura2.SelectedValue = grilla_liquido.DataKeys[row.RowIndex]["_Cod_tipo_temperatura"].ToString();
                            cbovolumen2.SelectedValue = grilla_liquido.DataKeys[row.RowIndex]["_Cod_tipo_volumen"].ToString();
                            cbotipo_sal.SelectedValue = grilla_liquido.DataKeys[row.RowIndex]["_Cod_tipo_sales"].ToString();
                            txtcomentario.Text = grilla_liquido.DataKeys[row.RowIndex]["_Observacion"].ToString();
                            cboconsistencia.Enabled = true;
                            cbodigestabilidad.Enabled = true;
                            cbodulzor.Enabled = true;
                            cbolactosa.Enabled = true;
                            cbotipo_sal.Enabled = true;
                            cbovolumen2.Enabled = true;
                            cbotemperatura2.Enabled = true;
                            txtcomentario.Enabled = true;
                        }
                        else
                        {
                            cboconsistencia.SelectedIndex = 0;
                            cbodigestabilidad.SelectedIndex = 0;
                            cbolactosa.SelectedIndex = 0;
                            cbodulzor.SelectedIndex = 0;
                            cbotemperatura2.SelectedIndex = 0;
                            cbovolumen2.SelectedIndex = 0;
                            cbotipo_sal.SelectedIndex = 0;
                            cboconsistencia.Enabled = false;
                            cbodigestabilidad.Enabled = false;
                            cbodulzor.Enabled = false;
                            cbolactosa.Enabled = false;
                            cbotipo_sal.Enabled = false;
                            cbovolumen2.Enabled = false;
                            cbotemperatura2.Enabled = false;
                            txtcomentario.Enabled = false;

                        }

                    }
                    else
                    {
                        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        row.ToolTip = "Fila Seleccionada";
                    }
                }
            }


        }


        #endregion

        #region selecccion_solido

        protected void grilla_solido_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (vig == "S")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grilla_solido, "Select$" + e.Row.RowIndex);
                    e.Row.ToolTip = " Seleccione con un Click la Fila deseada";
                }
            }
        }

        protected void grilla_solido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vig == "S")
            {
                foreach (GridViewRow row in grilla_solido.Rows)
                {
                    if (row.RowIndex == grilla_solido.SelectedIndex)
                    {
                        row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                        row.ToolTip = string.Empty;
                        cod_alimento = grilla_solido.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                        cod_alimentoaux = Convert.ToInt32(cod_alimento);
                        Session["_Cod_tipo_alimento"] = cod_alimento;
                        Session["_Nom_tipo_alimento"] = row.Cells[1].Text.Trim();
                        Session["_Nom_tipo_distribucion"] = grilla_solido.DataKeys[row.RowIndex]["_Nom_tipo_distribucion"].ToString();
                        cod_distribucion = Convert.ToInt32(grilla_solido.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString()); Session["Tipo"] = row.Cells[2].Text.Trim();
                        Session["Tipo"] = row.Cells[2].Text.Trim();
                        txtal.Text = row.Cells[1].Text.Trim().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");

                        if (Convert.ToInt32(cod_alimento) < 20170000)
                        {
                            cboconsistencia.SelectedValue= grilla_solido.DataKeys[row.RowIndex]["_Cod_tipo_consistencia"].ToString();
                            cbodigestabilidad.SelectedValue = grilla_solido.DataKeys[row.RowIndex]["_Cod_tipo_digestabilidad"].ToString();
                            cbolactosa.SelectedValue = grilla_solido.DataKeys[row.RowIndex]["_Cod_lactosa"].ToString();
                            cbodulzor.SelectedValue = grilla_solido.DataKeys[row.RowIndex]["_Cod_dulzor"].ToString();
                            cbotemperatura2.SelectedValue = grilla_solido.DataKeys[row.RowIndex]["_Cod_tipo_temperatura"].ToString();
                            cbovolumen2.SelectedValue =grilla_solido.DataKeys[row.RowIndex]["_Cod_tipo_volumen"].ToString();
                            cbotipo_sal.SelectedValue = grilla_solido.DataKeys[row.RowIndex]["_Cod_tipo_sales"].ToString();
                            txtcomentario.Text = grilla_solido.DataKeys[row.RowIndex]["_Observacion"].ToString();
                            cboconsistencia.Enabled = true;
                            cbodigestabilidad.Enabled = true;
                            cbodulzor.Enabled = true;
                            cbolactosa.Enabled = true;
                            cbotipo_sal.Enabled = true;
                            cbovolumen2.Enabled = true;
                            cbotemperatura2.Enabled = true;
                            txtcomentario.Enabled = true;

                            //guardar_alimento_extra();
                        }
                        else
                        {
                            cboconsistencia.SelectedIndex = 0;
                            cbodigestabilidad.SelectedIndex = 0;
                            cbolactosa.SelectedIndex = 0;
                            cbodulzor.SelectedIndex = 0;
                            cbotemperatura2.SelectedIndex = 0;
                            cbovolumen2.SelectedIndex = 0;
                            cbotipo_sal.SelectedIndex = 0;
                            cboconsistencia.Enabled = false;
                            cbodigestabilidad.Enabled = false;
                            cbodulzor.Enabled = false;
                            cbolactosa.Enabled = false;
                            cbotipo_sal.Enabled = false;
                            cbovolumen2.Enabled = false;
                            cbotemperatura2.Enabled = false;
                            txtcomentario.Enabled = false;

                        }
                    }
                    else
                    {
                        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        row.ToolTip = " Seleccione con un Click la Fila deseada";
                    }
                }
            }


        }

        #endregion

        #region selecccion_agregado

        protected void grilla_agregado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (vig == "S")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grilla_agregado, "Select$" + e.Row.RowIndex);
                    e.Row.ToolTip = " Seleccione con un Click la Fila deseada";
                }
            }
        }

        protected void grilla_agregado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vig == "S")
            {
                foreach (GridViewRow row in grilla_agregado.Rows)
                {
                    if (row.RowIndex == grilla_agregado.SelectedIndex)
                    {
                        row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                        row.ToolTip = string.Empty;
                        cod_alimento = grilla_agregado.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                        cod_alimentoaux = Convert.ToInt32(cod_alimento);
                        Session["_Cod_tipo_alimento"] = cod_alimento;
                        //  txtdistribucion1.Text = row.Cells[1].Text.Trim().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                        //   txtalimento2.Text = row.Cells[2].Text.Trim();
                        Session["_Nom_tipo_alimento"] = row.Cells[1].Text.Trim();
                        Session["_Nom_tipo_distribucion"] = grilla_agregado.DataKeys[row.RowIndex]["_Nom_tipo_distribucion"].ToString();
                        cod_distribucion = Convert.ToInt32(grilla_agregado.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString());
                        Session["Tipo"] = row.Cells[2].Text.Trim();
                        txtal.Text = row.Cells[1].Text.Trim().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");

                        if (Convert.ToInt32(cod_alimento) < 20170000)
                        {
                            cboconsistencia.SelectedValue = grilla_agregado.DataKeys[row.RowIndex]["_Cod_tipo_consistencia"].ToString();
                            cbodigestabilidad.SelectedValue = grilla_agregado.DataKeys[row.RowIndex]["_Cod_tipo_digestabilidad"].ToString();
                            cbolactosa.SelectedValue = grilla_agregado.DataKeys[row.RowIndex]["_Cod_lactosa"].ToString();
                            cbodulzor.SelectedValue = grilla_agregado.DataKeys[row.RowIndex]["_Cod_dulzor"].ToString();
                            cbotemperatura2.SelectedValue = grilla_agregado.DataKeys[row.RowIndex]["_Cod_tipo_temperatura"].ToString();
                            cbovolumen2.SelectedValue = grilla_agregado.DataKeys[row.RowIndex]["_Cod_tipo_volumen"].ToString();
                            cbotipo_sal.SelectedValue = grilla_agregado.DataKeys[row.RowIndex]["_Cod_tipo_sales"].ToString();
                            txtcomentario.Text = grilla_agregado.DataKeys[row.RowIndex]["_Observacion"].ToString();
                            cboconsistencia.Enabled = true;
                            cbodigestabilidad.Enabled = true;
                            cbodulzor.Enabled = true;
                            cbolactosa.Enabled = true;
                            cbotipo_sal.Enabled = true;
                            cbovolumen2.Enabled = true;
                            cbotemperatura2.Enabled = true;
                            txtcomentario.Enabled = true;

                            //guardar_alimento_extra();
                        }
                        else
                        {
                            cboconsistencia.SelectedIndex = 0;
                            cbodigestabilidad.SelectedIndex = 0;
                            cbolactosa.SelectedIndex = 0;
                            cbodulzor.SelectedIndex = 0;
                            cbotemperatura2.SelectedIndex = 0;
                            cbovolumen2.SelectedIndex = 0;
                            cbotipo_sal.SelectedIndex = 0;
                            cboconsistencia.Enabled = false;
                            cbodigestabilidad.Enabled = false;
                            cbodulzor.Enabled = false;
                            cbolactosa.Enabled = false;
                            cbotipo_sal.Enabled = false;
                            cbovolumen2.Enabled = false;
                            cbotemperatura2.Enabled = false;
                            txtcomentario.Enabled = false;

                        }
                    }
                    else
                    {
                        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        row.ToolTip = " Seleccione con un Click la Fila deseada";
                    }
                }
            }
            //   ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { Agregar(); });", true);



        }

        #endregion

        #region selecccion_sopa

        protected void grilla_sopa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (vig == "S")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grilla_sopa, "Select$" + e.Row.RowIndex);
                    e.Row.ToolTip = " Seleccione con un Click la Fila deseada";
                }
            }
        }

        protected void grilla_sopa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vig == "S")
            {
                foreach (GridViewRow row in grilla_sopa.Rows)
                {
                    if (row.RowIndex == grilla_sopa.SelectedIndex)
                    {
                        row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                        row.ToolTip = string.Empty;
                        cod_alimento = grilla_sopa.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                        cod_alimentoaux = Convert.ToInt32(cod_alimento);
                        Session["_Cod_tipo_alimento"] = cod_alimento;
                        //  txtdistribucion1.Text = row.Cells[1].Text.Trim().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                        //   txtalimento2.Text = row.Cells[2].Text.Trim();
                        Session["_Nom_tipo_alimento"] = row.Cells[1].Text.Trim();
                        Session["_Nom_tipo_distribucion"] = grilla_sopa.DataKeys[row.RowIndex]["_Nom_tipo_distribucion"].ToString();
                        cod_distribucion = Convert.ToInt32(grilla_sopa.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString());
                        Session["Tipo"] = row.Cells[2].Text.Trim();
                        txtal.Text = row.Cells[1].Text.Trim().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");

                        if (Convert.ToInt32(cod_alimento) < 20170000)
                        {
                            cboconsistencia.SelectedValue = grilla_sopa.DataKeys[row.RowIndex]["_Cod_tipo_consistencia"].ToString();
                            cbodigestabilidad.SelectedValue = grilla_sopa.DataKeys[row.RowIndex]["_Cod_tipo_digestabilidad"].ToString();
                            cbolactosa.SelectedValue = grilla_sopa.DataKeys[row.RowIndex]["_Cod_lactosa"].ToString();
                            cbodulzor.SelectedValue = grilla_sopa.DataKeys[row.RowIndex]["_Cod_dulzor"].ToString();
                            cbotemperatura2.SelectedValue = grilla_sopa.DataKeys[row.RowIndex]["_Cod_tipo_temperatura"].ToString();
                            cbovolumen2.SelectedValue = grilla_sopa.DataKeys[row.RowIndex]["_Cod_tipo_volumen"].ToString();
                            cbotipo_sal.SelectedValue = grilla_sopa.DataKeys[row.RowIndex]["_Cod_tipo_sales"].ToString();
                            txtcomentario.Text = grilla_sopa.DataKeys[row.RowIndex]["_Observacion"].ToString();
                            cboconsistencia.Enabled = true;
                            cbodigestabilidad.Enabled = true;
                            cbodulzor.Enabled = true;
                            cbolactosa.Enabled = true;
                            cbotipo_sal.Enabled = true;
                            cbovolumen2.Enabled = true;
                            cbotemperatura2.Enabled = true;
                            txtcomentario.Enabled = true;
                            //guardar_alimento_extra();
                        }
                        else
                        {
                            cboconsistencia.SelectedIndex = 0;
                            cbodigestabilidad.SelectedIndex = 0;
                            cbolactosa.SelectedIndex = 0;
                            cbodulzor.SelectedIndex = 0;
                            cbotemperatura2.SelectedIndex = 0;
                            cbovolumen2.SelectedIndex = 0;
                            cbotipo_sal.SelectedIndex = 0;
                            cboconsistencia.Enabled = false;
                            cbodigestabilidad.Enabled = false;
                            cbodulzor.Enabled = false;
                            cbolactosa.Enabled = false;
                            cbotipo_sal.Enabled = false;
                            cbovolumen2.Enabled = false;
                            cbotemperatura2.Enabled = false;
                            txtcomentario.Enabled = false;

                        }
                    }
                    else
                    {
                        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        row.ToolTip = " Seleccione con un Click la Fila deseada";
                    }
                }
                //   ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { Agregar(); });", true);
            }


        }

        #endregion

        #region selecccion_ensaladas

        protected void grilla_ensalada_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (vig == "S")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grilla_ensalada, "Select$" + e.Row.RowIndex);
                    e.Row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void grilla_ensalada_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vig == "S")
            {
                foreach (GridViewRow row in grilla_ensalada.Rows)
                {
                    if (row.RowIndex == grilla_ensalada.SelectedIndex)
                    {
                        row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                        row.ToolTip = string.Empty;
                        cod_alimento = grilla_ensalada.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                        cod_alimentoaux = Convert.ToInt32(cod_alimento);
                        Session["_Cod_tipo_alimento"] = cod_alimento;
                        Session["_Nom_tipo_alimento"] = row.Cells[1].Text.Trim();
                        Session["_Nom_tipo_distribucion"] = grilla_ensalada.DataKeys[row.RowIndex]["_Nom_tipo_distribucion"].ToString();
                        cod_distribucion = Convert.ToInt32(grilla_ensalada.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString()); Session["Tipo"] = row.Cells[2].Text.Trim();
                        Session["Tipo"] = row.Cells[2].Text.Trim();
                        txtal.Text = row.Cells[1].Text.Trim().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");

                        if (Convert.ToInt32(cod_alimento) < 20170000)
                        {
                            cboconsistencia.SelectedValue = grilla_ensalada.DataKeys[row.RowIndex]["_Cod_tipo_consistencia"].ToString();
                            cbodigestabilidad.SelectedValue =grilla_ensalada.DataKeys[row.RowIndex]["_Cod_tipo_digestabilidad"].ToString();
                            cbolactosa.SelectedValue = grilla_ensalada.DataKeys[row.RowIndex]["_Cod_lactosa"].ToString();
                            cbodulzor.SelectedValue = grilla_ensalada.DataKeys[row.RowIndex]["_Cod_dulzor"].ToString();
                            cbotemperatura2.SelectedValue = grilla_ensalada.DataKeys[row.RowIndex]["_Cod_tipo_temperatura"].ToString();
                            cbovolumen2.SelectedValue = grilla_ensalada.DataKeys[row.RowIndex]["_Cod_tipo_volumen"].ToString();
                            cbotipo_sal.SelectedValue = grilla_ensalada.DataKeys[row.RowIndex]["_Cod_tipo_sales"].ToString();
                            txtcomentario.Text = grilla_ensalada.DataKeys[row.RowIndex]["_Observacion"].ToString();
                            cboconsistencia.Enabled = true;
                            cbodigestabilidad.Enabled = true;
                            cbodulzor.Enabled = true;
                            cbolactosa.Enabled = true;
                            cbotipo_sal.Enabled = true;
                            cbovolumen2.Enabled = true;
                            cbotemperatura2.Enabled = true;
                            txtcomentario.Enabled = true;
                            //guardar_alimento_extra();
                        }
                        else
                        {
                            cboconsistencia.SelectedIndex = 0;
                            cbodigestabilidad.SelectedIndex = 0;
                            cbolactosa.SelectedIndex = 0;
                            cbodulzor.SelectedIndex = 0;
                            cbotemperatura2.SelectedIndex = 0;
                            cbovolumen2.SelectedIndex = 0;
                            cbotipo_sal.SelectedIndex = 0;
                            cboconsistencia.Enabled = false;
                            cbodigestabilidad.Enabled = false;
                            cbodulzor.Enabled = false;
                            cbolactosa.Enabled = false;
                            cbotipo_sal.Enabled = false;
                            cbovolumen2.Enabled = false;
                            cbotemperatura2.Enabled = false;
                            txtcomentario.Enabled = false;

                        }
                    }
                    else
                    {
                        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        row.ToolTip = " Seleccione con un Click la Fila deseada";
                    }
                }
            }


        }

        #endregion

        #region selecccion_plato_fondo

        protected void grilla_plato_fondo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (vig == "S")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grilla_plato_fondo, "Select$" + e.Row.RowIndex);
                    e.Row.ToolTip = " Seleccione con un Click la Fila deseada";
                }
            }
        }

        protected void grilla_plato_fondo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vig == "S")
            {
                foreach (GridViewRow row in grilla_plato_fondo.Rows)
                {
                    if (row.RowIndex == grilla_plato_fondo.SelectedIndex)
                    {
                        row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                        row.ToolTip = string.Empty;
                        cod_alimento = grilla_plato_fondo.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                        cod_alimentoaux = Convert.ToInt32(cod_alimento);
                        Session["_Cod_tipo_alimento"] = cod_alimento;
                        Session["_Nom_tipo_alimento"] = row.Cells[1].Text.Trim();
                        Session["_Nom_tipo_distribucion"] = grilla_plato_fondo.DataKeys[row.RowIndex]["_Nom_tipo_distribucion"].ToString();
                        cod_distribucion = Convert.ToInt32(grilla_plato_fondo.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString()); Session["Tipo"] = row.Cells[2].Text.Trim();
                        Session["Tipo"] = row.Cells[2].Text.Trim();
                        txtal.Text = row.Cells[1].Text.Trim().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");

                        if (Convert.ToInt32(cod_alimento) < 20170000)
                        {
                            cboconsistencia.SelectedValue = grilla_plato_fondo.DataKeys[row.RowIndex]["_Cod_tipo_consistencia"].ToString();
                            cbodigestabilidad.SelectedValue = grilla_plato_fondo.DataKeys[row.RowIndex]["_Cod_tipo_digestabilidad"].ToString();
                            cbolactosa.SelectedValue = grilla_plato_fondo.DataKeys[row.RowIndex]["_Cod_lactosa"].ToString();
                            cbodulzor.SelectedValue = grilla_plato_fondo.DataKeys[row.RowIndex]["_Cod_dulzor"].ToString();
                            cbotemperatura2.SelectedValue = grilla_plato_fondo.DataKeys[row.RowIndex]["_Cod_tipo_temperatura"].ToString();
                            cbovolumen2.SelectedValue = grilla_plato_fondo.DataKeys[row.RowIndex]["_Cod_tipo_volumen"].ToString();
                            cbotipo_sal.SelectedValue = grilla_plato_fondo.DataKeys[row.RowIndex]["_Cod_tipo_sales"].ToString();
                            txtcomentario.Text = grilla_plato_fondo.DataKeys[row.RowIndex]["_Observacion"].ToString();
                            cboconsistencia.Enabled = true;
                            cbodigestabilidad.Enabled = true;
                            cbodulzor.Enabled = true;
                            cbolactosa.Enabled = true;
                            cbotipo_sal.Enabled = true;
                            cbovolumen2.Enabled = true;
                            cbotemperatura2.Enabled = true;
                            txtcomentario.Enabled = true;
                            //guardar_alimento_extra();
                        }
                        else
                        {
                            cboconsistencia.SelectedIndex = 0;
                            cbodigestabilidad.SelectedIndex = 0;
                            cbolactosa.SelectedIndex = 0;
                            cbodulzor.SelectedIndex = 0;
                            cbotemperatura2.SelectedIndex = 0;
                            cbovolumen2.SelectedIndex = 0;
                            cbotipo_sal.SelectedIndex = 0;
                            cboconsistencia.Enabled = false;
                            cbodigestabilidad.Enabled = false;
                            cbodulzor.Enabled = false;
                            cbolactosa.Enabled = false;
                            cbotipo_sal.Enabled = false;
                            cbovolumen2.Enabled = false;
                            cbotemperatura2.Enabled = false;
                            txtcomentario.Enabled = false;

                        }
                    }
                    else
                    {
                        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        row.ToolTip = " Seleccione con un Click la Fila deseada";
                    }
                }
                //   ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { Agregar(); });", true);

            }

        }


        #endregion

        #region selecccion_acompañamiento

        protected void grilla_acompañamiento_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (vig == "S")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grilla_acompañamiento, "Select$" + e.Row.RowIndex);
                    e.Row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void grilla_acompañamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vig == "S")
            {
                foreach (GridViewRow row in grilla_acompañamiento.Rows)
                {
                    if (row.RowIndex == grilla_acompañamiento.SelectedIndex)
                    {
                        row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                        row.ToolTip = string.Empty;
                        cod_alimento = grilla_acompañamiento.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                        cod_alimentoaux = Convert.ToInt32(cod_alimento);
                        Session["_Cod_tipo_alimento"] = cod_alimento;
                        Session["_Nom_tipo_alimento"] = row.Cells[1].Text.Trim();
                        Session["_Nom_tipo_distribucion"] = grilla_acompañamiento.DataKeys[row.RowIndex]["_Nom_tipo_distribucion"].ToString();
                        cod_distribucion = Convert.ToInt32(grilla_acompañamiento.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString()); Session["Tipo"] = row.Cells[2].Text.Trim();
                        Session["Tipo"] = row.Cells[2].Text.Trim();
                        txtal.Text = row.Cells[1].Text.Trim().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");

                        if (Convert.ToInt32(cod_alimento) < 20170000)
                        {
                            cboconsistencia.SelectedValue = grilla_acompañamiento.DataKeys[row.RowIndex]["_Cod_tipo_consistencia"].ToString();
                            cbodigestabilidad.SelectedValue = grilla_acompañamiento.DataKeys[row.RowIndex]["_Cod_tipo_digestabilidad"].ToString();
                            cbolactosa.SelectedValue = grilla_acompañamiento.DataKeys[row.RowIndex]["_Cod_lactosa"].ToString();
                            cbodulzor.SelectedValue = grilla_acompañamiento.DataKeys[row.RowIndex]["_Cod_dulzor"].ToString();
                            cbotemperatura2.SelectedValue = grilla_acompañamiento.DataKeys[row.RowIndex]["_Cod_tipo_temperatura"].ToString();
                            cbovolumen2.SelectedValue = grilla_acompañamiento.DataKeys[row.RowIndex]["_Cod_tipo_volumen"].ToString();
                            cbotipo_sal.SelectedValue = grilla_acompañamiento.DataKeys[row.RowIndex]["_Cod_tipo_sales"].ToString();
                            txtcomentario.Text = grilla_acompañamiento.DataKeys[row.RowIndex]["_Observacion"].ToString();
                            cboconsistencia.Enabled = true;
                            cbodigestabilidad.Enabled = true;
                            cbodulzor.Enabled = true;
                            cbolactosa.Enabled = true;
                            cbotipo_sal.Enabled = true;
                            cbovolumen2.Enabled = true;
                            cbotemperatura2.Enabled = true;
                            txtcomentario.Enabled = true;
                        }
                        else
                        {
                            cboconsistencia.SelectedIndex = 0;
                            cbodigestabilidad.SelectedIndex = 0;
                            cbolactosa.SelectedIndex = 0;
                            cbodulzor.SelectedIndex = 0;
                            cbotemperatura2.SelectedIndex = 0;
                            cbovolumen2.SelectedIndex = 0;
                            cbotipo_sal.SelectedIndex = 0;
                            cboconsistencia.Enabled = false;
                            cbodigestabilidad.Enabled = false;
                            cbodulzor.Enabled = false;
                            cbolactosa.Enabled = false;
                            cbotipo_sal.Enabled = false;
                            cbovolumen2.Enabled = false;
                            cbotemperatura2.Enabled = false;
                            txtcomentario.Enabled = false;

                        }
                    }
                    else
                    {
                        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        row.ToolTip = " Seleccione con un Click la Fila deseada";
                    }
                }
            }



        }


        #endregion

        #region selecccion_postre

        protected void grilla_postre_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (vig == "S")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grilla_postre, "Select$" + e.Row.RowIndex);
                    e.Row.ToolTip = " Seleccione con un Click la Fila deseada";
                }
            }
        }

        protected void grilla_postre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vig == "S")
            {
                foreach (GridViewRow row in grilla_postre.Rows)
                {
                    if (row.RowIndex == grilla_postre.SelectedIndex)
                    {
                        row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                        row.ToolTip = string.Empty;
                        cod_alimento = grilla_postre.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                        cod_alimentoaux = Convert.ToInt32(cod_alimento);
                        Session["_Cod_tipo_alimento"] = cod_alimento;
                        Session["_Nom_tipo_alimento"] = row.Cells[1].Text.Trim();
                        Session["_Nom_tipo_distribucion"] = grilla_postre.DataKeys[row.RowIndex]["_Nom_tipo_distribucion"].ToString();
                        cod_distribucion = Convert.ToInt32(grilla_postre.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString()); Session["Tipo"] = row.Cells[2].Text.Trim();
                        Session["Tipo"] = row.Cells[2].Text.Trim();
                        txtal.Text = row.Cells[1].Text.Trim().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");

                        if (Convert.ToInt32(cod_alimento) < 20170000)
                        {
                            cboconsistencia.SelectedValue =grilla_postre.DataKeys[row.RowIndex]["_Cod_tipo_consistencia"].ToString();
                            cbodigestabilidad.SelectedValue = grilla_postre.DataKeys[row.RowIndex]["_Cod_tipo_digestabilidad"].ToString();
                            cbolactosa.SelectedValue = grilla_postre.DataKeys[row.RowIndex]["_Cod_lactosa"].ToString();
                            cbodulzor.SelectedValue = grilla_postre.DataKeys[row.RowIndex]["_Cod_dulzor"].ToString();
                            cbotemperatura2.SelectedValue = grilla_postre.DataKeys[row.RowIndex]["_Cod_tipo_temperatura"].ToString();
                            cbovolumen2.SelectedValue = grilla_postre.DataKeys[row.RowIndex]["_Cod_tipo_volumen"].ToString();
                            cbotipo_sal.SelectedValue = grilla_postre.DataKeys[row.RowIndex]["_Cod_tipo_sales"].ToString();
                            txtcomentario.Text = grilla_postre.DataKeys[row.RowIndex]["_Observacion"].ToString();
                            cboconsistencia.Enabled = true;
                            cbodigestabilidad.Enabled = true;
                            cbodulzor.Enabled = true;
                            cbolactosa.Enabled = true;
                            cbotipo_sal.Enabled = true;
                            cbovolumen2.Enabled = true;
                            cbotemperatura2.Enabled = true;
                            txtcomentario.Enabled = true;
                            //guardar_alimento_extra();
                        }
                        else
                        {
                            cboconsistencia.SelectedIndex = 0;
                            cbodigestabilidad.SelectedIndex = 0;
                            cbolactosa.SelectedIndex = 0;
                            cbodulzor.SelectedIndex = 0;
                            cbotemperatura2.SelectedIndex = 0;
                            cbovolumen2.SelectedIndex = 0;
                            cbotipo_sal.SelectedIndex = 0;
                            cboconsistencia.Enabled = false;
                            cbodigestabilidad.Enabled = false;
                            cbodulzor.Enabled = false;
                            cbolactosa.Enabled = false;
                            cbotipo_sal.Enabled = false;
                            cbovolumen2.Enabled = false;
                            cbotemperatura2.Enabled = false;
                            txtcomentario.Enabled = false;

                        }
                    }
                    else
                    {
                        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        row.ToolTip = " Seleccione con un Click la Fila deseada";
                    }
                }
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { cerrar_pop(); });", true);
            }


        }


        #endregion

        #region selecccion_hidrico

        protected void grilla_hidrico_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (vig == "S")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grilla_hidrico, "Select$" + e.Row.RowIndex);
                    e.Row.ToolTip = " Seleccione con un Click la Fila deseada";
                }
            }
        }

        protected void grilla_hidrico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vig == "S")
            {
                foreach (GridViewRow row in grilla_hidrico.Rows)
                {
                    if (row.RowIndex == grilla_hidrico.SelectedIndex)
                    {
                        row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                        row.ToolTip = string.Empty;
                        cod_alimento = grilla_hidrico.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString();
                        cod_alimentoaux = Convert.ToInt32(cod_alimento);
                        Session["_Cod_tipo_alimento"] = cod_alimento;
                        Session["_Nom_tipo_alimento"] = row.Cells[1].Text.Trim();
                        Session["_Nom_tipo_distribucion"] = grilla_hidrico.DataKeys[row.RowIndex]["_Nom_tipo_distribucion"].ToString();
                        cod_distribucion = Convert.ToInt32(grilla_hidrico.DataKeys[row.RowIndex]["_Cod_tipo_distribucion"].ToString()); Session["Tipo"] = row.Cells[2].Text.Trim();
                        Session["Tipo"] = row.Cells[2].Text.Trim();
                        txtal.Text = row.Cells[1].Text.Trim().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");

                        if (Convert.ToInt32(cod_alimento) < 20170000)
                        {
                            cboconsistencia.SelectedValue =grilla_hidrico.DataKeys[row.RowIndex]["_Cod_tipo_consistencia"].ToString();
                            cbodigestabilidad.SelectedValue = grilla_hidrico.DataKeys[row.RowIndex]["_Cod_tipo_digestabilidad"].ToString();
                            cbolactosa.SelectedValue = grilla_hidrico.DataKeys[row.RowIndex]["_Cod_lactosa"].ToString();
                            cbodulzor.SelectedValue = grilla_hidrico.DataKeys[row.RowIndex]["_Cod_dulzor"].ToString();
                            cbotemperatura2.SelectedValue =grilla_hidrico.DataKeys[row.RowIndex]["_Cod_tipo_temperatura"].ToString();
                            cbovolumen2.SelectedValue =grilla_hidrico.DataKeys[row.RowIndex]["_Cod_tipo_volumen"].ToString();
                            cbotipo_sal.SelectedValue = grilla_hidrico.DataKeys[row.RowIndex]["_Cod_tipo_sales"].ToString();
                            txtcomentario.Text = grilla_hidrico.DataKeys[row.RowIndex]["_Observacion"].ToString();
                            cboconsistencia.Enabled = true;
                            cbodigestabilidad.Enabled = true;
                            cbodulzor.Enabled = true;
                            cbolactosa.Enabled = true;
                            cbotipo_sal.Enabled = true;
                            cbovolumen2.Enabled = true;
                            cbotemperatura2.Enabled = true;
                            txtcomentario.Enabled = true;
                            //guardar_alimento_extra();
                        }
                        else
                        {
                            cboconsistencia.SelectedIndex = 0;
                            cbodigestabilidad.SelectedIndex = 0;
                            cbolactosa.SelectedIndex = 0;
                            cbodulzor.SelectedIndex = 0;
                            cbotemperatura2.SelectedIndex = 0;
                            cbovolumen2.SelectedIndex = 0;
                            cbotipo_sal.SelectedIndex = 0;
                            cboconsistencia.Enabled = false;
                            cbodigestabilidad.Enabled = false;
                            cbodulzor.Enabled = false;
                            cbolactosa.Enabled = false;
                            cbotipo_sal.Enabled = false;
                            cbovolumen2.Enabled = false;
                            cbotemperatura2.Enabled = false;
                            txtcomentario.Enabled = false;

                        }
                    }
                    else
                    {
                        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        row.ToolTip = " Seleccione con un Click la Fila deseada";
                    }
                }
                //   ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { Agregar(); });", true);
            }


        }

        #endregion

        #endregion

        #region Eliminar Alimento

        protected void delete()
        {

            int cod_dis = Convert.ToInt32(Session["_Cod_tipo_distribucion"].ToString());
            int cod = Convert.ToInt32(Session["_Cod_tipo_alimento"].ToString());

            switch (cod_dis)
            {
                case 1:

                    //DataTable dtalimentos_sopa = (DataTable)Session["tbl_alimentos_sopa"];

                    foreach (DataRow rx in dtalimentos_sopa.Select("_Cod_tipo_alimento = '" + cod + "'"))
                    {
                        //rx.Delete();
                        rx["_Vigencia"] = "N";
                    }

                    dtalimentos_sopa.AcceptChanges();

                    Session["tbl_alimentos_sopa"] = dtalimentos_sopa;
                    grilla_sopa.DataSource = new DataView(dtalimentos_sopa, " _Vigencia='S'", "_Estado", DataViewRowState.CurrentRows);
                    grilla_sopa.DataBind();



                    break;
                case 2:

                  //  DataTable dtalimentos_ensalada = (DataTable)Session["tbl_alimentos_ensaladas"];

                    foreach (DataRow rx in dtalimentos_ensaladas.Select("_Cod_tipo_alimento = '" + cod + "'"))
                    {

                        rx["_Vigencia"] = "N";
                    }

                    dtalimentos_ensaladas.AcceptChanges();

                    Session["tbl_alimentos_ensaladas"] = dtalimentos_ensaladas;
                    grilla_ensalada.DataSource = new DataView(dtalimentos_ensaladas, " _Vigencia='S'", "_Estado", DataViewRowState.CurrentRows);
                    grilla_ensalada.DataBind();

                    cboconsistencia.SelectedIndex = 0;
                    cbodigestabilidad.SelectedIndex = 0;
                    cbolactosa.SelectedIndex = 0;
                    cbodulzor.SelectedIndex = 0;
                    cbotemperatura2.SelectedIndex = 0;
                    cbovolumen2.SelectedIndex = 0;
                    cbotipo_sal.SelectedIndex = 0;
                    txtal.Text = "";

                    break;
                case 3:

                 //   DataTable dtalimentos_plato_fondo = (DataTable)Session["tbl_alimentos_plato_fondo"];

                    foreach (DataRow rx in dtalimentos_plato_fondo.Select("_Cod_tipo_alimento = '" + cod + "'"))
                    {
                        //   rx.Delete();
                        rx["_Vigencia"] = "N";
                    }

                    dtalimentos_plato_fondo.AcceptChanges();

                    Session["tbl_alimentos_plato_fondo "] = dtalimentos_plato_fondo;
                    grilla_plato_fondo.DataSource = new DataView(dtalimentos_plato_fondo, " _Vigencia='S'", "_Estado", DataViewRowState.CurrentRows);
                    grilla_plato_fondo.DataBind();

                    cboconsistencia.SelectedIndex = 0;
                    cbodigestabilidad.SelectedIndex = 0;
                    cbolactosa.SelectedIndex = 0;
                    cbodulzor.SelectedIndex = 0;
                    cbotemperatura2.SelectedIndex = 0;
                    cbovolumen2.SelectedIndex = 0;
                    cbotipo_sal.SelectedIndex = 0;
                    txtal.Text = "";



                    break;
                case 4:


                  //  DataTable dtalimentos_acompañamiento = (DataTable)Session["tbl_alimentos_acompañamiento"];

                    foreach (DataRow rx in dtalimentos_acompañamiento.Select("_Cod_tipo_alimento = '" + cod + "'"))
                    {
                        // rx.Delete();
                        rx["_Vigencia"] = "N";
                    }

                    dtalimentos_acompañamiento.AcceptChanges();

                    Session["tbl_alimentos_acompañamiento"] = dtalimentos_acompañamiento;
                    grilla_acompañamiento.DataSource = new DataView(dtalimentos_acompañamiento, " _Vigencia='S'", "_Estado", DataViewRowState.CurrentRows);
                    grilla_acompañamiento.DataBind();

                    cboconsistencia.SelectedIndex = 0;
                    cbodigestabilidad.SelectedIndex = 0;
                    cbolactosa.SelectedIndex = 0;
                    cbodulzor.SelectedIndex = 0;
                    cbotemperatura2.SelectedIndex = 0;
                    cbovolumen2.SelectedIndex = 0;
                    cbotipo_sal.SelectedIndex = 0;
                    txtal.Text = "";


                    break;
                case 5:


                   // DataTable dtalimentos_postre = (DataTable)Session["tbl_alimentos_postre"];

                    foreach (DataRow rx in dtalimentos_postre.Select("_Cod_tipo_alimento = '" + cod + "'"))
                    {
                        // rx.Delete();
                        rx["_Vigencia"] = "N";
                    }

                    dtalimentos_postre.AcceptChanges();

                    Session["tbl_alimentos_postre"] = dtalimentos_postre;
                    grilla_postre.DataSource = new DataView(dtalimentos_postre, " _Vigencia='S'", "_Estado", DataViewRowState.CurrentRows);
                    grilla_postre.DataBind();

                    cboconsistencia.SelectedIndex = 0;
                    cbodigestabilidad.SelectedIndex = 0;
                    cbolactosa.SelectedIndex = 0;
                    cbodulzor.SelectedIndex = 0;
                    cbotemperatura2.SelectedIndex = 0;
                    cbovolumen2.SelectedIndex = 0;
                    cbotipo_sal.SelectedIndex = 0;
                    txtal.Text = "";


                    break;
                case 7:
                  //  DataTable dtalimentos_liquido = (DataTable)Session["tbl_alimentos_liquido"];

                    foreach (DataRow rx in dtalimentos_liquido.Select("_Cod_tipo_alimento = '" + cod + "'"))
                    {
                        //  rx.Delete();
                        rx["_Vigencia"] = "N";
                    }

                    dtalimentos_liquido.AcceptChanges();

                    Session["tbl_alimentos_liquido"] = dtalimentos_liquido;
                    grilla_liquido.DataSource = new DataView(dtalimentos_liquido, " _Vigencia='S'", "_Estado", DataViewRowState.CurrentRows);
                    grilla_liquido.DataBind();

                    cboconsistencia.SelectedIndex = 0;
                    cbodigestabilidad.SelectedIndex = 0;
                    cbolactosa.SelectedIndex = 0;
                    cbodulzor.SelectedIndex = 0;
                    cbotemperatura2.SelectedIndex = 0;
                    cbovolumen2.SelectedIndex = 0;
                    cbotipo_sal.SelectedIndex = 0;
                    txtal.Text = "";


                    break;
                case 8:
                  //  DataTable dtalimentos_solido = (DataTable)Session["tbl_alimentos_solido"];

                    foreach (DataRow rx in dtalimentos_solido.Select("_Cod_tipo_alimento = '" + cod + "'"))
                    {
                        //  rx.Delete();
                        rx["_Vigencia"] = "N";
                    }

                    dtalimentos_solido.AcceptChanges();

                    Session["tbl_alimentos_solido"] = dtalimentos_solido;
                    grilla_solido.DataSource = new DataView(dtalimentos_solido, " _Vigencia='S'", "_Estado", DataViewRowState.CurrentRows);
                    grilla_solido.DataBind();

                    cboconsistencia.SelectedIndex = 0;
                    cbodigestabilidad.SelectedIndex = 0;
                    cbolactosa.SelectedIndex = 0;
                    cbodulzor.SelectedIndex = 0;
                    cbotemperatura2.SelectedIndex = 0;
                    cbovolumen2.SelectedIndex = 0;
                    cbotipo_sal.SelectedIndex = 0;
                    txtal.Text = "";

                    break;
                case 9:
                   // DataTable dtalimentos_agregado = (DataTable)Session["tbl_alimentos_agregado"];

                    foreach (DataRow rx in dtalimentos_agregado.Select("_Cod_tipo_alimento = '" + cod + "'"))
                    {
                        //  rx.Delete();
                        rx["_Vigencia"] = "N";
                    }

                    dtalimentos_agregado.AcceptChanges();

                    Session["tbl_alimentos_agregado"] = dtalimentos_agregado;
                    grilla_agregado.DataSource = new DataView(dtalimentos_agregado, " _Vigencia='S'", "_Estado", DataViewRowState.CurrentRows);
                    grilla_agregado.DataBind();

                    cboconsistencia.SelectedIndex = 0;
                    cbodigestabilidad.SelectedIndex = 0;
                    cbolactosa.SelectedIndex = 0;
                    cbodulzor.SelectedIndex = 0;
                    cbotemperatura2.SelectedIndex = 0;
                    cbovolumen2.SelectedIndex = 0;
                    cbotipo_sal.SelectedIndex = 0;
                    txtal.Text = "";


                    break;
                case 10:

                  //  DataTable dtalimentos_hidricos = (DataTable)Session["tbl_alimentos_hidricos"];

                    foreach (DataRow rx in dtalimentos_hidricos.Select("_Cod_tipo_alimento = '" + cod + "'"))
                    {
                        //  rx.Delete();
                        rx["_Vigencia"] = "N";
                    }

                    dtalimentos_hidricos.AcceptChanges();

                    Session["tbl_alimentos_hidricos"] = dtalimentos_hidricos;
                    grilla_hidrico.DataSource = new DataView(dtalimentos_hidricos, " _Vigencia='S'", "_Estado", DataViewRowState.CurrentRows);
                    grilla_hidrico.DataBind();

                    cboconsistencia.SelectedIndex = 0;
                    cbodigestabilidad.SelectedIndex = 0;
                    cbolactosa.SelectedIndex = 0;
                    cbodulzor.SelectedIndex = 0;
                    cbotemperatura2.SelectedIndex = 0;
                    cbovolumen2.SelectedIndex = 0;
                    cbotipo_sal.SelectedIndex = 0;
                    txtal.Text = "";


                    break;


                default:
                    Console.WriteLine("Default case");
                    break;
            }

        }

        #endregion

        #region Cargar Combox

        protected void Cargar_tipo_consistencia()
        {
            try
            {

                List<Utilidades> lista_tipo_consistencia = new UtilidadesNE().Cargartipo_consistencia();
                cboconsistencia.DataSource = lista_tipo_consistencia;
                cboconsistencia.DataTextField = "_Nom_tipo_consistencia";
                cboconsistencia.DataValueField = "_Cod_tipo_consistencia";
                cboconsistencia.DataBind();
                cboconsistencia.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }

        protected void Cargar_tipo_digestabilidad()
        {
            try
            {

                List<Utilidades> lista_tipo_digestabilidad = new UtilidadesNE().Cargartipo_digestabilidad();
                cbodigestabilidad.DataSource = lista_tipo_digestabilidad;
                cbodigestabilidad.DataTextField = "_Nom_tipo_digestabilidad";
                cbodigestabilidad.DataValueField = "_Cod_tipo_digestabilidad";
                cbodigestabilidad.DataBind();
                cbodigestabilidad.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }

        protected void Cargar_tipo_sal()
        {
            try
            {

                List<Utilidades> lista_tipo_sales = new UtilidadesNE().Cargartipo_sales();
                cbotipo_sal.DataSource = lista_tipo_sales;
                cbotipo_sal.DataTextField = "_Nom_tipo_sales";
                cbotipo_sal.DataValueField = "_Cod_tipo_sales";
                cbotipo_sal.DataBind();
                cbotipo_sal.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }

        protected void Cargar_tipo_dulzor()
        {
            try
            {

                List<Utilidades> lista_tipo_dulzor = new UtilidadesNE().Cargartipo_dulzor();
                cbodulzor.DataSource = lista_tipo_dulzor;
                cbodulzor.DataTextField = "_Nom_dulzor";
                cbodulzor.DataValueField = "_Cod_dulzor";
                cbodulzor.DataBind();
                cbodulzor.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }

        protected void Cargar_tipo_lactosa()
        {
            try
            {

                List<Utilidades> lista_tipo_lactosa = new UtilidadesNE().Cargartipo_lactosa();
                cbolactosa.DataSource = lista_tipo_lactosa;
                cbolactosa.DataTextField = "_Nom_lactosa";
                cbolactosa.DataValueField = "_Cod_lactosa";
                cbolactosa.DataBind();
                cbolactosa.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }

        protected void Cargar_tipo_temperatura()
        {
            try
            {

                List<Utilidades> lista_tipo_termperatura = new UtilidadesNE().Cargartipo_temperatura();
                cbotemperatura2.DataSource = lista_tipo_termperatura;
                cbotemperatura2.DataTextField = "_Nom_tipo_temperatura";
                cbotemperatura2.DataValueField = "_Cod_tipo_temperatura";
                cbotemperatura2.DataBind();
                cbotemperatura2.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }

        protected void Cargar_tipo_volumen()
        {
            try
            {

                List<Utilidades> lista_tipo_volumen = new UtilidadesNE().Cargartipo_volumen();
                cbovolumen2.DataSource = lista_tipo_volumen;
                cbovolumen2.DataTextField = "_Nom_tipo_volumen";
                cbovolumen2.DataValueField = "_Cod_tipo_volumen";
                cbovolumen2.DataBind();
                cbovolumen2.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }

        #endregion

        #region Extras y Especiales



        protected void guardar_alimento_extra()
        {
            string tip = Session["Tipo"].ToString();
            if (tip == "EX")
            {
                Ingresar_alimentos_extras_existente();
                Habilitar_componentes();
            }
            else
            {
                 cod_estado = "1";
                if (Convert.ToInt32(cod_alimento) < 20170000)
                {

                    Graba_grilla_especial_existente();
                    Habilitar_componentes();
                }

                else
                {
                    Graba_grilla_especial_no_existente();

                }
                //Ingresar_alimentos_existente();
            }
                  txtespecial.Text = "";
            especial3.Value = "";

        }

        protected void buscar_especial(object sender, EventArgs e)
        {
            Buscar_especial();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { Agregar(); });", true);
        }

        protected void agregar_especial(object sender, EventArgs e)
        {
            
            nom_alimento_especial_2 = txtespecial.Text.ToUpper();

            if(dtespecial_2.Rows.Count==0)
            {
                string v = "";
                if (v != "")
                {
                    cod_alimento_especial_2 = Convert.ToInt32(v);
                    cod_alimentoaux = cod_alimento_especial_2;
                    Graba_grilla_especial_existente();
                }
                else
                {

                    Graba_grilla_especial_no_existente();
                }

              
            }
            txtespecial.Text = "";
            btn_agregar_ali.Visible = false;
        }

        protected void Graba_grilla_especial_no_existente()
        {
            
            if (cod_estado == "")
            {
                cod_alimento_especial_2 = Generar_cod_alimento();
            }
            string nom_distribucion = Session["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
            int cod_dis = Convert.ToInt32(Session["_Cod_Distribucion"].ToString());
            int cod_tipo = Convert.ToInt32(Session["_Cod_tipo_comida"].ToString());
            dtespecial = (DataTable)Session["tbl_alimentos_especiales"];
            DataTable dt_contex = new DataTable();
            int cont = 0;

            switch (cod_dis)
            {
                case 1:
                    dtalimentos_sopa = (DataTable)Session["tbl_alimentos_sopa"];
                    dtalimentos_sopa = limpiar_dt_grilla(dtalimentos_sopa, 1);


                    cont = Validar_repet(dtalimentos_sopa, cod_alimento_especial_2);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_sopa = Agregar_especial_grilla(dtalimentos_sopa, cod_tipo, cod_dis, cod_alimento_especial_2, grilla_sopa, "ES", nom_alimento_especial_2, nom_distribucion);
                        Session["tbl_alimentos_sopa"] = dtalimentos_sopa;
                        grilla_sopa.DataSource = new DataView(dtalimentos_sopa, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_sopa.DataBind();
                    }


                    else
                    {
                        dtalimentos_sopa = (DataTable)Session["tbl_alimentos_sopa"];
                        foreach (DataRow fila in dtalimentos_sopa.Select(" _Cod_tipo_alimento= " + cod_alimento_especial_2))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_sopa.AcceptChanges();
                                grilla_sopa.DataSource = new DataView(dtalimentos_sopa, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_sopa"] = dtalimentos_sopa;
                                grilla_sopa.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
                            }
                        }

                    }




                    break;
                case 2:

                    dtalimentos_ensaladas = (DataTable)Session["tbl_alimentos_ensaladas"];
                    dtalimentos_ensaladas = limpiar_dt_grilla(dtalimentos_ensaladas, 2);

                    cont = Validar_repet(dtalimentos_ensaladas, cod_alimento_especial_2);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_ensaladas = Agregar_especial_grilla(dtalimentos_ensaladas, cod_tipo, cod_dis, cod_alimento_especial_2, grilla_ensalada, "ES", nom_alimento_especial_2, nom_distribucion);
                        Session["tbl_alimentos_ensaladas"] = dtalimentos_ensaladas;
                        grilla_ensalada.DataSource = new DataView(dtalimentos_ensaladas, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_ensalada.DataBind();
                    }
                    else
                    {
                        foreach (DataRow fila in dtalimentos_ensaladas.Select(" _Cod_tipo_alimento= " + cod_alimento_especial_2))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_ensaladas.AcceptChanges();
                                grilla_ensalada.DataSource = new DataView(dtalimentos_ensaladas, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_ensaladas"] = dtalimentos_ensaladas;
                                grilla_ensalada.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }

                    }


                    break;
                case 3:

                    dtalimentos_plato_fondo = (DataTable)Session["tbl_alimentos_plato_fondo"];
                    dtalimentos_plato_fondo = limpiar_dt_grilla(dtalimentos_plato_fondo, 3);

                    cont = Validar_repet(dtalimentos_plato_fondo, cod_alimento_especial_2);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_plato_fondo = Agregar_especial_grilla(dtalimentos_plato_fondo, cod_tipo, cod_dis, cod_alimento_especial_2, grilla_plato_fondo, "ES", nom_alimento_especial_2, nom_distribucion);
                        Session["tbl_alimentos_plato_fondo"] = dtalimentos_plato_fondo;
                        grilla_plato_fondo.DataSource = new DataView(dtalimentos_plato_fondo, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_plato_fondo.DataBind();
                    }
                    else
                    {
                        foreach (DataRow fila in dtalimentos_plato_fondo.Select(" _Cod_tipo_alimento= " + cod_alimento_especial_2))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_plato_fondo.AcceptChanges();
                                grilla_plato_fondo.DataSource = new DataView(dtalimentos_plato_fondo, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_plato_fondo"] = dtalimentos_plato_fondo;
                                grilla_plato_fondo.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }

                    }




                    break;
                case 4:

                    dtalimentos_acompañamiento = (DataTable)Session["tbl_alimentos_acompañamiento"];
                    dtalimentos_acompañamiento = limpiar_dt_grilla(dtalimentos_acompañamiento, 4);

                    cont = Validar_repet(dtalimentos_acompañamiento, cod_alimento_especial_2);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_acompañamiento = Agregar_especial_grilla(dtalimentos_acompañamiento, cod_tipo, cod_dis, cod_alimento_especial_2, grilla_acompañamiento, "ES", nom_alimento_especial_2, nom_distribucion);
                        Session["tbl_alimentos_acompañamiento"] = dtalimentos_acompañamiento;
                        grilla_acompañamiento.DataSource = new DataView(dtalimentos_acompañamiento, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_acompañamiento.DataBind();
                    }
                    else
                    {
                        foreach (DataRow fila in dtalimentos_acompañamiento.Select(" _Cod_tipo_alimento= " + cod_alimento_especial_2))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_acompañamiento.AcceptChanges();
                                grilla_acompañamiento.DataSource = new DataView(dtalimentos_acompañamiento, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_acompañamiento"] = dtalimentos_acompañamiento;
                                grilla_acompañamiento.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }

                    }




                    break;
                case 5:

                    dtalimentos_postre = (DataTable)Session["tbl_alimentos_postre"];
                    dtalimentos_postre = limpiar_dt_grilla(dtalimentos_postre, 5);

                    cont = Validar_repet(dtalimentos_postre, cod_alimento_especial_2);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_postre = Agregar_especial_grilla(dtalimentos_postre, cod_tipo, cod_dis, cod_alimento_especial_2, grilla_postre, "ES", nom_alimento_especial_2, nom_distribucion);
                        Session["tbl_alimentos_postre"] = dtalimentos_postre;
                        grilla_postre.DataSource = new DataView(dtalimentos_postre, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_postre.DataBind();
                    }


                    else
                    {
                        foreach (DataRow fila in dtalimentos_postre.Select(" _Cod_tipo_alimento= " + cod_alimento_especial_2))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_postre.AcceptChanges();
                                grilla_postre.DataSource = new DataView(dtalimentos_postre, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_postre"] = dtalimentos_postre;
                                grilla_postre.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }

                    }



                    break;
                case 7:

                    dtalimentos_liquido = (DataTable)Session["tbl_alimentos_liquido"];
                    dtalimentos_liquido = limpiar_dt_grilla(dtalimentos_liquido, 7);

                    cont = Validar_repet(dtalimentos_liquido, cod_alimento_especial_2);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_liquido = Agregar_especial_grilla(dtalimentos_liquido, cod_tipo, cod_dis, cod_alimento_especial_2, grilla_liquido, "ES", nom_alimento_especial_2, nom_distribucion);
                        dtalimentos_liquido.AcceptChanges();
                        Session["tbl_alimentos_liquido"] = dtalimentos_liquido;
                        grilla_liquido.DataSource = new DataView(dtalimentos_liquido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_liquido.DataBind();
                    }


                    else
                    {
                        foreach (DataRow fila in dtalimentos_liquido.Select(" _Cod_tipo_alimento= " + cod_alimento_especial_2))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_liquido.AcceptChanges();
                                grilla_liquido.DataSource = new DataView(dtalimentos_liquido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_liquido"] = dtalimentos_liquido;
                                grilla_liquido.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }
                    }


                    break;
                case 8:

                    dtalimentos_solido = (DataTable)Session["tbl_alimentos_solido"];
                    dtalimentos_solido = limpiar_dt_grilla(dtalimentos_solido, 8);

                    cont = Validar_repet(dtalimentos_solido, cod_alimento_especial_2);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_solido = Agregar_especial_grilla(dtalimentos_solido, cod_tipo, cod_dis, cod_alimento_especial_2, grilla_solido, "ES", nom_alimento_especial_2, nom_distribucion);
                        Session["tbl_alimentos_solido"] = dtalimentos_solido;
                        grilla_solido.DataSource = new DataView(dtalimentos_solido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_solido.DataBind();
                    }

                    else
                    {
                        foreach (DataRow fila in dtalimentos_solido.Select(" _Cod_tipo_alimento= " + cod_alimento_especial_2))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_solido.AcceptChanges();
                                grilla_solido.DataSource = new DataView(dtalimentos_solido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_solido"] = dtalimentos_solido;
                                grilla_solido.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }

                    }



                    break;

                case 9:

                    dtalimentos_agregado = (DataTable)Session["tbl_alimentos_agregado"];
                    dtalimentos_agregado = limpiar_dt_grilla(dtalimentos_agregado, 9);

                    cont = Validar_repet(dtalimentos_agregado, cod_alimento_especial_2);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_agregado = Agregar_especial_grilla(dtalimentos_agregado, cod_tipo, cod_dis, cod_alimento_especial_2, grilla_agregado, "ES", nom_alimento_especial_2, nom_distribucion);
                        Session["tbl_alimentos_agregado"] = dtalimentos_agregado;
                        grilla_agregado.DataSource = new DataView(dtalimentos_agregado, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_agregado.DataBind();
                    }


                    else
                    {
                        foreach (DataRow fila in dtalimentos_agregado.Select(" _Cod_tipo_alimento= " + cod_alimento_especial_2))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_agregado.AcceptChanges();
                                grilla_agregado.DataSource = new DataView(dtalimentos_agregado, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_agregado"] = dtalimentos_agregado;
                                grilla_agregado.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }

                    }



                    break;


                case 10:

                    dtalimentos_hidricos = (DataTable)Session["tbl_alimentos_hidricos"];
                    dtalimentos_hidricos = limpiar_dt_grilla(dtalimentos_hidricos, 10);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_hidricos = Agregar_especial_grilla(dtalimentos_hidricos, cod_tipo, cod_dis, cod_alimento_especial_2, grilla_hidrico, "ES", nom_alimento_especial_2, nom_distribucion);
                        Session["tbl_alimentos_hidricos"] = dtalimentos_hidricos;
                        grilla_hidrico.DataSource = new DataView(dtalimentos_hidricos, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_hidrico.DataBind();
                    }

                    else
                    {
                        foreach (DataRow fila in dtalimentos_hidricos.Select(" _Cod_tipo_alimento= " + cod_alimento_especial_2))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_hidricos.AcceptChanges();
                                grilla_hidrico.DataSource = new DataView(dtalimentos_hidricos, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_hidricos"] = dtalimentos_hidricos;
                                grilla_hidrico.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }


                    }

                    break;



                default:
                    Console.WriteLine("Default case");
                    break;
            }



        }

        protected void Graba_grilla_especial_existente()
        {

            string nom_distribucion = Session["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
            int cod_dis = Convert.ToInt32(Session["_Cod_Distribucion"].ToString());
            int cod_tipo = Convert.ToInt32(Session["_Cod_tipo_comida"].ToString());
            dtespecial = (DataTable)Session["tbl_alimentos_especiales"];
            DataTable dt_contex = new DataTable();
            int cont = 0;

            switch (cod_dis)
            {
                case 1:
                    dtalimentos_sopa = (DataTable)Session["tbl_alimentos_sopa"];
                    dtalimentos_sopa = limpiar_dt_grilla(dtalimentos_sopa, 1);


                    cont = Validar_repet(dtalimentos_sopa, cod_alimento_especial_2);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_sopa = Agregar_especial_existente(dtalimentos_sopa, cod_tipo, cod_dis, cod_alimento_especial_2, grilla_sopa, "ES", nom_alimento_especial_2, nom_distribucion);
                        Session["tbl_alimentos_sopa"] = dtalimentos_sopa;
                        grilla_sopa.DataSource = new DataView(dtalimentos_sopa, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_sopa.DataBind();
                    }


                    else
                    {
                        dtalimentos_sopa = (DataTable)Session["tbl_alimentos_sopa"];
                        foreach (DataRow fila in dtalimentos_sopa.Select(" _Cod_tipo_alimento= " + cod_alimento_especial_2))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_sopa.AcceptChanges();
                                grilla_sopa.DataSource = new DataView(dtalimentos_sopa, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_sopa"] = dtalimentos_sopa;
                                grilla_sopa.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
                            }
                        }

                    }




                    break;
                case 2:

                    dtalimentos_ensaladas = (DataTable)Session["tbl_alimentos_ensaladas"];
                    dtalimentos_ensaladas = limpiar_dt_grilla(dtalimentos_ensaladas, 2);

                    cont = Validar_repet(dtalimentos_ensaladas, cod_alimento_especial_2);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_ensaladas = Agregar_especial_existente(dtalimentos_ensaladas, cod_tipo, cod_dis, cod_alimento_especial_2, grilla_ensalada, "ES", nom_alimento_especial_2, nom_distribucion);
                        Session["tbl_alimentos_ensaladas"] = dtalimentos_ensaladas;
                        grilla_ensalada.DataSource = new DataView(dtalimentos_ensaladas, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_ensalada.DataBind();
                    }
                    else
                    {
                        foreach (DataRow fila in dtalimentos_ensaladas.Select(" _Cod_tipo_alimento= " + cod_alimento_especial_2))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_ensaladas.AcceptChanges();
                                grilla_ensalada.DataSource = new DataView(dtalimentos_ensaladas, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_ensaladas"] = dtalimentos_ensaladas;
                                grilla_ensalada.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }

                    }


                    break;
                case 3:

                    dtalimentos_plato_fondo = (DataTable)Session["tbl_alimentos_plato_fondo"];
                    dtalimentos_plato_fondo = limpiar_dt_grilla(dtalimentos_plato_fondo, 3);

                    cont = Validar_repet(dtalimentos_plato_fondo, cod_alimento_especial_2);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_plato_fondo = Agregar_especial_existente(dtalimentos_plato_fondo, cod_tipo, cod_dis, cod_alimento_especial_2, grilla_plato_fondo, "ES", nom_alimento_especial_2, nom_distribucion);
                        Session["tbl_alimentos_plato_fondo"] = dtalimentos_plato_fondo;
                        grilla_plato_fondo.DataSource = new DataView(dtalimentos_plato_fondo, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_plato_fondo.DataBind();
                    }
                    else
                    {
                        foreach (DataRow fila in dtalimentos_plato_fondo.Select(" _Cod_tipo_alimento= " + cod_alimento_especial_2))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_plato_fondo.AcceptChanges();
                                grilla_plato_fondo.DataSource = new DataView(dtalimentos_plato_fondo, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_plato_fondo"] = dtalimentos_plato_fondo;
                                grilla_plato_fondo.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }

                    }




                    break;
                case 4:

                    dtalimentos_acompañamiento = (DataTable)Session["tbl_alimentos_acompañamiento"];
                    dtalimentos_acompañamiento = limpiar_dt_grilla(dtalimentos_acompañamiento, 4);

                    cont = Validar_repet(dtalimentos_acompañamiento, cod_alimento_especial_2);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_acompañamiento = Agregar_especial_existente(dtalimentos_acompañamiento, cod_tipo, cod_dis, cod_alimento_especial_2, grilla_acompañamiento, "ES", nom_alimento_especial_2, nom_distribucion);
                        Session["tbl_alimentos_acompañamiento"] = dtalimentos_acompañamiento;
                        grilla_acompañamiento.DataSource = new DataView(dtalimentos_acompañamiento, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_acompañamiento.DataBind();
                    }
                    else
                    {
                        foreach (DataRow fila in dtalimentos_acompañamiento.Select(" _Cod_tipo_alimento= " + cod_alimento_especial_2))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_acompañamiento.AcceptChanges();
                                grilla_acompañamiento.DataSource = new DataView(dtalimentos_acompañamiento, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_acompañamiento"] = dtalimentos_acompañamiento;
                                grilla_acompañamiento.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }

                    }




                    break;
                case 5:

                    dtalimentos_postre = (DataTable)Session["tbl_alimentos_postre"];
                    dtalimentos_postre = limpiar_dt_grilla(dtalimentos_postre, 5);

                    cont = Validar_repet(dtalimentos_postre, cod_alimento_especial_2);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_postre = Agregar_especial_existente(dtalimentos_postre, cod_tipo, cod_dis, cod_alimento_especial_2, grilla_postre, "ES", nom_alimento_especial_2, nom_distribucion);
                        Session["tbl_alimentos_postre"] = dtalimentos_postre;
                        grilla_postre.DataSource = new DataView(dtalimentos_postre, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_postre.DataBind();
                    }


                    else
                    {
                        foreach (DataRow fila in dtalimentos_postre.Select(" _Cod_tipo_alimento= " + cod_alimento_especial_2))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_postre.AcceptChanges();
                                grilla_postre.DataSource = new DataView(dtalimentos_postre, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_postre"] = dtalimentos_postre;
                                grilla_postre.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }

                    }



                    break;
                case 7:

                    dtalimentos_liquido = (DataTable)Session["tbl_alimentos_liquido"];
                    dtalimentos_liquido = limpiar_dt_grilla(dtalimentos_liquido, 7);

                    cont = Validar_repet(dtalimentos_liquido, cod_alimento_especial_2);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_liquido = Agregar_especial_existente(dtalimentos_liquido, cod_tipo, cod_dis, cod_alimento_especial_2, grilla_liquido, "ES", nom_alimento_especial_2, nom_distribucion);
                        dtalimentos_liquido.AcceptChanges();
                        Session["tbl_alimentos_liquido"] = dtalimentos_liquido;
                        grilla_liquido.DataSource = new DataView(dtalimentos_liquido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_liquido.DataBind();
                    }


                    else
                    {
                        foreach (DataRow fila in dtalimentos_liquido.Select(" _Cod_tipo_alimento= " + cod_alimento_especial_2))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_liquido.AcceptChanges();
                                grilla_liquido.DataSource = new DataView(dtalimentos_liquido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_liquido"] = dtalimentos_liquido;
                                grilla_liquido.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }
                    }


                    break;
                case 8:

                    dtalimentos_solido = (DataTable)Session["tbl_alimentos_solido"];
                    dtalimentos_solido = limpiar_dt_grilla(dtalimentos_solido, 8);

                    cont = Validar_repet(dtalimentos_solido, cod_alimento_especial_2);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_solido = Agregar_especial_existente(dtalimentos_solido, cod_tipo, cod_dis, cod_alimento_especial_2, grilla_solido, "ES", nom_alimento_especial_2, nom_distribucion);
                        Session["tbl_alimentos_solido"] = dtalimentos_solido;
                        grilla_solido.DataSource = new DataView(dtalimentos_solido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_solido.DataBind();
                    }

                    else
                    {
                        foreach (DataRow fila in dtalimentos_solido.Select(" _Cod_tipo_alimento= " + cod_alimento_especial_2))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_solido.AcceptChanges();
                                grilla_solido.DataSource = new DataView(dtalimentos_solido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_solido"] = dtalimentos_solido;
                                grilla_solido.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }

                    }



                    break;

                case 9:

                    dtalimentos_agregado = (DataTable)Session["tbl_alimentos_agregado"];
                    dtalimentos_agregado = limpiar_dt_grilla(dtalimentos_agregado, 9);

                    cont = Validar_repet(dtalimentos_agregado, cod_alimento_especial_2);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_agregado = Agregar_especial_existente(dtalimentos_agregado, cod_tipo, cod_dis, cod_alimento_especial_2, grilla_agregado, "ES", nom_alimento_especial_2, nom_distribucion);
                        Session["tbl_alimentos_agregado"] = dtalimentos_agregado;
                        grilla_agregado.DataSource = new DataView(dtalimentos_agregado, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_agregado.DataBind();
                    }


                    else
                    {
                        foreach (DataRow fila in dtalimentos_agregado.Select(" _Cod_tipo_alimento= " + cod_alimento_especial_2))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_agregado.AcceptChanges();
                                grilla_agregado.DataSource = new DataView(dtalimentos_agregado, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_agregado"] = dtalimentos_agregado;
                                grilla_agregado.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }

                    }



                    break;


                case 10:

                    dtalimentos_hidricos = (DataTable)Session["tbl_alimentos_hidricos"];
                    dtalimentos_hidricos = limpiar_dt_grilla(dtalimentos_hidricos, 10);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_hidricos = Agregar_especial_existente(dtalimentos_hidricos, cod_tipo, cod_dis, cod_alimento_especial_2, grilla_hidrico, "ES", nom_alimento_especial_2, nom_distribucion);
                        Session["tbl_alimentos_hidricos"] = dtalimentos_hidricos;
                        grilla_hidrico.DataSource = new DataView(dtalimentos_hidricos, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_hidrico.DataBind();
                    }

                    else
                    {
                        foreach (DataRow fila in dtalimentos_hidricos.Select(" _Cod_tipo_alimento= " + cod_alimento_especial_2))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_hidricos.AcceptChanges();
                                grilla_hidrico.DataSource = new DataView(dtalimentos_hidricos, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_hidricos"] = dtalimentos_hidricos;
                                grilla_hidrico.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }


                    }

                    break;



                default:
                    Console.WriteLine("Default case");
                    break;
            }



        }


        protected int Generar_cod_alimento()
        {
            int var = 0;
            int codigo_esp = 0;
            int contador = 0;
            int cod_x = 0;
            int valor_cod = 0;
            string val = "";
            Utilidades u = new UtilidadesNE().Extraer_codigo_especial();
            codigo_esp = u._Id;

           

                string v = DateTime.Now.ToString("dd-MM-yyyy");
                string[] c = v.Split('-');
                string c1 = c[0];
                string c2 = c[1];
                string c3 = c[2];
                 val = c3 + c2 + "00";
          


            dtespecial_2 = (DataTable)Session["tbl_super_especial"];
            foreach (DataRow fila in dtespecial_2.Rows)
            {
                cod_x = Convert.ToInt32(fila["_Cod_tipo_alimento"].ToString());
                contador++;
            }

            if (contador > 0)
            {
                var = Convert.ToInt32(val) + codigo_esp + contador;
            }
            else 
            {
                var = Convert.ToInt32(val) + codigo_esp ;
            }

           
            return var;

        }



        protected DataTable limpiar_dt_grilla(DataTable dt_1, int cod)
        {
            foreach (DataRow rx in dt_1.Rows)
            {
                if (Convert.ToInt32(rx["_Cod_tipo_distribucion"].ToString()) != cod)
                {
                    rx.Delete();
                }

            }
            dt_1.AcceptChanges();
            return dt_1;
        }


        protected DataTable Agregar_especial_grilla(DataTable dt_dis, int cod_tipo, int cod_dis, int cod_al, GridView nom, string estado, string nom_al, string nom_dist)
        {

            dtsuper_especial = (DataTable)Session["tbl_super_especial"];
            dtespecial = (DataTable)Session["tbl_alimentos_especiales"];


            int cont1 = Validar_repet(dt_dis, cod_al);
            if (cont1 == 0)
            {
                DataRow Fila2 = dt_dis.NewRow();
                Fila2["_Cod_tipo_distribucion"] = cod_dis;
                Fila2["_Cod_tipo_comida"] = cod_tipo;
                Fila2["_Id_tipo_alimento"] = cod_al;
                Fila2["_Cod_tipo_alimento"] = cod_al;
                Fila2["_Nom_tipo_alimento"] = nom_al.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ").ToUpper();
                Fila2["_Nom_tipo_distribucion"] = nom_dist.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ").ToUpper();
                Fila2["_Vigencia"] = 'S';
                Fila2["_Cantidad"] = 1;
                Fila2["_Estado"] = estado;

                Fila2["_Cod_tipo_consistencia"] = "0";
                Fila2["_Cod_tipo_digestabilidad"] = "0";
                Fila2["_Cod_lactosa"] = "0";
                Fila2["_Cod_dulzor"] = "0";
                Fila2["_Cod_tipo_sales"] = "0";
                Fila2["_Cod_tipo_temperatura"] = "0";
                Fila2["_Cod_tipo_volumen"] = "0";
                Fila2["_Mixto"] = "N";


                // cargar  los  combobox  de la grilla
                txtal.Text = nom_al.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ").ToUpper();
                cboconsistencia.SelectedIndex = 0;
                cbodigestabilidad.SelectedIndex = 0;
                cbolactosa.SelectedIndex = 0;
                cbodulzor.SelectedIndex = 0;
                cbotipo_sal.SelectedIndex = 0;
                cbotemperatura2.SelectedIndex = 0;
                cbovolumen2.SelectedIndex = 0;
                txtcomentario.Text = "";

                dt_dis.Rows.Add(Fila2);

                dt_dis.AcceptChanges();
            }
            else
            {
                dt_dis = Cambio_estado_alimento(dt_dis, cod_al);

            }

            nom.DataSource = new DataView(dt_dis, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);

            nom.DataBind();

            //   llenar  especiales
            int cont2 = Validar_repet(dtsuper_especial, cod_al);
            if (cont2 == 0)
            {


                DataRow Fila1 = dtsuper_especial.NewRow();
                Fila1["_Cod_tipo_distribucion"] = cod_dis;
                Fila1["_Cod_tipo_comida"] = cod_tipo;
                Fila1["_Id_tipo_alimento"] = cod_al;
                Fila1["_Cod_tipo_alimento"] = cod_al;
                Fila1["_Nom_tipo_alimento"] = nom_al.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ").ToUpper();
                Fila1["_Nom_tipo_distribucion"] = nom_dist.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ").ToUpper();
                Fila1["_Vigencia"] = 'S';
                Fila1["_Cantidad"] = 1;
                Fila1["_Estado"] = "ES";

                Fila1["_Cod_tipo_consistencia"] = "0";
                Fila1["_Cod_tipo_digestabilidad"] = "0";
                Fila1["_Cod_lactosa"] = "0";
                Fila1["_Cod_dulzor"] = "0";
                Fila1["_Cod_tipo_sales"] = "0";
                Fila1["_Cod_tipo_temperatura"] = "0";
                Fila1["_Cod_tipo_volumen"] = "0";
                Fila1["_Mixto"] = "N";

                dtsuper_especial.Rows.Add(Fila1);

                dtsuper_especial.AcceptChanges();
                Session["tbl_super_especial"] = dtsuper_especial;

            }

            int cont3 = Validar_repet(dtespecial, cod_al);
            if (cont3 == 0)
            {
                DataRow Fila11 = dtespecial.NewRow();
                Fila11["_Cod_tipo_distribucion"] = cod_dis;
                Fila11["_Cod_tipo_comida"] = cod_tipo;
                Fila11["_Id_tipo_alimento"] = cod_al;
                Fila11["_Cod_tipo_alimento"] = cod_al;
                Fila11["_Nom_tipo_alimento"] = nom_al.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ").ToUpper();
                Fila11["_Nom_tipo_distribucion"] = nom_dist.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ").ToUpper();
                Fila11["_Vigencia"] = 'S';
                Fila11["_Cantidad"] = 1;
                Fila11["_Estado"] = "ES";

                Fila11["_Cod_tipo_consistencia"] = "0";
                Fila11["_Cod_tipo_digestabilidad"] = "0";
                Fila11["_Cod_lactosa"] = "0";
                Fila11["_Cod_dulzor"] = "0";
                Fila11["_Cod_tipo_sales"] = "0";
                Fila11["_Cod_tipo_temperatura"] = "0";
                Fila11["_Cod_tipo_volumen"] = "0";
                Fila11["_Mixto"] = "N";

                dtespecial.Rows.Add(Fila11);

                dtespecial.AcceptChanges();
                grilla_especial.DataSource = new DataView(dtespecial, "_Vigencia ='S' and _Cod_tipo_distribucion='" + cod_dis + "'", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
                Session["tbl_alimentos_especiales"] = dtespecial;
                grilla_especial.DataBind();
            }
            // Cargar_grilla_extra_especiales();
            return dt_dis;
        }

        protected DataTable Agregar_especial_existente(DataTable dt_dis, int cod_tipo, int cod_dis, int cod_al, GridView nom, string estado, string nom_al, string nom_dist)
        {

            dtsuper_especial = (DataTable)Session["tbl_super_especial"];
            dtespecial = (DataTable)Session["tbl_alimentos_especiales"];
            dt_componentes = (DataTable)Session["dt_componentes"];

            foreach (DataRow fila in dt_componentes.Select(" _Id_tipo_alimento= " + cod_al))
            {
                //   llenar  especiales
                int cont1 = Validar_repet(dt_dis, cod_al);
                if (cont1 == 0)
                {
                    DataRow Fila2 = dt_dis.NewRow();
                    Fila2["_Cod_tipo_comida"] = cod_tipo;
                    Fila2["_Cod_tipo_distribucion"] = cod_dis;
                    Fila2["_Id_tipo_alimento"] = cod_alimento_especial_2;
                    Fila2["_Cod_tipo_alimento"] = cod_alimento_especial_2;
                    Fila2["_Nom_tipo_alimento"] = nom_alimento_especial_2.ToUpper();
                    Fila2["_Nom_tipo_distribucion"] = fila["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila2["_Vigencia"] = 'S';
                    Fila2["_Cantidad"] = 1;
                    Fila2["_Estado"] = estado;

                    Fila2["_Cod_tipo_consistencia"] = Convert.ToInt32(fila["_Cod_tipo_consistencia"].ToString());
                    Fila2["_Cod_tipo_digestabilidad"] = Convert.ToInt32(fila["_Cod_tipo_digestabilidad"].ToString());



                    string v_lactosa = fila["_No_lactosa"].ToString();
                    if (v_lactosa == "S")
                    {
                        Fila2["_Cod_lactosa"] = Convert.ToInt32(fila["_Cod_lactosa_pref"].ToString());
                        cbolactosa.SelectedValue = fila["_Cod_lactosa_pref"].ToString();
                    }
                    else
                    {
                        Fila2["_Cod_lactosa"] = Convert.ToInt32(fila["_Cod_lactosa"].ToString());
                        cbolactosa.SelectedValue = fila["_Cod_lactosa"].ToString();
                    }

                    string v_dulzor = fila["_No_dulzor"].ToString();
                    if (v_dulzor == "S")
                    {
                        Fila2["_Cod_dulzor"] = Convert.ToInt32(fila["_Cod_dulzor_pref"].ToString());
                        cbodulzor.SelectedValue = fila["_Cod_dulzor_pref"].ToString();
                    }
                    else
                    {
                        Fila2["_Cod_dulzor"] = Convert.ToInt32(fila["_Cod_dulzor"].ToString());
                        cbodulzor.SelectedValue = fila["_Cod_dulzor"].ToString();
                    }

                    string v_sal = fila["_No_sal"].ToString();
                    if (v_sal == "S")
                    {
                        Fila2["_Cod_dulzor"] = Convert.ToInt32(fila["_Cod_sales_pref"].ToString());
                        cbotipo_sal.SelectedValue = fila["_Cod_sales_pref"].ToString();
                    }
                    else
                    {
                        Fila2["_Cod_tipo_sales"] = Convert.ToInt32(fila["_Cod_tipo_sales"].ToString());
                        cbotipo_sal.SelectedValue = fila["_Cod_tipo_sales"].ToString();
                    }




                    Fila2["_Cod_tipo_temperatura"] = Convert.ToInt32(fila["_Cod_tipo_temperatura"].ToString());
                    Fila2["_Cod_tipo_volumen"] = Convert.ToInt32(fila["_Cod_tipo_volumen"].ToString());
                    Fila2["_Observacion"] = "";
                    Fila2["_Mixto"] = "N";

                    // cargar  los  combobox  de la grilla
                    txtal.Text = fila["_Nom_tipo_alimento"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    cboconsistencia.SelectedValue = fila["_Cod_tipo_consistencia"].ToString();
                    cbodigestabilidad.SelectedValue = fila["_Cod_tipo_digestabilidad"].ToString();
                    cbotemperatura2.SelectedValue = fila["_Cod_tipo_temperatura"].ToString();
                    cbovolumen2.SelectedValue = fila["_Cod_tipo_volumen"].ToString();
                    txtcomentario.Text = "";


                    dt_dis.Rows.Add(Fila2);
                }

                else
                {
                    dt_dis = Cambio_estado_alimento(dt_dis, cod_al);

                }



                //   llenar  especiales
                int cont2 = Validar_repet(dtsuper_especial, cod_al);
                if (cont2 == 0)
                {


                    DataRow Fila1 = dtsuper_especial.NewRow();
                    Fila1["_Cod_tipo_distribucion"] = cod_dis;
                    Fila1["_Cod_tipo_comida"] = cod_tipo;
                    Fila1["_Id_tipo_alimento"] = cod_alimento_especial_2;
                    Fila1["_Cod_tipo_alimento"] = cod_alimento_especial_2;
                    Fila1["_Nom_tipo_alimento"] = nom_alimento_especial_2.ToUpper();
                    Fila1["_Nom_tipo_distribucion"] = fila["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila1["_Vigencia"] = 'S';
                    Fila1["_Cantidad"] = 1;
                    Fila1["_Estado"] = "ES";

                    Fila1["_Cod_tipo_consistencia"] = Convert.ToInt32(fila["_Cod_tipo_consistencia"].ToString());
                    Fila1["_Cod_tipo_digestabilidad"] = Convert.ToInt32(fila["_Cod_tipo_digestabilidad"].ToString());

                    string v_lactosa = fila["_No_lactosa"].ToString();
                    if (v_lactosa == "S")
                    {
                        Fila1["_Cod_lactosa"] = Convert.ToInt32(fila["_Cod_lactosa_pref"].ToString());
                     
                    }
                    else
                    {
                        Fila1["_Cod_lactosa"] = Convert.ToInt32(fila["_Cod_lactosa"].ToString());
                     
                    }

                    string v_dulzor = fila["_No_dulzor"].ToString();
                    if (v_dulzor == "S")
                    {
                        Fila1["_Cod_dulzor"] = Convert.ToInt32(fila["_Cod_dulzor_pref"].ToString());
                       
                    }
                    else
                    {
                        Fila1["_Cod_dulzor"] = Convert.ToInt32(fila["_Cod_dulzor"].ToString());
                        cbodulzor.SelectedValue = fila["_Cod_dulzor"].ToString();
                    }

                    string v_sal = fila["_No_sal"].ToString();
                    if (v_sal == "S")
                    {
                        Fila1["_Cod_dulzor"] = Convert.ToInt32(fila["_Cod_sales_pref"].ToString());
                      
                    }
                    else
                    {
                        Fila1["_Cod_tipo_sales"] = Convert.ToInt32(fila["_Cod_tipo_sales"].ToString());
                      
                    }

                    Fila1["_Cod_tipo_temperatura"] = Convert.ToInt32(fila["_Cod_tipo_temperatura"].ToString());
                    Fila1["_Cod_tipo_volumen"] = Convert.ToInt32(fila["_Cod_tipo_volumen"].ToString());
                    Fila1["_Mixto"] = "N";

                    dtsuper_especial.Rows.Add(Fila1);

                    dtsuper_especial.AcceptChanges();
                    Session["tbl_super_especial"] = dtsuper_especial;

                }

                int cont3 = Validar_repet(dtespecial, cod_al);
                if (cont3 == 0)
                {
                    DataRow Fila11 = dtespecial.NewRow();
                    Fila11["_Cod_tipo_distribucion"] = cod_dis;
                    Fila11["_Cod_tipo_comida"] = cod_tipo;
                    Fila11["_Id_tipo_alimento"] = cod_alimento_especial_2;
                    Fila11["_Cod_tipo_alimento"] = cod_alimento_especial_2;
                    Fila11["_Nom_tipo_alimento"] = nom_alimento_especial_2.ToUpper();
                    Fila11["_Nom_tipo_distribucion"] = fila["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila11["_Vigencia"] = 'S';
                    Fila11["_Cantidad"] = 1;
                    Fila11["_Estado"] = "ES";

                    Fila11["_Cod_tipo_consistencia"] = Convert.ToInt32(fila["_Cod_tipo_consistencia"].ToString());
                    Fila11["_Cod_tipo_digestabilidad"] = Convert.ToInt32(fila["_Cod_tipo_digestabilidad"].ToString());

                    string v_lactosa = fila["_No_lactosa"].ToString();
                    if (v_lactosa == "S")
                    {
                        Fila11["_Cod_lactosa"] = Convert.ToInt32(fila["_Cod_lactosa_pref"].ToString());
                       
                    }
                    else
                    {
                        Fila11["_Cod_lactosa"] = Convert.ToInt32(fila["_Cod_lactosa"].ToString());
                        
                    }

                    string v_dulzor = fila["_No_dulzor"].ToString();
                    if (v_dulzor == "S")
                    {
                        Fila11["_Cod_dulzor"] = Convert.ToInt32(fila["_Cod_dulzor_pref"].ToString());
                        
                    }
                    else
                    {
                        Fila11["_Cod_dulzor"] = Convert.ToInt32(fila["_Cod_dulzor"].ToString());
                 
                    }

                    string v_sal = fila["_No_sal"].ToString();
                    if (v_sal == "S")
                    {
                        Fila11["_Cod_dulzor"] = Convert.ToInt32(fila["_Cod_sales_pref"].ToString());
                       
                    }
                    else
                    {
                        Fila11["_Cod_tipo_sales"] = Convert.ToInt32(fila["_Cod_tipo_sales"].ToString());
                       
                    }

                    Fila11["_Cod_tipo_temperatura"] = Convert.ToInt32(fila["_Cod_tipo_temperatura"].ToString());
                    Fila11["_Cod_tipo_volumen"] = Convert.ToInt32(fila["_Cod_tipo_volumen"].ToString());
                    Fila11["_Mixto"] = "N";

                    dtespecial.Rows.Add(Fila11);

                    dtespecial.AcceptChanges();
                    grilla_especial.DataSource = new DataView(dtespecial, "_Vigencia ='S' and _Cod_tipo_distribucion='" + cod_dis + "'", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
                    Session["tbl_alimentos_especiales"] = dtespecial;
                    grilla_especial.DataBind();
                }


            }

            // Cargar_grilla_extra_especiales();
            return dt_dis;
        }

        protected DataTable Agregar_extras_grilla(DataTable dt_ext, DataTable dt_dis, int cod_tipo, int cod_dis, int cod_al, string estado)
        {
            dt_dis = borrar(dt_dis);
            if (estado == "EX")
            {
                
                foreach (DataRow fila in dt_ext.Select(" _Id_tipo_alimento= " + cod_al))
                {
                    int _num = Convert.ToInt32(fila["_Cod_tipo_distribucion"].ToString());
                    DataRow Fila2 = dt_dis.NewRow();
                    if (cod_dis == 0)
                    {
                        if(cod_distribucion==8)
                        {
                            if (_num == 5)
                            {
                                Fila2["_Cod_tipo_distribucion"] = "8";
                            }
                            else
                            {
                                Fila2["_Cod_tipo_distribucion"] =_num;
                            }
                        }
                        else
                        {
                             Fila2["_Cod_tipo_distribucion"] = cod_distribucion;
                        }
                       
                    }
                    else
                    {
                     
                        if(cod_distribucion==8)
                        {
                            if (_num == 5)
                            {
                                Fila2["_Cod_tipo_distribucion"] = "8";
                            }
                            else
                            {
                                Fila2["_Cod_tipo_distribucion"] =_num;
                            }
                        }
                        else
                        {
                             Fila2["_Cod_tipo_distribucion"] = cod_dis;
                        }
                       

                    }


                    Fila2["_Cod_tipo_comida"] = cod_tipo;
                    Fila2["_Id_tipo_alimento"] = Convert.ToInt32(fila["_Id_tipo_alimento"].ToString());
                    Fila2["_Cod_tipo_alimento"] = Convert.ToInt32(fila["_Cod_tipo_alimento"].ToString()); ;
                    Fila2["_Nom_tipo_alimento"] = fila["_Nom_tipo_alimento"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila2["_Nom_tipo_distribucion"] = fila["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila2["_Vigencia"] = 'S';
                    Fila2["_Cantidad"] = 1;
                    Fila2["_Estado"] = estado;

                    Fila2["_Cod_tipo_consistencia"] = Convert.ToInt32(fila["_Cod_tipo_consistencia"].ToString());
                    Fila2["_Cod_tipo_digestabilidad"] = Convert.ToInt32(fila["_Cod_tipo_digestabilidad"].ToString());


                    string v_lactosa = fila["_No_lactosa"].ToString();
                    if (v_lactosa == "S")
                    {
                        Fila2["_Cod_lactosa"] = Convert.ToInt32(fila["_Cod_lactosa_pref"].ToString());
                        cbolactosa.SelectedValue = fila["_Cod_lactosa_pref"].ToString();
                    }
                    else
                    {
                        Fila2["_Cod_lactosa"] = Convert.ToInt32(fila["_Cod_lactosa"].ToString());
                        cbolactosa.SelectedValue = Fila2["_Cod_lactosa"].ToString();
                    }

                    string v_dulzor = fila["_No_dulzor"].ToString();
                    if (v_dulzor == "S")
                    {
                        Fila2["_Cod_dulzor"] = Convert.ToInt32(fila["_Cod_dulzor_pref"].ToString());
                        cbodulzor.SelectedValue = fila["_Cod_dulzor_pref"].ToString();
                    }
                    else
                    {
                        Fila2["_Cod_dulzor"] = Convert.ToInt32(fila["_Cod_dulzor"].ToString());
                        cbodulzor.SelectedValue = Fila2["_Cod_dulzor"].ToString();
                    }

                    string v_sal = fila["_No_sal"].ToString();
                    if (v_sal == "S")
                    {
                        Fila2["_Cod_tipo_sales"] = Convert.ToInt32(fila["_Cod_sales_pref"].ToString());
                        cbotipo_sal.SelectedValue = fila["_Cod_sales_pref"].ToString();
                    }
                    else
                    {
                        Fila2["_Cod_tipo_sales"] = Convert.ToInt32(fila["_Cod_tipo_sales"].ToString());
                        cbotipo_sal.SelectedValue = Fila2["_Cod_tipo_sales"].ToString();
                    }

                    Fila2["_Cod_tipo_temperatura"] = Convert.ToInt32(fila["_Cod_tipo_temperatura"].ToString());
                    Fila2["_Cod_tipo_volumen"] = Convert.ToInt32(fila["_Cod_tipo_volumen"].ToString());
                    Fila2["_Observacion"] = "";
                    Fila2["_Mixto"] = "N";

                    // cargar  los  combobox  de la grilla
                    txtal.Text = fila["_Nom_tipo_alimento"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    cboconsistencia.SelectedValue = fila["_Cod_tipo_consistencia"].ToString();
                    cbodigestabilidad.SelectedValue = fila["_Cod_tipo_digestabilidad"].ToString();
                    cbotemperatura2.SelectedValue = fila["_Cod_tipo_temperatura"].ToString();
                    cbovolumen2.SelectedValue = fila["_Cod_tipo_volumen"].ToString();
                    txtcomentario.Text = "";


                    dt_dis.Rows.Add(Fila2);
                }

            }
            else
            {



                foreach (DataRow fila in dt_ext.Select(" _Id_tipo_alimento= " + cod_al))
                {
                    DataRow Fila2 = dt_dis.NewRow();
                    if (cod_dis == 0)
                    {
                        Fila2["_Cod_tipo_distribucion"] = Convert.ToInt32(fila["_Cod_tipo_distribucion"].ToString());
                    }
                    else
                    {
                        Fila2["_Cod_tipo_distribucion"] = cod_dis;

                    }
                    Fila2["_Cod_tipo_comida"] = cod_tipo;
                    Fila2["_Id_tipo_alimento"] = Convert.ToInt32(fila["_Id_tipo_alimento"].ToString());
                    Fila2["_Cod_tipo_alimento"] = Convert.ToInt32(fila["_Cod_tipo_alimento"].ToString()); ;
                    Fila2["_Nom_tipo_alimento"] = fila["_Nom_tipo_alimento"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila2["_Nom_tipo_distribucion"] = fila["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila2["_Vigencia"] = 'S';
                    Fila2["_Cantidad"] = 1;
                    Fila2["_Estado"] = estado;

                    Fila2["_Cod_tipo_consistencia"] = Convert.ToInt32(fila["_Cod_tipo_consistencia"].ToString());
                    Fila2["_Cod_tipo_digestabilidad"] = Convert.ToInt32(fila["_Cod_tipo_digestabilidad"].ToString());

                    string v_lactosa = fila["_No_lactosa"].ToString();
                    if (v_lactosa == "S")
                    {
                        Fila2["_Cod_lactosa"] = Convert.ToInt32(fila["_Cod_lactosa_pref"].ToString());
                        cbolactosa.SelectedValue = fila["_Cod_lactosa_pref"].ToString();
                    }
                    else
                    {
                        Fila2["_Cod_lactosa"] = Convert.ToInt32(fila["_Cod_lactosa"].ToString());
                        cbolactosa.SelectedValue = fila["_Cod_lactosa"].ToString();
                    }

                    string v_dulzor = fila["_No_dulzor"].ToString();
                    if (v_dulzor == "S")
                    {
                        Fila2["_Cod_dulzor"] = Convert.ToInt32(fila["_Cod_dulzor_pref"].ToString());
                        cbodulzor.SelectedValue = fila["_Cod_dulzor_pref"].ToString();
                    }
                    else
                    {
                        Fila2["_Cod_dulzor"] = Convert.ToInt32(fila["_Cod_dulzor"].ToString());
                        cbodulzor.SelectedValue = fila["_Cod_dulzor"].ToString();
                    }

                    string v_sal = fila["_No_sal"].ToString();
                    if (v_sal == "S")
                    {
                        Fila2["_Cod_tipo_sales"] = Convert.ToInt32(fila["_Cod_sales_pref"].ToString());
                        cbotipo_sal.SelectedValue = fila["_Cod_sales_pref"].ToString();
                    }
                    else
                    {
                        Fila2["_Cod_tipo_sales"] = Convert.ToInt32(fila["_Cod_tipo_sales"].ToString());
                        cbotipo_sal.SelectedValue = fila["_Cod_tipo_sales"].ToString();
                    }
                    Fila2["_Cod_tipo_temperatura"] = Convert.ToInt32(fila["_Cod_tipo_temperatura"].ToString());
                    Fila2["_Cod_tipo_volumen"] = Convert.ToInt32(fila["_Cod_tipo_volumen"].ToString());
                    Fila2["_Observacion"] = "";
                    Fila2["_Mixto"] = "N";

                    // cargar  los  combobox  de la grilla
                    txtal.Text = fila["_Nom_tipo_alimento"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    cboconsistencia.SelectedValue = fila["_Cod_tipo_consistencia"].ToString();
                    cbodigestabilidad.SelectedValue =fila["_Cod_tipo_digestabilidad"].ToString();
     
                   
                    cbotemperatura2.SelectedValue = fila["_Cod_tipo_temperatura"].ToString();
                    cbovolumen2.SelectedValue =fila["_Cod_tipo_volumen"].ToString();
                    txtcomentario.Text = "";


                    dt_dis.Rows.Add(Fila2);


                    //   llenar  especiales
                    int cont2 = Validar_repet(dtsuper_especial, cod_al);
                    if (cont2 == 0)
                    {


                        DataRow Fila1 = dtsuper_especial.NewRow();
                        Fila1["_Cod_tipo_distribucion"] = cod_dis;
                        Fila1["_Cod_tipo_comida"] = cod_tipo;
                        Fila1["_Id_tipo_alimento"] = cod_al;
                        Fila1["_Cod_tipo_alimento"] = cod_al;
                        Fila1["_Nom_tipo_alimento"] = fila["_Nom_tipo_alimento"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                        Fila1["_Nom_tipo_distribucion"] = fila["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                        Fila1["_Vigencia"] = 'S';
                        Fila1["_Cantidad"] = 1;
                        Fila1["_Estado"] = "ES";

                        Fila1["_Cod_tipo_consistencia"] = Convert.ToInt32(fila["_Cod_tipo_consistencia"].ToString());
                        Fila1["_Cod_tipo_digestabilidad"] = Convert.ToInt32(fila["_Cod_tipo_digestabilidad"].ToString());
                        Fila1["_Cod_lactosa"] = Convert.ToInt32(fila["_Cod_lactosa"].ToString());
                        Fila1["_Cod_dulzor"] = Convert.ToInt32(fila["_Cod_dulzor"].ToString());
                        Fila1["_Cod_tipo_sales"] = Convert.ToInt32(fila["_Cod_tipo_sales"].ToString());
                        Fila1["_Cod_tipo_temperatura"] = Convert.ToInt32(fila["_Cod_tipo_temperatura"].ToString());
                        Fila1["_Cod_tipo_volumen"] = Convert.ToInt32(fila["_Cod_tipo_volumen"].ToString());
                        Fila1["_Mixto"] = "N";

                        dtsuper_especial.Rows.Add(Fila1);

                        dtsuper_especial.AcceptChanges();
                        Session["tbl_super_especial"] = dtsuper_especial;

                    }

                    int cont3 = Validar_repet(dtespecial, cod_al);
                    if (cont3 == 0)
                    {
                        DataRow Fila11 = dtespecial.NewRow();
                        Fila11["_Cod_tipo_distribucion"] = cod_dis;
                        Fila11["_Cod_tipo_comida"] = cod_tipo;
                        Fila11["_Id_tipo_alimento"] = cod_al;
                        Fila11["_Cod_tipo_alimento"] = cod_al;
                        Fila11["_Nom_tipo_alimento"] = fila["_Nom_tipo_alimento"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                        Fila11["_Nom_tipo_distribucion"] = fila["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                        Fila11["_Vigencia"] = 'S';
                        Fila11["_Cantidad"] = 1;
                        Fila11["_Estado"] = "ES";

                        Fila11["_Cod_tipo_consistencia"] = Convert.ToInt32(fila["_Cod_tipo_consistencia"].ToString());
                        Fila11["_Cod_tipo_digestabilidad"] = Convert.ToInt32(fila["_Cod_tipo_digestabilidad"].ToString());
                        Fila11["_Cod_lactosa"] = Convert.ToInt32(fila["_Cod_lactosa"].ToString());
                        Fila11["_Cod_dulzor"] = Convert.ToInt32(fila["_Cod_dulzor"].ToString());
                        Fila11["_Cod_tipo_sales"] = Convert.ToInt32(fila["_Cod_tipo_sales"].ToString());
                        Fila11["_Cod_tipo_temperatura"] = Convert.ToInt32(fila["_Cod_tipo_temperatura"].ToString());
                        Fila11["_Cod_tipo_volumen"] = Convert.ToInt32(fila["_Cod_tipo_volumen"].ToString());
                        Fila11["_Mixto"] = "N";

                        dtespecial.Rows.Add(Fila11);

                        dtespecial.AcceptChanges();
                        grilla_especial.DataSource = new DataView(dtespecial, "_Vigencia ='S' and _Cod_tipo_distribucion='" + cod_dis + "'", "_Cod_tipo_distribucion", DataViewRowState.CurrentRows);
                        Session["tbl_alimentos_especiales"] = dtespecial;
                        grilla_especial.DataBind();
                    }


                }
            }



            dt_dis.AcceptChanges();


            return dt_dis;
        }

        protected DataTable Agregar_dt_extras(DataTable dt_ext, DataTable dt_ext2, int cod_tipo, int cod)
        {
            dt_ext = borrar(dt_ext2);
            foreach (DataRow fil in dt_ext.Select(" _Cod_tipo_alimento= " + cod))
            {
                DataRow Fila2 = dt_ext2.NewRow();
                Fila2["_Cod_tipo_distribucion"] = Convert.ToInt32(fil["_Cod_tipo_distribucion"].ToString());
                Fila2["_Cod_tipo_comida"] = cod_tipo;
                Fila2["_Id_tipo_alimento"] = Convert.ToInt32(fil["_Id_tipo_alimento"].ToString());
                Fila2["_Cod_tipo_alimento"] = Convert.ToInt32(fil["_Cod_tipo_alimento"].ToString()); ;
                Fila2["_Nom_tipo_alimento"] = fil["_Nom_tipo_alimento"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                Fila2["_Nom_tipo_distribucion"] = fil["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                Fila2["_Vigencia"] = 'S';
                Fila2["_Cantidad"] = 1;
                Fila2["_Estado"] = "EX";

                Fila2["_Cod_tipo_consistencia"] = Convert.ToInt32(fil["_Cod_tipo_consistencia"].ToString());
                Fila2["_Cod_tipo_digestabilidad"] = Convert.ToInt32(fil["_Cod_tipo_digestabilidad"].ToString());

                  string v_lactosa=fil["_No_lactosa"].ToString();
                  if (v_lactosa == "S")
                  {
                      Fila2["_Cod_lactosa"] = Convert.ToInt32(fil["_Cod_lactosa_pref"].ToString());
                  }
                  else
                  {
                      Fila2["_Cod_lactosa"] = Convert.ToInt32(fil["_Cod_lactosa"].ToString());
                  }

                string v_dulzor=fil["_No_dulzor"].ToString();
                if (v_dulzor == "S")
                {
                    Fila2["_Cod_dulzor"] = Convert.ToInt32(fil["_Cod_dulzor_pref"].ToString());
                }
                else
                {
                    Fila2["_Cod_dulzor"] = Convert.ToInt32(fil["_Cod_dulzor"].ToString());
                }
            
                 string v_sal=fil["_No_sal"].ToString();
                 if (v_sal == "S")
                 {
                     Fila2["_Cod_tipo_sales"] = Convert.ToInt32(fil["_Cod_sales_pref"].ToString());
                 }
                 else
                 {
                     Fila2["_Cod_tipo_sales"] = Convert.ToInt32(fil["_Cod_tipo_sales"].ToString());
                 }


             



                Fila2["_Cod_tipo_temperatura"] = Convert.ToInt32(fil["_Cod_tipo_temperatura"].ToString());
                Fila2["_Cod_tipo_volumen"] = Convert.ToInt32(fil["_Cod_tipo_volumen"].ToString());
                Fila2["_Observacion"] = "";
                Fila2["_Mixto"] = "N";



                dt_ext2.Rows.Add(Fila2);

            }

            dt_ext2.AcceptChanges();
            return dt_ext2;
        }

        protected int Validar_repet(DataTable dt_2, int cod)
        {
            int cont = 0;
            foreach (DataRow fila in dt_2.Select(" _Cod_tipo_alimento= " + cod))
            {
                cont++;
            }

            return cont;
        }

        protected DataTable borrar(DataTable dt_2)
        {
            int cont = 0;
            foreach (DataRow fila in dt_2.Select(" _Cod_tipo_alimento= " + 0))
            {
                fila.Delete();
            }
            dt_2.AcceptChanges();

            return dt_2;
        }

        protected DataTable Cambio_estado_alimento(DataTable dt_2, int cod)
        {

            foreach (DataRow fila in dt_2.Select(" _Cod_tipo_alimento= " + cod))
            {
                string estado = fila["_Vigencia"].ToString();

                if (estado == "N")
                {
                    fila["_Vigencia"] = "S";
                }
            }

            return dt_2;
        }

        protected void Ingresar_alimentos_extras_existente()
        {


            string nom_distribucion = Session["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
            int cod_dis = Convert.ToInt32(Session["_Cod_Distribucion"].ToString());
            int cod_tipo = Convert.ToInt32(Session["_Cod_tipo_comida"].ToString());
            int cod_tipo_ali = cod_alimentoaux;
            dtextras_2 = (DataTable)Session["tbl_extras_2"];
            dtextra = (DataTable)Session["tbl_alimentos_extra"];

            int cont = 0;
            int cont2 = 0;
            switch (cod_dis)
            {
                case 1:


                    dtalimentos_sopa = (DataTable)Session["tbl_alimentos_sopa"];
                    dtalimentos_sopa = limpiar_dt_grilla(dtalimentos_sopa, 1);

                    cont = Validar_repet(dtalimentos_sopa, cod_tipo_ali);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_sopa = Agregar_extras_grilla(dtextra, dtalimentos_sopa, cod_tipo, 0, cod_tipo_ali, "EX");
                        Session["tbl_alimentos_sopa"] = dtalimentos_sopa;
                        grilla_sopa.DataSource = new DataView(dtalimentos_sopa, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_sopa.DataBind();
                        // agregado  dt extra  el alimento seleccionado 

                        cont2 = Validar_repet(dtextras_2, cod_tipo_ali);
                        if (cont2 == 0)
                        {
                            Session["tbl_extras_2"] = Agregar_dt_extras(dtextra, dtextras_2, cod_tipo, cod_tipo_ali);
                        }
                    }
                    else
                    {
                        dtalimentos_sopa = (DataTable)Session["tbl_alimentos_sopa"];
                        foreach (DataRow fila in dtalimentos_sopa.Select(" _Cod_tipo_alimento= " + cod_tipo_ali))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_sopa.AcceptChanges();
                                grilla_sopa.DataSource = new DataView(dtalimentos_sopa, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_sopa"] = dtalimentos_sopa;
                                grilla_sopa.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
                            }
                        }
                    }



                    break;
                case 2:

                    dtalimentos_ensaladas = (DataTable)Session["tbl_alimentos_ensaladas"];
                    dtalimentos_ensaladas = limpiar_dt_grilla(dtalimentos_ensaladas, 2);

                    cont = Validar_repet(dtalimentos_ensaladas, cod_tipo_ali);

                    if (cont == 0)
                    {
                        dtalimentos_ensaladas = Agregar_extras_grilla(dtextra, dtalimentos_ensaladas, cod_tipo, 0, cod_tipo_ali, "EX");
                        Session["tbl_alimentos_ensaladas"] = dtalimentos_ensaladas;
                        grilla_ensalada.DataSource = new DataView(dtalimentos_ensaladas, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_ensalada.DataBind();

                        cont2 = Validar_repet(dtextras_2, cod_tipo_ali);
                        if (cont2 == 0)
                        {
                            Session["tbl_extras_2"] = Agregar_dt_extras(dtextra, dtextras_2, cod_tipo, cod_tipo_ali);
                        }
                    }
                    else
                    {
                        dtalimentos_ensaladas = (DataTable)Session["tbl_alimentos_ensaladas"];
                        foreach (DataRow fila in dtalimentos_ensaladas.Select(" _Cod_tipo_alimento= " + cod_tipo_ali))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_ensaladas.AcceptChanges();
                                grilla_ensalada.DataSource = new DataView(dtalimentos_ensaladas, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_ensaladas"] = dtalimentos_ensaladas;
                                grilla_ensalada.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
                            }
                        }

                    }




                    break;
                case 3:

                    dtalimentos_plato_fondo = (DataTable)Session["tbl_alimentos_plato_fondo"];
                    // limpio  dt
                    dtalimentos_plato_fondo = limpiar_dt_grilla(dtalimentos_plato_fondo, 3);

                    cont = Validar_repet(dtalimentos_plato_fondo, cod_tipo_ali);

                    if (cont == 0)
                    {
                        dtalimentos_plato_fondo = Agregar_extras_grilla(dtextra, dtalimentos_plato_fondo, cod_tipo, 0, cod_tipo_ali, "EX");
                        Session["tbl_alimentos_plato_fondo"] = dtalimentos_plato_fondo;
                        grilla_plato_fondo.DataSource = new DataView(dtalimentos_plato_fondo, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_plato_fondo.DataBind();

                        cont2 = Validar_repet(dtextras_2, cod_tipo_ali);
                        if (cont2 == 0)
                        {
                            Session["tbl_extras_2"] = Agregar_dt_extras(dtextra, dtextras_2, cod_tipo, cod_tipo_ali);
                        }
                    }

                    else
                    {
                        dtalimentos_plato_fondo = (DataTable)Session["tbl_alimentos_plato_fondo"];
                        foreach (DataRow fila in dtalimentos_plato_fondo.Select(" _Cod_tipo_alimento= " + cod_tipo_ali))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_plato_fondo.AcceptChanges();
                                grilla_plato_fondo.DataSource = new DataView(dtalimentos_plato_fondo, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_plato_fondo"] = dtalimentos_plato_fondo;
                                grilla_plato_fondo.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
                            }
                        }


                    }


                    break;
                case 4:

                    dtalimentos_acompañamiento = (DataTable)Session["tbl_alimentos_acompañamiento"];
                    // limpio  dt
                    dtalimentos_acompañamiento = limpiar_dt_grilla(dtalimentos_acompañamiento, 4);


                    cont = Validar_repet(dtalimentos_acompañamiento, cod_tipo_ali);

                    if (cont == 0)
                    {
                        dtalimentos_acompañamiento = Agregar_extras_grilla(dtextra, dtalimentos_acompañamiento, cod_tipo, 0, cod_tipo_ali, "EX");
                        Session["tbl_alimentos_acompañamiento"] = dtalimentos_acompañamiento;
                        grilla_acompañamiento.DataSource = new DataView(dtalimentos_acompañamiento, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_acompañamiento.DataBind();

                        cont2 = Validar_repet(dtextras_2, cod_tipo_ali);
                        if (cont2 == 0)
                        {
                            Session["tbl_extras_2"] = Agregar_dt_extras(dtextra, dtextras_2, cod_tipo, cod_tipo_ali);
                        }
                    }

                    else
                    {
                        dtalimentos_acompañamiento = (DataTable)Session["tbl_alimentos_acompañamiento"];
                        foreach (DataRow fila in dtalimentos_agregado.Select(" _Cod_tipo_alimento= " + cod_tipo_ali))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_acompañamiento.AcceptChanges();
                                grilla_acompañamiento.DataSource = new DataView(dtalimentos_acompañamiento, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_acompañamiento"] = dtalimentos_acompañamiento;
                                grilla_acompañamiento.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
                            }
                        }


                    }



                    break;
                case 5:

                    dtalimentos_postre = (DataTable)Session["tbl_alimentos_postre"];
                    // limpio  dt
                    dtalimentos_postre = limpiar_dt_grilla(dtalimentos_postre, 5);


                    cont = Validar_repet(dtalimentos_postre, cod_tipo_ali);

                    if (cont == 0)
                    {
                        dtalimentos_postre = Agregar_extras_grilla(dtextra, dtalimentos_postre, cod_tipo, 0, cod_tipo_ali, "EX");
                        Session["tbl_alimentos_postre"] = dtalimentos_postre;
                        grilla_postre.DataSource = new DataView(dtalimentos_postre, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_postre.DataBind();

                        cont2 = Validar_repet(dtextras_2, cod_tipo_ali);
                        if (cont2 == 0)
                        {
                            Session["tbl_extras_2"] = Agregar_dt_extras(dtextra, dtextras_2, cod_tipo, cod_tipo_ali);
                        }
                    }

                    else
                    {
                        dtalimentos_postre = (DataTable)Session["tbl_alimentos_postre"];
                        foreach (DataRow fila in dtalimentos_postre.Select(" _Cod_tipo_alimento= " + cod_tipo_ali))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_postre.AcceptChanges();
                                grilla_postre.DataSource = new DataView(dtalimentos_postre, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_postre"] = dtalimentos_postre;
                                grilla_postre.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
                            }
                        }


                    }

                    break;
                case 7:

                    dtalimentos_liquido = (DataTable)Session["tbl_alimentos_liquido"];
                    // limpio  dt
                    dtalimentos_liquido = limpiar_dt_grilla(dtalimentos_liquido, 7);

                    cont = Validar_repet(dtalimentos_liquido, cod_tipo_ali);

                    if (cont == 0)
                    {
                        dtalimentos_liquido = Agregar_extras_grilla(dtextra, dtalimentos_liquido, cod_tipo, 0, cod_tipo_ali, "EX");
                        Session["tbl_alimentos_liquido"] = dtalimentos_liquido;
                        grilla_liquido.DataSource = new DataView(dtalimentos_liquido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_liquido.DataBind();

                        cont2 = Validar_repet(dtextras_2, cod_tipo_ali);
                        if (cont2 == 0)
                        {
                            Session["tbl_extras_2"] = Agregar_dt_extras(dtextra, dtextras_2, cod_tipo, cod_tipo_ali);
                        }
                    }


                    else
                    {
                        foreach (DataRow fila in dtalimentos_liquido.Select(" _Cod_tipo_alimento= " + cod_tipo_ali))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_liquido.AcceptChanges();
                                grilla_liquido.DataSource = new DataView(dtalimentos_liquido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_liquido"] = dtalimentos_liquido;
                                grilla_liquido.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
                            }
                        }

                    }



                    break;
                case 8:

                    dtalimentos_solido = (DataTable)Session["tbl_alimentos_solido"];
                    // limpio  dt
                    dtalimentos_solido = limpiar_dt_grilla(dtalimentos_solido, 8);


                    cont = Validar_repet(dtalimentos_solido, cod_tipo_ali);

                    if (cont == 0)
                    {
                        dtalimentos_solido = Agregar_extras_grilla(dtextra, dtalimentos_solido, cod_tipo, 0, cod_tipo_ali, "EX");
                        Session["tbl_alimentos_solido"] = dtalimentos_solido;
                        grilla_solido.DataSource = new DataView(dtalimentos_solido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_solido.DataBind();

                        cont2 = Validar_repet(dtextras_2, cod_tipo_ali);
                        if (cont2 == 0)
                        {
                            Session["tbl_extras_2"] = Agregar_dt_extras(dtextra, dtextras_2, cod_tipo, cod_tipo_ali);
                        }
                    }


                    else
                    {
                        foreach (DataRow fila in dtalimentos_solido.Select(" _Cod_tipo_alimento= " + cod_tipo_ali))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_solido.AcceptChanges();
                                grilla_solido.DataSource = new DataView(dtalimentos_solido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_solido"] = dtalimentos_solido;
                                grilla_solido.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
                            }
                        }


                    }


                    break;

                case 9:

                    dtalimentos_agregado = (DataTable)Session["tbl_alimentos_agregado"];
                    // limpio  dt
                    dtalimentos_agregado = limpiar_dt_grilla(dtalimentos_agregado, 9);


                    cont = Validar_repet(dtalimentos_agregado, cod_tipo_ali);

                    if (cont == 0)
                    {
                        dtalimentos_agregado = Agregar_extras_grilla(dtextra, dtalimentos_agregado, cod_tipo, 0, cod_tipo_ali, "EX");
                        Session["tbl_alimentos_agregado"] = dtalimentos_agregado;
                        grilla_agregado.DataSource = new DataView(dtalimentos_agregado, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_agregado.DataBind();

                        cont2 = Validar_repet(dtextras_2, cod_tipo_ali);
                        if (cont2 == 0)
                        {
                            Session["tbl_extras_2"] = Agregar_dt_extras(dtextra, dtextras_2, cod_tipo, cod_tipo_ali);
                        }
                    }

                    else
                    {
                        foreach (DataRow fila in dtalimentos_agregado.Select(" _Cod_tipo_alimento= " + cod_tipo_ali))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_agregado.AcceptChanges();
                                grilla_agregado.DataSource = new DataView(dtalimentos_agregado, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_agregado"] = dtalimentos_agregado;
                                grilla_agregado.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
                            }
                        }

                    }


                    break;


                case 10:

                    dtalimentos_hidricos = (DataTable)Session["tbl_alimentos_hidricos"];
                    // limpio  dt
                    dtalimentos_hidricos = limpiar_dt_grilla(dtalimentos_hidricos, 10);


                    cont = Validar_repet(dtalimentos_hidricos, cod_tipo_ali);

                    if (cont == 0)
                    {
                        dtalimentos_hidricos = Agregar_extras_grilla(dtextra, dtalimentos_hidricos, cod_tipo, 0, cod_tipo_ali, "EX");
                        Session["tbl_alimentos_hidricos"] = dtalimentos_hidricos;
                        grilla_hidrico.DataSource = new DataView(dtalimentos_hidricos, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_hidrico.DataBind();

                        cont2 = Validar_repet(dtextras_2, cod_tipo_ali);
                        if (cont2 == 0)
                        {
                            Session["tbl_extras_2"] = Agregar_dt_extras(dtextra, dtextras_2, cod_tipo, cod_tipo_ali);
                        }
                    }

                    else
                    {
                        foreach (DataRow fila in dtalimentos_hidricos.Select(" _Cod_tipo_alimento= " + cod_tipo_ali))
                        {
                            if (fila["_Cod_tipo_distribucion"].ToString() == "N")
                            {
                                fila["_Cod_tipo_distribucion"] = "S";
                                dtalimentos_hidricos.AcceptChanges();
                                grilla_hidrico.DataSource = new DataView(dtalimentos_hidricos, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_hidricos"] = dtalimentos_hidricos;
                                grilla_hidrico.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }


                    }



                    break;



                default:
                    Console.WriteLine("Default case");
                    break;
            }

            //   ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { cerrar_pop(); });", true);

        }

        protected void Ingresar_alimentos_no_existente(int cod, string nom_alimento)
        {
            int cod_ali = cod;

            string nom_distribucion = Session["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
            int cod_dis = Convert.ToInt32(Session["_Cod_Distribucion"].ToString());
            int cod_tipo = Convert.ToInt32(Session["_Cod_tipo_comida"].ToString());
            dtsuper_especial = (DataTable)Session["tbl_super_especial"];
            dtespecial = (DataTable)Session["tbl_alimentos_especiales"];

            int cont = 0;
            int cont2 = 0;
            switch (cod_dis)
            {
                case 1:
                    dtalimentos_sopa = (DataTable)Session["tbl_alimentos_sopa"];
                    dtalimentos_sopa = limpiar_dt_grilla(dtalimentos_sopa, 1);


                    cont = Validar_repet(dtalimentos_sopa, cod_ali);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_sopa = Agregar_especial_grilla(dtalimentos_sopa, cod_tipo, cod_dis, cod_ali, grilla_sopa, "ES", nom_alimento, nom_distribucion);
                        Session["tbl_alimentos_sopa"] = dtalimentos_sopa;
                        grilla_sopa.DataSource = new DataView(dtalimentos_sopa, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_sopa.DataBind();
                    }


                    else
                    {
                        dtalimentos_sopa = (DataTable)Session["tbl_alimentos_sopa"];
                        foreach (DataRow fila in dtalimentos_sopa.Select(" _Cod_tipo_alimento= " + cod_ali))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_sopa.AcceptChanges();
                                grilla_sopa.DataSource = new DataView(dtalimentos_sopa, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_sopa"] = dtalimentos_sopa;
                                grilla_sopa.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
                            }
                        }

                    }




                    break;
                case 2:

                    dtalimentos_ensaladas = (DataTable)Session["tbl_alimentos_ensaladas"];
                    dtalimentos_ensaladas = limpiar_dt_grilla(dtalimentos_ensaladas, 2);

                    cont = Validar_repet(dtalimentos_ensaladas, cod_ali);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_ensaladas = Agregar_especial_grilla(dtalimentos_ensaladas, cod_tipo, cod_dis, cod_ali, grilla_ensalada, "ES", nom_alimento, nom_distribucion);
                        Session["tbl_alimentos_ensaladas"] = dtalimentos_ensaladas;
                        grilla_ensalada.DataSource = new DataView(dtalimentos_ensaladas, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_ensalada.DataBind();
                    }
                    else
                    {
                        foreach (DataRow fila in dtalimentos_ensaladas.Select(" _Cod_tipo_alimento= " + cod_ali))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_ensaladas.AcceptChanges();
                                grilla_ensalada.DataSource = new DataView(dtalimentos_ensaladas, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_ensaladas"] = dtalimentos_ensaladas;
                                grilla_ensalada.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }

                    }


                    break;
                case 3:

                    dtalimentos_plato_fondo = (DataTable)Session["tbl_alimentos_plato_fondo"];
                    dtalimentos_plato_fondo = limpiar_dt_grilla(dtalimentos_plato_fondo, 3);

                    cont = Validar_repet(dtalimentos_plato_fondo, cod_ali);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_plato_fondo = Agregar_especial_grilla(dtalimentos_plato_fondo, cod_tipo, cod_dis, cod_ali, grilla_plato_fondo, "ES", nom_alimento, nom_distribucion);
                        Session["tbl_alimentos_plato_fondo"] = dtalimentos_plato_fondo;
                        grilla_plato_fondo.DataSource = new DataView(dtalimentos_plato_fondo, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_plato_fondo.DataBind();
                    }
                    else
                    {
                        foreach (DataRow fila in dtalimentos_plato_fondo.Select(" _Cod_tipo_alimento= " + cod_ali))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_plato_fondo.AcceptChanges();
                                grilla_plato_fondo.DataSource = new DataView(dtalimentos_plato_fondo, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_plato_fondo"] = dtalimentos_plato_fondo;
                                grilla_plato_fondo.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }

                    }




                    break;
                case 4:

                    dtalimentos_acompañamiento = (DataTable)Session["tbl_alimentos_acompañamiento"];
                    dtalimentos_acompañamiento = limpiar_dt_grilla(dtalimentos_acompañamiento, 4);

                    cont = Validar_repet(dtalimentos_acompañamiento, cod_ali);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_acompañamiento = Agregar_especial_grilla(dtalimentos_acompañamiento, cod_tipo, cod_dis, cod_ali, grilla_acompañamiento, "ES", nom_alimento, nom_distribucion);
                        Session["tbl_alimentos_acompañamiento"] = dtalimentos_acompañamiento;
                        grilla_acompañamiento.DataSource = new DataView(dtalimentos_acompañamiento, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_acompañamiento.DataBind();
                    }
                    else
                    {
                        foreach (DataRow fila in dtalimentos_acompañamiento.Select(" _Cod_tipo_alimento= " + cod_ali))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_acompañamiento.AcceptChanges();
                                grilla_acompañamiento.DataSource = new DataView(dtalimentos_acompañamiento, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_acompañamiento"] = dtalimentos_acompañamiento;
                                grilla_acompañamiento.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }

                    }




                    break;
                case 5:

                    dtalimentos_postre = (DataTable)Session["tbl_alimentos_postre"];
                    dtalimentos_postre = limpiar_dt_grilla(dtalimentos_postre, 5);

                    cont = Validar_repet(dtalimentos_postre, cod_ali);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_postre = Agregar_especial_grilla(dtalimentos_postre, cod_tipo, cod_dis, cod_ali, grilla_postre, "ES", nom_alimento, nom_distribucion);
                        Session["tbl_alimentos_postre"] = dtalimentos_postre;
                        grilla_postre.DataSource = new DataView(dtalimentos_postre, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_postre.DataBind();
                    }


                    else
                    {
                        foreach (DataRow fila in dtalimentos_postre.Select(" _Cod_tipo_alimento= " + cod_ali))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_postre.AcceptChanges();
                                grilla_postre.DataSource = new DataView(dtalimentos_postre, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_postre"] = dtalimentos_postre;
                                grilla_postre.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }

                    }



                    break;
                case 7:

                    dtalimentos_liquido = (DataTable)Session["tbl_alimentos_liquido"];
                    dtalimentos_liquido = limpiar_dt_grilla(dtalimentos_liquido, 7);

                    cont = Validar_repet(dtalimentos_liquido, cod_ali);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_liquido = Agregar_especial_grilla(dtalimentos_liquido, cod_tipo, cod_dis, cod_ali, grilla_liquido, "ES", nom_alimento, nom_distribucion);
                        dtalimentos_liquido.AcceptChanges();
                        Session["tbl_alimentos_liquido"] = dtalimentos_liquido;
                        grilla_liquido.DataSource = new DataView(dtalimentos_liquido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_liquido.DataBind();
                    }


                    else
                    {
                        foreach (DataRow fila in dtalimentos_liquido.Select(" _Cod_tipo_alimento= " + cod_ali))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_liquido.AcceptChanges();
                                grilla_liquido.DataSource = new DataView(dtalimentos_liquido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_liquido"] = dtalimentos_liquido;
                                grilla_liquido.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }
                    }


                    break;
                case 8:

                    dtalimentos_solido = (DataTable)Session["tbl_alimentos_solido"];
                    dtalimentos_solido = limpiar_dt_grilla(dtalimentos_solido, 8);

                    cont = Validar_repet(dtalimentos_solido, cod_ali);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_solido = Agregar_especial_grilla(dtalimentos_solido, cod_tipo, cod_dis, cod_ali, grilla_solido, "ES", nom_alimento, nom_distribucion);
                        Session["tbl_alimentos_solido"] = dtalimentos_solido;
                        grilla_solido.DataSource = new DataView(dtalimentos_solido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_solido.DataBind();
                    }

                    else
                    {
                        foreach (DataRow fila in dtalimentos_solido.Select(" _Cod_tipo_alimento= " + cod_ali))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_solido.AcceptChanges();
                                grilla_solido.DataSource = new DataView(dtalimentos_solido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_solido"] = dtalimentos_solido;
                                grilla_solido.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }

                    }



                    break;

                case 9:

                    dtalimentos_agregado = (DataTable)Session["tbl_alimentos_agregado"];
                    dtalimentos_agregado = limpiar_dt_grilla(dtalimentos_agregado, 9);

                    cont = Validar_repet(dtalimentos_agregado, cod_ali);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_agregado = Agregar_especial_grilla(dtalimentos_agregado, cod_tipo, cod_dis, cod_ali, grilla_agregado, "ES", nom_alimento, nom_distribucion);
                        Session["tbl_alimentos_agregado"] = dtalimentos_agregado;
                        grilla_agregado.DataSource = new DataView(dtalimentos_agregado, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_agregado.DataBind();
                    }


                    else
                    {
                        foreach (DataRow fila in dtalimentos_agregado.Select(" _Cod_tipo_alimento= " + cod_ali))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_agregado.AcceptChanges();
                                grilla_agregado.DataSource = new DataView(dtalimentos_agregado, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_agregado"] = dtalimentos_agregado;
                                grilla_agregado.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }

                    }



                    break;


                case 10:

                    dtalimentos_hidricos = (DataTable)Session["tbl_alimentos_hidricos"];
                    dtalimentos_hidricos = limpiar_dt_grilla(dtalimentos_hidricos, 10);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_hidricos = Agregar_especial_grilla(dtalimentos_hidricos, cod_tipo, cod_dis, cod_ali, grilla_hidrico, "ES", nom_alimento, nom_distribucion);
                        Session["tbl_alimentos_hidricos"] = dtalimentos_hidricos;
                        grilla_hidrico.DataSource = new DataView(dtalimentos_hidricos, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_hidrico.DataBind();
                    }


                    else
                    {
                        foreach (DataRow fila in dtalimentos_hidricos.Select(" _Cod_tipo_alimento= " + cod_ali))
                        {
                            if (fila["_Vigencia"].ToString() == "N")
                            {
                                fila["_Vigencia"] = "S";
                                dtalimentos_hidricos.AcceptChanges();
                                grilla_hidrico.DataSource = new DataView(dtalimentos_hidricos, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                                Session["tbl_alimentos_hidricos"] = dtalimentos_hidricos;
                                grilla_hidrico.DataBind();

                            }
                            else
                            {
                                txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                            }
                        }


                    }

                    break;



                default:
                    Console.WriteLine("Default case");
                    break;
            }



        }

        protected void Ingresar_alimentos_existente()
        {


            string nom_distribucion = Session["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
            int cod_dis = Convert.ToInt32(Session["_Cod_Distribucion"].ToString());
            int cod_tipo = Convert.ToInt32(Session["_Cod_tipo_comida"].ToString());
            Cargar_grilla_especial();
            dt_componentes = (DataTable)Session["dt_componentes"];

            int cont = 0;
            int cont2 = 0;
            switch (cod_dis)
            {
                case 1:
                    dtalimentos_sopa = (DataTable)Session["tbl_alimentos_sopa"];

                    dtalimentos_sopa = limpiar_dt_grilla(dtalimentos_sopa, 1);

                    cont = Validar_repet(dtalimentos_sopa, cod_alimentoaux);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_sopa = Agregar_extras_grilla(dt_componentes, dtalimentos_sopa, cod_tipo, 0, cod_alimentoaux, "ES");
                        Session["tbl_alimentos_sopa"] = dtalimentos_sopa;
                        grilla_sopa.DataSource = new DataView(dtalimentos_sopa, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_sopa.DataBind();
                    }

                    else
                    {
                        txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                        Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                    }




                    break;
                case 2:

                    dtalimentos_ensaladas = (DataTable)Session["tbl_alimentos_ensaladas"];


                    dtalimentos_ensaladas = limpiar_dt_grilla(dtalimentos_ensaladas, 1);

                    cont = Validar_repet(dtalimentos_ensaladas, cod_alimentoaux);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_ensaladas = Agregar_extras_grilla(dt_componentes, dtalimentos_ensaladas, cod_tipo, 0, cod_alimentoaux, "ES");
                        Session["tbl_alimentos_ensaladas"] = dtalimentos_ensaladas;
                        grilla_ensalada.DataSource = new DataView(dtalimentos_ensaladas, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_ensalada.DataBind();
                    }

                    else
                    {
                        txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                        Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                    }




                    break;
                case 3:

                    dtalimentos_plato_fondo = (DataTable)Session["tbl_alimentos_plato_fondo"];
                    dtalimentos_plato_fondo = limpiar_dt_grilla(dtalimentos_plato_fondo, 3);

                    cont = Validar_repet(dtalimentos_plato_fondo, cod_alimentoaux);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_plato_fondo = Agregar_extras_grilla(dt_componentes, dtalimentos_plato_fondo, cod_tipo, 0, cod_alimentoaux, "ES");
                        Session["tbl_alimentos_plato_fondo"] = dtalimentos_plato_fondo;
                        grilla_plato_fondo.DataSource = new DataView(dtalimentos_plato_fondo, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_plato_fondo.DataBind();
                    }
                    else
                    {
                        txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                        Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                    }


                    break;
                case 4:

                    dtalimentos_acompañamiento = (DataTable)Session["tbl_alimentos_acompañamiento"];
                    dtalimentos_acompañamiento = limpiar_dt_grilla(dtalimentos_acompañamiento, 4);

                    cont = Validar_repet(dtalimentos_acompañamiento, cod_alimentoaux);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_acompañamiento = Agregar_extras_grilla(dt_componentes, dtalimentos_acompañamiento, cod_tipo, 0, cod_alimentoaux, "ES");
                        Session["tbl_alimentos_acompañamiento"] = dtalimentos_acompañamiento;
                        grilla_acompañamiento.DataSource = new DataView(dtalimentos_acompañamiento, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_acompañamiento.DataBind();
                    }
                    else
                    {
                        txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                        Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                    }



                    break;
                case 5:

                    dtalimentos_postre = (DataTable)Session["tbl_alimentos_postre"];

                    dtalimentos_postre = limpiar_dt_grilla(dtalimentos_postre, 5);

                    cont = Validar_repet(dtalimentos_postre, cod_alimentoaux);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_postre = Agregar_extras_grilla(dt_componentes, dtalimentos_postre, cod_tipo, 0, cod_alimentoaux, "ES");
                        Session["tbl_alimentos_postre"] = dtalimentos_postre;
                        grilla_postre.DataSource = new DataView(dtalimentos_postre, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_postre.DataBind();
                    }

                    else
                    {
                        txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                        Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                    }

                    break;
                case 7:

                    dtalimentos_liquido = (DataTable)Session["tbl_alimentos_liquido"];


                    dtalimentos_liquido = limpiar_dt_grilla(dtalimentos_liquido, 7);

                    cont = Validar_repet(dtalimentos_liquido, cod_alimentoaux);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_liquido = Agregar_extras_grilla(dt_componentes, dtalimentos_liquido, cod_tipo, 0, cod_alimentoaux, "ES");
                        Session["tbl_alimentos_liquido"] = dtalimentos_liquido;
                        grilla_liquido.DataSource = new DataView(dtalimentos_liquido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_liquido.DataBind();
                    }
                    else
                    {
                        txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                        Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
                    }



                    break;
                case 8:

                    dtalimentos_solido = (DataTable)Session["tbl_alimentos_solido"];
                    dtalimentos_solido = limpiar_dt_grilla(dtalimentos_solido, 8);

                    cont = Validar_repet(dtalimentos_solido, cod_alimentoaux);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_solido = Agregar_extras_grilla(dt_componentes, dtalimentos_solido, cod_tipo, 0, cod_alimentoaux, "ES");
                        Session["tbl_alimentos_solido"] = dtalimentos_solido;
                        grilla_solido.DataSource = new DataView(dtalimentos_solido, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_solido.DataBind();
                    }



                    else
                    {

                        txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                        Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);
                    }


                    break;

                case 9:

                    dtalimentos_agregado = (DataTable)Session["tbl_alimentos_agregado"];

                    dtalimentos_agregado = limpiar_dt_grilla(dtalimentos_agregado, 9);

                    cont = Validar_repet(dtalimentos_agregado, cod_alimentoaux);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_agregado = Agregar_extras_grilla(dt_componentes, dtalimentos_agregado, cod_tipo, 0, cod_alimentoaux, "ES");
                        Session["tbl_alimentos_agregado"] = dtalimentos_agregado;
                        grilla_agregado.DataSource = new DataView(dtalimentos_agregado, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_agregado.DataBind();
                    }


                    else
                    {
                        txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                        Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                    }


                    break;


                case 10:

                    dtalimentos_hidricos = (DataTable)Session["tbl_alimentos_hidricos"];
                    dtalimentos_hidricos = limpiar_dt_grilla(dtalimentos_hidricos, 10);

                    cont = Validar_repet(dtalimentos_hidricos, cod_alimentoaux);

                    if (cont == 0)
                    {
                        //  registro  dt_alimento el alimneto  seleccionado

                        dtalimentos_hidricos = Agregar_extras_grilla(dt_componentes, dtalimentos_hidricos, cod_tipo, 0, cod_alimentoaux, "ES");
                        Session["tbl_alimentos_hidricos"] = dtalimentos_hidricos;
                        grilla_hidrico.DataSource = new DataView(dtalimentos_hidricos, "_Vigencia ='S' ", "_Estado", DataViewRowState.CurrentRows);
                        grilla_hidrico.DataBind();
                    }



                    else
                    {
                        txtmsg.Text = "Estimado usuario, el Alimento ya se encuentra registrado";
                        Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                    }



                    break;



                default:
                    Console.WriteLine("Default case");
                    break;
            }



        }

        protected void guardar_especial_dt()
        {
            string v = DateTime.Now.ToString("dd-MM-yyyy");
            string[] c = v.Split('-');
            string c1 = c[0];
            string c2 = c[1];
            string c3 = c[2];
            string val = c3 + c2 + "00";
            //    Cargar_grilla_especial();
            if (dtespecial_2.Rows.Count < 1)
            {
                int contador = 0;
                int cod_x = 0;

                int codigo_esp = 0;
                int valor_cod = 0;
                int valor = Convert.ToInt32(val);

                Utilidades u = new UtilidadesNE().Extraer_codigo_especial();
                codigo_esp = u._Id;

                foreach (DataRow fila in dtespecial.Rows)
                {
                    cod_x = Convert.ToInt32(fila["_Cod_tipo_alimento"].ToString());
                    contador++;
                }

                if (codigo_esp == 0)
                {
                    valor_cod = valor + codigo_esp + 1;
                }

                else
                {
                    if (contador == 0)
                    {
                        valor_cod = codigo_esp + 1;
                    }
                    else
                    {
                        if (codigo_esp <= cod_x)
                        {
                            valor_cod = cod_x + 1;
                        }
                        else
                        {
                            valor_cod = codigo_esp + contador;
                        }
                    }
                }


                int cod_ali = valor_cod;
                string nom_alimento = nom_alimento_especial_2.ToUpper();

                Ingresar_alimentos_no_existente(cod_ali, nom_alimento);

            }
            else
            {

                Ingresar_alimentos_existente();


            }

            txtmsg.Text = "Estimado usuario, El Alimento sea  Registrado Correctamente";
            Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

            txtespecial.Text = "";
        }

        protected Boolean Validar_alimentos_extra()
        {
            Boolean var = false;
            int cod_dis = Convert.ToInt32(Session["_Cod_Distribucion"].ToString());
            int cod_tipo = Convert.ToInt32(Session["_Cod_tipo_comida"].ToString());
            int cod_ali = Convert.ToInt32(Session["_Cod_tipo_alimento"].ToString());

            switch (cod_dis)
            {
                case 1:

                    dtextra = (DataTable)Session["tbl_alimentos_extra"];
                    foreach (DataRow fila in dtextra.Select(" _Cod_tipo_alimento= " + cod_ali))
                    {
                        var = true;
                    }

                    break;
                case 2:
                    dtextra = (DataTable)Session["tbl_alimentos_extra"];
                    foreach (DataRow fila in dtextra.Select(" _Cod_tipo_alimento= " + cod_ali))
                    {
                        var = true;
                    }

                    break;
                case 3:

                    dtextra = (DataTable)Session["tbl_alimentos_extra"];
                    foreach (DataRow fila in dtextra.Select(" _Cod_tipo_alimento= " + cod_ali))
                    {
                        var = true;
                    }
                    break;
                case 4:

                    dtextra = (DataTable)Session["tbl_alimentos_extra"];
                    foreach (DataRow fila in dtextra.Select(" _Cod_tipo_alimento= " + cod_ali))
                    {
                        var = true;
                    }
                    break;
                case 5:
                    dtextra = (DataTable)Session["tbl_alimentos_extra"];
                    foreach (DataRow fila in dtextra.Select(" _Cod_tipo_alimento= " + cod_ali))
                    {
                        var = true;
                    }

                    break;
                case 7:
                    dtextra = (DataTable)Session["tbl_alimentos_extra"];
                    foreach (DataRow fila in dtextra.Select(" _Cod_tipo_alimento= " + cod_ali))
                    {
                        var = true;
                    }

                    break;
                case 8:
                    dtextra = (DataTable)Session["tbl_alimentos_extra"];
                    foreach (DataRow fila in dtextra.Select(" _Cod_tipo_alimento= " + cod_ali))
                    {
                        var = true;
                    }
                    break;
                case 9:

                    dtextra = (DataTable)Session["tbl_alimentos_extra"];
                    foreach (DataRow fila in dtextra.Select(" _Cod_tipo_alimento= " + cod_ali))
                    {
                        var = true;
                    }

                    break;
                case 10:
                    dtextra = (DataTable)Session["tbl_alimentos_extra"];
                    foreach (DataRow fila in dtextra.Select(" _Cod_tipo_alimento= " + cod_ali))
                    {
                        var = true;
                    }
                    break;


                default:
                    Console.WriteLine("Default case");
                    break;


            }
            return var;

        }

        protected Boolean Validar_alimentos()
        {
            Boolean var = false;
            int cod_dis = Convert.ToInt32(Session["_Cod_Distribucion"].ToString());
            int cod_tipo = Convert.ToInt32(Session["_Cod_tipo_comida"].ToString());
            int cod_ali = Convert.ToInt32(Session["_Cod_tipo_alimento"].ToString());

            switch (cod_dis)
            {
                case 1:

                    dtalimentos_sopa = (DataTable)Session["tbl_alimentos_sopa"];
                    foreach (DataRow fila in dtalimentos_sopa.Select(" _Cod_tipo_alimento= " + cod_ali))
                    {
                        var = true;
                    }

                    break;
                case 2:

                    dtalimentos_ensaladas = (DataTable)Session["tbl_alimentos_ensaladas"];
                    foreach (DataRow fila in dtalimentos_ensaladas.Select(" _Cod_tipo_alimento= " + cod_ali))
                    {
                        var = true;
                    }

                    break;
                case 3:

                    dtalimentos_plato_fondo = (DataTable)Session["tbl_alimentos_plato_fondo"];
                    foreach (DataRow fila in dtalimentos_plato_fondo.Select(" _Cod_tipo_alimento= " + cod_ali))
                    {
                        var = true;
                    }

                    break;
                case 4:
                    dtalimentos_acompañamiento = (DataTable)Session["tbl_alimentos_acompañamiento"];
                    foreach (DataRow fila in dtalimentos_acompañamiento.Select(" _Cod_tipo_alimento= " + cod_ali))
                    {
                        var = true;
                    }


                    break;
                case 5:
                    dtalimentos_postre = (DataTable)Session["tbl_alimentos_postre"];
                    foreach (DataRow fila in dtalimentos_postre.Select(" _Cod_tipo_alimento= " + cod_ali))
                    {
                        var = true;
                    }


                    break;
                case 7:

                    dtalimentos_liquido = (DataTable)Session["tbl_alimentos_liquido"];

                    foreach (DataRow fila in dtalimentos_liquido.Select(" _Cod_tipo_alimento= " + cod_ali))
                    {
                        var = true;
                    }

                    break;
                case 8:

                    dtalimentos_solido = (DataTable)Session["tbl_alimentos_solido"];
                    foreach (DataRow fila in dtalimentos_solido.Select(" _Cod_tipo_alimento= " + cod_ali))
                    {
                        var = true;
                    }
                    break;
                case 9:

                    dtalimentos_agregado = (DataTable)Session["tbl_alimentos_agregado"];
                    foreach (DataRow fila in dtalimentos_agregado.Select(" _Cod_tipo_alimento= " + cod_ali))
                    {
                        var = true;
                    }

                    break;
                case 10:

                    break;


                default:
                    Console.WriteLine("Default case");
                    break;


            }
            return var;

        }

        protected void grabar_grilla()
        {
            int cod_dis = Convert.ToInt32(Session["_Cod_Distribucion"].ToString());
            int cod_tipo = Convert.ToInt32(Session["_Cod_tipo_comida"].ToString());
            int cod_ali = Convert.ToInt32(Session["_Cod_tipo_alimento"].ToString());
            string nom_alimento = Session["_Nom_tipo_alimento"].ToString();
            string nom_distribucion = Session["_Nom_tipo_distribucion"].ToString().Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
            string tipo = Session["Tipo"].ToString();
            switch (cod_dis)
            {
                case 1:

                    dtalimentos_sopa = (DataTable)Session["tbl_alimentos_sopa"];

                    DataRow Fila1 = dtalimentos_sopa.NewRow();
                    Fila1["_Cod_tipo_distribucion"] = cod_dis;
                    Fila1["_Cod_tipo_comida"] = cod_tipo;
                    Fila1["_Id_tipo_alimento"] = cod_ali;
                    Fila1["_Cod_tipo_alimento"] = cod_ali;
                    Fila1["_Nom_tipo_alimento"] = nom_alimento.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila1["_Nom_tipo_distribucion"] = nom_distribucion.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila1["_Vigencia"] = 'S';
                    Fila1["_Cantidad"] = 1;
                    Fila1["_Estado"] = tipo;

                    Fila1["_Cod_tipo_consistencia"] = cod_consistencia;
                    Fila1["_Cod_tipo_digestabilidad"] = cod_digestabilidad;
                    Fila1["_Cod_tipo_sales"] = cod_sal;
                    Fila1["_Cod_tipo_volumen"] = cod_volumen;
                    Fila1["_Cod_tipo_temperatura"] = cod_temperatura;
                    Fila1["_Cod_lactosa"] = cod_lactosa;
                    Fila1["_Cod_dulzor"] = cod_dulzor;
                    Fila1["_Mixto"] = "N";



                    dtalimentos_sopa.Rows.Add(Fila1);
                    dtalimentos_sopa.AcceptChanges();
                    if (dtalimentos_sopa.Rows.Count > 0)
                    {
                        foreach (DataRow rx in dtalimentos_sopa.Rows)
                        {
                            if (Convert.ToInt32(rx["_Cod_tipo_distribucion"].ToString()) != 1)
                            {
                                rx.Delete();
                            }


                        }

                        dtalimentos_sopa.AcceptChanges();
                    }
                    dtalimentos_sopa.AcceptChanges();
                    grilla_sopa.DataSource = new DataView(dtalimentos_sopa, "_Cod_tipo_distribucion=1 and _Vigencia='S'", "_Estado", DataViewRowState.CurrentRows);
                    Session["tbl_alimentos_sopa"] = dtalimentos_sopa;
                    grilla_sopa.DataBind();

                    break;
                case 2:

                    dtalimentos_ensaladas = (DataTable)Session["tbl_alimentos_ensaladas"];


                    DataRow Fila2 = dtalimentos_ensaladas.NewRow();
                    Fila2["_Cod_tipo_distribucion"] = cod_dis;
                    Fila2["_Cod_tipo_comida"] = cod_tipo;
                    Fila2["_Id_tipo_alimento"] = cod_ali;
                    Fila2["_Cod_tipo_alimento"] = cod_ali;
                    Fila2["_Nom_tipo_alimento"] = nom_alimento.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila2["_Nom_tipo_distribucion"] = nom_distribucion.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila2["_Vigencia"] = 'S';
                    Fila2["_Cantidad"] = 1;
                    Fila2["_Estado"] = tipo;

                    Fila2["_Cod_tipo_consistencia"] = cod_consistencia;
                    Fila2["_Cod_tipo_digestabilidad"] = cod_digestabilidad;
                    Fila2["_Cod_tipo_sales"] = cod_sal;
                    Fila2["_Cod_tipo_volumen"] = cod_volumen;
                    Fila2["_Cod_tipo_temperatura"] = cod_temperatura;
                    Fila2["_Cod_lactosa"] = cod_lactosa;
                    Fila2["_Cod_dulzor"] = cod_dulzor;
                    Fila2["_Mixto"] = "N";

                    dtalimentos_ensaladas.Rows.Add(Fila2);
                    dtalimentos_ensaladas.AcceptChanges();
                    if (dtalimentos_ensaladas.Rows.Count > 0)
                    {
                        foreach (DataRow rx in dtalimentos_ensaladas.Rows)
                        {
                            if (Convert.ToInt32(rx["_Cod_tipo_distribucion"].ToString()) != 2)
                            {
                                rx.Delete();
                            }
                        }

                        dtalimentos_ensaladas.AcceptChanges();
                    }
                    dtalimentos_ensaladas.AcceptChanges();
                    grilla_ensalada.DataSource = new DataView(dtalimentos_ensaladas, "_Cod_tipo_distribucion=2 and _Vigencia='S'", "_Estado", DataViewRowState.CurrentRows);
                    Session["tbl_alimentos_ensaladas"] = dtalimentos_ensaladas;
                    grilla_ensalada.DataBind();

                    break;
                case 3:
                    dtalimentos_plato_fondo = (DataTable)Session["tbl_alimentos_plato_fondo"];

                    DataRow Fila3 = dtalimentos_plato_fondo.NewRow();
                    Fila3["_Cod_tipo_distribucion"] = cod_dis;
                    Fila3["_Cod_tipo_comida"] = cod_tipo;
                    Fila3["_Id_tipo_alimento"] = cod_ali;
                    Fila3["_Cod_tipo_alimento"] = cod_ali;
                    Fila3["_Nom_tipo_alimento"] = nom_alimento.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila3["_Nom_tipo_distribucion"] = nom_distribucion.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila3["_Vigencia"] = 'S';
                    Fila3["_Cantidad"] = 1;
                    Fila3["_Estado"] = tipo;


                    Fila3["_Cod_tipo_consistencia"] = cod_consistencia;
                    Fila3["_Cod_tipo_digestabilidad"] = cod_digestabilidad;
                    Fila3["_Cod_tipo_sales"] = cod_sal;
                    Fila3["_Cod_tipo_volumen"] = cod_volumen;
                    Fila3["_Cod_tipo_temperatura"] = cod_temperatura;
                    Fila3["_Cod_lactosa"] = cod_lactosa;
                    Fila3["_Cod_dulzor"] = cod_dulzor;
                    Fila3["_Mixto"] = "N";

                    dtalimentos_plato_fondo.Rows.Add(Fila3);
                    dtalimentos_plato_fondo.AcceptChanges();
                    if (dtalimentos_plato_fondo.Rows.Count > 0)
                    {
                        foreach (DataRow rx in dtalimentos_plato_fondo.Rows)
                        {
                            if (Convert.ToInt32(rx["_Cod_tipo_distribucion"].ToString()) != 3)
                            {
                                rx.Delete();
                            }
                        }

                        dtalimentos_plato_fondo.AcceptChanges();
                    }
                    dtalimentos_plato_fondo.AcceptChanges();
                    grilla_plato_fondo.DataSource = new DataView(dtalimentos_plato_fondo, "_Cod_tipo_distribucion=3 and _Vigencia='S'", "_Estado", DataViewRowState.CurrentRows);
                    Session["tbl_alimentos_plato_fondo"] = dtalimentos_plato_fondo;
                    grilla_plato_fondo.DataBind();

                    break;
                case 4:
                    dtalimentos_acompañamiento = (DataTable)Session["tbl_alimentos_acompañamiento"];

                    DataRow Fila4 = dtalimentos_acompañamiento.NewRow();
                    Fila4["_Cod_tipo_distribucion"] = cod_dis;
                    Fila4["_Cod_tipo_comida"] = cod_tipo;
                    Fila4["_Id_tipo_alimento"] = cod_ali;
                    Fila4["_Cod_tipo_alimento"] = cod_ali;
                    Fila4["_Nom_tipo_alimento"] = nom_alimento.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila4["_Nom_tipo_distribucion"] = nom_distribucion.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila4["_Vigencia"] = 'S';
                    Fila4["_Cantidad"] = 1;
                    Fila4["_Estado"] = tipo;

                    Fila4["_Cod_tipo_consistencia"] = cod_consistencia;
                    Fila4["_Cod_tipo_digestabilidad"] = cod_digestabilidad;
                    Fila4["_Cod_tipo_sales"] = cod_sal;
                    Fila4["_Cod_tipo_volumen"] = cod_volumen;
                    Fila4["_Cod_tipo_temperatura"] = cod_temperatura;
                    Fila4["_Cod_lactosa"] = cod_lactosa;
                    Fila4["_Cod_dulzor"] = cod_dulzor;
                    Fila4["_Mixto"] = "N";

                    dtalimentos_acompañamiento.Rows.Add(Fila4);
                    dtalimentos_acompañamiento.AcceptChanges();
                    if (dtalimentos_acompañamiento.Rows.Count > 0)
                    {
                        foreach (DataRow rx in dtalimentos_acompañamiento.Rows)
                        {
                            if (Convert.ToInt32(rx["_Cod_tipo_distribucion"].ToString()) != 4)
                            {
                                rx.Delete();
                            }

                        }

                        dtalimentos_acompañamiento.AcceptChanges();
                    }
                    dtalimentos_acompañamiento.AcceptChanges();
                    grilla_acompañamiento.DataSource = new DataView(dtalimentos_acompañamiento, "_Cod_tipo_distribucion=4 and _Vigencia='S'", "_Estado", DataViewRowState.CurrentRows);
                    Session["tbl_alimentos_acompañamiento"] = dtalimentos_acompañamiento;
                    grilla_acompañamiento.DataBind();
                    break;
                case 5:

                    dtalimentos_postre = (DataTable)Session["tbl_alimentos_postre"];

                    DataRow Fila5 = dtalimentos_postre.NewRow();
                    Fila5["_Cod_tipo_distribucion"] = cod_dis;
                    Fila5["_Cod_tipo_comida"] = cod_tipo;
                    Fila5["_Id_tipo_alimento"] = cod_ali;
                    Fila5["_Cod_tipo_alimento"] = cod_ali;
                    Fila5["_Nom_tipo_alimento"] = nom_alimento.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila5["_Nom_tipo_distribucion"] = nom_distribucion.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila5["_Vigencia"] = 'S';
                    Fila5["_Cantidad"] = 1;
                    Fila5["_Estado"] = tipo;

                    Fila5["_Cod_tipo_consistencia"] = cod_consistencia;
                    Fila5["_Cod_tipo_digestabilidad"] = cod_digestabilidad;
                    Fila5["_Cod_tipo_sales"] = cod_sal;
                    Fila5["_Cod_tipo_volumen"] = cod_volumen;
                    Fila5["_Cod_tipo_temperatura"] = cod_temperatura;
                    Fila5["_Cod_lactosa"] = cod_lactosa;
                    Fila5["_Cod_dulzor"] = cod_dulzor;
                    Fila5["_Mixto"] = "N";

                    dtalimentos_postre.Rows.Add(Fila5);
                    dtalimentos_postre.AcceptChanges();
                    if (dtalimentos_postre.Rows.Count > 0)
                    {
                        foreach (DataRow rx in dtalimentos_postre.Rows)
                        {
                            if (Convert.ToInt32(rx["_Cod_tipo_distribucion"].ToString()) != 5)
                            {
                                rx.Delete();
                            }
                        }

                        dtalimentos_postre.AcceptChanges();
                    }
                    dtalimentos_postre.AcceptChanges();
                    grilla_postre.DataSource = new DataView(dtalimentos_postre, "_Cod_tipo_distribucion=5 and _Vigencia='S'", "_Estado", DataViewRowState.CurrentRows);
                    Session["tbl_alimentos_liquido"] = dtalimentos_postre;
                    grilla_postre.DataBind();

                    break;
                case 7:
                    dtalimentos_liquido = (DataTable)Session["tbl_alimentos_liquido"];

                    DataRow Fila7 = dtalimentos_liquido.NewRow();
                    Fila7["_Cod_tipo_distribucion"] = cod_dis;
                    Fila7["_Id_tipo_alimento"] = cod_ali;
                    Fila7["_Cod_tipo_comida"] = cod_tipo;
                    Fila7["_Cod_tipo_alimento"] = cod_ali;
                    Fila7["_Nom_tipo_alimento"] = nom_alimento.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila7["_Nom_tipo_distribucion"] = nom_distribucion.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila7["_Vigencia"] = 'S';
                    Fila7["_Cantidad"] = 1;
                    Fila7["_Estado"] = tipo;

                    Fila7["_Cod_tipo_consistencia"] = cod_consistencia;
                    Fila7["_Cod_tipo_digestabilidad"] = cod_digestabilidad;
                    Fila7["_Cod_tipo_sales"] = cod_sal;
                    Fila7["_Cod_tipo_volumen"] = cod_volumen;
                    Fila7["_Cod_tipo_temperatura"] = cod_temperatura;
                    Fila7["_Cod_lactosa"] = cod_lactosa;
                    Fila7["_Cod_dulzor"] = cod_dulzor;
                    Fila7["_Mixto"] = "N";

                    dtalimentos_liquido.Rows.Add(Fila7);

                    if (dtalimentos_liquido.Rows.Count > 0)
                    {
                        foreach (DataRow rx in dtalimentos_liquido.Rows)
                        {
                            if (Convert.ToInt32(rx["_Cod_tipo_distribucion"].ToString()) != 7)
                            {
                                rx.Delete();
                            }

                        }

                        dtalimentos_liquido.AcceptChanges();
                    }
                    dtalimentos_liquido.AcceptChanges();
                    grilla_liquido.DataSource = new DataView(dtalimentos_liquido, "_Cod_tipo_distribucion=7 and _Vigencia='S'", "_Estado", DataViewRowState.CurrentRows);
                    Session["tbl_alimentos_liquido"] = dtalimentos_liquido;
                    grilla_liquido.DataBind();

                    break;
                case 8:
                    dtalimentos_solido = (DataTable)Session["tbl_alimentos_solido"];

                    DataRow Fila8 = dtalimentos_solido.NewRow();
                    Fila8["_Cod_tipo_distribucion"] = cod_dis;
                    Fila8["_Cod_tipo_comida"] = cod_tipo;
                    Fila8["_Id_tipo_alimento"] = cod_ali;
                    Fila8["_Cod_tipo_alimento"] = cod_ali;
                    Fila8["_Nom_tipo_alimento"] = nom_alimento.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila8["_Nom_tipo_distribucion"] = nom_distribucion.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila8["_Vigencia"] = 'S';
                    Fila8["_Cantidad"] = 1;
                    Fila8["_Estado"] = tipo;

                    Fila8["_Cod_tipo_consistencia"] = cod_consistencia;
                    Fila8["_Cod_tipo_digestabilidad"] = cod_digestabilidad;
                    Fila8["_Cod_tipo_sales"] = cod_sal;
                    Fila8["_Cod_tipo_volumen"] = cod_volumen;
                    Fila8["_Cod_tipo_temperatura"] = cod_temperatura;
                    Fila8["_Cod_lactosa"] = cod_lactosa;
                    Fila8["_Cod_dulzor"] = cod_dulzor;
                    Fila8["_Mixto"] = "N";

                    dtalimentos_solido.Rows.Add(Fila8);
                    dtalimentos_solido.AcceptChanges();
                    if (dtalimentos_solido.Rows.Count > 0)
                    {
                        foreach (DataRow rx in dtalimentos_solido.Rows)
                        {
                            if (Convert.ToInt32(rx["_Cod_tipo_distribucion"].ToString()) != 8)
                            {
                                rx.Delete();
                            }
                        }

                        dtalimentos_solido.AcceptChanges();
                    }
                    dtalimentos_solido.AcceptChanges();
                    grilla_solido.DataSource = new DataView(dtalimentos_solido, "_Cod_tipo_distribucion=8 and _Vigencia='S'", "_Estado", DataViewRowState.CurrentRows);
                    Session["tbl_alimentos_solido"] = dtalimentos_solido;
                    grilla_solido.DataBind();

                    break;
                case 9:
                    dtalimentos_agregado = (DataTable)Session["tbl_alimentos_agregado"];

                    DataRow Fila9 = dtalimentos_agregado.NewRow();
                    Fila9["_Cod_tipo_distribucion"] = cod_dis;
                    Fila9["_Cod_tipo_comida"] = cod_tipo;
                    Fila9["_Id_tipo_alimento"] = cod_ali;
                    Fila9["_Cod_tipo_alimento"] = cod_ali;
                    Fila9["_Nom_tipo_alimento"] = nom_alimento.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila9["_Nom_tipo_distribucion"] = nom_distribucion.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila9["_Vigencia"] = 'S';
                    Fila9["_Cantidad"] = 1;
                    Fila9["_Estado"] = tipo;

                    Fila9["_Cod_tipo_consistencia"] = cod_consistencia;
                    Fila9["_Cod_tipo_digestabilidad"] = cod_digestabilidad;
                    Fila9["_Cod_tipo_sales"] = cod_sal;
                    Fila9["_Cod_tipo_volumen"] = cod_volumen;
                    Fila9["_Cod_tipo_temperatura"] = cod_temperatura;
                    Fila9["_Cod_lactosa"] = cod_lactosa;
                    Fila9["_Cod_dulzor"] = cod_dulzor;
                    Fila9["_Mixto"] = "N";

                    dtalimentos_agregado.Rows.Add(Fila9);
                    dtalimentos_agregado.AcceptChanges();
                    if (dtalimentos_agregado.Rows.Count > 0)
                    {
                        foreach (DataRow rx in dtalimentos_agregado.Rows)
                        {
                            if (Convert.ToInt32(rx["_Cod_tipo_distribucion"].ToString()) != 9)
                            {
                                rx.Delete();
                            }
                        }

                        dtalimentos_agregado.AcceptChanges();
                    }
                    dtalimentos_agregado.AcceptChanges();
                    grilla_agregado.DataSource = new DataView(dtalimentos_agregado, "_Cod_tipo_distribucion=9 and _Vigencia='S'", "_Estado", DataViewRowState.CurrentRows);
                    Session["tbl_alimentos_agregado"] = dtalimentos_agregado;
                    grilla_agregado.DataBind();

                    break;
                case 10:


                    DataRow Fila10 = dtalimentos_hidricos.NewRow();

                    Fila10["_Cod_tipo_distribucion"] = cod_dis;
                    Fila10["_Cod_tipo_comida"] = cod_tipo;
                    Fila10["_Id_tipo_alimento"] = cod_ali;
                    Fila10["_Cod_tipo_alimento"] = cod_ali;
                    Fila10["_Nom_tipo_alimento"] = nom_alimento.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila10["_Nom_tipo_distribucion"] = nom_distribucion.Replace("&#209;", "Ñ").Replace("Ñ", "Ñ");
                    Fila10["_Vigencia"] = 'S';
                    Fila10["_Cantidad"] = 1;
                    Fila10["_Estado"] = tipo;

                    Fila10["_Cod_tipo_consistencia"] = cod_consistencia;
                    Fila10["_Cod_tipo_digestabilidad"] = cod_digestabilidad;
                    Fila10["_Cod_tipo_sales"] = cod_sal;
                    Fila10["_Cod_tipo_volumen"] = cod_volumen;
                    Fila10["_Cod_tipo_temperatura"] = cod_temperatura;
                    Fila10["_Cod_lactosa"] = cod_lactosa;
                    Fila10["_Cod_dulzor"] = cod_dulzor;
                    Fila10["_Mixto"] = "N";

                    dtalimentos_hidricos.Rows.Add(Fila10);
                    dtalimentos_hidricos.AcceptChanges();
                    if (dtalimentos_hidricos.Rows.Count > 0)
                    {
                        foreach (DataRow rx in dtalimentos_hidricos.Rows)
                        {
                            if (Convert.ToInt32(rx["_Cod_tipo_distribucion"].ToString()) != 10)
                            {
                                rx.Delete();
                            }
                        }

                        dtalimentos_hidricos.AcceptChanges();
                    }
                    dtalimentos_hidricos.AcceptChanges();
                    grilla_hidrico.DataSource = new DataView(dtalimentos_hidricos, "_Cod_tipo_distribucion=10 and _Vigencia='S'", "_Estado", DataViewRowState.CurrentRows);
                    Session["tbl_alimentos_hidricos"] = dtalimentos_hidricos;
                    grilla_hidrico.DataBind();
                    break;


                default:
                    Console.WriteLine("Default case");
                    break;
            }

        }

        void Cargar_grilla_especial()
        {
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            string descripcion = txtespecial.Text;
            int cod_tipo_distribucion = Convert.ToInt32(Session["_Cod_Distribucion"].ToString());
            List<Utilidades> lista_alimentos_especial = new UtilidadesNE().Cargar_alimentos_menu_extra_extra(cod_distribucion, descripcion);

            dtespecial_2 = ConvertToDataTable(lista_alimentos_especial);
            Session["tbl_alimentos_especiales"] = dtespecial_2;

        }

        void Buscar_extra()
        {
            dtextra = (DataTable)Session["tbl_alimentos_extra"];
            DataView dvSol = dtextra.AsDataView();
            dvSol.RowFilter = "_Nom_tipo_alimento Like '" + txtextra.Text + "%'";

            grilla_extra.DataSource = dvSol;
            grilla_extra.DataBind();
            txtextra.Text = "";

            if (dvSol.Count > 0)
            {

            }

        }

        void Buscar_especial()
        {
            btn_agregar_ali.Visible = true;

            Cargar_grilla_especial();
            if (dtespecial.Rows.Count == 0)
            {
                btn_agregar_ali.Visible = true;

            }
            else
            {

            }

        }


        #endregion

        #region Guardar Pedido

        protected void Guardar_liquido()
        {
            string mixto = "";
            int id_tipo_comida = 0;
            foreach (DataRow rx in dt_pedido_registrado.Select("_Cod_tipo_comida = '" + cod_tipo_comida + "'"))
            {
                id_tipo_comida = Convert.ToInt32(rx["_id_tipo_comida"].ToString());
            }

            dt.Clear();
            dt = dtalimentos_liquido;
            if (dt.Rows.Count > 0)
            {
                guardar_distribucion(7, id_tipo_comida, mixto);
                guardar_alimentos(dt, 7);
            }

        }

        protected void Guardar_solido()
        {
            string mixto = "";
            int id_tipo_comida = 0;
            foreach (DataRow rx in dt_pedido_registrado.Select("_Cod_tipo_comida = '" + cod_tipo_comida + "'"))
            {
                id_tipo_comida = Convert.ToInt32(rx["_id_tipo_comida"].ToString());
            }

            dt.Clear();
            dt = dtalimentos_solido;
            if (dt.Rows.Count > 0)
            {
                guardar_distribucion(8, id_tipo_comida, mixto);
                guardar_alimentos(dt, 8);
            }
        }

        protected void Guardar_agregar()
        {
            string mixto = "";
            int id_tipo_comida = 0;
            foreach (DataRow rx in dt_pedido_registrado.Select("_Cod_tipo_comida = '" + cod_tipo_comida + "'"))
            {
                id_tipo_comida = Convert.ToInt32(rx["_id_tipo_comida"].ToString());
            }
            dt.Clear();
            dt = dtalimentos_agregado;
            if (dt.Rows.Count > 0)
            {
                guardar_distribucion(9, id_tipo_comida, mixto);
                guardar_alimentos(dt, 9);
            }
        }

        protected void Guardar_sopa()
        {
            string mixto = "";
            int id_tipo_comida = 0;
            foreach (DataRow rx in dt_pedido_registrado.Select("_Cod_tipo_comida = '" + cod_tipo_comida + "'"))
            {
                id_tipo_comida = Convert.ToInt32(rx["_id_tipo_comida"].ToString());
            }

            dt.Clear();
            dt = dtalimentos_sopa;
            if (dt.Rows.Count > 0)
            {

                guardar_distribucion(1, id_tipo_comida, mixto);
                guardar_alimentos(dt, 1);
            }
        }

        protected void Guardar_ensalada()
        {

            int id_tipo_comida = 0;
            foreach (DataRow rx in dt_pedido_registrado.Select("_Cod_tipo_comida = '" + cod_tipo_comida + "'"))
            {
                id_tipo_comida = Convert.ToInt32(rx["_id_tipo_comida"].ToString());
            }

            dt.Clear();
            dt = dtalimentos_ensaladas;
            if (dt.Rows.Count > 0)
            {
                if (ck_mixto.Checked == true)
                {
                    mixto = "S";
                }
                else
                {
                    mixto = null;
                }

                guardar_distribucion(2, id_tipo_comida, mixto);
                guardar_alimentos(dt, 2);
            }
        }

        protected void Guardar_plato_fondo()
        {
            string mixto = "";
            int id_tipo_comida = 0;
            foreach (DataRow rx in dt_pedido_registrado.Select("_Cod_tipo_comida = '" + cod_tipo_comida + "'"))
            {
                id_tipo_comida = Convert.ToInt32(rx["_id_tipo_comida"].ToString());
            }

            dt.Clear();
            dt = dtalimentos_plato_fondo;
            if (dt.Rows.Count > 0)
            {
                guardar_distribucion(3, id_tipo_comida, mixto);
                guardar_alimentos(dt, 3);
            }
        }

        protected void Guardar_acompañamiento()
        {
            string mixto = "";
            int id_tipo_comida = 0;
            foreach (DataRow rx in dt_pedido_registrado.Select("_Cod_tipo_comida = '" + cod_tipo_comida + "'"))
            {
                id_tipo_comida = Convert.ToInt32(rx["_id_tipo_comida"].ToString());
            }

            dt.Clear();
            dt = dtalimentos_acompañamiento;
            if (dt.Rows.Count > 0)
            {
                guardar_distribucion(4, id_tipo_comida, mixto);
                guardar_alimentos(dt, 4);
            }
        }

        protected void Guardar_postre()
        {
            string mixto = "";
            int id_tipo_comida = 0;
            foreach (DataRow rx in dt_pedido_registrado.Select("_Cod_tipo_comida = '" + cod_tipo_comida + "'"))
            {
                id_tipo_comida = Convert.ToInt32(rx["_id_tipo_comida"].ToString());
            }

            dt.Clear();
            dt = dtalimentos_postre;
            if (dt.Rows.Count > 0)
            {
                guardar_distribucion(5, id_tipo_comida, mixto);
                guardar_alimentos(dt, 5);
            }
        }

        protected void Guardar_hidricos()
        {
            string mixto = "";
            int id_tipo_comida = 0;
            foreach (DataRow rx in dt_pedido_registrado.Select("_Cod_tipo_comida = '" + cod_tipo_comida + "'"))
            {
                id_tipo_comida = Convert.ToInt32(rx["_id_tipo_comida"].ToString());
            }

            dt.Clear();
            dt = dtalimentos_hidricos;

            if (dt.Rows.Count > 0)
            {
                guardar_distribucion(10, id_tipo_comida, mixto);
                guardar_alimentos(dt, 10);
            }
        }

        protected void guardar_distribucion(int cod_dist, int cod_tipo, string mixto)
        {
            string obs = Session["Comentario_comida"].ToString();
            int cont = 0;
            foreach (DataRow rx1 in dt_pedido_registrado.Select("_Cod_tipo_distribucion = '" + cod_dist + "' and  _Id_tipo_comida = '" + cod_tipo + "' "))
            {
                cont++;
                cod_distribucion = Convert.ToInt32(rx1["_Id_tipo_distribucion"].ToString());

            }

            if (cont == 0)
            {

                string var = new Menu_tipo_distribucionNE().Registrar_Tipo_Distribucion(cod_tipo, cod_dist, user, mixto, obs);
                cod_distribucion = Convert.ToInt32(var);
            }

            else
            {

                string var = new Menu_tipo_distribucionNE().Modificar_Tipo_Distribucion(cod_tipo, cod_dist, user, mixto, obs);
            }

        }

        protected void guardar_alimentos(DataTable dt1, int cod_dis)
        {
            string re = "";
            int cont = 0;
            int cod_res = 0;
            string coment = Session["Comentario_comida"].ToString();

            if (coment == "")
            {
                coment = "";
            }
            else
            {
                coment = Session["Comentario_comida"].ToString();
            }



            foreach (DataRow rx in dt1.Select("_Cod_tipo_distribucion = '" + cod_dis + "'"))
            {
                int cod_al = Convert.ToInt32(rx["_Cod_tipo_alimento"].ToString());
                string nom_al = rx["_Nom_tipo_alimento"].ToString();
                int cant = Convert.ToInt32(rx["_Cantidad"].ToString());
                string vig = rx["_Vigencia"].ToString();
                string est = rx["_Estado"].ToString();

                int cod_c = Convert.ToInt32(rx["_Cod_tipo_consistencia"].ToString());
                int cod_d = Convert.ToInt32(rx["_Cod_tipo_digestabilidad"].ToString());
                int cod_l = Convert.ToInt32(rx["_Cod_lactosa"].ToString());
                int cod_du = Convert.ToInt32(rx["_Cod_dulzor"].ToString());
                int cod_v = Convert.ToInt32(rx["_Cod_tipo_volumen"].ToString());
                int cod_t = Convert.ToInt32(rx["_Cod_tipo_temperatura"].ToString());
                int cod_s = Convert.ToInt32(rx["_Cod_tipo_sales"].ToString());
                string comentario = rx["_Observacion"].ToString();


                foreach (DataRow rx1 in dt_pedido_registrado.Select("_Cod_tipo_alimento = '" + cod_al + "' and  _Cod_tipo_comida = '" + cod_tipo_comida + "'"))
                {
                    cont++;
                    cod_res = Convert.ToInt32(rx1["_Id_tipo_distribucion"].ToString());

                }

                if (cont == 0)
                {
                    if (dt1.Rows.Count > 0)
                    {




                        if (est == "ES")
                        {
                            re = new Menu_tipo_alimentosNE().Registrar_Tipo_Alimento(cod_distribucion, cod_dis, 20171019, cod_al, nom_al, cant, vig, est, user, cod_c, cod_d, cod_l, cod_du, cod_v, cod_t, cod_s, comentario,cod_pedido);
                            txtmsg.Text = "Estimado Usuario, Sea registrado Correctamente el Alimento";
                        }
                        else
                        {
                            re = new Menu_tipo_alimentosNE().Registrar_Tipo_Alimento(cod_distribucion, cod_dis, cod_al, cod_al, nom_al, cant, vig, est, user, cod_c, cod_d, cod_l, cod_du, cod_v, cod_t, cod_s, comentario, cod_pedido);
                            txtmsg.Text = "Estimado Usuario, Sea registrado Correctamente el Alimento";
                        }


                        ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensaje(); });", true);
                    }
                }
                else
                {
                    re = new Menu_tipo_alimentosNE().Modificar_Tipo_Alimento(cod_res, cod_dis, cod_al, cant, vig, est, user, cod_c, cod_d, cod_l, cod_du, cod_v, cod_t, cod_s, comentario);
                    txtmsg.Text = "Estimado Usuario, Sea registrado Correctamente el Alimento";


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensaje(); });", true);

                }
                cont = 0;
            }


            string r1 = new Menu_tipo_comidaNE().Modificar_Tipo_Comida_comentario(cod_pedido, cod_tipo_comida, coment, user);

            guardar_alimentos_extras();
            guardar_alimentos_especiales();

        }

        protected void guardar_alimentos_extras()
        {
            dtextras_2 = (DataTable)Session["tbl_extras_2"];
            foreach (DataRow rx in dtextras_2.Rows)
            {
                int cod_tipo_comida = Convert.ToInt32(rx["_Cod_tipo_comida"].ToString());
                int cod_dis = Convert.ToInt32(rx["_Cod_tipo_distribucion"].ToString());
                int cod_al = Convert.ToInt32(rx["_Cod_tipo_alimento"].ToString());
                string nom_al = rx["_Nom_tipo_alimento"].ToString();
                int cant = Convert.ToInt32(rx["_Cantidad"].ToString());
                string vig = rx["_Vigencia"].ToString();
                string est = rx["_Estado"].ToString();

                int cod_c = Convert.ToInt32(rx["_Cod_tipo_consistencia"].ToString());
                int cod_d = Convert.ToInt32(rx["_Cod_tipo_digestabilidad"].ToString());
                int cod_l = Convert.ToInt32(rx["_Cod_lactosa"].ToString());
                int cod_du = Convert.ToInt32(rx["_Cod_dulzor"].ToString());
                int cod_v = Convert.ToInt32(rx["_Cod_tipo_volumen"].ToString());
                int cod_t = Convert.ToInt32(rx["_Cod_tipo_temperatura"].ToString());
                int cod_s = Convert.ToInt32(rx["_Cod_tipo_sales"].ToString());
                string comentario = rx["_Observacion"].ToString();

                string msg = new PedidosNE().Registrar_alimentos_extra(cod_tipo_comida, cod_dis, cod_distribucion, Convert.ToInt32(cod_al), user, est, nom_al, cod_c, cod_d, cod_l, cod_du, cod_v, cod_t, cod_s, comentario, Convert.ToInt32(cod_pedido));
            }
        }

        protected void guardar_alimentos_especiales()
        {
            dtsuper_especial = (DataTable)Session["tbl_super_especial"];
            if (dtsuper_especial.Rows.Count > 0)
            {
                foreach (DataRow rx in dtsuper_especial.Rows)
                {
                    int cod_tipo_comida = Convert.ToInt32(rx["_Cod_tipo_comida"].ToString());
                    int cod_dis = Convert.ToInt32(rx["_Cod_tipo_distribucion"].ToString());
                    int cod_al = Convert.ToInt32(rx["_Cod_tipo_alimento"].ToString());
                    string nom_al = rx["_Nom_tipo_alimento"].ToString();
                    int cant = Convert.ToInt32(rx["_Cantidad"].ToString());
                    string vig = rx["_Vigencia"].ToString();
                    string est = rx["_Estado"].ToString();

                    string msg = new PedidosNE().Registrar_alimentos_especiales(cod_tipo_comida, cod_dis, cod_distribucion, Convert.ToInt32(cod_al), user, est, nom_al);
                }
            }
        }

        #endregion

        #region Restablecer Pedidos Originales

        protected void restablacer_pedido(int d)
        {
            string res = "";
            foreach (DataRow rx in dt_pedido_registrado.Select("_Cod_menu = '" + cod_pedido + "' and  _Cod_tipo_distribucion = '" + d + "' and  _Cod_tipo_comida = '" + cod_tipo_comida + "' "))
            {


                string id_alimento = rx["_id_tipo_alimento"].ToString();
                int id_distribucion = Convert.ToInt32(rx["_id_tipo_distribucion"].ToString());
                int id_comida = Convert.ToInt32(rx["_id_tipo_comida"].ToString());
                res = new PedidosNE().Eliminar_Pedido(id_comida, id_distribucion);

            }
        }

        protected void restablacer_pedido()
        {
            int cont = 0;


            int cod = cod_tipo_comida;

            switch (cod)
            {
                case 1:
                    restablacer_pedido(7);
                    restablacer_pedido(8);
                    restablacer_pedido(9);
                    restablacer_pedido(10);
                    alm_1.Visible = false;
                    alm_2.Visible = false;
                    alm_3.Visible = false;
                    alm_4.Visible = false;
                    alm_5.Visible = false;


                    break;
                case 2:

                    restablacer_pedido(7);
                    restablacer_pedido(8);
                    restablacer_pedido(9);
                    restablacer_pedido(10);
                    alm_1.Visible = false;
                    alm_2.Visible = false;
                    alm_3.Visible = false;
                    alm_4.Visible = false;
                    alm_5.Visible = false;


                    break;
                case 3:
                    desa_liquido.Visible = false;
                    desa_solidos.Visible = false;
                    desa_agregados.Visible = false;
                    restablacer_pedido(1);
                    restablacer_pedido(2);
                    restablacer_pedido(3);
                    restablacer_pedido(4);
                    restablacer_pedido(5);


                    break;
                case 4:

                    restablacer_pedido(7);
                    restablacer_pedido(8);
                    restablacer_pedido(9);
                    restablacer_pedido(10);
                    alm_1.Visible = false;
                    alm_2.Visible = false;
                    alm_3.Visible = false;
                    alm_4.Visible = false;
                    alm_5.Visible = false;


                    break;
                case 5:
                    desa_liquido.Visible = false;
                    desa_solidos.Visible = false;
                    desa_agregados.Visible = false;
                    desa_solidos.Visible = false;
                    desa_agregados.Visible = false;
                    restablacer_pedido(1);
                    restablacer_pedido(2);
                    restablacer_pedido(3);
                    restablacer_pedido(4);
                    restablacer_pedido(5);


                    break;

                case 6:
                  restablacer_pedido(7);
                    restablacer_pedido(8);
                    restablacer_pedido(9);
                    restablacer_pedido(10);
                    alm_1.Visible = false;
                    alm_2.Visible = false;
                    alm_3.Visible = false;
                    alm_4.Visible = false;
                    alm_5.Visible = false;


                    break;
                case 7:

                    restablacer_pedido(7);
                    restablacer_pedido(8);
                    restablacer_pedido(9);
                    restablacer_pedido(10);
                    alm_1.Visible = false;
                    alm_2.Visible = false;
                    alm_3.Visible = false;
                    alm_4.Visible = false;
                    alm_5.Visible = false;


                    break;
                case 8:



                    restablacer_pedido(10);
                    alm_1.Visible = false;
                    alm_2.Visible = false;
                    alm_3.Visible = false;
                    alm_4.Visible = false;
                    alm_5.Visible = false;

                    break;



                default:
                    Console.WriteLine("Default case");
                    break;
            }
            Cargar_datos_pedidos();
        }

        #endregion

        #region Cambios_compomentes

        protected void btn_cambiar_componente()
        {

            string v_valor = Session["_Cod_tipo_alimento"].ToString();

            if(v_valor=="")
            {
                txtmsg2.Text = "Estimado usuario, No existe Alimento asociado a los componentes seleccionados";
                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "msg_1();", true);
            }
            else
            {
              int var_cod_alimento = Convert.ToInt32(v_valor);
              int var_cod_distribucion = cod_distribucion;

            switch (var_cod_distribucion)
            {
                case 1:
                    dtalimentos_sopa = (DataTable)Session["tbl_alimentos_sopa"];
                    foreach (DataRow rx1 in dtalimentos_sopa.Select("_Cod_tipo_alimento = '" + var_cod_alimento + "'"))
                    {

                        rx1["_Cod_tipo_consistencia"] = cboconsistencia.SelectedValue;
                        rx1["_Cod_tipo_digestabilidad"] = cbodigestabilidad.SelectedValue;
                        rx1["_Cod_lactosa"] = cbolactosa.SelectedValue;
                        rx1["_Cod_dulzor"] = cbodulzor.SelectedValue;
                        rx1["_Cod_tipo_sales"] = cbotipo_sal.SelectedValue;
                        rx1["_Cod_tipo_volumen"] = cbovolumen2.SelectedValue;
                        rx1["_Cod_tipo_temperatura"] = cbotemperatura2.SelectedValue;
                        rx1["_Observacion"] = comentario_alimento;

                    }
                    dtalimentos_sopa.AcceptChanges();
                    Session["tbl_alimentos_sopa"] = dtalimentos_sopa;

                    break;
                case 2:
                    dtalimentos_ensaladas = (DataTable)Session["tbl_alimentos_ensaladas"];
                    foreach (DataRow rx1 in dtalimentos_ensaladas.Select("_Cod_tipo_alimento = '" + var_cod_alimento + "'"))
                    {

                        rx1["_Cod_tipo_consistencia"] = cboconsistencia.SelectedValue;
                        rx1["_Cod_tipo_digestabilidad"] = cbodigestabilidad.SelectedValue;
                        rx1["_Cod_lactosa"] = cbolactosa.SelectedValue;
                        rx1["_Cod_dulzor"] = cbodulzor.SelectedValue;
                        rx1["_Cod_tipo_sales"] = cbotipo_sal.SelectedValue;
                        rx1["_Cod_tipo_volumen"] = cbovolumen2.SelectedValue;
                        rx1["_Cod_tipo_temperatura"] = cbotemperatura2.SelectedValue;
                        rx1["_Observacion"] = comentario_alimento;


                    }
                    dtalimentos_ensaladas.AcceptChanges();
                    Session["tbl_alimentos_ensaladas"] = dtalimentos_ensaladas;

                    break;
                case 3:
                    dtalimentos_plato_fondo = (DataTable)Session["tbl_alimentos_plato_fondo"];
                    foreach (DataRow rx1 in dtalimentos_plato_fondo.Select("_Cod_tipo_alimento = '" + var_cod_alimento + "'"))
                    {
                        rx1["_Cod_tipo_consistencia"] = cboconsistencia.SelectedValue;
                        rx1["_Cod_tipo_digestabilidad"] = cbodigestabilidad.SelectedValue;
                        rx1["_Cod_lactosa"] = cbolactosa.SelectedValue;
                        rx1["_Cod_dulzor"] = cbodulzor.SelectedValue;
                        rx1["_Cod_tipo_sales"] = cbotipo_sal.SelectedValue;
                        rx1["_Cod_tipo_volumen"] = cbovolumen2.SelectedValue;
                        rx1["_Cod_tipo_temperatura"] = cbotemperatura2.SelectedValue;
                        rx1["_Observacion"] = comentario_alimento;

                    }
                    dtalimentos_plato_fondo.AcceptChanges();
                    Session["tbl_alimentos_plato_fondo"] = dtalimentos_plato_fondo;
                    break;
                case 4:
                    dtalimentos_acompañamiento = (DataTable)Session["tbl_alimentos_acompañamiento"];
                    foreach (DataRow rx1 in dtalimentos_acompañamiento.Select("_Cod_tipo_alimento = '" + var_cod_alimento + "'"))
                    {

                        rx1["_Cod_tipo_consistencia"] = cboconsistencia.SelectedValue;
                        rx1["_Cod_tipo_digestabilidad"] = cbodigestabilidad.SelectedValue;
                        rx1["_Cod_lactosa"] = cbolactosa.SelectedValue;
                        rx1["_Cod_dulzor"] = cbodulzor.SelectedValue;
                        rx1["_Cod_tipo_sales"] = cbotipo_sal.SelectedValue;
                        rx1["_Cod_tipo_volumen"] = cbovolumen2.SelectedValue;
                        rx1["_Cod_tipo_temperatura"] = cbotemperatura2.SelectedValue;
                        rx1["_Observacion"] = comentario_alimento;


                    }
                    dtalimentos_acompañamiento.AcceptChanges();
                    Session["tbl_alimentos_acompañamiento"] = dtalimentos_acompañamiento;
                    break;
                case 5:
                    dtalimentos_postre = (DataTable)Session["tbl_alimentos_postre"];
                    foreach (DataRow rx1 in dtalimentos_postre.Select("_Cod_tipo_alimento = '" + var_cod_alimento + "'"))
                    {
                        rx1["_Cod_tipo_consistencia"] = cboconsistencia.SelectedValue;
                        rx1["_Cod_tipo_digestabilidad"] = cbodigestabilidad.SelectedValue;
                        rx1["_Cod_lactosa"] = cbolactosa.SelectedValue;
                        rx1["_Cod_dulzor"] = cbodulzor.SelectedValue;
                        rx1["_Cod_tipo_sales"] = cbotipo_sal.SelectedValue;
                        rx1["_Cod_tipo_volumen"] = cbovolumen2.SelectedValue;
                        rx1["_Cod_tipo_temperatura"] = cbotemperatura2.SelectedValue;
                        rx1["_Observacion"] = comentario_alimento;


                    }
                    dtalimentos_postre.AcceptChanges();
                    Session["tbl_alimentos_postre"] = dtalimentos_postre;

                    break;
                case 7:

                    dtalimentos_liquido = (DataTable)Session["tbl_alimentos_liquido"];
                    foreach (DataRow rx1 in dtalimentos_liquido.Select("_Cod_tipo_alimento = '" + var_cod_alimento + "'"))
                    {
                        rx1["_Cod_tipo_consistencia"] = cboconsistencia.SelectedValue;
                        rx1["_Cod_tipo_digestabilidad"] = cbodigestabilidad.SelectedValue;
                        rx1["_Cod_lactosa"] = cbolactosa.SelectedValue;
                        rx1["_Cod_dulzor"] = cbodulzor.SelectedValue;
                        rx1["_Cod_tipo_sales"] = cbotipo_sal.SelectedValue;
                        rx1["_Cod_tipo_volumen"] = cbovolumen2.SelectedValue;
                        rx1["_Cod_tipo_temperatura"] = cbotemperatura2.SelectedValue;
                        rx1["_Observacion"] = comentario_alimento;

                    }
                    dtalimentos_liquido.AcceptChanges();
                    Session["tbl_alimentos_liquido"] = dtalimentos_liquido;
                    break;
                case 8:
                    dtalimentos_solido = (DataTable)Session["tbl_alimentos_solido"];
                    foreach (DataRow rx1 in dtalimentos_solido.Select("_Cod_tipo_alimento = '" + var_cod_alimento + "'"))
                    {
                        rx1["_Cod_tipo_consistencia"] = cboconsistencia.SelectedValue;
                        rx1["_Cod_tipo_digestabilidad"] = cbodigestabilidad.SelectedValue;
                        rx1["_Cod_lactosa"] = cbolactosa.SelectedValue;
                        rx1["_Cod_dulzor"] = cbodulzor.SelectedValue;
                        rx1["_Cod_tipo_sales"] = cbotipo_sal.SelectedValue;
                        rx1["_Cod_tipo_volumen"] = cbovolumen2.SelectedValue;
                        rx1["_Cod_tipo_temperatura"] = cbotemperatura2.SelectedValue;
                        rx1["_Observacion"] = comentario_alimento;


                    }

                    dtalimentos_solido.AcceptChanges();
                    Session["tbl_alimentos_solido"] = dtalimentos_solido;

                    break;

                case 9:
                    dtalimentos_agregado = (DataTable)Session["tbl_alimentos_agregado"];
                    foreach (DataRow rx1 in dtalimentos_agregado.Select("_Cod_tipo_alimento = '" + var_cod_alimento + "'"))
                    {

                        rx1["_Cod_tipo_consistencia"] = cboconsistencia.SelectedValue;
                        rx1["_Cod_tipo_digestabilidad"] = cbodigestabilidad.SelectedValue;
                        rx1["_Cod_lactosa"] = cbolactosa.SelectedValue;
                        rx1["_Cod_dulzor"] = cbodulzor.SelectedValue;
                        rx1["_Cod_tipo_sales"] = cbotipo_sal.SelectedValue;
                        rx1["_Cod_tipo_volumen"] = cbovolumen2.SelectedValue;
                        rx1["_Cod_tipo_temperatura"] = cbotemperatura2.SelectedValue;
                        rx1["_Observacion"] = comentario_alimento;

                    }

                    dtalimentos_agregado.AcceptChanges();
                    Session["tbl_alimentos_agregado"] = dtalimentos_agregado;
                    break;

                case 10:
                    dtalimentos_hidricos = (DataTable)Session["tbl_alimentos_hidricos"];
                    foreach (DataRow rx1 in dtalimentos_hidricos.Select("_Cod_tipo_alimento = '" + var_cod_alimento + "'"))
                    {
                        rx1["_Cod_tipo_consistencia"] = cboconsistencia.SelectedValue;
                        rx1["_Cod_tipo_digestabilidad"] = cbodigestabilidad.SelectedValue;
                        rx1["_Cod_lactosa"] = cbolactosa.SelectedValue;
                        rx1["_Cod_dulzor"] = cbodulzor.SelectedValue;
                        rx1["_Cod_tipo_sales"] = cbotipo_sal.SelectedValue;
                        rx1["_Cod_tipo_volumen"] = cbovolumen2.SelectedValue;
                        rx1["_Cod_tipo_temperatura"] = cbotemperatura2.SelectedValue;
                        rx1["_Observacion"] = comentario_alimento;

                    }
                    dtalimentos_hidricos.AcceptChanges();
                    Session["tbl_alimentos_hidricos"] = dtalimentos_hidricos;
                    break;



                default:
                    Console.WriteLine("Default case");
                    break;
            }
            }

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


        #endregion

        #region Validaciones

        #endregion

        protected void agregar(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { agregar_alimentos(); });", true);
        }


        protected void Buscar_alimento_especial()
        {
            string filtro = txtespecial.Text.ToUpper();
            List<Utilidades> lista_alimentos_especial = new UtilidadesNE().Cargar_alimentos_menu_extra_extra(cod_distribucion, filtro);
            dtespecial_2 = ConvertToDataTable(lista_alimentos_especial);
            grilla_especial.DataSource = dtespecial_2;
            grilla_especial.DataBind();

            if (dtespecial_2.Rows.Count == 0)
                btn_agregar_ali.Visible=true;
        }


        protected void txtespecial_TextChanged(object sender, EventArgs e)
        {
            Buscar_alimento_especial();

        }


    }
}