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
   public  class Menu_tipo_alimentosDA
    {
        string res = "";
        string BD = ConfigurationManager.AppSettings["BD"];
        string User = ConfigurationManager.AppSettings["Usuario"];
        string Pass = ConfigurationManager.AppSettings["Pass"];
        ConectarFalp conn;

        public string Registrar_Tipo_Alimento(Menu_tipo_alimento var,string cod_cama)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_PEDIDO_A");

                conn.ParametroBD("PIN_COD_MENU", var._Cod_pedido_reg_det, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_ALIMENTOS", var._Cod_tipo_alimentos, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_CANTIDAD", var._Cantidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_VIGENCIA", var._Vigencia, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_ESTADO", var._Estado, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_USER", var._User_crea, DbType.String, ParameterDirection.Input);


                conn.ParametroBD("POUT_PEDIDO_ALIMENTO", 0, DbType.Int64, ParameterDirection.Output);

                int registro = conn.ExecuteNonQuery();

                conn.Cerrar();

                return conn.ParamValue("POUT_PEDIDO_ALIMENTO").ToString();
            }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }
        }


        public string Registrar_Tipo_Alimento(Menu_tipo_alimento var,int cod_comparacion,int cod_consistencia,int cod_digestabilidad,int cod_lactosa,int cod_dulzor, int cod_volumen, int cod_temperatura,int cod_sal,string comentario,string cod_pedido)
        {
          /*  try
            {*/
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

              /*  conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001M.P_REGISTRAR_TIPO_ALIMENTO");

                conn.ParametroBD("PIN_COD_DISTRIBUCION", var._Cod_pedido_reg_det, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_ALIMENTOS", var._Cod_tipo_alimentos, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_CANTIDAD", var._Cantidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_VIGENCIA", var._Vigencia, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_ESTADO", var._Estado, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_USER", var._User_crea, DbType.String, ParameterDirection.Input);*/
                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_PEDIDO_A");

                conn.ParametroBD("PIN_COD_MENU", var._Cod_pedido_reg_det, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_COMPARACION", cod_comparacion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_ALIMENTOS", var._Cod_tipo_alimentos, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_NOM_TIPO_ALIMENTO", var._Nom_tipo_alimentos, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_DISTRIBUCION", var._Cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_CANTIDAD", var._Cantidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_VIGENCIA", var._Vigencia, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_ESTADO", var._Estado, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_USER", var._User_crea, DbType.String, ParameterDirection.Input);

                conn.ParametroBD("PIN_COD_CONSISTENCIA", cod_consistencia, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DIGESTABILIDAD", cod_digestabilidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_LACTOSA", cod_lactosa, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DULZOR", cod_dulzor, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_VOLUMEN", cod_volumen, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TEMPERATURA", cod_temperatura, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_SAL",cod_sal, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COMENTARIO", comentario, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_PEDIDO", cod_pedido, DbType.String, ParameterDirection.Input);
             

                int registro = conn.ExecuteNonQuery();
                if (registro > -2)
                {
                    res = "ok";
                }
                else
                {

                    res = "error";
                }

                conn.Cerrar();

                return res;
          /*  }
            catch (Exception ex)
            {
                conn.Cerrar();
                throw ex;
            }*/
        }

        public string Modificar_Tipo_Alimento(Menu_tipo_alimento var, int cod_consistencia, int cod_digestabilidad, int cod_lactosa, int cod_dulzor, int cod_volumen, int cod_temperatura, int cod_sal, string comentario)
        {
            try
            {
                conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001M.P_MODIFICAR_TIPO_ALIMENTO");

                conn.ParametroBD("PIN_COD_DISTRIBUCION", var._Cod_pedido_reg_det, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_ALIMENTOS", var._Cod_tipo_alimentos, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_DISTRIBUCION", var._Cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_CANTIDAD", var._Cantidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_VIGENCIA", var._Vigencia, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_ESTADO", var._Estado, DbType.String, ParameterDirection.Input);
                conn.ParametroBD("PIN_USER", var._User_crea, DbType.String, ParameterDirection.Input);


                conn.ParametroBD("PIN_COD_CONSISTENCIA", cod_consistencia, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DIGESTABILIDAD", cod_digestabilidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_LACTOSA", cod_lactosa, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DULZOR", cod_dulzor, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_VOLUMEN", cod_volumen, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TEMPERATURA", cod_temperatura, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_SAL", cod_sal, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COMENTARIO", comentario, DbType.String, ParameterDirection.Input);
           




                int registro = conn.ExecuteNonQuery();
                if (registro > -2)
                {
                    res = "ok";
                }
                else
                {

                    res = "error";
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

        public List<Menu_tipo_alimento> Listado_ingesta(string cod_pedido, string cod_tipo_comida)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_INGESTA_PAC");
                conn.ParametroBD("PIN_COD_PEDIDO", cod_pedido, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_COMIDA", cod_tipo_comida, DbType.Int64, ParameterDirection.Input);


                IDataReader lector = conn.ExecuteReader();

                List<Menu_tipo_alimento> lista = new List<Menu_tipo_alimento>();

                while (lector.Read())
                {
                    Menu_tipo_alimento var = new Menu_tipo_alimento();

                    var._Cod_pedido = lector["COD_PEDIDO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_PEDIDO"]);

                    var._Cod_tipo_alimentos = lector["COD_TIPO_ALIMENTO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_ALIMENTO"]);
                    var._Nom_tipo_alimentos = lector["NOM_TIPO_ALIMENTO"].Equals(DBNull.Value) ? string.Empty : lector["NOM_TIPO_ALIMENTO"].ToString();
                    var._Cod_tipo_comida = lector["COD_TIPO_COMIDA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_COMIDA"]);
                    var._Cod_tipo_distribucion = lector["COD_TIPO_DISTRIBUCION"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_DISTRIBUCION"]);

                    var._Calorias= lector["CALORIAS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["CALORIAS"]);
                    var._Proteinas = lector["PROTEINAS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["PROTEINAS"]);
                    var._Lipidos = lector["LIPIDOS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["LIPIDOS"]);
                    var._Hyc = lector["HYC"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["HYC"]);
                    var._Sodio = lector["SODIO"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["SODIO"]);

                    var._Ing_id = lector["COD_INGESTA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_INGESTA"]);
                    var._Ing_calorias = lector["ING_CALORIAS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["ING_CALORIAS"]);
                    var._Ing_proteinas = lector["ING_PROTEINAS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["ING_PROTEINAS"]);
                    var._Ing_lipidos = lector["ING_LIPIDOS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["ING_LIPIDOS"]);
                    var._Ing_hyc = lector["ING_HYC"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["ING_HYC"]);
                    var._Ing_sodio = lector["ING_SODIO"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["ING_SODIO"]);

                    var._Gr_i = lector["GR_I"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["GR_I"]);
                    var._Ing_gr_c = lector["ING_GR_C"].Equals(DBNull.Value) ? string.Empty : lector["ING_GR_C"].ToString();
                    var._Cc_i = lector["CC_I"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["CC_I"]);
                    var._Ing_cc_c = lector["ING_CC_C"].Equals(DBNull.Value) ? string.Empty : lector["ING_CC_C"].ToString();
                    var._Ing_cc_total = lector["ING_CC_TOTAL"].Equals(DBNull.Value) ? string.Empty : lector["ING_CC_TOTAL"].ToString();
                    var._Ajuste_calorias = lector["AJUSTE_CALORIAS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["AJUSTE_CALORIAS"]);
                    var._Ajuste_proteinas = lector["AJUSTE_PROTEINAS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["AJUSTE_PROTEINAS"]);
                    var._Ajuste_lipidos = lector["AJUSTE_LIPIDOS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["AJUSTE_LIPIDOS"]);
                    var._Ajuste_hyc = lector["AJUSTE_HYC"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["AJUSTE_HYC"]);
                    var._Ajuste_sodio = lector["AJUSTE_SODIO"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["AJUSTE_SODIO"]);
                    var._Ajuste_cc_total = lector["AJUSTE_CC_TOTAL"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["AJUSTE_CC_TOTAL"]);

                    var._Sub_calorias = lector["SUB_CALORIAS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["SUB_CALORIAS"]);
                    var._Sub_proteinas = lector["SUB_PROTEINAS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["SUB_PROTEINAS"]);
                    var._Sub_lipidos = lector["SUB_LIPIDOS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["SUB_LIPIDOS"]);
                    var._Sub_hyc = lector["SUB_HYC"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["SUB_HYC"]);
                    var._Sub_sodio = lector["SUB_SODIO"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["SUB_SODIO"]);
                    var._Sub_cc_total = lector["SUB_CC_TOTAL"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["SUB_CC_TOTAL"]);
                    var._Porcentaje = lector["PORCENTAJE"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["PORCENTAJE"]);
                    var._Mixto = lector["MIXTO"].Equals(DBNull.Value) ? string.Empty : lector["MIXTO"].ToString();
                    var._Cantidad = lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);

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


        public List<Menu_tipo_alimento> Listado_ingesta_2(string cod_pedido, string cod_tipo_comida)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_INGESTA_PAC_2");
                conn.ParametroBD("PIN_COD_PEDIDO", cod_pedido, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_TIPO_COMIDA", cod_tipo_comida, DbType.Int64, ParameterDirection.Input);


                IDataReader lector = conn.ExecuteReader();

                List<Menu_tipo_alimento> lista = new List<Menu_tipo_alimento>();

                while (lector.Read())
                {
                    Menu_tipo_alimento var = new Menu_tipo_alimento();

                    var._Cod_pedido = lector["COD_PEDIDO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_PEDIDO"]);

                    var._Cod_tipo_alimentos = lector["COD_TIPO_ALIMENTO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_ALIMENTO"]);
                    var._Nom_tipo_alimentos = lector["NOM_TIPO_ALIMENTO"].Equals(DBNull.Value) ? string.Empty : lector["NOM_TIPO_ALIMENTO"].ToString();
                    var._Cod_tipo_comida = lector["COD_TIPO_COMIDA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_COMIDA"]);

                    var._Calorias = lector["CALORIAS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["CALORIAS"]);
                    var._Proteinas = lector["PROTEINAS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["PROTEINAS"]);
                    var._Lipidos = lector["LIPIDOS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["LIPIDOS"]);
                    var._Hyc = lector["HYC"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["HYC"]);
                    var._Sodio = lector["SODIO"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["SODIO"]);

                    var._Ing_id = lector["COD_INGESTA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_INGESTA"]);
                    var._Ing_calorias = lector["ING_CALORIAS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["ING_CALORIAS"]);
                    var._Ing_proteinas = lector["ING_PROTEINAS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["ING_PROTEINAS"]);
                    var._Ing_lipidos = lector["ING_LIPIDOS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["ING_LIPIDOS"]);
                    var._Ing_hyc = lector["ING_HYC"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["ING_HYC"]);
                    var._Ing_sodio = lector["ING_SODIO"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["ING_SODIO"]);

                    var._Gr_i = lector["GR_I"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["GR_I"]);
                    var._Ing_gr_c = lector["ING_GR_C"].Equals(DBNull.Value) ? string.Empty : lector["ING_GR_C"].ToString();
                    var._Cc_i = lector["CC_I"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CC_I"]);
                    var._Ing_cc_c = lector["ING_CC_C"].Equals(DBNull.Value) ? string.Empty : lector["ING_CC_C"].ToString();
                    var._Ing_cc_total = lector["ING_CC_TOTAL"].Equals(DBNull.Value) ? string.Empty : lector["ING_CC_TOTAL"].ToString();
                    var._Ajuste_calorias = lector["AJUSTE_CALORIAS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["AJUSTE_CALORIAS"]);
                    var._Ajuste_proteinas = lector["AJUSTE_PROTEINAS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["AJUSTE_PROTEINAS"]);
                    var._Ajuste_lipidos = lector["AJUSTE_LIPIDOS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["AJUSTE_LIPIDOS"]);
                    var._Ajuste_hyc = lector["AJUSTE_HYC"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["AJUSTE_HYC"]);
                    var._Ajuste_sodio = lector["AJUSTE_SODIO"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["AJUSTE_SODIO"]);
                    var._Ajuste_cc_total = lector["AJUSTE_CC_TOTAL"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["AJUSTE_CC_TOTAL"]);

                    var._Sub_calorias = lector["SUB_CALORIAS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["SUB_CALORIAS"]);
                    var._Sub_proteinas = lector["SUB_PROTEINAS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["SUB_PROTEINAS"]);
                    var._Sub_lipidos = lector["SUB_LIPIDOS"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["SUB_LIPIDOS"]);
                    var._Sub_hyc = lector["SUB_HYC"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["SUB_HYC"]);
                    var._Sub_sodio = lector["SUB_SODIO"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["SUB_SODIO"]);
                    var._Sub_cc_total = lector["SUB_CC_TOTAL"].Equals(DBNull.Value) ? 0 : Convert.ToDouble(lector["SUB_CC_TOTAL"]);
                    var._Porcentaje = lector["PORCENTAJE"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["PORCENTAJE"]);
                    var._Mixto = lector["MIXTO"].Equals(DBNull.Value) ? string.Empty : lector["MIXTO"].ToString();
                    var._Cantidad = lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);
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


        public List<Menu_tipo_alimento> Validar_ingesta(string cod_pedido)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_VALIDA_INGESTA_PAC");
                conn.ParametroBD("PIN_COD_PEDIDO", cod_pedido, DbType.Int64, ParameterDirection.Input);
       
                IDataReader lector = conn.ExecuteReader();

                List<Menu_tipo_alimento> lista = new List<Menu_tipo_alimento>();

                while (lector.Read())
                {
                    Menu_tipo_alimento var = new Menu_tipo_alimento();


                    var._Cod_tipo_alimentos = lector["COD_TIPO_ALIMENTO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_ALIMENTO"]);
                    var._Cod_tipo_comida = lector["COD_TIPO_COMIDA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_COMIDA"]);

                    var._Ing_id = lector["COD_INGESTA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_INGESTA"]);
                 
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


        public string Registrar_Ingesta(Menu_tipo_alimento var)
        {
            /*  try
              {*/
            conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

            if (conn.Estado == ConnectionState.Closed) conn.Abrir();



            conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_REGISTRAR_INGESTA");

            conn.ParametroBD("PIN_COD_PEDIDO", var._Cod_pedido, DbType.Int64, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_TIPO_COMIDA", var._Cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_TIPO_ALIMENTOS", var._Cod_tipo_alimentos, DbType.Int64, ParameterDirection.Input);
            conn.ParametroBD("PIN_GR_C", var._Gr_i, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_CC_C", var._Cc_i, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_CALORIAS", var._Calorias, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_PROTEINAS", var._Proteinas, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_LIPIDOS", var._Lipidos, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_HYC", var._Hyc, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_SODIO", var._Sodio, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_USUARIO", var._User_crea, DbType.String, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_CC_CCTOTAL", var._Ing_cc_total, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_PORCENTAJE", var._Porcentaje, DbType.Int64, ParameterDirection.Input);
            conn.ParametroBD("PIN_CANTIDAD", var._Cantidad, DbType.Int64, ParameterDirection.Input);
            int registro = conn.ExecuteNonQuery();
            if (registro > -2)
            {
                res = "ok";
            }
            else
            {

                res = "error";
            }

            conn.Cerrar();

            return res;
            /*  }
              catch (Exception ex)
              {
                  conn.Cerrar();
                  throw ex;
              }*/
        }

        public string Modificar_Ingesta(Menu_tipo_alimento var)
        {
            /*  try
              {*/
            conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

            if (conn.Estado == ConnectionState.Closed) conn.Abrir();

            conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001M.P_MODIFICAR_INGESTA");

            conn.ParametroBD("PIN_COD_INGESTA", var._Ing_id, DbType.Int64, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_PEDIDO", var._Cod_pedido, DbType.Int64, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_TIPO_COMIDA", var._Cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_TIPO_ALIMENTOS", var._Cod_tipo_alimentos, DbType.Int64, ParameterDirection.Input);
            conn.ParametroBD("PIN_GR_C", var._Gr_i, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_CC_C", var._Cc_i, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_CALORIAS", var._Calorias, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_PROTEINAS", var._Proteinas, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_LIPIDOS", var._Lipidos, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_HYC", var._Hyc, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_SODIO", var._Sodio, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_USUARIO", var._User_crea, DbType.String, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_CC_CCTOTAL", var._Ing_cc_total, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_PORCENTAJE", var._Porcentaje, DbType.Int64, ParameterDirection.Input);
            conn.ParametroBD("PIN_CANTIDAD", var._Cantidad, DbType.Int64, ParameterDirection.Input);
            int registro = conn.ExecuteNonQuery();
            if (registro > -2)
            {
                res = "ok";
            }
            else
            {

                res = "error";
            }

            conn.Cerrar();

            return res;
            /*  }
              catch (Exception ex)
              {
                  conn.Cerrar();
                  throw ex;
              }*/
        }



        public string Modificar_totales(Menu_tipo_alimento var, double cod_sgc)
        {
            /*  try
              {*/
            conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

            if (conn.Estado == ConnectionState.Closed) conn.Abrir();

            conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001M.P_MODIFICAR_TOTALES");

            conn.ParametroBD("PIN_COD_INGESTA", var._Ing_id, DbType.Int64, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_PEDIDO", var._Cod_pedido, DbType.Int64, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_TIPO_COMIDA", var._Cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_SUB_CALORIAS", var._Sub_calorias, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_SUB_PROTEINAS", var._Sub_proteinas, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_SUB_LIPIDOS", var._Sub_lipidos, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_SUB_SODIO", var._Sub_sodio, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_SUB_HYC", var._Sub_hyc, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_SUB_CCTOTAL", var._Sub_cc_total, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_AJ_CALORIAS", var._Ajuste_calorias, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_AJ_PROTEINAS", var._Ajuste_proteinas, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_AJ_LIPIDOS", var._Ajuste_lipidos, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_AJ_HYC", var._Ajuste_hyc, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_AJ_SODIO", var._Ajuste_sodio, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_AJ_CCTOTAL", var._Ajuste_cc_total, DbType.Double, ParameterDirection.Input);
            conn.ParametroBD("PIN_USUARIO", var._User_crea, DbType.String, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_SUB_GRTOTAL", cod_sgc, DbType.Double, ParameterDirection.Input);

            int registro = conn.ExecuteNonQuery();
            if (registro > -2)
            {
                res = "ok";
            }
            else
            {

                res = "error";
            }

            conn.Cerrar();

            return res;
            /*  }
              catch (Exception ex)
              {
                  conn.Cerrar();
                  throw ex;
              }*/
        }

        public string Restablecer(string  cod_pedido, string cod_tipo_comida)
        {
            /*  try
              {*/
            conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

            if (conn.Estado == ConnectionState.Closed) conn.Abrir();

            conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_ELIMINAR_INGESTA");

  
            conn.ParametroBD("PIN_COD_PEDIDO", cod_pedido, DbType.Int64, ParameterDirection.Input);
            conn.ParametroBD("PIN_COD_TIPO_COMIDA", cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
           
            int registro = conn.ExecuteNonQuery();
            if (registro > -2)
            {
                res = "ok";
            }
            else
            {

                res = "error";
            }

            conn.Cerrar();

            return res;
            /*  }
              catch (Exception ex)
              {
                  conn.Cerrar();
                  throw ex;
              }*/
        }


        public  List<Menu_tipo_alimento> Obtener_resumen()
        {

            return new List<Menu_tipo_alimento> 
            { 
               new Menu_tipo_alimento { _Cod_tipo_comida=1, _Nom_tipo_distribucion="Desayuno (D)", _Ing_gr_c="0",_Calorias=0 , _Proteinas=0,_Lipidos=0,_Hyc=0, _Sodio=0,_Hc=0,_Ing_cc_total="0"},
               new Menu_tipo_alimento { _Cod_tipo_comida=2, _Nom_tipo_distribucion="Colacion Matinal (C1)", _Ing_gr_c="0",_Calorias=0 , _Proteinas=0,_Lipidos=0,_Hyc=0, _Sodio=0,_Hc=0,_Ing_cc_total="0"},
               new Menu_tipo_alimento { _Cod_tipo_comida=3, _Nom_tipo_distribucion="Amuerzo (A)",_Ing_gr_c="0", _Calorias=0 , _Proteinas=0,_Lipidos=0,_Hyc=0, _Sodio=0,_Hc=0,_Ing_cc_total="0"},

               new Menu_tipo_alimento { _Cod_tipo_comida=4, _Nom_tipo_distribucion="Once (O)",_Ing_gr_c="0", _Calorias=0 , _Proteinas=0,_Lipidos=0,_Hyc=0, _Sodio=0,_Hc=0,_Ing_cc_total="0"},
               new Menu_tipo_alimento { _Cod_tipo_comida=5, _Nom_tipo_distribucion="Cena (C)",_Ing_gr_c="0" ,_Calorias=0 , _Proteinas=0,_Lipidos=0,_Hyc=0, _Sodio=0,_Hc=0,_Ing_cc_total="0"},
               new Menu_tipo_alimento { _Cod_tipo_comida=6, _Nom_tipo_distribucion="Colacion Tarde (C2)",_Ing_gr_c="0", _Calorias=0 , _Proteinas=0,_Lipidos=0,_Hyc=0, _Sodio=0,_Hc=0,_Ing_cc_total="0"},
               new Menu_tipo_alimento { _Cod_tipo_comida=7, _Nom_tipo_distribucion="Colacion Extra (CE)",_Ing_gr_c="0" ,_Calorias=0 , _Proteinas=0,_Lipidos=0,_Hyc=0, _Sodio=0,_Hc=0,_Ing_cc_total="0"},
               new Menu_tipo_alimento { _Cod_tipo_comida=8, _Nom_tipo_distribucion="Hidricos (HCO)",_Ing_gr_c="0" ,_Calorias=0 , _Proteinas=0,_Lipidos=0,_Hyc=0, _Sodio=0,_Hc=0,_Ing_cc_total="0"},
               new Menu_tipo_alimento { _Cod_tipo_comida=9, _Nom_tipo_distribucion="TOTAL",_Ing_gr_c="0", _Calorias=0 , _Proteinas=0,_Lipidos=0,_Hyc=0, _Sodio=0,_Hc=0,_Ing_cc_total="0"},


            };
        }
    }
}
