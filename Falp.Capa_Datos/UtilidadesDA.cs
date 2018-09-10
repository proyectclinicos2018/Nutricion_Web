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
    public class UtilidadesDA
    {

        string res = "";
        string BD = ConfigurationManager.AppSettings["BD"];
        string User = ConfigurationManager.AppSettings["Usuario"];
        string Pass = ConfigurationManager.AppSettings["Pass"];
        ConectarFalp conn;


        public List<Utilidades> Cargarturno()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_TURNOS");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_turno = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_turno = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargarservicio()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_SERVICIOS");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_servicio = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_servicio = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargarestado()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_ESTADO");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_estado = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_estado = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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


   

        public List<Utilidades> Cargar_tipo_bus()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_BUSQUEDA");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_bus = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_bus = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_doc()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_DOC");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_doc = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_doc = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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


        public List<Utilidades> Cargar_tipo_consistencia()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_CONSISTENCIA");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_consistencia = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_consistencia = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_digestabilidad()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_DIGESTABILIDAD");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_digestabilidad = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_digestabilidad = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_aporte_nutrientes()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_APORTE_NUTRI");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_aporte_nutrientes = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_aporte_nutrientes = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_volumen()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_VOLUMEN");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_volumen = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_volumen = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_temperatura()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_TEMPERATURA");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_temperatura = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_temperatura = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_sales()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_SALES");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_sales = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_sales = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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



        public List<Utilidades> Cargar_tipo_dulzor()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_DULZOR");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_dulzor = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_dulzor = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_lactosa()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_LACTOSA");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_lactosa = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_lactosa = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_nutrientes()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_NUTRIENTES");
               


                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_nutrientes = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_nutrientes = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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



    

   
        public List<Utilidades> Cargar_tipo_nutrientes_pedido(int cod_pedido)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_NUTRIENTES_PED");

                conn.ParametroBD("PIN_COD_PEDIDO", cod_pedido, DbType.Int64, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();
                    var._Id_tipo_nutrientes = lector["ID_NUT"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_NUT"]);
                    var._Cod_tipo_nutrientes = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_nutrientes = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();
                    var._Est_tipo_nutrientes = lector["VIGENTE"].Equals(DBNull.Value) ? string.Empty : lector["VIGENTE"].ToString();

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

        public List<Utilidades> Cargar_alimentos_pedido(int cod_pedido)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_COMIDAS_PEDIDO");

                conn.ParametroBD("PIN_COD_PEDIDO", cod_pedido, DbType.Int64, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();
                    var._Cod_menu = lector["COD_PEDIDO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_PEDIDO"]);
                    var._Id_tipo_comida = lector["ID_COMIDA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_COMIDA"]);
                    var._Cod_tipo_comida = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_comida = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO"].ToString();
                    var._Id_tipo_alimento = lector["ID_TIPO_ALIMENTO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_TIPO_ALIMENTO"]);
                    var._Cod_tipo_alimento = lector["COD_TIPO_ALIMENTO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_ALIMENTO"]);

                    var._Vale_impreso = lector["VALE_IMPRESO"].Equals(DBNull.Value) ? string.Empty : lector["VALE_IMPRESO"].ToString();
                    var._Ingesta = lector["INGESTA"].Equals(DBNull.Value) ? string.Empty : lector["INGESTA"].ToString();
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


        public List<Utilidades> Cargar_tipo_comida()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_COM");



                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_comida= lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_comida = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_distribucion(int cod_tipo_comida)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_DISTR");
                conn.ParametroBD("PIN_COD_COMIDA", cod_tipo_comida, DbType.Int64, ParameterDirection.Input);


                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_distribucion = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_distribucion = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargarregimen()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_REGIMEN");


                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_regimen = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_regimen = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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


        public List<Utilidades> Cargarbandeja()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_BANDEJA");


                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_bandeja = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_bandeja = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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
        public List<Utilidades> Cargaraislamiento()
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_AISLAMIENTO");


                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_aislamiento = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_aislamiento = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_tipo_alimento(int cod_tipo_distribucion)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_ALIM");
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);


                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_alimento = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_alimento = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();


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

        public List<Utilidades> Cargar_alimentos_menu(int cod_tipo_comida,int cod_tipo_distribucion,int cod_cobro,int cod_consistencia,int cod_digestabilidad,int cod_sal,int cod_lactosa,int cod_dulzor)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_ALIM_DIA");
                conn.ParametroBD("PIN_COD_COMIDA", cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_COBRO", cod_cobro, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_CONSISTENCIA", cod_consistencia, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DIGESTABILIDAD", cod_digestabilidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_SAL", cod_sal, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_LACTOSA", cod_lactosa, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DULZOR", cod_dulzor, DbType.Int64, ParameterDirection.Input);

                //conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Id_tipo_alimento = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Cod_tipo_alimento = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_alimento = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();
                    var._Cod_tipo_distribucion = lector["COD_DISTRIBUCION"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DISTRIBUCION"]);
                    var._Nom_tipo_distribucion = lector["NOM_DISTRIBUCION"].Equals(DBNull.Value) ? string.Empty : lector["NOM_DISTRIBUCION"].ToString();
                    
                    var._Cantidad = lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);
                    var._Vigencia = lector["VIGENCIA"].Equals(DBNull.Value) ? string.Empty : lector["VIGENCIA"].ToString();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO"].ToString();

                    var._Cod_tipo_consistencia = lector["COD_CONSISTENCIA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_CONSISTENCIA"]);
                    var._Cod_tipo_digestabilidad = lector["COD_DIGESTABILIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DIGESTABILIDAD"]);
                    var._Cod_lactosa = lector["COD_LACTOSA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_LACTOSA"]);
                    var._Cod_dulzor = lector["COD_DULZOR"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DULZOR"]);
                    var._Cod_tipo_sales = lector["COD_SAL"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_SAL"]);
                    var._Cod_tipo_temperatura = lector["COD_TEMPERATURA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TEMPERATURA"]);
                    var._Cod_tipo_volumen = lector["COD_VOLUMEN"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_VOLUMEN"]);
                    var._Observacion = lector["OBSERVACION"].Equals(DBNull.Value) ? string.Empty : lector["OBSERVACION"].ToString();
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


        public List<Utilidades> Cargar_Colacion_Ant(int cod_tipo_comida, int cod_tipo_distribucion, int cod_menu )
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_COLACION_ANT");
                conn.ParametroBD("PIN_COD_COMIDA", cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_PEDIDO", cod_menu, DbType.Int64, ParameterDirection.Input);
     

                //conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_alimento = lector["COD_ALIMENTO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_ALIMENTO"]);
                    var._Nom_tipo_alimento = lector["NOM_ALIMENTO"].Equals(DBNull.Value) ? string.Empty : lector["NOM_ALIMENTO"].ToString();
                    var._Cod_tipo_distribucion = lector["COD_DISTRIBUCION"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DISTRIBUCION"]);
                    var._Nom_tipo_distribucion = lector["NOM_DISTRIBUCION"].Equals(DBNull.Value) ? string.Empty : lector["NOM_DISTRIBUCION"].ToString();

                    var._Cantidad = lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);
                    var._Vigencia = lector["VIGENCIA"].Equals(DBNull.Value) ? string.Empty : lector["VIGENCIA"].ToString();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO"].ToString();

                    var._Cod_tipo_consistencia = lector["COD_CONSISTENCIA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_CONSISTENCIA"]);
                    var._Cod_tipo_digestabilidad = lector["COD_DIGESTABILIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DIGESTABILIDAD"]);
                    var._Cod_lactosa = lector["COD_LACTOSA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_LACTOSA"]);
                    var._Cod_dulzor = lector["COD_DULZOR"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DULZOR"]);
                    var._Cod_tipo_sales = lector["COD_SAL"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_SAL"]);
                    var._Cod_tipo_temperatura = lector["COD_TEMPERATURA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TEMPERATURA"]);
                    var._Cod_tipo_volumen = lector["COD_VOLUMEN"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_VOLUMEN"]);
                    var._Observacion = lector["OBSERVACION"].Equals(DBNull.Value) ? string.Empty : lector["OBSERVACION"].ToString();
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


        public List<Utilidades> Cargar_Colacion_mat_noct(int cod_tipo_comida, int cod_tipo_distribucion)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_COLACION_MAT_NOCT");
                conn.ParametroBD("PIN_COD_COMIDA", cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
  

                //conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_alimento = lector["COD_ALIMENTO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_ALIMENTO"]);
                    var._Nom_tipo_alimento = lector["NOM_ALIMENTO"].Equals(DBNull.Value) ? string.Empty : lector["NOM_ALIMENTO"].ToString();
                    var._Cod_tipo_distribucion = lector["COD_DISTRIBUCION"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DISTRIBUCION"]);
                    var._Nom_tipo_distribucion = lector["NOM_DISTRIBUCION"].Equals(DBNull.Value) ? string.Empty : lector["NOM_DISTRIBUCION"].ToString();

                    var._Cantidad = lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);
                    var._Vigencia = lector["VIGENCIA"].Equals(DBNull.Value) ? string.Empty : lector["VIGENCIA"].ToString();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO"].ToString();

                    var._Cod_tipo_consistencia = lector["COD_CONSISTENCIA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_CONSISTENCIA"]);
                    var._Cod_tipo_digestabilidad = lector["COD_DIGESTABILIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DIGESTABILIDAD"]);
                    var._Cod_lactosa = lector["COD_LACTOSA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_LACTOSA"]);
                    var._Cod_dulzor = lector["COD_DULZOR"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DULZOR"]);
                    var._Cod_tipo_sales = lector["COD_SAL"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_SAL"]);
                    var._Cod_tipo_temperatura = lector["COD_TEMPERATURA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TEMPERATURA"]);
                    var._Cod_tipo_volumen = lector["COD_VOLUMEN"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_VOLUMEN"]);
                    var._Observacion = lector["OBSERVACION"].Equals(DBNull.Value) ? string.Empty : lector["OBSERVACION"].ToString();
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

        public List<Utilidades> Cargar_alimentos_menu_colacion( int cod_tipo_distribucion, int cod_cobro, int cod_consistencia, int cod_digestabilidad, int cod_sal, int cod_lactosa, int cod_dulzor, string descripcion)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_ALIM_DIA_COLACION");
       
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_COBRO", cod_cobro, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_CONSISTENCIA", cod_consistencia, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DIGESTABILIDAD", cod_digestabilidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_SAL", cod_sal, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_LACTOSA", cod_lactosa, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DULZOR", cod_dulzor, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_DESCRIPCION", descripcion, DbType.String, ParameterDirection.Input);

                //conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Id_tipo_alimento = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Cod_tipo_alimento = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_alimento = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();
                    var._Cod_tipo_distribucion = lector["COD_DISTRIBUCION"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DISTRIBUCION"]);
                    var._Nom_tipo_distribucion = lector["NOM_DISTRIBUCION"].Equals(DBNull.Value) ? string.Empty : lector["NOM_DISTRIBUCION"].ToString();

                    var._Cantidad = lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);
                    var._Vigencia = lector["VIGENCIA"].Equals(DBNull.Value) ? string.Empty : lector["VIGENCIA"].ToString();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO"].ToString();

                    var._Cod_tipo_consistencia = lector["COD_CONSISTENCIA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_CONSISTENCIA"]);
                    var._Cod_tipo_digestabilidad = lector["COD_DIGESTABILIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DIGESTABILIDAD"]);
                    var._Cod_lactosa = lector["COD_LACTOSA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_LACTOSA"]);
                    var._Cod_dulzor = lector["COD_DULZOR"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DULZOR"]);
                    var._Cod_tipo_sales = lector["COD_SAL"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_SAL"]);
                    var._Cod_tipo_temperatura = lector["COD_TEMPERATURA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TEMPERATURA"]);
                    var._Cod_tipo_volumen = lector["COD_VOLUMEN"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_VOLUMEN"]);
                    var._Observacion = lector["OBSERVACION"].Equals(DBNull.Value) ? string.Empty : lector["OBSERVACION"].ToString();
                 /*   var._Cod_sales_pref = lector["SAL_PREF"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["SAL_PREF"]);
                    var._Cod_dulzor_pref = lector["DULZOR_PREF"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["DULZOR_PREF"]);
                    var._Cod_lactosa_pref = lector["LACTOSA_PREF"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["LACTOSA_PREF"]);

                    var._Cod_consistencia_pref = lector["CONSISTENCIA_PREF"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CONSISTENCIA_PREF"]);
                    var._Cod_digestabilidad_pref = lector["DIGESTABILIDAD_PREF"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["DIGESTABILIDAD_PREF"]);
                    var._No_sal = lector["NOSAL"].Equals(DBNull.Value) ? string.Empty : lector["NOSAL"].ToString();
                    var._No_dulzor = lector["NODULZOR"].Equals(DBNull.Value) ? string.Empty : lector["NODULZOR"].ToString();
                    var._No_lactosa = lector["NOLACTOSA"].Equals(DBNull.Value) ? string.Empty : lector["NOLACTOSA"].ToString();*/

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


        public List<Utilidades> Cargar_alimentos_menu_libre( int cod_tipo_distribucion,  string descripcion)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_ALIM_DIA_LIBRE");
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);

                conn.ParametroBD("PIN_DESCRIPCION", descripcion, DbType.String, ParameterDirection.Input);

                //conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Id_tipo_alimento = lector["ID_ALIM"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_ALIM"]);
                    var._Cod_tipo_alimento = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_alimento = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();
                    var._Cod_tipo_distribucion = lector["COD_DISTRIBUCION"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DISTRIBUCION"]);
                    var._Nom_tipo_distribucion = lector["NOM_DISTRIBUCION"].Equals(DBNull.Value) ? string.Empty : lector["NOM_DISTRIBUCION"].ToString();

                    var._Cantidad = lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);
                    var._Vigencia = lector["VIGENCIA"].Equals(DBNull.Value) ? string.Empty : lector["VIGENCIA"].ToString();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO"].ToString();

                    var._Cod_tipo_consistencia = lector["COD_CONSISTENCIA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_CONSISTENCIA"]);
                    var._Cod_tipo_digestabilidad = lector["COD_DIGESTABILIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DIGESTABILIDAD"]);
                    var._Cod_lactosa = lector["COD_LACTOSA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_LACTOSA"]);
                    var._Cod_dulzor = lector["COD_DULZOR"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DULZOR"]);
                    var._Cod_tipo_sales = lector["COD_SAL"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_SAL"]);
                    var._Cod_tipo_temperatura = lector["COD_TEMPERATURA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TEMPERATURA"]);
                    var._Cod_tipo_volumen = lector["COD_VOLUMEN"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_VOLUMEN"]);

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


        public List<Utilidades> Cargar_alimentos_menu_especiales(int cod_tipo_comida, int cod_tipo_distribucion, int cod_cobro, int cod_consistencia, int cod_digestabilidad, int cod_sal, int cod_lactosa, int cod_dulzor,string descripcion)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_ALIM_DIA_ESPECIALES");
                conn.ParametroBD("PIN_COD_COMIDA", cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_COBRO", cod_cobro, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_CONSISTENCIA", cod_consistencia, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DIGESTABILIDAD", cod_digestabilidad, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_SAL", cod_sal, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_LACTOSA", cod_lactosa, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DULZOR", cod_dulzor, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_DESCRIPCION", descripcion, DbType.String, ParameterDirection.Input);

                //conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Id_tipo_alimento = lector["ID_ALIM"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_ALIM"]);
                    var._Cod_tipo_alimento = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
                    var._Nom_tipo_alimento = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();
                    var._Cod_tipo_distribucion = lector["COD_DISTRIBUCION"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DISTRIBUCION"]);
                    var._Nom_tipo_distribucion = lector["NOM_DISTRIBUCION"].Equals(DBNull.Value) ? string.Empty : lector["NOM_DISTRIBUCION"].ToString();

                    var._Cantidad = lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);
                    var._Vigencia = lector["VIGENCIA"].Equals(DBNull.Value) ? string.Empty : lector["VIGENCIA"].ToString();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO"].ToString();

                    var._Cod_tipo_consistencia = lector["COD_CONSISTENCIA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_CONSISTENCIA"]);
                    var._Cod_tipo_digestabilidad = lector["COD_DIGESTABILIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DIGESTABILIDAD"]);
                    var._Cod_lactosa = lector["COD_LACTOSA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_LACTOSA"]);
                    var._Cod_dulzor = lector["COD_DULZOR"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DULZOR"]);
                    var._Cod_tipo_sales = lector["COD_SAL"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_SAL"]);
                    var._Cod_tipo_temperatura = lector["COD_TEMPERATURA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TEMPERATURA"]);
                    var._Cod_tipo_volumen = lector["COD_VOLUMEN"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_VOLUMEN"]);

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

        public List<Utilidades> Cargar_alimentos_menu_extra(int cod_tipo_comida, int cod_tipo_distribucion,string descripcion)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_ALIMENTOS_EXTRAS");
                conn.ParametroBD("PIN_COD_COMIDA", cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input); 
                conn.ParametroBD("PIN_DESCRIPCION", descripcion, DbType.String, ParameterDirection.Input);
                //conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Id_tipo_alimento = lector["ID_ALIM"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_ALIM"]);
                    var._Cod_tipo_alimento = lector["COD_ALIMENTO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_ALIMENTO"]);
                    var._Cod_tipo_distribucion = lector["COD_DISTRIBUCION"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DISTRIBUCION"]);
                    var._Nom_tipo_distribucion = lector["NOM_DISTRIBUCION"].Equals(DBNull.Value) ? string.Empty : lector["NOM_DISTRIBUCION"].ToString();
                    var._Cod_alimento_especial = lector["COD_ESPECIAL"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_ESPECIAL"]);
                   // var._Nom_alimento_especial = lector["NOM_ESPECIAL"].Equals(DBNull.Value) ? string.Empty : lector["NOM_ESPECIAL"].ToString();
                    var._Cod_tipo_comida = lector["COD_TIPO_COMIDA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_COMIDA"]);
                    var._Nom_tipo_alimento = lector["NOM_ESPECIAL"].Equals(DBNull.Value) ? string.Empty : lector["NOM_ESPECIAL"].ToString();
                    var._Cantidad = lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);
                    var._Vigencia = lector["VIGENCIA"].Equals(DBNull.Value) ? string.Empty : lector["VIGENCIA"].ToString();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO"].ToString();

                    var._Cod_tipo_consistencia = lector["COD_CONSISTENCIA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_CONSISTENCIA"]);
                    var._Cod_tipo_digestabilidad = lector["COD_DIGESTABILIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DIGESTABILIDAD"]);
                    var._Cod_lactosa = lector["COD_LACTOSA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_LACTOSA"]);
                    var._Cod_dulzor = lector["COD_DULZOR"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DULZOR"]);
                    var._Cod_tipo_sales = lector["COD_SAL"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_SAL"]);
                    var._Cod_tipo_temperatura = lector["COD_TEMPERATURA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TEMPERATURA"]);
                    var._Cod_tipo_volumen = lector["COD_VOLUMEN"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_VOLUMEN"]);
                   
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


        public List<Utilidades> Cargar_alimentos_menu_especiales(int cod_tipo_comida, int cod_tipo_distribucion, string descripcion)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_ALIMENTOS_ESPECIALES");
                conn.ParametroBD("PIN_COD_COMIDA", cod_tipo_comida, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_DESCRIPCION", descripcion, DbType.String, ParameterDirection.Input);
                //conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Id_tipo_alimento = lector["ID_ALIM"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_ALIM"]);
                    var._Cod_tipo_alimento = lector["COD_ALIMENTO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_ALIMENTO"]);
                    var._Cod_tipo_distribucion = lector["COD_DISTRIBUCION"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DISTRIBUCION"]);
                    var._Nom_tipo_distribucion = lector["NOM_DISTRIBUCION"].Equals(DBNull.Value) ? string.Empty : lector["NOM_DISTRIBUCION"].ToString();
                    var._Cod_alimento_especial = lector["COD_ESPECIAL"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_ESPECIAL"]);
                    // var._Nom_alimento_especial = lector["NOM_ESPECIAL"].Equals(DBNull.Value) ? string.Empty : lector["NOM_ESPECIAL"].ToString();
                    var._Cod_tipo_comida = lector["COD_TIPO_COMIDA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_COMIDA"]);
                    var._Nom_tipo_alimento = lector["NOM_ESPECIAL"].Equals(DBNull.Value) ? string.Empty : lector["NOM_ESPECIAL"].ToString();
                    var._Cantidad = lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);
                    var._Vigencia = lector["VIGENCIA"].Equals(DBNull.Value) ? string.Empty : lector["VIGENCIA"].ToString();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO"].ToString();

                    var._Cod_tipo_consistencia = lector["COD_CONSISTENCIA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_CONSISTENCIA"]);
                    var._Cod_tipo_digestabilidad = lector["COD_DIGESTABILIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DIGESTABILIDAD"]);
                    var._Cod_lactosa = lector["COD_LACTOSA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_LACTOSA"]);
                    var._Cod_dulzor = lector["COD_DULZOR"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DULZOR"]);
                    var._Cod_tipo_sales = lector["COD_SAL"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_SAL"]);
                    var._Cod_tipo_temperatura = lector["COD_TEMPERATURA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TEMPERATURA"]);
                    var._Cod_tipo_volumen = lector["COD_VOLUMEN"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_VOLUMEN"]);

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


        public List<Utilidades> Cargar_alimentos_especiales_cod( int cod_tipo_distribucion)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_ESPECIAL_COD");
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                //conn.ParametroBD("PIN_FECHA", fecha, DbType.String, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Id_tipo_alimento = lector["ID_ALIM"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_ALIM"]);
                  var._Cod_tipo_distribucion = lector["COD_DISTRIBUCION"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DISTRIBUCION"]);
                    var._Nom_tipo_distribucion = lector["NOM_DISTRIBUCION"].Equals(DBNull.Value) ? string.Empty : lector["NOM_DISTRIBUCION"].ToString();
                    var._Nom_tipo_alimento= lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();
                    var._Cantidad = lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);
                    var._Vigencia = lector["VIGENCIA"].Equals(DBNull.Value) ? string.Empty : lector["VIGENCIA"].ToString();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO"].ToString();
                    var._Mixto = lector["MIXTO"].Equals(DBNull.Value) ? string.Empty : lector["MIXTO"].ToString();

                    var._Cod_tipo_consistencia = lector["COD_CONSISTENCIA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_CONSISTENCIA"]);
                    var._Cod_tipo_digestabilidad = lector["COD_DIGESTABILIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DIGESTABILIDAD"]);
                    var._Cod_lactosa = lector["COD_LACTOSA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_LACTOSA"]);
                    var._Cod_dulzor = lector["COD_DULZOR"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DULZOR"]);
                    var._Cod_tipo_sales = lector["COD_SAL"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_SAL"]);
                    var._Cod_tipo_temperatura = lector["COD_TEMPERATURA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TEMPERATURA"]);
                    var._Cod_tipo_volumen = lector["COD_VOLUMEN"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_VOLUMEN"]);

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

        public List<Utilidades> Cargar_alimentos_menu_extra_extra( int cod_tipo_distribucion,string descripcion)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_ALIMENTOS_ESPECIAL");
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_DESCRIPCION", descripcion, DbType.String, ParameterDirection.Input);


                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_tipo_alimento = lector["ID_ALIM"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_ALIM"]);
                    var._Cod_tipo_distribucion = lector["COD_DISTRIBUCION"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DISTRIBUCION"]);
                    var._Nom_tipo_distribucion = lector["NOM_DISTRIBUCION"].Equals(DBNull.Value) ? string.Empty : lector["NOM_DISTRIBUCION"].ToString();   
                    var._Nom_tipo_alimento = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();
                    var._Cantidad = lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);
                    var._Vigencia = lector["VIGENCIA"].Equals(DBNull.Value) ? string.Empty : lector["VIGENCIA"].ToString();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO"].ToString();

                    var._Cod_tipo_consistencia = lector["COD_CONSISTENCIA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_CONSISTENCIA"]);
                    var._Cod_tipo_digestabilidad = lector["COD_DIGESTABILIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DIGESTABILIDAD"]);
                    var._Cod_lactosa = lector["COD_LACTOSA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_LACTOSA"]);
                    var._Cod_dulzor = lector["COD_DULZOR"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DULZOR"]);
                    var._Cod_tipo_sales = lector["COD_SAL"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_SAL"]);
                    var._Cod_tipo_temperatura = lector["COD_TEMPERATURA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TEMPERATURA"]);
                    var._Cod_tipo_volumen = lector["COD_VOLUMEN"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_VOLUMEN"]);

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


        public List<Utilidades> Cargar_alimentos_especial(int cod_tipo_distribucion, string descripcion)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_ALIMENTOS_ESPECIAL2");
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_tipo_distribucion, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_DESCRIPCION", descripcion, DbType.String, ParameterDirection.Input);


                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {

                 string cod = lector["CODIGO"].Equals(DBNull.Value) ? string.Empty : lector["CODIGO"].ToString();
                 string cad = lector["DESCRIPCION"].Equals(DBNull.Value) ? string.Empty : lector["DESCRIPCION"].ToString();
                
              
  
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




        public Utilidades Extraer_componentes_alimento(string cod_alimento, string cod_distribucion)
        {
            try
            {
                Utilidades  var = new Utilidades();
                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_EXTRAER_COMPONENTES");
                conn.ParametroBD("PIN_COD_ALIMENTO", cod_alimento, DbType.Int64, ParameterDirection.Input);
                conn.ParametroBD("PIN_COD_DISTRIBUCION", cod_distribucion, DbType.Int64, ParameterDirection.Input);

                IDataReader lector = conn.ExecuteReader();


                if (lector.Read())
                {
                  

                    var._Cod_tipo_consistencia = lector["COD_CONSISTENCIA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_CONSISTENCIA"]);
                    var._Cod_tipo_digestabilidad = lector["COD_DIGESTABILIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DIGESTABILIDAD"]);
                    var._Cod_dulzor = lector["COD_DULZOR"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DULZOR"]);
                    var._Cod_lactosa = lector["COD_LACTOSA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_LACTOSA"]);
                    var._Cod_tipo_temperatura = lector["COD_TEMPERATURA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TEMPERATURA"]);
                    var._Cod_tipo_volumen = lector["COD_VOLUMEN"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_VOLUMEN"]);
                    var._Cod_tipo_sales = lector["COD_SAL"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_SAL"]);

                  
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


        public Utilidades Extraer_codigo_especial()
        {
            try
            {
                Utilidades var = new Utilidades();
                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_CODIGO_ESPECIAL");


                IDataReader lector = conn.ExecuteReader();


                if (lector.Read())
                {


                    var._Id = lector["CODIGO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CODIGO"]);
          

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


        public List<Utilidades> Cargar_pedidos_registrados(int cod_pedido)
        {
            try
            {

                ConectarFalp conn = new ConectarFalp(BD, User, Pass, ConectarFalp.TipoBase.Oracle);

                if (conn.Estado == ConnectionState.Closed) conn.Abrir();

                conn.CrearCommand(CommandType.StoredProcedure, "PCK_NUT001I.P_CARGAR_TIPO_COMIDA_PED");
                conn.ParametroBD("PIN_COD_PEDIDO", cod_pedido, DbType.Int64, ParameterDirection.Input);


                IDataReader lector = conn.ExecuteReader();

                List<Utilidades> lista = new List<Utilidades>();

                while (lector.Read())
                {
                    Utilidades var = new Utilidades();

                    var._Cod_menu = lector["ID_MENU"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_MENU"]);
                    var._Id_tipo_distribucion = lector["ID_TIPO_DISTRIBUCION"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_TIPO_DISTRIBUCION"]);     
                    var._Cod_tipo_distribucion = lector["COD_TIPO_DISTRIBUCION"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_DISTRIBUCION"]);
                    var._Nom_tipo_distribucion = lector["NOM_TIPO_DISTRIBUCION"].Equals(DBNull.Value) ? string.Empty : lector["NOM_TIPO_DISTRIBUCION"].ToString();
                    var._Id_tipo_alimento = lector["ID_TIPO_ALIMENTO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_TIPO_ALIMENTO"]);     
                    var._Cod_tipo_alimento = lector["COD_TIPO_ALIMENTO"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_ALIMENTO"]);
                    var._Nom_tipo_alimento = lector["NOM_TIPO_ALIMENTO"].Equals(DBNull.Value) ? string.Empty : lector["NOM_TIPO_ALIMENTO"].ToString();
                    var._Id_tipo_comida = lector["ID_TIPO_COMIDA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["ID_TIPO_COMIDA"]);     
                    var._Cod_tipo_comida = lector["COD_TIPO_COMIDA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TIPO_COMIDA"]);
                    var._Nom_tipo_comida = lector["NOM_TIPO_COMIDA"].Equals(DBNull.Value) ? string.Empty : lector["NOM_TIPO_COMIDA"].ToString();

                    var._Cantidad = lector["CANTIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["CANTIDAD"]);
                    var._Vigencia = lector["VIGENCIA"].Equals(DBNull.Value) ? string.Empty : lector["VIGENCIA"].ToString();
                    var._Estado = lector["ESTADO"].Equals(DBNull.Value) ? string.Empty : lector["ESTADO"].ToString();

                    var._Cod_tipo_consistencia = lector["COD_CONSISTENCIA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_CONSISTENCIA"]);
                    var._Cod_tipo_digestabilidad = lector["COD_DIGESTABILIDAD"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DIGESTABILIDAD"]);
                    var._Cod_dulzor = lector["COD_DULZOR"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_DULZOR"]);
                    var._Cod_lactosa = lector["COD_LACTOSA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_LACTOSA"]);
                    var._Cod_tipo_temperatura = lector["COD_TEMPERATURA"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_TEMPERATURA"]);
                    var._Cod_tipo_volumen = lector["COD_VOLUMEN"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_VOLUMEN"]);
                    var._Cod_tipo_sales = lector["COD_SAL"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(lector["COD_SAL"]);
                    var._Observacion = lector["OBSERVACION"].Equals(DBNull.Value) ? string.Empty : lector["OBSERVACION"].ToString();
                    var._Comentario_tipo_comida = lector["COMENTARIO"].Equals(DBNull.Value) ? string.Empty : lector["COMENTARIO"].ToString();
                    var._Mixto = lector["MIXTO"].Equals(DBNull.Value) ? string.Empty : lector["MIXTO"].ToString();
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




      


    }
}
