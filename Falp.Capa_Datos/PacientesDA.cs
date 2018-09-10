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
    public  class PacientesDA
    {
      
        string res = "";
        string BD = ConfigurationManager.AppSettings["BD"];
        string User = ConfigurationManager.AppSettings["Usuario"];
        string Pass = ConfigurationManager.AppSettings["Pass"];
        ConectarFalp conn;

        public Pacientes Cargar_paciente(int tipo, string filtro)
        {
            try
            {
                Pacientes var = new Pacientes();
                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_PACIENTE");

                conn.ParametroBD("PIN_COD_TIPO_BUSQUEDA", tipo, DbType.Int32, ParameterDirection.Input);
                conn.ParametroBD("PIN_FILTRO", filtro, DbType.String, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                if (lector.Read())
                {

                    var._Id_pac = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Ficha = lector["FICHA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["FICHA"]);
                    var._Folio = lector["FOLIO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["FOLIO"]);
                    var._Tipo_doc = lector["TIPO_DOC"].Equals(DBNull.Value) ? "0" : Convert.ToString(lector["TIPO_DOC"]);
                    var._Num_doc = lector["NUM_DOC"].Equals(DBNull.Value) ? string.Empty : lector["NUM_DOC"].ToString();
                    var._Nombres = lector["NOMBRES"].Equals(DBNull.Value) ? string.Empty : (string)lector["NOMBRES"];
                 

                }
                else
                {
                    var._Id_pac = 0;
                }
                conn.Cerrar();

                return var;
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public Pacientes Cargar_paciente( string cod_paciente)
        {
            try
            {
                Pacientes var = new Pacientes();
                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_PACIENTE_ID");

                conn.ParametroBD("PIN_COD_PACIENTE", cod_paciente, DbType.Int32, ParameterDirection.Input);


                IDataReader lector = conn.ExecuteReader();

                if (lector.Read())
                {

                    var._Id_pac = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Ficha = lector["FICHA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["FICHA"]);
                    var._Folio = lector["FOLIO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["FOLIO"]);
                    var._Tipo_doc = lector["TIPO_DOC"].Equals(DBNull.Value) ? "0" : Convert.ToString(lector["TIPO_DOC"]);
                    var._Num_doc = lector["NUM_DOC"].Equals(DBNull.Value) ? string.Empty : lector["NUM_DOC"].ToString();
                    var._Nombres = lector["NOMBRES"].Equals(DBNull.Value) ? string.Empty : (string)lector["NOMBRES"];
                /*    var._Nom_institucion = lector["NOM_INSTITUCION"].Equals(DBNull.Value) ? string.Empty : (string)lector["NOM_INSTITUCION"];
                    var._Nom_prevision = lector["NOM_PREVISION"].Equals(DBNull.Value) ? string.Empty : (string)lector["NOM_PREVISION"];
                    var._Nom_plan_previsional = lector["NOM_PLAN_PREVISIONAL"].Equals(DBNull.Value) ? string.Empty : (string)lector["NOM_PLAN_PREVISIONAL"];*/


                }
                else
                {
                    var._Id_pac = 0;
                }
                conn.Cerrar();

                return var;
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public string Registrar_Paciente(Pacientes var)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_PACIENTE");

                conn.ParametroBD("PIN_FOLIO", var._Ficha, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_FICHA", var._Folio, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_TIPO_DOC", var._Tipo_doc, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_NUM_DOC", var._Num_doc, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_NOMBRES", var._Nombres.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("POUT_PAC_ID", 0, DbType.Int64, ParameterDirection.Output);

                int registro = conn.ExecuteNonQuery();

                conn.Cerrar();

                return conn.ParamValue("POUT_PAC_ID").ToString();
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

    }
}
