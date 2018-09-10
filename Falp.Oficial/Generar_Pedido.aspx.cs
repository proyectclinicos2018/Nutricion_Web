using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Falp.Entidades;
using Falp.Capa_Negocios;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.ComponentModel;

namespace Falp.Oficial
{
    public partial class Generar_Pedido : System.Web.UI.Page
    {

    #region Variables

        static string cod_alimento = "";
        static int cod_alimento_2 = 0;
        static string cod_pedido = "0";
        static int cod_d = 0;
        static int cod_c1 = 0;
        static int cod_a = 0;
        static int cod_o = 0;
        static int cod_c = 0;
        static int cod_c2 = 0;
        static int cod_ce = 0;
        static int cod_hco = 0;
        static int id_tipo_comida = 0;
        static int id_tipo_distribucion = 0;
        static int cod_tipo_comida = 0;
        static int estado_tipo_comida = 0;
        static int cod_opc_comida = 0;
        static int id_opc_comida = 0;
        static int opc_ck = 2;
        static string user = "";

        static int cod_consistencia = 0;
        static int cod_digestabilidad = 0;
        static int cod_cobro = 0;
        static int cod_lactosa = 0;
        static int cod_dulzor = 0;
        static int cod_sal = 0;
        static int cod_aislamiento = 0;


        #region variables opciones alimento

        static int cod_cero_boca_1 = 7;
        static int cod_ayuno_1 = 6;
        static int cod_enteral_1 = 4;
        static int cod_parenteral_1 = 5;

        static string val_d = "S";
        static string val_c1 = "S";
        static string val_a = "S";
        static string val_o = "S";
        static string val_c = "S";
        static string val_c2 = "S";
        static string val_ce = "S";
        static string val_hco = "S";


        #endregion 

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

        static string comentario = "";
        DataTable dt_listado_comida = new DataTable();

        #endregion

    protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["Usuario"] != null)
                {
                   // bloqueo_total();
                    Cargar_regimen();
                    Cargar_aislamiento();
                    Cargar_sal();
                    Cargar_lactosa();
                    Cargar_dulzor();
                    Cargar_digestabilidad();
                    Cargar_consistencia();
                    
                    validar_existe_pedido();
                    validar_existe_tipo_comida_activo();
                    
                     user = Session["Usuario"].ToString();


                     if (cod_pedido == "0")
                     {
                         img_d.ImageUrl = "~/Imagenes/Botones/off.png";
                         img_c1.ImageUrl = "~/Imagenes/Botones/off.png";
                         img_a.ImageUrl = "~/Imagenes/Botones/off.png";
                         img_o.ImageUrl = "~/Imagenes/Botones/off.png";
                         img_c.ImageUrl = "~/Imagenes/Botones/off.png";
                         img_c2.ImageUrl = "~/Imagenes/Botones/off.png";
                         img_ce.ImageUrl = "~/Imagenes/Botones/off.png";
                         img_hco.ImageUrl = "~/Imagenes/Botones/off.png";
                         ck_alimen_oral.Checked = true;

                         if (ck_alimen_oral.Checked == true)
                         {
                             img_d.ImageUrl = "~/Imagenes/Botones/on.png";
                             img_c1.ImageUrl = "~/Imagenes/Botones/on.png";
                             img_a.ImageUrl = "~/Imagenes/Botones/on.png";
                             img_o.ImageUrl = "~/Imagenes/Botones/on.png";
                             img_c.ImageUrl = "~/Imagenes/Botones/on.png";
                             img_c2.ImageUrl = "~/Imagenes/Botones/on.png";
                             img_ce.ImageUrl = "~/Imagenes/Botones/on.png";
                             img_hco.ImageUrl = "~/Imagenes/Botones/on.png";
                             habilitacion_total();
                             btn_b_alim_oral.Visible = true;


                             Extraer_opc_comida();
                             cambiar_ck();
                             registrar_pedido();
                           
                             Registrar_tipo_comida();
                        
                            
                         }

                     }
   

                    string vig= Session["VIG"].ToString();

                    if (vig == "N")
                    {
                        cboaislamiento.Enabled = false;
                        cboconsistencia.Enabled = false;
                        cbodigestabilidad.Enabled = false;
                        cboregimen.Enabled = false;
                        cbodulzor.Enabled = false;
                        cbolactosa.Enabled = false;
                        cbosal.Enabled = false;
                        ck_alimen_oral.Enabled = false;
                        ck_ayuno.Enabled = false;
                        ck_cero_boca.Enabled = false;
                        ck_nut_parenteral.Enabled = false;
                        ck_nut_oral.Enabled = false;
                        img_a.Enabled = false;
                        img_c.Enabled = false;
                        img_c1.Enabled = false;
                        img_c2.Enabled = false;
                        img_ce.Enabled = false;
                        img_d.Enabled = false;
                        img_hco.Enabled = false;


                    }
                    else
                    {
                        if (vig == "M")
                        {
                            Bloquear_Mañana();
                        }
                    }

                   //  cod_pedido = Session["_Cod_pedido"].ToString();
                
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

    #region Listar Grilla

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

    #endregion

    #endregion

    #region Cargar DataTables

    #endregion

    #region Cargar Combox

    protected void Cargar_aislamiento()
    {
        try
        {

            List<Utilidades> lista_aislamiento = new UtilidadesNE().Cargaraislamiento();
            cboaislamiento.DataSource = lista_aislamiento;
            cboaislamiento.DataTextField = "_Nom_aislamiento";
            cboaislamiento.DataValueField = "_Cod_aislamiento";
            cboaislamiento.DataBind();
            cboaislamiento.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        catch (Exception ex)
        {

            System.Console.Write(ex.Message);
        }
    }

    protected void Cargar_regimen()
    {
        try
        {
            List<Utilidades> lista_regimen = new UtilidadesNE().Cargarregimen();
            cboregimen.DataSource = lista_regimen;
            cboregimen.DataTextField = "_Nom_regimen";
            cboregimen.DataValueField = "_Cod_regimen";
            cboregimen.DataBind();
            cboregimen.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        catch (Exception ex)
        {
            System.Console.Write(ex.Message);
        }
    }

    protected void Cargar_consistencia()
    {
        try
        {

            List<Utilidades> lista_consistencia = new UtilidadesNE().Cargartipo_consistencia();
            cboconsistencia.DataSource = lista_consistencia;
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

    protected void Cargar_digestabilidad()
    {
        try
        {

            List<Utilidades> lista_digestabilidad = new UtilidadesNE().Cargartipo_digestabilidad();
            cbodigestabilidad.DataSource = lista_digestabilidad;
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

    protected void Cargar_sal()
    {
        try
        {

            List<Utilidades> lista_sal = new UtilidadesNE().Cargartipo_sales();
            cbosal.DataSource = lista_sal;
            cbosal.DataTextField = "_Nom_tipo_sales";
            cbosal.DataValueField = "_Cod_tipo_sales";
            cbosal.DataBind();
            cbosal.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        catch (Exception ex)
        {

            System.Console.Write(ex.Message);
        }
    }

    protected void Cargar_lactosa()
    {
        try
        {

            List<Utilidades> lista_lactosa = new UtilidadesNE().Cargartipo_lactosa();
            cbolactosa.DataSource = lista_lactosa;
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

    protected void Cargar_dulzor()
    {
        try
        {

            List<Utilidades> lista_dulzor = new UtilidadesNE().Cargartipo_dulzor();
            cbodulzor.DataSource = lista_dulzor;
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

    protected void cboaislamiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        cod_aislamiento = Convert.ToInt32(cboaislamiento.SelectedValue.ToString());
    }

    protected void cboregimen_SelectedIndexChanged(object sender, EventArgs e)
    {
        cod_cobro = Convert.ToInt32(cboregimen.SelectedValue.ToString());
    }

    protected void cboconsistencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        cod_consistencia = Convert.ToInt32(cboconsistencia.SelectedValue.ToString());
    }

    protected void cbodigestabilidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        cod_digestabilidad = Convert.ToInt32(cbodigestabilidad.SelectedValue.ToString());
    }

    protected void cbosal_SelectedIndexChanged(object sender, EventArgs e)
    {
        cod_sal = Convert.ToInt32(cbosal.SelectedValue.ToString());
    }

    protected void cbolactosa_SelectedIndexChanged(object sender, EventArgs e)
    {
        cod_lactosa = Convert.ToInt32(cbolactosa.SelectedValue.ToString());
    }

    protected void cbodulzor_SelectedIndexChanged(object sender, EventArgs e)
    {
        cod_dulzor = Convert.ToInt32(cbodulzor.SelectedValue.ToString());
    }


    #endregion 

    #endregion

    #region Botones


    protected void acceso_d(object sender, EventArgs e)
    {
         string vig= Session["VIG"].ToString();

         if (vig == "N")
         {
             Session["Tipo_Alimento"] = "DESAYUNO (D)";
             Session["_Cod_tipo_comida"] = var_cod_desayuno.ToString();
             Response.Redirect("Guardar_Pedido.aspx");
         }
         else
         {
             string vale = "";
             string ingesta = "";
             dt_listado_comida = (DataTable)Session["tabla_comidas"];
             foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_desayuno + "'"))
             {
                 vale = row["_Vale_impreso"].ToString();
                 ingesta = row["_Ingesta"].ToString();
                 Session["_Vale"] = vale;
                 Session["_Ingesta_d"] = ingesta;
             }

             if (vale != "S" && ingesta != "S")
             {
                 Session["Consistencia"] = cboconsistencia.SelectedValue;
                 cod_consistencia = Convert.ToInt32(cboconsistencia.SelectedValue);
                 Session["Digestabilidad"] = cbodigestabilidad.SelectedValue;
                 cod_digestabilidad = Convert.ToInt32(cbodigestabilidad.SelectedValue);
                 Session["Regimen"] = cboregimen.SelectedValue;
                 cod_cobro = Convert.ToInt32(cboregimen.SelectedValue);
                 Session["Lactosa"] = cbolactosa.SelectedValue;
                 cod_lactosa = Convert.ToInt32(cbolactosa.SelectedValue);
                 Session["Dulzor"] = cbodulzor.SelectedValue;
                 cod_dulzor = Convert.ToInt32(cbodulzor.SelectedValue);
                 Session["Sal"] = cbosal.SelectedValue;
                 cod_sal = Convert.ToInt32(cbosal.SelectedValue);
                 Session["Aislamiento"] = cboaislamiento.SelectedValue;
                 cod_aislamiento = Convert.ToInt32(cboaislamiento.SelectedValue);
                 int cont = 0;


                 if (Validar_campos())
                 {
                     registrar_pedido();
                     Registrar_tipo_comida(var_cod_desayuno);




                     if (dt_listado_comida.Rows.Count > 0)
                     {

                         foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_desayuno + "'"))
                         {
                             string v = row["_Estado"].ToString();
                             Session["Tipo_Alimento"] = row["_Nom_tipo_comida"].ToString();
                             Session["_Cod_tipo_comida"] = row["_Cod_tipo_comida"].ToString();
                             Session["_Cod_pedido"] = row["_Cod_menu"].ToString();


                             if (v == "S")
                             {

                                 Response.Redirect("Guardar_Pedido.aspx");
                             }
                             else
                             {
                                 txtmsg.Text = "Estimado Usuario, no tiene permiso acceso debido a la configuración de la opcion de alimento";
                                 ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);

                             }
                         }
                     }
                     else
                     {
                         Session["Tipo_Alimento"] = "DESAYUNO (D)";
                         Session["_Cod_tipo_comida"] = var_cod_desayuno.ToString();
                         Response.Redirect("Guardar_Pedido.aspx");
                     }
                 }
             }

             else
             {

                Session["Tipo_Alimento"] = "DESAYUNO (D)";
                         Session["_Cod_tipo_comida"] = var_cod_desayuno.ToString();
                         Response.Redirect("Guardar_Pedido.aspx");

             }
         }


    }

    protected void acceso_c1(object sender, EventArgs e)
    {
         string vig= Session["VIG"].ToString();

         if (vig == "N")
         {
             Session["Tipo_Alimento"] = "COLACION MATINAL (C1)";
             Session["_Cod_tipo_comida"] = var_cod_colacion_matinal.ToString();
             Response.Redirect("Guardar_Pedido.aspx");
         }
         else
         {
             string vale = "";
             string ingesta = "";
             dt_listado_comida = (DataTable)Session["tabla_comidas"];
             foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_colacion_matinal + "'"))
             {
                 vale = row["_Vale_impreso"].ToString();
                 ingesta = row["_Ingesta"].ToString();
                 Session["_Vale"] = vale;
                 Session["_Ingesta_c1"] = ingesta;
             }

             if (vale != "S" && ingesta != "S")
             {
                 Session["Consistencia"] = cboconsistencia.SelectedValue;
                 cod_consistencia = Convert.ToInt32(cboconsistencia.SelectedValue);
                 Session["Digestabilidad"] = cbodigestabilidad.SelectedValue;
                 cod_digestabilidad = Convert.ToInt32(cbodigestabilidad.SelectedValue);
                 Session["Regimen"] = cboregimen.SelectedValue;
                 cod_cobro = Convert.ToInt32(cboregimen.SelectedValue);
                 Session["Lactosa"] = cbolactosa.SelectedValue;
                 cod_lactosa = Convert.ToInt32(cbolactosa.SelectedValue);
                 Session["Dulzor"] = cbodulzor.SelectedValue;
                 cod_dulzor = Convert.ToInt32(cbodulzor.SelectedValue);
                 Session["Sal"] = cbosal.SelectedValue;
                 cod_sal = Convert.ToInt32(cbosal.SelectedValue);
                 Session["Aislamiento"] = cboaislamiento.SelectedValue;
                 cod_aislamiento = Convert.ToInt32(cboaislamiento.SelectedValue);

                 int cont = 0;


                 if (Validar_campos())
                 {
                     registrar_pedido();
                     Registrar_tipo_comida(var_cod_colacion_matinal);




                     if (dt_listado_comida.Rows.Count > 0)
                     {

                         foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_colacion_matinal + "'"))
                         {
                             string v = row["_Estado"].ToString();
                             Session["Tipo_Alimento"] = row["_Nom_tipo_comida"].ToString();
                             Session["_Cod_tipo_comida"] = row["_Cod_tipo_comida"].ToString();
                             Session["_Cod_pedido"] = row["_Cod_menu"].ToString();
                             if (v == "S")
                             {
                                 cont++;

                                 Response.Redirect("Guardar_Pedido.aspx");
                             }

                             else
                             {
                                 txtmsg.Text = "Estimado Usuario, no tiene permiso acceso debido a la configuración de la opcion de alimento";
                                 ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);

                             }
                         }
                     }
                     else
                     {
                         Session["Tipo_Alimento"] = "COLACION MATINAL (C1)";
                         Session["_Cod_tipo_comida"] = var_cod_colacion_matinal.ToString();
                         Response.Redirect("Guardar_Pedido.aspx");
                     }
                 }

             }

             else
             {

                     Session["Tipo_Alimento"] = "COLACION MATINAL (C1)";
                         Session["_Cod_tipo_comida"] = var_cod_colacion_matinal.ToString();
                         Response.Redirect("Guardar_Pedido.aspx");

             }
         }


    }

    protected void acceso_a(object sender, EventArgs e)
    {
         string vig= Session["VIG"].ToString();

         if (vig == "N")
         {
             Session["Tipo_Alimento"] = "ALMUERZO (A)";
             Session["_Cod_tipo_comida"] = var_cod_almuerzo.ToString();
             Response.Redirect("Guardar_Pedido.aspx");
         }
         else
         {
             string vale = "";
             string ingesta = "";
             dt_listado_comida = (DataTable)Session["tabla_comidas"];
             foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_almuerzo + "'"))
             {
                 vale = row["_Vale_impreso"].ToString();
                 ingesta = row["_Ingesta"].ToString();
                 Session["_Vale"] = vale;
                 Session["_Ingesta_a"] = ingesta;
             }

             if (vale != "S" && ingesta !="S")
             {
                 Session["Consistencia"] = cboconsistencia.SelectedValue;
                 cod_consistencia = Convert.ToInt32(cboconsistencia.SelectedValue);
                 Session["Digestabilidad"] = cbodigestabilidad.SelectedValue;
                 cod_digestabilidad = Convert.ToInt32(cbodigestabilidad.SelectedValue);
                 Session["Regimen"] = cboregimen.SelectedValue;
                 cod_cobro = Convert.ToInt32(cboregimen.SelectedValue);
                 Session["Lactosa"] = cbolactosa.SelectedValue;
                 cod_lactosa = Convert.ToInt32(cbolactosa.SelectedValue);
                 Session["Dulzor"] = cbodulzor.SelectedValue;
                 cod_dulzor = Convert.ToInt32(cbodulzor.SelectedValue);
                 Session["Sal"] = cbosal.SelectedValue;
                 cod_sal = Convert.ToInt32(cbosal.SelectedValue);
                 Session["Aislamiento"] = cboaislamiento.SelectedValue;
                 cod_aislamiento = Convert.ToInt32(cboaislamiento.SelectedValue);


                 int cont = 0;




                 if (Validar_campos())
                 {
                     registrar_pedido();
                     Registrar_tipo_comida(var_cod_almuerzo);



                     if (dt_listado_comida.Rows.Count > 0)
                     {

                         foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_almuerzo + "'"))
                         {
                             Session["Tipo_Alimento"] = row["_Nom_tipo_comida"].ToString();
                             Session["_Cod_tipo_comida"] = row["_Cod_tipo_comida"].ToString();
                             Session["_Cod_pedido"] = row["_Cod_menu"].ToString();
                             string v = row["_Estado"].ToString();

                             if (v == "S")
                             {
                                 Response.Redirect("Guardar_Pedido.aspx");
                             }
                             else
                             {
                                 txtmsg.Text = "Estimado Usuario, no tiene permiso acceso debido a la configuración de la opcion de alimento";
                                 ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);

                             }
                         }
                     }
                     else
                     {
                         Session["Tipo_Alimento"] = "ALMUERZO (A)";
                         Session["_Cod_tipo_comida"] = var_cod_almuerzo.ToString();
                         Response.Redirect("Guardar_Pedido.aspx");
                     }
                 }

             }

             else
             {
                 Session["Tipo_Alimento"] = "ALMUERZO (A)";
                 Session["_Cod_tipo_comida"] = var_cod_almuerzo.ToString();
                 Response.Redirect("Guardar_Pedido.aspx");
        

             }
         }

    }

    protected void acceso_o(object sender, EventArgs e)
    {
         string vig= Session["VIG"].ToString();

         if (vig == "N")
         {
             Session["Tipo_Alimento"] = "ONCE (O)";
             Session["_Cod_tipo_comida"] = var_cod_once.ToString();
             Response.Redirect("Guardar_Pedido.aspx");
         }
         else
         {
             string vale = "";
             string ingesta = "";
             dt_listado_comida = (DataTable)Session["tabla_comidas"];
             foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_once + "'"))
             {
                 vale = row["_Vale_impreso"].ToString();
                 ingesta = row["_Ingesta"].ToString();
                 Session["_Vale"] = vale;
                 Session["_Ingesta_o"] = ingesta;
             }

             if (vale != "S" && ingesta != "S")
             {

                 Session["Consistencia"] = cboconsistencia.SelectedValue;
                 cod_consistencia = Convert.ToInt32(cboconsistencia.SelectedValue);
                 Session["Digestabilidad"] = cbodigestabilidad.SelectedValue;
                 cod_digestabilidad = Convert.ToInt32(cbodigestabilidad.SelectedValue);
                 Session["Regimen"] = cboregimen.SelectedValue;
                 cod_cobro = Convert.ToInt32(cboregimen.SelectedValue);
                 Session["Lactosa"] = cbolactosa.SelectedValue;
                 cod_lactosa = Convert.ToInt32(cbolactosa.SelectedValue);
                 Session["Dulzor"] = cbodulzor.SelectedValue;
                 cod_dulzor = Convert.ToInt32(cbodulzor.SelectedValue);
                 Session["Sal"] = cbosal.SelectedValue;
                 cod_sal = Convert.ToInt32(cbosal.SelectedValue);
                 Session["Aislamiento"] = cboaislamiento.SelectedValue;
                 cod_aislamiento = Convert.ToInt32(cboaislamiento.SelectedValue);

                 int cont = 0;


                 if (Validar_campos())
                 {
                     registrar_pedido();
                     Registrar_tipo_comida(var_cod_once);



                     if (dt_listado_comida.Rows.Count > 0)
                     {
                         foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_once + "'"))
                         {
                             string v = row["_Estado"].ToString();
                             Session["Tipo_Alimento"] = row["_Nom_tipo_comida"].ToString();
                             Session["_Cod_tipo_comida"] = row["_Cod_tipo_comida"].ToString();
                             Session["_Cod_pedido"] = row["_Cod_menu"].ToString();
                             if (v == "S")
                             {
                                 cont++;
                                 Response.Redirect("Guardar_Pedido.aspx");
                             }
                             else
                             {
                                 txtmsg.Text = "Estimado Usuario, no tiene permiso acceso debido a la configuración de la opcion de alimento";
                                 ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);

                             }
                         }
                     }
                     else
                     {
                         Session["Tipo_Alimento"] = "ONCE (O)";
                         Session["_Cod_tipo_comida"] = var_cod_once.ToString();
                         Response.Redirect("Guardar_Pedido.aspx");
                     }
                 }

             }

             else
             {

                  Session["Tipo_Alimento"] = "ONCE (O)";
                         Session["_Cod_tipo_comida"] = var_cod_once.ToString();
                         Response.Redirect("Guardar_Pedido.aspx");

             }
         }

    }

    protected void acceso_c(object sender, EventArgs e)
    {
         string vig= Session["VIG"].ToString();

         if (vig == "N")
         {
             Session["Tipo_Alimento"] = "CENA (C)";
             Session["_Cod_tipo_comida"] = var_cod_cena.ToString();
             Response.Redirect("Guardar_Pedido.aspx");
         }
         else
         {
             string vale = "";
             string ingesta = "";
             dt_listado_comida = (DataTable)Session["tabla_comidas"];
             foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_cena + "'"))
             {
                 vale = row["_Vale_impreso"].ToString();
                 ingesta = row["_Ingesta"].ToString();
                 Session["_Vale"] = vale;
                 Session["_Ingesta_c"] = ingesta;
             }

             if (vale != "S" && ingesta != "S")
             {
                 Session["Consistencia"] = cboconsistencia.SelectedValue;
                 cod_consistencia = Convert.ToInt32(cboconsistencia.SelectedValue);
                 Session["Digestabilidad"] = cbodigestabilidad.SelectedValue;
                 cod_digestabilidad = Convert.ToInt32(cbodigestabilidad.SelectedValue);
                 Session["Regimen"] = cboregimen.SelectedValue;
                 cod_cobro = Convert.ToInt32(cboregimen.SelectedValue);
                 Session["Lactosa"] = cbolactosa.SelectedValue;
                 cod_lactosa = Convert.ToInt32(cbolactosa.SelectedValue);
                 Session["Dulzor"] = cbodulzor.SelectedValue;
                 cod_dulzor = Convert.ToInt32(cbodulzor.SelectedValue);
                 Session["Sal"] = cbosal.SelectedValue;
                 cod_sal = Convert.ToInt32(cbosal.SelectedValue);
                 Session["Aislamiento"] = cboaislamiento.SelectedValue;
                 cod_aislamiento = Convert.ToInt32(cboaislamiento.SelectedValue);

                 int cont = 0;


                 if (Validar_campos())
                 {
                     registrar_pedido();
                     Registrar_tipo_comida(var_cod_cena);




                     if (dt_listado_comida.Rows.Count > 0)
                     {
                         foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_cena + "'"))
                         {
                             string v = row["_Estado"].ToString();
                             Session["Tipo_Alimento"] = row["_Nom_tipo_comida"].ToString();
                             Session["_Cod_tipo_comida"] = row["_Cod_tipo_comida"].ToString();
                             Session["_Cod_pedido"] = row["_Cod_menu"].ToString();
                             if (v == "S")
                             {
                                 cont++;
                                 Response.Redirect("Guardar_Pedido.aspx");
                             }
                             else
                             {
                                 txtmsg.Text = "Estimado Usuario, no tiene permiso acceso debido a la configuración de la opcion de alimento";
                                 ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);

                             }
                         }
                     }
                     else
                     {
                         Session["Tipo_Alimento"] = "CENA (C)";
                         Session["_Cod_tipo_comida"] = var_cod_cena.ToString();
                         Response.Redirect("Guardar_Pedido.aspx");
                     }
                 }
             }

             else
             {

                  Session["Tipo_Alimento"] = "CENA (C)";
                         Session["_Cod_tipo_comida"] = var_cod_cena.ToString();
                         Response.Redirect("Guardar_Pedido.aspx");
             }
         }

    }

    protected void acceso_c2(object sender, EventArgs e)
    {
        string vig= Session["VIG"].ToString();

        if (vig == "N")
        {
            Session["Tipo_Alimento"] = "COLACION NOCTURNA (C2)";
            Session["_Cod_tipo_comida"] = var_cod_colacion_nocturna.ToString();
            Response.Redirect("Guardar_Pedido.aspx");
        }
        else
        {
            string vale = "";
            string ingesta = "";
            dt_listado_comida = (DataTable)Session["tabla_comidas"];
            foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_colacion_nocturna + "'"))
            {
                vale = row["_Vale_impreso"].ToString();
                ingesta = row["_Ingesta"].ToString();
                Session["_Vale"] = vale;
                Session["_Ingesta_c2"] = ingesta;
            }

            if (vale != "S" && ingesta != "S")
            {
                Session["Consistencia"] = cboconsistencia.SelectedValue;
                cod_consistencia = Convert.ToInt32(cboconsistencia.SelectedValue);
                Session["Digestabilidad"] = cbodigestabilidad.SelectedValue;
                cod_digestabilidad = Convert.ToInt32(cbodigestabilidad.SelectedValue);
                Session["Regimen"] = cboregimen.SelectedValue;
                cod_cobro = Convert.ToInt32(cboregimen.SelectedValue);
                Session["Lactosa"] = cbolactosa.SelectedValue;
                cod_lactosa = Convert.ToInt32(cbolactosa.SelectedValue);
                Session["Dulzor"] = cbodulzor.SelectedValue;
                cod_dulzor = Convert.ToInt32(cbodulzor.SelectedValue);
                Session["Sal"] = cbosal.SelectedValue;
                cod_sal = Convert.ToInt32(cbosal.SelectedValue);
                Session["Aislamiento"] = cboaislamiento.SelectedValue;
                cod_aislamiento = Convert.ToInt32(cboaislamiento.SelectedValue);

                int cont = 0;
                dt_listado_comida = (DataTable)Session["tabla_comidas"];

                if (Validar_campos())
                {
                    registrar_pedido();
                    Registrar_tipo_comida(var_cod_colacion_nocturna);




                    if (dt_listado_comida.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_colacion_nocturna + "'"))
                        {
                            string v = row["_Estado"].ToString();
                            Session["Tipo_Alimento"] = row["_Nom_tipo_comida"].ToString();
                            Session["_Cod_tipo_comida"] = row["_Cod_tipo_comida"].ToString();
                            Session["_Cod_pedido"] = row["_Cod_menu"].ToString();
                            if (v == "S")
                            {
                                cont++;
                                Response.Redirect("Guardar_Pedido.aspx");
                            }
                            else
                            {
                                txtmsg.Text = "Estimado Usuario, no tiene permiso acceso debido a la configuración de la opcion de alimento";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);

                            }
                        }
                    }
                    else
                    {
                        Session["Tipo_Alimento"] = "COLACION NOCTURNA (C2)";
                        Session["_Cod_tipo_comida"] = var_cod_colacion_nocturna.ToString();
                        Response.Redirect("Guardar_Pedido.aspx");
                    }
                }

            }

            else
            {

                  Session["Tipo_Alimento"] = "COLACION NOCTURNA (C2)";
                        Session["_Cod_tipo_comida"] = var_cod_colacion_nocturna.ToString();
                        Response.Redirect("Guardar_Pedido.aspx");

            }
        }

    }

    protected void acceso_ce(object sender, EventArgs e)
    {
          string vig= Session["VIG"].ToString();

          if (vig == "N")
          {
              Session["Tipo_Alimento"] = "COLACION EXTRA (CE)";
              Session["_Cod_tipo_comida"] = var_cod_colacion_extra.ToString();
              Response.Redirect("Guardar_Pedido.aspx");
          }
          else
          {
              string vale = "";
              string ingesta = "";
              dt_listado_comida = (DataTable)Session["tabla_comidas"];
              foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_colacion_extra + "'"))
              {
                  vale = row["_Vale_impreso"].ToString();
                  ingesta = row["_Ingesta"].ToString();
                  Session["_Vale"] = vale;
                  Session["_Ingesta_ce"] = ingesta;
              }

              if (vale != "S" && ingesta != "S")
              {
                  Session["Consistencia"] = cboconsistencia.SelectedValue;
                  cod_consistencia = Convert.ToInt32(cboconsistencia.SelectedValue);
                  Session["Digestabilidad"] = cbodigestabilidad.SelectedValue;
                  cod_digestabilidad = Convert.ToInt32(cbodigestabilidad.SelectedValue);
                  Session["Regimen"] = cboregimen.SelectedValue;
                  cod_cobro = Convert.ToInt32(cboregimen.SelectedValue);
                  Session["Lactosa"] = cbolactosa.SelectedValue;
                  cod_lactosa = Convert.ToInt32(cbolactosa.SelectedValue);
                  Session["Dulzor"] = cbodulzor.SelectedValue;
                  cod_dulzor = Convert.ToInt32(cbodulzor.SelectedValue);
                  Session["Sal"] = cbosal.SelectedValue;
                  cod_sal = Convert.ToInt32(cbosal.SelectedValue);
                  Session["Aislamiento"] = cboaislamiento.SelectedValue;
                  cod_aislamiento = Convert.ToInt32(cboaislamiento.SelectedValue);

                  int cont = 0;
                  dt_listado_comida = (DataTable)Session["tabla_comidas"];
                  if (Validar_campos())
                  {
                      registrar_pedido();
                      Registrar_tipo_comida(var_cod_colacion_extra);



                      if (dt_listado_comida.Rows.Count > 0)
                      {
                          foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_colacion_extra + "'"))
                          {
                              string v = row["_Estado"].ToString();
                              Session["Tipo_Alimento"] = row["_Nom_tipo_comida"].ToString();
                              Session["_Cod_tipo_comida"] = row["_Cod_tipo_comida"].ToString();
                              Session["_Cod_pedido"] = row["_Cod_menu"].ToString();
                              if (v == "S")
                              {
                                  cont++;
                                  Response.Redirect("Guardar_Pedido.aspx");
                              }
                              else
                              {
                                  txtmsg.Text = "Estimado Usuario, no tiene permiso acceso debido a la configuración de la opcion de alimento";
                                  ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);

                              }
                          }
                      }
                      else
                      {
                          Session["Tipo_Alimento"] = "COLACION EXTRA (CE)";
                          Session["_Cod_tipo_comida"] = var_cod_colacion_extra.ToString();
                          Response.Redirect("Guardar_Pedido.aspx");
                      }
                  }

              }

              else
              {

                          Session["Tipo_Alimento"] = "COLACION EXTRA (CE)";
                          Session["_Cod_tipo_comida"] = var_cod_colacion_extra.ToString();
                          Response.Redirect("Guardar_Pedido.aspx");

              }
          }

    }

    protected void acceso_hco(object sender, EventArgs e)
    {
         string vig= Session["VIG"].ToString();

         if (vig == "N")
         {
             Session["Tipo_Alimento"] = "HIDRICOS (HCO)";
             Session["_Cod_tipo_comida"] = var_cod_hidricos.ToString();
             Response.Redirect("Guardar_Pedido.aspx");
         }
         else
         {
             string vale = "";
             string ingesta="";
             dt_listado_comida = (DataTable)Session["tabla_comidas"];
             foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_hidricos + "'"))
             {
                 vale = row["_Vale_impreso"].ToString();
                 ingesta = row["_Ingesta"].ToString();
                 Session["_Vale"] = vale;
                 Session["_Ingesta_hco"] = ingesta;
             }

             if (vale != "S" && ingesta != "S")
             {
                 Session["Consistencia"] = cboconsistencia.SelectedValue;
                 cod_consistencia = Convert.ToInt32(cboconsistencia.SelectedValue);
                 Session["Digestabilidad"] = cbodigestabilidad.SelectedValue;
                 cod_digestabilidad = Convert.ToInt32(cbodigestabilidad.SelectedValue);
                 Session["Regimen"] = cboregimen.SelectedValue;
                 cod_cobro = Convert.ToInt32(cboregimen.SelectedValue);
                 Session["Lactosa"] = cbolactosa.SelectedValue;
                 cod_lactosa = Convert.ToInt32(cbolactosa.SelectedValue);
                 Session["Dulzor"] = cbodulzor.SelectedValue;
                 cod_dulzor = Convert.ToInt32(cbodulzor.SelectedValue);
                 Session["Sal"] = cbosal.SelectedValue;
                 cod_sal = Convert.ToInt32(cbosal.SelectedValue);
                 Session["Aislamiento"] = cboaislamiento.SelectedValue;
                 cod_aislamiento = Convert.ToInt32(cboaislamiento.SelectedValue);

                 int cont = 0;
                 dt_listado_comida = (DataTable)Session["tabla_comidas"];

                 if (Validar_campos())
                 {
                     registrar_pedido();
                     Registrar_tipo_comida(var_cod_hidricos);




                     if (dt_listado_comida.Rows.Count > 0)
                     {
                         foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_hidricos + "'"))
                         {
                             string v = row["_Estado"].ToString();
                             Session["Tipo_Alimento"] = row["_Nom_tipo_comida"].ToString();
                             Session["_Cod_tipo_comida"] = row["_Cod_tipo_comida"].ToString();
                             Session["_Cod_pedido"] = row["_Cod_menu"].ToString();
                             if (v == "S")
                             {
                                 cont++;
                                 Response.Redirect("Guardar_Pedido.aspx");
                             }
                             else
                             {
                                 txtmsg.Text = "Estimado Usuario, no tiene permiso acceso debido a la configuración de la opcion de alimento";
                                 ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);

                             }
                         }
                     }
                     else
                     {
                         Session["Tipo_Alimento"] = "HIDRICOS (HCO)";
                         Session["_Cod_tipo_comida"] = var_cod_hidricos.ToString();
                         Response.Redirect("Guardar_Pedido.aspx");
                     }
                 }

             }

             else
             {

                         Session["Tipo_Alimento"] = "HIDRICOS (HCO)";
                         Session["_Cod_tipo_comida"] = var_cod_hidricos.ToString();
                         Response.Redirect("Guardar_Pedido.aspx");

             }
         }

    }

    protected void btn_volver(object sender, EventArgs e)
    {
        Response.Redirect("Listado_Camas.aspx");
    }


    protected void Cambiar_img(int num)
    {
        Session["_Cod_tipo_comida"] = num;
        dt_listado_comida = (DataTable)Session["tabla_comidas"];

        string v = "";
        string i= "";
        foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + num + "'"))
        {
            v = row["_Estado"].ToString();
            i = row["_Ingesta"].ToString();
            if (i != "S")
            {
                if (v == "S")
                {
                    row["_Estado"] = "N";
                    img_d.ImageUrl = "~/Imagenes/Botones/off.png";
                    img_d_2.ImageUrl = "~/Imagenes/Almuerzos/desa_1.jpg";
                }

                else
                {

                    row["_Estado"] = "S";
                    img_d.ImageUrl = "~/Imagenes/Botones/on.png";
                    img_d_2.ImageUrl = "~/Imagenes/Almuerzos/desa_1.jpg";

                }
            }
        }
        dt_listado_comida.AcceptChanges();
        Session["tabla_comidas"] = dt_listado_comida;
        if (Validar_campos())
        {
            Registrar_tipo_comida(num);
            validar_eliminacion(num);
            validar_existe_tipo_comida_activo();
        }

    }

    protected void Btn_desayuno(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Cambiar_img(var_cod_desayuno);
        string vig= Session["VIG"].ToString();
        if (vig == "M")
        {
            Bloquear_Mañana();
        }
     }

    protected void Btn_colacion_man(object sender, EventArgs e)
    {

        Cambiar_img(var_cod_colacion_matinal);
    
    }

    protected void Btn_almuerzo1(object sender, EventArgs e)
    {
        Cambiar_img(var_cod_almuerzo);
    
    }

    protected void Btn_once(object sender, EventArgs e)
    {      
        Cambiar_img(var_cod_once);     
    }

    protected void Btn_cena(object sender, EventArgs e)
    {
        Cambiar_img(var_cod_cena);  
    }

    protected void Btn_colacion_noc(object sender, EventArgs e)
    {

        Cambiar_img(var_cod_colacion_nocturna);  
    }

    protected void Btn_colacion_ext(object sender, EventArgs e)
    {
        Cambiar_img(var_cod_colacion_extra);  
    }

    protected void Btn_hidricos(object sender, EventArgs e)
    {

        Cambiar_img(var_cod_hidricos);
        string vig = Session["VIG"].ToString();
        if (vig == "M")
        {
            Bloquear_Mañana();
        }
    }

    protected void buscar_comentario(object sender, EventArgs e)
    {
        if (ck_alimen_oral.Checked == true)
        {
            comen.Text = "  Alimentación Oral";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { info_comentario(); });", true);
           
        }
        else
        {
            if (ck_ayuno.Checked == true)
            {
                comen.Text = " Ayuno";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { info_comentario(); });", true);
           
            }
            else
            {
                if (ck_nut_oral.Checked == true)
                {
                    comen.Text = "Nutrición Oral";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { info_comentario(); });", true);
           
                }
                else
                {
                    if (ck_nut_parenteral.Checked == true)
                    {
                        comen.Text = "Nutrición Parental";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { info_comentario(); });", true);
           
                    }
                    else
                    {
                        if (ck_cero_boca.Checked == true)
                        {
                            comen.Text = "Cero x Boca";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { info_comentario(); });", true);
          
                        }
                       
                    }
                }
            }
        }
    }

    #endregion

    #region Metodos

    #region Bloqueo 

    protected void Bloquear_Mañana()
    {
        img_a.Enabled = false;
        img_a_2.Enabled = false;
        img_o.Enabled = false;
        img_o_2.Enabled = false;
        img_c.Enabled = false;
        img_c_2.Enabled = false;
        img_c1.Enabled = false;
        img_c1_2.Enabled = false;
        img_c2.Enabled = false;
        img_c2_2.Enabled = false;
        img_ce.Enabled = false;
        img_ce_2.Enabled = false;
        img_d.Enabled = true;
        img_d_2.Enabled = true;
        img_hco.Enabled = true;
        img_hco_2.Enabled = true;
    }
   
    protected void bloqueo_total()
    {
        img_d.Enabled = false;
        img_c1.Enabled = false;
        img_a.Enabled = false;
        img_o.Enabled = false;
        img_c.Enabled = false;
        img_c2.Enabled = false;
        img_ce.Enabled = false;
        img_hco.Enabled = false;

        img_c_2.Enabled = false;
        img_c1_2.Enabled = false;
        img_ce_2.Enabled = false;
        img_d_2.Enabled = false;
        img_o_2.Enabled = false;
        img_a_2.Enabled = false;
        img_c2_2.Enabled = false;
        img_hco_2.Enabled = false;

        /*  cbosal.Enabled = false;
          cboregimen.Enabled = false;
          cbolactosa.Enabled = false;
          cbodulzor.Enabled = false;
          cboaislamiento.Enabled = false;
          cboconsistencia.Enabled = false;
          cbodigestabilidad.Enabled = false;*/
    }

    protected void bloqueo_parcial()
    {


        img_c_2.Enabled = false;
        img_c1_2.Enabled = false;
        img_ce_2.Enabled = false;
        img_d_2.Enabled = false;
        img_o_2.Enabled = false;
        img_a_2.Enabled = false;
        img_c2_2.Enabled = false;
        img_hco_2.Enabled = false;

        /* cbosal.Enabled = false;
         cboregimen.Enabled = false;
         cbolactosa.Enabled = false;
         cbodulzor.Enabled = false;
         cboaislamiento.Enabled = false;
         cboconsistencia.Enabled = false;
         cbodigestabilidad.Enabled = false;*/
    }

    #endregion 



    #region Habilitar 

    protected void habilitacion_total()
    {
        img_d.Enabled = true;
        img_c1.Enabled = true;
        img_a.Enabled = true;
        img_o.Enabled = true;
        img_c.Enabled = true;
        img_c2.Enabled = true;
        img_ce.Enabled = true;
        img_hco.Enabled = true;

        img_c_2.Enabled = true;
        img_c1_2.Enabled = true;
        img_ce_2.Enabled = true;
        img_d_2.Enabled = true;
        img_o_2.Enabled = true;
        img_a_2.Enabled = true;
        img_c2_2.Enabled = true;
        img_hco_2.Enabled = true;

        cbosal.Enabled = true;
        cboregimen.Enabled = true;
        cbolactosa.Enabled = true;
        cbodulzor.Enabled = true;
        cboaislamiento.Enabled = true;
        cboconsistencia.Enabled = true;
        cbodigestabilidad.Enabled = true;
    }
    #endregion

    #region Extraer Datos Pedido 

    protected void validar_existe_tipo_comida_activo()
    {
        validar_existe_pedido();
        buscar_alimento_activos();
        activar_iconos();
       
    }
    protected void buscar_alimento_activos()
    {
        List<Utilidades> lista_comida = new UtilidadesNE().Cargaralimentos_pedido(Convert.ToInt32(cod_pedido));
        dt_listado_comida = ConvertToDataTable(lista_comida);
        Session["tabla_comidas"] = dt_listado_comida;
    }
  
    #endregion 

    #region  Cambio de Iconos

    protected void activar_iconos()
    {
        string vale = "";
        string ingesta = "";
        foreach (DataRow row in dt_listado_comida.Rows)
        {
            int cod_d = Convert.ToInt32(row["_Cod_tipo_comida"].ToString());
            cod_tipo_comida = Convert.ToInt32(row["_Cod_tipo_comida"].ToString());
            cod_alimento_2 = Convert.ToInt32(row["_Cod_tipo_alimento"].ToString());
            string v = row["_Estado"].ToString();
            vale = row["_Vale_impreso"].ToString();
            ingesta = row["_Ingesta"].ToString();


            switch (cod_d)
            {
                case 1:
                    if (ingesta != "S")
                    {
                        if (vale != "S")
                        {
                            if (v == "S")
                            {
                                if (cod_alimento_2 == 0)
                                {
                                    img_d.ImageUrl = "~/Imagenes/Botones/on.png";
                                    img_d_2.ImageUrl = "~/Imagenes/Almuerzos/desa_1.jpg";
                                    img_d.Enabled = true;
                                    img_d_2.Enabled = true;
                                }
                                else
                                {
                                    img_d_2.ImageUrl = "~/Imagenes/Botones/ck.png";
                                    img_d.ImageUrl = "~/Imagenes/Botones/on.png";
                                    img_d.Enabled = true;
                                    img_d_2.Enabled = true;

                                }

                            }
                            else
                            {
                                img_d.ImageUrl = "~/Imagenes/Botones/off.png";
                                img_d_2.ImageUrl = "~/Imagenes/Almuerzos/desa_1.jpg";
                                img_d.Enabled = true;
                                img_d_2.Enabled = false;
                            }
                        }
                        else
                        {
                         
                            img_d_2.ImageUrl = "~/Imagenes/Botones/Imprimir.png";
                            img_d_2.ToolTip = "Tipo Comida posee  vale Impreso";
                            if (v == "S")
                            {
                                img_d.ImageUrl = "~/Imagenes/Botones/on.png";
                                img_d.Enabled = true;
                                img_d_2.Enabled = true;
                            }
                            else
                            {
                                img_d.ImageUrl = "~/Imagenes/Botones/off.png";
                                img_d.Enabled = false;
                                img_d_2.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        
                        img_d_2.ImageUrl = "~/Imagenes/Botones/ingesta.png";
                        img_d_2.ToolTip = "Tipo Comida posee Ingesta";
                        if (v == "S")
                        {
                            img_d.ImageUrl = "~/Imagenes/Botones/on.png";
                            img_d.Enabled = true;
                            img_d_2.Enabled = true;
                        }
                        else
                        {
                            img_d.ImageUrl = "~/Imagenes/Botones/off.png";
                            img_d.Enabled = false;
                            img_d_2.Enabled = false;
                        }


                    }

                    break;
                case 2:

                    if (ingesta != "S")
                    {
                    if (vale != "S")
                    {
                        if (v == "S")
                        {
                            if (cod_alimento_2 == 0)
                            {
                                img_c1.ImageUrl = "~/Imagenes/Botones/on.png";
                                img_c1_2.ImageUrl = "~/Imagenes/Almuerzos/cola_1.jpg";
                                img_c1.Enabled = true;
                                img_c1_2.Enabled = true;
                            }
                            else
                            {
                                img_c1.ImageUrl = "~/Imagenes/Botones/on.png";
                                img_c1_2.ImageUrl = "~/Imagenes/Botones/ck.png";
                                img_c1.Enabled = true;
                                img_c1_2.Enabled = true;

                            }

                        }
                        else
                        {
                            img_c1.ImageUrl = "~/Imagenes/Botones/off.png";
                            img_c1_2.ImageUrl = "~/Imagenes/Almuerzos/cola_1.jpg";
                            img_c1.Enabled = true;
                            img_c1_2.Enabled = false;
                        }
                    }
                    else
                    {
                    
                        img_c1_2.ImageUrl = "~/Imagenes/Botones/Imprimir.png";
                        img_c1_2.ToolTip = "Tipo Comida posee  vale Impreso";
                        if (v == "S")
                        {
                            img_c1.ImageUrl = "~/Imagenes/Botones/on.png";
                            img_c1.Enabled = true;
                            img_c1_2.Enabled = true;
                        }
                        else
                        {
                            img_c1.ImageUrl = "~/Imagenes/Botones/off.png";
                            img_c1.Enabled = false;
                            img_c1_2.Enabled = false;
                        }
                    }

                      }
                    else
                    {
                        
                        img_c1_2.ImageUrl = "~/Imagenes/Botones/ingesta.png";
                        img_c1_2.ToolTip = "Tipo Comida posee  Ingesta";
                        if (v == "S")
                        {
                            img_c1.ImageUrl = "~/Imagenes/Botones/on.png";
                            img_c1.Enabled = true;
                            img_c1_2.Enabled = true;
                        }
                        else
                        {
                            img_c1.ImageUrl = "~/Imagenes/Botones/off.png";
                            img_c1.Enabled = false;
                            img_c1_2.Enabled = false;
                        }


                    }


                    break;
                case 3:
                    if (ingesta != "S")
                    {
                        if (vale != "S")
                        {
                            if (v == "S")
                            {
                                if (cod_alimento_2 == 0)
                                {
                                    img_a.ImageUrl = "~/Imagenes/Botones/on.png";
                                    img_a_2.ImageUrl = "~/Imagenes/Almuerzos/almu_4.jpg";
                                    img_a.Enabled = true;
                                    img_a_2.Enabled = true;
                                }
                                else
                                {
                                    img_a.ImageUrl = "~/Imagenes/Botones/on.png";
                                    img_a_2.ImageUrl = "~/Imagenes/Botones/ck.png";
                                    img_a.Enabled = true;
                                    img_a_2.Enabled = true;

                                }

                            }
                            else
                            {
                                img_a.ImageUrl = "~/Imagenes/Botones/off.png";
                                img_a_2.ImageUrl = "~/Imagenes/Almuerzos/almu_4.jpg";
                                img_a.Enabled = true;
                                img_a_2.Enabled = false;
                            }
                        }
                        else
                        {
                         
                            img_a_2.ImageUrl = "~/Imagenes/Botones/Imprimir.png";
                            img_a_2.ToolTip = "Tipo Comida posee  Vale Impreso";
                            if (v == "S")
                            {
                                img_a.ImageUrl = "~/Imagenes/Botones/on.png";
                                img_a.Enabled = true;
                                img_a_2.Enabled = true;
                            }
                            else
                            {
                                img_a.ImageUrl = "~/Imagenes/Botones/off.png";
                                img_a.Enabled = false;
                                img_a_2.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                       
                        img_a_2.ImageUrl = "~/Imagenes/Botones/ingesta.png";
                        img_a_2.ToolTip = "Tipo Comida posee Ingesta";
                        if (v == "S")
                        {
                            img_a.ImageUrl = "~/Imagenes/Botones/on.png";
                            img_a.Enabled = true;
                            img_a_2.Enabled = true;
                        }
                        else
                        {
                            img_a.ImageUrl = "~/Imagenes/Botones/off.png";
                            img_a.Enabled = false;
                            img_a_2.Enabled = false;
                        }


                    }


                    break;
                case 4:
                    if (ingesta != "S")
                    {
                        if (vale != "S")
                        {
                            if (v == "S")
                            {
                                if (cod_alimento_2 == 0)
                                {
                                    img_o.ImageUrl = "~/Imagenes/Botones/on.png";
                                    img_o_2.ImageUrl = "~/Imagenes/Almuerzos/desa_1.jpg";
                                    img_o.Enabled = true;
                                    img_o_2.Enabled = true;
                                }
                                else
                                {
                                    img_o.ImageUrl = "~/Imagenes/Botones/on.png";
                                    img_o_2.ImageUrl = "~/Imagenes/Botones/ck.png";
                                    img_o.Enabled = true;
                                    img_o_2.Enabled = true;

                                }

                            }
                            else
                            {
                                img_o.ImageUrl = "~/Imagenes/Botones/off.png";
                                img_o_2.ImageUrl = "~/Imagenes/Almuerzos/desa_1.jpg";
                                img_o.Enabled = true;
                                img_o_2.Enabled = false;
                            }
                        }
                        else
                        {
                          
                            img_o_2.ImageUrl = "~/Imagenes/Botones/Imprimir.png";
                            img_o_2.ToolTip = "Tipo Comida posee Vale Impreso";
                            if (v == "S")
                            {
                                img_o.ImageUrl = "~/Imagenes/Botones/on.png";
                                img_o.Enabled = true;
                                img_o_2.Enabled = true;
                            }
                            else
                            {
                                img_o.ImageUrl = "~/Imagenes/Botones/off.png";
                                img_o.Enabled = false;
                                img_o_2.Enabled = false;
                            }
                        }
                    }

                        
                    else
                    {
                        
                        img_o_2.ImageUrl = "~/Imagenes/Botones/ingesta.png";
                        img_o_2.ToolTip = "Tipo Comida posee Ingesta";
                        if (v == "S")
                        {
                            img_o.ImageUrl = "~/Imagenes/Botones/on.png";
                            img_o.Enabled = true;
                            img_o_2.Enabled = true;
                        }
                        else
                        {
                            img_o.ImageUrl = "~/Imagenes/Botones/off.png";
                            img_o.Enabled = false;
                            img_o_2.Enabled = false;
                        }


                    }

                    break;
                case 5:

                    if (ingesta != "S")
                    {
                        if (vale != "S")
                        {
                            if (v == "S")
                            {
                                if (cod_alimento_2 == 0)
                                {
                                    img_c.ImageUrl = "~/Imagenes/Botones/on.png";
                                    img_c_2.ImageUrl = "~/Imagenes/Almuerzos/almu_4.jpg";
                                    img_c.Enabled = true;
                                    img_c_2.Enabled = true;
                                }
                                else
                                {
                                    img_c.ImageUrl = "~/Imagenes/Botones/on.png";
                                    img_c_2.ImageUrl = "~/Imagenes/Botones/ck.png";
                                    img_c.Enabled = true;
                                    img_c_2.Enabled = true;

                                }

                            }
                            else
                            {
                                img_c.ImageUrl = "~/Imagenes/Botones/off.png";
                                img_c_2.ImageUrl = "~/Imagenes/Almuerzos/almu_4.jpg";
                                img_c.Enabled = true;
                                img_c_2.Enabled = false;
                            }
                        }
                        else
                        {
                          
                            img_c_2.ImageUrl = "~/Imagenes/Botones/Imprimir.png";
                            img_c_2.ToolTip = "Tipo Comida posee Vale Impreso";
                            if (v == "S")
                            {
                                img_c.ImageUrl = "~/Imagenes/Botones/on.png";
                                img_c.Enabled = true;
                                img_c_2.Enabled = true;
                            }
                            else
                            {
                                img_c.ImageUrl = "~/Imagenes/Botones/off.png";
                                img_c.Enabled = false;
                                img_c_2.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                       
                        img_c_2.ImageUrl = "~/Imagenes/Botones/ingesta.png";
                        img_c_2.ToolTip = "Tipo Comida posee Ingesta";
                        if (v == "S")
                        {
                            img_c.ImageUrl = "~/Imagenes/Botones/on.png";
                            img_c.Enabled = true;
                            img_c_2.Enabled = true;
                        }
                        else
                        {
                            img_c.ImageUrl = "~/Imagenes/Botones/off.png";
                            img_c.Enabled = false;
                            img_c_2.Enabled = false;
                        }


                    }

                    break;
                case 6:
                    if (ingesta != "S")
                    {
                        if (vale != "S")
                        {
                            if (v == "S")
                            {
                                if (cod_alimento_2 == 0)
                                {
                                    img_c2.ImageUrl = "~/Imagenes/Botones/on.png";
                                    img_c2_2.ImageUrl = "~/Imagenes/Almuerzos/cola_1.jpg";
                                    img_c2.Enabled = true;
                                    img_c2_2.Enabled = true;
                                }
                                else
                                {
                                    img_c2.ImageUrl = "~/Imagenes/Botones/on.png";
                                    img_c2_2.ImageUrl = "~/Imagenes/Botones/ck.png";
                                    img_c2.Enabled = true;
                                    img_c2_2.Enabled = true;

                                }

                            }
                            else
                            {
                                img_c2.ImageUrl = "~/Imagenes/Botones/off.png";
                                img_c2_2.ImageUrl = "~/Imagenes/Almuerzos/cola_1.jpg";
                                img_c2.Enabled = true;
                                img_c2_2.Enabled = false;
                            }
                        }
                        else
                        {
                  
                            img_c2_2.ImageUrl = "~/Imagenes/Botones/Imprimir.png";
                            img_c2_2.ToolTip = "Tipo Comida posee Vale Impreso";
                            if (v == "S")
                            {
                                img_c2.ImageUrl = "~/Imagenes/Botones/on.png";
                                img_c2.Enabled = true;
                                img_c2_2.Enabled = true;
                            }
                            else
                            {
                                img_c2.ImageUrl = "~/Imagenes/Botones/off.png";
                                img_c2.Enabled = false;
                                img_c2_2.Enabled = false;
                            }
                        }
                    }

                    else
                    {
                        
                        img_c2_2.ImageUrl = "~/Imagenes/Botones/ingesta.png";
                        img_c2_2.ToolTip = "Tipo Comida posee Ingesta";
                        if (v == "S")
                        {
                            img_c2.ImageUrl = "~/Imagenes/Botones/on.png";
                            img_c2.Enabled = true;
                            img_c2_2.Enabled = true;
                        }
                        else
                        {
                            img_c2.ImageUrl = "~/Imagenes/Botones/off.png";
                            img_c2.Enabled = false;
                            img_c2_2.Enabled = false;
                        }


                    }


                    break;
                case 7:
                    if (ingesta != "S")
                    {
                        if (vale != "S")
                        {
                            if (v == "S")
                            {
                                if (cod_alimento_2 == 0)
                                {
                                    img_ce.ImageUrl = "~/Imagenes/Botones/on.png";
                                    img_ce_2.ImageUrl = "~/Imagenes/Almuerzos/cola_1.jpg";
                                    img_ce.Enabled = true;
                                    img_ce_2.Enabled = true;
                                }
                                else
                                {
                                    img_ce_2.ImageUrl = "~/Imagenes/Botones/ck.png";
                                    img_ce.ImageUrl = "~/Imagenes/Botones/on.png";
                                    img_ce.Enabled = true;
                                    img_ce_2.Enabled = true;

                                }

                            }
                            else
                            {
                                img_ce.ImageUrl = "~/Imagenes/Botones/off.png";
                                img_ce_2.ImageUrl = "~/Imagenes/Almuerzos/cola_1.jpg";
                                img_ce.Enabled = true;
                                img_ce_2.Enabled = false;
                            }
                        }
                        else
                        {
                        
                            img_ce_2.ImageUrl = "~/Imagenes/Botones/Imprimir.png";
                            img_ce_2.ToolTip = "Tipo Comida posee Vale Impreso";
                            if (v == "S")
                            {
                                img_ce.ImageUrl = "~/Imagenes/Botones/on.png";
                                img_ce.Enabled = true;
                                img_ce_2.Enabled = true;
                            }
                            else
                            {
                                img_ce.ImageUrl = "~/Imagenes/Botones/off.png";
                                img_ce.Enabled = false;
                                img_ce_2.Enabled = false;
                            }
                        }
                    }
                 
                    else
                    {
                        
                        img_ce_2.ImageUrl = "~/Imagenes/Botones/ingesta.png";
                        img_ce_2.ToolTip = "Tipo Comida posee Ingesta";
                        if (v == "S")
                        {
                            img_ce.ImageUrl = "~/Imagenes/Botones/on.png";
                            img_ce.Enabled = true;
                            img_ce_2.Enabled = true;
                        }
                        else
                        {
                            img_ce.ImageUrl = "~/Imagenes/Botones/off.png";
                            img_ce.Enabled = false;
                            img_ce_2.Enabled = false;
                        }


                    }

                    break;

                case 8:
                    if (ingesta != "S")
                    {
                        if (vale != "S")
                        {
                            if (v == "S")
                            {
                                if (cod_alimento_2 == 0)
                                {
                                    img_hco.ImageUrl = "~/Imagenes/Botones/on.png";
                                    img_hco_2.ImageUrl = "~/Imagenes/Almuerzos/hidri_1.jpg";
                                    img_hco.Enabled = true;
                                    img_hco_2.Enabled = true;
                                }
                                else
                                {
                                    img_hco_2.ImageUrl = "~/Imagenes/Botones/ck.png";
                                    img_hco.ImageUrl = "~/Imagenes/Botones/on.png";
                                    img_hco.Enabled = true;
                                    img_hco_2.Enabled = true;

                                }

                            }
                            else
                            {
                                img_hco.ImageUrl = "~/Imagenes/Botones/off.png";
                                img_hco_2.ImageUrl = "~/Imagenes/Almuerzos/hidri_1.jpg";
                                img_hco.Enabled = true;
                                img_hco_2.Enabled = false;
                            }
                        }
                        else
                        {
                           
                            img_hco_2.ImageUrl = "~/Imagenes/Botones/Imprimir.png";
                            img_hco_2.ToolTip = "Tipo Comida posee Vale Impreso";
                            if (v == "S")
                            {
                                img_hco.ImageUrl = "~/Imagenes/Botones/on.png";
                                img_hco.Enabled = true;
                                img_hco_2.Enabled = true;
                            }
                            else
                            {
                                img_hco.ImageUrl = "~/Imagenes/Botones/off.png";
                                img_hco.Enabled = false;
                                img_hco_2.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                       
                        img_hco_2.ImageUrl = "~/Imagenes/Botones/ingesta.png";
                        img_hco_2.ToolTip = "Tipo Comida posee Ingesta";
                        if (v == "S")
                        {
                            img_hco.ImageUrl = "~/Imagenes/Botones/on.png";
                            img_hco.Enabled = true;
                            img_hco_2.Enabled = true;
                        }
                        else
                        {
                            img_hco.ImageUrl = "~/Imagenes/Botones/off.png";
                            img_hco.Enabled = false;
                            img_hco_2.Enabled = false;
                        }


                    }


                    break;




                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }
    }
    #endregion

    #region  Extraer opc_comida

    protected void Extraer_opc_comida()
    {
        Pedidos p = new PedidosNE().Extraer_opc_comida(cod_pedido);
        opc_ck = p._Cod_opc_comida;
                 
    }
    #endregion 

    #region Guardar Pedido

    protected void registrar_pedido()
    {
        
        int c = 0;
        int c_estado = 0;
        string paciente = Session["Cod_paciente"].ToString();
        string cama = Session["Cod_cama"].ToString();
        string user = Session["Usuario"].ToString();

        if (ck_ayuno.Checked == true)
        {
            comentario = txtobservacion.Text.ToUpper();
            cod_opc_comida = 1;
            c_estado = 6;
        }
        else
        {
            if (ck_alimen_oral.Checked == true)
            {
                comentario = txtobservacion.Text.ToUpper();
                cod_opc_comida = 2;
                c_estado = 3;
                habilitacion_total();

            }
            else
            {
                if (ck_nut_oral.Checked == true)
                {
                    comentario = txtobservacion.Text.ToUpper();
                    cod_opc_comida = 3;
                    c_estado = 4;
                    habilitacion_total();
                }
                else
                {

                    if (ck_nut_parenteral.Checked == true)
                    {
                        comentario = txtobservacion.Text.ToUpper();
                        cod_opc_comida = 4;
                        c_estado = 5;
                        habilitacion_total();

                    }
                    else
                    {
                        if (ck_cero_boca.Checked == true)
                        {
                            comentario = txtobservacion.Text.ToUpper();
                            cod_opc_comida = 5;
                            c_estado = 7;
                            bloqueo_total();
                        }
                    }
                }
            }
        }
   
        if (cod_pedido == "0")
        {
            string vig = Session["VIG"].ToString();
            if (vig != "M")
            {
                string msg = new PedidosNE().Registrar_Pedido(cod_consistencia, cod_digestabilidad, cod_cobro, cod_lactosa, cod_dulzor, cod_sal, user, cama, paciente, cod_opc_comida, comentario, cod_aislamiento, c_estado);
                cod_pedido = msg;
                Session["_Cod_pedido"] = cod_pedido;
            }
            else
            {
                string fecha=Session["FECH_M"].ToString();
                string msg = new PedidosNE().Registrar_Pedido(cod_consistencia, cod_digestabilidad, cod_cobro, cod_lactosa, cod_dulzor, cod_sal, user, cama, paciente, cod_opc_comida, comentario, cod_aislamiento, c_estado,fecha);
                cod_pedido = msg;
                Session["_Cod_pedido"] = cod_pedido;
            }
        }
        else
        {
            Session["_Cod_pedido"] = cod_pedido;
            string msg = new PedidosNE().Modificar_Pedido(cod_pedido, cod_consistencia, cod_digestabilidad, cod_cobro, cod_lactosa, cod_dulzor, cod_sal, user, cama, paciente, cod_opc_comida, comentario, cod_aislamiento, c_estado);
            // validar_existe_pedido();
        }

       registrar_opc_comida();
    }

    protected void registrar_opc_comida()
    {
        Extraer_opc_comida();
         dt_listado_comida = (DataTable)Session["tabla_comidas"];
         if (dt_listado_comida.Rows.Count > 0)
         {
             foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_desayuno + "'"))
             {
                 string x = row["_Estado"].ToString();
                 if (x != "")
                 {
                     val_d = x;
                 }

             }
             foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_colacion_matinal + "'"))
             {

                 string x = row["_Estado"].ToString();
                 if (x != "")
                 {
                     val_c1 = x;
                 }
             }
             foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_almuerzo + "'"))
             {

                 string x = row["_Estado"].ToString();
                 if (x != "")
                 {
                     val_a = x;
                 }
             }
             foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_once + "'"))
             {

                 string x = row["_Estado"].ToString();
                 if (x != "")
                 {
                     val_o = x;
                 }
             }
             foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_cena + "'"))
             {

                 string x = row["_Estado"].ToString();
                 if (x != "")
                 {
                     val_c = x;
                 }
             }
             foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_colacion_nocturna + "'"))
             {

                 string x = row["_Estado"].ToString();
                 if (x != "")
                 {
                     val_c2 = x;
                 }
             }

             foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_colacion_extra + "'"))
             {

                 string x = row["_Estado"].ToString();
                 if (x != "")
                 {
                     val_ce = x;
                 }
             }

             foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_hidricos + "'"))
             {

                 string x = row["_Estado"].ToString();
                 if (x != "")
                 {
                     val_hco = x;
                 }
             }

             if (opc_ck != cod_opc_comida)
             {
                 string msg = new PedidosNE().Registrar_opc_comida(cod_pedido, cod_consistencia, cod_digestabilidad, cod_cobro, cod_lactosa, cod_dulzor, cod_sal, user, cod_opc_comida, comentario, cod_aislamiento, val_d, val_c1, val_a, val_o, val_c, val_c2, val_ce, val_hco);
                 id_opc_comida = Convert.ToInt32(msg);

             }
             else
             {
                 string msg = new PedidosNE().Modificar_opc_comida(id_opc_comida, cod_pedido, cod_consistencia, cod_digestabilidad, cod_cobro, cod_lactosa, cod_dulzor, cod_sal, user, cod_opc_comida, comentario, cod_aislamiento, val_d, val_c1, val_a, val_o, val_c, val_c2, val_ce, val_hco);

             }
         }

       
  
    }


    #endregion 

    #region registrar_tipo_comida

    protected void Registrar_tipo_comida()
    {

        int cod = 0;
        int id = 0;
        string v = "";
        dt_listado_comida = (DataTable)Session["tabla_comidas"];
        foreach (DataRow row in dt_listado_comida.Rows)
        {
            id = Convert.ToInt32(row["_Id_tipo_comida"].ToString());
            cod = Convert.ToInt32(row["_Cod_tipo_comida"].ToString());
            v = row["_Estado"].ToString();

            if (id == 0  && cod >0)
            {
                string msg = new Menu_tipo_comidaNE().Registrar_Tipo_Comida(Convert.ToInt32(cod_pedido), cod, user, v);

            }
            else
            {
                string msg = new Menu_tipo_comidaNE().Modificar_Tipo_Comida(Convert.ToInt32(cod_pedido), id, user, v);

            }

        }


    }

    protected void Registrar_tipo_comida(int cod)
    {

        int id = 0;
        string v = "S";
        dt_listado_comida = (DataTable)Session["tabla_comidas"];
        foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + cod + "'"))
        {

            id = Convert.ToInt32(row["_Id_tipo_comida"].ToString());
            cod = Convert.ToInt32(row["_Cod_tipo_comida"].ToString());
            v = row["_Estado"].ToString();

        }
        string msg = new Menu_tipo_comidaNE().Modificar_Tipo_Comida(Convert.ToInt32(cod_pedido), id, user, v);

        validar_existe_tipo_comida_activo();

    }

    #endregion 

    #region  Cambiar Estados y Eliminacion de Alimentos

    protected void cambiar_estado_tipo_alimento()
    {
        string msg = "";
        string user = Session["Usuario"].ToString();
        string paciente = Session["Cod_paciente"].ToString();
        string cod_tipo_comida = Session["_Cod_tipo_comida"].ToString();
        dt_listado_comida = (DataTable)Session["tabla_comidas"];
        foreach (DataRow miRow1 in dt_listado_comida.Select("_Cod_tipo_comida = '" + cod_tipo_comida + "'"))
        {
            id_tipo_comida = Convert.ToInt32(miRow1["_Id_tipo_comida"].ToString());
        }

        if (id_tipo_comida > 0)
        {
            msg = new PedidosNE().Eliminar_Pedido(user, cod_pedido, cod_tipo_comida, id_tipo_comida, paciente);
        }

        if (msg == "ok")
        {
        }
        else
        {

        }
    }

    protected void cambiar_estado()
    {
        int var = Convert.ToInt32(Session["_Cod_tipo_comida"].ToString());
        switch (var)
        {
            case 1:
                cambiar_estado(var_cod_desayuno);
                break;
            case 2:

                cambiar_estado(var_cod_colacion_matinal);
                break;
            case 3:

                cambiar_estado(var_cod_almuerzo);

                break;
            case 4:

                cambiar_estado(var_cod_once);

                break;
            case 5:
                cambiar_estado(var_cod_cena);

                break;
            case 6:

                cambiar_estado(var_cod_colacion_nocturna);

                break;
            case 7:

                cambiar_estado(var_cod_colacion_extra);
                break;

            case 8:

                cambiar_estado(var_cod_hidricos);

                break;



            default:
                Console.WriteLine("Default case");
                break;
        }




    }

    protected void cambiar_estado(int var)
    {

        int cont = 0;
        switch (var)
        {
            case 1:

                dt_listado_comida = (DataTable)Session["tabla_comidas"];
                if (Convert.ToInt32(cod_pedido) > 0)
                {
                    Session["_Cod_tipo_comida"] = var_cod_desayuno;

                    foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_desayuno + "'"))
                    {
                        string v = row["_Estado"].ToString();
                        string i = row["_Ingesta"].ToString();
                        if(i!="S")
                        {
                            int alimentos = Convert.ToInt32(row["_Cod_tipo_alimento"].ToString());
                            if (v == "S")
                            {

                                v = "N";
                                row["_Estado"] = v;
                                img_d.ImageUrl = "~/Imagenes/Botones/off.png";
                                img_d_2.ImageUrl = "~/Imagenes/Almuerzos/desa_1.jpg";


                            }
                            else
                            {
                                v = "S";
                                row["_Estado"] = v;
                                img_d.ImageUrl = "~/Imagenes/Botones/on.png";
                            }
                       }

                        dt_listado_comida.AcceptChanges();
                        Session["tabla_comidas"] = dt_listado_comida;
                    }
                }
                else
                {
                    txtmsg.Text = "Estimado Usuario, debe registrar el pedido";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);
                }


                break;
            case 2:

                dt_listado_comida = (DataTable)Session["tabla_comidas"];
                if (Convert.ToInt32(cod_pedido) > 0)
                {

                    foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_colacion_matinal + "'"))
                    {
                        string v = row["_Estado"].ToString();
                         string i = row["_Ingesta"].ToString();
                         if (i != "S")
                         {

                             if (v == "S")
                             {
                                 v = "N";
                                 row["_Estado"] = v;
                                 img_c1.ImageUrl = "~/Imagenes/Botones/off.png";
                                 img_c1_2.ImageUrl = "~/Imagenes/Almuerzos/cola_1.jpg";

                             }
                             else
                             {
                                 v = "S";
                                 row["_Estado"] = v;
                                 img_c1.ImageUrl = "~/Imagenes/Botones/on.png";
                             }
                         }

                        dt_listado_comida.AcceptChanges();
                        Session["tabla_comidas"] = dt_listado_comida;


                    }
                }
                else
                {
                    txtmsg.Text = "Estimado Usuario, debe registrar el pedido";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);
                }




                break;
            case 3:

                dt_listado_comida = (DataTable)Session["tabla_comidas"];
                if (Convert.ToInt32(cod_pedido) > 0)
                {
                    foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_almuerzo + "'"))
                    {
                        string v = row["_Estado"].ToString();
                         string i = row["_Ingesta"].ToString();
                         if (i != "S")
                         {

                             if (v == "S")
                             {
                                 v = "N";
                                 row["_Estado"] = v;
                                 img_a.ImageUrl = "~/Imagenes/Botones/off.png";
                                 img_a_2.ImageUrl = "~/Imagenes/Almuerzos/almu_4.jpg";

                             }
                             else
                             {
                                 v = "S";
                                 row["_Estado"] = v;
                                 img_a.ImageUrl = "~/Imagenes/Botones/on.png";
                             }
                         }

                        dt_listado_comida.AcceptChanges();
                        Session["tabla_comidas"] = dt_listado_comida;


                    }
                }
                else
                {
                    txtmsg.Text = "Estimado Usuario, debe registrar el pedido";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);
                }


                break;
            case 4:

                dt_listado_comida = (DataTable)Session["tabla_comidas"];
                if (Convert.ToInt32(cod_pedido) > 0)
                {
                    foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_once + "'"))
                    {
                        string v = row["_Estado"].ToString();
                         string i = row["_Ingesta"].ToString();
                         if (i != "S")
                         {

                             if (v == "S")
                             {
                                 v = "N";
                                 row["_Estado"] = v;
                                 img_o.ImageUrl = "~/Imagenes/Botones/off.png";
                                 img_o_2.ImageUrl = "~/Imagenes/Almuerzos/desa_1.jpg";

                             }
                             else
                             {
                                 v = "S";
                                 row["_Estado"] = v;
                                 img_o.ImageUrl = "~/Imagenes/Botones/on.png";
                             }
                         }

                        dt_listado_comida.AcceptChanges();
                        Session["tabla_comidas"] = dt_listado_comida;


                    }
                }
                else
                {
                    txtmsg.Text = "Estimado Usuario, debe registrar el pedido";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);
                }

                break;
            case 5:
                dt_listado_comida = (DataTable)Session["tabla_comidas"];
                if (Convert.ToInt32(cod_pedido) > 0)
                {
                    foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_cena + "'"))
                    {
                        string v = row["_Estado"].ToString();
                         string i = row["_Ingesta"].ToString();
                         if (i != "S")
                         {

                             if (v == "S")
                             {
                                 v = "N";
                                 row["_Estado"] = v;
                                 img_c.ImageUrl = "~/Imagenes/Botones/off.png";
                                 img_c_2.ImageUrl = "~/Imagenes/Almuerzos/almu_4.jpg";

                             }
                             else
                             {
                                 v = "S";
                                 row["_Estado"] = v;
                                 img_c.ImageUrl = "~/Imagenes/Botones/on.png";
                             }
                         }

                        dt_listado_comida.AcceptChanges();
                        Session["tabla_comidas"] = dt_listado_comida;


                    }

                }
                else
                {
                    txtmsg.Text = "Estimado Usuario, debe registrar el pedido";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);
                }

                break;
            case 6:

                dt_listado_comida = (DataTable)Session["tabla_comidas"];
                if (Convert.ToInt32(cod_pedido) > 0)
                {

                    foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_colacion_nocturna + "'"))
                    {
                        string v = row["_Estado"].ToString();
                         string i = row["_Ingesta"].ToString();
                         if (i != "S")
                         {

                             if (v == "S")
                             {
                                 v = "N";
                                 row["_Estado"] = v;
                                 img_c2.ImageUrl = "~/Imagenes/Botones/off.png";
                                 img_c2_2.ImageUrl = "~/Imagenes/Almuerzos/cola_1.jpg";

                             }
                             else
                             {
                                 v = "S";
                                 row["_Estado"] = v;
                                 img_c2.ImageUrl = "~/Imagenes/Botones/on.png";
                             }
                         }

                        dt_listado_comida.AcceptChanges();
                        Session["tabla_comidas"] = dt_listado_comida;

                    }

                }
                else
                {
                    txtmsg.Text = "Estimado Usuario, debe registrar el pedido";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);
                }


                break;
            case 7:

                dt_listado_comida = (DataTable)Session["tabla_comidas"];
                if (Convert.ToInt32(cod_pedido) > 0)
                {

                    Session["_Cod_tipo_comida"] = var_cod_desayuno;

                    foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_colacion_extra + "'"))
                    {
                        string v = row["_Estado"].ToString();
                         string i = row["_Ingesta"].ToString();
                         if (i != "S")
                         {

                             if (v == "S")
                             {
                                 v = "N";
                                 row["_Estado"] = v;
                                 img_ce.ImageUrl = "~/Imagenes/Botones/off.png";
                                 img_ce_2.ImageUrl = "~/Imagenes/Almuerzos/cola_1.jpg";

                             }
                             else
                             {
                                 v = "S";
                                 row["_Estado"] = v;
                                 img_ce.ImageUrl = "~/Imagenes/Botones/on.png";
                             }
                         }

                        dt_listado_comida.AcceptChanges();
                        Session["tabla_comidas"] = dt_listado_comida;


                    }


                }
                else
                {
                    txtmsg.Text = "Estimado Usuario, debe registrar el pedido";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);
                }


                break;

            case 8:
                dt_listado_comida = (DataTable)Session["tabla_comidas"];
                if (Convert.ToInt32(cod_pedido) > 0)
                {
                    foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var_cod_hidricos + "'"))
                    {
                        string v = row["_Estado"].ToString();
                         string i = row["_Ingesta"].ToString();
                         if (i != "S")
                         {

                             if (v == "S")
                             {
                                 v = "N";
                                 row["_Estado"] = v;
                                 img_hco.ImageUrl = "~/Imagenes/Botones/off.png";
                                 img_hco_2.ImageUrl = "~/Imagenes/Almuerzos/hidri_1.jpg";

                             }
                             else
                             {
                                 v = "S";
                                 row["_Estado"] = v;
                                 img_hco.ImageUrl = "~/Imagenes/Botones/on.png";
                             }
                         }

                        dt_listado_comida.AcceptChanges();
                        Session["tabla_comidas"] = dt_listado_comida;


                    }

                }
                else
                {
                    txtmsg.Text = "Estimado Usuario, debe registrar el pedido";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);
                }


                break;



            default:
                Console.WriteLine("Default case");
                break;
        }
    }
         
    protected string eliminar_tipo_alimento()
    {
        string msg = "";
        string user = Session["Usuario"].ToString();
        string paciente = Session["Cod_paciente"].ToString();
        string cod_tipo_comida = Session["_Cod_tipo_comida"].ToString();
        dt_listado_comida = (DataTable)Session["tabla_comidas"];
        foreach (DataRow miRow1 in dt_listado_comida.Select("_Cod_tipo_comida = '" + cod_tipo_comida + "'"))
        {
            id_tipo_comida = Convert.ToInt32(miRow1["_Id_tipo_comida"].ToString());
            id_tipo_distribucion = Convert.ToInt32(miRow1["_Id_tipo_distribucion"].ToString());
        }

        if (id_tipo_comida > 0)
        {
            // msg = new PedidosNE().Eliminar_alimentos_Pedido(user, cod_pedido, cod_tipo_comida, id_tipo_comida, paciente);
            msg = new PedidosNE().Eliminar_Pedido3(id_tipo_comida);
        }

        return msg;
    }

    protected void validar_eliminacion(int cod)
    {
        string res = "";
        string v = "";
        string vale = "";
        dt_listado_comida = (DataTable)Session["tabla_comidas"];
        foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + cod + "'"))
        {
            v = row["_Estado"].ToString();
            vale = row["_Ingesta"].ToString();

            if (vale != "S")
            {
                res = eliminar_tipo_alimento();
                //   activar_iconos();

                if (res == "ok")
                {
                    txtmsg1.Text = "Estimado Usuario, fue Eliminado todos los alimentos  Asociados a este Tipo Comida";
                    Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);

                }


            }
            else
            {
                txtmsg1.Text = "Estimado Usuario, Este alimento no se puede eliminar porque posee Ingesta";
                Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "onLoad", "MostrarLabel();", true);


            }


        }
        validar_existe_tipo_comida_activo();
    }

    protected void Eliminar()
    {
        string res = "";
        int cod_tipo = 0;
        cambiar_estado();
        cod_tipo = Convert.ToInt32(Session["_Cod_tipo_comida"].ToString());

        switch (cod_tipo)
        {
            case 1:
                validar_eliminacion(var_cod_desayuno);
                break;
            case 2:
                validar_eliminacion(var_cod_colacion_matinal);
                break;

            case 3:
                validar_eliminacion(var_cod_almuerzo);
                break;

            case 4:
                validar_eliminacion(var_cod_once);
                break;


            case 5:
                validar_eliminacion(var_cod_cena);
                break;

            case 6:
                validar_eliminacion(var_cod_colacion_nocturna);
                break;

            case 7:
                validar_eliminacion(var_cod_colacion_extra);
                break;

            case 8:
                validar_eliminacion(var_cod_hidricos);
                break;

        }



        activar_iconos();





    }

    #endregion 

    #region Activar

    protected void activar(int var, string vigencia)
    {
        int cont = 0;
 
                dt_listado_comida = (DataTable)Session["tabla_comidas"];
                foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var + "'"))
                {
                    cont++;
                }

                if (cont == 0)
                {
                    DataRow Fila1 = dt_listado_comida.NewRow();

                    Fila1["_Cod_menu"] = cod_pedido;
                    Fila1["_Id_tipo_comida"] = 0;
                    Fila1["_Cod_tipo_comida"] = var;
                    Fila1["_Estado"] = vigencia;

                    if (vigencia == "S")
                    {
                        if (var == 1) { img_d.ImageUrl = "~/Imagenes/Botones/on.png"; }
                        if (var == 2) { img_c1.ImageUrl = "~/Imagenes/Botones/on.png"; }
                        if (var == 3) { img_a.ImageUrl = "~/Imagenes/Botones/on.png"; }
                        if (var == 4) { img_o.ImageUrl = "~/Imagenes/Botones/on.png"; }
                        if (var == 5) { img_c.ImageUrl = "~/Imagenes/Botones/on.png"; }
                        if (var == 6) { img_c2.ImageUrl = "~/Imagenes/Botones/on.png"; }
                        if (var == 7) { img_ce.ImageUrl = "~/Imagenes/Botones/on.png"; }
                        if (var == 8) { img_hco.ImageUrl = "~/Imagenes/Botones/on.png"; }

                    }

                    else
                    {
                        if (var == 1) { img_d.ImageUrl = "~/Imagenes/Botones/off.png"; }
                        if (var == 2) { img_c1.ImageUrl = "~/Imagenes/Botones/off.png"; }
                        if (var == 3) { img_a.ImageUrl = "~/Imagenes/Botones/off.png"; }
                        if (var == 4) { img_o.ImageUrl = "~/Imagenes/Botones/off.png"; }
                        if (var == 5) { img_c.ImageUrl = "~/Imagenes/Botones/off.png"; }
                        if (var == 6) { img_c2.ImageUrl = "~/Imagenes/Botones/off.png"; }
                        if (var == 7) { img_ce.ImageUrl = "~/Imagenes/Botones/off.png"; }
                        if (var == 8) { img_hco.ImageUrl = "~/Imagenes/Botones/off.png"; }

                    }
                    dt_listado_comida.Rows.Add(Fila1);
                    dt_listado_comida.AcceptChanges();
                    Session["tabla_comidas"] = dt_listado_comida;


                }
                else
                {
                    string v = "";
                    int cod = 0;
                    foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + var + "'"))
                    {
                        v = row["_Estado"].ToString();
                        if (row["_Cod_tipo_alimento"].ToString() == "")
                        { cod = 0; }
                        else
                        {
                            cod = Convert.ToInt32(row["_Cod_tipo_alimento"].ToString());

                            if (cod > 0)
                            {
                               v= row["_Estado"].ToString();
                            }
                            else
                            {
                                v = vigencia;
                                row["_Estado"] = vigencia;
                            }



                        }
                        if (cod == 0)
                        {
                            if (v == "S")
                            {
                                if (var == 1) { img_d.ImageUrl = "~/Imagenes/Botones/on.png"; }
                                if (var == 2) { img_c1.ImageUrl = "~/Imagenes/Botones/on.png"; }
                                if (var == 3) { img_a.ImageUrl = "~/Imagenes/Botones/on.png"; }
                                if (var == 4) { img_o.ImageUrl = "~/Imagenes/Botones/on.png"; }
                                if (var == 5) { img_c.ImageUrl = "~/Imagenes/Botones/on.png"; }
                                if (var == 6) { img_c2.ImageUrl = "~/Imagenes/Botones/on.png"; }
                                if (var == 7) { img_ce.ImageUrl = "~/Imagenes/Botones/on.png"; }
                                if (var == 8) { img_hco.ImageUrl = "~/Imagenes/Botones/on.png"; }

                            }

                            else
                            {
                                if (var == 1) { img_d.ImageUrl = "~/Imagenes/Botones/off.png"; }
                                if (var == 2) { img_c1.ImageUrl = "~/Imagenes/Botones/off.png"; }
                                if (var == 3) { img_a.ImageUrl = "~/Imagenes/Botones/off.png"; }
                                if (var == 4) { img_o.ImageUrl = "~/Imagenes/Botones/off.png"; }
                                if (var == 5) { img_c.ImageUrl = "~/Imagenes/Botones/off.png"; }
                                if (var == 6) { img_c2.ImageUrl = "~/Imagenes/Botones/off.png"; }
                                if (var == 7) { img_ce.ImageUrl = "~/Imagenes/Botones/off.png"; }
                                if (var == 8) { img_hco.ImageUrl = "~/Imagenes/Botones/off.png"; }

                            }
                        }
                        else
                        {
                            if (v == "S")
                            {
                                if (var == 1) { img_d.ImageUrl = "~/Imagenes/Botones/on.png"; }
                                if (var == 2) { img_c1.ImageUrl = "~/Imagenes/Botones/on.png"; }
                                if (var == 3) { img_a.ImageUrl = "~/Imagenes/Botones/on.png"; }
                                if (var == 4) { img_o.ImageUrl = "~/Imagenes/Botones/on.png"; }
                                if (var == 5) { img_c.ImageUrl = "~/Imagenes/Botones/on.png"; }
                                if (var == 6) { img_c2.ImageUrl = "~/Imagenes/Botones/on.png"; }
                                if (var == 7) { img_ce.ImageUrl = "~/Imagenes/Botones/on.png"; }
                                if (var == 8) { img_hco.ImageUrl = "~/Imagenes/Botones/on.png"; }

                            }

                            else
                            {
                                if (var == 1) { img_d.ImageUrl = "~/Imagenes/Botones/off.png"; }
                                if (var == 2) { img_c1.ImageUrl = "~/Imagenes/Botones/off.png"; }
                                if (var == 3) { img_a.ImageUrl = "~/Imagenes/Botones/off.png"; }
                                if (var == 4) { img_o.ImageUrl = "~/Imagenes/Botones/off.png"; }
                                if (var == 5) { img_c.ImageUrl = "~/Imagenes/Botones/off.png"; }
                                if (var == 6) { img_c2.ImageUrl = "~/Imagenes/Botones/off.png"; }
                                if (var == 7) { img_ce.ImageUrl = "~/Imagenes/Botones/off.png"; }
                                if (var == 8) { img_hco.ImageUrl = "~/Imagenes/Botones/off.png"; }

                            }

                        }


                        dt_listado_comida.AcceptChanges();
                        Session["tabla_comidas"] = dt_listado_comida;

                    }
                }




    }

    #endregion 

    #region  Ckeck

    protected void cambiar_ck()
    {
        if (ck_ayuno.Checked == true)
        {
            comen.Text = "Ayuno";
           cod_opc_comida = 1;
           txtobservacion.Text = "";
           bloqueo_parcial();
           ck_alimen_oral.Checked = false;
           ck_nut_oral.Checked = false;
           ck_nut_parenteral.Checked = false;
           ck_cero_boca.Checked = false;

           btn_b_ayuno.Visible = true;
           btn_b_alim_oral.Visible = false;
           btn_b_cero_boca.Visible = false;
           btn_b_nut_oral.Visible = false;
           btn_b_nut_parenteral.Visible = false;
            
       

            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { info_comentario(); });", true);
            if (Convert.ToInt32(cod_pedido) == 0)
            {
                activar(var_cod_desayuno, "N");
                 activar(var_cod_colacion_matinal, "N");
                 activar(var_cod_almuerzo, "N");
                 activar(var_cod_once, "N");
                 activar(var_cod_cena, "N");
                 activar(var_cod_colacion_nocturna, "N");
                 activar(var_cod_colacion_extra, "N");
                 activar(var_cod_hidricos, "S");

            }

            else
            {

                verificar_2(var_cod_desayuno);
                verificar_2(var_cod_colacion_matinal);
                verificar_2(var_cod_almuerzo);
                verificar_2(var_cod_once);
                verificar_2(var_cod_cena);
                verificar_2(var_cod_colacion_nocturna);
                verificar_2(var_cod_colacion_extra);
                verificar_2(var_cod_hidricos);

            }
        }
        else
        {
            if (ck_alimen_oral.Checked == true)
            {
                cod_opc_comida = 2;
                txtobservacion.Text = "";
                habilitacion_total();
                comen.Text = "Alimentación Oral";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { info_comentario(); });", true);
                ck_nut_oral.Checked = false;
                ck_nut_parenteral.Checked = false;
                ck_ayuno.Checked = false;
                ck_cero_boca.Checked = false;

                btn_b_ayuno.Visible = false;
                btn_b_alim_oral.Visible = true;
                btn_b_cero_boca.Visible = false;
                btn_b_nut_oral.Visible = false;
                btn_b_nut_parenteral.Visible = false;

                if (Convert.ToInt32(cod_pedido) == 0)
                {

                    activar(var_cod_desayuno, "S");
                    activar(var_cod_colacion_matinal, "S");
                    activar(var_cod_almuerzo, "S");
                    activar(var_cod_once, "S");
                    activar(var_cod_cena, "S");
                    activar(var_cod_colacion_nocturna, "S");
                    activar(var_cod_colacion_extra, "S");
                    activar(var_cod_hidricos, "S");
                }
                else
                {

                    verificar_2(var_cod_desayuno);
                    verificar_2(var_cod_colacion_matinal);
                    verificar_2(var_cod_almuerzo);
                    verificar_2(var_cod_once);
                    verificar_2(var_cod_cena);
                    verificar_2(var_cod_colacion_nocturna);
                    verificar_2(var_cod_colacion_extra);
                    verificar_2(var_cod_hidricos);
                  
                }
         
            }
            else
            {
                if (ck_nut_oral.Checked == true)
                {
                    comen.Text = "Nutrición Oral";
                    cod_opc_comida = 3;
                    txtobservacion.Text = "";
                    habilitacion_total();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { info_comentario(); });", true);
                    ck_alimen_oral.Checked = false;
                    ck_nut_parenteral.Checked = false;
                    ck_ayuno.Checked = false;
                    ck_cero_boca.Checked = false;

                    btn_b_ayuno.Visible = false;
                    btn_b_alim_oral.Visible = false;
                    btn_b_cero_boca.Visible = false;
                    btn_b_nut_oral.Visible = true;
                    btn_b_nut_parenteral.Visible = false;
                    if (Convert.ToInt32(cod_pedido) == 0)
                    {
                        activar(var_cod_desayuno, "S");
                        activar(var_cod_colacion_matinal, "S");
                        activar(var_cod_almuerzo, "S");
                        activar(var_cod_once, "S");
                        activar(var_cod_cena, "S");
                        activar(var_cod_colacion_nocturna, "S");
                        activar(var_cod_colacion_extra, "S");
                        activar(var_cod_hidricos, "S");
                    }
                    else
                    {
                        verificar_2(var_cod_desayuno);
                        verificar_2(var_cod_colacion_matinal);
                        verificar_2(var_cod_almuerzo);
                        verificar_2(var_cod_once);
                        verificar_2(var_cod_cena);
                        verificar_2(var_cod_colacion_nocturna);
                        verificar_2(var_cod_colacion_extra);
                        verificar_2(var_cod_hidricos);
                     
                    }
                }
                else
                {
                    if (ck_nut_parenteral.Checked == true)
                    {
                        comen.Text = "Nutrición Parental";
                        cod_opc_comida = 4;
                        txtobservacion.Text = "";
                        habilitacion_total();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { info_comentario(); });", true);
                        ck_alimen_oral.Checked = false;
                        ck_nut_oral.Checked = false;
                        ck_ayuno.Checked = false;
                        ck_cero_boca.Checked = false;

                        btn_b_ayuno.Visible = false;
                        btn_b_alim_oral.Visible = false;
                        btn_b_cero_boca.Visible = false;
                        btn_b_nut_oral.Visible = false;
                        btn_b_nut_parenteral.Visible = true;

                        if (Convert.ToInt32(cod_pedido) == 0)
                        {
                            activar(var_cod_desayuno, "S");
                            activar(var_cod_colacion_matinal, "S");
                            activar(var_cod_almuerzo, "S");
                            activar(var_cod_once, "S");
                            activar(var_cod_cena, "S");
                            activar(var_cod_colacion_nocturna, "S");
                            activar(var_cod_colacion_extra, "S");
                            activar(var_cod_hidricos, "S");
                           
                        }

                        else
                        {
                            verificar_2(var_cod_desayuno);
                            verificar_2(var_cod_colacion_matinal);
                            verificar_2(var_cod_almuerzo);
                            verificar_2(var_cod_once);
                            verificar_2(var_cod_cena);
                            verificar_2(var_cod_colacion_nocturna);
                            verificar_2(var_cod_colacion_extra);
                            verificar_2(var_cod_hidricos);

                        }

                    }
                    else
                    {
                        if (ck_cero_boca.Checked == true)
                        {
                            comen.Text = "Cero x Boca";
                            cod_opc_comida = 5;
                            txtobservacion.Text = "";
                            bloqueo_total();

                            ck_ayuno.Checked = false;
                            ck_alimen_oral.Checked = false;
                            ck_nut_oral.Checked = false;
                            ck_nut_parenteral.Checked = false;

                            btn_b_ayuno.Visible = false;
                            btn_b_alim_oral.Visible = false;
                            btn_b_cero_boca.Visible = true;
                            btn_b_nut_oral.Visible = false;
                            btn_b_nut_parenteral.Visible = false;

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { info_comentario(); });", true);


                            if (Convert.ToInt32(cod_pedido) == 0)
                            {
                                activar(var_cod_desayuno, "N");
                                activar(var_cod_colacion_matinal, "N");
                                activar(var_cod_almuerzo, "N");
                                activar(var_cod_once, "N");
                                activar(var_cod_cena, "N");
                                activar(var_cod_colacion_nocturna, "N");
                                activar(var_cod_colacion_extra, "N");
                                activar(var_cod_hidricos, "N");
 
                            }
                            else
                            {

                                verificar_2(var_cod_desayuno);
                                verificar_2(var_cod_colacion_matinal);
                                verificar_2(var_cod_almuerzo);
                                verificar_2(var_cod_once);
                                verificar_2(var_cod_cena);
                                verificar_2(var_cod_colacion_nocturna);
                                verificar_2(var_cod_colacion_extra);
                                verificar_2(var_cod_hidricos);
                           
                            }


                        }
                        else
                        {
                            
                        }
                    }
                }
            }
        }
       
    }

    protected void opc_alim_CheckedChanged(object sender, System.EventArgs e)
    {
        cambiar_ck();
        registrar_opc_comida();
        Registrar_tipo_comida();
        Extraer_opc_comida();
       // validar_existe_tipo_comida_activo();
        buscar_alimento_activos();
        activar_iconos();
    }
    #endregion 

    #region Convertir  Lista A DataTables

    public DataTable ConvertToDataTable<T>(IList<T> data)
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

    #region  Validar Campos

    protected Boolean Validar_campos()
    {
        Boolean var = false;

        if (ck_ayuno.Checked == false && ck_alimen_oral.Checked == false && ck_nut_parenteral.Checked == false && ck_nut_oral.Checked == false && ck_cero_boca.Checked == false)
        {
            txtmsg.Text = "Estimado Usuario, No ha seleccionado ninguna opción de alimentación ";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);

        }
        else
        {
            if (Convert.ToInt32(cboaislamiento.SelectedValue) == 0)
            {
                txtmsg.Text = "Estimado Usuario, No ha seleccionado tipo aislamiento ";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);

            }

            else
            {
                if (Convert.ToInt32(cboregimen.SelectedValue) == 0)
                {
                    txtmsg.Text = "Estimado Usuario, No ha seleccionado ninguna opción de Cobro ";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);

                }

                else
                {
                    if (Convert.ToInt32(cboconsistencia.SelectedValue) == 0)
                    {
                        txtmsg.Text = "Estimado Usuario, No ha seleccionado ninguna opción de Consistencia ";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);

                    }

                    else
                    {

                        if (Convert.ToInt32(cbodigestabilidad.SelectedValue) == 0)
                        {
                            txtmsg.Text = "Estimado Usuario, No ha seleccionado ninguna opción de Digestabilidad ";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);

                        }

                        else
                        {
                            if (Convert.ToInt32(cbolactosa.SelectedValue) == 0)
                            {
                                txtmsg.Text = "Estimado Usuario, No ha seleccionado ninguna opción de Lactosa ";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);

                            }

                            else
                            {
                                if (Convert.ToInt32(cbodulzor.SelectedValue) == 0)
                                {
                                    txtmsg.Text = "Estimado Usuario, No ha seleccionado ninguna opción de Dulzor ";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { mensajes(); });", true);

                                }

                                else
                                {

                                    var = true;
                                }

                            }

                        }
                    }

                }

            }

        }

        return var;

    }

    #endregion 

    #region Validar Existencia pedido

    protected void validar_existe_pedido()
    {
        string cod = Session["_Cod_pedido"].ToString();
        Pedidos p = new PedidosNE().Cargar_pedidos2(Convert.ToInt32(cod));
        cod_pedido = p._Cod_menu.ToString();
        id_opc_comida = p._Id_opc_comida;
        int a = p._Cod_aislamiento;
        if (a == 0)
        {
            cboaislamiento.SelectedValue= "1";
            cod_aislamiento = 1;
        }
        else
        {
            cboaislamiento.SelectedValue = p._Cod_aislamiento.ToString();
            cod_aislamiento = p._Cod_aislamiento;
        }

        int b = p._Cod_regimen;
        if (b == 0)
        {
            cboregimen.SelectedValue = "1";
            Session["Regimen"] = 1;
            cod_cobro = 1;
        }
        else
        {
            cboregimen.SelectedValue = p._Cod_regimen.ToString();
            Session["Regimen"] = p._Cod_regimen.ToString();
            cod_cobro = p._Cod_regimen;
        }

        int c = p._Cod_tipo_consistencia;
        if (c == 0)
        {
            cboconsistencia.SelectedValue = "1";
            Session["Consistencia"] = "1";
            cod_consistencia = 1;
        }
        else
        {
            cboconsistencia.SelectedValue = p._Cod_tipo_consistencia.ToString();
            Session["Consistencia"] = p._Cod_tipo_consistencia.ToString();
            cod_consistencia = p._Cod_tipo_consistencia;
        }

        int d = p._Cod_tipo_digestabilidad;
        if (d == 0)
        {
            cbodigestabilidad.SelectedValue = "1";
            Session["Digestabilidad"] = "1";

            cod_digestabilidad = 1;
        }
        else
        {
            cbodigestabilidad.SelectedValue = p._Cod_tipo_digestabilidad.ToString();
            Session["Digestabilidad"] = p._Cod_tipo_digestabilidad.ToString();
            cod_digestabilidad = p._Cod_tipo_digestabilidad;
        }

        int e = p._Cod_tipo_digestabilidad;
        if (e == 0)
        {
            cbolactosa.SelectedValue= "1";
            Session["Lactosa"] = "1";

            cod_lactosa = 1;
        }
        else
        {
            cbolactosa.SelectedValue = p._Cod_lactosa.ToString();
            Session["Lactosa"] = p._Cod_lactosa.ToString();
            cod_lactosa = p._Cod_lactosa;
        }

        int f = p._Cod_dulzor;
        if (f == 0)
        {
            cbodulzor.SelectedValue = "1";
            Session["Dulzor"] = "1";
            cod_dulzor = 1;
        }
        else
        {
            cbodulzor.SelectedValue = p._Cod_dulzor.ToString();
            Session["Dulzor"]  = p._Cod_dulzor.ToString();
            cod_dulzor = p._Cod_dulzor;
        }

        int g = p._Cod_tipo_sales;
        if (g == 0)
        {
            cbosal.SelectedValue = "1";
            Session["Sal"] = "1";

            cod_sal = 1;
        }
        else
        {
            cbosal.SelectedValue = p._Cod_tipo_sales.ToString();
            Session["Sal"] = p._Cod_tipo_sales.ToString();
            cod_sal = p._Cod_tipo_sales;
        }

      



        string com = p._Comentario_tipo_comida;

        if (com == "" || com == null)
        {
            Session["Comentario_comida"] = "";
            txtobservacion.Text = "";
        }
        else
        {
            Session["Comentario_comida"] = p._Comentario_tipo_comida.ToString().ToUpper();
            txtobservacion.Text = p._Comentario_tipo_comida.ToString().ToUpper();
        }

        //      Session["Comentario_comida"] = p._Comentario_tipo_comida.ToString().ToUpper();
        int op = p._Cod_opc_comida;
        opc_ck = p._Cod_opc_comida;
        btn_b_alim_oral.Visible = false;
        btn_b_ayuno.Visible = false;
        btn_b_nut_oral.Visible = false;
        btn_b_nut_parenteral.Visible = false;
        btn_b_cero_boca.Visible = false;
        switch (op)
        {
            case 1:
                ck_ayuno.Checked = true;
                bloqueo_parcial();
                btn_b_ayuno.Visible = true;

                break;

            case 2:
                ck_alimen_oral.Checked = true;
                habilitacion_total();
                btn_b_alim_oral.Visible = true;
                break;

            case 3:
                ck_nut_oral.Checked = true;
                habilitacion_total();
                btn_b_nut_oral.Visible = true;
                break;

            case 4:
                ck_nut_parenteral.Checked = true;
                habilitacion_total();
                btn_b_nut_parenteral.Visible = true;
                break;

            case 5:
                ck_cero_boca.Checked = true;
                bloqueo_parcial();
                btn_b_cero_boca.Visible = true;
                break;

        }



    }

    #endregion 

    #region  Validar Comidas

    protected int validar_comida(int codigo)
    {
        int res = 0;
        dt_listado_comida = (DataTable)Session["tabla_comidas"];
        foreach (DataRow row in dt_listado_comida.Rows)
        {

            if (Convert.ToInt32(row["_Cod_tipo_comida"].ToString()) == 1 && Convert.ToInt32(row["_Cod_menu"].ToString()) == Convert.ToInt32(cod_pedido))
            {
                id_tipo_comida = Convert.ToInt32(row["_Id_tipo_comida"].ToString());
                img_d.ImageUrl = "~/Imagenes/Botones/on.png";


                res = 1;
            }
            else
            {
                if (Convert.ToInt32(row["_Cod_tipo_comida"].ToString()) == 2 && Convert.ToInt32(row["_Cod_menu"].ToString()) == Convert.ToInt32(cod_pedido))
                {
                    id_tipo_comida = Convert.ToInt32(row["_Id_tipo_comida"].ToString());
                    img_c1.ImageUrl = "~/Imagenes/Botones/on.png";
                    res = 1;
                }
                else
                {
                    if (Convert.ToInt32(row["_Cod_tipo_comida"].ToString()) == 3 && Convert.ToInt32(row["_Cod_menu"].ToString()) == Convert.ToInt32(cod_pedido))
                    {
                        id_tipo_comida = Convert.ToInt32(row["_Id_tipo_comida"].ToString());
                        img_a.ImageUrl = "~/Imagenes/Botones/on.png";
                        res = 1;
                    }
                    else
                    {
                        if (Convert.ToInt32(row["_Cod_tipo_comida"].ToString()) == 4 && Convert.ToInt32(row["_Cod_menu"].ToString()) == Convert.ToInt32(cod_pedido))
                        {
                            id_tipo_comida = Convert.ToInt32(row["_Id_tipo_comida"].ToString());
                            img_o.ImageUrl = "~/Imagenes/Botones/on.png";
                            res = 1;
                        }
                        else
                        {

                            if (Convert.ToInt32(row["_Cod_tipo_comida"].ToString()) == 5 && Convert.ToInt32(row["_Cod_menu"].ToString()) == Convert.ToInt32(cod_pedido))
                            {
                                id_tipo_comida = Convert.ToInt32(row["_Id_tipo_comida"].ToString());
                                img_c.ImageUrl = "~/Imagenes/Botones/on.png";
                                res = 1;
                            }
                            else
                            {
                                if (Convert.ToInt32(row["_Cod_tipo_comida"].ToString()) == 6 && Convert.ToInt32(row["_Cod_menu"].ToString()) == Convert.ToInt32(cod_pedido))
                                {
                                    id_tipo_comida = Convert.ToInt32(row["_Id_tipo_comida"].ToString());
                                    img_c2.ImageUrl = "~/Imagenes/Botones/on.png";
                                    res = 1;
                                }
                                else
                                {
                                    if (Convert.ToInt32(row["_Cod_tipo_comida"].ToString()) == 7 && Convert.ToInt32(row["_Cod_menu"].ToString()) == Convert.ToInt32(cod_pedido))
                                    {
                                        id_tipo_comida = Convert.ToInt32(row["_Id_tipo_comida"].ToString());
                                        img_ce.ImageUrl = "~/Imagenes/Botones/on.png";
                                        res = 1;
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(row["_Cod_tipo_comida"].ToString()) == 8 && Convert.ToInt32(row["_Cod_menu"].ToString()) == Convert.ToInt32(cod_pedido))
                                        {
                                            id_tipo_comida = Convert.ToInt32(row["_Id_tipo_comida"].ToString());
                                            img_hco.ImageUrl = "~/Imagenes/Botones/on.png";
                                            res = 1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }



        }
        Session["tabla_nutrientes"] = dt_listado_comida;
        return res;

    }

    #endregion 

    #region Validar Imagenes

    protected void verificar_2(int cod)
    {
        string v = "";
        string vale = "";
        int tipo = 0;
        int alimento = 0;
        dt_listado_comida = (DataTable)Session["tabla_comidas"];
        foreach (DataRow row in dt_listado_comida.Select("_Cod_tipo_comida = '" + cod + "'"))
        {
            tipo++;
            v = row["_Estado"].ToString();
            string a = row["_Cod_tipo_alimento"].ToString();
            if (a == "" || a == null)
            {
                a = "0";
            }

            alimento = Convert.ToInt32(a);
            vale = row["_Vale_impreso"].ToString();

          }

            if (vale == "S")
            {
                if (cod == 1) { img_d.Enabled = false; img_d_2.Enabled = false; }
                else
                {
                    if (cod == 2) { img_c1.Enabled = false; img_c1_2.Enabled = false; }
                    else
                    {
                        if (cod == 3) { img_a.Enabled = false; img_a_2.Enabled = false; }
                        else
                        {
                            if (cod == 4) { img_o.Enabled = false; img_o_2.Enabled = false; }
                            else
                            {
                                if (cod == 5) { img_c.Enabled = false; img_c_2.Enabled = false; }
                                else
                                {
                                    if (cod == 6) { img_c2.Enabled = false; img_c2_2.Enabled = false; }
                                    else
                                    {
                                        if (cod == 7) { img_ce.Enabled = false; img_ce_2.Enabled = false; }
                                        else
                                        {
                                            if (cod == 8) { img_hco.Enabled = false; img_hco_2.Enabled = false; }
                                            else
                                            {

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


            }
            else
            {

                if (ck_ayuno.Checked == true)
                {

                    if (cod == 1) { activar(var_cod_desayuno, "N"); }
                    else
                    {
                        if (cod == 2) { activar(var_cod_colacion_matinal, "N"); }
                        else
                        {
                            if (cod == 3) { activar(var_cod_almuerzo, "N"); }
                            else
                            {
                                if (cod == 4) { activar(var_cod_once, "N"); }
                                else
                                {
                                    if (cod == 5) { activar(var_cod_cena, "N"); }
                                    else
                                    {
                                        if (cod == 6) { activar(var_cod_colacion_nocturna, "N"); }
                                        else
                                        {
                                            if (cod == 7) { activar(var_cod_colacion_extra, "N"); }
                                            else
                                            {
                                                if (cod == 8) { activar(var_cod_hidricos, "S"); }
                                                else
                                                {

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                   /* img_c1.ImageUrl = "~/Imagenes/Botones/off.png";
                    img_a.ImageUrl = "~/Imagenes/Botones/off.png";
                    img_o.ImageUrl = "~/Imagenes/Botones/off.png";
                    img_c.ImageUrl = "~/Imagenes/Botones/off.png";
                    img_c2.ImageUrl = "~/Imagenes/Botones/off.png";
                    img_ce.ImageUrl = "~/Imagenes/Botones/off.png";
                    img_hco.ImageUrl = "~/Imagenes/Botones/on.png";*/

                }
                else
                {
                    if (ck_alimen_oral.Checked == true)
                    {
                        if (cod == 1) { activar(var_cod_desayuno, "S"); }
                        else
                        {
                            if (cod == 2) { activar(var_cod_colacion_matinal, "S"); }
                            else
                            {
                                if (cod == 3) { activar(var_cod_almuerzo, "S"); }
                                else
                                {
                                    if (cod == 4) { activar(var_cod_once, "S"); }
                                    else
                                    {
                                        if (cod == 5) { activar(var_cod_cena, "S"); }
                                        else
                                        {
                                            if (cod == 6) { activar(var_cod_colacion_nocturna, "S"); }
                                            else
                                            {
                                                if (cod == 7) { activar(var_cod_colacion_extra, "S"); }
                                                else
                                                {
                                                    if (cod == 8) { activar(var_cod_hidricos, "S"); }
                                                    else
                                                    {

                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                     /*   img_d.ImageUrl = "~/Imagenes/Botones/on.png";
                        img_c1.ImageUrl = "~/Imagenes/Botones/on.png";
                        img_a.ImageUrl = "~/Imagenes/Botones/on.png";
                        img_o.ImageUrl = "~/Imagenes/Botones/on.png";
                        img_c.ImageUrl = "~/Imagenes/Botones/on.png";
                        img_c2.ImageUrl = "~/Imagenes/Botones/on.png";
                        img_ce.ImageUrl = "~/Imagenes/Botones/on.png";
                        img_hco.ImageUrl = "~/Imagenes/Botones/on.png";*/

                    }

                    else
                    {

                        if (ck_nut_oral.Checked == true)
                        {
                   
                        if (cod == 1) { activar(var_cod_desayuno, "S"); }
                        else
                        {
                            if (cod == 2) { activar(var_cod_colacion_matinal, "S"); }
                            else
                            {
                                if (cod == 3) { activar(var_cod_almuerzo, "S"); }
                                else
                                {
                                    if (cod == 4) { activar(var_cod_once, "S"); }
                                    else
                                    {
                                        if (cod == 5) { activar(var_cod_cena, "S"); }
                                        else
                                        {
                                            if (cod == 6) { activar(var_cod_colacion_nocturna, "S"); }
                                            else
                                            {
                                                if (cod == 7) { activar(var_cod_colacion_extra, "S"); }
                                                else
                                                {
                                                    if (cod == 8) { activar(var_cod_hidricos, "S"); }
                                                    else
                                                    {

                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                           /* img_d.ImageUrl = "~/Imagenes/Botones/on.png";
                            img_c1.ImageUrl = "~/Imagenes/Botones/on.png";
                            img_a.ImageUrl = "~/Imagenes/Botones/on.png";
                            img_o.ImageUrl = "~/Imagenes/Botones/on.png";
                            img_c.ImageUrl = "~/Imagenes/Botones/on.png";
                            img_c2.ImageUrl = "~/Imagenes/Botones/on.png";
                            img_ce.ImageUrl = "~/Imagenes/Botones/on.png";
                            img_hco.ImageUrl = "~/Imagenes/Botones/on.png";*/

                        }

                        else
                        {
                            if (ck_nut_parenteral.Checked == true)
                            {
                              if (cod == 1) { activar(var_cod_desayuno, "S"); }
                                else
                                {
                                    if (cod == 2) { activar(var_cod_colacion_matinal, "S"); }
                                    else
                                    {
                                        if (cod == 3) { activar(var_cod_almuerzo, "S"); }
                                        else
                                        {
                                            if (cod == 4) { activar(var_cod_once, "S"); }
                                            else
                                            {
                                                if (cod == 5) { activar(var_cod_cena, "S"); }
                                                else
                                                {
                                                    if (cod == 6) { activar(var_cod_colacion_nocturna, "S"); }
                                                    else
                                                    {
                                                        if (cod == 7) { activar(var_cod_colacion_extra, "S"); }
                                                        else
                                                        {
                                                            if (cod == 8) { activar(var_cod_hidricos, "S"); }
                                                            else
                                                            {

                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                             /*   img_d.ImageUrl = "~/Imagenes/Botones/on.png";
                                img_c1.ImageUrl = "~/Imagenes/Botones/on.png";
                                img_a.ImageUrl = "~/Imagenes/Botones/on.png";
                                img_o.ImageUrl = "~/Imagenes/Botones/on.png";
                                img_c.ImageUrl = "~/Imagenes/Botones/on.png";
                                img_c2.ImageUrl = "~/Imagenes/Botones/on.png";
                                img_ce.ImageUrl = "~/Imagenes/Botones/on.png";
                                img_hco.ImageUrl = "~/Imagenes/Botones/on.png";*/

                            }
                            else
                            {
                                if (ck_cero_boca.Checked == true)
                                {
                                   
                                            if (cod == 1) { activar(var_cod_desayuno, "N"); }
                                            else
                                            {
                                                if (cod == 2) { activar(var_cod_colacion_matinal, "N"); }
                                                else
                                                {
                                                    if (cod == 3) { activar(var_cod_almuerzo, "N"); }
                                                    else
                                                    {
                                                        if (cod == 4) { activar(var_cod_once, "N"); }
                                                        else
                                                        {
                                                            if (cod == 5) { activar(var_cod_cena, "N"); }
                                                            else
                                                            {
                                                                if (cod == 6) { activar(var_cod_colacion_nocturna, "N"); }
                                                                else
                                                                {
                                                                    if (cod == 7) { activar(var_cod_colacion_extra, "N"); }
                                                                    else
                                                                    {
                                                                        if (cod == 8) { activar(var_cod_hidricos, "N"); }
                                                                        else
                                                                        {

                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }


                                  /*  img_d.ImageUrl = "~/Imagenes/Botones/off.png";
                                    img_c1.ImageUrl = "~/Imagenes/Botones/off.png";
                                    img_a.ImageUrl = "~/Imagenes/Botones/off.png";
                                    img_o.ImageUrl = "~/Imagenes/Botones/off.png";
                                    img_c.ImageUrl = "~/Imagenes/Botones/off.png";
                                    img_c2.ImageUrl = "~/Imagenes/Botones/off.png";
                                    img_ce.ImageUrl = "~/Imagenes/Botones/off.png";
                                    img_hco.ImageUrl = "~/Imagenes/Botones/off.png";*/

                                }
                                else
                                {

                                }
                            }

                        }

                    }
                }


            }
      


      
     //   registrar_opc_comida();
    }



    #endregion 


    #endregion




    [WebMethod]
   public string Sumar()
   {
       string var="si";
       return var;
                
   }


         
    }
}