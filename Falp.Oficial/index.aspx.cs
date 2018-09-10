using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using Falp.Entidades;
using Falp.Capa_Negocios;

namespace Falp.Oficial
{
    public partial class index : System.Web.UI.Page
    {
        string user = "";
        string pass = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected int validarusuario()
        {
            user = Request.Form["inputEmail"];
            pass = Request.Form["inputPassword"];
            int var = 0;
            Usuarios us = new UsuariosNE().Validar_usuario(user, pass);


            if (us._Usuario == "" && us._Password == "")
            {
                var = 0;
            }
            else
            {
                var = 1;

            }
            return var;

        }

        protected void ingresar(object sender, EventArgs e)
        {
            int val = validarusuario();
            if (val == 1)
            {
                Session["Usuario"] = user;
                Response.Redirect("Home.aspx");
            }
            else
            {

                string res1 = "Estimado Usuario, El  Usuario ingresado  o la  Contraseña  es incorrecta";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup1('" + res1 + "');", true);
                inputEmail.Value = "";
                inputPassword.Value = "";
            }

        }

     


    }
}