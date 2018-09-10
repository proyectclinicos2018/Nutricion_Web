using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Falp.Oficial
{
    public partial class General2 : System.Web.UI.MasterPage
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

    }
}