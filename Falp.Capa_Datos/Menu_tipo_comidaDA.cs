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
   public  class Menu_tipo_comidaDA
    {

        string res = "";
        string BD = ConfigurationManager.AppSettings["BD"];
        string User = ConfigurationManager.AppSettings["Usuario"];
        string Pass = ConfigurationManager.AppSettings["Pass"];
        ConectarFalp conn;

        public string Registrar_Tipo_Comida(Menu_tipo_comida var,string vigencia)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_REG_COMIDA");

                conn.ParametroBD("PIN_COD_MENU", var._Cod_pedido, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_COMIDA", var._Cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_USER", var._User_crea, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_VIGENCIA", vigencia, DbType.String, ParameterDirection.Input);
              
          

                conn.ParametroBD("POUT_REG_COMIDA", 0, DbType.Int64, ParameterDirection.Output);

                int registro = conn.ExecuteNonQuery();

                conn.Cerrar();

                return conn.ParamValue("POUT_REG_COMIDA").ToString();
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public string Modificar_Tipo_Comida(Menu_tipo_comida var,string v)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001M.P_MODIFICAR_REG_COMIDA");

                conn.ParametroBD("PIN_COD_MENU", var._Cod_pedido, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_COMIDA", var._Cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_USER", var._User_crea, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_VIGENCIA", v, DbType.String, ParameterDirection.Input);


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



        public string Modificar_Tipo_Comida_comentario(Menu_tipo_comida var, string comentario)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001M.P_MODIFICAR_REG_COMIDA_COMENT");

                conn.ParametroBD("PIN_COD_PEDIDO", var._Cod_pedido, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_COMIDA", var._Cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_USUARIO", var._User_modifica, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_COMENTARIO", comentario, DbType.String, ParameterDirection.Input);


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
