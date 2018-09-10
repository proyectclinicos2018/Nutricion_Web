using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Falp.Entidades;
using Falp.Capa_Negocios;
using System.ComponentModel;
using System.Reflection;
using System.Web.Services;
using System.Web.Script.Services;
using System.Text.RegularExpressions;

namespace Falp.Oficial
{
    public partial class Listado_Camas : System.Web.UI.Page
    {
    #region Variables

    static string user = "";
    static string rut = "";
    static string nombre = "";
    static string ficha = "";
    static string fecha = "";
    static int cod_estado = 0;
    static int cod_turno = 0;
    static  int cod_tipo_comida = 0;
    static int tipo_doc = 0;
    static  int tipo_menu = 0;
    static int cod_servicio = 0;
    static string cod_pedido = "0";
    static string cod_cama = "";
    static string cod_paciente = "";
    static string nom_paciente = "";
    static string f_alta = "";
    static string obs = "";
    static string f = "";

  //  static List<Cama_Pacientes> lista_cama_paciente = new List<Cama_Pacientes>();
    static List<Cama_Pacientes> lista_cama_paciente2 = new List<Cama_Pacientes>();
    static  List<Cama_Pacientes> lista_cama_paciente3 = new List<Cama_Pacientes>();
    Cama_Pacientes var=new Cama_Pacientes();
    #endregion

    #region DataTable

    static  DataTable dt_listado_cama_2 = new DataTable();
    static DataTable dt_listado_alimento = new DataTable();
    #endregion 
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            if (Session["Usuario"] != null)
            {
                 fecha = "";
                 f = "";
                user = Session["Usuario"].ToString();
                Cargar_estado();
                Cargar_servicio();
                Cargar_turno();
                Cargar_tipocomida();
                Cargar_grilla();
                
                Session["FECHA_ACTUAL"] = DateTime.Now.ToString("dd-MM-yyyy");
                datepicker1.Text = DateTime.Now.ToString("dd-MM-yyyy");
                     
            }
            else
            {
            Response.Redirect("index.aspx");
            Session["Usuario"] = "";
            }

        }

        btn_generar_pedido.Visible = true;
        MaintainScrollPositionOnPostBack = true;
    }


    #region Cargar

    #region Cargar Grilla

    #region Listar Grilla

     

    protected  void    Cargar_grilla()
    {
     int cod=0;
        
        if (f == "")
        {
             fecha = fecha = DateTime.Now.ToString("dd-MM-yyyy");
        }
        else
        {
              fecha = f;
        }

        List<Cama_Pacientes> lista_cama_paciente = new List<Cama_Pacientes>();
        Cama_PacienteNE var1 = new Cama_PacienteNE();
        lista_cama_paciente = var1.ListadoCamaPacientes(tipo_doc, rut, cod_servicio, cod_turno, cod_estado, cod_tipo_comida, nombre, ficha, fecha);
        dt_listado_cama_2 = ConvertToDataTable(lista_cama_paciente);
        Session["dt_cama_paciente"] = dt_listado_cama_2;

        grillacama.DataSource = lista_cama_paciente;
        grillacama.DataBind();
        txtcantidad.Text = lista_cama_paciente.Count().ToString();


       f = "";
    }

    #endregion

  
    #region Pintar Extraer grilla

    protected void grillacama_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         string fecha="";
           


                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                var estado = e.Row.DataItem as Cama_Pacientes;
                
                
                var image1 = e.Row.FindControl("img_1") as Image;
                var image2 = e.Row.FindControl("img_2") as Image;
                var image3 = e.Row.FindControl("img_3") as Image;
                var image4 = e.Row.FindControl("img_4") as Image;
                var image5 = e.Row.FindControl("img_5") as Image;
                var image6 = e.Row.FindControl("img_6") as Image;
                var image7 = e.Row.FindControl("img_7") as Image;
                var image8 = e.Row.FindControl("img_8") as Image;

                image1.ImageUrl = "~/Imagenes/Botones/cancelar.png";
                image1.ToolTip = "No sea Registrado el Pedido";
                image2.ImageUrl = "~/Imagenes/Botones/cancelar.png";
                image2.ToolTip = "No sea Registrado el Pedido";
                image3.ImageUrl = "~/Imagenes/Botones/cancelar.png";
                image3.ToolTip = "No sea Registrado el Pedido";
                image4.ImageUrl = "~/Imagenes/Botones/cancelar.png";
                image4.ToolTip = "No sea Registrado el Pedido";
                image5.ImageUrl = "~/Imagenes/Botones/cancelar.png";
                image5.ToolTip = "No sea Registrado el Pedido";
                image6.ImageUrl = "~/Imagenes/Botones/cancelar.png";
                image6.ToolTip = "No sea Registrado el Pedido";
                image7.ImageUrl = "~/Imagenes/Botones/cancelar.png";
                image7.ToolTip = "No sea Registrado el Pedido";
                image8.ImageUrl = "~/Imagenes/Botones/cancelar.png";
                image8.ToolTip = "No sea Registrado el Pedido";
                  

                int cod_paciente = Convert.ToInt32(estado._Correlativo);
               
                string cod_pedido=Convert.ToString(estado._Cod_menu);
                // int cod_paciente = Convert.ToInt32(row1["_Correlativo"].ToString());

                if (f == "")
                {
                    fecha = fecha = DateTime.Now.ToString("dd-MM-yyyy");
                }
                else
                {
                    fecha = f;
                }
                Cama_PacienteNE var = new Cama_PacienteNE();

                lista_cama_paciente2 = var.ListadoCamaPacientes2(cod_paciente, fecha);
                dt_listado_alimento = ConvertToDataTable(lista_cama_paciente2);


                                                                                                                                                                                                                                                                                                                            #region  Valida ingesta

    int cod_vale = 0;
    int cod_ingesta = 0;
    foreach (DataRow row3 in dt_listado_alimento.Rows)
    {
        string vale = row3["_Estado_cama"].ToString();
        string ingesta = row3["_Ingesta"].ToString();

        if (vale == "S")
        {
            cod_vale++;
        }

        if (ingesta == "S")
        {
            cod_ingesta++;
        }
                            
    }

    if (cod_vale == cod_ingesta && cod_vale > 0 && cod_ingesta>0)
        {
            if (dt_listado_alimento.Rows.Count > 0)
            {
                string res = new PedidosNE().Cambiar_estado(cod_pedido, 9);
                e.Row.Cells[2].Text = "FINALIZADO";
            }
        }

    #endregion 

                                                                                        #region  Valida alta medica

    if (estado._Estado == "8" || estado._Fecha_alta != "")
    {
        // string res = new PedidosNE().Cambiar_estado(cod_pedido, 8);
        e.Row.Cells[2].Text = "PAC. ALTA ADMINISTRATIVA";

    }

    #endregion 



                int n_a = 0;
                int c1 = 0;
                int i = 0;
                int a1 = 0;
                int n_e = 0;
                int n_p = 0;
                int c_b = 0;
                int p_a = 0;
                int f1 = 0;
                string fe = "";

                  

                if (dt_listado_alimento.Rows.Count > 0)
                {
                    foreach (DataRow row in dt_listado_alimento.Rows)
                    {

                        int c = Convert.ToInt32(row["_Cod_tipo_comida"].ToString());
                        int a = Convert.ToInt32(row["_Cod_tipo_alimento"].ToString());
                        string est = row["_Estado"].ToString();
                        string vale = row["_Estado_cama"].ToString();
                        string ingesta = row["_Ingesta"].ToString();
                        string v_comida = row["_Vigencia_comida"].ToString();
                        string v_alimento = row["_Vigencia_alimento"].ToString();
                        //   string f_hosp = row["_Fecha_hosp"].ToString();




                        if (est == "" && estado._Fecha_alta == "" || est == "1" && estado._Fecha_alta == "")
                        {
                            e.Row.Cells[2].Text = "NO ASIGNADO";

                        }
                        else
                        {
                            if (Validar_estado(dt_listado_alimento) && estado._Fecha_alta == "" || est == "2" && estado._Fecha_alta == "")
                            {
                                e.Row.Cells[2].Text = "COMPLETO";
                                string res = new PedidosNE().Cambiar_estado(cod_pedido, 2);
                            }
                            else
                            {
                                if (est == "3" && estado._Fecha_alta == "")
                                {
                                    e.Row.Cells[2].Text = "INCOMPLETO";
                                }
                                else
                                {
                                    if (est == "4" && estado._Fecha_alta == "")
                                    {
                                        e.Row.Cells[2].Text = "NUTRICIÓN ENTERAL";
                                    }
                                    else
                                    {
                                        if (est == "5" && estado._Fecha_alta == "")
                                        {
                                            e.Row.Cells[2].Text = "NUTRICIÓN PARENTERAL";
                                        }
                                        else
                                        {
                                            if (est == "6" && estado._Fecha_alta == "")
                                            {
                                                e.Row.Cells[2].Text = "AYUNO";

                                            }
                                            else
                                            {
                                                if (est == "7" && estado._Fecha_alta == "")
                                                {
                                                    e.Row.Cells[2].Text = "CERO BOCA";
 
                                                   
                                                }
                                                else
                                                {
                                                    if (estado._Fecha_alta!="")
                                                    {
                                                        string res = new PedidosNE().Cambiar_estado(cod_pedido, 8);
                                                        e.Row.Cells[2].Text = "PAC. ALTA ADMINISTRATIVA";
                                                   
                                                    }
                                                    else
                                                    {
                                                        if (Validar_estado_finalizado(dt_listado_alimento))
                                                        {
                                                            string res = new PedidosNE().Cambiar_estado(cod_pedido, 9);
                                                            e.Row.Cells[2].Text = "FINALIZADO";

                                                        }
                                                        else
                                                        {
                                                            e.Row.Cells[2].Text = "INCOMPLETO";
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (c > 0 && a == 0 && v_comida=="S")
                        {
                            switch (Convert.ToInt32(c))
                            {
                                case 1: image1.ImageUrl = "~/Imagenes/Botones/incompleto.png"; image1.ToolTip = "Pedido posee no posee alimentos registrados"; break;
                                case 2: image2.ImageUrl = "~/Imagenes/Botones/incompleto.png"; image2.ToolTip = "Pedido posee no posee alimentos registrados"; break;
                                case 3: 
                                    image3.ImageUrl = "~/Imagenes/Botones/incompleto.png"; image3.ToolTip = "Pedido posee no posee alimentos registrados";
                                            
                                            
                                    break;
                                case 4: image4.ImageUrl = "~/Imagenes/Botones/incompleto.png"; image4.ToolTip = "Pedido posee no posee alimentos registrados"; break;
                                case 5: image5.ImageUrl = "~/Imagenes/Botones/incompleto.png"; image5.ToolTip = "Pedido posee no posee alimentos registrados"; break;
                                case 6: image6.ImageUrl = "~/Imagenes/Botones/incompleto.png"; image6.ToolTip = "Pedido posee no posee alimentos registrados"; break;
                                case 7: image7.ImageUrl = "~/Imagenes/Botones/incompleto.png"; image7.ToolTip = "Pedido posee no posee alimentos registrados"; break;
                                case 8: image8.ImageUrl = "~/Imagenes/Botones/incompleto.png"; image8.ToolTip = "Pedido posee no posee alimentos registrados"; break;

                            }
                        }
                        else
                        {
                            if (c > 0 && a > 0 && v_comida == "S" && v_alimento=="S")
                            {
                                if (ingesta != "S")
                                {
                                    if (vale != "S")
                                    {
                                        switch (Convert.ToInt32(c))
                                        {

                                            case 1: image1.ImageUrl = "~/Imagenes/Botones/ok.png"; image1.ToolTip = "Tipo Comida posee al menos un Alimento"; break;
                                            case 2: image2.ImageUrl = "~/Imagenes/Botones/ok.png"; image2.ToolTip = "Tipo Comida posee al menos un Alimento"; break;
                                            case 3: image3.ImageUrl = "~/Imagenes/Botones/ok.png"; image3.ToolTip = "Tipo Comida Comida posee al menos un Alimento"; break;
                                            case 4: image4.ImageUrl = "~/Imagenes/Botones/ok.png"; image4.ToolTip = "Tipo Comida posee al menos un Alimento"; break;
                                            case 5: image5.ImageUrl = "~/Imagenes/Botones/ok.png"; image5.ToolTip = "Tipo Comida posee al menos un Alimento"; break;
                                            case 6: image6.ImageUrl = "~/Imagenes/Botones/ok.png"; image6.ToolTip = "Tipo Comida posee al menos un Alimento"; break;
                                            case 7: image7.ImageUrl = "~/Imagenes/Botones/ok.png"; image7.ToolTip = "Tipo Comida posee al menos un Alimento"; break;
                                            case 8: image8.ImageUrl = "~/Imagenes/Botones/ok.png"; image8.ToolTip = "Tipo Comida posee al menos un Alimento"; break;

                                        }
                                    }
                                    else
                                    {
                                        switch (Convert.ToInt32(c))
                                        {
                                            case 1: image1.ImageUrl = "~/Imagenes/Botones/Imprimir.png"; image1.ToolTip = "Tipo Comida posee  vale Impreso"; break;
                                            case 2: image2.ImageUrl = "~/Imagenes/Botones/Imprimir.png"; image2.ToolTip = "Tipo Comida posee  vale Impreso"; break;
                                            case 3: image3.ImageUrl = "~/Imagenes/Botones/Imprimir.png"; image3.ToolTip = "Tipo Comida posee  vale Impreso"; break;
                                            case 4: image4.ImageUrl = "~/Imagenes/Botones/Imprimir.png"; image4.ToolTip = "Tipo Comida posee  vale Impreso"; break;
                                            case 5: image5.ImageUrl = "~/Imagenes/Botones/Imprimir.png"; image5.ToolTip = "Tipo Comida posee  vale Impreso"; break;
                                            case 6: image6.ImageUrl = "~/Imagenes/Botones/Imprimir.png"; image6.ToolTip = "Tipo Comida posee  vale Impreso"; break;
                                            case 7: image7.ImageUrl = "~/Imagenes/Botones/Imprimir.png"; image7.ToolTip = "Tipo Comida posee  vale Impreso"; break;
                                            case 8: image8.ImageUrl = "~/Imagenes/Botones/Imprimir.png"; image8.ToolTip = "Tipo Comida posee  vale Impreso"; break;
                                        }
                                    }
                                }
                                else
                                {
                                    switch (Convert.ToInt32(c))
                                    {
                                            case 1: image1.ImageUrl = "~/Imagenes/Botones/ingesta.png"; image1.ToolTip = "Tipo Comida posee Ingesta"; break;
                                            case 2: image2.ImageUrl = "~/Imagenes/Botones/ingesta.png"; image2.ToolTip = "Tipo Comida posee Ingesta"; break;
                                            case 3: image3.ImageUrl = "~/Imagenes/Botones/ingesta.png"; image3.ToolTip = "Tipo Comida posee Ingesta"; break;
                                            case 4: image4.ImageUrl = "~/Imagenes/Botones/ingesta.png"; image4.ToolTip = "Tipo Comida posee Ingesta"; break;
                                            case 5: image5.ImageUrl = "~/Imagenes/Botones/ingesta.png"; image5.ToolTip = "Tipo Comida posee Ingesta"; break;
                                            case 6: image6.ImageUrl = "~/Imagenes/Botones/ingesta.png"; image6.ToolTip = "Tipo Comida posee Ingesta"; break;
                                            case 7: image7.ImageUrl = "~/Imagenes/Botones/ingesta.png"; image7.ToolTip = "Tipo Comida posee Ingesta"; break;
                                            case 8: image8.ImageUrl = "~/Imagenes/Botones/ingesta.png"; image8.ToolTip = "Tipo Comida posee Ingesta"; break;
                                      }

                                }
                            }
                            else
                            {
                   

                            }

                        }

                    }
                }
                else
                {
                    image1.ImageUrl = "~/Imagenes/Botones/cancelar.png";
                    image1.ToolTip = "No sea Registrado el Pedido";
                    image2.ImageUrl = "~/Imagenes/Botones/cancelar.png";
                    image2.ToolTip = "No sea Registrado el Pedido";
                    image3.ImageUrl = "~/Imagenes/Botones/cancelar.png";
                    image3.ToolTip = "No sea Registrado el Pedido";
                    image4.ImageUrl = "~/Imagenes/Botones/cancelar.png";
                    image4.ToolTip = "No sea Registrado el Pedido";
                    image5.ImageUrl = "~/Imagenes/Botones/cancelar.png";
                    image5.ToolTip = "No sea Registrado el Pedido";
                    image6.ImageUrl = "~/Imagenes/Botones/cancelar.png";
                    image6.ToolTip = "No sea Registrado el Pedido";
                    image7.ImageUrl = "~/Imagenes/Botones/cancelar.png";
                    image7.ToolTip = "No sea Registrado el Pedido";
                    image8.ImageUrl = "~/Imagenes/Botones/cancelar.png";
                    image8.ToolTip = "No sea Registrado el Pedido";


                    string s = e.Row.Cells[2].Text.Replace("&nbsp;","");
                    if (s == "" || s == "1")
                    {
                        e.Row.Cells[2].Text = "NO ASIGNADO";
                    }
                }
            
  
               }
    }

    protected void grillacama_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grillacama.PageIndex = e.NewPageIndex;
        grillacama.DataBind();
        Cargar_grilla();          
    }

    #endregion

    #endregion



    #region Cargar Combox
    protected void Cargar_tipocomida()
    {
        try
        {

            List<Utilidades> lista_tipocomida = new UtilidadesNE().Cargartipo_comida();
            cbotipo_comida.DataSource = lista_tipocomida;
            cbotipo_comida.DataTextField = "_Nom_tipo_comida";
            cbotipo_comida.DataValueField = "_Cod_tipo_comida";
            cbotipo_comida.DataBind();
            cbotipo_comida.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        catch (Exception ex)
        {

            System.Console.Write(ex.Message);
        }
    }

    protected void Cargar_turno()
    {
        try
        {

            List<Utilidades> lista_turno = new UtilidadesNE().Cargarturno();
            cboturno.DataSource = lista_turno;
            cboturno.DataTextField = "_Nom_turno";
            cboturno.DataValueField = "_Cod_turno";
            cboturno.DataBind();
            cboturno.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        catch (Exception ex)
        {
            System.Console.Write(ex.Message);
        }
    }

    protected void Cargar_servicio()
    {
        try
        {
            List<Utilidades> lista_servicio = new UtilidadesNE().Cargarservicio();
            cboservicio.DataSource = lista_servicio;
            cboservicio.DataTextField = "_Nom_servicio";
            cboservicio.DataValueField = "_Cod_servicio";
            cboservicio.DataBind();
            cboservicio.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        catch (Exception ex)
        {
             System.Console.Write(ex.Message);
        }
    }

    protected void Cargar_estado()
    {
        try
        {
            List<Utilidades> lista_estado = new UtilidadesNE().Cargarestado();
            cboestado.DataSource = lista_estado;
            cboestado.DataTextField = "_Nom_estado";
            cboestado.DataValueField = "_Cod_estado";
            cboestado.DataBind();
            cboestado.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        catch (Exception ex)
        {
            System.Console.Write(ex.Message);
        }
    }

    #endregion  


    #endregion

    #region Botones

    protected void ingresar(object sender, EventArgs e)
    {
       Button btndetails = sender as Button;
       GridViewRow row = (GridViewRow)btndetails.NamingContainer;
       dt_listado_cama_2 = (DataTable)Session["dt_cama_paciente"];    
       string correlativo =grillacama.DataKeys[row.RowIndex]["_Correlativo"].ToString().Replace("&nbsp;", "");
       string hora = grillacama.DataKeys[row.RowIndex]["_Hora"].ToString();
       foreach (DataRow row1 in dt_listado_cama_2.Select(" _Correlativo= " + correlativo))
       {
           string cod = row1["_Cod_menu"].ToString();
           Session["_Cod_pedido"] = cod;

       }
        Session["Cod_Paciente"] = correlativo;
        Session["Cod_Cama"] = grillacama.DataKeys[row.RowIndex]["_Cod_cama"].ToString().Replace("&nbsp;", "");
        Session["Cama"] = row.Cells[11].Text.Trim().Replace("&nbsp;", "");
        Session["Nom_Servicio"] = row.Cells[16].Text.Trim().Replace("&nbsp;", "");
        Session["Nom_Paciente"] = row.Cells[15].Text.Trim().Replace("&nbsp;", "").Replace("&#209;", "Ñ").ToUpper();
        Session["Habitacion"] = row.Cells[12].Text.Trim().Replace("&nbsp;", "");
        Session["Ficha"] = grillacama.DataKeys[row.RowIndex]["_Cod_nhc"].ToString().Replace("&nbsp;", "");
        Session["Tipo_doc"] = grillacama.DataKeys[row.RowIndex]["_Tipo_doc"].ToString().Replace("&nbsp;", "");
        Session["Fecha"] = grillacama.DataKeys[row.RowIndex]["_Fecha_hosp"].ToString().Replace("&nbsp;", "");
        Session["Rut"] = row.Cells[14].Text.Trim().Replace("&#209;", "Ñ");
        f_alta = grillacama.DataKeys[row.RowIndex]["_Fecha_alta"].ToString().Replace("&nbsp;", "");
        Session["Fecha_pedido"] = grillacama.DataKeys[row.RowIndex]["_Fecha_pedido"].ToString().Replace("&nbsp;", "");
   
        string s_fhoy = Session["FECHA_ACTUAL"].ToString();
        string s_fped = Session["Fecha_pedido"].ToString();

        if (s_fped != "")
        {

            if (Convert.ToDateTime(s_fhoy) == Convert.ToDateTime(s_fped) && Convert.ToDateTime(datepicker1.Text) == Convert.ToDateTime(s_fhoy))
            {
                Session["VIG"] = "S";
            }
            else
            {
                DateTime f = Convert.ToDateTime(fecha);
                string fecha_hoy = DateTime.Now.ToString("dd-MM-yyyy");
                DateTime f2 = Convert.ToDateTime(fecha_hoy);
                f2 = f2.AddDays(1);

                string[] H = hora.Split(':');
                string H1 = H[0];

                if (f2.ToString("dd-MM-yyyy") == datepicker1.Text && dt_listado_cama_2.Rows.Count > 0 && Convert.ToInt32(H1) >= 16)
                {
                    Session["FECH_M"] = f2.ToString("dd-MM-yyyy");
                    Session["VIG"] = "M";
                }

                else
                {
                    Session["VIG"] = "N";
                }


            }
        }
        else
        {
            DateTime f = Convert.ToDateTime(fecha);
            string fecha_hoy = DateTime.Now.ToString("dd-MM-yyyy");
            DateTime f2 = Convert.ToDateTime(fecha_hoy);
            f2 = f2.AddDays(1);



            string[] H = hora.Split(':');
            string H1 = H[0];

            if (fecha_hoy == datepicker1.Text)
            {
                Session["VIG"] = "S";

            }
            else
            {
                if (f2.ToString("dd-MM-yyyy") == datepicker1.Text && dt_listado_cama_2.Rows.Count > 0 && Convert.ToInt32(H1) >= 16)
                {
                    Session["FECH_M"] = f2.ToString("dd-MM-yyyy");
                    Session["VIG"] = "M";
                }
                else
                {
                    txtmsg.Text = "Estimado Usuario, Para Ingresar Alimentos al Pedido de Mañana deberá realizarse después de las 16 horas";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { msg(); });", true);
                }
            }
        }

        cama1.Text = Session["Cama"].ToString();
        habitacion1.Text = Session["Habitacion"].ToString();
        rut1.Text = Session["Rut"].ToString();
        nombre1.Text = Session["Nom_Paciente"].ToString();
        servicio1.Text = Session["Nom_Servicio"].ToString();
        cod_paciente = grillacama.DataKeys[row.RowIndex]["_Correlativo"].ToString().Replace("&nbsp;", "");
        cod_cama = grillacama.DataKeys[row.RowIndex]["_Cod_cama"].ToString().Replace("&nbsp;", "");
        ficha1.Text = Session["Ficha"].ToString();
      
        cargar_observacion();

        int cont = 0;
        DataTable dt_listado_cama = (DataTable)Session["tabla_cama"];

        if (f_alta == "")
        {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { informacion(); });", true);
        }
        else
        {
        txtmsg.Text = "Estimado Usuario, El Paciente se encuentra Egresado , por ende no se puede generar Pedido";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { msg(); });", true);
        }
       
    }


    protected void Btn_detalle_pedido(object sender, EventArgs e)
    {
        Button btndetails = sender as Button;
        GridViewRow row = (GridViewRow)btndetails.NamingContainer;


        cod_paciente = grillacama.DataKeys[row.RowIndex]["_Correlativo"].ToString().Replace("&nbsp;", "");
        cod_cama = grillacama.DataKeys[row.RowIndex]["_Cod_cama"].ToString().Replace("&nbsp;", "");
        Session["Cod_Paciente"] = grillacama.DataKeys[row.RowIndex]["_Correlativo"].ToString().Replace("&nbsp;", "");
        Session["Cama"] = row.Cells[11].Text.Trim().Replace("&nbsp;", "");
        Session["Habitacion"] = row.Cells[12].Text.Trim().Replace("&nbsp;", "");
        Session["Nom_Paciente"] = row.Cells[15].Text.Trim().Replace("&nbsp;", "").Replace("&#209;", "Ñ");
        Session["Nom_Servicio"] = row.Cells[16].Text.Trim().Replace("&nbsp;", "");
        Session["Ficha"] = grillacama.DataKeys[row.RowIndex]["_Cod_nhc"].ToString().Replace("&nbsp;", "");
        Session["Rut"] = row.Cells[14].Text.Trim().Replace("&#209;", "Ñ");
        Session["Fecha"] = grillacama.DataKeys[row.RowIndex]["_Fecha_hosp"].ToString().Replace("&nbsp;", "");
        string cod = grillacama.DataKeys[row.RowIndex]["_Cod_menu"].ToString().Replace("&nbsp;", "");
        string hora = grillacama.DataKeys[row.RowIndex]["_Hora"].ToString();
        Session["Cod_menu"] = cod;

        string f_p = grillacama.DataKeys[row.RowIndex]["_Fecha_pedido"].ToString().Replace("&nbsp;", "");
        int cod_p = Convert.ToInt32(grillacama.DataKeys[row.RowIndex]["_Cod_menu"].ToString().Replace("&nbsp;", ""));
        Session["_Cod_pedido"] = cod_p;

        if (f_p != "")
        {

            DateTime f = Convert.ToDateTime(fecha);
            string fecha_hoy = DateTime.Now.ToString("dd-MM-yyyy");
            DateTime f2 = Convert.ToDateTime(fecha_hoy);
            f2 = f2.AddDays(1);



            string[] H = hora.Split(':');
            string H1 = H[0];

            if (f2.ToString("dd-MM-yyyy") == datepicker1.Text && dt_listado_cama_2.Rows.Count > 0 )
            {
                txtmsg.Text = "Estimado Usuario, No se puede acceder a esta opción, porque la Ingesta se habilitara Mañana ";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { msg(); });", true);

            }

            else
            {
                Session["Fecha_pedido"] = f_p;
                Response.Redirect("Generar_Ingesta.aspx");
            }
          
        }

        else
        {
            txtmsg.Text = "Estimado Usuario, No se puede acceder a esta opción, porque no existe Pedido para este Paciente ";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { msg(); });", true);

        }

    }

    protected void Btn_envia_generar_ped(object sender, EventArgs e)
    {
        string r = obs;
        if (r == "" || r == null)
        {
             Guardar_observacion();
        }
        else
        {
    
            Modificar_observacion();
        }
    }

    protected void datepicker1_TextChanged(object sender, EventArgs e)
    {
       string fec = datepicker1.Text;
        Regex re = new Regex("^([0]?[0-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})$");

        if (re.IsMatch(fec))
        {
            f = datepicker1.Text;
           Cargar_grilla();
        }
        else
        {
            txtmsg.Text = "Estimado Usuario, La Fecha Ingresada no tiene el formato correcto";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { msg(); });", true);
            f = "";
            datepicker1.Text = "";
            datepicker1.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }  
    }
    


    protected void buscar(object sender, EventArgs e)
    {
        rut = txrut.Text;
        nombre = txnombre.Text.ToUpper();
        ficha = ficha_2.Text;
        f = datepicker1.Text;

        if (f == "")
        {
             fecha = DateTime.Now.ToString("dd/MM/yyyy");
        }
        else
        {      
             fecha = datepicker1.Text;
        }

        cod_servicio = Convert.ToInt32(cboservicio.SelectedValue);
        cod_estado = Convert.ToInt32(cboestado.SelectedValue);
        cod_tipo_comida = Convert.ToInt32(cbotipo_comida.SelectedValue);
        cod_turno = Convert.ToInt32(cboturno.SelectedValue);
        tipo_doc = 0;
        Cargar_grilla();

        limpiar();
    }

    #endregion

    #region Metodos

    protected Boolean Validar_estado_finalizado(DataTable dt)
    {
        Boolean var = false;
        int contador =0;

        contador  += Validar_tiempo_finalizado(dt, 1);
        contador += Validar_tiempo_finalizado(dt, 2);
        contador += Validar_tiempo_finalizado(dt, 3);
        contador += Validar_tiempo_finalizado(dt, 4);
        contador += Validar_tiempo_finalizado(dt, 5);
        contador += Validar_tiempo_finalizado(dt, 6);
        contador += Validar_tiempo_finalizado(dt, 7);
        contador += Validar_tiempo_finalizado(dt, 8);

        if (contador==8)
        {
            var = true;
        }

        return var;
    }

    protected int Validar_tiempo_finalizado(DataTable dt,int t_c)
    {
        int var = 0;

        foreach (DataRow row in dt.Select("_Cod_tipo_comida="+ t_c))
        {
           string v= row["_Vigencia_comida"].ToString();
           string ing= row["_Ingesta"].ToString();
           if (ing == "S" && v == "S")
           {
               var = 1;
           }
           else
           {
               if (ing == "" && v == "N")
               {
                   var = 1;
               }
               else
               {
                   var = 0;
               }
           }
           
        }

        return var;
    }

    protected Boolean Validar_estado(DataTable dt)
    {
        Boolean var = false;
        int valor = 0;
        int d = 0; int c1 = 0; int a = 0; int o = 0; int c = 0; int c2 = 0; int ce = 0; int hco = 0;
        int tipo = 0;
        int estado = 0;
        foreach (DataRow row in dt.Rows)
        {

           tipo = Convert.ToInt32(row["_Cod_tipo_comida"].ToString());
           estado = Convert.ToInt32(row["_Estado"].ToString());
           if (estado == 3)
           {
               switch (Convert.ToInt32(tipo))
               {
                   case 1:
                       if (d == 0)
                       {
                           int val1 = Existe_alimento(dt, tipo);
                           int val2 = Verificar_estado(dt, tipo);
                           if (val1 == 1 && val2 == 1)
                           {
                               valor= valor+ 1;
                           }
                           else
                           {
                               if (val1 == 0 && val2 == 1)
                               {
                                   valor=valor+ 1;
                               }
                               else
                               {
                                   if (val1 == 1 && val2 == 0)
                                   {
                                       valor = valor + 1;
                                   }
                                   else
                                   {
                                       valor = valor + 0;
                                   }
                               }
                           }

                       }
                       d++;
                       
                       break;
                   case 2:

                       if (c1 == 0)
                       {
                           int val1 = Existe_alimento(dt, tipo);
                           int val2 = Verificar_estado(dt, tipo);
                           if (val1 == 1 && val2 == 1)
                           {
                               valor = valor + 1;
                           }
                           else
                           {
                               if (val1 == 0 && val2 == 1)
                               {
                                   valor = valor + 1;
                               }
                               else
                               {
                                   if (val1 == 1 && val2 == 0)
                                   {
                                       valor = valor + 1;
                                   }
                                   else
                                   {
                                       valor = valor + 0;
                                   }
                               }
                           }
                       }
                       c1++;

                       break;
                   case 3:

                       if (a == 0)
                       {
                           int val1 = Existe_alimento(dt, tipo);
                           int val2 = Verificar_estado(dt, tipo);
                           if (val1 == 1 && val2 == 1)
                           {
                               valor = valor + 1;
                           }
                           else
                           {
                               if (val1 == 0 && val2 == 1)
                               {
                                   valor = valor + 1;
                               }
                               else
                               {
                                   if (val1 == 1 && val2 == 0)
                                   {
                                       valor = valor + 1;
                                   }
                                   else
                                   {
                                       valor = valor + 0;
                                   }
                               }
                           }
                       }
                       a++;

                       break;
                   case 4:

                      if (o == 0)
                       {
                           int val1 = Existe_alimento(dt, tipo);
                           int val2 = Verificar_estado(dt, tipo);
                           if (val1 == 1 && val2 == 1)
                           {
                               valor = valor + 1;
                           }
                           else
                           {
                               if (val1 == 0 && val2 == 1)
                               {
                                   valor = valor + 1;
                               }
                               else
                               {
                                   if (val1 == 1 && val2 == 0)
                                   {
                                       valor = valor + 1;
                                   }
                                   else
                                   {
                                       valor = valor + 0;
                                   }
                               }
                           }

                       }
                       o++;

                       break;
                   case 5:

                          if (c == 0)
                       {
                           int val1 = Existe_alimento(dt, tipo);
                           int val2 = Verificar_estado(dt, tipo);
                           if (val1 == 1 && val2 == 1)
                           {
                               valor = valor + 1;
                           }
                           else
                           {
                               if (val1 == 0 && val2 == 1)
                               {
                                   valor = valor + 1;
                               }
                               else
                               {
                                   if (val1 == 1 && val2 == 0)
                                   {
                                       valor = valor + 1;
                                   }
                                   else
                                   {
                                       valor = valor + 0;
                                   }
                               }
                           }

                       }
                       c++;
                       break;
                   case 6:

                          if (c2 == 0)
                       {
                           int val1 = Existe_alimento(dt, tipo);
                           int val2 = Verificar_estado(dt, tipo);
                           if (val1 == 1 && val2 == 1)
                           {
                               valor = valor + 1;
                           }
                           else
                           {
                               if (val1 == 0 && val2 == 1)
                               {
                                   valor = valor + 1;
                               }
                               else
                               {
                                   if (val1 == 1 && val2 == 0)
                                   {
                                       valor = valor + 1;
                                   }
                                   else
                                   {
                                       valor = valor + 0;
                                   }
                               }
                           }

                       }
                       c2++;

                       break;
                   case 7:

                          if (ce == 0)
                       {
                           int val1 = Existe_alimento(dt, tipo);
                           int val2 = Verificar_estado(dt, tipo);
                           if (val1 == 1 && val2 == 1)
                           {
                               valor = valor + 1;
                           }
                           else
                           {
                               if (val1 == 0 && val2 == 1)
                               {
                                   valor = valor + 1;
                               }
                               else
                               {
                                   if (val1 == 1 && val2 == 0)
                                   {
                                       valor = valor + 1;
                                   }
                                   else
                                   {
                                       valor = valor + 0;
                                   }
                               }
                           }

                       }
                       ce++;

                       break;
                   case 8:

                        if (hco == 0)
                       {
                           int val1 = Existe_alimento(dt, tipo);
                           int val2 = Verificar_estado(dt, tipo);
                           if (val1 == 1 && val2 == 1)
                           {
                               valor = valor + 1;
                           }
                           else
                           {
                               if (val1 == 0 && val2 == 1)
                               {
                                   valor = valor + 1;
                               }
                               else
                               {
                                   if (val1 == 1 && val2 == 0)
                                   {
                                       valor = valor + 1;
                                   }
                                   else
                                   {
                                       valor = valor + 0;
                                   }
                               }
                           }

                       }
                       hco++;

                       break;
               }
           }
           else
           {
               var = false;

           }
        }

        if (valor == 8)
        {
            var = true;
     
        }
        else
        {
            var = false;
        }

        return var;
    }

    protected int Existe_alimento(DataTable dt, int tipo )
    {
        int valor = 0;
        foreach (DataRow row1 in dt.Select("_Cod_tipo_comida=" + tipo))
        {
            
            if (Convert.ToInt32(row1["_Cod_tipo_alimento"].ToString()) > 0)
            {
                valor = 1;
            }
            else
            {
                valor = 0;
            }
            
        }
        return valor;
    }

    protected int Verificar_estado(DataTable dt, int tipo)
    {
        int valor = 0;
        foreach (DataRow row1 in dt.Select("_Cod_tipo_comida=" + tipo))
        {
            if (row1["_Vigencia_comida"].ToString() == "N")
            {
                valor = 1;
            }
            else{
                valor = 0;
            }
 
        }
        return valor;
    }

    #region Limpiar

    protected  void limpiar()
    {
        cboturno.SelectedIndex = 0;
        cbotipo_comida.SelectedIndex = 0;
        cboservicio.SelectedIndex = 0;
        cboestado.SelectedIndex = 0;
        txrut.Text = "";
        txnombre.Text = "";
        ficha_2.Text = "";
          
    }

    protected void volver(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");        
    }

    #endregion

    #region Convert Lista DataTables

    public static  DataTable ConvertToDataTable<T>(IList<T> data)
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

    #region Guardar Observacion 

    protected void  Guardar_observacion()
    {
        string descripcion = txtobservaciones.Text.ToUpper();
        string msg = new PedidosNE().Registrar_Observaciones(user, cod_paciente, descripcion);
        Response.Redirect("Generar_Pedido.aspx");
        
    }

    protected void  Modificar_observacion()
    {
        string descripcion = txtobservaciones.Text.ToUpper();
        string msg = new PedidosNE().Modificar_Observaciones(user, cod_paciente, descripcion);
        if (msg == "ok")
        {
            txtobservaciones.Text = descripcion.ToUpper();
            Response.Redirect("Generar_Pedido.aspx");
        }
    }

    protected void  cargar_observacion()
    {            
        Pedidos var = new PedidosNE().Cargar_Observacion(cod_paciente);
        obs = var._Observaciones;
        txtobservaciones.Text = obs;
    }

    #endregion

    #endregion

    #region Validaciones

    protected int validar_pedido()
    {
        int var = 0;
        int var2 = 0;

        if (cod_paciente == "" || cod_paciente == null)
        {
            var2 = 0;
            Pedidos ped = new PedidosNE().Cargar_pedidos2(var2);
            var = ped._Id;
            return var;
        }
        else
        {
            Pedidos ped = new PedidosNE().Cargar_pedidos2(Convert.ToInt32(cod_paciente));
            var = ped._Id;
            return var;
        }

         
    }

    #endregion

    }
 }