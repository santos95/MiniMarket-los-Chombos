using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DRol
    {

        public int IdRol { get; set; }
        public string Rol { get; set; }
        public string Descripcion { get; set; }
        public string Registrado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public char Estado { get; set; }
        public string TextoBuscar { get; set; }


        public DRol()
        {

        }

        public DRol(string rol, string descripcion, string registrado, char estado)
        {

            Rol = rol;
            Descripcion = descripcion;
            Registrado = registrado;
            Estado = estado;

        }

        public DRol(int id, string rol, string descripcion, char estado)
        {

            IdRol = id;
            Rol = rol;
            Descripcion = descripcion;
            Estado = estado;

        }

        public DRol(int idRol, string rol, string descripcion, string registrado, DateTime fechaRegistro, char estado)
        {
            IdRol = idRol;
            Rol = rol;
            Descripcion = descripcion;
            Registrado = registrado;
            FechaRegistro = fechaRegistro;
            Estado = estado;
        }

        public string Guardar(DRol Rol)
        {
            string rpta;
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexion.Cn;
                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spInsertarRol",
                    CommandType = CommandType.StoredProcedure

                };

                /*SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "spInsertarRol";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                */
                SqlParameter parRol = new SqlParameter
                {

                    ParameterName = "@rol",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Rol.Rol,

                };
                sqlCmd.Parameters.Add(parRol);

                SqlParameter parDescripcion = new SqlParameter
                {

                    ParameterName = "@descrip",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 120,
                    Value = Rol.Descripcion

                };
                sqlCmd.Parameters.Add(parDescripcion);

                SqlParameter parRegistrado = new SqlParameter
                {

                    ParameterName = "@registrado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 40,
                    Value = Rol.Registrado

                };
                sqlCmd.Parameters.Add(parRegistrado);

                SqlParameter parEstado = new SqlParameter
                {

                    ParameterName = "@estado",
                    SqlDbType = SqlDbType.Char,
                    SqlValue = Rol.Estado
                };
                sqlCmd.Parameters.Add(parEstado);

                SqlParameter parMensaje = new SqlParameter
                {

                    ParameterName = "@mensaje",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Direction = ParameterDirection.Output,

                };
                sqlCmd.Parameters.Add(parMensaje);

              

                //rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK, " + parMensaje.Value.ToString() : parMensaje.Value.ToString();
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

        public string Actualizar(DRol Rol)
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
                    CommandText = "spActualizarRol",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parId = new SqlParameter
                {

                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Value = Rol.IdRol,

                };

                sqlCmd.Parameters.Add(parId);

                SqlParameter parRol = new SqlParameter
                {

                    ParameterName = "@rol",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Rol.Rol

                };

                sqlCmd.Parameters.Add(parRol);

                SqlParameter parDescripcion = new SqlParameter
                {

                    ParameterName = "@descrip",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 120,
                    Value = Rol.Descripcion

                };

                sqlCmd.Parameters.Add(parDescripcion);

                SqlParameter parEstado = new SqlParameter
                {

                    ParameterName = "@estado",
                    SqlDbType = SqlDbType.Char,
                    Size = 1,
                    Value = Rol.Estado

                };

                sqlCmd.Parameters.Add(parEstado);

                SqlParameter parMensaje = new SqlParameter
                {

                    ParameterName = "@mensaje",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Direction = ParameterDirection.Output,

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
                //cierra la conexión.
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();

            }


            return rpta;
        }

        public DataTable Mostrar()
        {

            DataTable dtResultado = new DataTable("Roles");
            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "spMostrarRoles";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }

            return dtResultado;

        }

        //Filtros
        public DataTable MostrarA()
        {

            DataTable dtResultado = new DataTable("RolesA");
            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spMostrarRolesA",
                    CommandType = CommandType.StoredProcedure
               

                };

                SqlDataAdapter sqlDat = new SqlDataAdapter(cmd);

                sqlDat.Fill(dtResultado);
            }
            catch
            {

                dtResultado = null;

            }

            return dtResultado;
        }

        public DataTable MostrarI()
        {

            DataTable dtResultado = new DataTable("RolesI");
            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spMostrarRolesI",
                    CommandType = CommandType.StoredProcedure


                };

                SqlDataAdapter sqlDat = new SqlDataAdapter(cmd);

                sqlDat.Fill(dtResultado);
            }
            catch
            {

                dtResultado = null;

            }

            return dtResultado;
        }

        //buscar por nombre
        public DataTable BuscarNombre(DRol Rol)
        {
            DataTable dtResultado = new DataTable("Rol");

            try
            {
                SqlConnection sqlCon = new SqlConnection
                {

                    ConnectionString = Conexion.Cn

                };


                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spBuscarRolNombre",
                    CommandType = CommandType.StoredProcedure,



                };

                SqlParameter parTextoBuscar = new SqlParameter
                {

                    ParameterName = "@textobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Rol.TextoBuscar

                };

                sqlCmd.Parameters.Add(parTextoBuscar);




                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtResultado);


            }
            catch
            {

                dtResultado = null;

            }

            return dtResultado;
        }
    }
}
