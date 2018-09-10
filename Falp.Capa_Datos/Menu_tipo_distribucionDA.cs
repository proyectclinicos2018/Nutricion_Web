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
   public  class Menu_tipo_distribucionDA
    {
       
        string res = "";
        string BD = ConfigurationManager.AppSettings["BD"];
        string User = ConfigurationManager.AppSettings["Usuario"];
        string Pass = ConfigurationManager.AppSettings["Pass"];
        ConectarFalp conn;

        public string Registrar_Tipo_Distribucion(Menu_tipo_distribucion var,string mixto,string obs)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_MENU_REG_COM_DET");

                conn.ParametroBD("PIN_COD_MENU_DET", var._Cod_pedido_det, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DISTRIBUCION", var._Cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_USER", var._User_crea, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_MIXTO", mixto, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_OBSERVACION", obs, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("POUT_REG_COMIDA_DET", 0, DbType.Int64, ParameterDirection.Output);

                int registro = conn.ExecuteNonQuery();

                conn.Cerrar();

                return conn.ParamValue("POUT_REG_COMIDA_DET").ToString();
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }


        public string Modificar_Tipo_Distribucion(Menu_tipo_distribucion var, string mixto, string obs)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001M.P_MODIFICAR_MENU_REG_COM_DET");

                conn.ParametroBD("PIN_COD_MENU_DET", var._Cod_pedido_det, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DISTRIBUCION", var._Cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_USER", var._User_crea, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_MIXTO", mixto, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_OBSERVACION", obs, DbType.String, ParameterDirection.Input);



                int registro = conn.ExecuteNonQuery();

                conn.Cerrar();

                if (registro > -2)
                {
                    res = "ok";
                }
                else
                {

                    res = "error";
                }

                return res;

            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }
    }
}
