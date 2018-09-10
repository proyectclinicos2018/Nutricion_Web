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
using System.Configuration;

namespace Falp.Oficial
{
    public partial class General_Oficial : System.Web.UI.MasterPage
    {

        #region Variables

        static string user = "";
        string rut = "";
        string nombre1 = "";
        string ficha = "";

        int cod_estado = 0;
        int cod_turno = 0;
        int cod_tipo_comida = 0;
        int tipo_doc = 0;
        int tipo_menu = 0;
        int cod_servicio = 0;

        static int cod_n_a = 0;
        static int cod_c = 0;
        static int cod_i = 0;
        static int cod_n_p = 0;
        static int cod_n_e = 0;
        static int cod_a = 0;
        static int cod_c_b = 0;
        static int cod_p_a = 0;
        static int cod_f = 0;

        static string cod_pedido = "";
        static string cod_cama = "";
        static string cod_paciente = "";
        static string nom_paciente = "";

        static string obs = "";
        static string f = "";

        List<Cama_Pacientes> lista_cama_paciente = new List<Cama_Pacientes>();
        List<Cama_Pacientes> lista_cama_paciente2 = new List<Cama_Pacientes>();
        List<Cama_Pacientes> lista_cama_paciente3 = new List<Cama_Pacientes>();
        Cama_Pacientes var = new Cama_Pacientes();
        #endregion

        #region DataTable
        DataTable dt_listado_cama = new DataTable();
        DataTable dt_listado_cama_2 = new DataTable();
        DataTable dt_listado_alimento = new DataTable();
         DataTable dt_resumen = new DataTable();
        #endregion 
 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["Usuario"] != null)
                {

                    user = Session["Usuario"].ToString();
                  
                   nombre2.Text = user.ToUpper();
                    Cargar_grilla();
                   string  ser = ConfigurationManager.AppSettings["BD"];

                    if(ser=="BD_DESA.WORLD")
                    {
                        txtserver.Text = "DESA";
                    }
                    else{

                        if(ser=="BD_QA.WORLD")
                        {
                            txtserver.Text = "QA";
                        }
                        else{

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


        protected void Cargar_grilla()
        {
            int n_a = 0;
            int c = 0;
            int i = 0;
            int a = 0;
            int n_e = 0;
            int n_p = 0;
            int c_b = 0;
            int p_a = 0;
            int f = 0;
            int cod = 0;
            string est = "";
            Session["n_a"] = "0";
            Session["c"] = "0";
            Session["i"] = "0";
            Session["n_e"] = "0";
            Session["n_p"] = "0";
            Session["a"] = "0";
            Session["c_b"] = "0";
            Session["p_a"] = "0";
            Session["f"] = "0";

            string res = new PedidosNE().Cambiar_menu();

            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            fec.Text = fecha;
          //  string res1 = new PedidosNE().Cambiar_estado_Pedido(fecha);

            Cama_PacienteNE var1 = new Cama_PacienteNE();
            lista_cama_paciente = var1.ListadoCamaPacientes(0, "", Convert.ToInt32(0), 0, 0, 0, "", "", fecha);
            dt_listado_cama_2 = ConvertToDataTable(lista_cama_paciente);

            int cod_1 = 0;
            int cod_2 = 0;
            string fe = "";

            foreach (DataRow row in dt_listado_cama_2.Rows)
            {
                est = row["_Estado"].ToString();
                fe=row["_Fecha_alta"].ToString();

                if (est == "" && fe == "" || est == "1" && fe == "")
                {

                    n_a = n_a + 1;
                    Session["n_a"] = n_a.ToString();
                }
                else
                {
                    if (est == "2" && fe == "")
                    {

                        c = c + 1;
                        Session["c"] = c.ToString();
                    }
                    else
                    {
                        if (est == "3" && fe == "")
                        {

                            i = i + 1;
                            Session["i"] = i.ToString();
                        }
                        else
                        {
                            if (est == "4" && fe == "")
                            {

                                n_e = n_e + 1;
                                Session["n_e"] = n_e.ToString();
                            }
                            else
                            {
                                if (est == "5" && fe == "")
                                {

                                    n_p = n_p + 1;
                                    Session["n_p"] = n_p.ToString();
                                }
                                else
                                {
                                    if (est == "6" && fe == "")
                                    {
                                       
                                        a = a + 1;
                                        Session["a"] = a.ToString();
                                    }
                                    else
                                    {
                                        if (est == "7" && fe == "")
                                        {

                                            c_b = c_b + 1;
                                            Session["n_a"] = n_a.ToString();
                                        }
                                        else
                                        {
                                            if (est == "8"  || fe!="")
                                            {

                                                p_a = p_a + 1;
                                                Session["p_a"] = p_a.ToString();
                                            }
                                            else
                                            {
                                                if (est == "9" && fe == "")
                                                {


                                                    Session["f"] = f.ToString();
                                                    f = f + 1;
                                                    Session["f"] = f.ToString();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }


                    grillacama.DataSource = lista_cama_paciente3;
                    grillacama.DataBind();



                }
            }
            cargar();
        }

     protected void  cargar()
     {
         
            Crear_Tabla_resumen();
            Llenar_Tabla_resumen(1, "NO ASIGNADO", Convert.ToInt32(Session["n_a"].ToString()));
            Llenar_Tabla_resumen(2, "COMPLETO", Convert.ToInt32(Session["c"].ToString()));
            Llenar_Tabla_resumen(3, "INCOMPLETO", Convert.ToInt32(Session["i"].ToString()));
                    Llenar_Tabla_resumen(4, "NUT ENTERAL",Convert.ToInt32(Session["n_e"].ToString()));
                    Llenar_Tabla_resumen(5, "NUT PARENTERAL", Convert.ToInt32(Session["n_p"].ToString()));
                    Llenar_Tabla_resumen(6, "AYUNO", Convert.ToInt32(Session["a"].ToString()));
                    Llenar_Tabla_resumen(7, "CERO BOCA", Convert.ToInt32(Session["c_b"].ToString()));
                    Llenar_Tabla_resumen(8, "PAC. ALTA ADMINISTRATIVA", Convert.ToInt32(Session["p_a"].ToString()));
                    Llenar_Tabla_resumen(9, "FINALIZADO", Convert.ToInt32(Session["f"].ToString()));
     }



          private void Llenar_Tabla_resumen(int cod, string nom,int  cant)
        {
            DataRow Fila = dt_resumen.NewRow();

            Fila["_Id"] = cod;
            Fila["_Estado"] = nom;
            Fila["_Cantidad"] =cant;
          

            dt_resumen.Rows.Add(Fila);
            grillacama.AutoGenerateColumns = false;

            DataView DTW = new DataView(dt_resumen, "", string.Empty, DataViewRowState.CurrentRows);
            grillacama.DataSource = DTW;
            Session["dt_resumen_2"] = dt_resumen;

            grillacama.DataBind();
        }

        private void  Crear_Tabla_resumen()
        {
            dt_resumen.Columns.Add("_Id", typeof(int));
            dt_resumen.Columns.Add("_Estado", typeof(string));
            dt_resumen.Columns.Add("_Cantidad", typeof(int));
        

            Session["dt_resumen_2"] = dt_resumen;
        }

        protected void grillacama_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grillacama.PageIndex = e.NewPageIndex;
            grillacama.DataBind();
            Cargar_grilla();


        }



        #region Convert Lista DataTables

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
    }
}