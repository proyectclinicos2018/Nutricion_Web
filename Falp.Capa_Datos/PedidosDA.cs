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
    public class PedidosDA
    {

        string res = "";
        string BD = ConfigurationManager.AppSettings["BD"];
        string User = ConfigurationManager.AppSettings["Usuario"];
        string Pass = ConfigurationManager.AppSettings["Pass"];
        ConectarFalp conn;

        public Pedidos Cargar_pedidos(int cod_pedido)
        {
            try
            {
                Pedidos var = new Pedidos(); 
                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_PEDIDO");

                conn.ParametroBD("PIN_COD_PEDIDO", cod_pedido, DbType.Int64, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Pedidos> lista = new List<Pedidos>();

                if (lector.Read())
                {

                    var._Id = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Cod_paciente = lector["COD_PACIENTE"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Cod_cama = lector["COD_CAMA"].Equals(DBNull.Value) ? string.Empty : lector["CODIGO"].ToString();
                    var._Cod_tipo_consistencia = lector["COD_CONSISTENCIA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_CONSISTENCIA"]);
                    var._Cod_tipo_digestabilidad = lector["COD_DIGESTABILIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DIGESTABILIDAD"]);
                    var._Cod_tipo_aporte_nutrientes = lector["COD_APORTE_NUTRIENTES"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_APORTE_NUTRIENTES"]);
                    var._Cod_tipo_volumen = lector["COD_VOLUMEN"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_VOLUMEN"]);
                    var._Cod_tipo_temperatura = lector["COD_TEMPERATURA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TEMPERATURA"]);
                    var._Cod_tipo_sales = lector["COD_TIPO_SALES"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_SALES"]);
                   var._Diagnostico = lector["DIAGNOSTICO"].Equals(DBNull.Value) ? string.Empty : (string)lector["DIAGNOSTICO"];
                    var._Amnesis_alim = lector["AMNESIS"].Equals(DBNull.Value) ? string.Empty : (string)lector["AMNESIS"];
                    var._Observaciones = lector["OBSERVACIONES"].Equals(DBNull.Value) ? string.Empty : (string)lector["OBSERVACIONES"];
                }
                else
                {
                    var._Id = 0;
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



        public Pedidos Extraer_opc_comida(string cod_pedido)
        {
            try
            {
                Pedidos var = new Pedidos();
                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_EXTRAER_OPC_COMIDA");

                conn.ParametroBD("PIN_COD_PEDIDO", cod_pedido, DbType.Int64, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Pedidos> lista = new List<Pedidos>();

                if (lector.Read())
                {
                    var._Cod_opc_comida = lector["OPC_COMIDA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["OPC_COMIDA"]);
                }
                else
                {
                    var._Id = 0;
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

        public Pedidos Cargar_Observacion(string cod_paciente)
        {
            try
            {
                Pedidos var = new Pedidos();
                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_OBSERVACIONES");

                conn.ParametroBD("PIN_COD_paciente", cod_paciente, DbType.Int64, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Pedidos> lista = new List<Pedidos>();

                if (lector.Read())
                {

                     var._Observaciones = lector["OBSERVACIONES"].Equals(DBNull.Value) ? string.Empty : (string)lector["OBSERVACIONES"];
                }
                else
                {
                    var._Id = 0;
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

        public Pedidos Cargar_pedidos2(int cod_pedido)
        {
            try
            {
                Pedidos var = new Pedidos();
                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_PEDIDO_PACIENTE");

                conn.ParametroBD("PIN_COD_PEDIDO", cod_pedido, DbType.Int64, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Pedidos> lista = new List<Pedidos>();

                if (lector.Read())
                {

                    var._Cod_menu= lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Cod_paciente = lector["COD_PACIENTE"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Cod_cama = lector["COD_CAMA"].Equals(DBNull.Value) ? string.Empty : lector["CODIGO"].ToString() ;
                    var._Cod_tipo_consistencia = lector["COD_CONSISTENCIA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_CONSISTENCIA"]);
                    var._Cod_tipo_digestabilidad = lector["COD_DIGESTABILIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DIGESTABILIDAD"]);
                    var._Cod_lactosa = lector["COD_LACTOSA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_LACTOSA"]);
                    var._Cod_dulzor = lector["COD_DULZOR"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DULZOR"]);
                    var._Cod_regimen = lector["COD_COBRO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_COBRO"]);
                    var._Cod_tipo_sales = lector["COD_TIPO_SALES"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_SALES"]);                
                    var._Cod_aislamiento = lector["COD_AISLAMIENTO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_AISLAMIENTO"]);
                    var._Cod_opc_comida= lector["COD_OPC_COMIDA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_OPC_COMIDA"]);
                    var._Comentario_tipo_comida = lector["COMENTARIO"].Equals(DBNull.Value) ? string.Empty : lector["COMENTARIO"].ToString();
                    var._Id_opc_comida = lector["ID_OPC_COMIDA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_OPC_COMIDA"]);
                    var._Cod_d= lector["COD_D"].Equals(DBNull.Value) ? string.Empty  : lector["COD_D"].ToString();
                    var._Cod_c1 = lector["COD_C1"].Equals(DBNull.Value) ? string.Empty : lector["COD_C1"].ToString();
                    var._Cod_a = lector["COD_A"].Equals(DBNull.Value) ? string.Empty : lector["COD_A"].ToString();
                    var._Cod_o = lector["COD_O"].Equals(DBNull.Value) ? string.Empty : lector["COD_O"].ToString();
                    var._Cod_c = lector["COD_C"].Equals(DBNull.Value) ? string.Empty : lector["COD_C"].ToString();
                    var._Cod_c2 = lector["COD_C2"].Equals(DBNull.Value) ? string.Empty : lector["COD_C2"].ToString();
                    var._Cod_ce = lector["COD_CE"].Equals(DBNull.Value) ? string.Empty : lector["COD_CE"].ToString();
                    var._Cod_hco = lector["COD_HCO"].Equals(DBNull.Value) ? string.Empty : lector["COD_HCO"].ToString();
           
                }
                else
                {
                    var._Cod_menu = 0;
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

        public List<Pedidos> Cargar_alimentos_pedidos(string fecha, int cod_tipo_comida, int cod_tipo_distribucion,string cod_pedido)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_ALIM_PEDIDO");
                conn.ParametroBD("PIN_COD_COMIDA", cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_PEDIDOS", cod_pedido, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);
                //conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Pedidos> lista = new List<Pedidos>();

                while (lector.Read())
                {
                    Pedidos var = new Pedidos();

                    var._Id_tipo_alimento = lector["ID_ALIM"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_ALIM"]);
                    var._Cod_tipo_alimento = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                   var._Nom_tipo_alimento = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();
                    var._Cantidad = lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);
                    var._Vigencia = lector["VIGENCIA"].Equals(DBNull.Value) ? string.Empty : lector["VIGENCIA"].ToString();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO"].ToString();
                    var._Id_tipo_distribucion = lector["ID_DISTRIBUCION"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_DISTRIBUCION"]);

                    var._Cod_tipo_distribucion = lector["DISTRIBUCION"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["DISTRIBUCION"]);
                    var._Cod_tipo_comida = lector["TIPO_COMIDA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["TIPO_COMIDA"]);
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

        public int Validar_alimento_pedido(string fecha, int cod_tipo_comida, int cod_tipo_distribucion,string cod_pedido)
        {
            try
            {
                int cont = 0;
                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_ALIM_PEDIDO");
                conn.ParametroBD("PIN_COD_COMIDA", cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_PEDIDOS", cod_pedido, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);
                //conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();


                while (lector.Read())
                {
                    cont++;
                }
               
                conn.Cerrar();

                return cont;
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public string Registrar_Pedido(Pedidos var,string fecha)
        {
            try
            {


                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_PEDIDO");

                conn.ParametroBD("PIN_CONSISTENCIA", var._Cod_tipo_consistencia, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_DIGESTABILIDAD", var._Cod_tipo_digestabilidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_REGIMEN", var._Cod_regimen, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_TIPO_SALES", var._Cod_tipo_sales, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_LACTOSA", var._Cod_lactosa, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DULZOR", var._Cod_dulzor, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_CAMA", var._Cod_cama, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_PACIENTE", var._Cod_paciente, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_OBSERVACION", var._Observaciones.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_USUARIO", var._User_crea.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_AYUNO", var._Cod_opc_comida, DbType.Int64, ParameterDirection.Input);

                conn.ParametroBD("PIN_COD_AISLAMIENTO", var._Cod_aislamiento, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_ESTADO", var._Cod_estado, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);
 
                conn.ParametroBD("POUT_PED_ID", 0, DbType.Int64, ParameterDirection.Output);

                int registro = conn.ExecuteNonQuery();

                conn.Cerrar();

                return conn.ParamValue("POUT_PED_ID").ToString();
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public string Registrar_Pedido(Pedidos var)
        {
            try
            {

                string fecha = DateTime.Now.ToString("dd-MM-yyyy");

                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_PEDIDO");

                conn.ParametroBD("PIN_CONSISTENCIA", var._Cod_tipo_consistencia, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_DIGESTABILIDAD", var._Cod_tipo_digestabilidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_REGIMEN", var._Cod_regimen, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_TIPO_SALES", var._Cod_tipo_sales, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_LACTOSA", var._Cod_lactosa, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DULZOR", var._Cod_dulzor, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_CAMA", var._Cod_cama, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_PACIENTE", var._Cod_paciente, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_OBSERVACION", var._Observaciones.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_USUARIO", var._User_crea.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_AYUNO", var._Cod_opc_comida, DbType.Int64, ParameterDirection.Input);

                conn.ParametroBD("PIN_COD_AISLAMIENTO", var._Cod_aislamiento, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_ESTADO", var._Cod_estado, DbType.Int64, ParameterDirection.Input);


                conn.ParametroBD("POUT_PED_ID", 0, DbType.Int64, ParameterDirection.Output);

                int registro = conn.ExecuteNonQuery();

                conn.Cerrar();

                return conn.ParamValue("POUT_PED_ID").ToString();
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public string Registrar_opc_comida(Pedidos var, string val_d, string val_c1, string val_a, string val_o, string val_c, string val_c2, string val_ce, string val_hco)
        {
            try
            {

                string fecha = DateTime.Now.ToString("dd-MM-yyyy");

                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_OPC_COMIDA");

                conn.ParametroBD("PIN_COD_PEDIDO", var._Cod_pedido, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_CONSISTENCIA", var._Cod_tipo_consistencia, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_DIGESTABILIDAD", var._Cod_tipo_digestabilidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_REGIMEN", var._Cod_regimen, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_TIPO_SALES", var._Cod_tipo_sales, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_LACTOSA", var._Cod_lactosa, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DULZOR", var._Cod_dulzor, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_OBSERVACION", var._Observaciones.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_USUARIO", var._User_crea.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_AYUNO", var._Cod_opc_comida, DbType.Int64, ParameterDirection.Input);

                conn.ParametroBD("PIN_COD_AISLAMIENTO", var._Cod_aislamiento, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_D", val_d.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_C1", val_c1.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_A", val_a.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_O", val_o.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_C", val_c.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_C2", val_c2.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_CE", val_ce.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_HCO", val_hco.ToUpper(), DbType.String, ParameterDirection.Input);
              



                conn.ParametroBD("POUT_PED_ID", 0, DbType.Int64, ParameterDirection.Output);

                int registro = conn.ExecuteNonQuery();

                conn.Cerrar();

                return conn.ParamValue("POUT_PED_ID").ToString();
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public string Modificar_opc_comida(Pedidos var, string val_d, string val_c1, string val_a, string val_o, string val_c, string val_c2, string val_ce, string val_hco)
        {
            try
            {

                string fecha = DateTime.Now.ToString("dd-MM-yyyy");

                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001M.P_MODIFICAR_OPC_COMIDA");

                conn.ParametroBD("PIN_ID_OPC", var._Id_opc_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_PEDIDO", var._Cod_pedido, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_CONSISTENCIA", var._Cod_tipo_consistencia, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_DIGESTABILIDAD", var._Cod_tipo_digestabilidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_REGIMEN", var._Cod_regimen, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_TIPO_SALES", var._Cod_tipo_sales, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_LACTOSA", var._Cod_lactosa, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DULZOR", var._Cod_dulzor, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_OBSERVACION", var._Observaciones.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_USUARIO", var._User_crea.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_AYUNO", var._Cod_opc_comida, DbType.Int64, ParameterDirection.Input);

                conn.ParametroBD("PIN_COD_AISLAMIENTO", var._Cod_aislamiento, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_D", val_d.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_C1", val_c1.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_A", val_a.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_O", val_o.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_C", val_c.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_C2", val_c2.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_CE", val_ce.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_HCO", val_hco.ToUpper(), DbType.String, ParameterDirection.Input);

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

        public string Registrar_Pedido(int cod_pedido,int cod_op_alimento,string user)
        {
            try
            {

                string fecha = DateTime.Now.ToString("dd-MM-yyyy");

                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_PEDIDO");

                conn.ParametroBD("PIN_COD_PEDIDO", cod_pedido, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_OP_ALIMENTO", cod_op_alimento, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_USUARIO", user, DbType.String, ParameterDirection.Input);
           

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

        public string Modificar_Pedido(Pedidos var)
        {
            try
            {

                string fecha = DateTime.Now.ToString("dd-MM-yyyy");

                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_MODIFICAR_PEDIDO");

                conn.ParametroBD("PIN_COD_PEDIDO", var._Cod_pedido, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_CONSISTENCIA", var._Cod_tipo_consistencia, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_DIGESTABILIDAD", var._Cod_tipo_digestabilidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_REGIMEN", var._Cod_regimen, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_TIPO_SALES", var._Cod_tipo_sales, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_LACTOSA", var._Cod_lactosa, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DULZOR", var._Cod_dulzor, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_CAMA", var._Cod_cama, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_PACIENTE", var._Cod_paciente, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_OBSERVACION", var._Observaciones.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_USUARIO", var._User_crea.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_AYUNO", var._Cod_opc_comida, DbType.Int64, ParameterDirection.Input);
 
                conn.ParametroBD("PIN_COD_AISLAMIENTO", var._Cod_aislamiento, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_ESTADO", var._Cod_estado, DbType.Int64, ParameterDirection.Input);

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

        public string Eliminar_Pedido(Pedidos var)
        {
            try
            {

                string fecha = DateTime.Now.ToString("dd-MM-yyyy");

                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_ELIMINAR_PEDIDO");

         
                conn.ParametroBD("PIN_COD_PEDIDO", var._Cod_pedido, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_ID_TIPO_COMIDA", var._Id_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_COMIDA", var._Cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_PACIENTE", var._Cod_paciente, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_USUARIO", var._User_crea.ToUpper(), DbType.String, ParameterDirection.Input);   

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

        public string Eliminar_Alimentos_Pedido(Pedidos var)
        {
            try
            {

                string fecha = DateTime.Now.ToString("dd-MM-yyyy");

                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_ELIMINAR_PEDIDO");


                conn.ParametroBD("PIN_COD_PEDIDO", var._Cod_pedido, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_ID_TIPO_COMIDA", var._Id_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_COMIDA", var._Cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_PACIENTE", var._Cod_paciente, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_USUARIO", var._User_crea.ToUpper(), DbType.String, ParameterDirection.Input);

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

        public string Eliminar_Pedido2(Pedidos var)
        {
            try
            {

                string fecha = DateTime.Now.ToString("dd-MM-yyyy");

                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_ELIMINAR_PEDIDO2");


                conn.ParametroBD("PIN_COD_COMIDA", var._Id_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DISTRIBUCION", var._Id_tipo_distribucion, DbType.Int64, ParameterDirection.Input);

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

        public string Eliminar_Pedido3(Pedidos var)
        {
            try
            {

                string fecha = DateTime.Now.ToString("dd-MM-yyyy");

                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_ELIMINAR_PEDIDO3");


                conn.ParametroBD("PIN_COD_COMIDA", var._Id_tipo_comida, DbType.Int64, ParameterDirection.Input);
       
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

        public string Registrar_Pedido_nue(Pedidos var)
        {
            try
            {

                string fecha = DateTime.Now.ToString("dd-MM-yyyy");

                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_PEDIDO_NUE");


                conn.ParametroBD("PIN_COD_CAMA", var._Cod_cama, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_PACIENTE", var._Cod_paciente, DbType.Int64, ParameterDirection.Input);         
                conn.ParametroBD("PIN_USUARIO", var._User_crea.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("POUT_PED_ID", 0, DbType.Int64, ParameterDirection.Output);

                int registro = conn.ExecuteNonQuery();

                conn.Cerrar();

                return conn.ParamValue("POUT_PED_ID").ToString();
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }

        public string Registrar_alimentos_extra(Pedidos var, string tipo, int cod_consistencia, int cod_digestabilidad, int cod_lactosa, int cod_dulzor, int cod_volumen, int cod_temperatura, int cod_sal, string comentario)
        {
            try
            {

                string fecha = DateTime.Now.ToString("dd-MM-yyyy");

                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_ALIMENTOS_EXTRAS");


                conn.ParametroBD("PIN_COD_TIPO_COMIDA", var._Cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_DISTRIBUCION", var._Cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_ID_DISTRIBUCION", var._Id_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_ALIMENTO", var._Cod_tipo_alimento, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_NOM_TIPO_ALIMENTO", var._Nom_tipo_alimento.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_TIPO", tipo.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_USUARIO", var._User_crea.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_CONSISTENCIA", cod_consistencia, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_DIGESTABILIDAD", cod_digestabilidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_CONSISTENCIA", cod_dulzor, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_CONSISTENCIA", cod_lactosa, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_CONSISTENCIA", cod_sal, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_CONSISTENCIA", cod_temperatura, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_CONSISTENCIA", cod_volumen, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_OBSERVACION", comentario.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_PEDIDO", var._Cod_pedido, DbType.Int64, ParameterDirection.Input);
          

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

        public string Registrar_alimentos_especiales(Pedidos var, string tipo)
        {
            try
            {

                string fecha = DateTime.Now.ToString("dd-MM-yyyy");

                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_ALIMENTOS_ESPECIAL");


                conn.ParametroBD("PIN_COD_TIPO_COMIDA", var._Cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_DISTRIBUCION", var._Cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_ID_DISTRIBUCION", var._Id_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_ALIMENTO", var._Cod_tipo_alimento, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_NOM_TIPO_ALIMENTO", var._Nom_tipo_alimento.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_TIPO", tipo.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_USUARIO", var._User_crea.ToUpper(), DbType.String, ParameterDirection.Input);


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

        public string Registrar_Observaciones(Pedidos var)
        {
            try
            {

                string fecha = DateTime.Now.ToString("dd-MM-yyyy");

                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_OBSERVACIONES");


                conn.ParametroBD("PIN_COD_PACIENTE", var._Cod_paciente, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_DESCRIPCION", var._Observaciones.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_USUARIO", var._User_crea.ToUpper(), DbType.String, ParameterDirection.Input);

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

        public string Modificar_Observaciones(Pedidos var)
        {
            try
            {

                string fecha = DateTime.Now.ToString("dd-MM-yyyy");

                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_MODIFICAR_OBSERVACIONES");


                conn.ParametroBD("PIN_COD_PACIENTE", var._Cod_paciente, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_DESCRIPCION", var._Observaciones.ToUpper(), DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_USUARIO", var._User_crea.ToUpper(), DbType.String, ParameterDirection.Input);

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

        public string Registrar_Nutrientes(Pedidos var)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_NUTRIENTES");

                conn.ParametroBD("PIN_COD_PEDIDO", var._Id, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_NUTRIENTES", var._Nom_tipo_nutrientes, DbType.Int64, ParameterDirection.Input);


                int registro = conn.ExecuteNonQuery();

                conn.Cerrar();

                if (registro > 0)
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

        public string Modificar_Nutrientes(Pedidos var)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001M.P_MODIFICAR_NUTRIENTES");

                conn.ParametroBD("PIN_COD_PEDIDO", var._Id, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_NUTRIENTES", var._Cod_tipo_nutrientes, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_VIGENTE", var._Est_tipo_nutrientes, DbType.String, ParameterDirection.Input);

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

        public string Eliminar_Nutrientes(int cod_pedido)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001M.P_ELIMINAR_NUTRIENTES");

                conn.ParametroBD("PIN_COD_PEDIDO", cod_pedido, DbType.Int64, ParameterDirection.Input);
            
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

        public string Cambiar_estado(string cod_pedido, int valor)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CAMBIAR_ESTADO_PEDIDO");

                conn.ParametroBD("PIN_COD_PEDIDO", cod_pedido, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_VALOR", valor, DbType.Int64, ParameterDirection.Input);

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

        public string Cambiar_menu()
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CAMBIAR_MENU");
                conn.ParametroBD("PIN_COD_PEDIDO", "", DbType.String, ParameterDirection.Input);

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

        public string Cambiar_estado_pedido(string fecha)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CERRAR_PEDIDO");
                conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);

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
