using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos.GestionNegocio
{
    public class Cargo
    {

        private int Id { get; set; }
        private string Nombre { get; set; }
        private string Descripcion { get; set; }
        private string Registrado { get; set; }
        private string Autorizado { get; set; }
        private char Estado { get; set; }

        public Cargo()
        {

        }

        public Cargo(int id, string autorizado)
        {
            this.Id = id;
            this.Autorizado = autorizado;
        }

        public Cargo(int id, string nombre, string descripcion, string registrado, string autorizado, char estado)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Registrado = registrado;
            this.Autorizado = autorizado;
            this.Estado = estado;
        }

        public Cargo(string nombre, string descripcion, string registrado, string autorizado, char estado)
        {

            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Registrado = registrado;
            this.Autorizado = autorizado;
            this.Estado = estado;

        }

        public Cargo(string nombre, string descripcion, string registrado, string autorizado)
        {

            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Registrado = registrado;
            this.Autorizado = autorizado;

        }

        public DataTable Mostrar()
        {


            DataTable dtResultado = new DataTable("Cargos");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                

                sqlCon.ConnectionString = Conexion.Cn;

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spMostrarCargo",
                    CommandType = CommandType.StoredProcedure
              
                };
             

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

            DataTable dtResultado = new DataTable("CargosActivos");
            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spMostrarCargoA",
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

            DataTable dtResultado = new DataTable("CargosInactivos");
            SqlConnection sqlCon = new SqlConnection();

            try
            {

                sqlCon.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spMostrarCargoI",
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

        public DataTable BuscarNombre(string nombre)
        {
            DataTable dt = new DataTable("Cargo");

            try
            {
                SqlConnection sqlCon = new SqlConnection
                {

                    ConnectionString = Conexion.Cn

                };

                SqlCommand sqlCmd = new SqlCommand
                {

                    Connection = sqlCon,
                    CommandText = "spBuscarCargoNombre",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parTextoBuscar = new SqlParameter
                {

                    ParameterName = "@textobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = nombre

                };

                sqlCmd.Parameters.Add(parTextoBuscar);

                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
                sqlDA.Fill(dt);

            }
            catch
            {
                dt = null;
            }

            return dt;
        }

        public string Guardar(Cargo C)
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
                    CommandText = "spRegistrarCargo",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parNombre = new SqlParameter
                {

                    ParameterName = "@nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = C.Nombre

                };

                sqlCmd.Parameters.Add(parNombre);

                SqlParameter parDescrip = new SqlParameter
                {

                    ParameterName = "@descripcion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = C.Descripcion

                };

                sqlCmd.Parameters.Add(parDescrip);

                SqlParameter parRegistrado = new SqlParameter
                {

                    ParameterName = "@registrado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = C.Registrado

                };

                sqlCmd.Parameters.Add(parRegistrado);


                SqlParameter parAutorizado = new SqlParameter
                {

                    ParameterName = "@autorizado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = C.Autorizado

                };

                sqlCmd.Parameters.Add(parAutorizado);

                SqlParameter parEstado = new SqlParameter
                {

                    ParameterName = "@estado",
                    SqlDbType = SqlDbType.Char,
                    Size = 1,
                    Value = C.Estado

                };

                sqlCmd.Parameters.Add(parEstado);

                SqlParameter parMensaje = new SqlParameter
                {

                    ParameterName = "@mensaje",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 80,
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

                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();

            }


            return rpta;

        }

        public string Autorizar(Cargo C)
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
                    CommandText = "spAutorizarCargo",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parID = new SqlParameter
                {

                    ParameterName = "@idCargo",
                    SqlDbType = SqlDbType.Int,
                    Value = C.Id

                };

                sqlCmd.Parameters.Add(parID);

                SqlParameter parAutorizar = new SqlParameter
                {

                    ParameterName = "@autorizar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = C.Autorizado

                };

                sqlCmd.Parameters.Add(parAutorizar);

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

                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();

            }


            return rpta;

        }

        public string Desautorizar(Cargo C)
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
                    CommandText = "spDesautorizarCargo",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parID = new SqlParameter
                {

                    ParameterName = "@idCargo",
                    SqlDbType = SqlDbType.Int,
                    Value = C.Id

                };

                sqlCmd.Parameters.Add(parID);

                SqlParameter parAutorizar = new SqlParameter
                {

                    ParameterName = "@autorizar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = C.Autorizado

                };

                sqlCmd.Parameters.Add(parAutorizar);

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

                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();

            }


            return rpta;

        }

        public string Actualizar(Cargo C)
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
                    CommandText = "spActualizarCargo",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter parID = new SqlParameter
                {

                    ParameterName = "@idCargo",
                    SqlDbType = SqlDbType.Int,
                    Value = C.Id

                };

                sqlCmd.Parameters.Add(parID);

                SqlParameter parNombre = new SqlParameter
                {

                    ParameterName = "@nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = C.Nombre

                };

                sqlCmd.Parameters.Add(parNombre);

                SqlParameter parDescrip = new SqlParameter
                {

                    ParameterName = "@descripcion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = C.Descripcion

                };

                sqlCmd.Parameters.Add(parDescrip);

                SqlParameter parRegistrado = new SqlParameter
                {

                    ParameterName = "@registrado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = C.Registrado

                };

                sqlCmd.Parameters.Add(parRegistrado);

                SqlParameter parEstado = new SqlParameter
                {

                    ParameterName = "@estado",
                    SqlDbType = SqlDbType.Char,
                    Size = 1,
                    Value = C.Estado

                };

                SqlParameter parAutorizar = new SqlParameter
                {

                    ParameterName = "@autorizado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = C.Autorizado

                };

                sqlCmd.Parameters.Add(parAutorizar);

                sqlCmd.Parameters.Add(parEstado);

                SqlParameter parMensaje = new SqlParameter
                {

                    ParameterName = "@mensaje",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 80,
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

                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();

            }


            return rpta;
        }
    }

}
