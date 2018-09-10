using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;

using System.Configuration;
using System.Data.Common;
using Falp.Entidades;



namespace Falp.Capa_Datos
{
   public  class Cama_PacienteDA
    {
     

        string res = "";
        string BD = ConfigurationManager.AppSettings["BD"];
        string User = ConfigurationManager.AppSettings["Usuario"];
        string Pass = ConfigurationManager.AppSettings["Pass"];
        ConectarFalp conn;

        DataTable dt_pac = new DataTable();
        static string cod_pac = "0";
        


        public List<Cama_Pacientes> ListadoCamaPacientes(int tipo_doc,string rut,int cod_servicio,int  cod_turno,int cod_estado,int cod_tipo_comida, string  nombre, string ficha, string  fecha)
        {
            try
            {
                if (ficha == "") ficha = "0";
             
                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_LISTADO_CAMAS_PAC");
                conn.ParametroBD("PIN_TIPO_DOC", tipo_doc, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_RUT", rut, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_SERVICIO", cod_servicio, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TURNO", cod_turno, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_ESTADO", cod_estado, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_COMIDA", cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_NOMBRE", nombre, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_FICHA", ficha, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Cama_Pacientes> lista = new List<Cama_Pacientes>();

                while (lector.Read())
                {
                    Cama_Pacientes var = new Cama_Pacientes();
                    var._Correlativo = lector["CORRELATIVO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CORRELATIVO"]);
                    //var._Id = lector["CAMA_ID"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CAMA_ID"]);
                   // var._Id_pac = lector["PAC_ID"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["PAC_ID"]);
                   // var._Ficha = lector["FICHA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["FICHA"]);
                    var._Cod_nhc = lector["NHC"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["NHC"]);
                    var._Num_cama = lector["NUM_CAMA"].Equals(DBNull.Value) ? string.Empty : lector["NUM_CAMA"].ToString();
                    var._Cod_habitacion = lector["COD_HABITACION"].Equals(DBNull.Value) ? string.Empty : lector["COD_HABITACION"].ToString();
                    var._Nom_habitacion = lector["NOM_HABITACION"].Equals(DBNull.Value) ? string.Empty : lector["NOM_HABITACION"].ToString();
                    var._Cod_servicio = lector["COD_SERVICIO"].Equals(DBNull.Value) ? string.Empty : lector["COD_SERVICIO"].ToString();
                    var._Nom_servicio = lector["NOM_SERVICIO"].Equals(DBNull.Value) ? string.Empty : lector["NOM_SERVICIO"].ToString();
                    var._Cod_cama = lector["COD_CAMA"].Equals(DBNull.Value) ? string.Empty : lector["COD_CAMA"].ToString();
                    var._Tipo_doc = lector["TIPO_DOC"].Equals(DBNull.Value) ? string.Empty : lector["TIPO_DOC"].ToString();
                    var._Num_doc = lector["RUT"].Equals(DBNull.Value) ?  string.Empty: lector["RUT"].ToString();
                    var._Nombres = lector["NOMBRES"].Equals(DBNull.Value) ? string.Empty : lector["NOMBRES"].ToString();
                    var._Estado = lector["COD_ESTADO_PEDIDO"].Equals(DBNull.Value) ? string.Empty : lector["COD_ESTADO_PEDIDO"].ToString();
                    var._Nom_estado = lector["NOM_ESTADO_PEDIDO"].Equals(DBNull.Value) ? string.Empty : lector["NOM_ESTADO_PEDIDO"].ToString();
                    var._Estado_cama = lector["CAMA_ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["CAMA_ESTADO"].ToString();
                    var._Cod_turno = lector["COD_TURNOS"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TURNOS"]);
                  /*  var._Cod_tipo_comida = lector["COD_TIPO_COMIDA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_COMIDA"]);
                    var._Nom_tipo_comida = lector["NOM_TIPO_COMIDA"].Equals(DBNull.Value) ? string.Empty : lector["NOM_TIPO_COMIDA"].ToString();
                    var._Cod_tipo_distribucion = lector["COD_DISTRIBUCION"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_COMIDA"]);
                    var._Nom_tipo_distribucion = lector["NOM_DISTRIBUCION"].Equals(DBNull.Value) ? string.Empty : lector["NOM_DISTRIBUCION"].ToString();
                    var._Cod_tipo_alimento = lector["COD_ALIMENTO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_ALIMENTO"]);
                    var._Nom_tipo_alimento= lector["NOM_ALIMENTO"].Equals(DBNull.Value) ? string.Empty : lector["NOM_ALIMENTO"].ToString();*/
                    var._Cod_menu = lector["COD_MENU"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_MENU"]);
                   var._Fecha_hosp = lector["FECHA_HOSP"].Equals(DBNull.Value) ? string.Empty : lector["FECHA_HOSP"].ToString();
                   var._Fecha_alta= lector["FECHA_ALTA"].Equals(DBNull.Value) ? string.Empty : lector["FECHA_ALTA"].ToString();
                   var._Fecha_pedido = lector["FECHA_PEDIDO"].Equals(DBNull.Value) ? string.Empty : lector["FECHA_PEDIDO"].ToString();
                   var._Hora = lector["HORA"].Equals(DBNull.Value) ? string.Empty : lector["HORA"].ToString();
                 /*   var._Ingesta = lector["INGESTA"].Equals(DBNull.Value) ? string.Empty : lector["INGESTA"].ToString();
                    var._Vale_impreso = lector["VALE"].Equals(DBNull.Value) ? string.Empty : lector["VALE"].ToString();*/
                    lista.Add(var);
                }
                conn.Cerrar();

                return lista;
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public List<Cama_Pacientes> ListadoCamaPacientes2(int cod_paciente, string fecha)
        {
            try
            {
                

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_VALIDAR_ALIM_PEDIDO");
                conn.ParametroBD("PIN_COD_PACIENTE", cod_paciente, DbType.Int64, ParameterDirection.Input);
    
                conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Cama_Pacientes> lista = new List<Cama_Pacientes>();

                while (lector.Read())
                {
                    Cama_Pacientes var = new Cama_Pacientes();
                    var._Cod_menu = lector["COD_PEDIDO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_PEDIDO"]);
                    var._Cod_tipo_comida = lector["COD_TIPO_COMIDA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_COMIDA"]);
                    var._Cod_tipo_alimento = lector["COD_TIPO_ALIMENTO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_ALIMENTO"]);
                    var._Estado = lector["ESTADO_PEDIDO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO_PEDIDO"].ToString();
                    var._Estado_cama = lector["VALE"].Equals(DBNull.Value) ? string.Empty : lector["VALE"].ToString();
                    var._Ingesta = lector["INGESTA"].Equals(DBNull.Value) ? string.Empty : lector["INGESTA"].ToString();
                    var._Vigencia_comida = lector["VIGENCIA_COMIDA"].Equals(DBNull.Value) ? string.Empty : lector["VIGENCIA_COMIDA"].ToString();
                    var._Vigencia_alimento = lector["VIGENCIA_ALI"].Equals(DBNull.Value) ? string.Empty : lector["VIGENCIA_ALI"].ToString();
                  /*  var._Fecha_hosp = lector["FECHA_HOSP"].Equals(DBNull.Value) ? string.Empty : lector["FECHA_HOSP"].ToString();
                    var._Fecha_alta = lector["FECHA_ALTA"].Equals(DBNull.Value) ? string.Empty : lector["FECHA_ALTA"].ToString();*/
                    lista.Add(var);
                }
                conn.Cerrar();

                return lista;
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public List<Cama_Pacientes> Listadoestadistico()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGO_ESTADISTICA");



                IDataReader lector = conn.ExecuteReader();

                List<Cama_Pacientes> lista = new List<Cama_Pacientes>();

                while (lector.Read())
                {
                    Cama_Pacientes var = new Cama_Pacientes();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : (string)lector["ESTADO"];
                    var._Cantidad= lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);
           

                    lista.Add(var);
                }
                conn.Cerrar();

                return lista;
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public string Liberar_cama(string cod_cama,string cod_paciente)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001M.P_LIBERAR_CAMA");

                conn.ParametroBD("PIN_COD_CAMA", cod_cama, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_PACIENTE", cod_paciente, DbType.Int64, ParameterDirection.Input);
           

                int registro = conn.ExecuteNonQuery();
                if (registro > -2)
                {
                    res = "ok";
                }
                else
                {
                    res = "Error";
                }
                conn.Cerrar();

                return res;

            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }


        public string Verificar_paciente(string cod_cama, string cod_paciente,string cod_servicio)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_VERIFICAR_PACIENTE");

                conn.ParametroBD("PIN_COD_CAMA", cod_cama, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_PACIENTE", cod_paciente, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_SERVICIO", cod_servicio, DbType.Int64, ParameterDirection.Input);


                dt_pac.Load(conn.ExecuteReader());

                if (dt_pac.Rows.Count > 0)
                {
                    cod_pac = dt_pac.Rows[0]["cod_pac"].ToString();
                }
                else
                {
                    cod_pac = "0";
                }

                return cod_pac;

            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }


        public string Actualizar_paciente()
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_TRASPASA_PAC_EHCOS");

                int registro = conn.ExecuteNonQuery();

             

                return "ok";

            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

    }
}
