using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos.Administracion
{
    public class Usuario
    {

        private int CodUsuario { get; set; }
        private int CodEmpleado { get; set; }
        private int CodRol { get; set; }
        private string NombreUsuario { get; set; }
        private string Contraseña { get; set; }
        private string Registrado { get; set; }
        private string Autorizado { get; set; }
        private string Observacion { get; set; }
        private char Estado { get; set; }

        public Usuario()
        {

        }

        public Usuario(int codEmpleado, int codRol, string nombreUsuario, string contraseña, string registrado, string autorizado, string observacion, char estado)
        {

            CodEmpleado = codEmpleado;
            CodRol = codRol;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            Registrado = registrado;
            Autorizado = autorizado;
            Observacion = observacion;
            Estado = estado;

        }

        public Usuario(int codUsuario, int codRol, string nombreUsuario, string contraseña, string autorizado, string observacion, char estado)
        {

            this.CodUsuario = codUsuario;
            this.CodRol = codRol;
            this.NombreUsuario = nombreUsuario;
            this.Contraseña = contraseña;
            this.Autorizado = autorizado;
            this.Observacion = observacion;
            this.Estado = estado;

        }
        //Filtro todos
        public DataTable Mostrar()
        {
            DataTable dt = new DataTable("Usuarios");
            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spListarUsuarios",
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

        //Filtro Usuarios Activos
        public DataTable MostrarA()
        {
            DataTable dt = new DataTable("Usuarios");
            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spListarUsuariosA",
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

        //Filtro Usuarios Inactivos
        public DataTable MostrarI()
        {
            DataTable dt = new DataTable("Usuarios");
            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spListarUsuariosI",
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

        //Filtro Usuarios Empleados activos sin usuarios asignados
        public DataTable MostrarEmpleados()
        {
            DataTable dt = new DataTable("Empleados");
            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spListarEmpleados",
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

        //Buscar por Código usuario
        public DataTable BuscarCodUsuario(int codUsuario, int filtro)
        {

            DataTable dt = new DataTable("Usuario");

            try
            {

                SqlConnection sqlCon = new SqlConnection
                {

                    ConnectionString = Conexion.Cn

                };

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spBuscarCodUsuario",
                    CommandType = CommandType.StoredProcedure
    
                };

                SqlParameter parCodUsuario = new SqlParameter
                {

                    ParameterName = "@usuario",
                    SqlDbType = SqlDbType.Int,
                    Value = codUsuario

                };

                sqlCmd.Parameters.Add(parCodUsuario);

                SqlParameter parFiltro = new SqlParameter
                {

                    ParameterName = "@filtro",
                    SqlDbType = SqlDbType.Int,
                    Value = filtro

                };

                sqlCmd.Parameters.Add(parFiltro);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);

                da.Fill(dt);

            }
            catch 
            {

                dt = null;
                
            }

            return dt;

        }

        //Buscar por nombre de usuario
        public DataTable BuscarUsuario(string usuario, int filtro)
        {
            DataTable dt = new DataTable("Usuario");

            try
            {

                SqlConnection sqlCon = new SqlConnection
                {

                    ConnectionString = Conexion.Cn

                };

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spBuscarNombreUsuario",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parUsuario = new SqlParameter
                {

                    ParameterName = "@usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = usuario

                };

                sqlCmd.Parameters.Add(parUsuario);

                SqlParameter parFiltro = new SqlParameter
                {

                    ParameterName = "@filtro",
                    SqlDbType = SqlDbType.Int,
                    Value = filtro

                };

                sqlCmd.Parameters.Add(parFiltro);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);

                da.Fill(dt);


            }
            catch 
            {

                dt = null;
            }

            return dt;
        }

        //Buscar por el nombre del empleado
        public DataTable BuscarUsuarioNombre(string nombre, int filtro)
        {

            DataTable dt = new DataTable("Usuario");

            try
            {

                SqlConnection sqlCon = new SqlConnection
                {

                    ConnectionString = Conexion.Cn

                };

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spBuscarUsuarioNombre",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parUsuario = new SqlParameter
                {

                    ParameterName = "@nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 60,
                    Value = nombre

                };

                sqlCmd.Parameters.Add(parUsuario);

                SqlParameter parFiltro = new SqlParameter
                {

                    ParameterName = "@filtro",
                    SqlDbType = SqlDbType.Int,
                    Value = filtro

                };

                sqlCmd.Parameters.Add(parFiltro);

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);

                da.Fill(dt);


            }
            catch
            {

                dt = null;
            }

            return dt;

        }
 
        public string NuevoUsuario(Usuario U)
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
                    CommandText = "spNuevoUsuario",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parCodEmpleado = new SqlParameter
                {

                    ParameterName = "@codEmpleado",
                    SqlDbType = SqlDbType.Int,
                    Value = U.CodEmpleado


                };

                sqlCmd.Parameters.Add(parCodEmpleado);

                SqlParameter parRol = new SqlParameter
                {

                    ParameterName = "@rol",
                    SqlDbType = SqlDbType.Int,
                    Value = U.CodRol

                };

                sqlCmd.Parameters.Add(parRol);

                SqlParameter parUsuario = new SqlParameter
                {

                    ParameterName = "@usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = U.NombreUsuario

                };

                sqlCmd.Parameters.Add(parUsuario);

                SqlParameter parContraseña = new SqlParameter
                {

                    ParameterName = "@contraseña",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = U.Contraseña

                };

                sqlCmd.Parameters.Add(parContraseña);

                SqlParameter parRegistrado = new SqlParameter
                {

                    ParameterName = "@registrado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 80,
                    Value = U.Registrado

                };

                sqlCmd.Parameters.Add(parRegistrado);

                SqlParameter parAutorizado = new SqlParameter
                {

                    ParameterName = "@autorizado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 80,
                    Value = U.Autorizado

                };

                sqlCmd.Parameters.Add(parAutorizado);

                SqlParameter parObservacion = new SqlParameter
                {

                    ParameterName = "@observacion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 300,
                    Value = U.Observacion

                };

                sqlCmd.Parameters.Add(parObservacion);

                SqlParameter parEstado = new SqlParameter
                {

                    ParameterName = "@estado",
                    SqlDbType = SqlDbType.Char,
                    Size = 1,
                    Value = U.Estado

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

        public string ActualizarUsuario(Usuario U)
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
                    CommandText = "spActualizarUsuario",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parCodEmpleado = new SqlParameter
                {

                    ParameterName = "@codUsuario",
                    SqlDbType = SqlDbType.Int,
                    Value = U.CodUsuario


                };

                sqlCmd.Parameters.Add(parCodEmpleado);

                SqlParameter parRol = new SqlParameter
                {

                    ParameterName = "@rol",
                    SqlDbType = SqlDbType.Int,
                    Value = U.CodRol

                };

                sqlCmd.Parameters.Add(parRol);

                SqlParameter parUsuario = new SqlParameter
                {

                    ParameterName = "@usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = U.NombreUsuario

                };

                sqlCmd.Parameters.Add(parUsuario);

                SqlParameter parContraseña = new SqlParameter
                {

                    ParameterName = "@contraseña",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = U.Contraseña

                };

                sqlCmd.Parameters.Add(parContraseña);

          
                SqlParameter parAutorizado = new SqlParameter
                {

                    ParameterName = "@autorizado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 80,
                    Value = U.Autorizado

                };

                sqlCmd.Parameters.Add(parAutorizado);

                SqlParameter parObservacion = new SqlParameter
                {

                    ParameterName = "@observacion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 300,
                    Value = U.Observacion

                };

                sqlCmd.Parameters.Add(parObservacion);

                SqlParameter parEstado = new SqlParameter
                {

                    ParameterName = "@estado",
                    SqlDbType = SqlDbType.Char,
                    Size = 1,
                    Value = U.Estado

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
