using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos.GestionNegocio
{
    public class HistorialEmpleado
    {

        private int IdHistorial { get; set; }
        private int CodCargo { get; set; }
        private int CodEmpleado { get; set; }
        private string Registrado { get; set; }
        private string Autorizado { get; set; }
        private DateTime FechaRegistro { get; set; }
        private string Observacion { get; set; }
        private char Estado { get; set; }

        public HistorialEmpleado()
        {

        }

        public HistorialEmpleado(int codCargo, int codEmpleado, string registrado, string autorizado, DateTime fechaRegistro, char estado)
        {

            this.CodCargo = codCargo;
            this.CodEmpleado = codEmpleado;
            this.Registrado = registrado;
            this.Autorizado = autorizado;
            this.FechaRegistro = fechaRegistro;
            this.Estado = estado;

        }


        public HistorialEmpleado(int codCargo, int codEmpleado, string registrado, string observacion)
        {

            this.CodCargo = codCargo;
            this.CodEmpleado = codEmpleado;
            this.Registrado = registrado;
            this.Observacion = observacion;

        }

        public HistorialEmpleado(int codCargo, int codEmpleado, string registrado, string autorizado, string observacion)
        {

            this.CodCargo = codCargo;
            this.CodEmpleado = codEmpleado;
            this.Registrado = registrado;
            this.Autorizado = autorizado;
            this.Observacion = observacion;

        }

        public HistorialEmpleado(int idHistorial, string observacion, string autorizado, char estado)
        {

            this.IdHistorial = idHistorial;
            this.Observacion = observacion;
            this.Autorizado = autorizado;
            this.Estado = estado;

        }

        public DataTable Mostrar()
        {

            DataTable dt = new DataTable("HistorialEmpleado");
            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;
                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spMostrarEmpleadosTodos",
                    CommandType = CommandType.StoredProcedure

                };

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dt);

            }
            catch
            {

                dt = null;
                
            }

            return dt;
        }

        public DataTable MostrarA()
        {
            DataTable dt = new DataTable("HistorialActivo");
            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;
                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spMostrarHistorialEmpleadoA",
                    CommandType = CommandType.StoredProcedure

                };

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dt);

            }
            catch
            {

                dt = null;

            }

            return dt;
        }

        public DataTable MostrarI()
        {
            DataTable dt = new DataTable("HistorialInactivos");
            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;
                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spMostrarHistorialEmpleadoI",
                    CommandType = CommandType.StoredProcedure

                };

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dt);

            }
            catch
            {

                dt = null;

            }

            return dt;
        }

        public DataTable MostrarNuevoEmpleado()
        {

            DataTable dt = new DataTable("EmpleadosNuevos");
            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;
                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spMostrarEmpleadosNuevos",
                    CommandType = CommandType.StoredProcedure

                };

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);

                sqlDat.Fill(dt);

            }
            catch
            {

                dt = null;

            }

            return dt;

        }

        //Búsquedas
        public DataTable BuscarCodigo(int numDoc, int filtro)
        {

            DataTable dt = new DataTable("HistorialEmpleado");
          

            try
            {

                SqlConnection sqlCon = new SqlConnection
                {

                    ConnectionString = Conexion.Cn

                };

                SqlCommand cmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spBuscarCódigoEmpleaado",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parCodigo = new SqlParameter
                {

                    ParameterName = "@codigo",
                    SqlDbType = SqlDbType.Int,
                    Value = numDoc

                };

                cmd.Parameters.Add(parCodigo);

                SqlParameter parFiltro = new SqlParameter
                {

                    ParameterName = "@filtro",
                    SqlDbType = SqlDbType.Int,
                    Value = filtro

                };

                cmd.Parameters.Add(parFiltro);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch 
            {

                dt = null;
            }

            return dt;

        }

        public DataTable BuscarNombre(string nombre, int filtro)
        {

            DataTable dt = new DataTable("HistorialEmpleado");


            try
            {

                SqlConnection sqlCon = new SqlConnection
                {

                    ConnectionString = Conexion.Cn

                };

                SqlCommand cmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spBuscarNombre",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parNombre = new SqlParameter
                {

                    ParameterName = "@nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 60,
                    Value = nombre

                };

                cmd.Parameters.Add(parNombre);

                SqlParameter parFiltro = new SqlParameter
                {

                    ParameterName = "@filtro",
                    SqlDbType = SqlDbType.Int,
                    Value = filtro

                };

                cmd.Parameters.Add(parFiltro);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {

                dt = null;
            }

            return dt;

        }

        public DataTable BuscarApellido(string apellido, int filtro)
        {

            DataTable dt = new DataTable("HistorialEmpleado");


            try
            {

                SqlConnection sqlCon = new SqlConnection
                {

                    ConnectionString = Conexion.Cn

                };

                SqlCommand cmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spBuscarApellido",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parApellido = new SqlParameter
                {

                    ParameterName = "@apellido",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 60,
                    Value = apellido

                };

                cmd.Parameters.Add(parApellido);

                SqlParameter parFiltro = new SqlParameter
                {

                    ParameterName = "@filtro",
                    SqlDbType = SqlDbType.Int,
                    Value = filtro

                };

                cmd.Parameters.Add(parFiltro);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {

                dt = null;
            }

            return dt;

        }

        public DataTable BuscarCargo(string cargo, int filtro)
        {

            DataTable dt = new DataTable("NuevosEmpleados");


            try
            {

                SqlConnection sqlCon = new SqlConnection
                {

                    ConnectionString = Conexion.Cn

                };

                SqlCommand cmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spBuscarCargo",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parCargo = new SqlParameter
                {

                    ParameterName = "@cargo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = cargo

                };

                cmd.Parameters.Add(parCargo);

                SqlParameter parFiltro = new SqlParameter
                {

                    ParameterName = "@filtro",
                    SqlDbType = SqlDbType.Int,
                    Value = filtro

                };

                cmd.Parameters.Add(parFiltro);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {

                dt = null;
            }

            return dt;

        }

        public string GuardarSinAutorizar(HistorialEmpleado HE)
        {
            string rpta = "";

            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;
                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spGuardarHistorial",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parCodEmpleado = new SqlParameter
                {

                    ParameterName = "@codEmpleado",
                    SqlDbType = SqlDbType.Int,
                    Value = HE.CodEmpleado

                };

                sqlCmd.Parameters.Add(parCodEmpleado);
           
                SqlParameter parCodCargo = new SqlParameter
                {

                    ParameterName = "@codCargo",
                    SqlDbType = SqlDbType.Int,
                    Value = HE.CodCargo

                };

                sqlCmd.Parameters.Add(parCodCargo);

                SqlParameter parRegistrado = new SqlParameter
                {

                    ParameterName = "@registrado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 80,
                    Value = HE.Registrado

                };

                sqlCmd.Parameters.Add(parRegistrado);

                SqlParameter parObservacion = new SqlParameter
                {

                    ParameterName = "@observacion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 300,
                    Value = HE.Observacion

                };

                sqlCmd.Parameters.Add(parObservacion);

                SqlParameter parMensaje = new SqlParameter
                {

                    ParameterName = "@mensaje",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Direction = ParameterDirection.Output

                };

                sqlCmd.Parameters.Add(parMensaje);

                sqlCmd.ExecuteNonQuery();
                rpta = parMensaje.Value.ToString();


            }
            catch (Exception ex)
            {

                rpta = ex.Message;
                
            }
            finally
            {

                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();

            }

            return rpta;

        }


        public string GuardarAutorizar(HistorialEmpleado HE)
        {
            string rpta = "";

            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;
                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spGuardarAutorizarHistorial",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parCodEmpleado = new SqlParameter
                {

                    ParameterName = "@codEmpleado",
                    SqlDbType = SqlDbType.Int,
                    Value = HE.CodEmpleado

                };

                sqlCmd.Parameters.Add(parCodEmpleado);

                SqlParameter parCodCargo = new SqlParameter
                {

                    ParameterName = "@codCargo",
                    SqlDbType = SqlDbType.Int,
                    Value = HE.CodCargo

                };

                sqlCmd.Parameters.Add(parCodCargo);

                SqlParameter parRegistrado = new SqlParameter
                {

                    ParameterName = "@registrado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 80,
                    Value = HE.Registrado

                };

                sqlCmd.Parameters.Add(parRegistrado);

                SqlParameter parAutorizado = new SqlParameter
                {

                    ParameterName = "@autorizado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 80,
                    Value = HE.Autorizado

                };

                sqlCmd.Parameters.Add(parAutorizado);


                SqlParameter parObservacion = new SqlParameter
                {

                    ParameterName = "@observacion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 300,
                    Value = HE.Observacion

                };

                sqlCmd.Parameters.Add(parObservacion);

                SqlParameter parMensaje = new SqlParameter
                {

                    ParameterName = "@mensaje",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Direction = ParameterDirection.Output

                };

                sqlCmd.Parameters.Add(parMensaje);

                sqlCmd.ExecuteNonQuery();
                rpta = parMensaje.Value.ToString();


            }
            catch (Exception ex)
            {

                rpta = ex.Message;

            }
            finally
            {

                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();

            }

            return rpta;

        }

        public string ActualizarHistorial(HistorialEmpleado HE)
        {

            string rpta = "";

            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;
                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spActualizarHistorial",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parId = new SqlParameter
                {

                    ParameterName = "@idDetalle",
                    SqlDbType = SqlDbType.Int,
                    SqlValue = HE.IdHistorial

                };

                sqlCmd.Parameters.Add(parId);

                SqlParameter parObservacion = new SqlParameter
                {

                    ParameterName = "@observacion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 300,
                    Value = HE.Observacion

                };

                sqlCmd.Parameters.Add(parObservacion);

                SqlParameter parAutorizado = new SqlParameter
                {

                    ParameterName = "@autorizado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 80,
                    Value = HE.Autorizado

                };

                sqlCmd.Parameters.Add(parAutorizado);

                SqlParameter parEstado = new SqlParameter
                {

                    ParameterName = "@estado",
                    SqlDbType = SqlDbType.Char,
                    Size = 1,
                    Value = HE.Estado

                };

                sqlCmd.Parameters.Add(parEstado);


                SqlParameter parMensaje = new SqlParameter
                {

                    ParameterName = "@mensaje",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 80,
                    Direction = ParameterDirection.Output

                };

                sqlCmd.Parameters.Add(parMensaje);

                sqlCmd.ExecuteNonQuery();
                rpta = parMensaje.Value.ToString();



            }
            catch (Exception ex)
            {

                rpta = ex.Message;

            }
            finally
            {

                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();

            }

            return rpta;

        }

    }

}
