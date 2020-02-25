using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;



namespace CapaDatos
{
    public class DCategoria
    {
        private int _Id_categoria;
        private string _Nombrecat;
        private string _Observacion;
        private DateTime _Fecharegistro;
        private string _TextoBuscar;

        public int Id_categoria
        {
            get
            {
                return _Id_categoria;
            }

            set
            {
                _Id_categoria = value;
            }
        }

        public string Nombrecat
        {
            get
            {
                return _Nombrecat;
            }

            set
            {
                _Nombrecat = value;
            }
        }

        public string Observacion
        {
            get
            {
                return _Observacion;
            }

            set
            {
                _Observacion = value;
            }
        }

        public DateTime Fecharegistro
        {
            get
            {
                return _Fecharegistro;
            }

            set
            {
                _Fecharegistro = value;
            }
        }

        public string TextoBuscar
        {
            get
            {
                return _TextoBuscar;
            }

            set
            {
                _TextoBuscar = value;
            }
        }






        //Constructor Vacío
        public DCategoria()
        {

        }
        //Constructor con parámetros
        public DCategoria(int id_categoria, string nombrecat, string observacion, DateTime fecharegistro, string textobuscar)
        {
            this.Id_categoria = id_categoria;
            this.Nombrecat = nombrecat;
            this.Observacion = observacion; ;
            this.Fecharegistro = fecharegistro;
            this.TextoBuscar = textobuscar;

        }


        //Método Insertar

        public string Insertar(DCategoria Categoria)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCod_categoria = new SqlParameter();
                ParCod_categoria.ParameterName = "@id_categoria";
                ParCod_categoria.SqlDbType = SqlDbType.Int;
                ParCod_categoria.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParCod_categoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombrecat";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Categoria.Nombrecat;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@observacion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Categoria.Observacion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParFecha_Nacimiento = new SqlParameter();
                ParFecha_Nacimiento.ParameterName = "@fecharegistro";
                ParFecha_Nacimiento.SqlDbType = SqlDbType.Date;
                ParFecha_Nacimiento.Size = 40;
                ParFecha_Nacimiento.Value = Categoria.Fecharegistro;
                SqlCmd.Parameters.Add(ParFecha_Nacimiento);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }

        //Método Editar
        public string Editar(DCategoria Categoria)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCod_categoria = new SqlParameter();
                ParCod_categoria.ParameterName = "@id_categoria";
                ParCod_categoria.SqlDbType = SqlDbType.Int;
                ParCod_categoria.Value = Categoria.Id_categoria;
                SqlCmd.Parameters.Add(ParCod_categoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombrecat";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Categoria.Nombrecat;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@observacion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Categoria.Observacion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParFecha_Nacimiento = new SqlParameter();
                ParFecha_Nacimiento.ParameterName = "@fecha_nacimiento";
                ParFecha_Nacimiento.SqlDbType = SqlDbType.Date;
                ParFecha_Nacimiento.Size = 40;
                ParFecha_Nacimiento.Value = Categoria.Fecharegistro;
                SqlCmd.Parameters.Add(ParFecha_Nacimiento);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Método Eliminar
        public string Eliminar(DCategoria Categoria)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCod_categoria = new SqlParameter();
                ParCod_categoria.ParameterName = "@id_categoria";
                ParCod_categoria.SqlDbType = SqlDbType.Int;
                ParCod_categoria.Value = Categoria.Id_categoria;
                SqlCmd.Parameters.Add(ParCod_categoria);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }


        //Método BuscarNombre
        public DataTable BuscarNombre(DCategoria Categoria)
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Categoria.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
    }

}
