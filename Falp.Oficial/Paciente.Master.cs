using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Falp.Entidades;
using Falp.Capa_Negocios;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Falp.Oficial
{
    public partial class Paciente : System.Web.UI.MasterPage
    {
        #region Variables

        string user = "";

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["Usuario"] != null)
                {

                    user = Session["Usuario"].ToString();

                    nombre.Text = user.ToUpper();
                    string ser = ConfigurationManager.AppSettings["BD"];

                    if (ser == "BD_DESA.WORLD")
                    {
                        txtserver.Text = "DESA";
                    }
                    else
                    {

                        if (ser == "BD_QA.WORLD")
                        {
                            txtserver.Text = "QA";
                        }
                        else
                        {

                            txtserver.Text = "PROD";
                        }
                    }
                    Cargar_tipo_documento();
          
                    buscar_paciente();
                

                }
                else
                {
                    Response.Redirect("index.aspx");
                    Session["Usuario"] = "";
                }

            }
        }
        protected void salir(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
            Session["Usuario"] = "";


        }


        protected void buscar_paciente()
        {
            string cod_paciente = Session["Cod_Paciente"].ToString();


   
            txtficha1.Text = Session["Ficha"].ToString();

            cbodocumento.SelectedIndex = Convert.ToInt32(Session["Tipo_doc"].ToString());
            txtnum_doc1.Text = Session["Rut"].ToString();
            txtpaciente1.Text = Session["Nom_Paciente"].ToString();
            txtcama1.Text = Session["Cama"].ToString();
            txthabitacion1.Text = Session["Habitacion"].ToString();
            txtservicio1.Text = Session["Nom_Servicio"].ToString();
           // txtnombre.Value = Convert.ToString(pac._Nombres);
        }


        protected void Cargar_tipo_documento()
        {
            try
            {

                List<Utilidades> lista_tipo_doc = new UtilidadesNE().Cargartipo_doc();
                cbodocumento.DataSource = lista_tipo_doc;
                cbodocumento.DataTextField = "_Nom_tipo_doc";
                cbodocumento.DataValueField = "_Cod_tipo_doc";
                cbodocumento.DataBind();
                cbodocumento.Items.Insert(0, new ListItem("Seleccionar", "0"));

       
            }

            catch (Exception ex)
            {
             
                System.Console.Write(ex.Message);
            }
        }



    


    }
}