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
   public  class UsuariosDA
   {

  
        string res = "";
        string BD = ConfigurationManager.AppSettings["BD"];
        string User = ConfigurationManager.AppSettings["Usuario"];
        string Pass = ConfigurationManager.AppSettings["Pass"];
        ConectarFalp conn;

        public Usuarios Validar_usuario(string usuarios, string password)
        {

            Usuarios var = new Usuarios();
                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_VALIDAR_USUARIOS");

                conn.ParametroBD("PIN_USUARIO", usuarios.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_PASSWORD", password.ToUpper(), DbType.String, ParameterDirection.Input);
                IDataReader lector = conn.ExecuteReader();

               

                if (lector.Read())
                {

                    var._Usuario = lector["USUARIOS"].Equals(DBNull.Value) ? string.Empty : (string)lector["USUARIOS"];
                    var._Password = lector["PASSWORD"].Equals(DBNull.Value) ? string.Empty : (string)lector["PASSWORD"];
                }
                else
                {
                      var._Usuario = "";
                      var._Password="";
                }
                conn.Cerrar();

                return var;
            }
   }
}
