using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Falp.Oficial
{
    public partial class Paciente_Pedido : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Variables

            string user = "";

            #endregion

            if (IsPostBack == false)
            {
                if (Session["Usuario"] != null)
                {

                    user = Session["Usuario"].ToString();
                    txttipo.Text=Session["Tipo_Alimento"].ToString();

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
                 

                    buscar_paciente();

                    string com = Session["Comentario_comida"].ToString();
                    if (com == "")
                    {
                        txtcomentario_comida.Text = "";
                    }
                    else
                    {
                        txtcomentario_comida.Text = com;
                    }

                   string  vig = Session["VIG"].ToString();

                     if (vig == "N")
                     {
                         txtcomentario_comida.Enabled = false;
                     }
              
           
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
          
            txtpaciente1.Text = Session["Nom_Paciente"].ToString();
            txtservicio1.Text = Session["Nom_Servicio"].ToString();
        }

        protected void txtcomentario_comida_TextChanged(object sender, EventArgs e)
        {
            Session["Comentario_comida"] = txtcomentario_comida.Text.ToUpper();
        }
    


    }
}