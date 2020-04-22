using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
   public  class DCliente : DPersona
    {
        /*
        //Variables
        private int _Cod_cliente;
        private int _Persona;
        private string _Tipo_cliente;
        private string _Genero;
        private string _Estado;
        private string _TextoBuscar;


        //Propiedades
        //Métodos Setter an Getter Propiedades
        public int Cod_cliente
        {
            get { return _Cod_cliente; }
            set { _Cod_cliente = value; }
        }
   
        public int Persona
        {
            get { return _Persona; }
            set { _Persona = value; }
        }

        public string Tipo_cliente
        {
            get { return _Tipo_cliente; }
            set { _Tipo_cliente = value; }
        }

        public string Genero
        {
            get { return _Genero; }
            set { _Genero = value; }
        }

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        //Constructores
        public DCliente()
        {

        }

        public DCliente(int cod_cliente, int persona, string nombre, string apellido, string genero, string fecha_nacimiento, string tipo_Cliente, string num_documento, string direccion, string telefono, string email, string textobuscar, string estado)
        {
            this.Cod_cliente = cod_cliente;
            this.Persona = persona;
            this.Nombre = nombre;
            this.Apellido_sucursal = apellido;
            this.Genero = genero;
            this.Fechanac_fechaconstitucion = fecha_nacimiento;
            this.Tipo_cliente = tipo_Cliente;
            this.Cedula_ruc = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Correo = email;
            this.Estado = estado;

            this.TextoBuscar = textobuscar;
        }

        //Método Insertar

        public string Insertar(DCliente Cliente)
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
                SqlCmd.CommandText = "SpInsertarCliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parCedulaRuc = new SqlParameter();
                parCedulaRuc.ParameterName = "@cedula_ruc";
                parCedulaRuc.SqlDbType = SqlDbType.VarChar;
                parCedulaRuc.Size = 50;
                parCedulaRuc.Value = Cliente.Cedula_ruc;
                SqlCmd.Parameters.Add(parCedulaRuc);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = Cliente.Nombre;
                SqlCmd.Parameters.Add(parNombre);

                SqlParameter parApellidos = new SqlParameter();
                parApellidos.ParameterName = "@apellido_sucursal";
                parApellidos.SqlDbType = SqlDbType.VarChar;
                parApellidos.Size = 50;
                parApellidos.Value = Cliente.Apellido_sucursal;
                SqlCmd.Parameters.Add(parApellidos);

                SqlParameter ParFecha_Nacimiento = new SqlParameter();
                ParFecha_Nacimiento.ParameterName = "@fechanac_fechaconstitucion";
                ParFecha_Nacimiento.SqlDbType = SqlDbType.VarChar;
                ParFecha_Nacimiento.Size = 50;
                ParFecha_Nacimiento.Value = Cliente.Fechanac_fechaconstitucion;
                SqlCmd.Parameters.Add(ParFecha_Nacimiento);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.Int;
                ParTelefono.Value = Cliente.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@correo";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 30;
                ParEmail.Value = Cliente.Correo;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Cliente.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter parTipoCliente = new SqlParameter();
                parTipoCliente.ParameterName = "@tipo_cliente";
                parTipoCliente.Size = 1;
                parTipoCliente.Value = Cliente.Tipo_cliente;
                SqlCmd.Parameters.Add(parTipoCliente);


                SqlParameter ParGenero = new SqlParameter();
                ParGenero.ParameterName = "@genero";
                ParGenero.SqlDbType = SqlDbType.VarChar;
                ParGenero.Size = 1;
                ParGenero.Value = Cliente.Genero;
                SqlCmd.Parameters.Add(ParGenero);

                SqlParameter parEstado = new SqlParameter();
                parEstado.ParameterName = "@estado";
                parEstado.SqlDbType = SqlDbType.VarChar;
                parEstado.Size = 1;
                SqlCmd.Parameters.Add(parEstado);
                /*
                SqlParameter ParTipo_Documento = new SqlParameter();
                ParTipo_Documento.ParameterName = "@tipo_documento";
                ParTipo_Documento.SqlDbType = SqlDbType.VarChar;
                ParTipo_Documento.Size = 20;
                ParTipo_Documento.Value = Cliente.Tipo_Documento;
                SqlCmd.Parameters.Add(ParTipo_Documento);
               


                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParNum_Documento.Size = 8;
                ParNum_Documento.Value = Cliente.Num_Documento;
                SqlCmd.Parameters.Add(ParNum_Documento);
                 */


        //Ejecutamos nuestro comando
        /*
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
        
        /*
        //Método Editar
        public string Editar(DCliente Cliente)
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
                SqlCmd.CommandText = "speditar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCod_cliente = new SqlParameter();
                ParCod_cliente.ParameterName = "@cod_cliente";
                ParCod_cliente.SqlDbType = SqlDbType.Int;
                ParCod_cliente.Value = Cliente.Cod_cliente;
                SqlCmd.Parameters.Add(ParCod_cliente);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 20;
                ParNombre.Value = Cliente.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@apellidos";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 40;
                ParApellidos.Value = Cliente.Apellidos;
                SqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParGenero = new SqlParameter();
                ParGenero.ParameterName = "@genero";
                ParGenero.SqlDbType = SqlDbType.VarChar;
                ParGenero.Size = 1;
                ParGenero.Value = Cliente.Genero;
                SqlCmd.Parameters.Add(ParGenero);

                SqlParameter ParFecha_Nacimiento = new SqlParameter();
                ParFecha_Nacimiento.ParameterName = "@fecha_nacimiento";
                ParFecha_Nacimiento.SqlDbType = SqlDbType.VarChar;
                ParFecha_Nacimiento.Size = 40;
                ParFecha_Nacimiento.Value = Cliente.Fecha_Nacimiento;
                SqlCmd.Parameters.Add(ParFecha_Nacimiento);

                SqlParameter ParTipo_Documento = new SqlParameter();
                ParTipo_Documento.ParameterName = "@tipo_documento";
                ParTipo_Documento.SqlDbType = SqlDbType.VarChar;
                ParTipo_Documento.Size = 20;
                ParTipo_Documento.Value = Cliente.Tipo_Documento;
                SqlCmd.Parameters.Add(ParTipo_Documento);

                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParNum_Documento.Size = 8;
                ParNum_Documento.Value = Cliente.Num_Documento;
                SqlCmd.Parameters.Add(ParNum_Documento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Cliente.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = Cliente.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Cliente.Email;
                SqlCmd.Parameters.Add(ParEmail);

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

    */
        /*
            //Método Eliminar
            public string Eliminar(DCliente Cliente)
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
                    SqlCmd.CommandText = "speliminar_cliente";
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParCod_cliente = new SqlParameter();
                    ParCod_cliente.ParameterName = "@cod_cliente";
                    ParCod_cliente.SqlDbType = SqlDbType.Int;
                    ParCod_cliente.Value = Cliente.Cod_cliente;
                    SqlCmd.Parameters.Add(ParCod_cliente);
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
                DataTable DtResultado = new DataTable("cliente");
                SqlConnection SqlCon = new SqlConnection();
                try
                {
                    SqlCon.ConnectionString = Conexion.Cn;
                    SqlCommand SqlCmd = new SqlCommand();
                    SqlCmd.Connection = SqlCon;
                    SqlCmd.CommandText = "spListarCliente";
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


            //Método BuscarApellidos
            public DataTable BuscarApellidos(DCliente Cliente)
            {
                DataTable DtResultado = new DataTable("cliente");
                SqlConnection SqlCon = new SqlConnection();
                try
                {
                    SqlCon.ConnectionString = Conexion.Cn;
                    SqlCommand SqlCmd = new SqlCommand();
                    SqlCmd.Connection = SqlCon;
                    SqlCmd.CommandText = "spbuscar_cliente_apellidos";
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParTextoBuscar = new SqlParameter();
                    ParTextoBuscar.ParameterName = "@textobuscar";
                    ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                    ParTextoBuscar.Size = 50;
                    ParTextoBuscar.Value = Cliente.TextoBuscar;
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

            //Método BuscarNum_Documento
            public DataTable BuscarNum_Documento(DCliente Cliente)
            {
                DataTable DtResultado = new DataTable("cliente");
                SqlConnection SqlCon = new SqlConnection();
                try
                {
                    SqlCon.ConnectionString = Conexion.Cn;
                    SqlCommand SqlCmd = new SqlCommand();
                    SqlCmd.Connection = SqlCon;
                    SqlCmd.CommandText = "spbuscar_cliente_num_documento";
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParTextoBuscar = new SqlParameter();
                    ParTextoBuscar.ParameterName = "@textobuscar";
                    ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                    ParTextoBuscar.Size = 50;
                    ParTextoBuscar.Value = Cliente.TextoBuscar;
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

      */
    }
}
