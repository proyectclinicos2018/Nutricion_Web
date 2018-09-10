using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using Oracle.DataAccess.Client;

namespace Falp.Capa_Datos
{
    public class ConectarFalp
    {
        private string v_DBNombre;
        private string v_DBUser;
        private string v_DBPass;
        private DbConnection CnnOracle;
        private DbTransaction DBtransaccion;
        private TipoBase v_TipoBase;
        private IDbCommand v_Command;
        private ConnectionState v_Estado;

        public TipoBase TipoBD
        {
            get { return v_TipoBase; }
            set { v_TipoBase = value; }
        }
        /// <summary>
        /// Indica la Base a la Cual nos estamos conectando
        /// </summary>
        public enum TipoBase
        {
            Oracle = 1,
            SqlServer = 2,
            MySql = 3,
            Teradata = 4
        }

        public string DBNombre
        {
            get { return v_DBNombre; }
            set { v_DBNombre = value; }
        }

        public string DBUser
        {
            get { return v_DBUser; }
            set { v_DBUser = value; }
        }

        public string DBPass
        {
            get { return v_DBPass; }
            set { v_DBPass = value; }
        }

        public ConnectionState Estado
        {
            get { return v_Estado; }
            set { v_Estado = value; }
        }

        public ConectarFalp()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public ConectarFalp(string NombreBD, string UserDB, string PassDB, TipoBase TipoBase)
        {
            DBNombre = NombreBD;
            DBUser = UserDB;
            DBPass = PassDB;
            TipoBD = TipoBase;

            switch (TipoBD)
            {
                case TipoBase.Oracle:
                    CnnOracle = new OracleConnection();
                    CnnOracle.ConnectionString = "User Id=" + DBUser + ";Password=" + DBPass + ";Data Source=" + DBNombre;
                    break;
                case TipoBase.SqlServer:

                    break;
                case TipoBase.MySql:

                    break;
                case TipoBase.Teradata:

                    break;
            }

        }

        /// <summary>
        /// Metodo que nos permite abrir nuestra conexion
        /// </summary>
        public void Abrir()
        {
            switch (TipoBD)
            {
                case TipoBase.Oracle:
                    CnnOracle.Open();
                    break;
                case TipoBase.SqlServer:

                    break;
                case TipoBase.MySql:

                    break;
                case TipoBase.Teradata:

                    break;
            }
            v_Estado = ConnectionState.Open;
        }

        /// <summary>
        /// Metodo que nos permite Cerrar nuestra conexion
        /// </summary>
        public void Cerrar()
        {
            v_Estado = ConnectionState.Closed;
            CnnOracle.Close();
        }


        /// <summary>
        /// Metodo que nos permite Crear un Command para Nuestra Conexión
        /// </summary>
        public void CrearCommand()
        {
            try
            {
                switch (TipoBD)
                {
                    case TipoBase.Oracle:
                        OracleCommand v_Command = new OracleCommand();
                        v_Command.Parameters.Clear();
                        break;
                    case TipoBase.SqlServer:

                        break;
                    case TipoBase.MySql:

                        break;
                    case TipoBase.Teradata:

                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// Metodo que nos permite Crear un Command para Nuestra Conexión
        /// </summary>
        /// <param name="TipoComando">Tabla, Texto o un Procedimiento</param>
        /// <param name="TextoSql">String que ejecutara nuestro Command</param>
        public void CrearCommand(CommandType TipoComando, string TextoSql)
        {
            try
            {
                switch (TipoBD)
                {
                    case TipoBase.Oracle:
                        v_Command = new OracleCommand();
                        v_Command.CommandType = TipoComando;
                        v_Command.CommandText = TextoSql;
                        v_Command.Connection = CnnOracle;
                        v_Command.Parameters.Clear();
                        break;
                    case TipoBase.SqlServer:

                        break;
                    case TipoBase.MySql:

                        break;
                    case TipoBase.Teradata:

                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Metodo que nos permite Crear un Parametro en la Base de Datos
        /// No es necesario declarar un cursor para ejecutar una consulta ExecuteReader()
        /// </summary>
        /// <param name="NomParam">Nombre del Parametro</param>
        /// <param name="ValorParam">Valor del Parametro</param>
        /// <param name="TipoParam">Tipo de Parametro (String, Integer, etc.) excepto RefCursor</param>
        /// <param name="DireccionParam">Dirección que tendra nuestro Parametro</param>
        public void ParametroBD(string NomParam, object ValorParam, DbType TipoParam, ParameterDirection DireccionParam)
        {
            if (v_Command != null)
            {
                IDbDataParameter param;
                param = v_Command.CreateParameter();
                param = CrearParametro(NomParam, ValorParam, TipoParam, DireccionParam, 0);

                v_Command.Parameters.Add(param);

                /* Falta la Coleccion de Parametros */
            }
            else
            {
                throw new Exception("Debe Crear el objeto Command antes de Enviar los Parametros (CrearCommand())");
            }
        }

        public void ParametroBD(string NomParam, object ValorParam, DbType TipoParam, ParameterDirection DireccionParam, Int32 Size)
        {
            if (v_Command != null)
            {
                IDbDataParameter param;
                param = v_Command.CreateParameter();
                param = CrearParametro(NomParam, ValorParam, TipoParam, DireccionParam, Size);

                v_Command.Parameters.Add(param);

                /* Falta la Coleccion de Parametros */
            }
            else
            {
                throw new Exception("Debe Crear el objeto Command antes de Enviar los Parametros (CrearCommand())");
            }
        }

        protected IDbDataParameter CrearParametro(string Nombre, object Valor, DbType Tipo, ParameterDirection Direccion, Int32 Size)
        {
            try
            {
                IDbDataParameter param = null;
                switch (TipoBD)
                {
                    /*case TipoBase.Oracle:
                        param = new OracleParameter();
                        param.ParameterName = Nombre;
                        param.Value = Valor;
                        param.DbType = Tipo;
                        param.Direction = Direccion;*/

                    case TipoBase.Oracle:
                        param = new OracleParameter();
                        param.ParameterName = Nombre;
                        param.Value = Valor;
                        param.DbType = Tipo;
                        param.Direction = Direccion;

                        if ((ParameterDirection.ReturnValue == Direccion || ParameterDirection.Output == Direccion) && (DbType.String == Tipo || DbType.StringFixedLength == Tipo))
                        {
                            param.Size = Size;
                        }

                        break;
                    case TipoBase.MySql:
                        param = new OracleParameter();
                        param.ParameterName = Nombre;
                        param.Value = Valor;
                        param.DbType = Tipo;
                        param.Direction = Direccion;
                        break;
                    case TipoBase.Teradata:
                        param = new OracleParameter();
                        param.ParameterName = Nombre;
                        param.Value = Valor;
                        param.DbType = Tipo;
                        param.Direction = Direccion;
                        break;
                }
                return param;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Metodo que Retornara un IDataReader a nuestra Aplicación
        /// </summary>
        /// <returns></returns>
        public IDataReader ExecuteReader()
        {
            try
            {
                IDbDataParameter param = null;
                switch (TipoBD)
                {
                    case TipoBase.Oracle:
                        param = new OracleParameter("OUT_VDATOS", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output);
                        v_Command.Parameters.Add(param);
                        break;
                    case TipoBase.MySql:

                        break;
                    case TipoBase.Teradata:
                        break;
                }
                return v_Command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ExecuteNonQuery()
        {
            return v_Command.ExecuteNonQuery();
        }

        public object ExecuteScalar()
        {
            return v_Command.ExecuteScalar();
        }

        /// <summary>
        /// Metodo que nos permite identificar el inicio de una transacción
        /// </summary>
        public void IniciarTransaccion()
        {
            DBtransaccion = CnnOracle.BeginTransaction();

        }
        /// <summary>
        /// Metodo que nos permite indicar que la transacción Iniciada (IniciarTransaccion()) sera Confirmada.
        /// </summary>
        public void ConfirmarTransaccion()
        {
            DBtransaccion.Commit();
        }

        /// <summary>
        /// Metodo que nos permite indicar que la transacción Iniciada (IniciarTransaccion()) sera Reversada.
        /// </summary>
        public void ReversarTransaccion()
        {
            DBtransaccion.Rollback();
        }

        /// <summary>
        /// Metodo que nos permite Obtener el valor de un Parametro Ingresado por su Nombre
        /// </summary>
        /// <param name="Nombre">Nombre del Parametro a Buscar</param>
        /// <returns></returns>
        public object ParamValue(string Nombre)
        {
            try
            {
                foreach (IDbDataParameter Param in v_Command.Parameters)
                {
                    if (Param.ParameterName.ToUpper() == Nombre.ToUpper())
                    {
                        return Param.Value;
                    }
                }
                throw new Exception("No Existe este Nombre de Parametro");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Metodo que nos permite Obtener el valor de un Parametro Ingresado por su Indice
        /// </summary>
        /// <param name="Indice">Indice del Parametro ingresado</param>
        /// <returns></returns>
        public object ParamValue(Int16 Indice)
        {
            Int32 Vuelta;
            try
            {
                if (Indice > (v_Command.Parameters.Count - 1))
                {
                    throw new Exception("No Existe este Indice en la Colección de Parametros");
                }
                else
                {
                    Vuelta = 0;
                    foreach (IDbDataParameter Param in v_Command.Parameters)
                    {
                        if (Indice == Vuelta)
                        {
                            return Param.Value;
                        }
                        Vuelta += 1;
                    }
                    throw new Exception("No Existe este Indice en la Colección de Parametros");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
